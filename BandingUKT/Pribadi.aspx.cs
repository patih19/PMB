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
    public partial class Pribadi : User
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
                    this.GetDataPribadi(base.Request.QueryString["npm"].ToString().Trim());
                    this.Session["NoDaftar"] = base.Request.QueryString["npm"].ToString().Trim();
                    //LoadDataSurveiPribadi();
                }
                else if (string.IsNullOrEmpty(base.Request.QueryString["npm"]))
                {
                    this.GetDataPribadi(this.Session["NoDaftar"].ToString());
                   //LoadDataSurveiPribadi();
                }
                else
                {
                    this.Session["NoDaftar"] = null;
                    this.Session.Remove("NoDaftar");
                    this.Session["NoDaftar"] = base.Request.QueryString["npm"].ToString().Trim();
                    this.GetDataPribadi(this.Session["NoDaftar"].ToString());
                    //LoadDataSurveiPribadi();
                }
                //Response.Write(this.Session["NoDaftar"].ToString());
            }
        }

        protected void GetDataPribadi(string npm)
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
                catch (Exception )
                {
                    return;
                }
            }

            this.DlStAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendidikanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKerjaanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLModalAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLabaAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            this.DLStatausIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendidikanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKerjaanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLModalIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLabaIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            //---- GET DATA LAMA ---//
            string StrPribadi = "";
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_pribadi_banding WHERE no_daftar=@no_daftar AND data_banding='lama'" , con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_pribadi WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DlStAyah1.SelectedIndex = DlStAyah1.Items.IndexOf(DlStAyah1.Items.FindByText(rdr["stayah"].ToString().Trim()));
                                    this.DLPendidikanAyah1.SelectedIndex = DLPendidikanAyah1.Items.IndexOf(DLPendidikanAyah1.Items.FindByText(rdr["pdayah"].ToString().Trim()));
                                    this.DLKerjaanAyah1.SelectedIndex = DLKerjaanAyah1.Items.IndexOf(DLKerjaanAyah1.Items.FindByText(rdr["kerjaayah"].ToString().Trim()));
                                    this.DLModalAyah1.SelectedIndex = DLModalAyah1.Items.IndexOf(DLModalAyah1.Items.FindByText(rdr["modalayah"].ToString().Trim()));
                                    this.DLLabaAyah1.SelectedIndex = DLLabaAyah1.Items.IndexOf(DLLabaAyah1.Items.FindByText(rdr["labaayah"].ToString().Trim()));

                                    this.DLStatausIbu1.SelectedIndex = DLStatausIbu1.Items.IndexOf(DLStatausIbu1.Items.FindByText(rdr["stibu"].ToString().Trim()));
                                    this.DLPendidikanIbu1.SelectedIndex = DLPendidikanIbu1.Items.IndexOf(DLPendidikanIbu1.Items.FindByText(rdr["pdibu"].ToString().Trim()));
                                    this.DLKerjaanIbu1.SelectedIndex = DLKerjaanIbu1.Items.IndexOf(DLKerjaanIbu1.Items.FindByText(rdr["kerjaibu"].ToString().Trim()));
                                    this.DLModalIbu1.SelectedIndex = DLModalIbu1.Items.IndexOf(DLModalIbu1.Items.FindByText(rdr["modalibu"].ToString().Trim()));
                                    this.DLLabaIbu1.SelectedIndex = DLLabaIbu1.Items.IndexOf(DLLabaIbu1.Items.FindByText(rdr["labaibu"].ToString().Trim()));
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
                    else if (StrPribadi == "ada")
                    {
                        // ------ Data Pribadi Banding Ada ---------- //
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_pribadi_banding WHERE no_daftar=@no_daftar AND data_banding='lama'" , con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DlStAyah1.SelectedIndex = DlStAyah1.Items.IndexOf(DlStAyah1.Items.FindByText(rdr["stayah"].ToString().Trim()));
                                    this.DLPendidikanAyah1.SelectedIndex = DLPendidikanAyah1.Items.IndexOf(DLPendidikanAyah1.Items.FindByText(rdr["pdayah"].ToString().Trim()));
                                    this.DLKerjaanAyah1.SelectedIndex = DLKerjaanAyah1.Items.IndexOf(DLKerjaanAyah1.Items.FindByText(rdr["kerjaayah"].ToString().Trim()));
                                    this.DLModalAyah1.SelectedIndex = DLModalAyah1.Items.IndexOf(DLModalAyah1.Items.FindByText(rdr["modalayah"].ToString().Trim()));
                                    this.DLLabaAyah1.SelectedIndex = DLLabaAyah1.Items.IndexOf(DLLabaAyah1.Items.FindByText(rdr["labaayah"].ToString().Trim()));

                                    this.DLStatausIbu1.SelectedIndex = DLStatausIbu1.Items.IndexOf(DLStatausIbu1.Items.FindByText(rdr["stibu"].ToString().Trim()));
                                    this.DLPendidikanIbu1.SelectedIndex = DLPendidikanIbu1.Items.IndexOf(DLPendidikanIbu1.Items.FindByText(rdr["pdibu"].ToString().Trim()));
                                    this.DLKerjaanIbu1.SelectedIndex = DLKerjaanIbu1.Items.IndexOf(DLKerjaanIbu1.Items.FindByText(rdr["kerjaibu"].ToString().Trim()));
                                    this.DLModalIbu1.SelectedIndex = DLModalIbu1.Items.IndexOf(DLModalIbu1.Items.FindByText(rdr["modalibu"].ToString().Trim()));
                                    this.DLLabaIbu1.SelectedIndex = DLLabaIbu1.Items.IndexOf(DLLabaIbu1.Items.FindByText(rdr["labaibu"].ToString().Trim()));
                                }


                                this.LbMsgPribadi1.Text = "Data sudah tesimpan";
                                this.LbMsgPribadi1.ForeColor = System.Drawing.Color.Green;

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
            string StrPribadiBanding = "";
            string CS3 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS3))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_pribadi_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_pribadi_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DlStAyah.SelectedIndex = DlStAyah.Items.IndexOf(DlStAyah.Items.FindByText(rdr["stayah"].ToString().Trim()));
                                    this.DLPendidikanAyah.SelectedIndex = DLPendidikanAyah.Items.IndexOf(DLPendidikanAyah.Items.FindByText(rdr["pdayah"].ToString().Trim()));
                                    this.DLKerjaanAyah.SelectedIndex = DLKerjaanAyah.Items.IndexOf(DLKerjaanAyah.Items.FindByText(rdr["kerjaayah"].ToString().Trim()));
                                    this.DLModalAyah.SelectedIndex = DLModalAyah.Items.IndexOf(DLModalAyah.Items.FindByText(rdr["modalayah"].ToString().Trim()));
                                    this.DLLabaAyah.SelectedIndex = DLLabaAyah.Items.IndexOf(DLLabaAyah.Items.FindByText(rdr["labaayah"].ToString().Trim()));

                                    this.DLStatausIbu.SelectedIndex = DLStatausIbu.Items.IndexOf(DLStatausIbu.Items.FindByText(rdr["stibu"].ToString().Trim()));
                                    this.DLPendidikanIbu.SelectedIndex = DLPendidikanIbu.Items.IndexOf(DLPendidikanIbu.Items.FindByText(rdr["pdibu"].ToString().Trim()));
                                    this.DLKerjaanIbu.SelectedIndex = DLKerjaanIbu.Items.IndexOf(DLKerjaanIbu.Items.FindByText(rdr["kerjaibu"].ToString().Trim()));
                                    this.DLModalIbu.SelectedIndex = DLModalIbu.Items.IndexOf(DLModalIbu.Items.FindByText(rdr["modalibu"].ToString().Trim()));
                                    this.DLLabaIbu.SelectedIndex = DLLabaIbu.Items.IndexOf(DLLabaIbu.Items.FindByText(rdr["labaibu"].ToString().Trim()));
                                }


                                this.LbMsgPribadi.Text = "Data sudah tesimpan";
                                this.LbMsgPribadi.ForeColor = System.Drawing.Color.Green;

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
            SaveDataSurveiPribadi();
            LoadDataSurveiPribadi();
        }

        protected void SaveDataSurveiPribadi()
        {
            if (this.DlStAyah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Status Ayah');", true);
                return;
            }
            if (this.DLPendidikanAyah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pendidikan Ayah');", true);
                return;
            }
            if (this.DLKerjaanAyah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pekerjaan Ayah');", true);
                return;
            }
            if (this.DLModalAyah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Modal Ayah');", true);
                return;
            }
            if (this.DLLabaAyah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Laba Ayah');", true);
                return;
            }


            if (this.DLStatausIbu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Status Ibu');", true);
                return;
            }
            if (this.DLPendidikanIbu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pendidikan Ibu');", true);
                return;
            }
            if (this.DLKerjaanIbu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pekerjaan Ibu');", true);
                return;
            }
            if (this.DLModalIbu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Modal Ibu');", true);
                return;
            }
            if (this.DLLabaIbu.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Laba Ibu');", true);
                return;
            }


            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendidikanAyah.SelectedValue) +
                Convert.ToInt32(DLKerjaanAyah.SelectedValue) +
                Convert.ToInt32(DLModalAyah.SelectedValue) +
                Convert.ToInt32(DLLabaAyah.SelectedValue) +
                Convert.ToInt32(DLPendidikanIbu.SelectedValue) +
                Convert.ToInt32(DLKerjaanIbu.SelectedValue) +
                Convert.ToInt32(DLModalIbu.SelectedValue) +
                Convert.ToInt32(DLLabaIbu.SelectedValue);

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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_pribadi_banding (no_daftar,stayah,pdayah,kerjaayah, modalayah, labaayah,stibu,pdibu,kerjaibu,modalibu,labaibu,nilai,data_banding ) " +
                                                    "VALUES (@no_daftar,@stayah,@pdayah,@kerjaayah, @modalayah, @labaayah, @stibu,@pdibu,@kerjaibu,@modalibu,@labaibu,@nilai,@data_banding)", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stayah", this.DlStAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", this.DLPendidikanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalayah", this.DLModalAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", this.DLLabaAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@stibu", this.DLStatausIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdibu", this.DLPendidikanIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaibu", this.DLKerjaanIbu.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalibu", this.DLModalIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaibu", this.DLLabaIbu.SelectedItem.Text);
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

        protected void SaveDataLamaPibadi()
        {
            if (this.DlStAyah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Status Ayah');", true);
                return;
            }
            if (this.DLPendidikanAyah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pendidikan Ayah');", true);
                return;
            }
            if (this.DLKerjaanAyah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pekerjaan Ayah');", true);
                return;
            }
            if (this.DLModalAyah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Modal Ayah');", true);
                return;
            }
            if (this.DLLabaAyah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Laba Ayah');", true);
                return;
            }


            if (this.DLStatausIbu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Status Ibu');", true);
                return;
            }
            if (this.DLPendidikanIbu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pendidikan Ibu');", true);
                return;
            }
            if (this.DLKerjaanIbu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Pekerjaan Ibu');", true);
                return;
            }
            if (this.DLModalIbu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Modal Ibu');", true);
                return;
            }
            if (this.DLLabaIbu1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Laba Ibu');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendidikanAyah1.SelectedValue) +
                Convert.ToInt32(DLKerjaanAyah1.SelectedValue) +
                Convert.ToInt32(DLModalAyah1.SelectedValue) +
                Convert.ToInt32(DLLabaAyah1.SelectedValue) +
                Convert.ToInt32(DLPendidikanIbu1.SelectedValue) +
                Convert.ToInt32(DLKerjaanIbu1.SelectedValue) +
                Convert.ToInt32(DLModalIbu1.SelectedValue) +
                Convert.ToInt32(DLLabaIbu1.SelectedValue);

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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_pribadi_banding (no_daftar,stayah,pdayah,kerjaayah, modalayah, labaayah,stibu,pdibu,kerjaibu,modalibu,labaibu,nilai,data_banding ) " +
                                                    "VALUES (@no_daftar,@stayah,@pdayah,@kerjaayah, @modalayah, @labaayah, @stibu,@pdibu,@kerjaibu,@modalibu,@labaibu,@nilai,@data_banding)", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stayah", this.DlStAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", this.DLPendidikanAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah1.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalayah", this.DLModalAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", this.DLLabaAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@stibu", this.DLStatausIbu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdibu", this.DLPendidikanIbu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaibu", this.DLKerjaanIbu1.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalibu", this.DLModalIbu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaibu", this.DLLabaIbu1.SelectedItem.Text);
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

        protected void LoadDataSurveiPribadi()
        {
            this.DlStAyah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendidikanAyah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKerjaanAyah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLModalAyah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLabaAyah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            this.DLStatausIbu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendidikanIbu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKerjaanIbu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLModalIbu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLabaIbu.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");


            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_pribadi_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //DlStAyah.Attributes.Add("style", "background-color: red");


                                this.DlStAyah1.SelectedIndex = DlStAyah1.Items.IndexOf(DlStAyah1.Items.FindByText(rdr["stayah"].ToString().Trim()));
                                this.DLPendidikanAyah1.SelectedIndex = DLPendidikanAyah1.Items.IndexOf(DLPendidikanAyah1.Items.FindByText(rdr["pdayah"].ToString().Trim()));
                                this.DLKerjaanAyah1.SelectedIndex = DLKerjaanAyah1.Items.IndexOf(DLKerjaanAyah1.Items.FindByText(rdr["kerjaayah"].ToString().Trim()));
                                this.DLModalAyah1.SelectedIndex = DLModalAyah1.Items.IndexOf(DLModalAyah1.Items.FindByText(rdr["modalayah"].ToString().Trim()));
                                this.DLLabaAyah1.SelectedIndex = DLLabaAyah1.Items.IndexOf(DLLabaAyah1.Items.FindByText(rdr["labaayah"].ToString().Trim()));

                                this.DLStatausIbu1.SelectedIndex = DLStatausIbu1.Items.IndexOf(DLStatausIbu1.Items.FindByText(rdr["stibu"].ToString().Trim()));
                                this.DLPendidikanIbu1.SelectedIndex = DLPendidikanIbu1.Items.IndexOf(DLPendidikanIbu1.Items.FindByText(rdr["pdibu"].ToString().Trim()));
                                this.DLKerjaanIbu1.SelectedIndex = DLKerjaanIbu1.Items.IndexOf(DLKerjaanIbu1.Items.FindByText(rdr["kerjaibu"].ToString().Trim()));
                                this.DLModalIbu1.SelectedIndex = DLModalIbu1.Items.IndexOf(DLModalIbu1.Items.FindByText(rdr["modalibu"].ToString().Trim()));
                                this.DLLabaIbu1.SelectedIndex = DLLabaIbu1.Items.IndexOf(DLLabaIbu1.Items.FindByText(rdr["labaibu"].ToString().Trim()));
                            }


                            this.LbMsgPribadi.Text = "Data sudah tesimpan";
                            this.LbMsgPribadi.ForeColor = System.Drawing.Color.Green;

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

        protected void LoadDataLamaPribadi()
        {
            this.DlStAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendidikanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKerjaanAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLModalAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLabaAyah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            this.DLStatausIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPendidikanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKerjaanIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLModalIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLabaIbu1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");


            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_pribadi_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //DlStAyah.Attributes.Add("style", "background-color: red");

                                this.DlStAyah1.SelectedIndex = DlStAyah1.Items.IndexOf(DlStAyah1.Items.FindByText(rdr["stayah"].ToString().Trim()));
                                this.DLPendidikanAyah1.SelectedIndex = DLPendidikanAyah1.Items.IndexOf(DLPendidikanAyah1.Items.FindByText(rdr["pdayah"].ToString().Trim()));
                                this.DLKerjaanAyah1.SelectedIndex = DLKerjaanAyah1.Items.IndexOf(DLKerjaanAyah1.Items.FindByText(rdr["kerjaayah"].ToString().Trim()));
                                this.DLModalAyah1.SelectedIndex = DLModalAyah1.Items.IndexOf(DLModalAyah1.Items.FindByText(rdr["modalayah"].ToString().Trim()));
                                this.DLLabaAyah1.SelectedIndex = DLLabaAyah1.Items.IndexOf(DLLabaAyah1.Items.FindByText(rdr["labaayah"].ToString().Trim()));

                                this.DLStatausIbu1.SelectedIndex = DLStatausIbu1.Items.IndexOf(DLStatausIbu1.Items.FindByText(rdr["stibu"].ToString().Trim()));
                                this.DLPendidikanIbu1.SelectedIndex = DLPendidikanIbu1.Items.IndexOf(DLPendidikanIbu1.Items.FindByText(rdr["pdibu"].ToString().Trim()));
                                this.DLKerjaanIbu1.SelectedIndex = DLKerjaanIbu1.Items.IndexOf(DLKerjaanIbu1.Items.FindByText(rdr["kerjaibu"].ToString().Trim()));
                                this.DLModalIbu1.SelectedIndex = DLModalIbu1.Items.IndexOf(DLModalIbu1.Items.FindByText(rdr["modalibu"].ToString().Trim()));
                                this.DLLabaIbu1.SelectedIndex = DLLabaIbu1.Items.IndexOf(DLLabaIbu1.Items.FindByText(rdr["labaibu"].ToString().Trim()));
                            }


                            this.LbMsgPribadi1.Text = "Data sudah tesimpan";
                            this.LbMsgPribadi1.ForeColor = System.Drawing.Color.Green;

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

        private bool UpdateDataSurveiPribadi()
        {
            int error = 0;

            if (this.DlStAyah.SelectedValue == "-1")
            {
                this.DlStAyah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPendidikanAyah.SelectedValue == "-1")
            {
                this.DLPendidikanAyah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKerjaanAyah.SelectedValue == "-1")
            {
                this.DLKerjaanAyah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLModalAyah.SelectedValue == "-1")
            {
                this.DLModalAyah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLLabaAyah.SelectedValue == "-1")
            {
                this.DLLabaAyah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (this.DLStatausIbu.SelectedValue == "-1")
            {
                this.DLStatausIbu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPendidikanIbu.SelectedValue == "-1")
            {
                this.DLPendidikanIbu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKerjaanIbu.SelectedValue == "-1")
            {
                this.DLKerjaanIbu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLModalIbu.SelectedValue == "-1")
            {
                this.DLModalIbu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLLabaIbu.SelectedValue == "-1")
            {
                this.DLLabaIbu.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendidikanAyah.SelectedValue) +
                Convert.ToInt32(DLKerjaanAyah.SelectedValue) +
                Convert.ToInt32(DLModalAyah.SelectedValue) +
                Convert.ToInt32(DLLabaAyah.SelectedValue) +
                Convert.ToInt32(DLPendidikanIbu.SelectedValue) +
                Convert.ToInt32(DLKerjaanIbu.SelectedValue) +
                Convert.ToInt32(DLModalIbu.SelectedValue) +
                Convert.ToInt32(DLLabaIbu.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_pribadi_banding SET stayah=@stayah,pdayah=@pdayah,kerjaayah=@kerjaayah, modalayah=@modalayah, labaayah=@labaayah,stibu=@stibu,pdibu=@pdibu,kerjaibu=@kerjaibu,modalibu=@modalibu,labaibu=@labaibu,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);

                    cmd.Parameters.AddWithValue("@stayah", this.DlStAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", this.DLPendidikanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah.SelectedItem.Text.ToString());

                    cmd.Parameters.AddWithValue("@modalayah", this.DLModalAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", this.DLLabaAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@stibu", this.DLStatausIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdibu", this.DLPendidikanIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaibu", this.DLKerjaanIbu.SelectedItem.Text.ToString());

                    cmd.Parameters.AddWithValue("@modalibu", this.DLModalIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaibu", this.DLLabaIbu.SelectedItem.Text);
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

        private bool UpdateDataLamaPribadi()
        {
            int error = 0;

            if (this.DlStAyah1.SelectedValue == "-1")
            {
                this.DlStAyah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPendidikanAyah1.SelectedValue == "-1")
            {
                this.DLPendidikanAyah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKerjaanAyah1.SelectedValue == "-1")
            {
                this.DLKerjaanAyah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLModalAyah1.SelectedValue == "-1")
            {
                this.DLModalAyah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLLabaAyah1.SelectedValue == "-1")
            {
                this.DLLabaAyah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLStatausIbu1.SelectedValue == "-1")
            {
                this.DLStatausIbu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPendidikanIbu1.SelectedValue == "-1")
            {
                this.DLPendidikanIbu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKerjaanIbu1.SelectedValue == "-1")
            {
                this.DLKerjaanIbu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLModalIbu1.SelectedValue == "-1")
            {
                this.DLModalIbu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLLabaIbu1.SelectedValue == "-1")
            {
                this.DLLabaIbu1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Error Update Data Lama Borang Pribadi');", true);
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendidikanAyah1.SelectedValue) +
                Convert.ToInt32(DLKerjaanAyah1.SelectedValue) +
                Convert.ToInt32(DLModalAyah1.SelectedValue) +
                Convert.ToInt32(DLLabaAyah1.SelectedValue) +
                Convert.ToInt32(DLPendidikanIbu1.SelectedValue) +
                Convert.ToInt32(DLKerjaanIbu1.SelectedValue) +
                Convert.ToInt32(DLModalIbu1.SelectedValue) +
                Convert.ToInt32(DLLabaIbu1.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_pribadi_banding SET stayah=@stayah,pdayah=@pdayah,kerjaayah=@kerjaayah, modalayah=@modalayah, labaayah=@labaayah, stibu=@stibu,pdibu=@pdibu,kerjaibu=@kerjaibu,modalibu=@modalibu,labaibu=@labaibu,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);

                    cmd.Parameters.AddWithValue("@stayah", this.DlStAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", this.DLPendidikanAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah1.SelectedItem.Text.ToString());

                    cmd.Parameters.AddWithValue("@modalayah", this.DLModalAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", this.DLLabaAyah1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@stibu", this.DLStatausIbu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdibu", this.DLPendidikanIbu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaibu", this.DLKerjaanIbu1.SelectedItem.Text.ToString());

                    cmd.Parameters.AddWithValue("@modalibu", this.DLModalIbu1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaibu", this.DLLabaIbu1.SelectedItem.Text);
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    //this.LbMsgUpdate.Text = "UPDATE BORANG PRIBADI GAGAL !";
                    //Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        //protected void BtnUlangi_Click(object sender, EventArgs e)
        //{
        //    this.GetDataPribadi(this.Session["NoDaftar"].ToString());

        //    this.BtnSave.Enabled = false;
        //    this.BtnSave.Visible = false;

        //    this.BtnUpdate.Enabled = true;
        //    this.BtnUpdate.Visible = true;

        //}

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiPribadi() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiPribadi();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaPibadi();
            LoadDataLamaPribadi();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaPribadi() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaPribadi();
            }
        }
    }
}