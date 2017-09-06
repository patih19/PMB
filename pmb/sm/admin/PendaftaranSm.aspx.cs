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
    public partial class WebForm21 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    this.PanelDetailPendaftar.Visible = false;

                    string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();

                        SqlCommand CmdReq = new SqlCommand( "SELECT no, no_tagihan, no_pendaftar, nama, tahun, email, foto,pth_bukti,snd "+
	                                                        "FROM smmuntidar_tagihan WHERE  bpd='no' AND  tahun = ( SELECT TOP 1 tahun FROM smmuntidar_tagihan GROUP BY tahun ORDER BY tahun DESC )  AND pth_bukti IS NOT NULL", con);
                        //CmdPeriodik.Transaction = trans;
                        CmdReq.CommandType = System.Data.CommandType.Text;
                        DataTable TableReq = new DataTable();
                        TableReq.Columns.Add("No Billing");
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
                                    datarow["No Billing"] = rdr["no_tagihan"];
                                    datarow["Nama"] = rdr["nama"];
                                    datarow["Email"] = rdr["email"];

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
                                    //else
                                    //{
                                    //    datarow["Pengiriman"] = "NULL";
                                    //}
                                    datarow["Tahun"] = rdr["tahun"];
                                    //datarow["Foto"] = rdr["path_foto"];


                                    TableReq.Rows.Add(datarow);
                                }
                                //Fill Gridview
                                this.GVListDaftarSM.DataSource = TableReq;
                                this.GVListDaftarSM.DataBind();

                            }
                            else
                            {
                                //clear Gridview
                                TableReq.Rows.Clear();
                                TableReq.Clear();
                                this.GVListDaftarSM.DataSource = TableReq;
                                this.GVListDaftarSM.DataBind();
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
            this.LbNama.Text = this.GVListDaftarSM.Rows[index].Cells[2].Text;
            this.LbBill.Text = this.GVListDaftarSM.Rows[index].Cells[1].Text;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("SELECT no,pth_bukti FROM dbo.smmuntidar_tagihan WHERE tahun= ( select top 1 tahun from smmuntidar_tagihan group by tahun order by tahun DESC ) AND bpd='no' AND no_tagihan=@no_tagihan ", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.LbBill.Text);

                    using (SqlDataReader reader = CmdDisplay.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            this.PanelDetailPendaftar.Visible = true;

                            while (reader.Read())
                            {
                                //------------ read on real server ---------------
                                try
                                {
                                    Image1.ImageUrl = "http://sm.untidar.ac.id/kwt/" + reader["pth_bukti"].ToString().Trim();

                                    // Response.Write(reader["pth_bukti"].ToString());

                                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://sm.untidar.ac.id/kwt/" + reader["pth_bukti"].ToString().Trim());
                                    req.AllowAutoRedirect = false;
                                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                    if (res.StatusCode == HttpStatusCode.OK)
                                    {
                                        Image1.ImageUrl = "http://sm.untidar.ac.id/kwt/" + reader["pth_bukti"].ToString().Trim();
                                    }
                                    //Response.Write(reader["pth_bukti"].ToString());

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
                                //        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/smuntidar/kwt/" + reader["pth_bukti"].ToString());
                                //        req2.AllowAutoRedirect = false;
                                //        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                                //        if (res2.StatusCode == HttpStatusCode.OK)
                                //        {
                                //            Image1.ImageUrl = "http://localhost/smuntidar/kwt/" + reader["pth_bukti"].ToString();
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
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
                {
                    connection.Open();
                    SqlTransaction trans = connection.BeginTransaction();
                    try
                    {
                        //A.--------------- Read Data Pendaftaran ----------------------
                        SqlCommand cmdRead = new SqlCommand("SpReadData", connection);
                        cmdRead.Transaction = trans;
                        cmdRead.CommandType = System.Data.CommandType.StoredProcedure;

                        cmdRead.Parameters.AddWithValue("@no_tagihan", this.LbBill.Text.Trim());

                        SqlParameter No_Pendaftaran = new SqlParameter();
                        No_Pendaftaran.ParameterName = "@no_pendaftaran";
                        No_Pendaftaran.SqlDbType = System.Data.SqlDbType.VarChar;
                        No_Pendaftaran.Direction = System.Data.ParameterDirection.Output;
                        No_Pendaftaran.Size = 12;
                        cmdRead.Parameters.Add(No_Pendaftaran);

                        SqlParameter nama = new SqlParameter();
                        nama.ParameterName = "@nama";
                        nama.SqlDbType = System.Data.SqlDbType.VarChar;
                        nama.Direction = System.Data.ParameterDirection.Output;
                        nama.Size = 50;
                        cmdRead.Parameters.Add(nama);

                        SqlParameter Pin = new SqlParameter();
                        Pin.ParameterName = "@Pin";
                        Pin.SqlDbType = System.Data.SqlDbType.VarChar;
                        Pin.Direction = System.Data.ParameterDirection.Output;
                        Pin.Size = 8;
                        cmdRead.Parameters.Add(Pin);

                        SqlParameter Jurnal = new SqlParameter();
                        Jurnal.ParameterName = "@Jurnal";
                        Jurnal.SqlDbType = System.Data.SqlDbType.VarChar;
                        Jurnal.Direction = System.Data.ParameterDirection.Output;
                        Jurnal.Size = 10;
                        cmdRead.Parameters.Add(Jurnal);

                        SqlParameter Email = new SqlParameter();
                        Email.ParameterName = "@Email";
                        Email.SqlDbType = System.Data.SqlDbType.VarChar;
                        Email.Direction = System.Data.ParameterDirection.Output;
                        Email.Size = 50;
                        cmdRead.Parameters.Add(Email);

                        cmdRead.ExecuteNonQuery();

                        //B. --------------- Update Status Kirim ---------------------
                        // Update Jenis Pembayaran Bukan Bank Jateng
                        SqlCommand CmdUpdate = new SqlCommand("UPDATE dbo.smmuntidar_tagihan SET snd='yes' WHERE no_tagihan=@no_jurnal", connection);
                        CmdUpdate.Transaction = trans;
                        CmdUpdate.CommandType = System.Data.CommandType.Text;

                        CmdUpdate.Parameters.AddWithValue("@no_jurnal", this.LbBill.Text.Trim());
                        CmdUpdate.ExecuteNonQuery();


                        //C. --------------- Update Status Bayar ---------------------
                        // Update Jenis Pembayaran Bukan Bank Jateng
                        SqlCommand CmdUpdatePaid = new SqlCommand("update smmuntidar_posting_bank set pay_date=GETDATE(), status='paid' where billingNo=@bill", connection);
                        CmdUpdatePaid.Transaction = trans;
                        CmdUpdatePaid.CommandType = System.Data.CommandType.Text;

                        CmdUpdatePaid.Parameters.AddWithValue("@bill", this.LbBill.Text.Trim());
                        CmdUpdatePaid.ExecuteNonQuery();


                        //D.--------------- Kirim Email --------------------
                        using (MailMessage mm = new MailMessage("adminpmb@untidar.ac.id", Email.Value.ToString()))
                        {
                            mm.Subject = "Registrasi SM-UNTIDAR";
                            mm.Body = "Sdr/i. " + nama.Value.ToString() + ", yang terhormat,\r\n" +
                                "Terima kasih telah mendaftar Seleksi Mandiri Universitas Tidar Tahun 2017/2018. Data pendaftaran Anda yang tercacat pada sistem kami adalah :\r\n" +
                                "No Pendaftaran : " + No_Pendaftaran.Value.ToString() + "\r\n" +
                                "Nama Peserta : " + nama.Value.ToString() + "\r\n" +
                                "PIN Pendaftaran : " + Pin.Value.ToString() + "\r\n" +
                                "Segera Catat & Simpan Data Pendaftaran " + "\r\n" +
                                "============================================================" + "\r\n" +
                                "PROSES BERIKUTNYA LOGIN PADA LAMAN/WEBSITE http://sm.untidar.ac.id" + "\r\n" +
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
                        CmdUpdate.Dispose();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        connection.Close();
                        connection.Dispose();
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