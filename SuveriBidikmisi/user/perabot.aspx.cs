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
    public partial class perabot : SuveriBidikmisi.user.user
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
                    this.GetDataPerabot(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiPerabot();
                }
            }
        }

        protected void GetDataPerabot(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_perabot.no_daftar, ukt_perabot.hrmjtamu, ukt_perabot.hralmari, ukt_perabot.hrmjtengah, ukt_perabot.hrmjmakan, ukt_perabot.hrnjteras, ukt_perabot.hrtmtidur, ukt_perabot.hrtv, ukt_perabot.hrkomp, ukt_perabot.hrdapur, ukt_perabot.hrmjrias FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN ukt_perabot ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_perabot.no_daftar WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
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
                            this.LbHargaMejaKursiRuangTamu.Text = reader["hrmjtamu"].ToString().Trim();
                            this.LbHargaAlmarBifet.Text = reader["hralmari"].ToString().Trim();
                            this.LbHargaMejaKursiRuangTengah.Text = reader["hrmjtengah"].ToString().Trim();
                            this.LbHargaMejaKursiRuangMakan.Text = reader["hrmjmakan"].ToString().Trim();
                            this.LbHargaMejaKursiTeras.Text = reader["hrnjteras"].ToString().Trim();
                            this.LbHargaTempatTidur.Text = reader["hrtmtidur"].ToString().Trim();
                            this.LbHargaTV.Text = reader["hrtv"].ToString().Trim();
                            this.LbHargaKomputerLaptop.Text = reader["hrkomp"].ToString().Trim();
                            this.LbHargaPeralatanDapur.Text = reader["hrdapur"].ToString().Trim();
                            this.LbHargaMejaRias.Text = reader["hrmjrias"].ToString().Trim();
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
            SaveDataSurveiPerabot();
            LoadDataSurveiPerabot();
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

                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_perabot_bm (no_daftar,hrmjtamu,hralmari,hrmjtengah,hrmjmakan,hrnjteras,hrtmtidur,hrtv,hrkomp,hrdapur,hrmjrias,nilai,tahun) "+
                                                    "VALUES (@no_daftar,@hrmjtamu,@hralmari,@hrmjtengah,@hrmjmakan,@hrnjteras,@hrtmtidur,@hrtv,@hrkomp,@hrdapur,@hrmjrias,@nilai,@tahun) ", con);
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

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_perabot_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLBeliMKTamu.SelectedItem.Text = rdr["hrmjtamu"].ToString().Trim();
                                this.DLAlmariBft.SelectedItem.Text = rdr["hralmari"].ToString().Trim();
                                this.DLMKRuangTengah.SelectedItem.Text = rdr["hrmjtengah"].ToString().Trim();
                                this.DLMKRuangMakan.SelectedItem.Text = rdr["hrmjmakan"].ToString().Trim();
                                this.DLMKRuangTeras.SelectedItem.Text = rdr["hrnjteras"].ToString().Trim();
                                this.DLTmpTidur.SelectedItem.Text = rdr["hrtmtidur"].ToString().Trim();
                                this.DLTV.SelectedItem.Text = rdr["hrtv"].ToString().Trim();
                                this.DLKomp.SelectedItem.Text = rdr["hrkomp"].ToString().Trim();
                                this.DLPerabotDapur.SelectedItem.Text = rdr["hrdapur"].ToString().Trim();
                                this.DLMejaRias.SelectedItem.Text = rdr["hrmjrias"].ToString().Trim();

                            }


                            this.LbMsgPerabot.Text = "Data sudah tesimpan";
                            this.LbMsgPerabot.ForeColor = System.Drawing.Color.Green;

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

        private bool UpdateDataSurveiLingkungan()
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

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG PERABOT GAGAL !";
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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_perabot_bm SET hrmjtamu=@hrmjtamu,hralmari=@hralmari,hrmjtengah=@hrmjtengah,hrmjmakan=@hrmjmakan,hrnjteras=@hrnjteras,hrtmtidur=@hrtmtidur,hrtv=@hrtv,hrkomp=@hrkomp,hrdapur=@hrdapur,hrmjrias=@hrmjrias,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);

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
                    this.LbMsgUpdate.Text = "UPDATE BORANG PERABOT GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataPerabot(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiLingkungan() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiPerabot();
            }
        }
    }
}