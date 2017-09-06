using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace pmb.sm
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    this.PanelDetailPendaftar.Visible = false;

                    string CS = ConfigurationManager.ConnectionStrings["PMDK"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();

                        SqlCommand CmdReq = new SqlCommand("SELECT nomor, nama, email, path_foto, snd, id_account, tahun "+
                                                           "FROM pmdk_account "+
                                                           "WHERE (bpd = 'no') AND (tahun = '2017/2018') ", con);
                        //CmdPeriodik.Transaction = trans;
                        CmdReq.CommandType = System.Data.CommandType.Text;
                        DataTable TableReq = new DataTable();
                        TableReq.Columns.Add("No Billing");
                        TableReq.Columns.Add("Nama");
                        TableReq.Columns.Add("Email");
                        TableReq.Columns.Add("Bukti");
                        TableReq.Columns.Add("Pengiriman");
                        TableReq.Columns.Add("Foto");
                        TableReq.Columns.Add("Tahun");

                        using (SqlDataReader rdr = CmdReq.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    DataRow datarow = TableReq.NewRow();
                                    datarow["No Billing"] = rdr["id_account"];
                                    datarow["Nama"] = rdr["nama"];
                                    datarow["Email"] = rdr["email"];

                                    //------------- --------------
                                    if (rdr["path_foto"] != DBNull.Value)
                                    {
                                        datarow["Bukti"] = "Ada";
                                    }
                                    else
                                    {
                                        datarow["Bukti"] = "Tidak Ada";
                                    }

                                    // ---------- ------------
                                    if (rdr["snd"] != DBNull.Value)
                                    {
                                        if (rdr["snd"].ToString() == "yes")
                                        {
                                            datarow["Pengiriman"] = "Terkirim";
                                        }
                                        else
                                        {
                                            datarow["Pengiriman"] = "Belum Dikirim";
                                        }

                                    }
                                    else
                                    {
                                        datarow["Pengiriman"] = "NULL";
                                    }
                                    datarow["Tahun"] = rdr["tahun"];
                                    datarow["Foto"] = rdr["path_foto"];


                                    TableReq.Rows.Add(datarow);
                                }
                                //Fill Gridview
                                this.GVListDaftarPmdk.DataSource = TableReq;
                                this.GVListDaftarPmdk.DataBind();

                            }
                            else
                            {
                                //clear Gridview
                                TableReq.Rows.Clear();
                                TableReq.Clear();
                                this.GVListDaftarPmdk.DataSource = TableReq;
                                this.GVListDaftarPmdk.DataBind();
                            }
                        }

                        CmdReq.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }
            }
        }

        protected void BtnLihat_Click(object sender, EventArgs e)
        {
            this.PanelDetailPendaftar.Visible = true;
            this.PanelDetailPendaftar.Enabled = true;

            // get row index
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            //Response.Write( this.GVJadwal.Rows[index].Cells[3].Text);

            //set lb no jadwal
            this.LbNama.Text = this.GVListDaftarPmdk.Rows[index].Cells[2].Text;
            this.LbBill.Text = this.GVListDaftarPmdk.Rows[index].Cells[1].Text;


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMDK"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand( "SELECT pmdk_account.nomor, pmdk_posting_bank.billingNo, pmdk_account.no_daftar, pmdk_account.nama, pmdk_account.email, pmdk_account.snd, pmdk_account.path_foto "+
                                                            "FROM pmdk_account INNER JOIN "+
                                                            "pmdk_posting_bank ON pmdk_account.id_account = pmdk_posting_bank.billingNo "+
                                                            "WHERE billingNo = @NoBill", connection);
                    CmdDisplay.Parameters.AddWithValue("@NoBill", this.LbBill.Text); 

                    using (SqlDataReader reader = CmdDisplay.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //------------ read on real server ---------------
                                try
                                {
                                    Image1.ImageUrl = "http://pmdk.untidar.ac.id/kwe/" + reader["path_foto"].ToString();

                                    // Response.Write(reader["pth_bukti"].ToString());

                                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://pmdk.untidar.ac.id/kwe/" + reader["path_foto"].ToString());
                                    req.AllowAutoRedirect = false;
                                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                    if (res.StatusCode == HttpStatusCode.OK)
                                    {
                                        Image1.ImageUrl = "http://pmdk.untidar.ac.id/kwe/" + reader["path_foto"].ToString();
                                    }
                                    Response.Write(reader["path_foto"].ToString());

                                }
                                catch (Exception ex)
                                {
                                    Image1.ImageUrl = "";

                                    Response.Write(ex.Message.ToString());
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }

                                ////------------ read on local server ---------------
                                //try
                                //{
                                //    if (Image1.ImageUrl == "")
                                //    {
                                //        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/ukt/kwitansi_sb/" + reader["pth_bukti"].ToString());
                                //        req2.AllowAutoRedirect = false;
                                //        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                                //        if (res2.StatusCode == HttpStatusCode.OK)
                                //        {
                                //            Image1.ImageUrl = "http://localhost/ukt/kwitansi_sb/" + reader["pth_bukti"].ToString();
                                //        }
                                //        else
                                //        {
                                //            Image1.ImageUrl = "";
                                //        }

                                //    }
                                //}
                                //catch (Exception ex)
                                //{
                                //    Image1.ImageUrl = "";
                                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                //}
                            }
                        }
                    }
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    this.PanelDetailPendaftar.Visible = false;
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void BtnSah_Click(object sender, EventArgs e)
        {
            //Response.Write(this.LbNoPendaftaran.Text);
            //Response.Write(this.LbBill.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PMDK"].ConnectionString))
                {
                    connection.Open();
                    SqlTransaction trans = connection.BeginTransaction();
                    try
                    {
                        //A.--------------- Read Data Pendaftaran ----------------------
                        string NoAkunPembayaran = "";
                        string NamaPeserta = "";
                        string PIN = "";
                        string Email = "";

                        SqlCommand cmdRead = new SqlCommand("SELECT nomor, id_account, nama, pin, email, tahun "+
                                                            "FROM pmdk_account " +
                                                            "WHERE (id_account=@NoAkun)", connection);
                        cmdRead.Transaction = trans;
                        cmdRead.CommandType = System.Data.CommandType.Text;
                        cmdRead.Parameters.AddWithValue("@NoAkun", this.LbBill.Text);

                        using (SqlDataReader reader = cmdRead.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    NamaPeserta = reader["nama"].ToString().Trim();
                                    NoAkunPembayaran = reader["id_account"].ToString().Trim();
                                    PIN = reader["pin"].ToString().Trim();
                                    Email = reader["email"].ToString().Trim();
                                }
                            }
                        }

                        //B. --------------- Update Status Bayar ---------------------
                        // Update Jenis Pembayaran Bukan Bank Jateng
                        SqlCommand CmdUpdate = new SqlCommand("update pmdk_posting_bank set pay_date=GETDATE(), status='paid' where billingNo=@bill", connection);
                        CmdUpdate.Transaction = trans;
                        CmdUpdate.CommandType = System.Data.CommandType.Text;

                        CmdUpdate.Parameters.AddWithValue("@bill", this.LbBill.Text.Trim());
                        CmdUpdate.ExecuteNonQuery();

                        //C. --------------- Update Status Kirim ---------------------
                        // Update Jenis Pembayaran Bukan Bank Jateng
                        SqlCommand CmdStatusKirim = new SqlCommand("update pmdk_account set snd='yes' where id_account=@NoAkun AND nama=@nama", connection);
                        CmdStatusKirim.Transaction = trans;
                        CmdStatusKirim.CommandType = System.Data.CommandType.Text;

                        CmdStatusKirim.Parameters.AddWithValue("@NoAkun", this.LbBill.Text.Trim());
                        CmdStatusKirim.Parameters.AddWithValue("@nama", this.LbNama.Text.Trim());
                        CmdStatusKirim.ExecuteNonQuery();

                        //C.--------------- Kirim Email --------------------
                        Response.Write(NamaPeserta.ToString());

                        using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", Email.Trim()))
                        {
                            mm.Subject = "Registrasi PMDK ";
                            mm.Body = "Sdr/i. " + NamaPeserta + ", yang terhormat,\r\n" +
                                "Terima kasih telah melunasi biaya pendaftaran PMDK. Data pendaftaran Anda yang tercacat pada sistem kami adalah :\r\n" +
                                "No Akun : " + NoAkunPembayaran + "\r\n" +
                                "Nama Peserta : " + NamaPeserta + "\r\n" +
                                "PIN : " + PIN + "\r\n" +
                                "Segera Catat & Simpan Data Pendaftaran " + "\r\n" +
                                "=======================================================================================" + "\r\n" +
                                "LOGIN PADA LAMAN http://pmdk.untidar.ac.id/login MENGGUNAKAN NOMOR AKUN DAN PIN" + "\r\n" +
                                "=======================================================================================";

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
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email Terkirim.');", true);
                        }

                        trans.Commit();
                        cmdRead.Dispose();
                        CmdStatusKirim.Dispose();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        connection.Close();
                        connection.Dispose();
                        Response.Write(ex.Message.ToString());
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }


        }
    }
}