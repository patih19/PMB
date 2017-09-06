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

namespace smmuntidar.user
{
    //public partial class WebForm18 : System.Web.UI.Page
    public partial class WebForm18 : user_login
    {
        //------------- LogOut ------------------------------//
        protected override void OnInit(EventArgs e)
        {
            // Your code
            base.OnInit(e);
            keluar.ServerClick += new EventHandler(logout_ServerClick);
        }

        protected void logout_ServerClick(object sender, EventArgs e)
        {
            //Your Code here....
            this.Session["Name"] = null;
            this.Session["Passwd"] = null;
            this.Session.Remove("Name");
            this.Session.Remove("Passwd");
            this.Session.Remove("no_tagihan");
            this.Session.RemoveAll();

            this.Response.Redirect("~/Pendaftaran.aspx", false);
        }
        //---------------- End logout ------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LbTrans.Text = this.Session["Name"].ToString();

                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_foto where smmuntidar_foto.no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["proses_komplet"].ToString() == "ok")
                                {
                                    Response.Redirect("~/user/home.aspx", false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    ReadFoto();
                                }
                            }
                        }
                        else
                        {

                            this.PanelSelesai.Enabled = false;
                            this.PanelSelesai.Visible = false;

                            this.PanelUpload.Enabled = true;
                            this.PanelUpload.Visible = true;

                            // data no tagihan tidak ditemukan, sepertinya tidak mungkin kaarena user sudah bisa login
                        }
                    }
                }
                //---------------------------------- End Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
            }
        }

        protected void ReadFoto()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, path_foto from smmuntidar_foto where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ImageFoto.ImageUrl = "~/foto/" + reader["path_foto"].ToString();

                            if (reader["path_foto"] == DBNull.Value)
                            {
                                this.PanelSelesai.Enabled = false;
                                this.PanelSelesai.Visible = false;
                                this.PanelUpload.Enabled = true;
                                this.PanelUpload.Visible = true;
                            }
                            else
                            {
                                this.PanelSelesai.Enabled = true;
                                this.PanelSelesai.Visible = true;
                                this.PanelUpload.Enabled = false;
                                this.PanelUpload.Visible = false;
                            }
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
                    ImageFoto.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            //--------------- Filter Ukuran Foto --------------------
            if (!FileUploadFoto.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUploadFoto.PostedFile.ContentLength >= 153600 || FileUploadFoto.PostedFile.ContentLength < 50800)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Ukuran File 50 - 150 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            if (FileUploadFoto.FileName.Length > 25)
            {

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Tidak Boleh Lebih Dari 25 Karakter');", true);
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
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".jpeg":
                    contenttype = "image/jpeg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".JPG":
                    contenttype = "image/png";
                    break;
                case ".JPEG":
                    contenttype = "image/png";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
            }

            if (contenttype != String.Empty)
            {
                //Stream fs = FileUploadFoto.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //int length = bytes.Length;

                // ------- delete old image  ------------
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, path_foto from smmuntidar_foto where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //Byte[] bytes = (Byte[])reader["raport"];
                                //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                //string old = "~/" + rdr["pth_bns1"].ToString();
                                System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["path_foto"].ToString()));
                            }
                        }
                        else
                        {
                            //Console.WriteLine("No Image found.");
                        }
                        rdr.Close();

                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }


                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpInsertFoto2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@path", this.Session["no_tagihan"].ToString() + "-" + filename);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUploadFoto.SaveAs(Server.MapPath("~/foto/" + this.Session["no_tagihan"].ToString() + "-" + filename));

                        //this.Button1.Enabled = false;
                    }
                    catch (Exception ex)
                    {

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }

                // Read Foto
                ReadFoto();


                //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                //{
                //    try
                //    {
                //        connection.Open();
                //        SqlCommand cmd = new SqlCommand("SpInsertFoto", connection);
                //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                //        cmd.Parameters.AddWithValue("@foto", bytes);
                //        cmd.ExecuteNonQuery();

                //        //------------- InsertUpdateData(cmd) -----------;
                //        cmd.Dispose();
                //        lblMessage.ForeColor = System.Drawing.Color.Green;
                //        lblMessage.Text = "File Uploaded Successfully";

                //        ////========================== READER IMAGE FROM DB =========================
                //        //SqlCommand CmdDisplay = new SqlCommand("select image from tes_upload where id=7;", connection);
                //        //SqlDataReader reader = CmdDisplay.ExecuteReader();
                //        //if (reader.HasRows)
                //        //{
                //        //    while (reader.Read())
                //        //    {
                //        //        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                //        //        Image1.ImageUrl = "data:image/png;base64," + base64String;
                //        //    }
                //        //}
                //        //else
                //        //{
                //        //    Console.WriteLine("No Image found.");
                //        //}
                //        //reader.Close();
                //        ////======================== END READER =========================

                //        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                //        ImageFoto.ImageUrl = "data:image/png;base64," + base64String;
                //        BtnUpload.Enabled = true;
                //    }
                //    catch (Exception ex)
                //    {

                //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                //        return;
                //    }
                //}

            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user/home.aspx");
        }
    }
}