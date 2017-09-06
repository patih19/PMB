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
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //smuntidar.WebForm5 = ValUp.aspx
                Page Lastpage = (Page)Context.Handler;
                if (Lastpage is smuntidar.WebForm5)
                {

                    this.LbNoTag.Text = ((smuntidar.WebForm5)Lastpage).NoTagihan;
                    this.LbEmail.Text = ((smuntidar.WebForm5)Lastpage).Email;

                    if (this.LbNoTag.Text == "" || this.LbEmail.Text == "")
                    {
                        Response.Redirect("~/ValUp.aspx");
                    }
                }
                else
                {
                    //jika link sebelumnya tidak dari ValUp
                    Response.Redirect("~/ValUp.aspx");
                }
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Berkas Masih Kosong');", true);
                return;
            }

            if (FileUpload1.PostedFile.ContentLength < 204800 || FileUpload1.PostedFile.ContentLength >= 409600)
            {
                this.LbGagal.Text = "Ukuran File Tidak Sesuai Dengan Ketentuan !!";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            // Read the file and convert it to Byte Array
            //string filePath = FileUpload1.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

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
                        SqlCommand cmdIsupload = new SqlCommand("SpIsUploaded", connection);
                        cmdIsupload.Transaction = trans;
                        cmdIsupload.CommandType = System.Data.CommandType.StoredProcedure;

                        cmdIsupload.Parameters.AddWithValue("@no_tagihan", this.LbNoTag.Text);
                        cmdIsupload.ExecuteNonQuery();


                        //B. -------------- Insert ---------------
                        SqlCommand cmd = new SqlCommand("SpInsertSlip", connection);
                        cmd.Transaction = trans;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.LbNoTag.Text);
                        cmd.Parameters.AddWithValue("@path", FileName);
                        cmd.ExecuteNonQuery();

                        //---------- Save files to disk -------------------
                        FileUpload1.SaveAs(Server.MapPath("~/slip/" + FileName));

                        trans.Commit();
                        cmdIsupload.Dispose();

                        this.LbSuccess.ForeColor = System.Drawing.Color.Green;
                        this.LbSuccess.Text = "Tunggu Beberapa Saat Admin Akan Memverifikasi Berkas Anda, Data Akan Dikirimkan Kurang Dari 24 Jam";
                        this.LbEmail.Text = "";
                        this.LbNoTag.Text = "";
                        // ------------------------------------------------------------------------
                    }
                    catch (Exception ex)
                    {
                        this.LbSuccess.Text = "";
                        this.LbGagal.Text = ex.ToString();
                        this.LbEmail.Text = "";
                        this.LbNoTag.Text = "";
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
    }
}