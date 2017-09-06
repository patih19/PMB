using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace smmuntidar.user
{
    public partial class WebForm3 : user_login
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
                this.PanelSPI.Visible = false;
                this.PanelSPI.Enabled = false;

                PopulatePerhasilan();
                ClosePanelPenghasilan();

                //---------------------------------- Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
                this.LbTrans.Text = Session["Name"].ToString();

                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_spi where smmuntidar_spi.no_tagihan=@no_tagihan", con);
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
                                    Response.Redirect("~/user/pasfoto.aspx", false);
                                }
                                else if (rdr["proses_komplet"] == DBNull.Value)
                                {
                                    //Response.Redirect("~/user/confirm.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            // data no tagihan tidak ditemukan, sepertinya tidak mungkin karena user sudah bisa login
                        }
                    }
                }
                //---------------------------------- End Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
            }
        }

        private void PopulatePerhasilan()
        {
            try
            {
                // ------------------------------------------------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ----------------- Jumlah Peserta Tiap Prodi ---------------------------------
                    using (SqlCommand CmdProdiStatistik = new SqlCommand("SELECT id_penghasilan,penghasilan " +
                                                                    "FROM spi_penghasilan WHERE tahun_digunakan = (SELECT TOP 1 tahun_digunakan FROM spi_penghasilan ORDER BY tahun_digunakan DESC )", con))
                    {
                        CmdProdiStatistik.CommandType = System.Data.CommandType.Text;

                        this.DLPenghasilanOrtu.DataSource = CmdProdiStatistik.ExecuteReader();
                        this.DLPenghasilanOrtu.DataTextField = "penghasilan";
                        this.DLPenghasilanOrtu.DataValueField = "id_penghasilan";
                        this.DLPenghasilanOrtu.DataBind();
                    }

                    con.Close();
                    con.Dispose();

                    this.DLPenghasilanOrtu.Items.Insert(0, new ListItem("--- Pilih penghasilan orang tua/wali ---", "0"));
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void PopulatePilihanSPI()
        {
            try
            {
                this.PanelPenghasilan.Enabled = false;
                this.PanelPenghasilan.Visible = false;

                this.PanelSPI.Visible = true;
                this.PanelSPI.Enabled = true;

                // ------------------------------------------------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ----------------- Jumlah Peserta Tiap Prodi ---------------------------------
                    using (SqlCommand CmdPilihanSPI = new SqlCommand("SELECT id_spi, sumbangan_text FROM spi_sumbangan WHERE id_penghasilan= (SELECT id_penghasilan FROM smmuntidar_spi WHERE no_tagihan =@no_tagihan )", con))
                    {
                        CmdPilihanSPI.CommandType = System.Data.CommandType.Text;
                        //CmdPilihanSPI.Parameters.AddWithValue("no_tagihan", "0600000006");
                        CmdPilihanSPI.Parameters.AddWithValue("no_tagihan", this.Session["no_tagihan"].ToString());

                        this.DLSPI.DataSource = CmdPilihanSPI.ExecuteReader();
                        this.DLSPI.DataTextField = "sumbangan_text";
                        this.DLSPI.DataValueField = "id_spi";
                        this.DLSPI.DataBind();
                    }

                    this.DLSPI.Items.Insert(0, new ListItem("--- Pilih Sumbangan ---", "0"));

                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        private void ClosePanelPenghasilan()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {

                    connection.Open();
                    //========================== CEK PENGHASILAN =========================
                    SqlCommand cmdCekSPI = new SqlCommand("SELECT no_tagihan,id_penghasilan FROM smmuntidar_spi WHERE no_tagihan=@no_tagihan", connection);
                    cmdCekSPI.CommandType = System.Data.CommandType.Text;

                    //cmdCekSPI.Parameters.AddWithValue("@no_tagihan", "0600000006");
                    cmdCekSPI.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    SqlDataReader reader = cmdCekSPI.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["id_penghasilan"] != DBNull.Value)
                            {
                                this.PanelPenghasilan.Enabled = false;
                                this.PanelPenghasilan.Visible = false;

                                this.PanelSPI.Visible = true;
                                this.PanelSPI.Enabled = true;

                                reader.Close();
                                reader.Dispose();

                                cmdCekSPI.Dispose();

                                //========================== DISPLAY PENGHASILAN =========================
                                SqlCommand cmdShowPenghasilan = new SqlCommand("SELECT smmuntidar_spi.no_tagihan, spi_penghasilan.id_penghasilan, spi_penghasilan.penghasilan " +
                                                                                "FROM smmuntidar_spi INNER JOIN " +
                                                                                            "spi_penghasilan ON smmuntidar_spi.id_penghasilan = spi_penghasilan.id_penghasilan " +
                                                                                "WHERE smmuntidar_spi.no_tagihan = @no_tagihan", connection);
                                cmdShowPenghasilan.CommandType = System.Data.CommandType.Text;

                                //cmdShowPenghasilan.Parameters.AddWithValue("@no_tagihan", "0600000006");
                                cmdShowPenghasilan.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                                SqlDataReader RdrShowPenghasilan = cmdShowPenghasilan.ExecuteReader();
                                if (RdrShowPenghasilan.HasRows)
                                {
                                    while (RdrShowPenghasilan.Read())
                                    {
                                        if (RdrShowPenghasilan["penghasilan"] != DBNull.Value)
                                        {
                                            this.LbPenghasilan.Text = "Penghasilan : " + RdrShowPenghasilan["penghasilan"].ToString().Trim();
                                            this.LbPenghasilan.Font.Bold = true;
                                        }

                                    }
                                }
                                RdrShowPenghasilan.Close();
                                RdrShowPenghasilan.Dispose();

                                cmdShowPenghasilan.Dispose();

                                connection.Close();

                                PopulatePilihanSPI();

                                return;
                            }


                        }



                    }
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return;
            }

        }

        protected void BtnPenghasilan_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {

                        connection.Open();
                        //========================== INPUT SPI =========================
                        SqlCommand cmdSPI = new SqlCommand("SpInsertSPI", connection);
                        cmdSPI.CommandType = System.Data.CommandType.StoredProcedure;

                        //cmdSPI.Parameters.AddWithValue("@no_tagihan", "0600000006");
                        cmdSPI.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmdSPI.Parameters.AddWithValue("@IdPenghasilan", this.DLPenghasilanOrtu.SelectedValue.Trim());
                        
                        cmdSPI.ExecuteNonQuery();

                        // ==================== ==================
                        PopulatePilihanSPI();

                        //========================== DISPLAY PENGHASILAN =========================
                        SqlCommand cmdShowPenghasilan = new SqlCommand("SELECT smmuntidar_spi.no_tagihan, spi_penghasilan.id_penghasilan, spi_penghasilan.penghasilan " +
                                                                        "FROM smmuntidar_spi INNER JOIN " +
                                                                                    "spi_penghasilan ON smmuntidar_spi.id_penghasilan = spi_penghasilan.id_penghasilan " +
                                                                        "WHERE smmuntidar_spi.no_tagihan = @no_tagihan", connection);
                        cmdShowPenghasilan.CommandType = System.Data.CommandType.Text;

                        //cmdShowPenghasilan.Parameters.AddWithValue("@no_tagihan", "0600000006");
                        cmdShowPenghasilan.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                        SqlDataReader RdrShowPenghasilan = cmdShowPenghasilan.ExecuteReader();
                        if (RdrShowPenghasilan.HasRows)
                        {
                            while (RdrShowPenghasilan.Read())
                            {
                                if (RdrShowPenghasilan["penghasilan"] != DBNull.Value)
                                {
                                    this.LbPenghasilan.Text = "Penghasilan : " + RdrShowPenghasilan["penghasilan"].ToString().Trim();
                                    this.LbPenghasilan.Font.Bold = true;
                                }

                            }
                        }
                        RdrShowPenghasilan.Close();
                        RdrShowPenghasilan.Dispose();

                        cmdShowPenghasilan.Dispose();

                }                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void BtnSaveSPI_Click(object sender, EventArgs e)
        {

            if (this.DLSPI.SelectedItem.Text.Trim() == "--- Pilih Sumbangan ---")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Sumbangan Belum Dipilih !!');", true);
                return;
            }

            try
            {
                // ------------------------------------------------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ----------------- Jumlah Peserta Tiap Prodi ---------------------------------
                    using (SqlCommand CmdSaveSPI = new SqlCommand("UPDATE dbo.smmuntidar_spi SET sumbangan = (SELECT sumbangan FROM spi_sumbangan WHERE id_spi =@IdSPI), date=GETDATE(), proses_komplet='ok', tahun=(SELECT tahun FROM smmuntidar_tagihan WHERE no_tagihan=@no_tagihan) WHERE no_tagihan=@no_tagihan", con))
                    {
                        CmdSaveSPI.CommandType = System.Data.CommandType.Text;
                        //CmdSaveSPI.Parameters.AddWithValue("@no_tagihan", "0600000006");
                        CmdSaveSPI.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        CmdSaveSPI.Parameters.AddWithValue("@IdSPI", this.DLSPI .SelectedValue.Trim());

                        CmdSaveSPI.ExecuteNonQuery();

                        Response.Redirect("~/user/pasfoto.aspx", false);
                    }

                    con.Close();
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return;
            }
        }
    }
}