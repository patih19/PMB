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
    public partial class Rumah : User
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
                    this.GetDataRumah(this.Session["NoDaftar"].ToString());
                    //LoadDataSurveiRumah();
                }
            }
        }

        protected void GetDataRumah(string npm)
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

            //---- GET DATA LAMA ---//
            string StrPribadi = "";
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_rumah_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_rumah WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLStatusRumah1.SelectedIndex = DLStatusRumah1.Items.IndexOf(DLStatusRumah1.Items.FindByText(rdr["stsrumah"].ToString().Trim()));
                                    this.DlSmbrListrik1.SelectedIndex = DlSmbrListrik1.Items.IndexOf(DlSmbrListrik1.Items.FindByText(rdr["smbrlistrik"].ToString().Trim()));
                                    this.DLKwh1.SelectedIndex = DLKwh1.Items.IndexOf(DLKwh1.Items.FindByText(rdr["dylistrik"].ToString().Trim()));
                                    this.DlBiayaListrik1.SelectedIndex = DlBiayaListrik1.Items.IndexOf(DlBiayaListrik1.Items.FindByText(rdr["bylistrik"].ToString().Trim()));
                                    this.DLSmbrAir1.SelectedIndex = DLSmbrAir1.Items.IndexOf(DLSmbrAir1.Items.FindByText(rdr["sbair"].ToString().Trim()));

                                    this.DLBiayaAir1.SelectedIndex = DLBiayaAir1.Items.IndexOf(DLBiayaAir1.Items.FindByText(rdr["byair"].ToString().Trim()));
                                    this.DLLsTanah1.SelectedIndex = DLLsTanah1.Items.IndexOf(DLLsTanah1.Items.FindByText(rdr["lstanah"].ToString().Trim()));
                                    this.DLLsBangunan1.SelectedIndex = DLLsBangunan1.Items.IndexOf(DLLsBangunan1.Items.FindByText(rdr["lsbangunan"].ToString().Trim()));
                                    this.DLNJOP1.SelectedIndex = DLNJOP1.Items.IndexOf(DLNJOP1.Items.FindByText(rdr["njop"].ToString().Trim()));
                                    this.DLAtap1.SelectedIndex = DLAtap1.Items.IndexOf(DLAtap1.Items.FindByText(rdr["atap"].ToString().Trim()));

                                    this.DLLantai1.SelectedIndex = DLLantai1.Items.IndexOf(DLLantai1.Items.FindByText(rdr["lantai"].ToString().Trim()));
                                    this.DLRgTengah1.SelectedIndex = DLRgTengah1.Items.IndexOf(DLRgTengah1.Items.FindByText(rdr["rgtenngah"].ToString().Trim()));
                                    this.DLDapur1.SelectedIndex = DLDapur1.Items.IndexOf(DLDapur1.Items.FindByText(rdr["dpr"].ToString().Trim()));
                                    this.DLCuci1.SelectedIndex = DLCuci1.Items.IndexOf(DLCuci1.Items.FindByText(rdr["cuci"].ToString().Trim()));
                                    this.DLKmMandi1.SelectedIndex = DLKmMandi1.Items.IndexOf(DLKmMandi1.Items.FindByText(rdr["mandi"].ToString().Trim()));
                                    this.DLTeras1.SelectedIndex = DLTeras1.Items.IndexOf(DLTeras1.Items.FindByText(rdr["teras"].ToString().Trim()));
                                    this.DLGarasi1.SelectedIndex = DLGarasi1.Items.IndexOf(DLGarasi1.Items.FindByText(rdr["garasi"].ToString().Trim()));

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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_rumah_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLStatusRumah1.SelectedIndex = DLStatusRumah1.Items.IndexOf(DLStatusRumah1.Items.FindByText(rdr["stsrumah"].ToString().Trim()));
                                    this.DlSmbrListrik1.SelectedIndex = DlSmbrListrik1.Items.IndexOf(DlSmbrListrik1.Items.FindByText(rdr["smbrlistrik"].ToString().Trim()));
                                    this.DLKwh1.SelectedIndex = DLKwh1.Items.IndexOf(DLKwh1.Items.FindByText(rdr["dylistrik"].ToString().Trim()));
                                    this.DlBiayaListrik1.SelectedIndex = DlBiayaListrik1.Items.IndexOf(DlBiayaListrik1.Items.FindByText(rdr["bylistrik"].ToString().Trim()));
                                    this.DLSmbrAir1.SelectedIndex = DLSmbrAir1.Items.IndexOf(DLSmbrAir1.Items.FindByText(rdr["sbair"].ToString().Trim()));

                                    this.DLBiayaAir1.SelectedIndex = DLBiayaAir1.Items.IndexOf(DLBiayaAir1.Items.FindByText(rdr["byair"].ToString().Trim()));
                                    this.DLLsTanah1.SelectedIndex = DLLsTanah1.Items.IndexOf(DLLsTanah1.Items.FindByText(rdr["lstanah"].ToString().Trim()));
                                    this.DLLsBangunan1.SelectedIndex = DLLsBangunan1.Items.IndexOf(DLLsBangunan1.Items.FindByText(rdr["lsbangunan"].ToString().Trim()));
                                    this.DLNJOP1.SelectedIndex = DLNJOP1.Items.IndexOf(DLNJOP1.Items.FindByText(rdr["njop"].ToString().Trim()));
                                    this.DLAtap1.SelectedIndex = DLAtap1.Items.IndexOf(DLAtap1.Items.FindByText(rdr["atap"].ToString().Trim()));

                                    this.DLLantai1.SelectedIndex = DLLantai1.Items.IndexOf(DLLantai1.Items.FindByText(rdr["lantai"].ToString().Trim()));
                                    this.DLRgTengah1.SelectedIndex = DLRgTengah1.Items.IndexOf(DLRgTengah1.Items.FindByText(rdr["rgtenngah"].ToString().Trim()));
                                    this.DLDapur1.SelectedIndex = DLDapur1.Items.IndexOf(DLDapur1.Items.FindByText(rdr["dpr"].ToString().Trim()));
                                    this.DLCuci1.SelectedIndex = DLCuci1.Items.IndexOf(DLCuci1.Items.FindByText(rdr["cuci"].ToString().Trim()));
                                    this.DLKmMandi1.SelectedIndex = DLKmMandi1.Items.IndexOf(DLKmMandi1.Items.FindByText(rdr["mandi"].ToString().Trim()));
                                    this.DLTeras1.SelectedIndex = DLTeras1.Items.IndexOf(DLTeras1.Items.FindByText(rdr["teras"].ToString().Trim()));
                                    this.DLGarasi1.SelectedIndex = DLGarasi1.Items.IndexOf(DLGarasi1.Items.FindByText(rdr["garasi"].ToString().Trim()));

                                }


                                this.LbMsgRumah1.Text = "Data sudah tesimpan";
                                this.LbMsgRumah1.ForeColor = System.Drawing.Color.Green;

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
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_rumah_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_rumah_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");
                                    this.DLStatusRumah.SelectedIndex = DLStatusRumah.Items.IndexOf(DLStatusRumah.Items.FindByText(rdr["stsrumah"].ToString().Trim()));
                                    this.DlSmbrListrik.SelectedIndex = DlSmbrListrik.Items.IndexOf(DlSmbrListrik.Items.FindByText(rdr["smbrlistrik"].ToString().Trim()));
                                    this.DLKwh.SelectedIndex = DLKwh.Items.IndexOf(DLKwh.Items.FindByText(rdr["dylistrik"].ToString().Trim()));
                                    this.DlBiayaListrik.SelectedIndex = DlBiayaListrik.Items.IndexOf(DlBiayaListrik.Items.FindByText(rdr["bylistrik"].ToString().Trim()));
                                    this.DLSmbrAir.SelectedIndex = DLSmbrAir.Items.IndexOf(DLSmbrAir.Items.FindByText(rdr["sbair"].ToString().Trim()));

                                    this.DLBiayaAir.SelectedIndex = DLBiayaAir.Items.IndexOf(DLBiayaAir.Items.FindByText(rdr["byair"].ToString().Trim()));
                                    this.DLLsTanah.SelectedIndex = DLLsTanah.Items.IndexOf(DLLsTanah.Items.FindByText(rdr["lstanah"].ToString().Trim()));
                                    this.DLLsBangunan.SelectedIndex = DLLsBangunan.Items.IndexOf(DLLsBangunan.Items.FindByText(rdr["lsbangunan"].ToString().Trim()));
                                    this.DLNJOP.SelectedIndex = DLNJOP.Items.IndexOf(DLNJOP.Items.FindByText(rdr["njop"].ToString().Trim()));
                                    this.DLAtap.SelectedIndex = DLAtap.Items.IndexOf(DLAtap.Items.FindByText(rdr["atap"].ToString().Trim()));

                                    this.DLLantai.SelectedIndex = DLLantai.Items.IndexOf(DLLantai.Items.FindByText(rdr["lantai"].ToString().Trim()));
                                    this.DLRgTengah.SelectedIndex = DLRgTengah.Items.IndexOf(DLRgTengah.Items.FindByText(rdr["rgtenngah"].ToString().Trim()));
                                    this.DLDapur.SelectedIndex = DLDapur.Items.IndexOf(DLDapur.Items.FindByText(rdr["dpr"].ToString().Trim()));
                                    this.DLCuci.SelectedIndex = DLCuci.Items.IndexOf(DLCuci.Items.FindByText(rdr["cuci"].ToString().Trim()));
                                    this.DLKmMandi.SelectedIndex = DLKmMandi.Items.IndexOf(DLKmMandi.Items.FindByText(rdr["mandi"].ToString().Trim()));
                                    this.DLTeras.SelectedIndex = DLTeras.Items.IndexOf(DLTeras.Items.FindByText(rdr["teras"].ToString().Trim()));
                                    this.DLGarasi.SelectedIndex = DLGarasi.Items.IndexOf(DLGarasi.Items.FindByText(rdr["garasi"].ToString().Trim()));

                                }


                                this.LbMsgRumah.Text = "Data sudah tesimpan";
                                this.LbMsgRumah.ForeColor = System.Drawing.Color.Green;

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



        protected void SaveDataSurveiRumah()
        {
            if (this.DLStatusRumah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Status kepemilikan rumah');", true);
                return;
            }
            if (this.DlSmbrListrik.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sumber listrik');", true);
                return;
            }
            if (this.DLKwh.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Daya listrik');", true);
                return;
            }
            if (this.DlBiayaListrik.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata biaya listrik per bulan');", true);
                return;
            }
            if (this.DLSmbrAir.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sumber air');", true);
                return;
            }
            if (this.DLBiayaAir.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata biaya air per bulan');", true);
                return;
            }
            if (this.DLLsTanah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Luas tanah');", true);
                return;
            }
            if (this.DLLsBangunan.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Luas bangunan');", true);
                return;
            }
            if (this.DLNJOP.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi NJOP');", true);
                return;
            }
            if (this.DLAtap.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Bahan atap rumah');", true);
                return;
            }
            if (this.DLLantai.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Bahan lantai rumah');", true);
                return;
            }
            if (this.DLRgTengah.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Ruang tengah keluarga');", true);
                return;
            }
            if (this.DLDapur.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Dapur');", true);
                return;
            }
            if (this.DLCuci.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Cuci piring, gelas, baju');", true);
                return;
            }
            if (this.DLKmMandi.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Keperluan mandi/kamar mandi');", true);
                return;
            }
            if (this.DLTeras.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Teras');", true);
                return;
            }
            if (this.DLGarasi.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Garasi');", true);
                return;
            }


            // Get Nilai 
            int Nilai = Convert.ToInt32(DLStatusRumah.SelectedValue) +
                Convert.ToInt32(DlSmbrListrik.SelectedValue) +
                Convert.ToInt32(DLKwh.SelectedValue) +
                Convert.ToInt32(DlBiayaListrik.SelectedValue) +
                Convert.ToInt32(DLSmbrAir.SelectedValue) +
                Convert.ToInt32(DLBiayaAir.SelectedValue) +
                Convert.ToInt32(DLLsTanah.SelectedValue) +
                Convert.ToInt32(DLLsBangunan.SelectedValue) +
                Convert.ToInt32(DLNJOP.SelectedValue) +
                Convert.ToInt32(DLAtap.SelectedValue) +
                Convert.ToInt32(DLLantai.SelectedValue) +
                Convert.ToInt32(DLRgTengah.SelectedValue) +
                Convert.ToInt32(DLDapur.SelectedValue) +
                Convert.ToInt32(DLCuci.SelectedValue) +
                Convert.ToInt32(DLKmMandi.SelectedValue) +
                Convert.ToInt32(DLTeras.SelectedValue) +
                Convert.ToInt32(DLGarasi.SelectedValue);

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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_rumah_banding (no_daftar,stsrumah,smbrlistrik,dylistrik,bylistrik,sbair,byair,lstanah,lsbangunan,njop,atap,lantai,rgtenngah,dpr,cuci,mandi,teras,garasi,nilai,data_banding) " +
                                                    "VALUES (@no_daftar,@stsrumah,@smbrlistrik,@dylistrik,@bylistrik,@sbair,@byair,@lstanah,@lsbangunan,@njop,@atap,@lantai,@rgtenngah,@dpr,@cuci,@mandi,@teras,@garasi,@nilai,@data_banding)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stsrumah", this.DLStatusRumah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@smbrlistrik", this.DlSmbrListrik.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dylistrik", this.DLKwh.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@bylistrik", this.DlBiayaListrik.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sbair", this.DLSmbrAir.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@byair", this.DLBiayaAir.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lstanah", this.DLLsTanah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lsbangunan", this.DLLsBangunan.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@njop", this.DLNJOP.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@atap", this.DLAtap.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lantai", this.DLLantai.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@rgtenngah", this.DLRgTengah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dpr", this.DLDapur.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cuci", this.DLCuci.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mandi", this.DLKmMandi.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@teras", this.DLTeras.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@garasi", this.DLGarasi.SelectedItem.Text.Trim());

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

        protected void SaveDataLamaRumah()
        {
            if (this.DLStatusRumah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Status kepemilikan rumah');", true);
                return;
            }
            if (this.DlSmbrListrik1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sumber listrik');", true);
                return;
            }
            if (this.DLKwh1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Daya listrik');", true);
                return;
            }
            if (this.DlBiayaListrik1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata biaya listrik per bulan');", true);
                return;
            }
            if (this.DLSmbrAir1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Sumber air');", true);
                return;
            }
            if (this.DLBiayaAir1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata biaya air per bulan');", true);
                return;
            }
            if (this.DLLsTanah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Luas tanah');", true);
                return;
            }
            if (this.DLLsBangunan1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Luas bangunan');", true);
                return;
            }
            if (this.DLNJOP1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi NJOP');", true);
                return;
            }
            if (this.DLAtap1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Bahan atap rumah');", true);
                return;
            }
            if (this.DLLantai1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Bahan lantai rumah');", true);
                return;
            }
            if (this.DLRgTengah1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Ruang tengah keluarga');", true);
                return;
            }
            if (this.DLDapur1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Dapur');", true);
                return;
            }
            if (this.DLCuci1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Cuci piring, gelas, baju');", true);
                return;
            }
            if (this.DLKmMandi1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Keperluan mandi/kamar mandi');", true);
                return;
            }
            if (this.DLTeras1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Teras');", true);
                return;
            }
            if (this.DLGarasi1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Garasi');", true);
                return;
            }


            // Get Nilai 
            int Nilai = Convert.ToInt32(DLStatusRumah1.SelectedValue) +
                Convert.ToInt32(DlSmbrListrik1.SelectedValue) +
                Convert.ToInt32(DLKwh1.SelectedValue) +
                Convert.ToInt32(DlBiayaListrik1.SelectedValue) +
                Convert.ToInt32(DLSmbrAir1.SelectedValue) +
                Convert.ToInt32(DLBiayaAir1.SelectedValue) +
                Convert.ToInt32(DLLsTanah1.SelectedValue) +
                Convert.ToInt32(DLLsBangunan1.SelectedValue) +
                Convert.ToInt32(DLNJOP1.SelectedValue) +
                Convert.ToInt32(DLAtap1.SelectedValue) +
                Convert.ToInt32(DLLantai1.SelectedValue) +
                Convert.ToInt32(DLRgTengah1.SelectedValue) +
                Convert.ToInt32(DLDapur1.SelectedValue) +
                Convert.ToInt32(DLCuci1.SelectedValue) +
                Convert.ToInt32(DLKmMandi1.SelectedValue) +
                Convert.ToInt32(DLTeras1.SelectedValue) +
                Convert.ToInt32(DLGarasi1.SelectedValue);

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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_rumah_banding (no_daftar,stsrumah,smbrlistrik,dylistrik,bylistrik,sbair,byair,lstanah,lsbangunan,njop,atap,lantai,rgtenngah,dpr,cuci,mandi,teras,garasi,nilai,data_banding) " +
                                                    "VALUES (@no_daftar,@stsrumah,@smbrlistrik,@dylistrik,@bylistrik,@sbair,@byair,@lstanah,@lsbangunan,@njop,@atap,@lantai,@rgtenngah,@dpr,@cuci,@mandi,@teras,@garasi,@nilai,@data_banding)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stsrumah", this.DLStatusRumah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@smbrlistrik", this.DlSmbrListrik1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dylistrik", this.DLKwh1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@bylistrik", this.DlBiayaListrik1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sbair", this.DLSmbrAir1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@byair", this.DLBiayaAir1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lstanah", this.DLLsTanah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lsbangunan", this.DLLsBangunan1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@njop", this.DLNJOP1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@atap", this.DLAtap1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lantai", this.DLLantai1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@rgtenngah", this.DLRgTengah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dpr", this.DLDapur1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cuci", this.DLCuci1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mandi", this.DLKmMandi1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@teras", this.DLTeras1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@garasi", this.DLGarasi1.SelectedItem.Text.Trim());

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

        protected void LoadDataSurveiRumah()
        {
            this.DLStatusRumah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DlSmbrListrik.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKwh.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DlBiayaListrik.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSmbrAir.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLBiayaAir.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLsTanah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLsBangunan.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLNJOP.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLAtap.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLantai.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLRgTengah.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLDapur.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLCuci.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKmMandi.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTeras.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLGarasi.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_rumah_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLStatusRumah.SelectedIndex = DLStatusRumah.Items.IndexOf(DLStatusRumah.Items.FindByText(rdr["stsrumah"].ToString().Trim()));
                                this.DlSmbrListrik.SelectedIndex = DlSmbrListrik.Items.IndexOf(DlSmbrListrik.Items.FindByText(rdr["smbrlistrik"].ToString().Trim()));
                                this.DLKwh.SelectedIndex = DLKwh.Items.IndexOf(DLKwh.Items.FindByText(rdr["dylistrik"].ToString().Trim()));
                                this.DlBiayaListrik.SelectedIndex = DlBiayaListrik.Items.IndexOf(DlBiayaListrik.Items.FindByText(rdr["bylistrik"].ToString().Trim()));
                                this.DLSmbrAir.SelectedIndex = DLSmbrAir.Items.IndexOf(DLSmbrAir.Items.FindByText(rdr["sbair"].ToString().Trim()));

                                this.DLBiayaAir.SelectedIndex = DLBiayaAir.Items.IndexOf(DLBiayaAir.Items.FindByText(rdr["byair"].ToString().Trim()));
                                this.DLLsTanah.SelectedIndex = DLLsTanah.Items.IndexOf(DLLsTanah.Items.FindByText(rdr["lstanah"].ToString().Trim()));
                                this.DLLsBangunan.SelectedIndex = DLLsBangunan.Items.IndexOf(DLLsBangunan.Items.FindByText(rdr["lsbangunan"].ToString().Trim()));
                                this.DLNJOP.SelectedIndex = DLNJOP.Items.IndexOf(DLNJOP.Items.FindByText(rdr["njop"].ToString().Trim()));
                                this.DLAtap.SelectedIndex = DLAtap.Items.IndexOf(DLAtap.Items.FindByText(rdr["atap"].ToString().Trim()));

                                this.DLLantai.SelectedIndex = DLLantai.Items.IndexOf(DLLantai.Items.FindByText(rdr["lantai"].ToString().Trim()));
                                this.DLRgTengah.SelectedIndex = DLRgTengah.Items.IndexOf(DLRgTengah.Items.FindByText(rdr["rgtenngah"].ToString().Trim()));
                                this.DLDapur.SelectedIndex = DLDapur.Items.IndexOf(DLDapur.Items.FindByText(rdr["dpr"].ToString().Trim()));
                                this.DLCuci.SelectedIndex = DLCuci.Items.IndexOf(DLCuci.Items.FindByText(rdr["cuci"].ToString().Trim()));
                                this.DLKmMandi.SelectedIndex = DLKmMandi.Items.IndexOf(DLKmMandi.Items.FindByText(rdr["mandi"].ToString().Trim()));
                                this.DLTeras.SelectedIndex = DLTeras.Items.IndexOf(DLTeras.Items.FindByText(rdr["teras"].ToString().Trim()));
                                this.DLGarasi.SelectedIndex = DLGarasi.Items.IndexOf(DLGarasi.Items.FindByText(rdr["garasi"].ToString().Trim()));
                            }

                            this.LbMsgRumah.Text = "Data sudah tesimpan";
                            this.LbMsgRumah.ForeColor = System.Drawing.Color.Green;

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

        protected void LoadDataLamaRumah()
        {
            this.DLStatusRumah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DlSmbrListrik1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKwh1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DlBiayaListrik1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSmbrAir1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLBiayaAir1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLsTanah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLsBangunan1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLNJOP1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLAtap1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLantai1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLRgTengah1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLDapur1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLCuci1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKmMandi1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTeras1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLGarasi1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_rumah_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLStatusRumah1.SelectedIndex = DLStatusRumah1.Items.IndexOf(DLStatusRumah1.Items.FindByText(rdr["stsrumah"].ToString().Trim()));
                                this.DlSmbrListrik1.SelectedIndex = DlSmbrListrik1.Items.IndexOf(DlSmbrListrik1.Items.FindByText(rdr["smbrlistrik"].ToString().Trim()));
                                this.DLKwh1.SelectedIndex = DLKwh1.Items.IndexOf(DLKwh1.Items.FindByText(rdr["dylistrik"].ToString().Trim()));
                                this.DlBiayaListrik1.SelectedIndex = DlBiayaListrik1.Items.IndexOf(DlBiayaListrik1.Items.FindByText(rdr["bylistrik"].ToString().Trim()));
                                this.DLSmbrAir1.SelectedIndex = DLSmbrAir1.Items.IndexOf(DLSmbrAir1.Items.FindByText(rdr["sbair"].ToString().Trim()));

                                this.DLBiayaAir1.SelectedIndex = DLBiayaAir1.Items.IndexOf(DLBiayaAir1.Items.FindByText(rdr["byair"].ToString().Trim()));
                                this.DLLsTanah1.SelectedIndex = DLLsTanah1.Items.IndexOf(DLLsTanah1.Items.FindByText(rdr["lstanah"].ToString().Trim()));
                                this.DLLsBangunan1.SelectedIndex = DLLsBangunan1.Items.IndexOf(DLLsBangunan1.Items.FindByText(rdr["lsbangunan"].ToString().Trim()));
                                this.DLNJOP1.SelectedIndex = DLNJOP1.Items.IndexOf(DLNJOP1.Items.FindByText(rdr["njop"].ToString().Trim()));
                                this.DLAtap1.SelectedIndex = DLAtap1.Items.IndexOf(DLAtap1.Items.FindByText(rdr["atap"].ToString().Trim()));

                                this.DLLantai1.SelectedIndex = DLLantai1.Items.IndexOf(DLLantai1.Items.FindByText(rdr["lantai"].ToString().Trim()));
                                this.DLRgTengah1.SelectedIndex = DLRgTengah1.Items.IndexOf(DLRgTengah1.Items.FindByText(rdr["rgtenngah"].ToString().Trim()));
                                this.DLDapur1.SelectedIndex = DLDapur1.Items.IndexOf(DLDapur1.Items.FindByText(rdr["dpr"].ToString().Trim()));
                                this.DLCuci1.SelectedIndex = DLCuci1.Items.IndexOf(DLCuci1.Items.FindByText(rdr["cuci"].ToString().Trim()));
                                this.DLKmMandi1.SelectedIndex = DLKmMandi1.Items.IndexOf(DLKmMandi1.Items.FindByText(rdr["mandi"].ToString().Trim()));
                                this.DLTeras1.SelectedIndex = DLTeras1.Items.IndexOf(DLTeras1.Items.FindByText(rdr["teras"].ToString().Trim()));
                                this.DLGarasi1.SelectedIndex = DLGarasi1.Items.IndexOf(DLGarasi1.Items.FindByText(rdr["garasi"].ToString().Trim()));
                            }

                            this.LbMsgRumah1.Text = "Data sudah tesimpan";

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

        private bool UpdateDataSurveiRumah()
        {
            int error = 0;

            if (this.DLStatusRumah.SelectedValue == "-1")
            {
                this.DLStatusRumah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DlSmbrListrik.SelectedValue == "-1")
            {
                this.DlSmbrListrik.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKwh.SelectedValue == "-1")
            {
                this.DLKwh.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DlBiayaListrik.SelectedValue == "-1")
            {
                this.DlBiayaListrik.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSmbrAir.SelectedValue == "-1")
            {
                this.DLSmbrAir.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLBiayaAir.SelectedValue == "-1")
            {
                this.DLBiayaAir.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLLsTanah.SelectedValue == "-1")
            {
                this.DLLsTanah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLLsBangunan.SelectedValue == "-1")
            {
                this.DLLsBangunan.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLNJOP.SelectedValue == "-1")
            {
                this.DLNJOP.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLAtap.SelectedValue == "-1")
            {
                this.DLAtap.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLLantai.SelectedValue == "-1")
            {
                this.DLLantai.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLRgTengah.SelectedValue == "-1")
            {
                this.DLRgTengah.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLDapur.SelectedValue == "-1")
            {
                this.DLDapur.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLCuci.SelectedValue == "-1")
            {
                this.DLCuci.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKmMandi.SelectedValue == "-1")
            {
                this.DLKmMandi.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTeras.SelectedValue == "-1")
            {
                this.DLTeras.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLGarasi.SelectedValue == "-1")
            {
                this.DLGarasi.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLStatusRumah.SelectedValue) +
                Convert.ToInt32(DlSmbrListrik.SelectedValue) +
                Convert.ToInt32(DLKwh.SelectedValue) +
                Convert.ToInt32(DlBiayaListrik.SelectedValue) +
                Convert.ToInt32(DLSmbrAir.SelectedValue) +
                Convert.ToInt32(DLBiayaAir.SelectedValue) +
                Convert.ToInt32(DLLsTanah.SelectedValue) +
                Convert.ToInt32(DLLsBangunan.SelectedValue) +
                Convert.ToInt32(DLNJOP.SelectedValue) +
                Convert.ToInt32(DLAtap.SelectedValue) +
                Convert.ToInt32(DLLantai.SelectedValue) +
                Convert.ToInt32(DLRgTengah.SelectedValue) +
                Convert.ToInt32(DLDapur.SelectedValue) +
                Convert.ToInt32(DLCuci.SelectedValue) +
                Convert.ToInt32(DLKmMandi.SelectedValue) +
                Convert.ToInt32(DLTeras.SelectedValue) +
                Convert.ToInt32(DLGarasi.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_rumah_banding set stsrumah=@stsrumah,smbrlistrik=@smbrlistrik,dylistrik=@dylistrik,bylistrik=@bylistrik,sbair=@sbair,byair=@byair,lstanah=@lstanah,lsbangunan=@lsbangunan,njop=@njop,atap=@atap,lantai=@lantai,rgtenngah=@rgtenngah,dpr=@dpr,cuci=@cuci,mandi=@mandi,teras=@teras,garasi=@garasi,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stsrumah", this.DLStatusRumah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@smbrlistrik", this.DlSmbrListrik.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dylistrik", this.DLKwh.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@bylistrik", this.DlBiayaListrik.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sbair", this.DLSmbrAir.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@byair", this.DLBiayaAir.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lstanah", this.DLLsTanah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lsbangunan", this.DLLsBangunan.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@njop", this.DLNJOP.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@atap", this.DLAtap.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lantai", this.DLLantai.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@rgtenngah", this.DLRgTengah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dpr", this.DLDapur.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cuci", this.DLCuci.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mandi", this.DLKmMandi.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@teras", this.DLTeras.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@garasi", this.DLGarasi.SelectedItem.Text.Trim());

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

        private bool UpdateDataLamaRumah()
        {
            int error = 0;

            if (this.DLStatusRumah1.SelectedValue == "-1")
            {
                this.DLStatusRumah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DlSmbrListrik1.SelectedValue == "-1")
            {
                this.DlSmbrListrik1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKwh1.SelectedValue == "-1")
            {
                this.DLKwh1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DlBiayaListrik1.SelectedValue == "-1")
            {
                this.DlBiayaListrik1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSmbrAir1.SelectedValue == "-1")
            {
                this.DLSmbrAir1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLBiayaAir1.SelectedValue == "-1")
            {
                this.DLBiayaAir1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLLsTanah1.SelectedValue == "-1")
            {
                this.DLLsTanah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLLsBangunan1.SelectedValue == "-1")
            {
                this.DLLsBangunan1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLNJOP1.SelectedValue == "-1")
            {
                this.DLNJOP1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLAtap1.SelectedValue == "-1")
            {
                this.DLAtap1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLLantai1.SelectedValue == "-1")
            {
                this.DLLantai1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLRgTengah1.SelectedValue == "-1")
            {
                this.DLRgTengah1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (this.DLDapur1.SelectedValue == "-1")
            {
                this.DLDapur1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLCuci1.SelectedValue == "-1")
            {
                this.DLCuci1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLKmMandi1.SelectedValue == "-1")
            {
                this.DLKmMandi1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTeras1.SelectedValue == "-1")
            {
                this.DLTeras1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLGarasi1.SelectedValue == "-1")
            {
                this.DLGarasi1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate1.Visible = true;
                this.BtnUpdate1.Enabled = true;
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLStatusRumah1.SelectedValue) +
                Convert.ToInt32(DlSmbrListrik1.SelectedValue) +
                Convert.ToInt32(DLKwh1.SelectedValue) +
                Convert.ToInt32(DlBiayaListrik1.SelectedValue) +
                Convert.ToInt32(DLSmbrAir1.SelectedValue) +
                Convert.ToInt32(DLBiayaAir1.SelectedValue) +
                Convert.ToInt32(DLLsTanah1.SelectedValue) +
                Convert.ToInt32(DLLsBangunan1.SelectedValue) +
                Convert.ToInt32(DLNJOP1.SelectedValue) +
                Convert.ToInt32(DLAtap1.SelectedValue) +
                Convert.ToInt32(DLLantai1.SelectedValue) +
                Convert.ToInt32(DLRgTengah1.SelectedValue) +
                Convert.ToInt32(DLDapur1.SelectedValue) +
                Convert.ToInt32(DLCuci1.SelectedValue) +
                Convert.ToInt32(DLKmMandi1.SelectedValue) +
                Convert.ToInt32(DLTeras1.SelectedValue) +
                Convert.ToInt32(DLGarasi1.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_rumah_banding set stsrumah=@stsrumah,smbrlistrik=@smbrlistrik,dylistrik=@dylistrik,bylistrik=@bylistrik,sbair=@sbair,byair=@byair,lstanah=@lstanah,lsbangunan=@lsbangunan,njop=@njop,atap=@atap,lantai=@lantai,rgtenngah=@rgtenngah,dpr=@dpr,cuci=@cuci,mandi=@mandi,teras=@teras,garasi=@garasi,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stsrumah", this.DLStatusRumah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@smbrlistrik", this.DlSmbrListrik1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dylistrik", this.DLKwh1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@bylistrik", this.DlBiayaListrik1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sbair", this.DLSmbrAir1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@byair", this.DLBiayaAir1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lstanah", this.DLLsTanah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lsbangunan", this.DLLsBangunan1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@njop", this.DLNJOP1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@atap", this.DLAtap1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@lantai", this.DLLantai1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@rgtenngah", this.DLRgTengah1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@dpr", this.DLDapur1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@cuci", this.DLCuci1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@mandi", this.DLKmMandi1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@teras", this.DLTeras1.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@garasi", this.DLGarasi1.SelectedItem.Text.Trim());

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

        //protected void BtnUlangi_Click(object sender, EventArgs e)
        //{
        //    this.GetDataRumah(this.Session["NoDaftar"].ToString());

        //    this.BtnSave.Enabled = false;
        //    this.BtnSave.Visible = false;

        //    this.BtnUpdate.Enabled = true;
        //    this.BtnUpdate.Visible = true;
        //}

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDataSurveiRumah();
            LoadDataSurveiRumah();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiRumah() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiRumah();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaRumah();
            LoadDataLamaRumah();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaRumah() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaRumah();
            }
        }
    }
}