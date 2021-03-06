﻿using System;
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

namespace pmb.sm
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    this.PanelDetailPendaftar.Visible = false;

                    string CS = ConfigurationManager.ConnectionStrings["UKT"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();

                        SqlCommand CmdReq = new SqlCommand(" declare @TopThn varchar(10) "+
	                            "select top 1 @TopThn=tahun  from ukt_tahun_aktif order by tahun desc "+
	
	                            "SELECT     keu_posting_bank.billingNo, SMMTemp.nama, SMMTemp.pth_bukti, SMMTemp.email_aktif, SMMTemp.snd, SMMTemp.tahun, SMMTemp.no_pendaftar "+
	                            "FROM       SMMTemp INNER JOIN "+
						                              "keu_posting_bank ON SMMTemp.no_pendaftar = keu_posting_bank.payeeId "+
	                            "WHERE     (SMMTemp.tahun = @TopThn) AND (pth_bukti is not null)  AND ((SMMTemp.bpd = 'no') OR (SMMTemp.bpd = '') OR (SMMTemp.bpd is null) ) "+
	                            "ORDER BY SMMTemp.nama", con);
                        //CmdPeriodik.Transaction = trans;
                        CmdReq.CommandType = System.Data.CommandType.Text;

                        DataTable TableReq = new DataTable();
                        TableReq.Columns.Add("No Billing");
                        TableReq.Columns.Add("No Pendaftaran");
                        TableReq.Columns.Add("Nama");
                        TableReq.Columns.Add("Email");
                        TableReq.Columns.Add("Bukti");
                        TableReq.Columns.Add("Pengiriman");
                        TableReq.Columns.Add("Tahun");


                        using (SqlDataReader rdr = CmdReq.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    DataRow datarow = TableReq.NewRow();
                                    datarow["No Billing"] = rdr["billingNo"];
                                    datarow["No Pendaftaran"] = rdr["no_pendaftar"];
                                    datarow["Nama"] = rdr["nama"];
                                    datarow["Email"] = rdr["email_aktif"];

                                    //------------- --------------
                                    if (rdr["pth_bukti"] != DBNull.Value)
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
                                    TableReq.Rows.Add(datarow);
                                }

                                //Fill Gridview
                                this.GVListReq.DataSource = TableReq;
                                this.GVListReq.DataBind();

                            }
                            else
                            {
                                //clear Gridview
                                TableReq.Rows.Clear();
                                TableReq.Clear();
                                this.GVListReq.DataSource = TableReq;
                                this.GVListReq.DataBind();
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

            // get row index
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            //Response.Write( this.GVJadwal.Rows[index].Cells[3].Text);

            //set lb no jadwal
            this.LbNoPendaftaran.Text = this.GVListReq.Rows[index].Cells[2].Text.Trim();
            this.LbBill.Text = this.GVListReq.Rows[index].Cells[1].Text.Trim() ;
            this.LbNama.Text = this.GVListReq.Rows[index].Cells[3].Text.Trim();


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UKT"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("declare @TopThn varchar(10) "+
                                        "select top 1 @TopThn=tahun  from ukt_tahun_aktif order by tahun desc "+
	
                                        "SELECT     keu_posting_bank.billRef4, SMMTemp.no_pendaftar, SMMTemp.nama, SMMTemp.pth_bukti, SMMTemp.email_aktif, SMMTemp.tahun, SMMTemp.snd "+
                                        "FROM         SMMTemp INNER JOIN "+
                                                              "keu_posting_bank ON SMMTemp.no_pendaftar = keu_posting_bank.payeeId "+
                                        "WHERE      tahun=@TopThn AND (SMMTemp.no_pendaftar =@no_daftar )", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.LbNoPendaftaran.Text); // this.Session["Name"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //------------ read on real server ---------------
                            try
                            {
                                // Response.Write(reader["pth_bukti"].ToString());

                                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://ukt.untidar.ac.id/kwitansi_sm/" + reader["pth_bukti"].ToString());
                                req.AllowAutoRedirect = false;
                                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                if (res.StatusCode == HttpStatusCode.OK)
                                {
                                    Image1.ImageUrl = "http://ukt.untidar.ac.id/kwitansi_sm/" + reader["pth_bukti"].ToString();
                                }
                                //Response.Write(reader["pth_bukti"].ToString());

                            }
                            catch (Exception)
                            {
                                Image1.ImageUrl = "";
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                            }

                            //------------ read on local server ---------------
                            //try
                            //{
                            //    if (Image1.ImageUrl == "")
                            //    {
                            //        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/smmuntidar/kwt/" + reader["pth_bukti"].ToString());
                            //        req2.AllowAutoRedirect = false;
                            //        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                            //        if (res2.StatusCode == HttpStatusCode.OK)
                            //        {
                            //            Image1.ImageUrl = "http://localhost/smmuntidar/kwt/" + reader["pth_bukti"].ToString();
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
                    else
                    {
                        //Console.WriteLine("No Image found.");
                    }
                    reader.Close();
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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UKT"].ConnectionString))
            {
                connection.Open();
                SqlTransaction trans = connection.BeginTransaction();
                try
                {
                    //A.--------------- Read Data Pendaftaran ----------------------
                    string NoPendaftaran = "";
                    string NamaPeserta = "";
                    string PIN = "";
                    string Email = "";

                    SqlCommand cmdRead = new SqlCommand("declare @TopThn varchar(10)" +
                                        "select top 1 @TopThn=tahun  from ukt_tahun_aktif order by tahun desc " +

                                        "SELECT     keu_posting_bank.billRef4, SMMTemp.no_pendaftar, SMMTemp.nama, SMMTemp.pth_bukti, SMMTemp.email_aktif, SMMTemp.tahun, SMMTemp.snd " +
                                        "FROM         SMMTemp INNER JOIN " +
                                                              "keu_posting_bank ON SMMTemp.no_pendaftar = keu_posting_bank.payeeId " +
                                        "WHERE      tahun=@TopThn AND (SMMTemp.no_pendaftar =@no_daftar )", connection);
                    cmdRead.Transaction = trans;
                    cmdRead.CommandType = System.Data.CommandType.Text;

                    cmdRead.Parameters.AddWithValue("@no_daftar", this.LbNoPendaftaran.Text);

                    using (SqlDataReader reader = cmdRead.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                NamaPeserta = reader["nama"].ToString().Trim();
                                NoPendaftaran = reader["no_pendaftar"].ToString().Trim();
                                PIN = reader["billRef4"].ToString().Trim();
                                Email = reader["email_aktif"].ToString().Trim();
                            }
                        }
                    }

                    //B. --------------- Update Status Bayar ---------------------
                    // Update Jenis Pembayaran Bukan Bank Jateng
                    SqlCommand CmdUpdate = new SqlCommand("update keu_posting_bank set pay_date=GETDATE(), status='paid' where payeeId=@no_daftar AND billingNo=@bill", connection);
                    CmdUpdate.Transaction = trans;
                    CmdUpdate.CommandType = System.Data.CommandType.Text;

                    CmdUpdate.Parameters.AddWithValue("@no_daftar", this.LbNoPendaftaran.Text.Trim());
                    CmdUpdate.Parameters.AddWithValue("@bill", this.LbBill.Text.Trim());
                    CmdUpdate.ExecuteNonQuery();

                    //C. --------------- Update Status Kirim ---------------------
                    // Update Jenis Pembayaran Bukan Bank Jateng
                    SqlCommand CmdStatusKirim = new SqlCommand("UPDATE SMMTemp SET snd='yes' WHERE no_pendaftar=@no_pendaftar", connection);
                    CmdStatusKirim.Transaction = trans;
                    CmdStatusKirim.CommandType = System.Data.CommandType.Text;

                    CmdStatusKirim.Parameters.AddWithValue("@no_pendaftar", this.LbNoPendaftaran.Text);
                    CmdStatusKirim.ExecuteNonQuery();

                    //D.--------------- Kirim Email --------------------
                    using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", Email))
                    {
                        mm.Subject = "Registrasi SM-UNTIDAR";
                        mm.Body = "Sdr/i. " + NamaPeserta + ", yang terhormat,\r\n" +
                            "Terima kasih telah mendaftar Seleksi Mandiri Universitas Tidar Tahun 2017/2018. Data pendaftaran Anda yang tercacat pada sistem kami adalah :\r\n" +
                            "No Pendaftaran : " + NoPendaftaran + "\r\n" +
                            "Nama Peserta : " + NamaPeserta + "\r\n" +
                            "PIN Pendaftaran : " + PIN + "\r\n" +
                            "Segera Catat & Simpan Data Pendaftaran " + "\r\n" +
                            "============================================================" + "\r\n" +
                            "PROSES BERIKUTNYA LOGIN PADA LAMAN http://registrasi.untidar.ac.id MENGGUNAKAN NOMOR PENDAFTARAN DAN PIN" + "\r\n" +
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
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email Terkirim.');", true);
                    }

                    trans.Commit();
                    cmdRead.Dispose();
                    CmdStatusKirim.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message.ToString());

                    trans.Rollback();
                    connection.Close();
                    connection.Dispose();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}