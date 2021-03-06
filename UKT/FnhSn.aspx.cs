﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace UKT
{
    public partial class WebForm13 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelSNMPTN.Enabled = false;
                this.PanelSNMPTN.Visible = false;

                // Cek Kelengkapan Pengiisian Borang
                string CS2 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS2))
                {
                    try
                    {
                        con.Open();

                        //------------ CEK KELENGKAPAN BORANG --------------
                        SqlCommand cmd = new SqlCommand("SpCekKelengkapanBorang", con);
                        //cmd.Transaction = trans;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.ExecuteNonQuery();


                        //------------ GET UKT JALUR SNMPTN -------------------
                        //Response.Write(this.Session["NoDaftar"].ToString());
                        SqlCommand cmdJlSNMPTN = new SqlCommand(    " SELECT ukt_master.kategori, SnmptnTemp.nama_siswa, SnmptnTemp.idprodi, SnmptnTemp.terima, ukt_master.biaya, SnmptnTemp.bdk, SnmptnTemp.nomor_pendaftaran" +
                                                                    " FROM SnmptnTemp LEFT OUTER JOIN "+
                                                                    " ukt_master ON SnmptnTemp.tahun = ukt_master.thn_ukt AND SnmptnTemp.idprodi = ukt_master.kode AND SnmptnTemp.ukt = ukt_master.kategori " +
                                                                    " where nomor_pendaftaran=@no_daftar", con);
                        //cmd.Transaction = trans;
                        cmdJlSNMPTN.CommandType = System.Data.CommandType.Text;
                        cmdJlSNMPTN.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        using (SqlDataReader rdrSNMPTN = cmdJlSNMPTN.ExecuteReader())
                        {
                            if (rdrSNMPTN.HasRows)
                            {
                                this.PanelSNMPTN.Enabled = true;
                                this.PanelSNMPTN.Visible = true;

                                while (rdrSNMPTN.Read())
                                {
                                    if (rdrSNMPTN["biaya"] == DBNull.Value)
                                    {
                                        if (rdrSNMPTN["bdk"].ToString() == "1")
                                        {
                                            int BiayaBM = 0;
                                            string FormattedStringBM = string.Format
                                                (new System.Globalization.CultureInfo("id"), "{0:c}", BiayaBM);
                                            this.LbUktSNMPTN.Text = FormattedStringBM + ", Anda SEMENTARA Terdaftar Sebagai Mahasiswa BIDIK MISI";

                                            this.PanelPanduan.Visible = false;
                                            this.PanelPanduan.Enabled = false;
                                        }
                                        else
                                        {
                                            this.LbUktSNMPTN.Text = "Biaya UKT Anda Belum Ditetapkan.";

                                            this.PanelPanduan.Visible = false;
                                            this.PanelPanduan.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        int Biaya = Convert.ToInt32(rdrSNMPTN["biaya"].ToString());
                                        string FormattedString = string.Format
                                            (new System.Globalization.CultureInfo("id"), "{0:N2}", Biaya);

                                        this.LbUktSNMPTN.Text = FormattedString;
                                    }
                                }
                            }                            
                        }

                    }
                    catch (Exception)
                    {
                        Response.Redirect("Pri.aspx", false);
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Server.Transfer("~/am/KartuUTS.aspx", true);   
                DoDownloadUKT("Borang_UKT_" + this.Session["NoDaftar"].ToString());
            }
            catch (Exception ex)
            {
                this.Lberr.Text = ex.Message.ToString();
            }
        }

        private void DoDownloadUKT(string FileName)
        {
            try
            {
                //var url = "http://localhost:2281/am/PrintKRS3.aspx?nim="+LbNPM.Text+"&semester="+Tahun+Semester+"";
                var url = Request.Url.AbsoluteUri;

                //ndf ==> Nomor Pendaftaran
                int IndMiring = url.LastIndexOf('/');
                var NewUrl = url.Substring(0, IndMiring + 1) + "Prt.aspx?ndf=" + this.Session["NoDaftar"].ToString() + "";

                //return;
                var file = WKHtmlToPdf(NewUrl);
                if (file != null)
                {
                    Response.ContentType = "Application/pdf";
                    Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".pdf");
                    Response.BinaryWrite(file);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                this.Lberr.Text = ex.Message.ToString();
            }

        }

        public byte[] WKHtmlToPdf(string url)
        {
            var fileName = " - ";
            var wkhtmlDir = "C:\\Program Files\\wkhtmltopdf\\";
            var wkhtml = "C:\\Program Files\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            var p = new Process();

            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = wkhtml;
            p.StartInfo.WorkingDirectory = wkhtmlDir;

            string switches = "";
            switches += "--print-media-type ";
            switches += "--margin-top 10mm --margin-bottom 0mm --margin-right 0mm --margin-left 0mm ";
            switches += "--page-size A4 ";
            switches += "--disable-smart-shrinking";
            p.StartInfo.Arguments = switches + " " + url + " " + fileName;
            p.Start();

            //read output
            byte[] buffer = new byte[32768];
            byte[] file;
            using (var ms = new MemoryStream())
            {
                while (true)
                {
                    int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length);

                    if (read <= 0)
                    {
                        break;
                    }
                    ms.Write(buffer, 0, read);
                }
                file = ms.ToArray();
            }

            // wait or exit
            p.WaitForExit(60000);

            // read the exit code, close process
            int returnCode = p.ExitCode;
            p.Close();

            return returnCode == 0 ? file : null;
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.FileName == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File belum dipilih');", true);
                return;
            }

            if (FileUpload1.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama file tidak boleh lebih dari 25 karakter');", true);
                return;
            }

            if (this.TbEmail.Text.Trim() == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Email wajib diisi');", true);
                return;
            }

            //cek jalur masuk
            string jalur = "";
            string CS2 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS2))
            {
                try
                {
                    con.Open();
                    SqlCommand CmdJalur = new SqlCommand("SpCekJalurMasuk", con);
                    CmdJalur.CommandType = System.Data.CommandType.StoredProcedure;
                    CmdJalur.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    using (SqlDataReader RdrJalur = CmdJalur.ExecuteReader())
                    {
                        if (RdrJalur.HasRows)
                        {
                            while (RdrJalur.Read())
                            {
                                //jalur => SNMPTN, SBMPTN, SM-UNTIDAR dan SMM-UNTIDAR
                                jalur = RdrJalur["jalur"].ToString();

                                if (jalur == "")
                                {
                                    RdrJalur.Close();
                                    RdrJalur.Dispose();
                                    CmdJalur.Dispose();
                                    con.Close();
                                    con.Dispose();

                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Jalur Masuk Tidak Ditemukan');", true);
                                    return;
                                }
                            }
                        }
                    }

                    //----- UPLOAD BUKTI JALUR SNMPTN -------------//
                    if (jalur == "SNMPTN")
                    {
                        //--------------- Filter Ukuran Foto --------------------
                        if (!FileUpload1.HasFile)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Berkas Masih Kosong');", true);
                            return;
                        }

                        if (FileUpload1.PostedFile.ContentLength < 307200 || FileUpload1.PostedFile.ContentLength >= 512000)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                            return;
                        }

                        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        string ext = Path.GetExtension(FileName);
                        string contenttype = String.Empty;

                        //Set the contenttype based on File Extension
                        switch (ext)
                        {
                            case ".jpg":
                                contenttype = "image/jpg";
                                break;
                            case ".jpeg":
                                contenttype = "image/jpeg";
                                break;
                            case ".png":
                                contenttype = "image/png";
                                break;
                            case ".JPEG":
                                contenttype = "image/jpeg";
                                break;
                            case ".PNG":
                                contenttype = "image/jpeg";
                                break;
                            case ".JPG":
                                contenttype = "image/jpeg";
                                break;
                        }

                        if (contenttype != String.Empty)
                        {
                            //insert the file into database
                            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                            {
                                connection.Open();
                                SqlTransaction trans = connection.BeginTransaction();

                                try
                                {
                                    //A. ------------------ CEK UPLOAD --------------------
                                    SqlCommand cmdIsupload = new SqlCommand("SELECT pth_bukti FROM dbo.SnmptnTemp  WHERE nomor_pendaftaran=@no_daftar", connection);
                                    cmdIsupload.Transaction = trans;
                                    cmdIsupload.CommandType = System.Data.CommandType.Text;
                                    cmdIsupload.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                    using (SqlDataReader RdrUpload = cmdIsupload.ExecuteReader())
                                    {
                                        if (RdrUpload.HasRows)
                                        {
                                            while (RdrUpload.Read())
                                            {
                                                if (RdrUpload["pth_bukti"] != DBNull.Value)
                                                {
                                                    RdrUpload.Close();
                                                    RdrUpload.Dispose();
                                                    cmdIsupload.Dispose();
                                                    trans.Rollback();
                                                    trans.Dispose();
                                                    con.Close();
                                                    con.Dispose();

                                                    this.LbSuccess.Text = "";

                                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Sudah Diupload');", true);
                                                    return;
                                                }
                                            }

                                        }
                                    }

                                    //B. -------------- UPDATE PATH ---------------
                                    SqlCommand cmd = new SqlCommand("UPDATE dbo.SnmptnTemp SET pth_bukti=@path WHERE nomor_pendaftaran=@no_daftar", connection);
                                    cmd.Transaction = trans;
                                    cmd.CommandType = System.Data.CommandType.Text;

                                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                    cmd.Parameters.AddWithValue("@path", this.Session["NoDaftar"].ToString() + "_" + FileName);
                                    cmd.ExecuteNonQuery();

                                    //C. --------------- SET DATA PEMBAYARAN ----------------
                                    SqlCommand cmdUpBPD = new SqlCommand("UPDATE dbo.SnmptnTemp SET bpd='no', snd='no' WHERE nomor_pendaftaran=@no_daftar", connection);
                                    cmdUpBPD.Transaction = trans;
                                    cmdUpBPD.CommandType = System.Data.CommandType.Text;

                                    cmdUpBPD.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                    cmdUpBPD.ExecuteNonQuery();

                                    //D. --------------- UPDATE ALAMAT EMAIL ----------------
                                    SqlCommand cmdUpEmail = new SqlCommand("UPDATE dbo.SnmptnTemp SET email_aktif=@email WHERE nomor_pendaftaran=@no_daftar", connection);
                                    cmdUpEmail.Transaction = trans;
                                    cmdUpEmail.CommandType = System.Data.CommandType.Text;

                                    cmdUpEmail.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                    cmdUpEmail.Parameters.AddWithValue("@email", this.TbEmail.Text.Trim());
                                    cmdUpEmail.ExecuteNonQuery();

                                    trans.Commit();
                                    cmdIsupload.Dispose();

                                    //---------- Save files to disk -------------------
                                    FileUpload1.SaveAs(Server.MapPath("~/kwitansi_sn/" + this.Session["NoDaftar"].ToString() + "_" + FileName));

                                    this.LbSuccess.ForeColor = System.Drawing.Color.Green;
                                    this.LbSuccess.Text = "Upload berhasil, berkas Anda akan segera diproses oleh Administrator";
                                    // ------------------------------------------------------------------------
                                }
                                catch (Exception ex)
                                {
                                    this.LbSuccess.Text = "";
                                    this.Lberr.Text = ex.Message.ToString();
                                    trans.Rollback();
                                    connection.Close();
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                    return;
                                }


                            }
                        }
                        else // type file tidak diperbolehkan
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                            return;
                        }
                    }

                    this.Lberr.Text = "";
                }
                catch (Exception ex)
                {
                    this.LbSuccess.Text = "";
                    this.Lberr.Text = ex.Message.ToString();
                }
            }
        }
    }
}