using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace SuveriBidikmisi
{
    public partial class dokumen : SuveriBidikmisi.user.user
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                HtmlGenericControl control = (HtmlGenericControl)base.Master.FindControl("NavExample");
                control.Attributes.Add("class", "dropdown active opened");
                HtmlGenericControl control2 = (HtmlGenericControl)base.Master.FindControl("SubNavExample");
                control2.Attributes.Add("style", "display: block;");
                if (this.Session["NoDaftar"] == null)
                {
                    base.Response.Redirect("~/");
                }
                else
                {
                    //this.GetDataAset(this.Session["NoDaftar"].ToString());
                    //LoadDataSurveiAset();

                    ViewFoto();
                }
            }
        }

        protected void ViewFoto()
        {
            FotoRumahDepan(this.Session["NoDaftar"].ToString());
            FotoRuangTamu(this.Session["NoDaftar"].ToString());
            FotoRuangTengah(this.Session["NoDaftar"].ToString());
            FotoKamarTidur(this.Session["NoDaftar"].ToString());
            FotoDapur(this.Session["NoDaftar"].ToString());
            FotoKamarMandi(this.Session["NoDaftar"].ToString());
            //FotoGaji(this.Session["NoDaftar"].ToString());
        }

        protected void FotoRumahDepan(string no_daftar)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dpn_rumah from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_dpn_rumah"] == DBNull.Value)
                            {
                                this.PanelFotoRumah.Visible = false;
                                this.PanelFotoRumah.Enabled = false;
                            }
                            else
                            {
                                this.PanelFotoRumah.Visible = true;
                                this.PanelFotoRumah.Enabled = true;

                                this.ImgRumah.ImageUrl = "~/foto/" + reader["ft_dpn_rumah"].ToString();
                            }
                        }
                    }
                    else
                    {
                        this.PanelFotoRumah.Visible = false;
                        this.PanelFotoRumah.Enabled = false;

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgRumah.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoRuangTamu(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar,ft_ruang_tamu from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_ruang_tamu"] == DBNull.Value)
                            {
                                this.PanelRuangTamu.Visible = false;
                                this.PanelRuangTamu.Enabled = false;
                            }
                            else
                            {
                                this.PanelRuangTamu.Visible = true;
                                this.PanelRuangTamu.Enabled = true;

                                this.ImgRuangTamu.ImageUrl = "~/foto/" + reader["ft_ruang_tamu"].ToString();
                            }
                        }
                    }
                    else
                    {
                        this.PanelRuangTamu.Visible = false;
                        this.PanelRuangTamu.Enabled = false;

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgRuangTamu.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoRuangTengah(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_ruang_tengah from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_ruang_tengah"] == DBNull.Value)
                            {
                                this.PanelRuangTengah.Visible = false;
                                this.PanelRuangTengah.Enabled = false;
                            }
                            else
                            {
                                this.PanelRuangTengah.Visible = true;
                                this.PanelRuangTengah.Enabled = true;

                                this.ImgRuangTengah.ImageUrl = "~/foto/" + reader["ft_ruang_tengah"].ToString();
                            }
                        }
                    }
                    else
                    {
                        this.PanelRuangTengah.Visible = false;
                        this.PanelRuangTengah.Enabled = false;

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgRuangTengah.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoKamarTidur(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_kamar_tidur from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_kamar_tidur"] == DBNull.Value)
                            {
                                this.PanelKamarTidur.Visible = false;
                                this.PanelKamarTidur.Enabled = false;
                            }
                            else
                            {
                                this.PanelKamarTidur.Visible = true;
                                this.PanelKamarTidur.Enabled = true;

                                this.ImgKamarTidur.ImageUrl = "~/foto/" + reader["ft_kamar_tidur"].ToString();
                            }
                        }
                    }
                    else
                    {
                        this.PanelKamarTidur.Visible = false;
                        this.PanelKamarTidur.Enabled = false;

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgKamarTidur.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoDapur(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dapur from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_dapur"] == DBNull.Value)
                            {
                                this.PanelDapur.Visible = false;
                                this.PanelDapur.Enabled = false;
                            }
                            else
                            {
                                this.PanelDapur.Visible = true;
                                this.PanelDapur.Enabled = true;

                                this.ImageDapur.ImageUrl = "~/foto/" + reader["ft_dapur"].ToString();
                            }
                        }
                    }
                    else
                    {
                        this.PanelDapur.Visible = false;
                        this.PanelDapur.Enabled = false;

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImageDapur.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoKamarMandi(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_kamar_mandi from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_kamar_mandi"] == DBNull.Value)
                            {
                                this.PanelKamarMandi.Visible = false;
                                this.PanelKamarMandi.Enabled = false;
                            }
                            else
                            {
                                this.PanelKamarMandi.Visible = true;
                                this.PanelKamarMandi.Enabled = true;

                                this.ImageKamarMandi.ImageUrl = "~/foto/" + reader["ft_kamar_mandi"].ToString();
                            }
                        }
                    }
                    else
                    {
                        this.PanelKamarMandi.Visible = false;
                        this.PanelKamarMandi.Enabled = false;

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImageKamarMandi.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        //protected void FotoGaji(string no_akun)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            //========================== READER IMAGE FROM DB =========================
        //            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_penghasilan from ukt_document_bm where no_daftar=@no_daftar", connection);
        //            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
        //            SqlDataReader reader = CmdDisplay.ExecuteReader();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    if (reader["ft_penghasilan"] == DBNull.Value)
        //                    {
        //                        this.PanelGaji.Visible = false;
        //                        this.PanelGaji.Enabled = false;
        //                    }
        //                    else
        //                    {
        //                        this.PanelGaji.Visible = true;
        //                        this.PanelGaji.Enabled = true;

        //                        this.ImageGaji.ImageUrl = "~/foto/" + reader["ft_penghasilan"].ToString();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                this.PanelGaji.Visible = false;
        //                this.PanelGaji.Enabled = false;

        //                Console.WriteLine("No Image found.");
        //            }
        //            reader.Close();
        //            //======================== END READER =========================
        //        }
        //        catch (Exception ex)
        //        {
        //            ImageGaji.ImageUrl = null;
        //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //            return;
        //        }
        //    }
        //}


        protected void BtnUpFotoRumah_Click(object sender, EventArgs e)
        {
            if (this.FpFotoRumah.FileName.Length > 30)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
                return;
            }

            //--------------- Filter Ukuran Foto --------------------
            if (!FpFotoRumah.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Foto Rumah Belum Dipilih');", true);
                return;
            }


            if ((FpFotoRumah.PostedFile.ContentLength > 40960) && (FpFotoRumah.PostedFile.ContentLength <= 512000))
            {
                //// Read the file and convert it to Byte Array
                //string filePath = FileUpload1.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                //string ext = Path.GetExtension(filename);
                //string contenttype = String.Empty;

                string FileName = Path.GetFileName(FpFotoRumah.PostedFile.FileName);
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
                    case ".JPG":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/jpeg";
                        break;
                    case ".PNG":
                        contenttype = "image/png";
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
                            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dpn_rumah from ukt_document_bm where no_daftar=@no_daftar", connection);
                            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                            SqlDataReader rdr = CmdDisplay.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //Byte[] bytes = (Byte[])reader["raport"];
                                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                    //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                    string old = "~/" + rdr["ft_dpn_rumah"].ToString();
                                    System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_dpn_rumah"].ToString()));
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

                            if (Exsist())
                            {
                                //UPDATE
                                SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_dpn_rumah=@FotoDepanRumah  WHERE no_daftar=@no_daftar", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@FotoDepanRumah", this.Session["NoDaftar"].ToString() + "-FotoRumah-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpFotoRumah.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-FotoRumah-" + FileName));

                                // ---- open image ------
                                this.PanelFotoRumah.Visible = true;
                                this.PanelFotoRumah.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoRumahDepan(this.Session["NoDaftar"].ToString());

                            }
                            else
                            {
                                // INSERT 
                                SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_dpn_rumah) VALUES (@no_daftar,@ft_dpn_rumah)", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@ft_dpn_rumah", this.Session["NoDaftar"].ToString() + "-FotoRumah-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpFotoRumah.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-FotoRumah-" + FileName));

                                // ---- open image ------
                                this.PanelFotoRumah.Visible = true;
                                this.PanelFotoRumah.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoRumahDepan(this.Session["NoDaftar"].ToString());
                            }

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
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }


        }

        protected void BtnUpRuangTamu_Click(object sender, EventArgs e)
        {
            if (this.FpRuangTamu.FileName.Length > 30)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
                return;
            }

            //--------------- Filter Ukuran Foto --------------------
            if (!FpRuangTamu.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Foto Ruang Tamu Belum Dipilih');", true);
                return;
            }

            if ((FpRuangTamu.PostedFile.ContentLength > 40960) && (FpRuangTamu.PostedFile.ContentLength <= 512000))
            {
                //// Read the file and convert it to Byte Array
                //string filePath = FileUpload1.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                //string ext = Path.GetExtension(filename);
                //string contenttype = String.Empty;

                string FileName = Path.GetFileName(FpRuangTamu.PostedFile.FileName);
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
                    case ".JPG":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/jpeg";
                        break;
                    case ".PNG":
                        contenttype = "image/png";
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
                            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_ruang_tamu from ukt_document_bm where no_daftar=@no_daftar", connection);
                            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                            SqlDataReader rdr = CmdDisplay.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //Byte[] bytes = (Byte[])reader["raport"];
                                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                    //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                    string old = "~/" + rdr["ft_ruang_tamu"].ToString();
                                    System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_ruang_tamu"].ToString()));
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


                            if (Exsist())
                            {
                                //UPDATE
                                SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_ruang_tamu=@FotoRuangTamu WHERE no_daftar=@no_daftar", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@FotoRuangTamu", this.Session["NoDaftar"].ToString() + "-RuangTamu-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpRuangTamu.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-RuangTamu-" + FileName));

                                // ---- open image ------
                                this.PanelRuangTamu.Visible = true;
                                this.PanelRuangTamu.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoRuangTamu(this.Session["NoDaftar"].ToString());

                            }
                            else
                            {
                                // INSERT 
                                SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_ruang_tamu) VALUES (@no_daftar,@ft_ruang_tamu)", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@ft_ruang_tamu", this.Session["NoDaftar"].ToString() + "-RuangTamu-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpRuangTamu.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-RuangTamu-" + FileName));

                                // ---- open image ------
                                this.PanelRuangTamu.Visible = true;
                                this.PanelRuangTamu.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoRuangTamu(this.Session["NoDaftar"].ToString());
                            }

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
            else
            {
                //Label1.ForeColor = System.Drawing.Color.Red;
                //Label1.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

        }

        protected void BtnUpRuangTengah_Click(object sender, EventArgs e)
        {
            if (this.FpRuangTengah.FileName.Length > 30)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
                return;
            }

            //--------------- Filter Ukuran Foto --------------------
            if (!FpRuangTengah.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Ruang Tengah Belum Dipilih');", true);
                return;
            }

            if ((FpRuangTengah.PostedFile.ContentLength > 40960) && (FpRuangTengah.PostedFile.ContentLength <= 512000))
            {
                //// Read the file and convert it to Byte Array
                //string filePath = FileUpload1.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                //string ext = Path.GetExtension(filename);
                //string contenttype = String.Empty;

                string FileName = Path.GetFileName(FpRuangTengah.PostedFile.FileName);
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
                    case ".JPG":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/jpeg";
                        break;
                    case ".PNG":
                        contenttype = "image/png";
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
                            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_ruang_tengah from ukt_document_bm where no_daftar=@no_daftar", connection);
                            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                            SqlDataReader rdr = CmdDisplay.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //Byte[] bytes = (Byte[])reader["raport"];
                                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                    //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                    string old = "~/" + rdr["ft_ruang_tengah"].ToString();
                                    System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_ruang_tengah"].ToString()));
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

                            if (Exsist())
                            {
                                //UPDATE
                                SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_ruang_tengah=@FotoRuangTengah WHERE no_daftar=@no_daftar", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@FotoRuangTengah", this.Session["NoDaftar"].ToString() + "-RuangTengah-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                this.FpRuangTengah.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-RuangTengah-" + FileName));

                                // ---- open image ------
                                this.PanelRuangTengah.Visible = true;
                                this.PanelRuangTengah.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoRuangTengah(this.Session["NoDaftar"].ToString());

                            }
                            else
                            {
                                // INSERT 
                                SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_ruang_tengah) VALUES (@no_daftar,@ft_ruang_tengah)", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@ft_ruang_tengah", this.Session["NoDaftar"].ToString() + "-RuangTengah-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpRuangTengah.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-RuangTengah-" + FileName));

                                // ---- open image ------
                                this.PanelRuangTengah.Visible = true;
                                this.PanelRuangTengah.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoRuangTengah(this.Session["NoDaftar"].ToString());
                            }

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
            else
            {
                //Label1.ForeColor = System.Drawing.Color.Red;
                //Label1.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }


        }

        protected void BtnUpKamarTidur_Click(object sender, EventArgs e)
        {
            if (this.FpKamarTidur.FileName.Length > 30)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
                return;
            }

            //--------------- Filter Ukuran Foto --------------------
            if (!FpKamarTidur.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Kamar Tidur Belum Dipilih');", true);
                return;
            }

            if ((this.FpKamarTidur.PostedFile.ContentLength > 40960) && (FpKamarTidur.PostedFile.ContentLength <= 512000))
            {
                //// Read the file and convert it to Byte Array
                //string filePath = FileUpload1.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                //string ext = Path.GetExtension(filename);
                //string contenttype = String.Empty;

                string FileName = Path.GetFileName(FpKamarTidur.PostedFile.FileName);
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
                    case ".JPG":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/jpeg";
                        break;
                    case ".PNG":
                        contenttype = "image/png";
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
                            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_kamar_tidur from ukt_document_bm where no_daftar=@no_daftar", connection);
                            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                            SqlDataReader rdr = CmdDisplay.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //Byte[] bytes = (Byte[])reader["raport"];
                                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                    //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                    string old = "~/" + rdr["ft_kamar_tidur"].ToString();
                                    System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_kamar_tidur"].ToString()));
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

                            if (Exsist())
                            {
                                //UPDATE
                                SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_kamar_tidur=@FotoRuangTidur WHERE no_daftar=@no_daftar", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@FotoRuangTidur", this.Session["NoDaftar"].ToString() + "-KamarTidur-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                this.FpKamarTidur.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-KamarTidur-" + FileName));

                                // ---- open image ------
                                this.PanelKamarTidur.Visible = true;
                                this.PanelKamarTidur.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoKamarTidur(this.Session["NoDaftar"].ToString());

                            }
                            else
                            {
                                // INSERT 
                                SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_kamar_tidur) VALUES (@no_daftar,@ft_kamar_tidur)", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@ft_kamar_tidur", this.Session["NoDaftar"].ToString() + "-KamarTidur-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpKamarTidur.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-KamarTidur-" + FileName));

                                // ---- open image ------
                                this.PanelKamarTidur.Visible = true;
                                this.PanelKamarTidur.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoKamarTidur(this.Session["NoDaftar"].ToString());
                            }


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
            else
            {
                //Label1.ForeColor = System.Drawing.Color.Red;
                //Label1.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }


        }

        protected void BtnUpDapur_Click(object sender, EventArgs e)
        {
            if (this.FpDapur.FileName.Length > 30)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
                return;
            }

            //--------------- Filter Ukuran Foto --------------------
            if (!FpDapur.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Foto Dapur Belum Dipilih');", true);
                return;
            }

            if ((this.FpDapur.PostedFile.ContentLength > 40960) && (FpDapur.PostedFile.ContentLength <= 512000))
            {
                //// Read the file and convert it to Byte Array
                //string filePath = FileUpload1.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                //string ext = Path.GetExtension(filename);
                //string contenttype = String.Empty;

                string FileName = Path.GetFileName(FpDapur.PostedFile.FileName);
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
                    case ".JPG":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/jpeg";
                        break;
                    case ".PNG":
                        contenttype = "image/png";
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
                            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dapur from ukt_document_bm where no_daftar=@no_daftar", connection);
                            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                            SqlDataReader rdr = CmdDisplay.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //Byte[] bytes = (Byte[])reader["raport"];
                                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                    //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                    string old = "~/" + rdr["ft_dapur"].ToString();
                                    System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_dapur"].ToString()));
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

                            if (Exsist())
                            {
                                //UPDATE
                                SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_dapur=@FotoRuangDapur WHERE no_daftar=@no_daftar", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@FotoRuangDapur", this.Session["NoDaftar"].ToString() + "-Dapur-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                this.FpDapur.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-Dapur-" + FileName));

                                // ---- open image ------
                                this.PanelDapur.Visible = true;
                                this.PanelDapur.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoDapur(this.Session["NoDaftar"].ToString());

                            }
                            else
                            {
                                // INSERT 
                                SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_dapur) VALUES (@no_daftar,@ft_dapur)", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@ft_dapur", this.Session["NoDaftar"].ToString() + "-Dapur-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpDapur.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-Dapur-" + FileName));

                                // ---- open image ------
                                this.PanelDapur.Visible = true;
                                this.PanelDapur.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoDapur(this.Session["NoDaftar"].ToString());
                            }

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
            else
            {
                //Label1.ForeColor = System.Drawing.Color.Red;
                //Label1.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }


        }

        protected void BtnKamarMandi_Click(object sender, EventArgs e)
        {
            if (this.FpKamarMandi.FileName.Length > 30)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
                return;
            }

            //--------------- Filter Ukuran Foto --------------------
            if (!FpKamarMandi.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Foto Kamar Mandi Belum Dipilih');", true);
                return;
            }

            if ((this.FpKamarMandi.PostedFile.ContentLength > 40960) && (FpKamarMandi.PostedFile.ContentLength <= 512000))
            {
                //// Read the file and convert it to Byte Array
                //string filePath = FileUpload1.PostedFile.FileName;
                //string filename = Path.GetFileName(filePath);
                //string ext = Path.GetExtension(filename);
                //string contenttype = String.Empty;

                string FileName = Path.GetFileName(FpKamarMandi.PostedFile.FileName);
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
                    case ".JPG":
                        contenttype = "image/jpeg";
                        break;
                    case ".JPEG":
                        contenttype = "image/jpeg";
                        break;
                    case ".PNG":
                        contenttype = "image/png";
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
                            SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_kamar_mandi from ukt_document_bm where no_daftar=@no_daftar", connection);
                            CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                            SqlDataReader rdr = CmdDisplay.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //Byte[] bytes = (Byte[])reader["raport"];
                                    //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                                    //Image1.ImageUrl = "data:image/png;base64," + base64String;

                                    string old = "~/" + rdr["ft_kamar_mandi"].ToString();
                                    System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_kamar_mandi"].ToString()));
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

                            if (Exsist())
                            {
                                //UPDATE
                                SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_kamar_mandi=@FotoRuangMandi WHERE no_daftar=@no_daftar", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@FotoRuangMandi", this.Session["NoDaftar"].ToString() + "-KamarMandi-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                this.FpKamarMandi.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-KamarMandi-" + FileName));

                                // ---- open image ------
                                this.PanelKamarMandi.Visible = true;
                                this.PanelKamarMandi.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoKamarMandi(this.Session["NoDaftar"].ToString());

                            }
                            else
                            {
                                // INSERT 
                                SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_kamar_mandi) VALUES (@no_daftar,@ft_kamar_mandi)", connection);
                                cmd.CommandType = System.Data.CommandType.Text;

                                //--------------- save path to DB --------------------------
                                cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                                cmd.Parameters.AddWithValue("@ft_kamar_mandi", this.Session["NoDaftar"].ToString() + "-KamarMandi-" + FileName);
                                cmd.ExecuteNonQuery();

                                //------------- InsertUpdateData(cmd) -----------;
                                cmd.Dispose();
                                //Label1.ForeColor = System.Drawing.Color.Green;
                                //Label1.Text = "File Uploaded Successfully";

                                //---------- Save files to disk -------------------
                                FpKamarMandi.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-KamarMandi-" + FileName));

                                // ---- open image ------
                                this.PanelKamarMandi.Visible = true;
                                this.PanelKamarMandi.Enabled = true;

                                connection.Close();
                                connection.Dispose();

                                FotoKamarMandi(this.Session["NoDaftar"].ToString());
                            }

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
            else
            {
                //Label1.ForeColor = System.Drawing.Color.Red;
                //Label1.Text = "Ukuran File 100 KB - 200 KB";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }


        }

        //protected void BtnGaji_Click(object sender, EventArgs e)
        //{
        //    if (this.FpGaji.FileName.Length > 30)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Karakter Nama File Melebihi Ketentuan');", true);
        //        return;
        //    }

        //    //--------------- Filter Ukuran Foto --------------------
        //    if (!FpGaji.HasFile)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Foto Gaji Belum Dipilih');", true);
        //        return;
        //    }

        //    if ((this.FpGaji.PostedFile.ContentLength > 307200) && (FpGaji.PostedFile.ContentLength <= 512000))
        //    {
        //        //// Read the file and convert it to Byte Array
        //        //string filePath = FileUpload1.PostedFile.FileName;
        //        //string filename = Path.GetFileName(filePath);
        //        //string ext = Path.GetExtension(filename);
        //        //string contenttype = String.Empty;

        //        string FileName = Path.GetFileName(FpGaji.PostedFile.FileName);
        //        string ext = Path.GetExtension(FileName);
        //        string contenttype = String.Empty;


        //        //Set the contenttype based on File Extension
        //        switch (ext)
        //        {
        //            case ".jpg":
        //                contenttype = "image/jpg";
        //                break;
        //            case ".jpeg":
        //                contenttype = "image/jpeg";
        //                break;
        //            case ".png":
        //                contenttype = "image/png";
        //                break;
        //            case ".JPG":
        //                contenttype = "image/jpeg";
        //                break;
        //            case ".JPEG":
        //                contenttype = "image/jpeg";
        //                break;
        //            case ".PNG":
        //                contenttype = "image/png";
        //                break;
        //        }

        //        if (contenttype != String.Empty)
        //        {
        //            // ------- delete old image from server  ------------
        //            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //            {
        //                try
        //                {
        //                    connection.Open();
        //                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_penghasilan from ukt_document_bm where no_daftar=@no_daftar", connection);
        //                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
        //                    SqlDataReader rdr = CmdDisplay.ExecuteReader();
        //                    if (rdr.HasRows)
        //                    {
        //                        while (rdr.Read())
        //                        {
        //                            //Byte[] bytes = (Byte[])reader["raport"];
        //                            //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //                            //Image1.ImageUrl = "data:image/png;base64," + base64String;

        //                            string old = "~/" + rdr["ft_penghasilan"].ToString();
        //                            System.IO.File.Delete(Server.MapPath("~/foto/" + rdr["ft_penghasilan"].ToString()));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //Console.WriteLine("No Image found.");
        //                    }
        //                    rdr.Close();

        //                }
        //                catch (Exception ex)
        //                {
        //                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //                }
        //            }


        //            //insert the file into database
        //            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
        //            {
        //                try
        //                {
        //                    connection.Open();

        //                    if (Exsist())
        //                    {
        //                        //UPDATE
        //                        SqlCommand cmd = new SqlCommand("UPDATE ukt_document_bm SET ft_penghasilan=@FotoPenghasilan WHERE no_daftar=@no_daftar", connection);
        //                        cmd.CommandType = System.Data.CommandType.Text;

        //                        //--------------- save path to DB --------------------------
        //                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
        //                        cmd.Parameters.AddWithValue("@FotoPenghasilan", this.Session["NoDaftar"].ToString() + "-Penghasilan-" + FileName);
        //                        cmd.ExecuteNonQuery();

        //                        //------------- InsertUpdateData(cmd) -----------;
        //                        cmd.Dispose();
        //                        //Label1.ForeColor = System.Drawing.Color.Green;
        //                        //Label1.Text = "File Uploaded Successfully";

        //                        //---------- Save files to disk -------------------
        //                        this.FpGaji.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-Penghasilan-" + FileName));

        //                        // ---- open image ------
        //                        this.PanelGaji.Visible = true;
        //                        this.PanelGaji.Enabled = true;

        //                        connection.Close();
        //                        connection.Dispose();

        //                        FotoGaji(this.Session["NoDaftar"].ToString());

        //                    }
        //                    else
        //                    {
        //                        // INSERT 
        //                        SqlCommand cmd = new SqlCommand("INSERT INTO ukt_document_bm (no_daftar,ft_penghasilan) VALUES (@no_daftar,@ft_penghasilan)", connection);
        //                        cmd.CommandType = System.Data.CommandType.Text;

        //                        //--------------- save path to DB --------------------------
        //                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
        //                        cmd.Parameters.AddWithValue("@ft_penghasilan", this.Session["NoDaftar"].ToString() + "-Penghasilan-" + FileName);
        //                        cmd.ExecuteNonQuery();

        //                        //------------- InsertUpdateData(cmd) -----------;
        //                        cmd.Dispose();
        //                        //Label1.ForeColor = System.Drawing.Color.Green;
        //                        //Label1.Text = "File Uploaded Successfully";

        //                        //---------- Save files to disk -------------------
        //                        FpGaji.SaveAs(Server.MapPath("~/foto/" + this.Session["NoDaftar"].ToString() + "-Penghasilan-" + FileName));

        //                        // ---- open image ------
        //                        this.PanelGaji.Visible = true;
        //                        this.PanelGaji.Enabled = true;

        //                        connection.Close();
        //                        connection.Dispose();

        //                        FotoGaji(this.Session["NoDaftar"].ToString());
        //                    }

        //                }
        //                catch (Exception ex)
        //                {
        //                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //                }
        //            }
        //        }
        //        else // type file tidak diperbolehkan
        //        {
        //            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diperbolehkan');", true);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        //Label1.ForeColor = System.Drawing.Color.Red;
        //        //Label1.Text = "Ukuran File 100 KB - 200 KB";

        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
        //        return;
        //    }


        //}

        protected Boolean Exsist()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER NO DAFTAR FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {                        
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;                        
                    }
                    //======================== END READER =========================
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}