using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PinSemuntidar.user
{
    //public partial class WebForm8 : System.Web.UI.Page
    public partial class WebForm8 : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (!FileUploadFoto.HasFile)
            {
                return;
            }

            // Read the file and convert it to Byte Array
            string filePath = FileUploadFoto.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".doc":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".docx":
                    contenttype = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contenttype = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;

            }

            if (contenttype != String.Empty)
            {
                Stream fs = FileUploadFoto.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                if (Page.IsValid)
                {
                    //insert the file into database
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                    {
                        try
                        {
                            BtnUpload.Enabled = false;
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("insert into tes_upload(nama, type, image) values (@nama, @type, @image)", connection);
                            cmd.Parameters.Add("@nama", SqlDbType.VarChar).Value = filename;
                            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = contenttype;
                            cmd.Parameters.Add("@image", SqlDbType.Binary).Value = bytes;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            //InsertUpdateData(cmd);
                            cmd.Dispose();
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "File Uploaded Successfully";
                            //PanelFoto.Visible = true;
                            ////========================== READER =========================
                            //SqlCommand CmdDisplay = new SqlCommand("select image from tes_upload where id=7;", connection);
                            //SqlDataReader reader = CmdDisplay.ExecuteReader();
                            //if (reader.HasRows)
                            //{
                            //    while (reader.Read())
                            //    {
                            //        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //        Image1.ImageUrl = "data:image/png;base64," + base64String;
                            //    }
                            //}
                            //else
                            //{
                            //    Console.WriteLine("No rows found.");
                            //}
                            //reader.Close();
                            ////======================== END READER =========================

                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            ImageFoto.ImageUrl = "data:image/png;base64," + base64String;
                            BtnUpload.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            BtnUpload.Enabled = true;
                            Response.Write(ex.Message);
                        }
                    }
                }
                else // File Melebihi 100KB
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "File Melebihi 100 KB";
                }
            }
            else // type file tidak dikenal
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File format not recognised." +
                  " Upload Image/Word/PDF/Excel formats";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user/home.aspx");
        }
    }
}