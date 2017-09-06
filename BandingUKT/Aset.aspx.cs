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

namespace BandingUKT
{
    public partial class Aset : User
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
                    base.Response.Redirect("~/Peserta.aspx");
                }
                else
                {
                    this.GetDataAset(this.Session["NoDaftar"].ToString());
                    //LoadDataSurveiAset();
                }
            }
        }

        protected void GetDataAset(string npm)
        {
            string NoDaftar = "";

            string CS2 = ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS2))
            {
                try
                {
                    // ----- Get No Daftar----- //
                    con.Open();

                    SqlCommand CekPribadi = new SqlCommand("SELECT npm,no_daftar FROM bak_mahasiswa WHERE npm=@npm", con);
                    CekPribadi.CommandType = System.Data.CommandType.Text;
                    CekPribadi.Parameters.AddWithValue("@npm", npm);

                    using (SqlDataReader rdr = CekPribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                NoDaftar = rdr["no_daftar"].ToString().Trim();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                }
                catch (Exception)
                {
                    return;
                }
            }

            //---- GET DATA LAMA ---//
            string StrPribadi = "";
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_harta_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    CekPribadi.CommandType = System.Data.CommandType.Text;
                    CekPribadi.Parameters.AddWithValue("@no_daftar", npm);


                    using (SqlDataReader rdr = CekPribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            StrPribadi = "ada";
                        }
                    }

                    // -----Data Banding Belum ada -----//
                    if (StrPribadi == "")
                    {
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_harta WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.DLSawah1.SelectedIndex = this.DLSawah1.Items.IndexOf(DLSawah1.Items.FindByText(rdr["sawah"].ToString().Trim()));
                                    this.DLTanah1.SelectedIndex = DLTanah1.Items.IndexOf(DLTanah1.Items.FindByText(rdr["tanah"].ToString().Trim()));
                                    this.DLternak1.SelectedIndex = this.DLternak1.Items.IndexOf(DLternak1.Items.FindByText(rdr["ternak"].ToString().Trim()));
                                    this.DLmobil1.SelectedIndex = DLmobil1.Items.IndexOf(DLmobil1.Items.FindByText(rdr["mobil"].ToString().Trim()));
                                    this.DLGiro1.SelectedIndex = DLGiro1.Items.IndexOf(DLGiro1.Items.FindByText(rdr["tabungan"].ToString().Trim()));
                                    this.DLPerhiasan1.SelectedIndex = DLPerhiasan1.Items.IndexOf(DLPerhiasan1.Items.FindByText(rdr["hiasan"].ToString().Trim()));
                                    this.DLSepeda1.SelectedIndex = DLSepeda1.Items.IndexOf(DLSepeda1.Items.FindByText(rdr["sepeda"].ToString().Trim()));
                                }

                                this.PanelMsg1.Enabled = false;
                                this.PanelMsg1.Visible = false;

                                this.BtnSave1.Enabled = true;
                                this.BtnSave1.Visible = true;

                                this.BtnUpdate1.Enabled = false;
                                this.BtnUpdate1.Visible = false;
                            }
                        }
                    }
                    else if (StrPribadi == "ada")
                    {
                        // ------ Data Pribadi Banding Ada ---------- //
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_harta_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLSawah1.SelectedIndex = this.DLSawah1.Items.IndexOf(DLSawah1.Items.FindByText(rdr["sawah"].ToString().Trim()));
                                    this.DLTanah1.SelectedIndex = DLTanah1.Items.IndexOf(DLTanah1.Items.FindByText(rdr["tanah"].ToString().Trim()));
                                    this.DLternak1.SelectedIndex = this.DLternak1.Items.IndexOf(DLternak1.Items.FindByText(rdr["ternak"].ToString().Trim()));
                                    this.DLmobil1.SelectedIndex = DLmobil1.Items.IndexOf(DLmobil1.Items.FindByText(rdr["mobil"].ToString().Trim()));
                                    this.DLGiro1.SelectedIndex = DLGiro1.Items.IndexOf(DLGiro1.Items.FindByText(rdr["tabungan"].ToString().Trim()));
                                    this.DLPerhiasan1.SelectedIndex = DLPerhiasan1.Items.IndexOf(DLPerhiasan1.Items.FindByText(rdr["hiasan"].ToString().Trim()));
                                    this.DLSepeda1.SelectedIndex = DLSepeda1.Items.IndexOf(DLSepeda1.Items.FindByText(rdr["sepeda"].ToString().Trim()));
                                }

                                this.LbMsgAset1.Text = "Data sudah tesimpan";
                                this.LbMsgAset1.ForeColor = System.Drawing.Color.Green;

                                this.PanelMsg1.Enabled = true;
                                this.PanelMsg1.Visible = true;

                                this.BtnSave1.Enabled = false;
                                this.BtnSave1.Visible = false;

                                this.BtnUpdate1.Enabled = true;
                                this.BtnUpdate1.Visible = true;
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

            //---- GET DATA BARU (BANDING) ----//
            string StrPribadiBanding = "";
            string CS3 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS3))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_harta_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    CekPribadi.CommandType = System.Data.CommandType.Text;
                    CekPribadi.Parameters.AddWithValue("@no_daftar", npm);


                    using (SqlDataReader rdr = CekPribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            StrPribadiBanding = "ada";
                        }
                    }

                    // -----Data Banding Belum ada -----//
                    if (StrPribadiBanding == "")
                    {
                        this.PanelMsg.Enabled = false;
                        this.PanelMsg.Visible = false;

                        this.BtnSave.Enabled = true;
                        this.BtnSave.Visible = true;

                        this.BtnUpdate.Enabled = false;
                        this.BtnUpdate.Visible = false;
                    }
                    else if (StrPribadiBanding == "ada")
                    {
                        // ------ Data Pribadi Banding Ada ---------- //
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_harta_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLSawah.SelectedIndex = this.DLSawah.Items.IndexOf(DLSawah.Items.FindByText(rdr["sawah"].ToString().Trim()));
                                    this.DLTanah.SelectedIndex = DLTanah.Items.IndexOf(DLTanah.Items.FindByText(rdr["tanah"].ToString().Trim()));
                                    this.DLternak.SelectedIndex = this.DLternak.Items.IndexOf(DLternak.Items.FindByText(rdr["ternak"].ToString().Trim()));
                                    this.DLmobil.SelectedIndex = DLmobil.Items.IndexOf(DLmobil.Items.FindByText(rdr["mobil"].ToString().Trim()));
                                    this.DLGiro.SelectedIndex = DLGiro.Items.IndexOf(DLGiro.Items.FindByText(rdr["tabungan"].ToString().Trim()));
                                    this.DLPerhiasan.SelectedIndex = DLPerhiasan.Items.IndexOf(DLPerhiasan.Items.FindByText(rdr["hiasan"].ToString().Trim()));
                                    this.DLSepeda.SelectedIndex = DLSepeda.Items.IndexOf(DLSepeda.Items.FindByText(rdr["sepeda"].ToString().Trim()));
                                }

                                this.LbMsgAset.Text = "Data sudah tesimpan";
                                this.LbMsgAset.ForeColor = System.Drawing.Color.Green;

                                this.PanelMsg.Enabled = true;
                                this.PanelMsg.Visible = true;

                                this.BtnSave.Enabled = false;
                                this.BtnSave.Visible = false;

                                this.BtnUpdate.Enabled = true;
                                this.BtnUpdate.Visible = true;
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

        }

        protected void SaveDataSurveiAset()
        {
            if (this.DLSawah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sawah (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLTanah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tanah,ladang dan kebun (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLternak.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Ternak (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLmobil.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Mobil (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLGiro.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tabungan,giro,deposito');", true);
                return;
            }
            if (this.DLPerhiasan.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Perhiasan');", true);
                return;
            }
            if (this.DLSepeda.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sepeda, sepeda motor (perkiraan harga jual sekarang)');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLSawah.SelectedValue) +
                Convert.ToInt32(DLTanah.SelectedValue) +
                Convert.ToInt32(DLternak.SelectedValue) +
                Convert.ToInt32(DLmobil.SelectedValue) +
                Convert.ToInt32(DLGiro.SelectedValue) +
                Convert.ToInt32(DLPerhiasan.SelectedValue) +
                Convert.ToInt32(DLSepeda.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    //SqlCommand CmdTahun = new SqlCommand("SELECT TOP (1) no, tahun, aktif " +
                    //                                    "FROM            ukt_tahun_aktif " +
                    //                                    "WHERE        (aktif = 'yes') " +
                    //                                    "ORDER BY tahun DESC", con);

                    //CmdTahun.CommandType = System.Data.CommandType.Text;

                    //using (SqlDataReader rdr = CmdTahun.ExecuteReader())
                    //{
                    //    if (rdr.HasRows)
                    //    {
                    //        while (rdr.Read())
                    //        {
                    //            tahun = rdr["tahun"].ToString().Trim();
                    //        }
                    //    }

                    //    rdr.Close();
                    //    rdr.Dispose();
                    //}

                    SqlCommand cmd = new SqlCommand(" INSERT INTO ukt_harta_banding (no_daftar,sawah,tanah,ternak,mobil,tabungan,hiasan,sepeda,nilai,data_banding) " +
                                                    " VALUES (@no_daftar,@sawah,@tanah,@ternak,@mobil,@tabungan,@hiasan,@sepeda,@nilai,@data_banding)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tanah", DLTanah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@ternak", DLternak.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobil", DLmobil.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sepeda", DLSepeda.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@data_banding", "banding");

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void SaveDataLamaAset()
        {
            if (this.DLSawah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sawah (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLTanah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tanah,ladang dan kebun (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLternak1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Ternak (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLmobil1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Mobil (perkiraan harga jual sekarang)');", true);
                return;
            }
            if (this.DLGiro1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tabungan,giro,deposito');", true);
                return;
            }
            if (this.DLPerhiasan1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Perhiasan');", true);
                return;
            }
            if (this.DLSepeda1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sepeda, sepeda motor (perkiraan harga jual sekarang)');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLSawah1.SelectedValue) +
                Convert.ToInt32(DLTanah1.SelectedValue) +
                Convert.ToInt32(DLternak1.SelectedValue) +
                Convert.ToInt32(DLmobil1.SelectedValue) +
                Convert.ToInt32(DLGiro1.SelectedValue) +
                Convert.ToInt32(DLPerhiasan1.SelectedValue) +
                Convert.ToInt32(DLSepeda1.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    //SqlCommand CmdTahun = new SqlCommand("SELECT TOP (1) no, tahun, aktif " +
                    //                                    "FROM            ukt_tahun_aktif " +
                    //                                    "WHERE        (aktif = 'yes') " +
                    //                                    "ORDER BY tahun DESC", con);

                    //CmdTahun.CommandType = System.Data.CommandType.Text;

                    //using (SqlDataReader rdr = CmdTahun.ExecuteReader())
                    //{
                    //    if (rdr.HasRows)
                    //    {
                    //        while (rdr.Read())
                    //        {
                    //            tahun = rdr["tahun"].ToString().Trim();
                    //        }
                    //    }

                    //    rdr.Close();
                    //    rdr.Dispose();
                    //}

                    SqlCommand cmd = new SqlCommand(" INSERT INTO ukt_harta_banding (no_daftar,sawah,tanah,ternak,mobil,tabungan,hiasan,sepeda,nilai,data_banding) " +
                                                    " VALUES (@no_daftar,@sawah,@tanah,@ternak,@mobil,@tabungan,@hiasan,@sepeda,@nilai,@data_banding)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tanah", DLTanah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@ternak", DLternak1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobil", DLmobil1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sepeda", DLSepeda1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@data_banding", "lama");

                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void LoadDataSurveiAset()
        {

            this.DLSawah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTanah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLternak.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLmobil.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLGiro.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPerhiasan.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSepeda.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_harta_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLSawah.SelectedIndex = this.DLSawah.Items.IndexOf(DLSawah.Items.FindByText(rdr["sawah"].ToString().Trim()));
                                this.DLTanah.SelectedIndex = DLTanah.Items.IndexOf(DLTanah.Items.FindByText(rdr["tanah"].ToString().Trim()));
                                this.DLternak.SelectedIndex = this.DLternak.Items.IndexOf(DLternak.Items.FindByText(rdr["ternak"].ToString().Trim()));
                                this.DLmobil.SelectedIndex = DLmobil.Items.IndexOf(DLmobil.Items.FindByText(rdr["mobil"].ToString().Trim()));
                                this.DLGiro.SelectedIndex = DLGiro.Items.IndexOf(DLGiro.Items.FindByText(rdr["tabungan"].ToString().Trim()));
                                this.DLPerhiasan.SelectedIndex = DLPerhiasan.Items.IndexOf(DLPerhiasan.Items.FindByText(rdr["hiasan"].ToString().Trim()));
                                this.DLSepeda.SelectedIndex = DLSepeda.Items.IndexOf(DLSepeda.Items.FindByText(rdr["sepeda"].ToString().Trim()));
                            }

                            this.LbMsgAset.Text = "Data sudah tesimpan";
                            this.LbMsgAset.ForeColor = System.Drawing.Color.Green;

                            this.PanelMsg.Enabled = true;
                            this.PanelMsg.Visible = true;

                            this.BtnSave.Enabled = false;
                            this.BtnSave.Visible = false;

                            this.BtnUpdate.Enabled = true;
                            this.BtnUpdate.Visible = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void LoadDataLamaAset()
        {
            this.DLSawah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTanah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLternak1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLmobil1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLGiro1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPerhiasan1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSepeda1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_harta_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLSawah1.SelectedIndex = this.DLSawah1.Items.IndexOf(DLSawah1.Items.FindByText(rdr["sawah"].ToString().Trim()));
                                this.DLTanah1.SelectedIndex = DLTanah1.Items.IndexOf(DLTanah1.Items.FindByText(rdr["tanah"].ToString().Trim()));
                                this.DLternak1.SelectedIndex = this.DLternak1.Items.IndexOf(DLternak1.Items.FindByText(rdr["ternak"].ToString().Trim()));
                                this.DLmobil1.SelectedIndex = DLmobil1.Items.IndexOf(DLmobil1.Items.FindByText(rdr["mobil"].ToString().Trim()));
                                this.DLGiro1.SelectedIndex = DLGiro1.Items.IndexOf(DLGiro1.Items.FindByText(rdr["tabungan"].ToString().Trim()));
                                this.DLPerhiasan1.SelectedIndex = DLPerhiasan1.Items.IndexOf(DLPerhiasan1.Items.FindByText(rdr["hiasan"].ToString().Trim()));
                                this.DLSepeda1.SelectedIndex = DLSepeda1.Items.IndexOf(DLSepeda1.Items.FindByText(rdr["sepeda"].ToString().Trim()));
                            }

                            this.LbMsgAset1.Text = "Data sudah tesimpan";
                            this.LbMsgAset.ForeColor = System.Drawing.Color.Green;

                            this.PanelMsg1.Enabled = true;
                            this.PanelMsg1.Visible = true;

                            this.BtnSave1.Enabled = false;
                            this.BtnSave1.Visible = false;

                            this.BtnUpdate1.Enabled = true;
                            this.BtnUpdate1.Visible = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        private bool UpdateDataSurveiAset()
        {
            int error = 0;

            if (this.DLSawah.SelectedValue == "-1")
            {
                this.DLSawah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTanah.SelectedValue == "-1")
            {
                this.DLTanah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLternak.SelectedValue == "-1")
            {
                this.DLternak.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLmobil.SelectedValue == "-1")
            {
                this.DLmobil.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLGiro.SelectedValue == "-1")
            {
                this.DLGiro.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPerhiasan.SelectedValue == "-1")
            {
                this.DLPerhiasan.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSepeda.SelectedValue == "-1")
            {
                this.DLSepeda.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLSawah.SelectedValue) +
                Convert.ToInt32(DLTanah.SelectedValue) +
                Convert.ToInt32(DLternak.SelectedValue) +
                Convert.ToInt32(DLmobil.SelectedValue) +
                Convert.ToInt32(DLGiro.SelectedValue) +
                Convert.ToInt32(DLPerhiasan.SelectedValue) +
                Convert.ToInt32(DLSepeda.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    //SqlCommand CmdTahun = new SqlCommand("SELECT TOP (1) no, tahun, aktif " +
                    //                                    "FROM            ukt_tahun_aktif " +
                    //                                    "WHERE        (aktif = 'yes') " +
                    //                                    "ORDER BY tahun DESC", con);

                    //CmdTahun.CommandType = System.Data.CommandType.Text;

                    //using (SqlDataReader rdr = CmdTahun.ExecuteReader())
                    //{
                    //    if (rdr.HasRows)
                    //    {
                    //        while (rdr.Read())
                    //        {
                    //            tahun = rdr["tahun"].ToString().Trim();
                    //        }
                    //    }

                    //    rdr.Close();
                    //    rdr.Dispose();
                    //}

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_harta_banding SET no_daftar=@no_daftar,sawah=@sawah,tanah=@tanah,ternak=@ternak,mobil=@mobil,tabungan=@tabungan,hiasan=@hiasan,sepeda=@sepeda,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tanah", DLTanah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@ternak", DLternak.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobil", DLmobil.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sepeda", DLSepeda.SelectedItem.Text.Trim());
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        private bool UpdateDataLamaAset()
        {
            int error = 0;

            if (this.DLSawah1.SelectedValue == "-1")
            {
                this.DLSawah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTanah1.SelectedValue == "-1")
            {
                this.DLTanah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLternak1.SelectedValue == "-1")
            {
                this.DLternak1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLmobil1.SelectedValue == "-1")
            {
                this.DLmobil1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLGiro1.SelectedValue == "-1")
            {
                this.DLGiro1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPerhiasan1.SelectedValue == "-1")
            {
                this.DLPerhiasan1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSepeda1.SelectedValue == "-1")
            {
                this.DLSepeda1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.BtnUpdate1.Visible = true;
                this.BtnUpdate1.Enabled = true;
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLSawah1.SelectedValue) +
                Convert.ToInt32(DLTanah1.SelectedValue) +
                Convert.ToInt32(DLternak1.SelectedValue) +
                Convert.ToInt32(DLmobil1.SelectedValue) +
                Convert.ToInt32(DLGiro1.SelectedValue) +
                Convert.ToInt32(DLPerhiasan1.SelectedValue) +
                Convert.ToInt32(DLSepeda1.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    //SqlCommand CmdTahun = new SqlCommand("SELECT TOP (1) no, tahun, aktif " +
                    //                                    "FROM            ukt_tahun_aktif " +
                    //                                    "WHERE        (aktif = 'yes') " +
                    //                                    "ORDER BY tahun DESC", con);

                    //CmdTahun.CommandType = System.Data.CommandType.Text;

                    //using (SqlDataReader rdr = CmdTahun.ExecuteReader())
                    //{
                    //    if (rdr.HasRows)
                    //    {
                    //        while (rdr.Read())
                    //        {
                    //            tahun = rdr["tahun"].ToString().Trim();
                    //        }
                    //    }

                    //    rdr.Close();
                    //    rdr.Dispose();
                    //}

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_harta_banding SET no_daftar=@no_daftar,sawah=@sawah,tanah=@tanah,ternak=@ternak,mobil=@mobil,tabungan=@tabungan,hiasan=@hiasan,sepeda=@sepeda,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tanah", DLTanah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@ternak", DLternak1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobil", DLmobil1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sepeda", DLSepeda1.SelectedItem.Text.Trim());
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDataSurveiAset();
            LoadDataSurveiAset();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiAset() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiAset();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaAset();
            LoadDataLamaAset();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaAset() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaAset();
            }
        }
    }
}