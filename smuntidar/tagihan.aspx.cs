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


namespace smuntidar
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Filter Input
            if (this.TbNama.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama Harus Diisi');", true);
                return;
            }
            if (this.TbNoIdentitas.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nomor Identitas Harus Diisi');", true);
                return;
            }
            if (this.TbEmail.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Email Harus Diisi');", true);
                return;
            }
            if (this.TbCaptcha.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Harus Diisi');", true);
                return;
            }

            this.Captcha.ValidateCaptcha(this.TbCaptcha.Text.Trim());
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
                        SqlCommand CmdTagihan = new SqlCommand("SpInsertNoTagihanSmuntidar", con);
                        CmdTagihan.Transaction = trans;
                        CmdTagihan.CommandType = System.Data.CommandType.StoredProcedure;

                        CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama.Text);
                        CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas.SelectedItem.Text);
                        CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas.Text);
                        CmdTagihan.Parameters.AddWithValue("@email", this.TbEmail.Text);
                        string strPIN = GenerateIdentifier(8);
                        CmdTagihan.Parameters.AddWithValue("@pin", strPIN);

                        SqlParameter no_jurnal = new SqlParameter();
                        no_jurnal.ParameterName = "@no_tagihan";
                        no_jurnal.SqlDbType = System.Data.SqlDbType.VarChar;
                        no_jurnal.Direction = System.Data.ParameterDirection.Output;
                        no_jurnal.Size = 20;
                        CmdTagihan.Parameters.Add(no_jurnal);

                        SqlParameter no_pendaftaran = new SqlParameter();
                        no_pendaftaran.ParameterName = "@no_pendaftar";
                        no_pendaftaran.SqlDbType = System.Data.SqlDbType.VarChar;
                        no_pendaftaran.Direction = System.Data.ParameterDirection.Output;
                        no_pendaftaran.Size = 20;
                        CmdTagihan.Parameters.Add(no_pendaftaran);

                        CmdTagihan.ExecuteNonQuery();

                        //Kirim Email
                        //---------------------------------------------
                        using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", TbEmail.Text))
                        {
                            mm.Subject = "Registrasi SM-UNTIDAR";
                            mm.Body = "Sdr/i. " + TbNama.Text + " yang terhormat,\r\n" +
                                "Terima kasih telah mendaftar Seleksi Masuk Universitas Tidar Online Tahun 2015/2016. Data pendaftaran anda yang terdaftar di sistem kami adalah :\r\n" +
                                "No Pendaftaran : " + no_pendaftaran.Value.ToString() + "\r\n" +
                                "download form pembayaran https://drive.google.com/file/d/0B9QhYV69qy4bcUJseHFWQnhucW8/view?usp=sharing";

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
                        // ------------------------------------------------------------------------

                        this.bl.Text = no_jurnal.Value.ToString();
                        this.pn.Text = no_pendaftaran.Value.ToString();

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
                //Response.Redirect("~/biaya.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                return;
            }
        }

        public string NoPendaftar
        {
            get { return this.pn.Text;}
        }
        public string Nama
        {
            get { return this.TbNama.Text; }
        }

        private static string PinRandom(int size)
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] numArray = new byte[size];
            cryptoServiceProvider.GetBytes(numArray);
            return Convert.ToBase64String(numArray);
        }

        static readonly char[] AvailableCharacters = {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
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
                        SqlCommand CmdTagihan = new SqlCommand("SpInsertNoTagihanSmuntidar", con);
                        CmdTagihan.Transaction = trans;
                        CmdTagihan.CommandType = System.Data.CommandType.StoredProcedure;

                        CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama2.Text);
                        CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas2.SelectedItem.Text);
                        CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas2.Text);
                        CmdTagihan.Parameters.AddWithValue("@email", this.TbEmail2.Text);
                        string strPIN = GenerateIdentifier(8);
                        CmdTagihan.Parameters.AddWithValue("@pin", strPIN);

                        SqlParameter no_jurnal = new SqlParameter();
                        no_jurnal.ParameterName = "@no_tagihan";
                        no_jurnal.SqlDbType = System.Data.SqlDbType.VarChar;
                        no_jurnal.Direction = System.Data.ParameterDirection.Output;
                        no_jurnal.Size = 20;
                        CmdTagihan.Parameters.Add(no_jurnal);

                        SqlParameter no_pendaftaran = new SqlParameter();
                        no_pendaftaran.ParameterName = "@no_pendaftar";
                        no_pendaftaran.SqlDbType = System.Data.SqlDbType.VarChar;
                        no_pendaftaran.Direction = System.Data.ParameterDirection.Output;
                        no_pendaftaran.Size = 20;
                        CmdTagihan.Parameters.Add(no_pendaftaran);

                        CmdTagihan.ExecuteNonQuery();


                        // Update Jenis Pembayaran Bukan Bank Jateng
                        SqlCommand CmdUpdate= new SqlCommand("UPDATE dbo.smuntidar_tagihan SET bpd='no' WHERE no_tagihan=@no_jurnal", con);
                        CmdUpdate.Transaction = trans;
                        CmdUpdate.CommandType = System.Data.CommandType.Text;

                        CmdUpdate.Parameters.AddWithValue("@no_jurnal", no_jurnal.Value.ToString());
                        CmdUpdate.ExecuteNonQuery();

                        //Kirim Email
                        //---------------------------------------------
                        using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", TbEmail2.Text))
                        {
                            mm.Subject = "Registrasi SM-UNTIDAR";
                            mm.Body = "Sdr/i. " + TbNama2.Text + " yang terhormat,\r\n" +
                                "Terima kasih telah mendaftar Seleksi Masuk Universitas Tidar Online Tahun 2015/2016. Data pendaftaran Anda yang tercacat pada sistem kami adalah :\r\n" +
                                "No Pendaftaran : " + no_pendaftaran.Value.ToString() + "\r\n" +
                                "No Jurnal : " + no_jurnal.Value.ToString() + "\r\n" +
                                "Nama Peserta : " + TbNama2.Text + "\r\n" +
                                "Segera Catat & Simpan Data Pendaftaran " + "\r\n" +
                                "============================================================" + "\r\n" +
                                "PROSES BERIKUTNYA MEMBAYAR BIAYA PENDAFTARAN DI BANK" +"\r\n"+
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
                        // ------------------------------------------------------------------------

                        this.bl2.Text = no_jurnal.Value.ToString();
                        this.pn2.Text = no_pendaftaran.Value.ToString();

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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Proses Berhasil Tunggulah Beberapa Saat Kemudian Periksa Email Anda');", true);
                //Server.Transfer("~/biaya.aspx");
                //Response.Redirect("~/biaya.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                return;
            }
        }
    }
}