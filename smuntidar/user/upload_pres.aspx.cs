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
    //public partial class WebForm12 : System.Web.UI.Page
    public partial class WebForm12 : user_login
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

                // -- =================================  Keterangan Upload  =========================================== --
                //-----------------------------------Keterangan Upload Bonus 1 -----------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select no_tagihan,bonus_1 from smuntidar_nilai where no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["bonus_1"].ToString() != "")
                                {
                                    this.Label1.Text = "File Uploaded";
                                    Label1.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                        }
                    }

                    //-----------------------------------Keterangan Upload Bonus 2 -----------------------------------------------
                    SqlCommand CmdPeriodik2 = new SqlCommand("select no_tagihan,bonus_2 from smuntidar_nilai where no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik2.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik2.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik2.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["bonus_2"].ToString() != "")
                                {
                                    this.Label2.Text = "File Uploaded";
                                    Label2.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                        }
                    }

                    //-----------------------------------Keterangan Upload Bonus 3 -----------------------------------------------
                    SqlCommand CmdPeriodik3 = new SqlCommand("select no_tagihan,bonus_3 from smuntidar_nilai where no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik3.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik3.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik3.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["bonus_3"].ToString() != "")
                                {
                                    this.Label3.Text = "File Uploaded";
                                    Label3.ForeColor = System.Drawing.Color.Green;
                                }
                            }
                        }
                    }
                }
                // -- ======================  End Keterangan Upload ====================================== --
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload1.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload1.PostedFile.ContentLength < 102400 || FileUpload1.PostedFile.ContentLength >= 204800)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "File Melebihi 200 Kb";

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
            }

            if (contenttype != String.Empty)
            {
                // ------- delete old image  ------------
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, pth_bns1 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
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
                                System.IO.File.Delete(Server.MapPath("~/prestasi/" + rdr["pth_bns1"].ToString()));
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
                        SqlCommand cmd = new SqlCommand("SpInsertPrestasiKab1", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@path", this.Session["no_tagihan"].ToString() + "-KOTA-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label1.ForeColor = System.Drawing.Color.Green;
                        Label1.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload1.SaveAs(Server.MapPath("~/prestasi/" + this.Session["no_tagihan"].ToString() + "-KOTA-" + FileName));

                        //this.Button1.Enabled = false;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (!FileUpload2.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload2.PostedFile.ContentLength < 102400 || FileUpload2.PostedFile.ContentLength >= 204800)
            {
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = "File Melebihi 200 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
            //string filePath = FileUpload2.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

            string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
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
                // ------- delete old image  ------------
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, pth_bns2 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
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
                                System.IO.File.Delete(Server.MapPath("~/prestasi/" + rdr["pth_bns2"].ToString()));
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
                        SqlCommand cmd = new SqlCommand("SpInsertPrestasiProv1", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@path",this.Session["no_tagihan"].ToString() + "-PROV-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label2.ForeColor = System.Drawing.Color.Green;
                        Label2.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload2.SaveAs(Server.MapPath("~/prestasi/" + this.Session["no_tagihan"].ToString() + "-PROV-" + FileName));

                        //this.Button2.Enabled = false;
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
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!FileUpload3.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Foto Sebelum Upload');", true);
                return;
            }

            if (FileUpload3.PostedFile.ContentLength < 102400 || FileUpload3.PostedFile.ContentLength >= 204800)
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "File Melebihi 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            //// Read the file and convert it to Byte Array
            //string filePath = FileUpload2.PostedFile.FileName;
            //string filename = Path.GetFileName(filePath);
            //string ext = Path.GetExtension(filename);
            //string contenttype = String.Empty;

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
                // ------- delete old image  ------------
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, pth_bns3 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
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
                                System.IO.File.Delete(Server.MapPath("~/prestasi/" + rdr["pth_bns3"].ToString()));
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
                        SqlCommand cmd = new SqlCommand("SpInsertPrestasiNas1", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmd.Parameters.AddWithValue("@path",this.Session["no_tagihan"].ToString() + "-NAS-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        Label3.ForeColor = System.Drawing.Color.Green;
                        Label3.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUpload3.SaveAs(Server.MapPath("~/prestasi/" + this.Session["no_tagihan"].ToString() + "-NAS-" + FileName));

                        //this.Button3.Enabled = false;
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
            }
        }

        protected void BtnLihat1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan,pth_bns1 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); 
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["img_bonus_1"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                            Image1.ImageUrl = "~/prestasi/" + reader["pth_bns1"].ToString();
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
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
        }

        protected void BtnLihat2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan,pth_bns2 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["img_bonus_2"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                            Image1.ImageUrl = "~/prestasi/" + reader["pth_bns2"].ToString();
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
                }
            }
        }

        protected void Btnlihat3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan,pth_bns3 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Byte[] bytes = (Byte[])reader["img_bonus_3"];
                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

                            Image1.ImageUrl = "~/prestasi/" + reader["pth_bns3"].ToString();
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
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
        }
    }
}