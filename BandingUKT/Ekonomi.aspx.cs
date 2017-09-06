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
    public partial class Ekonomi : User
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
                    this.GetDataEkonomi(this.Session["NoDaftar"].ToString());
                }
            }
        }

        protected void GetDataEkonomi(string npm)
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
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_ekonomi_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_ekonomi WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.DLPendapatanAyah.SelectedIndex = this.DLPendapatanAyah.Items.IndexOf(DLPendapatanAyah.Items.FindByText(rdr["pdptayah"].ToString().Trim()));
                                    this.DLPendapatanIbu.SelectedIndex = DLPendapatanIbu.Items.IndexOf(DLPendapatanIbu.Items.FindByText(rdr["pdptibu"].ToString().Trim()));
                                    this.DLHutang.SelectedIndex = this.DLHutang.Items.IndexOf(DLHutang.Items.FindByText(rdr["htng"].ToString().Trim()));
                                    this.DlCicilan.SelectedIndex = DlCicilan.Items.IndexOf(DlCicilan.Items.FindByText(rdr["cicilan"].ToString().Trim()));
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_ekonomi_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLPendapatanAyah1.SelectedIndex = this.DLPendapatanAyah1.Items.IndexOf(DLPendapatanAyah1.Items.FindByText(rdr["pdptayah"].ToString().Trim()));
                                    this.DLPendapatanIbu1.SelectedIndex = DLPendapatanIbu1.Items.IndexOf(DLPendapatanIbu1.Items.FindByText(rdr["pdptibu"].ToString().Trim()));
                                    this.DLHutang1.SelectedIndex = this.DLHutang1.Items.IndexOf(DLHutang1.Items.FindByText(rdr["htng"].ToString().Trim()));
                                    this.DlCicilan1.SelectedIndex = DlCicilan1.Items.IndexOf(DlCicilan1.Items.FindByText(rdr["cicilan"].ToString().Trim()));
                                }

                                this.LbMsgEkonomi1.Text = "Data sudah tesimpan";
                                this.LbMsgEkonomi1.ForeColor = System.Drawing.Color.Green;

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
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_ekonomi_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_ekonomi_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLPendapatanAyah.SelectedIndex = this.DLPendapatanAyah.Items.IndexOf(DLPendapatanAyah.Items.FindByText(rdr["pdptayah"].ToString().Trim()));
                                    this.DLPendapatanIbu.SelectedIndex = DLPendapatanIbu.Items.IndexOf(DLPendapatanIbu.Items.FindByText(rdr["pdptibu"].ToString().Trim()));
                                    this.DLHutang.SelectedIndex = this.DLHutang.Items.IndexOf(DLHutang.Items.FindByText(rdr["htng"].ToString().Trim()));
                                    this.DlCicilan.SelectedIndex = DlCicilan.Items.IndexOf(DlCicilan.Items.FindByText(rdr["cicilan"].ToString().Trim()));
                                }

                                this.LbMsgEkonomi.Text = "Data sudah tesimpan";
                                this.LbMsgEkonomi.ForeColor = System.Drawing.Color.Green;

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

        protected void SaveDataSurveiEkonomi()
        {
            if (this.DLPendapatanAyah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata total pendapatan ayah/wali');", true);
                return;
            }
            if (this.DLPendapatanIbu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata total pendapatan ibu/wali');", true);
                return;
            }
            if (this.DLHutang.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Total hutang kelurga');", true);
                return;
            }
            if (this.DlCicilan.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Cicilan hutang per bulan');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendapatanAyah.SelectedValue) +
                Convert.ToInt32(DLPendapatanIbu.SelectedValue) +
                Convert.ToInt32(DLHutang.SelectedValue) +
                Convert.ToInt32(DlCicilan.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into ukt_ekonomi_banding (no_daftar,pdptayah,pdptibu,htng,cicilan,nilai,data_banding) values (@no_daftar,@pdptayah,@pdptibu,@htng,@cicilan,@nilai,@data_banding) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@htng", DLHutang.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan.SelectedItem.Text.Trim());
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

        protected void SaveDataLamaEkonomi()
        {
            if (this.DLPendapatanAyah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata total pendapatan ayah/wali');", true);
                return;
            }
            if (this.DLPendapatanIbu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata total pendapatan ibu/wali');", true);
                return;
            }
            if (this.DLHutang1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Total hutang kelurga');", true);
                return;
            }
            if (this.DlCicilan1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Cicilan hutang per bulan');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendapatanAyah1.SelectedValue) +
                Convert.ToInt32(DLPendapatanIbu1.SelectedValue) +
                Convert.ToInt32(DLHutang1.SelectedValue) +
                Convert.ToInt32(DlCicilan1.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("insert into ukt_ekonomi_banding (no_daftar,pdptayah,pdptibu,htng,cicilan,nilai,data_banding) values (@no_daftar,@pdptayah,@pdptibu,@htng,@cicilan,@nilai,@data_banding) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@htng", DLHutang1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan1.SelectedItem.Text.Trim());
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

        protected void LoadDataSurveiEkonomi()
        {
            this.DlCicilan.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLHutang.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendapatanAyah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendapatanIbu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_ekonomi_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLPendapatanAyah.SelectedIndex = this.DLPendapatanAyah.Items.IndexOf(DLPendapatanAyah.Items.FindByText(rdr["pdptayah"].ToString().Trim()));
                                this.DLPendapatanIbu.SelectedIndex = DLPendapatanIbu.Items.IndexOf(DLPendapatanIbu.Items.FindByText(rdr["pdptibu"].ToString().Trim()));
                                this.DLHutang.SelectedIndex = this.DLHutang.Items.IndexOf(DLHutang.Items.FindByText(rdr["htng"].ToString().Trim()));
                                this.DlCicilan.SelectedIndex = DlCicilan.Items.IndexOf(DlCicilan.Items.FindByText(rdr["cicilan"].ToString().Trim()));
                            }

                            this.LbMsgEkonomi.Text = "Data sudah tesimpan";
                            this.LbMsgEkonomi.ForeColor = System.Drawing.Color.Green;

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

        protected void LoadDataLamaEkonomi()
        {
            this.DlCicilan1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLHutang1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendapatanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendapatanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_ekonomi_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLPendapatanAyah1.SelectedIndex = this.DLPendapatanAyah1.Items.IndexOf(DLPendapatanAyah1.Items.FindByText(rdr["pdptayah"].ToString().Trim()));
                                this.DLPendapatanIbu1.SelectedIndex = DLPendapatanIbu1.Items.IndexOf(DLPendapatanIbu1.Items.FindByText(rdr["pdptibu"].ToString().Trim()));
                                this.DLHutang1.SelectedIndex = this.DLHutang1.Items.IndexOf(DLHutang1.Items.FindByText(rdr["htng"].ToString().Trim()));
                                this.DlCicilan1.SelectedIndex = DlCicilan1.Items.IndexOf(DlCicilan1.Items.FindByText(rdr["cicilan"].ToString().Trim()));
                            }

                            this.LbMsgEkonomi1.Text = "Data sudah tesimpan";
                            this.LbMsgEkonomi1.ForeColor = System.Drawing.Color.Green;

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

        private bool UpdateDataSurveiEkonomi()
        {
            int error = 0;

            if (this.DLPendapatanAyah.SelectedValue == "-1")
            {
                this.DLPendapatanAyah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPendapatanIbu.SelectedValue == "-1")
            {
                this.DLPendapatanIbu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLHutang.SelectedValue == "-1")
            {
                this.DLHutang.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DlCicilan.SelectedValue == "-1")
            {
                this.DlCicilan.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;

                //Response.Write("return");
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendapatanAyah.SelectedValue) +
                Convert.ToInt32(DLPendapatanIbu.SelectedValue) +
                Convert.ToInt32(DLHutang.SelectedValue) +
                Convert.ToInt32(DlCicilan.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_ekonomi_banding SET pdptayah=@pdptayah,pdptibu=@pdptibu,htng=@htng,cicilan=@cicilan,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@htng", DLHutang.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan.SelectedItem.Text.Trim());

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

        private bool UpdateDataLamaEkonomi()
        {
            int error = 0;

            if (this.DLPendapatanAyah1.SelectedValue == "-1")
            {
                this.DLPendapatanAyah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPendapatanIbu1.SelectedValue == "-1")
            {
                this.DLPendapatanIbu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLHutang1.SelectedValue == "-1")
            {
                this.DLHutang1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DlCicilan1.SelectedValue == "-1")
            {
                this.DlCicilan1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.BtnUpdate1.Visible = true;
                this.BtnUpdate1.Enabled = true;

                //Response.Write("return");
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendapatanAyah1.SelectedValue) +
                Convert.ToInt32(DLPendapatanIbu1.SelectedValue) +
                Convert.ToInt32(DLHutang1.SelectedValue) +
                Convert.ToInt32(DlCicilan1.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_ekonomi_banding SET pdptayah=@pdptayah,pdptibu=@pdptibu,htng=@htng,cicilan=@cicilan,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@htng", DLHutang1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan1.SelectedItem.Text.Trim());

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
            SaveDataSurveiEkonomi();
            LoadDataSurveiEkonomi();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiEkonomi() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiEkonomi();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaEkonomi();
            LoadDataLamaEkonomi();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaEkonomi() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaEkonomi();
            }
        }

    }
}