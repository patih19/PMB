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

namespace SuveriBidikmisi
{
    public partial class rumah : SuveriBidikmisi.user.user
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
                    base.Response.Redirect("~/user/home.aspx");
                }
                else
                {
                    this.GetDataRumah(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiRumah();
                }
            }
        }

        protected void GetDataRumah(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_rumah.no_daftar, ukt_rumah.stsrumah, ukt_rumah.smbrlistrik, ukt_rumah.dylistrik, ukt_rumah.bylistrik, ukt_rumah.sbair, ukt_rumah.byair, ukt_rumah.lstanah, ukt_rumah.lsbangunan, ukt_rumah.njop, ukt_rumah.atap, ukt_rumah.lantai, ukt_rumah.rgtenngah, ukt_rumah.dpr, ukt_rumah.cuci, ukt_rumah.mandi, ukt_rumah.teras, ukt_rumah.garasi, ukt_rumah.nilai FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN ukt_rumah ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_rumah.no_daftar WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
                {
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@npm", npm);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.LbStatusMilikRumah.Text = reader["stsrumah"].ToString().Trim();
                            this.LbSumberListrik.Text = reader["smbrlistrik"].ToString().Trim();
                            this.LbDayaListrik.Text = reader["dylistrik"].ToString().Trim();
                            this.LbBiayaListrikBulanan.Text = reader["bylistrik"].ToString().Trim();
                            this.LbSumberAir.Text = reader["sbair"].ToString().Trim();
                            this.LbBiayaAirBulanan.Text = reader["byair"].ToString().Trim();
                            this.LbLuasTanah.Text = reader["lstanah"].ToString().Trim();
                            this.LbLuasBangunan.Text = reader["lsbangunan"].ToString().Trim();
                            this.LbNJOP.Text = reader["njop"].ToString().Trim();
                            this.LbAtap.Text = reader["atap"].ToString().Trim();
                            this.LbLantaiRumah.Text = reader["lantai"].ToString().Trim();
                            this.LbRuangTengah.Text = reader["rgtenngah"].ToString().Trim();
                            this.LbDapur.Text = reader["dpr"].ToString().Trim();
                            this.LbCuciPiringGelas.Text = reader["cuci"].ToString().Trim();
                            this.LbKeperluanMandi.Text = reader["mandi"].ToString().Trim();
                            this.LbTeras.Text = reader["teras"].ToString().Trim();
                            this.LbGarasi.Text = reader["garasi"].ToString().Trim();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "ex", "alert('" + exception.Message.ToString() + "');", true);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDataSurveiRumah();
            LoadDataSurveiRumah();
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

            string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand CmdTahun = new SqlCommand("SELECT TOP (1) no, tahun, aktif " +
                                                        "FROM            ukt_tahun_aktif " +
                                                        "WHERE        (aktif = 'yes') " +
                                                        "ORDER BY tahun DESC", con);

                    CmdTahun.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader rdr = CmdTahun.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                tahun = rdr["tahun"].ToString().Trim();
                            }
                        }

                        rdr.Close();
                        rdr.Dispose();
                    }


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_rumah_bm (no_daftar,stsrumah,smbrlistrik,dylistrik,bylistrik,sbair,byair,lstanah,lsbangunan,njop,atap,lantai,rgtenngah,dpr,cuci,mandi,teras,garasi,nilai,tahun) "+
                                                    "VALUES (@no_daftar,@stsrumah,@smbrlistrik,@dylistrik,@bylistrik,@sbair,@byair,@lstanah,@lsbangunan,@njop,@atap,@lantai,@rgtenngah,@dpr,@cuci,@mandi,@teras,@garasi,@nilai,@tahun)", con);
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

                    cmd.Parameters.AddWithValue("@tahun", tahun);

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
            this.DLStatusRumah.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DlSmbrListrik.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKwh.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DlBiayaListrik.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSmbrAir.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLBiayaAir.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLsTanah.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLsBangunan.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLNJOP.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLAtap.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLLantai.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLRgTengah.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLDapur.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLCuci.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLKmMandi.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLTeras.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLGarasi.BorderColor  = System.Drawing.ColorTranslator.FromHtml("#ccc");



            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_rumah_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLStatusRumah.SelectedItem.Text = rdr["stsrumah"].ToString().Trim();
                                this.DlSmbrListrik.SelectedItem.Text = rdr["smbrlistrik"].ToString().Trim();
                                this.DLKwh.SelectedItem.Text = rdr["dylistrik"].ToString().Trim();
                                this.DlBiayaListrik.SelectedItem.Text = rdr["bylistrik"].ToString().Trim();
                                this.DLSmbrAir.SelectedItem.Text = rdr["sbair"].ToString().Trim();
                                this.DLBiayaAir.SelectedItem.Text = rdr["byair"].ToString().Trim();
                                this.DLLsTanah.SelectedItem.Text = rdr["lstanah"].ToString().Trim();
                                this.DLLsBangunan.SelectedItem.Text = rdr["lsbangunan"].ToString().Trim();
                                this.DLNJOP.SelectedItem.Text = rdr["njop"].ToString().Trim();
                                this.DLAtap.SelectedItem.Text = rdr["atap"].ToString().Trim();
                                this.DLLantai.Text = rdr["lantai"].ToString().Trim();
                                this.DLRgTengah.SelectedItem.Text = rdr["rgtenngah"].ToString().Trim();
                                this.DLDapur.SelectedItem.Text = rdr["dpr"].ToString().Trim();
                                this.DLCuci.SelectedItem.Text = rdr["cuci"].ToString().Trim();
                                this.DLKmMandi.SelectedItem.Text = rdr["mandi"].ToString().Trim();
                                this.DLTeras.SelectedItem.Text = rdr["teras"].ToString().Trim();
                                this.DLGarasi.SelectedItem.Text = rdr["garasi"].ToString().Trim();
                            }


                            this.LbMsgRumah.Text = "Data sudah tesimpan";
                            this.LbMsgRumah.ForeColor = System.Drawing.Color.Green;

                            this.PanelMsg.Enabled = true;
                            this.PanelMsg.Visible = true;

                            this.BtnSave.Enabled = false;
                            this.BtnSave.Visible = false;

                            this.BtnUpdate.Enabled = false;
                            this.BtnUpdate.Visible = false;
                        }
                        else
                        {
                            this.PanelMsg.Enabled = false;
                            this.PanelMsg.Visible = false;

                            this.BtnSave.Enabled = true;
                            this.BtnSave.Visible = true;

                            this.BtnUpdate.Enabled = false;
                            this.BtnUpdate.Visible = false;
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

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG RUMAH GAGAL !";
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

            string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand CmdTahun = new SqlCommand("SELECT TOP (1) no, tahun, aktif " +
                                                        "FROM            ukt_tahun_aktif " +
                                                        "WHERE        (aktif = 'yes') " +
                                                        "ORDER BY tahun DESC", con);

                    CmdTahun.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader rdr = CmdTahun.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                tahun = rdr["tahun"].ToString().Trim();
                            }
                        }

                        rdr.Close();
                        rdr.Dispose();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_rumah_bm set stsrumah=@stsrumah,smbrlistrik=@smbrlistrik,dylistrik=@dylistrik,bylistrik=@bylistrik,sbair=@sbair,byair=@byair,lstanah=@lstanah,lsbangunan=@lsbangunan,njop=@njop,atap=@atap,lantai=@lantai,rgtenngah=@rgtenngah,dpr=@dpr,cuci=@cuci,mandi=@mandi,teras=@teras,garasi=@garasi,nilai=@nilai,tahun=@tahun " +
                                                    "WHERE no_daftar=@no_daftar", con);

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

                    cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.LbMsgUpdate.Text = "UPDATE BORANG RUMAH GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataRumah(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiRumah() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiRumah();
            }
        }
    }
}