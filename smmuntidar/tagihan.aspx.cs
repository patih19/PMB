using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace smmuntidar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  BANK BPD JATENG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Filter Input
            if (this.TbNama.Text.Trim() == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama Harus Diisi');", true);
                return;
            }
            if (this.TbNoIdentitas.Text.Trim() == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nomor Identitas Harus Diisi');", true);
                return;
            }
            if (this.TbEmail.Text.Trim() == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Email Harus Diisi');", true);
                return;
            }
            if (this.TbCaptcha.Text.Trim() == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Harus Diisi');", true);
                return;
            }

            this.Captcha.ValidateCaptcha(this.TbCaptcha.Text.Trim());
            try
            {
                if (this.Captcha.UserValidated)
                {
                    string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        //open connection and begin transaction
                        con.Open();
                        SqlTransaction trans = con.BeginTransaction();

                        try
                        {
                            // 1. ------ Cek Masa Pendaftaran -------
                            SqlCommand CmdCekMasa = new SqlCommand("SpCekMasaDaftar", con);
                            CmdCekMasa.Transaction = trans;
                            CmdCekMasa.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdCekMasa.Parameters.AddWithValue("@jenis_keg", "daftar");

                            SqlParameter Status = new SqlParameter();
                            Status.ParameterName = "@output";
                            Status.SqlDbType = System.Data.SqlDbType.VarChar;
                            Status.Size = 50;
                            Status.Direction = System.Data.ParameterDirection.Output;
                            CmdCekMasa.Parameters.Add(Status);

                            CmdCekMasa.ExecuteNonQuery();

                            if (Status.Value.ToString() != "BUKA")
                            {
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Proses Tidak Sesuai Jadwal Pendaftaran !');", true);
                                return;
                            }

                            // Insert Tagihan pendaftar
                            SqlCommand CmdTagihan = new SqlCommand("SpInsertNoTagihanSmmuntidar", con);
                            CmdTagihan.Transaction = trans;
                            CmdTagihan.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama.Text);
                            CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas.SelectedItem.Text);
                            CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas.Text);
                            CmdTagihan.Parameters.AddWithValue("@email", this.TbEmail.Text.Trim().ToLower());
                            string strPIN = GenerateIdentifier(6);
                            CmdTagihan.Parameters.AddWithValue("@pin", strPIN);

                            SqlParameter no_tagihan = new SqlParameter();
                            no_tagihan.ParameterName = "@no_tagihan";
                            no_tagihan.SqlDbType = System.Data.SqlDbType.VarChar;
                            no_tagihan.Direction = System.Data.ParameterDirection.Output;
                            no_tagihan.Size = 20;
                            CmdTagihan.Parameters.Add(no_tagihan);

                            SqlParameter no_pendaftaran = new SqlParameter();
                            no_pendaftaran.ParameterName = "@no_pendaftar";
                            no_pendaftaran.SqlDbType = System.Data.SqlDbType.VarChar;
                            no_pendaftaran.Direction = System.Data.ParameterDirection.Output;
                            no_pendaftaran.Size = 20;
                            CmdTagihan.Parameters.Add(no_pendaftaran);

                            CmdTagihan.ExecuteNonQuery();

                            //--------------------- Kirim Email ------------------------
                            using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", TbEmail.Text))
                            {
                                mm.Subject = "Registrasi SM-UNTIDAR";
                                mm.Body = "Sdr/i. " + TbNama.Text + " yang terhormat,\r\n" +
                                    "Terima kasih telah mendaftar Seleksi Mandiri Universitas Tidar Tahun 2017/2018. Data pendaftaran Anda yang terdaftar dalam sistem kami adalah :\r\n" +
                                    "No Pendaftaran : " + no_pendaftaran.Value.ToString() + "\r\n" +
                                    "download formulir pembayaran https://drive.google.com/file/d/0B9QhYV69qy4bcEJKckxYclIzSEk/view";

                                //if (fuAttachment.HasFile)
                                //{
                                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                                //}

                                mm.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("adminpmb@untidar.ac.id", "adminpmb12345");
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mm);

                                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                            }
                            // -------------------------- End Sesding Email ---------------------------------
                                                       
                            NoPendaftarJateng = no_pendaftaran.Value.ToString();
                            NamaJateng = this.TbNama.Text;

                            //this.NoTgJateng.Text = no_tagihan.Value.ToString();
                            //this.NoDfJateng.Text = no_pendaftaran.Value.ToString();

                            trans.Commit();
                            trans.Dispose();
                            CmdTagihan.Dispose();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            con.Close();
                            con.Dispose();
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                            return;
                        }
                    }
                    Server.Transfer("~/biaya.aspx");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        //public string NoPendaftarJateng
        //{
        //    get { return this.NoDfJateng.Text; }
        //}

        //public string NamaJateng
        //{
        //    get { return this.TbNama.Text; }
        //}
        public string NoPendaftarJateng { get; set; }
        public string NamaJateng { get; set; }


        private static string PinRandom(int size)
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] numArray = new byte[size];
            cryptoServiceProvider.GetBytes(numArray);
            return Convert.ToBase64String(numArray);
        }

        static readonly char[] AvailableCharacters = {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
            'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
         };

        internal static string GenerateIdentifier(int length)
        {
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                int pos = randomData[idx] % AvailableCharacters.Length;
                identifier[idx] = AvailableCharacters[pos];
            }

            return new string(identifier);
        }

        /// <summary>
        /// NON BANK JATENG (BNI 46)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Filter Input
            if (this.TbNama2.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama Harus Diisi');", true);
                return;
            }
            if (this.TbNoIdentitas2.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nomor Identitas Harus Diisi');", true);
                return;
            }
            if (this.TbEmail2.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Email Harus Diisi');", true);
                return;
            }
            if (this.TbCaptcha2.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Harus Diisi');", true);
                return;
            }

            this.Captcha2.ValidateCaptcha(this.TbCaptcha2.Text.Trim());
            try
            {
                if (this.Captcha2.UserValidated)
                {
                    string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        //open connection and begin transaction
                        con.Open();
                        SqlTransaction trans = con.BeginTransaction();

                        try
                        {
                            // ------ Cek Masa Pendaftaran -------
                            SqlCommand CmdCekMasa = new SqlCommand("SpCekMasaDaftar", con);
                            CmdCekMasa.Transaction = trans;
                            CmdCekMasa.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdCekMasa.Parameters.AddWithValue("@jenis_keg", "daftar");

                            SqlParameter Status = new SqlParameter();
                            Status.ParameterName = "@output";
                            Status.SqlDbType = System.Data.SqlDbType.VarChar;
                            Status.Size = 50;
                            Status.Direction = System.Data.ParameterDirection.Output;
                            CmdCekMasa.Parameters.Add(Status);

                            CmdCekMasa.ExecuteNonQuery();

                            if (Status.Value.ToString() != "BUKA")
                            {
                                trans.Rollback();
                                con.Close();

                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Proses Tidak Sesuai Jadwal Pendaftaran !');", true);
                                return;
                            }

                            // Insert Tagihan pendaftar
                            SqlCommand CmdTagihan = new SqlCommand("SpInsertNoTagihanSmmuntidar", con);
                            CmdTagihan.Transaction = trans;
                            CmdTagihan.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama2.Text.Trim());
                            CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas2.SelectedItem.Text.Trim());
                            CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas2.Text.Trim());
                            CmdTagihan.Parameters.AddWithValue("@email", this.TbEmail2.Text.Trim().ToLower());
                            string strPIN = GenerateIdentifier(6);
                            CmdTagihan.Parameters.AddWithValue("@pin", strPIN);

                            //CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama.Text);
                            //CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas.SelectedItem.Text);
                            //CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas.Text);
                            //string strPIN = GenerateIdentifier(8);
                            //CmdTagihan.Parameters.AddWithValue("@pin", strPIN);

                            SqlParameter no_tagihan = new SqlParameter();
                            no_tagihan.ParameterName = "@no_tagihan";
                            no_tagihan.SqlDbType = System.Data.SqlDbType.VarChar;
                            no_tagihan.Direction = System.Data.ParameterDirection.Output;
                            no_tagihan.Size = 20;
                            CmdTagihan.Parameters.Add(no_tagihan);

                            SqlParameter no_pendaftaran = new SqlParameter();
                            no_pendaftaran.ParameterName = "@no_pendaftar";
                            no_pendaftaran.SqlDbType = System.Data.SqlDbType.VarChar;
                            no_pendaftaran.Direction = System.Data.ParameterDirection.Output;
                            no_pendaftaran.Size = 20;
                            CmdTagihan.Parameters.Add(no_pendaftaran);

                            CmdTagihan.ExecuteNonQuery();


                            // Update Jenis Pembayaran Bukan Bank Jateng
                            SqlCommand CmdUpdate = new SqlCommand("UPDATE dbo.smmuntidar_tagihan SET bpd='no' WHERE no_tagihan=@no_tagihan", con);
                            CmdUpdate.Transaction = trans;
                            CmdUpdate.CommandType = System.Data.CommandType.Text;

                            CmdUpdate.Parameters.AddWithValue("@no_tagihan", no_tagihan.Value.ToString());
                            CmdUpdate.ExecuteNonQuery();

                            // Update Kode Pembayaran Bukan Bank Jateng
                            string strKodeTagihan = GenerateIdentifier(6);
                            SqlCommand CmdUpdateKode = new SqlCommand("UPDATE dbo.smmuntidar_tagihan SET kd_tagihan=@kode_tagihan WHERE no_tagihan=@no_tagihan", con);
                            CmdUpdateKode.Transaction = trans;
                            CmdUpdateKode.CommandType = System.Data.CommandType.Text;
                            CmdUpdateKode.Parameters.AddWithValue("@kode_tagihan", strKodeTagihan);
                            CmdUpdateKode.Parameters.AddWithValue("@no_tagihan", no_tagihan.Value.ToString());
                            CmdUpdateKode.ExecuteNonQuery();

                            // Get Kode Kode Tagihan
                            SqlCommand GetKodeTagihan = new SqlCommand("SELECT kd_tagihan FROM dbo.smmuntidar_tagihan WHERE no_tagihan=@no_tagihan AND bpd='no'", con);
                            GetKodeTagihan.Transaction = trans;
                            GetKodeTagihan.CommandType = System.Data.CommandType.Text;
                            GetKodeTagihan.Parameters.AddWithValue("@no_tagihan", no_tagihan.Value.ToString());

                            string KodeTagihan = "";

                            using (SqlDataReader rdr = GetKodeTagihan.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        KodeTagihan = rdr["kd_tagihan"].ToString();
                                    }
                                }
                                else
                                {
                                    trans.Rollback();
                                    con.Close();
                                    con.Dispose();

                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Tagihan Tidak Ditemukan');", true);
                                    return;
                                }
                            }



                            //----------------------- Kirim Email ----------------------
                            using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", TbEmail2.Text.Trim()))
                            {
                                mm.Subject = "Registrasi SM-UNTIDAR";
                                mm.Body = "Sdr/i. " + TbNama2.Text + " yang terhormat,\r\n" +
                                    "Terima kasih telah mendaftar Seleksi Mandiri Universitas Tidar Online Tahun 2017/2018. Data pendaftaran Anda yang tercacat pada sistem kami adalah :\r\n" +
                                    "No Pendaftaran : " + no_pendaftaran.Value.ToString() + "\r\n" +
                                    "Kode Tagihan : " + KodeTagihan + "\r\n" +
                                    "Nama Peserta : " + TbNama2.Text + "\r\n" +
                                    "Segera Catat & Simpan Data Pendaftaran " + "\r\n" +
                                    "============================================================" + "\r\n" +
                                    "PROSES BERIKUTNYA BACA PANDUAN PEMBAYARAN SEBELUM MEMBAYAR => https://drive.google.com/file/d/0B9QhYV69qy4bM21qR2RydkN2M2s/view" + "\r\n" +
                                    "============================================================";

                                //if (fuAttachment.HasFile)
                                //{
                                //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                                //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                                //}

                                mm.IsBodyHtml = false;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential("adminpmb@untidar.ac.id", "adminpmb12345");
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = 587;
                                smtp.Send(mm);
                                //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                            }
                            // -------------------------------- End Kirim Email ----------------------------------------

                            this.LbSuccessMsg.Text = "Proses Berhasil Tunggulah Beberapa Saat Kemudian Periksa Email Anda";
                            this.LbSuccessMsg.ForeColor = System.Drawing.Color.Green;

                            trans.Commit();
                            trans.Dispose();
                            CmdTagihan.Dispose();

                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            con.Close();
                            con.Dispose();
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                            return;
                        }
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                    return;
                }


            }
            catch (Exception)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Security code is not valid, please reload this page');", true);
                return;

            }
        }
    }
}