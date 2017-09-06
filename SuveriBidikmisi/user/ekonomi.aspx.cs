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
    public partial class ekonomi : SuveriBidikmisi.user.user
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
                    this.GetDataEkonomi(this.Session["NoDaftar"].ToString());

                    LoadDataSurveiEkonomi();
                }
            }
        }

        protected void GetDataEkonomi(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_ekonomi.no_daftar, ukt_ekonomi.pdptayah, ukt_ekonomi.pdptibu, ukt_ekonomi.htng, ukt_ekonomi.cicilan FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN  ukt_ekonomi ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_ekonomi.no_daftar  WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
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
                            this.LbPendapatanAyah.Text = reader["pdptayah"].ToString().Trim();
                            this.LbPendapatanIbu.Text = reader["pdptibu"].ToString().Trim();
                            this.LbHutangKeluarga.Text = reader["htng"].ToString().Trim();
                            this.LbCicilanHutang.Text = reader["cicilan"].ToString().Trim();
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
            SaveDataSurveiEkonomi();
            LoadDataSurveiEkonomi();
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

                    SqlCommand cmd = new SqlCommand("insert into ukt_ekonomi_bm (no_daftar,pdptayah,pdptibu,htng,cicilan,nilai,tahun) values (@no_daftar,@pdptayah,@pdptibu,@htng,@cicilan,@nilai,@tahun) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@htng", DLHutang.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan.SelectedItem.Text);
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

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_ekonomi_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLPendapatanAyah.SelectedItem.Text = rdr["pdptayah"].ToString().Trim();
                                this.DLPendapatanIbu.SelectedItem.Text = rdr["pdptibu"].ToString().Trim();
                                this.DLHutang.SelectedItem.Text = rdr["htng"].ToString().Trim();
                                this.DlCicilan.SelectedItem.Text = rdr["cicilan"].ToString().Trim();

                            }

                            this.LbMsgEkonomi.Text = "Data sudah tesimpan";
                            this.LbMsgEkonomi.ForeColor = System.Drawing.Color.Green;

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
                this.LbMsgUpdate.Text = "UPDATE BORANG EKONOMI GAGAL !";
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendapatanAyah.SelectedValue) +
                Convert.ToInt32(DLPendapatanIbu.SelectedValue) +
                Convert.ToInt32(DLHutang.SelectedValue) +
                Convert.ToInt32(DlCicilan.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_ekonomi_bm SET pdptayah=@pdptayah,pdptibu=@pdptibu,htng=@htng,cicilan=@cicilan,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@htng", DLHutang.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.LbMsgUpdate.Text = "UPDATE BORANG EKONOMI GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataEkonomi(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiEkonomi() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiEkonomi();
            }
        }
    }
}