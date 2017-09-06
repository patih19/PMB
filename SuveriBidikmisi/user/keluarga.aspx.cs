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
    public partial class keluarga : SuveriBidikmisi.user.user
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
                    this.GetDataKeluarga(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiKeluarga();
                }
            }
        }

        protected void GetDataKeluarga(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_keluarga.no_daftar, ukt_keluarga.orgrumah, ukt_keluarga.sdr, ukt_keluarga.sdrkuliah, ukt_keluarga.sdrsekolah FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN ukt_keluarga ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_keluarga.no_daftar WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
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
                            this.LbJumlahOrangSerumah.Text = reader["orgrumah"].ToString().Trim();
                            this.LbJumlahSaudara.Text = reader["sdr"].ToString().Trim();
                            this.LbJumlahSdrKuliah.Text = reader["sdrkuliah"].ToString().Trim();
                            this.LbJumSdrSekolah.Text = reader["sdrsekolah"].ToString().Trim();
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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_keluarga_bm (no_daftar,orgrumah,sdr,sdrkuliah,sdrsekolah,nilai,tahun) VALUES (@no_daftar,@orgrumah,@sdr,@sdrkuliah,@sdrsekolah,@nilai,@tahun)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@orgrumah", this.DLOrgRumah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdr", this.DLSdrKandung.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrkuliah", this.DLSdrKandungKuliah.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@sdrsekolah", this.DLSdrKandungSekolah.SelectedItem.Text.Trim());
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

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_keluarga_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLOrgRumah.SelectedItem.Text = rdr["orgrumah"].ToString().Trim();
                                this.DLSdrKandung.SelectedItem.Text = rdr["sdr"].ToString().Trim();
                                this.DLSdrKandungKuliah.SelectedItem.Text = rdr["sdrkuliah"].ToString().Trim();
                                this.DLSdrKandungSekolah.SelectedItem.Text = rdr["sdrsekolah"].ToString().Trim();
                            }


                            this.LbMsgKeluarga.Text = "Data sudah tesimpan";
                            this.LbMsgKeluarga.ForeColor = System.Drawing.Color.Green;

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

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG KELUARGA GAGAL !";
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLOrgRumah.SelectedValue) +
                        Convert.ToInt32(DLSdrKandung.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungKuliah.SelectedValue) +
                        Convert.ToInt32(DLSdrKandungSekolah.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_keluarga_bm SET orgrumah=@orgrumah,sdr=@sdr, sdrkuliah=@sdrkuliah,sdrsekolah=@sdrsekolah,nilai= @nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);

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
                    this.LbMsgUpdate.Text = "UPDATE BORANG KELUARGA GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataKeluarga(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiKeluarga() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiKeluarga();
            }
        }

    }
}