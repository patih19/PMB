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


namespace smuntidar.user
{
    //public partial class WebForm11 : System.Web.UI.Page
      public partial class WebForm11 : user_login
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

                //-----------------------------------Keterangan Upload -----------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select no_tagihan,path,semester from smuntidar_raport where no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if ((rdr["path"].ToString() != "") && (rdr["semester"].ToString() == "1"))
                                {
                                    this.Label1.Text = "uploaded";
                                    Label1.ForeColor = System.Drawing.Color.Green;
                                }
                                else if ((rdr["path"].ToString() != "") && (rdr["semester"].ToString() == "2"))
                                {
                                    this.Label2.Text = "uploaded";
                                    Label2.ForeColor = System.Drawing.Color.Green;
                                }
                                else if ((rdr["path"].ToString() != "") && (rdr["semester"].ToString() == "3"))
                                {
                                    this.Label3.Text = "uploaded";
                                    Label3.ForeColor = System.Drawing.Color.Green;
                                }
                                else if ((rdr["path"].ToString() != "") && (rdr["semester"].ToString() == "4"))
                                {
                                    this.Label4.Text = "uploaded";
                                    Label4.ForeColor = System.Drawing.Color.Green;
                                }
                                else if ((rdr["path"].ToString() != "") && (rdr["semester"].ToString() == "5"))
                                {
                                    this.Label5.Text = "uploaded";
                                    Label5.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                        }
                        else
                        {
                            
                        }
                    }
                }
                // --------------------------- End Keterangan Upload --------------------------------------
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //--------------- Filter Ukuran Foto --------------------
        //    if (!FileUpload1.HasFile)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
        //        return;
        //    }

        //    if (FileUpload1.PostedFile.ContentLength >= 204800 || FileUpload1.PostedFile.ContentLength < 102400)
        //    {
        //        Label1.ForeColor = System.Drawing.Color.Red;
        //        Label1.Text = "Ukuran File 100 KB - 200 KB";

        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
        //        return;
        //    }

        //    // Read the file and convert it to Byte Array
        //    string filePath = FileUpload1.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    //Set the contenttype based on File Extension
        //    switch (ext)
        //    {
        //        case ".jpg":
        //            contenttype = "image/jpg";
        //            break;
        //        case ".jpeg":
        //            contenttype = "image/jpeg";
        //            break;
        //        case ".png":
        //            contenttype = "image/png";
        //            break;
        //        case ".JPEG":
        //            contenttype = "image/jpeg";
        //            break;
        //    }

        //    if (contenttype != String.Empty)
        //    {
        //        Stream fs = FileUpload1.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        int length = bytes.Length;

        //        //insert the file into database
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport", connection);
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
        //                cmd.Parameters.AddWithValue("@semester","1");
        //                cmd.Parameters.AddWithValue("@foto", bytes);
        //                cmd.ExecuteNonQuery();

        //                //------------- InsertUpdateData(cmd) -----------;
        //                cmd.Dispose();
        //                Label1.ForeColor = System.Drawing.Color.Green;
        //                Label1.Text = "File Uploaded Successfully";

        //               // this.Button1.Enabled = false;
        //            }
        //            catch (Exception ex)
        //            {
        //                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //            }
        //        }
        //    }
        //    else // type file tidak diperbolehkan
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
        //        return;
        //    }
        //}
        protected void BtnDisk1_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload1.PostedFile.ContentLength >= 204800 || FileUpload1.PostedFile.ContentLength < 102400)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
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
            }

            if (contenttype != String.Empty)
            {
                // ------- delete old image from server  ------------
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                        CmdDisplay.Parameters.AddWithValue("@semester", "1");
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //Byte[] bytes = (Byte[])reader["raport"];
                                //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                string old = "~/" + rdr["path"].ToString();
                                System.IO.File.Delete(Server.MapPath("~/raport/" + rdr["path"].ToString()));
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
                        SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //--------------- save path to DB --------------------------
                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@semester", "1");
                        cmd.Parameters.AddWithValue("@path", this.Session["no_tagihan"].ToString() +"-1-"+ FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload1.SaveAs(Server.MapPath("~/raport/" + this.Session["no_tagihan"].ToString() + "-1-" + FileName));

                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                return;
            }
        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    //--------------- Filter Ukuran Foto --------------------
        //    if (!FileUpload20.HasFile)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
        //        return;
        //    }

        //    if (FileUpload20.PostedFile.ContentLength >= 204800 || FileUpload20.PostedFile.ContentLength < 102400)
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //        Label2.Text = "Ukuran File 100 KB - 200 KB";

        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
        //        return;
        //    }

        //    // Read the file and convert it to Byte Array
        //    string filePath = FileUpload20.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    //Set the contenttype based on File Extension
        //    switch (ext)
        //    {
        //        case ".jpg":
        //            contenttype = "image/jpg";
        //            break;
        //        case ".jpeg":
        //            contenttype = "image/jpeg";
        //            break;
        //        case ".png":
        //            contenttype = "image/png";
        //            break;
        //        case ".JPEG":
        //            contenttype = "image/jpeg";
        //            break;
        //    }

        //    if (contenttype != String.Empty)
        //    {
        //        Stream fs = FileUpload20.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        int length = bytes.Length;

        //        //insert the file into database
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport", connection);
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
        //                cmd.Parameters.AddWithValue("@semester", "2");
        //                cmd.Parameters.AddWithValue("@foto", bytes);
        //                cmd.ExecuteNonQuery();

        //                //------------- InsertUpdateData(cmd) -----------;
        //                cmd.Dispose();
        //                Label2.ForeColor = System.Drawing.Color.Green;
        //                Label2.Text = "File Uploaded Successfully";

        //                this.Button2.Enabled = false;
        //            }
        //            catch (Exception ex)
        //            {

        //                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //                return;
        //            }
        //        }
        //    }
        //    else // type file tidak diperbolehkan
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
        //        return;
        //    }
        //}
        protected void BtnDisk2_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload20.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload20.PostedFile.ContentLength >= 204800 || FileUpload20.PostedFile.ContentLength < 102400)
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
            //string filePath = FileUpload1.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            string FileName = Path.GetFileName(FileUpload20.PostedFile.FileName);
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
            }

            if (contenttype != String.Empty)
            {
                //Stream fs = FileUpload1.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //int length = bytes.Length;

                // ------- delete old image  ------------
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                        CmdDisplay.Parameters.AddWithValue("@semester", "2");
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //Byte[] bytes = (Byte[])reader["raport"];
                                //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                string old = "~/" + rdr["path"].ToString();
                                System.IO.File.Delete(Server.MapPath("~/raport/" + rdr["path"].ToString()));
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
                        SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@semester", "2");
                        cmd.Parameters.AddWithValue("@path", this.Session["no_tagihan"].ToString() + "-2-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label2.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload20.SaveAs(Server.MapPath("~/raport/" + this.Session["no_tagihan"].ToString() + "-2-" + FileName));

                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                return;
            }
        }

        //protected void Button3_Click(object sender, EventArgs e)
        //{
        //    //--------------- Filter Ukuran Foto --------------------
        //    if (!FileUpload3.HasFile)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
        //        return;
        //    }

        //    if (FileUpload3.PostedFile.ContentLength >= 204800 || FileUpload3.PostedFile.ContentLength < 102400)
        //    {
        //        Label3.ForeColor = System.Drawing.Color.Red;
        //        Label3.Text = "Ukuran File 100 KB - 200 KB";

        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
        //        return;
        //    }

        //    // Read the file and convert it to Byte Array
        //    string filePath = FileUpload3.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    //Set the contenttype based on File Extension
        //    switch (ext)
        //    {
        //        case ".jpg":
        //            contenttype = "image/jpg";
        //            break;
        //        case ".jpeg":
        //            contenttype = "image/jpeg";
        //            break;
        //        case ".png":
        //            contenttype = "image/png";
        //            break;
        //        case ".JPEG":
        //            contenttype = "image/jpeg";
        //            break;
        //    }

        //    if (contenttype != String.Empty)
        //    {
        //        Stream fs = FileUpload3.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        int length = bytes.Length;

        //        //insert the file into database
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport", connection);
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
        //                cmd.Parameters.AddWithValue("@semester", "3");
        //                cmd.Parameters.AddWithValue("@foto", bytes);
        //                cmd.ExecuteNonQuery();

        //                //------------- InsertUpdateData(cmd) -----------;
        //                cmd.Dispose();
        //                Label3.ForeColor = System.Drawing.Color.Green;
        //                Label3.Text = "File Uploaded Successfully";

        //                this.Button3.Enabled = false;
        //            }
        //            catch (Exception ex)
        //            {

        //                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //                return;
        //            }
        //        }
        //    }
        //    else // type file tidak diperbolehkan
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
        //        return;
        //    }
        //}
        protected void BtnDisk3_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload3.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload3.PostedFile.ContentLength >= 204800 || FileUpload3.PostedFile.ContentLength < 102400)
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
            //string filePath = FileUpload1.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            // ------- delete old image  ------------
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", "3");
                    SqlDataReader rdr = CmdDisplay.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["raport"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                            string old = "~/" + rdr["path"].ToString();
                            System.IO.File.Delete(Server.MapPath("~/raport/" + rdr["path"].ToString()));
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

            string FileName = Path.GetFileName(FileUpload3.PostedFile.FileName);
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
            }

            if (contenttype != String.Empty)
            {
                //Stream fs = FileUpload1.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //int length = bytes.Length;

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@semester", "3");
                        cmd.Parameters.AddWithValue("@path",this.Session["no_tagihan"].ToString() + "-3-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label3.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload3.SaveAs(Server.MapPath("~/raport/" + this.Session["no_tagihan"].ToString() + "-3-" + FileName));

                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                return;
            }
        }

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    //--------------- Filter Ukuran Foto --------------------
        //    if (!FileUpload4.HasFile)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
        //        return;
        //    }

        //    if (FileUpload4.PostedFile.ContentLength >= 204800 || FileUpload4.PostedFile.ContentLength < 102400)
        //    {
        //        Label4.ForeColor = System.Drawing.Color.Red;
        //        Label4.Text = "Ukuran File 100 KB - 200 KB";

        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
        //        return;
        //    }

        //    // Read the file and convert it to Byte Array
        //    string filePath = FileUpload4.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    //Set the contenttype based on File Extension
        //    switch (ext)
        //    {
        //        case ".jpg":
        //            contenttype = "image/jpg";
        //            break;
        //        case ".jpeg":
        //            contenttype = "image/jpeg";
        //            break;
        //        case ".png":
        //            contenttype = "image/png";
        //            break;
        //        case ".JPEG":
        //            contenttype = "image/jpeg";
        //            break;
        //    }

        //    if (contenttype != String.Empty)
        //    {
        //        Stream fs = FileUpload4.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        int length = bytes.Length;

        //        //insert the file into database
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport", connection);
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
        //                cmd.Parameters.AddWithValue("@semester", "4");
        //                cmd.Parameters.AddWithValue("@foto", bytes);
        //                cmd.ExecuteNonQuery();

        //                //------------- InsertUpdateData(cmd) -----------;
        //                cmd.Dispose();
        //                Label4.ForeColor = System.Drawing.Color.Green;
        //                Label4.Text = "File Uploaded Successfully";

        //                this.Button4.Enabled = false;
        //            }
        //            catch (Exception ex)
        //            {

        //                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //                return;
        //            }
        //        }
        //    }
        //    else // type file tidak diperbolehkan
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
        //        return;
        //    }
        //}
        protected void BtnDisk4_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload4.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload4.PostedFile.ContentLength >= 204800 || FileUpload4.PostedFile.ContentLength < 102400)
            {
                Label4.ForeColor = System.Drawing.Color.Red;
                Label4.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
            //string filePath = FileUpload1.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            // ------- delete old image  ------------
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", "4");
                    SqlDataReader rdr = CmdDisplay.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["raport"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                            string old = "~/" + rdr["path"].ToString();
                            System.IO.File.Delete(Server.MapPath("~/raport/" + rdr["path"].ToString()));
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

            string FileName = Path.GetFileName(FileUpload4.PostedFile.FileName);
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
            }

            if (contenttype != String.Empty)
            {
                //Stream fs = FileUpload1.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //int length = bytes.Length;

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@semester", "4");
                        cmd.Parameters.AddWithValue("@path", this.Session["no_tagihan"].ToString() + "-4-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label4.ForeColor = System.Drawing.Color.Green;
                        Label4.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload4.SaveAs(Server.MapPath("~/raport/" + this.Session["no_tagihan"].ToString() + "-4-" + FileName));

                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                return;
            }
        }

        //protected void Button5_Click(object sender, EventArgs e)
        //{
        //    //--------------- Filter Ukuran Foto --------------------
        //    if (!FileUpload5.HasFile)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
        //        return;
        //    }

        //    if ( FileUpload5.PostedFile.ContentLength >= 204800 || FileUpload5.PostedFile.ContentLength < 102400)
        //    {
        //        Label5.ForeColor = System.Drawing.Color.Red;
        //        Label5.Text = "Ukuran File 100 KB - 200 KB";

        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
        //        return;
        //    }

        //    // Read the file and convert it to Byte Array
        //    string filePath = FileUpload5.PostedFile.FileName;
        //    string filename = Path.GetFileName(filePath);
        //    string ext = Path.GetExtension(filename);
        //    string contenttype = String.Empty;

        //    //Set the contenttype based on File Extension
        //    switch (ext)
        //    {
        //        case ".jpg":
        //            contenttype = "image/jpg";
        //            break;
        //        case ".jpeg":
        //            contenttype = "image/jpeg";
        //            break;
        //        case ".png":
        //            contenttype = "image/png";
        //            break;
        //        case ".JPEG":
        //            contenttype = "image/jpeg";
        //            break;
        //    }

        //    if (contenttype != String.Empty)
        //    {
        //        Stream fs = FileUpload5.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        int length = bytes.Length;

        //        //insert the file into database
        //        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport", connection);
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
        //                cmd.Parameters.AddWithValue("@semester", "5");
        //                cmd.Parameters.AddWithValue("@foto", bytes);
        //                cmd.ExecuteNonQuery();

        //                //------------- InsertUpdateData(cmd) -----------;
        //                cmd.Dispose();
        //                Label5.ForeColor = System.Drawing.Color.Green;
        //                Label5.Text = "File Uploaded Successfully";

        //                this.Button5.Enabled = false;
        //            }
        //            catch (Exception ex)
        //            {

        //                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //                return;
        //            }
        //        }
        //    }
        //    else // type file tidak diperbolehkan
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File tidak diperbolehkan');", true);
        //        return;
        //    }
        //}
        protected void BtnDisk5_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload5.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload5.PostedFile.ContentLength >= 204800 || FileUpload5.PostedFile.ContentLength < 102400)
            {
                Label5.ForeColor = System.Drawing.Color.Red;
                Label5.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
            //string filePath = FileUpload1.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            // ------- delete old image  ------------
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", "5");
                    SqlDataReader rdr = CmdDisplay.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["raport"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                            string old = "~/" + rdr["path"].ToString();
                            System.IO.File.Delete(Server.MapPath("~/raport/" + rdr["path"].ToString()));
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

            string FileName = Path.GetFileName(FileUpload5.PostedFile.FileName);
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
            }

            if (contenttype != String.Empty)
            {
                //Stream fs = FileUpload1.PostedFile.InputStream;
                //BinaryReader br = new BinaryReader(fs);
                //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //int length = bytes.Length;

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpUpdateFotoRaport2", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@semester", "5");
                        cmd.Parameters.AddWithValue("@path", this.Session["no_tagihan"].ToString() + "-5-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label5.ForeColor = System.Drawing.Color.Green;
                        Label5.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload5.SaveAs(Server.MapPath("~/raport/" + this.Session["no_tagihan"].ToString() + "-5-" + FileName));

                    }
                    catch (Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
                return;
            }
        }

        // Function to View Foto Raport From DATABASE
        protected void LihatFoto(string no_tagihan, string semester)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no, raport from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan",no_tagihan); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", semester );
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Byte[] bytes = (Byte[]) reader["raport"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            Image1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void LihatFoto2(string no_tagihan, string semester)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", no_tagihan); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", semester);
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["raport"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                           Image1.ImageUrl = "~/raport/" + reader["path"].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void BtnLihat1_Click(object sender, EventArgs e)
        {
            LihatFoto(this.Session["no_tagihan"].ToString(), "1");
            LblSemester.Text = " Raport Semester 1 (Satu)";
        }

        protected void BtnLihat2_Click(object sender, EventArgs e)
        {
            LihatFoto(this.Session["no_tagihan"].ToString(), "2");
            LblSemester.Text = " Raport Semester 2 (Dua)";
        }

        protected void Btnlihat3_Click(object sender, EventArgs e)
        {
            LihatFoto(this.Session["no_tagihan"].ToString(), "3");
            LblSemester.Text = " Raport Semester 3 (Tiga)";
        }

        protected void Btnlihat4_Click(object sender, EventArgs e)
        {
            LihatFoto(this.Session["no_tagihan"].ToString(), "4");
            LblSemester.Text = " Raport Semester 4 (Empat)";
        }

        protected void BtnLihat5_Click(object sender, EventArgs e)
        {
            LihatFoto(this.Session["no_tagihan"].ToString(), "5");
            LblSemester.Text = " Raport Semester 5 (Lima)";
        }

        protected void BtnDskLihat1_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.Session["no_tagihan"].ToString(), "1");
            LblSemester.Text = "Raport Semester 1 (Satu)";
        }

        protected void BtnDskLihat2_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.Session["no_tagihan"].ToString(), "2");
            LblSemester.Text = "Raport Semester 2 (Dua)";
        }

        protected void BtnDskLihat3_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.Session["no_tagihan"].ToString(), "3");
            LblSemester.Text = "Raport Semester 3 (Tiga)";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.Session["no_tagihan"].ToString(), "4");
            LblSemester.Text = "Raport Semester 4 (Empat)";
        }

        protected void BtnDskLihat5_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.Session["no_tagihan"].ToString(), "5");
            LblSemester.Text = "Raport Semester 5 (Lima)";
        }

       





       



    }
}