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

namespace UKT
{
    public partial class WebForm11 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //------------------- Cek Upload Komplet ----------------
                //this.BtnSubmit.Visible = false;
                //this.BtnSubmit.Enabled = false;

                string CSUp = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CSUp))
                {
                    con.Open();

                    // --------------- Cek Borang Sebelumnya ----------------------//
                    SqlCommand CmdCekAset = new SqlCommand("SELECT no_daftar,komplate,valid FROM dbo.ukt_harta WHERE no_daftar=@no_daftar", con);
                    CmdCekAset.CommandType = System.Data.CommandType.Text;
                    CmdCekAset.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrEko = CmdCekAset.ExecuteReader())
                    {
                        if (rdrEko.HasRows)
                        {
                            while (rdrEko.Read())
                            {
                                if (rdrEko["komplate"].ToString() != "yes" && rdrEko["valid"].ToString() == "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekFasilitas = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_falilitas WHERE no_daftar=@no_daftar", con);
                    CmdCekFasilitas.CommandType = System.Data.CommandType.Text;
                    CmdCekFasilitas.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrEko = CmdCekFasilitas.ExecuteReader())
                    {
                        if (rdrEko.HasRows)
                        {
                            while (rdrEko.Read())
                            {
                                if (rdrEko["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekHarta = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_harta WHERE no_daftar=@no_daftar", con);
                    CmdCekHarta.CommandType = System.Data.CommandType.Text;
                    CmdCekHarta.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrHarta = CmdCekHarta.ExecuteReader())
                    {
                        if (rdrHarta.HasRows)
                        {
                            while (rdrHarta.Read())
                            {
                                if (rdrHarta["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekKeluarga = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_keluarga WHERE no_daftar=@no_daftar", con);
                    CmdCekKeluarga.CommandType = System.Data.CommandType.Text;
                    CmdCekKeluarga.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrKeluarga = CmdCekKeluarga.ExecuteReader())
                    {
                        if (rdrKeluarga.HasRows)
                        {
                            while (rdrKeluarga.Read())
                            {
                                if (rdrKeluarga["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekLingkungan = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_lingkungan WHERE no_daftar=@no_daftar", con);
                    CmdCekLingkungan.CommandType = System.Data.CommandType.Text;
                    CmdCekLingkungan.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrLingkungan = CmdCekLingkungan.ExecuteReader())
                    {
                        if (rdrLingkungan.HasRows)
                        {
                            while (rdrLingkungan.Read())
                            {
                                if (rdrLingkungan["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekPerabot = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_perabot WHERE no_daftar=@no_daftar", con);
                    CmdCekPerabot.CommandType = System.Data.CommandType.Text;
                    CmdCekPerabot.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrPerabot = CmdCekPerabot.ExecuteReader())
                    {
                        if (rdrPerabot.HasRows)
                        {
                            while (rdrPerabot.Read())
                            {
                                if (rdrPerabot["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekPribadi = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_pribadi WHERE no_daftar=@no_daftar", con);
                    CmdCekPribadi.CommandType = System.Data.CommandType.Text;
                    CmdCekPribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrPribadi = CmdCekPribadi.ExecuteReader())
                    {
                        if (rdrPribadi.HasRows)
                        {
                            while (rdrPribadi.Read())
                            {
                                if (rdrPribadi["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }

                    SqlCommand CmdCekRumah = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_rumah WHERE no_daftar=@no_daftar", con);
                    CmdCekRumah.CommandType = System.Data.CommandType.Text;
                    CmdCekRumah.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdrRumah = CmdCekRumah.ExecuteReader())
                    {
                        if (rdrRumah.HasRows)
                        {
                            while (rdrRumah.Read())
                            {
                                if (rdrRumah["komplate"].ToString() != "yes")
                                {
                                    Response.Redirect("Pri.aspx", false);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Pri.aspx", false);
                            return;
                        }
                    }
                    // --------------- End Cek Borang Sebelumnya ----------------------//



                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["komplate"].ToString() == "yes")
                                {
                                    if (this.Session["Jalur"].ToString().Trim() == "SNMPTN")
                                    {
                                        Response.Redirect("FnhSn.aspx", false);
                                    }
                                    else if (this.Session["Jalur"].ToString().Trim() == "SBMPTN")
                                    {
                                        Response.Redirect("FnhSb.aspx", false);
                                    }
                                    else if (this.Session["Jalur"].ToString().Trim() == "SM-UNTIDAR")
                                    {
                                        Response.Redirect("FnhSmTulis.aspx", false);
                                    }
                                    else if (this.Session["Jalur"].ToString().Trim() == "PMDK-D3")
                                    {
                                        Response.Redirect("FnhSmPmdk.aspx", false);
                                    }
                                }
                            }
                        }
                    }
                }

                
            }
                // -- =================================  Keterangan Upload  =========================================== --
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    //-----------------------------------Keterangan KK -----------------------------------------------
                    string KetKK = "";
                    SqlCommand CmdKK = new SqlCommand("SELECT kk FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdKK.CommandType = System.Data.CommandType.Text;
                    CmdKK.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdKK.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["kk"] != DBNull.Value)
                                {
                                    KetKK = "uploaded";
                                    this.LbKK.Text = "File Uploaded";
                                    LbKK.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbKK.Text = "File tidak diupload";
                                    LbKK.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }

                    //-----------------------------------Keterangan Foto Rumah -----------------------------------------------
                    string KetFtRumah = "";
                    SqlCommand CmdFotoRumah = new SqlCommand("SELECT ft_dpn_rumah FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdFotoRumah.CommandType = System.Data.CommandType.Text;
                    CmdFotoRumah.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdFotoRumah.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["ft_dpn_rumah"] != DBNull.Value)
                                {
                                    KetFtRumah = "uploaded";
                                    this.LbRumah.Text = "File Uploaded";
                                    LbRumah.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbRumah.Text = "File tidak diupload";
                                    LbRumah.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }

                    //-----------------------------------Keterangan Penghasilan -----------------------------------------------
                    string KetPenghasilan = "";
                    SqlCommand CmdPenghasilan = new SqlCommand("SELECT penghasilan FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPenghasilan.CommandType = System.Data.CommandType.Text;
                    CmdPenghasilan.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdPenghasilan.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["penghasilan"] != DBNull.Value)
                                {
                                    KetPenghasilan = "uploaded";
                                    this.LbPenghasilan.Text = "File Uploaded";
                                    LbPenghasilan.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbPenghasilan.Text = "File tidak diupload";
                                    LbPenghasilan.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }


                    //------------ Enable Btn Upload ----------------------//
                    if (KetPenghasilan == "uploaded" && KetKK == "uploaded" && KetPenghasilan == "uploaded")
                    {
                        this.BtnSubmit.Visible = true;
                        this.BtnSubmit.Enabled = true;
                    }


                    //-----------------------------------Keterangan Upload STNK -----------------------------------------------
                    SqlCommand CmdSTNK = new SqlCommand("SELECT stnk FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdSTNK.CommandType = System.Data.CommandType.Text;

                    CmdSTNK.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdSTNK.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["stnk"] != DBNull.Value)
                                {
                                    this.LbSTNK.Text = "File Uploaded";
                                    LbSTNK.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbSTNK.Text = "File not found";
                                    LbSTNK.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }

                    }

                    //-----------------------------------Keterangan Upload Rekening Listrik -----------------------------------------------
                    SqlCommand CmdListrik = new SqlCommand("SELECT listrik FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdListrik.CommandType = System.Data.CommandType.Text;

                    CmdListrik.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdListrik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["listrik"] != DBNull.Value)
                                {
                                    this.LbListrik.Text = "File Uploaded";
                                    LbListrik.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbListrik.Text = "File not found";
                                    LbListrik.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }

                    }

                    //----------------------------------- Keterangan Upload Rekening Air -----------------------------------------------
                    SqlCommand CmdRekenigAir = new SqlCommand("SELECT air FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdRekenigAir.CommandType = System.Data.CommandType.Text;

                    CmdRekenigAir.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdRekenigAir.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["air"] != DBNull.Value)
                                {
                                    this.LbAir.Text = "File Uploaded";
                                    LbAir.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbAir.Text = "File not found";
                                    LbAir.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }

                    }

                    //----------------------------------- Keterangan Upload Rekening Telepon -----------------------------------------------
                    SqlCommand CmdRekeingTelepon = new SqlCommand("SELECT telp FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdRekeingTelepon.CommandType = System.Data.CommandType.Text;

                    CmdRekeingTelepon.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdRekeingTelepon.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["telp"] != DBNull.Value)
                                {
                                    this.LbTelp.Text = "File Uploaded";
                                    LbTelp.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    this.LbTelp.Text = "File not found";
                                    LbTelp.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }

                    }

                    //------------------- Cek Upload Komplet ----------------
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_document WHERE no_daftar=@no_daftar", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["komplate"].ToString() == "yes")
                                {
                                    if (this.Session["Jalur"].ToString().Trim() == "SNMPTN")
                                    {
                                        Response.Redirect("FnhSn.aspx", false);
                                    }
                                    else if (this.Session["Jalur"].ToString().Trim() == "SBMPTN")
                                    {
                                        Response.Redirect("FnhSb.aspx", false);
                                    }
                                    else if (this.Session["Jalur"].ToString().Trim() == "SM-UNTIDAR")
                                    {
                                        Response.Redirect("FnhSmTulis.aspx", false);
                                    }
                                    else if (this.Session["Jalur"].ToString().Trim() == "SM-PMDK")
                                    {
                                        Response.Redirect("FnhSmPmdk.aspx", false);
                                    }
                                }
                            }
                        }
                    }
                }
            // -- ======================  End Keterangan Upload ====================================== --
            //}
        }

        protected void BtnUpKK_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (FileUploadKK.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if ( !FileUploadKK.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File KK Sebelum Upload');", true);
                return;
            }

            if (FileUploadKK.PostedFile.ContentLength < 102400 || FileUploadKK.PostedFile.ContentLength >= 307200)
            {
                LbKK.ForeColor = System.Drawing.Color.Red;
                LbKK.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadKK.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, kk from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["kk"].ToString()));
                            }
                        }
                        else
                        {
                            //Console.WriteLine("No Image found.");
                        }
                        rdr.Close();


                        //SqlCommand Remove = new SqlCommand("update kk from ukt_document where no_daftar=@no_daftar", connection);
                        //Remove.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        //Remove.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpInputKK", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FileKK", this.Session["NoDaftar"].ToString() + "-KK-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        LbKK.ForeColor = System.Drawing.Color.Green;
                        LbKK.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUploadKK.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-KK-" + FileName));

                        //this.Button1.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            
            }
        }

        protected void BtnRumah_Click(object sender, EventArgs e)
        {
            //---------------- Filter Ukuran Foto --------------------
            if (FileUploadRumah.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if (!FileUploadRumah .HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File Foto Rumah Sebelum Upload');", true);
                return;
            }

            if (FileUploadRumah.PostedFile.ContentLength < 102400 || FileUploadRumah.PostedFile.ContentLength >= 307200)
            {
                this.LbRumah.ForeColor = System.Drawing.Color.Red;
                this.LbRumah.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadRumah.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dpn_rumah from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["ft_dpn_rumah"].ToString()));
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
                        this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpInputFtRumah", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FileFtRmh", this.Session["NoDaftar"].ToString() + "-FotoRmh-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.LbRumah.ForeColor = System.Drawing.Color.Green;
                        this.LbRumah.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        this.FileUploadRumah.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-FotoRmh-" + FileName));

                        //this.Button1.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            }
        }

        protected void BtnPenghasilan_Click(object sender, EventArgs e)
        {
            //---------------- Filter Ukuran Foto --------------------
            if (this.FileUploadPenghasilan.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if (!FileUploadPenghasilan.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File Keterangan Penghasilan Sebelum Upload');", true);
                return;
            }

            if (FileUploadPenghasilan.PostedFile.ContentLength < 102400 || FileUploadPenghasilan.PostedFile.ContentLength >= 307200)
            {
                this.LbPenghasilan.ForeColor = System.Drawing.Color.Red;
                this.LbPenghasilan.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadPenghasilan.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, penghasilan from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["penghasilan"].ToString()));
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
                        this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpInputPenghasilan", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FilePenghasilan", this.Session["NoDaftar"].ToString() + "-Penghasilan-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.LbPenghasilan.ForeColor = System.Drawing.Color.Green;
                        this.LbPenghasilan.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        this.FileUploadPenghasilan.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-Penghasilan-" + FileName));

                        //this.Button1.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            }
        }

        protected void BtnUpSTNK_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (FileUploadSTNK.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if (!FileUploadSTNK.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File STNK Sebelum Upload');", true);
                return;
            }

            if (this.FileUploadSTNK.PostedFile.ContentLength < 102400 || FileUploadSTNK.PostedFile.ContentLength >= 307200)
            {
                this.LbSTNK.ForeColor = System.Drawing.Color.Red;
                this.LbSTNK.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadSTNK.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, stnk from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["stnk"].ToString()));
                            }
                        }
                        else
                        {
                            //Console.WriteLine("No Image found.");
                        }
                        rdr.Close();


                        //SqlCommand Remove = new SqlCommand("update stnk from ukt_document where no_daftar=@no_daftar", connection);
                        //Remove.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        //Remove.ExecuteNonQuery();

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
                        SqlCommand cmd = new SqlCommand("SpInputSTNK", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FileSTNK", this.Session["NoDaftar"].ToString() + "-STNK-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.LbSTNK.ForeColor = System.Drawing.Color.Green;
                        this.LbSTNK.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUploadSTNK.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-STNK-" + FileName));

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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            }
        }

        protected void BtnUpListrik_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (FileUploadListrik.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if ( !FileUploadListrik.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File Rekening Listrik Sebelum Upload');", true);
                return;
            }

            if (this.FileUploadListrik.PostedFile.ContentLength < 102400 || FileUploadListrik.PostedFile.ContentLength >= 307200)
            {
                this.LbListrik.ForeColor = System.Drawing.Color.Red;
                this.LbListrik.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadListrik.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, listrik from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["listrik"].ToString()));
                            }
                        }
                        else
                        {
                            //Console.WriteLine("No Image found.");
                        }
                        rdr.Close();


                        //SqlCommand Remove = new SqlCommand("update listrik from ukt_document where no_daftar=@no_daftar", connection);
                        //Remove.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        //Remove.ExecuteNonQuery();

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
                        SqlCommand cmd = new SqlCommand("SpInputListrik", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FileListrik", this.Session["NoDaftar"].ToString() + "-LISTRIK-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.LbListrik.ForeColor = System.Drawing.Color.Green;
                        this.LbListrik.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUploadListrik.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-LISTRIK-" + FileName));

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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            }
        }

        protected void BtnUpAir_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (FileUploadAir.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if ( !this.FileUploadAir.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File Rekening Air Sebelum Upload');", true);
                return;
            }

            if (this.FileUploadAir.PostedFile.ContentLength < 102400 || FileUploadAir.PostedFile.ContentLength >= 307200)
            {
                this.LbAir.ForeColor = System.Drawing.Color.Red;
                this.LbAir.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadAir.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, air from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["air"].ToString()));
                            }
                        }
                        else
                        {
                            //Console.WriteLine("No Image found.");
                        }
                        rdr.Close();


                        //SqlCommand Remove = new SqlCommand("update air from ukt_document where no_daftar=@no_daftar", connection);
                        //Remove.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        //Remove.ExecuteNonQuery();

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
                        SqlCommand cmd = new SqlCommand("SpInputAir", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FileAir", this.Session["NoDaftar"].ToString() + "-AIR-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.LbAir.ForeColor = System.Drawing.Color.Green;
                        this.LbAir.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUploadAir.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-AIR-" + FileName));

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
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            }
        }

        protected void BtnUpTelp_Click(object sender, EventArgs e)
        {
            //--------------- Filter Ukuran Foto --------------------
            if (FileUploadTelp.FileName.Length > 25)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama File Lebih Dari 25 Karekter');", true);
                return;
            }

            if (!this.FileUploadTelp.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih File Rekening Telepon Sebelum Upload');", true);
                return;
            }

            if (this.FileUploadTelp.PostedFile.ContentLength < 102400 || FileUploadTelp.PostedFile.ContentLength >= 307200)
            {
                this.LbTelp.ForeColor = System.Drawing.Color.Red;
                this.LbTelp.Text = "Ukuran File 100-300 Kb";

                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Ukuran File Tidak Sesuai Ketentuan');", true);
                return;
            }

            string FileName = Path.GetFileName(FileUploadTelp.PostedFile.FileName);
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
                    contenttype = "image/bmp";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpeg";
                    break;
                case ".PNG":
                    contenttype = "image/png";
                    break;
                case ".BMP":
                    contenttype = "image/bmp";
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
                        SqlCommand CmdDisplay = new SqlCommand("select no_daftar, telp from ukt_document where no_daftar=@no_daftar", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        SqlDataReader rdr = CmdDisplay.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                System.IO.File.Delete(Server.MapPath("~/document/" + rdr["telp"].ToString()));
                            }
                        }
                        else
                        {
                            //Console.WriteLine("No Image found.");
                        }
                        rdr.Close();


                        //SqlCommand Remove = new SqlCommand("update telp from ukt_document where no_daftar=@no_daftar", connection);
                        //Remove.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString()); // this.Session["Name"].ToString());
                        //Remove.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        //this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }

                //insert the file into database
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("SpInputTelp", connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                        cmd.Parameters.AddWithValue("@FileTelp", this.Session["NoDaftar"].ToString() + "-TELEPON-" + FileName);
                        cmd.ExecuteNonQuery();

                        //------------- InsertUpdateData(cmd) -----------;
                        cmd.Dispose();
                        this.LbTelp.ForeColor = System.Drawing.Color.Green;
                        this.LbTelp.Text = "File Uploaded Successfully";

                        //---------- Save files to disk -------------------
                        FileUploadTelp.SaveAs(Server.MapPath("~/document/" + this.Session["NoDaftar"].ToString() + "-TELEPON-" + FileName));

                        //this.Button1.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        //this.LbErr.Text = ex.Message.ToString();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    }
                }
            }
            else // type file tidak diperbolehkan
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('File Tidak Diizinkan');", true);
                return;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Unggah File Pendukung Kelengkapan
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    //open connection and begin transaction
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("SpCatatUploadDoc", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Fnh.aspx", false);
                }
                catch (Exception ex)
                {
                    this.LbErr.Text = ex.Message.ToString();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/document/slip.pdf");
        }

    }
}