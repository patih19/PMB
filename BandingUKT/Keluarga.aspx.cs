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
    public partial class Keluarga : User
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
                    this.GetDataKeluarga(this.Session["NoDaftar"].ToString());
                    //LoadDataSurveiKeluarga();
                }
            }
        }

        protected void GetDataKeluarga(string npm)
        {

            string NoDaftar = "";

            string CS2 = ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS2))
            {
                try
                {
                    // ----- Get No Daftar----- //
                    con.Open();

                    SqlCommand CekPribadi = new SqlCommand("SELECT npm,no_daftar FROM bak_mahasiswa WHERE npm=@npm ", con);
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

            //this.DlStAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLPendidikanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLKerjaanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLModalAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLLabaAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            //this.DLStatausIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLPendidikanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLKerjaanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLModalIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            //this.DLLabaIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            //---- GET DATA LAMA ---//
            string StrKeluarga = "";
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_keluarga_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    CekPribadi.CommandType = System.Data.CommandType.Text;
                    CekPribadi.Parameters.AddWithValue("@no_daftar", npm);

                    using (SqlDataReader rdr = CekPribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            StrKeluarga = "ada";
                        }
                    }

                    // ----- Data Banding Belum Ada -----//
                    if (StrKeluarga == "")
                    {
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_keluarga WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLOrgRumah1.SelectedIndex = DLOrgRumah1.Items.IndexOf(DLOrgRumah1.Items.FindByText(rdr["orgrumah"].ToString().Trim()));
                                    this.DLSdrKandung1.SelectedIndex = DLSdrKandung1.Items.IndexOf(DLSdrKandung1.Items.FindByText(rdr["sdr"].ToString().Trim()));
                                    this.DLSdrKandungKuliah1.SelectedIndex = DLSdrKandungKuliah1.Items.IndexOf(DLSdrKandungKuliah1.Items.FindByText(rdr["sdrkuliah"].ToString().Trim()));
                                    this.DLSdrKandungSekolah1.SelectedIndex = DLSdrKandungSekolah1.Items.IndexOf(DLSdrKandungSekolah1.Items.FindByText(rdr["sdrsekolah"].ToString().Trim()));
                                }

                                //this.LbMsgPribadi1.Text = "Data sudah tesimpan";
                                //this.LbMsgPribadi1.ForeColor = System.Drawing.Color.Green;

                                this.PanelMsg1.Enabled = false;
                                this.PanelMsg1.Visible = false;

                                this.BtnSave1.Enabled = true;
                                this.BtnSave1.Visible = true;

                                this.BtnUpdate1.Enabled = false;
                                this.BtnUpdate1.Visible = false;
                            }
                        }
                    }
                    else if (StrKeluarga == "ada")
                    {
                        // ------ Data Pribadi Banding Ada ---------- //
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_keluarga_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLOrgRumah1.SelectedIndex = DLOrgRumah1.Items.IndexOf(DLOrgRumah1.Items.FindByText(rdr["orgrumah"].ToString().Trim()));
                                    this.DLSdrKandung1.SelectedIndex = DLSdrKandung1.Items.IndexOf(DLSdrKandung1.Items.FindByText(rdr["sdr"].ToString().Trim()));
                                    this.DLSdrKandungKuliah1.SelectedIndex = DLSdrKandungKuliah1.Items.IndexOf(DLSdrKandungKuliah1.Items.FindByText(rdr["sdrkuliah"].ToString().Trim()));
                                    this.DLSdrKandungSekolah1.SelectedIndex = DLSdrKandungSekolah1.Items.IndexOf(DLSdrKandungSekolah1.Items.FindByText(rdr["sdrsekolah"].ToString().Trim()));
                                }

                                this.LbMsgKel1.Text = "Data sudah tesimpan";
                                this.LbMsgKel1.ForeColor = System.Drawing.Color.Green;

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

            //---- GET DATA BARU (BANDING) ---//
            string StrKeluargaBanding = "";
            string CS3 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS3))
            {
                try
                {
                    con.Open();
                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_keluarga_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    CekPribadi.CommandType = System.Data.CommandType.Text;
                    CekPribadi.Parameters.AddWithValue("@no_daftar", npm);


                    using (SqlDataReader rdr = CekPribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            StrKeluargaBanding = "ada";
                        }
                    }

                    // -----Data Banding Belum ada -----//
                    if (StrKeluargaBanding == "")
                    {
                        this.PanelMsg.Enabled = false;
                        this.PanelMsg.Visible = false;

                        this.BtnSave.Enabled = true;
                        this.BtnSave.Visible = true;

                        this.BtnUpdate.Enabled = false;
                        this.BtnUpdate.Visible = false;
                    }
                    else if (StrKeluargaBanding == "ada")
                    {
                        // ------ Data Pribadi Banding Ada ---------- //
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_keluarga_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLOrgRumah1.SelectedIndex = DLOrgRumah1.Items.IndexOf(DLOrgRumah1.Items.FindByText(rdr["orgrumah"].ToString().Trim()));
                                    this.DLSdrKandung1.SelectedIndex = DLSdrKandung1.Items.IndexOf(DLSdrKandung1.Items.FindByText(rdr["sdr"].ToString().Trim()));
                                    this.DLSdrKandungKuliah1.SelectedIndex = DLSdrKandungKuliah1.Items.IndexOf(DLSdrKandungKuliah1.Items.FindByText(rdr["sdrkuliah"].ToString().Trim()));
                                    this.DLSdrKandungSekolah1.SelectedIndex = DLSdrKandungSekolah1.Items.IndexOf(DLSdrKandungSekolah1.Items.FindByText(rdr["sdrsekolah"].ToString().Trim()));
                                }

                                this.LbMsgKel.Text = "Data sudah tesimpan";
                                this.LbMsgKel.ForeColor = System.Drawing.Color.Green;

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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDataSurveiKeluarga();
            LoadDataSurveiKeluarga();
        }

        protected void SaveDataSurveiKeluarga()
        {
            if (this.DLOrgRumah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Orang Serumah');", true);
                return;
            }
            if (this.DLSdrKandung.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Saudara Kandung');", true);
                return;
            }
            if (this.DLSdrKandungKuliah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Saudara Kandung Kuliah');", true);
                return;
            }
            if (this.DLSdrKandungSekolah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Saudara Kandung Sekolah');", true);
                return;
            }


            // Get Nilai 
            int Nilai = Convert.ToInt32(DLOrgRumah.SelectedValue) +
                        Convert.ToInt32(DLSdrKandung.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungKuliah.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungSekolah.SelectedValue);

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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_keluarga_banding (no_daftar,orgrumah,sdr,sdrkuliah,sdrsekolah,nilai,data_banding) VALUES (@no_daftar,@orgrumah,@sdr,@sdrkuliah,@sdrsekolah,@nilai,@data_banding)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@orgrumah", this.DLOrgRumah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdr", this.DLSdrKandung.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrkuliah", this.DLSdrKandungKuliah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrsekolah", this.DLSdrKandungSekolah.SelectedItem.Text.Trim());
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

        protected void SaveDataLamaKeluarga()
        {
            if (this.DLOrgRumah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Orang Serumah');", true);
                return;
            }
            if (this.DLSdrKandung1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Saudara Kandung');", true);
                return;
            }
            if (this.DLSdrKandungKuliah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Saudara Kandung Kuliah');", true);
                return;
            }
            if (this.DLSdrKandungSekolah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Jumlah Saudara Kandung Sekolah');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLOrgRumah1.SelectedValue) +
                        Convert.ToInt32(DLSdrKandung1.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungKuliah1.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungSekolah1.SelectedValue);

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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_keluarga_banding (no_daftar,orgrumah,sdr,sdrkuliah,sdrsekolah,nilai,data_banding) VALUES (@no_daftar,@orgrumah,@sdr,@sdrkuliah,@sdrsekolah,@nilai,@data_banding)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@orgrumah", this.DLOrgRumah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdr", this.DLSdrKandung1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrkuliah", this.DLSdrKandungKuliah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrsekolah", this.DLSdrKandungSekolah1.SelectedItem.Text.Trim());
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

        protected void LoadDataSurveiKeluarga()
        {
            this.DLOrgRumah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSdrKandung.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSdrKandungKuliah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSdrKandungSekolah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");


            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_keluarga_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLOrgRumah.SelectedIndex = DLOrgRumah.Items.IndexOf(DLOrgRumah.Items.FindByText(rdr["orgrumah"].ToString().Trim()));
                                this.DLSdrKandung.SelectedIndex = DLSdrKandung.Items.IndexOf(DLSdrKandung.Items.FindByText(rdr["sdr"].ToString().Trim()));
                                this.DLSdrKandungKuliah.SelectedIndex = DLSdrKandungKuliah.Items.IndexOf(DLSdrKandungKuliah.Items.FindByText(rdr["sdrkuliah"].ToString().Trim()));
                                this.DLSdrKandungSekolah.SelectedIndex = DLSdrKandungSekolah.Items.IndexOf(DLSdrKandungSekolah.Items.FindByText(rdr["sdrsekolah"].ToString().Trim()));
                            }

                            this.LbMsgKel.Text = "Data sudah tesimpan";
                            this.LbMsgKel.ForeColor = System.Drawing.Color.Green;

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

        protected void LoadDataLamaKeluarga()
        {
            this.DLOrgRumah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSdrKandung1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSdrKandungKuliah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSdrKandungSekolah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");


            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_keluarga_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {

                                this.DLOrgRumah1.SelectedIndex = DLOrgRumah1.Items.IndexOf(DLOrgRumah1.Items.FindByText(rdr["orgrumah"].ToString().Trim()));
                                this.DLSdrKandung1.SelectedIndex = DLSdrKandung1.Items.IndexOf(DLSdrKandung1.Items.FindByText(rdr["sdr"].ToString().Trim()));
                                this.DLSdrKandungKuliah1.SelectedIndex = DLSdrKandungKuliah1.Items.IndexOf(DLSdrKandungKuliah1.Items.FindByText(rdr["sdrkuliah"].ToString().Trim()));
                                this.DLSdrKandungSekolah1.SelectedIndex = DLSdrKandungSekolah1.Items.IndexOf(DLSdrKandungSekolah1.Items.FindByText(rdr["sdrsekolah"].ToString().Trim()));
                            }

                            this.LbMsgKel1.Text = "Data sudah tersimpan";

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

        private bool UpdateDataSurveiKeluarga()
        {
            int error = 0;

            if (this.DLOrgRumah.SelectedValue == "-1")
            {
                this.DLOrgRumah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSdrKandung.SelectedValue == "-1")
            {
                this.DLSdrKandung.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSdrKandungKuliah.SelectedValue == "-1")
            {
                this.DLSdrKandungKuliah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSdrKandungSekolah.SelectedValue == "-1")
            {
                this.DLSdrKandungSekolah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;

                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLOrgRumah.SelectedValue) +
                        Convert.ToInt32(DLSdrKandung.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungKuliah.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungSekolah.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_keluarga_banding SET orgrumah=@orgrumah,sdr=@sdr, sdrkuliah=@sdrkuliah,sdrsekolah=@sdrsekolah,nilai= @nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@orgrumah", this.DLOrgRumah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdr", this.DLSdrKandung.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrkuliah", this.DLSdrKandungKuliah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrsekolah", this.DLSdrKandungSekolah.SelectedItem.Text.Trim());
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        private bool UpdateDataLamaKeluarga()
        {
            int error = 0;

            if (this.DLOrgRumah1.SelectedValue == "-1")
            {
                this.DLOrgRumah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSdrKandung1.SelectedValue == "-1")
            {
                this.DLSdrKandung1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSdrKandungKuliah1.SelectedValue == "-1")
            {
                this.DLSdrKandungKuliah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSdrKandungSekolah1.SelectedValue == "-1")
            {
                this.DLSdrKandungSekolah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate1.Visible = true;
                this.BtnUpdate1.Enabled = true;

                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLOrgRumah1.SelectedValue) +
                        Convert.ToInt32(DLSdrKandung1.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungKuliah1.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungSekolah1.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_keluarga_banding SET orgrumah=@orgrumah,sdr=@sdr, sdrkuliah=@sdrkuliah,sdrsekolah=@sdrsekolah,nilai= @nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@orgrumah", this.DLOrgRumah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdr", this.DLSdrKandung1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrkuliah", this.DLSdrKandungKuliah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrsekolah", this.DLSdrKandungSekolah1.SelectedItem.Text.Trim());
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiKeluarga() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiKeluarga();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaKeluarga();
            LoadDataLamaKeluarga();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaKeluarga() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaKeluarga();
            }
        }

    }
}