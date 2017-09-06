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
    public partial class Perabot : User
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
                    this.GetDataPerabot(this.Session["NoDaftar"].ToString());
                }
            }
        }

        protected void GetDataPerabot(string npm)
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
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_perabot_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_perabot WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.DLBeliMKTamu1.SelectedIndex = this.DLBeliMKTamu1.Items.IndexOf(DLBeliMKTamu1.Items.FindByText(rdr["hrmjtamu"].ToString().Trim()));
                                    this.DLAlmariBft1. SelectedIndex = DLAlmariBft1.Items.IndexOf(DLAlmariBft1.Items.FindByText(rdr["hralmari"].ToString().Trim()));
                                    this.DLMKRuangTengah1. SelectedIndex = DLMKRuangTengah1.Items.IndexOf(DLMKRuangTengah1.Items.FindByText(rdr["hrmjtengah"].ToString().Trim()));
                                    this.DLMKRuangMakan1.SelectedIndex = DLMKRuangMakan1.Items.IndexOf(DLMKRuangMakan1.Items.FindByText(rdr["hrmjmakan"].ToString().Trim()));
                                    this.DLMKRuangTeras1.SelectedIndex = DLMKRuangTeras1.Items.IndexOf(DLMKRuangTeras1.Items.FindByText(rdr["hrnjteras"].ToString().Trim()));
                                    this.DLTmpTidur1.SelectedIndex = DLTmpTidur1.Items.IndexOf(DLTmpTidur1.Items.FindByText(rdr["hrtmtidur"].ToString().Trim()));
                                    this.DLTV1.SelectedIndex = DLTV1.Items.IndexOf(DLTV1.Items.FindByText(rdr["hrtv"].ToString()));
                                    this.DLKomp1.SelectedIndex = DLKomp1.Items.IndexOf(DLKomp1.Items.FindByText(rdr["hrkomp"].ToString().Trim()));
                                    this.DLPerabotDapur1.SelectedIndex = DLPerabotDapur1.Items.IndexOf(DLPerabotDapur1.Items.FindByText(rdr["hrdapur"].ToString().Trim()));
                                    this.DLMejaRias1.SelectedIndex = DLMejaRias1.Items.IndexOf(DLMejaRias1.Items.FindByText(rdr["hrmjrias"].ToString().Trim()));
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_perabot_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");
                                    this.DLBeliMKTamu1.SelectedIndex = this.DLBeliMKTamu1.Items.IndexOf(DLBeliMKTamu1.Items.FindByText(rdr["hrmjtamu"].ToString().Trim()));
                                    this.DLAlmariBft1.SelectedIndex = DLAlmariBft1.Items.IndexOf(DLAlmariBft1.Items.FindByText(rdr["hralmari"].ToString().Trim()));
                                    this.DLMKRuangTengah1.SelectedIndex = DLMKRuangTengah1.Items.IndexOf(DLMKRuangTengah1.Items.FindByText(rdr["hrmjtengah"].ToString().Trim()));
                                    this.DLMKRuangMakan1.SelectedIndex = DLMKRuangMakan1.Items.IndexOf(DLMKRuangMakan1.Items.FindByText(rdr["hrmjmakan"].ToString().Trim()));
                                    this.DLMKRuangTeras1.SelectedIndex = DLMKRuangTeras1.Items.IndexOf(DLMKRuangTeras1.Items.FindByText(rdr["hrnjteras"].ToString().Trim()));
                                    this.DLTmpTidur1.SelectedIndex = DLTmpTidur1.Items.IndexOf(DLTmpTidur1.Items.FindByText(rdr["hrtmtidur"].ToString().Trim()));
                                    this.DLTV1.SelectedIndex = DLTV1.Items.IndexOf(DLTV1.Items.FindByText(rdr["hrtv"].ToString()));
                                    this.DLKomp1.SelectedIndex = DLKomp1.Items.IndexOf(DLKomp1.Items.FindByText(rdr["hrkomp"].ToString().Trim()));
                                    this.DLPerabotDapur1.SelectedIndex = DLPerabotDapur1.Items.IndexOf(DLPerabotDapur1.Items.FindByText(rdr["hrdapur"].ToString().Trim()));
                                    this.DLMejaRias1.SelectedIndex = DLMejaRias1.Items.IndexOf(DLMejaRias1.Items.FindByText(rdr["hrmjrias"].ToString().Trim()));

                                }

                                this.LbMsgPerabot1.Text = "Data sudah tesimpan";
                                this.LbMsgPerabot1.ForeColor = System.Drawing.Color.Green;

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
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_perabot_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_perabot_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");
                                    this.DLBeliMKTamu.SelectedIndex = this.DLBeliMKTamu.Items.IndexOf(DLBeliMKTamu.Items.FindByText(rdr["hrmjtamu"].ToString().Trim()));
                                    this.DLAlmariBft.SelectedIndex = DLAlmariBft.Items.IndexOf(DLAlmariBft.Items.FindByText(rdr["hralmari"].ToString().Trim()));
                                    this.DLMKRuangTengah.SelectedIndex = DLMKRuangTengah.Items.IndexOf(DLMKRuangTengah.Items.FindByText(rdr["hrmjtengah"].ToString().Trim()));
                                    this.DLMKRuangMakan.SelectedIndex = DLMKRuangMakan.Items.IndexOf(DLMKRuangMakan.Items.FindByText(rdr["hrmjmakan"].ToString().Trim()));
                                    this.DLMKRuangTeras.SelectedIndex = DLMKRuangTeras.Items.IndexOf(DLMKRuangTeras.Items.FindByText(rdr["hrnjteras"].ToString().Trim()));
                                    this.DLTmpTidur.SelectedIndex = DLTmpTidur.Items.IndexOf(DLTmpTidur.Items.FindByText(rdr["hrtmtidur"].ToString().Trim()));
                                    this.DLTV.SelectedIndex = DLTV.Items.IndexOf(DLTV.Items.FindByText(rdr["hrtv"].ToString()));
                                    this.DLKomp.SelectedIndex = DLKomp.Items.IndexOf(DLKomp.Items.FindByText(rdr["hrkomp"].ToString().Trim()));
                                    this.DLPerabotDapur.SelectedIndex = DLPerabotDapur.Items.IndexOf(DLPerabotDapur.Items.FindByText(rdr["hrdapur"].ToString().Trim()));
                                    this.DLMejaRias.SelectedIndex = DLMejaRias.Items.IndexOf(DLMejaRias.Items.FindByText(rdr["hrmjrias"].ToString().Trim()));
                                }

                                this.LbMsgPerabot.Text = "Data sudah tesimpan";
                                this.LbMsgPerabot.ForeColor = System.Drawing.Color.Green;

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

        protected void SaveDataSurveiPerabot()
        {
            if (this.DLBeliMKTamu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi harga beli meja kursi ruang tamu');", true);
                return;
            }
            if (this.DLAlmariBft.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli almari bifet dan sejenisnya');", true);
                return;
            }
            if (this.DLMKRuangTengah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja kursi ruang tengah/keluarga');", true);
                return;
            }
            if (this.DLMKRuangMakan.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja kursi ruang makan');", true);
                return;
            }
            if (this.DLMKRuangTeras.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja kursi ruang teras');", true);
                return;
            }
            if (this.DLTmpTidur.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli tempat tidur');", true);
                return;
            }
            if (this.DLTV.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli televisi');", true);
                return;
            }
            if (this.DLKomp.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli keseluruhan komputer, laptop dan printer');", true);
                return;
            }
            if (this.DLPerabotDapur.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi >Harga beli keseluruhan gas,oven & perabot dapur');", true);
                return;
            }
            if (this.DLMejaRias.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja rias');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLBeliMKTamu.SelectedValue) +
            Convert.ToInt32(DLAlmariBft.SelectedValue) +
            Convert.ToInt32(DLMKRuangTengah.SelectedValue) +
            Convert.ToInt32(DLMKRuangMakan.SelectedValue) +
            Convert.ToInt32(DLMKRuangTeras.SelectedValue) +
            Convert.ToInt32(DLTmpTidur.SelectedValue) +
            Convert.ToInt32(DLTV.SelectedValue) +
            Convert.ToInt32(DLKomp.SelectedValue) +
            Convert.ToInt32(DLPerabotDapur.SelectedValue) +
            Convert.ToInt32(DLMejaRias.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_perabot_banding (no_daftar,hrmjtamu,hralmari,hrmjtengah,hrmjmakan,hrnjteras,hrtmtidur,hrtv,hrkomp,hrdapur,hrmjrias,nilai,data_banding) " +
                                                    "VALUES (@no_daftar,@hrmjtamu,@hralmari,@hrmjtengah,@hrmjmakan,@hrnjteras,@hrtmtidur,@hrtv,@hrkomp,@hrdapur,@hrmjrias,@nilai,@data_banding) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@hrmjtamu", DLBeliMKTamu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hralmari", DLAlmariBft.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjtengah", DLMKRuangTengah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjmakan", DLMKRuangMakan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrnjteras", DLMKRuangTeras.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtmtidur", DLTmpTidur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtv", DLTV.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrkomp", DLKomp.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrdapur", DLPerabotDapur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjrias", DLMejaRias.SelectedItem.Text);
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

        protected void SaveDataLamaPerabot()
        {
            if (this.DLBeliMKTamu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi harga beli meja kursi ruang tamu');", true);
                return;
            }
            if (this.DLAlmariBft1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli almari bifet dan sejenisnya');", true);
                return;
            }
            if (this.DLMKRuangTengah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja kursi ruang tengah/keluarga');", true);
                return;
            }
            if (this.DLMKRuangMakan1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja kursi ruang makan');", true);
                return;
            }
            if (this.DLMKRuangTeras1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja kursi ruang teras');", true);
                return;
            }
            if (this.DLTmpTidur1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli tempat tidur');", true);
                return;
            }
            if (this.DLTV1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli televisi');", true);
                return;
            }
            if (this.DLKomp1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli keseluruhan komputer, laptop dan printer');", true);
                return;
            }
            if (this.DLPerabotDapur1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi >Harga beli keseluruhan gas,oven & perabot dapur');", true);
                return;
            }
            if (this.DLMejaRias1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Harga beli meja rias');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLBeliMKTamu1.SelectedValue) +
            Convert.ToInt32(DLAlmariBft1.SelectedValue) +
            Convert.ToInt32(DLMKRuangTengah1.SelectedValue) +
            Convert.ToInt32(DLMKRuangMakan1.SelectedValue) +
            Convert.ToInt32(DLMKRuangTeras1.SelectedValue) +
            Convert.ToInt32(DLTmpTidur1.SelectedValue) +
            Convert.ToInt32(DLTV1.SelectedValue) +
            Convert.ToInt32(DLKomp1.SelectedValue) +
            Convert.ToInt32(DLPerabotDapur1.SelectedValue) +
            Convert.ToInt32(DLMejaRias1.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_perabot_banding (no_daftar,hrmjtamu,hralmari,hrmjtengah,hrmjmakan,hrnjteras,hrtmtidur,hrtv,hrkomp,hrdapur,hrmjrias,nilai,data_banding) " +
                                                    "VALUES (@no_daftar,@hrmjtamu,@hralmari,@hrmjtengah,@hrmjmakan,@hrnjteras,@hrtmtidur,@hrtv,@hrkomp,@hrdapur,@hrmjrias,@nilai,@data_banding) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@hrmjtamu", DLBeliMKTamu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hralmari", DLAlmariBft1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjtengah", DLMKRuangTengah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjmakan", DLMKRuangMakan1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrnjteras", DLMKRuangTeras1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtmtidur", DLTmpTidur1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtv", DLTV1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrkomp", DLKomp1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrdapur", DLPerabotDapur1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjrias", DLMejaRias1.SelectedItem.Text);
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

        protected void LoadDataSurveiPerabot()
        {
            this.DLBeliMKTamu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLAlmariBft.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMKRuangTengah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMKRuangMakan.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMKRuangTeras.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTmpTidur.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTV.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKomp.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPerabotDapur.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMejaRias.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");


            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_perabot_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {

                                this.DLBeliMKTamu.SelectedIndex = this.DLBeliMKTamu.Items.IndexOf(DLBeliMKTamu.Items.FindByText(rdr["hrmjtamu"].ToString().Trim()));
                                this.DLAlmariBft.SelectedIndex = DLAlmariBft.Items.IndexOf(DLAlmariBft.Items.FindByText(rdr["hralmari"].ToString().Trim()));
                                this.DLMKRuangTengah.SelectedIndex = DLMKRuangTengah.Items.IndexOf(DLMKRuangTengah.Items.FindByText(rdr["hrmjtengah"].ToString().Trim()));
                                this.DLMKRuangMakan.SelectedIndex = DLMKRuangMakan.Items.IndexOf(DLMKRuangMakan.Items.FindByText(rdr["hrmjmakan"].ToString().Trim()));
                                this.DLMKRuangTeras.SelectedIndex = DLMKRuangTeras.Items.IndexOf(DLMKRuangTeras.Items.FindByText(rdr["hrnjteras"].ToString().Trim()));
                                this.DLTmpTidur.SelectedIndex = DLTmpTidur.Items.IndexOf(DLTmpTidur.Items.FindByText(rdr["hrtmtidur"].ToString().Trim()));
                                this.DLTV.SelectedIndex = DLTV.Items.IndexOf(DLTV.Items.FindByText(rdr["hrtv"].ToString().Trim()));
                                this.DLKomp.SelectedIndex = DLKomp.Items.IndexOf(DLKomp.Items.FindByText(rdr["hrkomp"].ToString().Trim()));
                                this.DLPerabotDapur.SelectedIndex = DLPerabotDapur.Items.IndexOf(DLPerabotDapur.Items.FindByText(rdr["hrdapur"].ToString().Trim()));
                                this.DLMejaRias.SelectedIndex = DLMejaRias.Items.IndexOf(DLMejaRias.Items.FindByText(rdr["hrmjrias"].ToString().Trim()));
                            }


                            this.LbMsgPerabot.Text = "Data sudah tesimpan";
                            this.LbMsgPerabot.ForeColor = System.Drawing.Color.Green;

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

        protected void LoadDataLamaPerabot()
        {
            this.DLBeliMKTamu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLAlmariBft1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMKRuangTengah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMKRuangMakan1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMKRuangTeras1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTmpTidur1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTV1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKomp1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPerabotDapur1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLMejaRias1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");


            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_perabot_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLBeliMKTamu1.SelectedIndex = this.DLBeliMKTamu1.Items.IndexOf(DLBeliMKTamu1.Items.FindByText(rdr["hrmjtamu"].ToString().Trim()));
                                this.DLAlmariBft1.SelectedIndex = DLAlmariBft1.Items.IndexOf(DLAlmariBft1.Items.FindByText(rdr["hralmari"].ToString().Trim()));
                                this.DLMKRuangTengah1.SelectedIndex = DLMKRuangTengah1.Items.IndexOf(DLMKRuangTengah1.Items.FindByText(rdr["hrmjtengah"].ToString().Trim()));
                                this.DLMKRuangMakan1.SelectedIndex = DLMKRuangMakan1.Items.IndexOf(DLMKRuangMakan1.Items.FindByText(rdr["hrmjmakan"].ToString().Trim()));
                                this.DLMKRuangTeras1.SelectedIndex = DLMKRuangTeras1.Items.IndexOf(DLMKRuangTeras1.Items.FindByText(rdr["hrnjteras"].ToString().Trim()));
                                this.DLTmpTidur1.SelectedIndex = DLTmpTidur1.Items.IndexOf(DLTmpTidur1.Items.FindByText(rdr["hrtmtidur"].ToString().Trim()));
                                this.DLTV1.SelectedIndex = DLTV1.Items.IndexOf(DLTV1.Items.FindByText(rdr["hrtv"].ToString()));
                                this.DLKomp1.SelectedIndex = DLKomp1.Items.IndexOf(DLKomp1.Items.FindByText(rdr["hrkomp"].ToString().Trim()));
                                this.DLPerabotDapur1.SelectedIndex = DLPerabotDapur1.Items.IndexOf(DLPerabotDapur1.Items.FindByText(rdr["hrdapur"].ToString().Trim()));
                                this.DLMejaRias1.SelectedIndex = DLMejaRias1.Items.IndexOf(DLMejaRias1.Items.FindByText(rdr["hrmjrias"].ToString().Trim()));

                            }


                            this.LbMsgPerabot1.Text = "Data sudah tesimpan";
                            this.LbMsgPerabot1.ForeColor = System.Drawing.Color.Green;

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

        private bool UpdateDataSurveiPerabot()
        {

            int error = 0;

            if (this.DLBeliMKTamu.SelectedValue == "-1")
            {
                this.DLBeliMKTamu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLAlmariBft.SelectedValue == "-1")
            {
                this.DLAlmariBft.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMKRuangTengah.SelectedValue == "-1")
            {
                this.DLMKRuangTengah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMKRuangMakan.SelectedValue == "-1")
            {
                this.DLMKRuangMakan.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMKRuangTeras.SelectedValue == "-1")
            {
                this.DLMKRuangTeras.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTmpTidur.SelectedValue == "-1")
            {
                this.DLTmpTidur.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTV.SelectedValue == "-1")
            {
                this.DLTV.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKomp.SelectedValue == "-1")
            {
                this.DLKomp.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPerabotDapur.SelectedValue == "-1")
            {
                this.DLPerabotDapur.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMejaRias.SelectedValue == "-1")
            {
                this.DLMejaRias.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;

                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLBeliMKTamu.SelectedValue) +
            Convert.ToInt32(DLAlmariBft.SelectedValue) +
            Convert.ToInt32(DLMKRuangTengah.SelectedValue) +
            Convert.ToInt32(DLMKRuangMakan.SelectedValue) +
            Convert.ToInt32(DLMKRuangTeras.SelectedValue) +
            Convert.ToInt32(DLTmpTidur.SelectedValue) +
            Convert.ToInt32(DLTV.SelectedValue) +
            Convert.ToInt32(DLKomp.SelectedValue) +
            Convert.ToInt32(DLPerabotDapur.SelectedValue) +
            Convert.ToInt32(DLMejaRias.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_perabot_banding SET hrmjtamu=@hrmjtamu,hralmari=@hralmari,hrmjtengah=@hrmjtengah,hrmjmakan=@hrmjmakan,hrnjteras=@hrnjteras,hrtmtidur=@hrtmtidur,hrtv=@hrtv,hrkomp=@hrkomp,hrdapur=@hrdapur,hrmjrias=@hrmjrias,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@hrmjtamu", DLBeliMKTamu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hralmari", DLAlmariBft.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjtengah", DLMKRuangTengah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjmakan", DLMKRuangMakan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrnjteras", DLMKRuangTeras.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtmtidur", DLTmpTidur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtv", DLTV.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrkomp", DLKomp.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrdapur", DLPerabotDapur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjrias", DLMejaRias.SelectedItem.Text);
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

        private bool UpdateDataLamaPerabot()
        {

            int error = 0;

            if (this.DLBeliMKTamu1.SelectedValue == "-1")
            {
                this.DLBeliMKTamu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLAlmariBft1.SelectedValue == "-1")
            {
                this.DLAlmariBft1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMKRuangTengah1.SelectedValue == "-1")
            {
                this.DLMKRuangTengah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMKRuangMakan1.SelectedValue == "-1")
            {
                this.DLMKRuangMakan1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMKRuangTeras1.SelectedValue == "-1")
            {
                this.DLMKRuangTeras1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTmpTidur1.SelectedValue == "-1")
            {
                this.DLTmpTidur1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTV1.SelectedValue == "-1")
            {
                this.DLTV1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKomp1.SelectedValue == "-1")
            {
                this.DLKomp1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPerabotDapur1.SelectedValue == "-1")
            {
                this.DLPerabotDapur1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLMejaRias1.SelectedValue == "-1")
            {
                this.DLMejaRias1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate1.Visible = true;
                this.BtnUpdate1.Enabled = true;

                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLBeliMKTamu1.SelectedValue) +
            Convert.ToInt32(DLAlmariBft1.SelectedValue) +
            Convert.ToInt32(DLMKRuangTengah1.SelectedValue) +
            Convert.ToInt32(DLMKRuangMakan1.SelectedValue) +
            Convert.ToInt32(DLMKRuangTeras1.SelectedValue) +
            Convert.ToInt32(DLTmpTidur1.SelectedValue) +
            Convert.ToInt32(DLTV1.SelectedValue) +
            Convert.ToInt32(DLKomp1.SelectedValue) +
            Convert.ToInt32(DLPerabotDapur1.SelectedValue) +
            Convert.ToInt32(DLMejaRias1.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_perabot_banding SET hrmjtamu=@hrmjtamu,hralmari=@hralmari,hrmjtengah=@hrmjtengah,hrmjmakan=@hrmjmakan,hrnjteras=@hrnjteras,hrtmtidur=@hrtmtidur,hrtv=@hrtv,hrkomp=@hrkomp,hrdapur=@hrdapur,hrmjrias=@hrmjrias,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@hrmjtamu", DLBeliMKTamu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hralmari", DLAlmariBft1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjtengah", DLMKRuangTengah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjmakan", DLMKRuangMakan1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrnjteras", DLMKRuangTeras1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtmtidur", DLTmpTidur1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtv", DLTV1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrkomp", DLKomp1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrdapur", DLPerabotDapur1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjrias", DLMejaRias1.SelectedItem.Text);
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
            SaveDataSurveiPerabot();
            LoadDataSurveiPerabot();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiPerabot() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiPerabot();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaPerabot();
            LoadDataLamaPerabot();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaPerabot() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaPerabot();
            }
        }
    }
}