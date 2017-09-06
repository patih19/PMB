using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace smmuntidar
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //smuntidar.WebForm5 = ValUp.aspx
                Page Lastpage = (Page)Context.Handler;
                if (Lastpage is smmuntidar.WebForm5)
                {
                    //string folder = "slip/";
                    //Response.Write(Server.MapPath("/kwt/"));

                    this.LbNoTag.Text = ((smmuntidar.WebForm5)Lastpage).NoTagihan;
                    this.LbEmail.Text = ((smmuntidar.WebForm5)Lastpage).Email;

                    if (this.LbNoTag.Text == "" || this.LbEmail.Text == "")
                    {
                        Response.Redirect("~/ValUpload.aspx");
                    }
                }
                else
                {
                    //jika link sebelumnya tidak dari ValUp
                    Response.Redirect("~/ValUpload.aspx");
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

            if (FileUpload1.PostedFile.ContentLength < 307200 || FileUpload1.PostedFile.ContentLength >= 512000)
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
                case ".bmp":
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
                case ".BMP":
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

                        cmdIsupload.Parameters.AddWithValue("@no_tagihan", this.LbNoTag.Text.Trim());
                        cmdIsupload.ExecuteNonQuery();

                        //B. -------------- Insert ---------------
                        SqlCommand cmd = new SqlCommand("SpInsertSlip", connection);
                        cmd.Transaction = trans;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.LbNoTag.Text.Trim());
                        cmd.Parameters.AddWithValue("@path", this.LbNoTag.Text.Trim() +"-"+ FileName);
                        cmd.ExecuteNonQuery();

                        trans.Commit();
                        cmdIsupload.Dispose();

                        //---------- Save files to disk -------------------
                        FileUpload1.SaveAs(Server.MapPath("/kwt/" + this.LbNoTag.Text.Trim() + "-" + FileName));

                        this.LbSuccess.ForeColor = System.Drawing.Color.Green;
                        this.LbSuccess.Text = "Upload berhasil, berkas Anda akan segera diproses oleh Administrator, PIN Pendaftaran akan dikirim dalam waktu kurang dari 2 X 24 Jam, periksa kembali email Anda";
                        this.LbEmail.Text = "";
                        this.LbNoTag.Text = "";
                        this.LbGagal.Text = "";
                        // ------------------------------------------------------------------------
                    }
                    catch (Exception ex)
                    {
                        this.LbSuccess.Text = "";
                        this.LbGagal.Text = ex.Message.ToString();
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