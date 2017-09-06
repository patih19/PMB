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
    public partial class aset : SuveriBidikmisi.user.user
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
                    base.Response.Redirect("~/");
                }
                else
                {
                    this.GetDataAset(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiAset();
                }
            }
        }

        protected void GetDataAset(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_harta.no_daftar, ukt_harta.sawah, ukt_harta.tanah, ukt_harta.ternak, ukt_harta.mobil, ukt_harta.tabungan, ukt_harta.hiasan, ukt_harta.sepeda FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN ukt_harta ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_harta.no_daftar  WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
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
                            this.LbSawah.Text = reader["sawah"].ToString().Trim();
                            this.LbLadangKebun.Text = reader["tanah"].ToString().Trim();
                            this.LbTernak.Text = reader["ternak"].ToString().Trim();
                            this.LbMobil.Text = reader["mobil"].ToString().Trim();
                            this.LbTabungan.Text = reader["tabungan"].ToString().Trim();
                            this.LbPerhiasan.Text = reader["hiasan"].ToString().Trim();
                            this.LbSepedaMotor.Text = reader["sepeda"].ToString().Trim();
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
            SaveDataSurveiAset();
            LoadDataSurveiAset();
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

                    SqlCommand cmd = new SqlCommand(" INSERT INTO ukt_harta_bm (no_daftar,sawah,tanah,ternak,mobil,tabungan,hiasan,sepeda,nilai,tahun) "+
                                                    " VALUES (@no_daftar,@sawah,@tanah,@ternak,@mobil,@tabungan,@hiasan,@sepeda,@nilai,@tahun)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tanah", DLTanah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ternak", DLternak.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@mobil", DLmobil.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sepeda", DLSepeda.SelectedItem.Text);
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

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_harta_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLSawah.SelectedItem.Text = rdr["sawah"].ToString().Trim();
                                this.DLTanah.SelectedItem.Text = rdr["tanah"].ToString().Trim();
                                this.DLternak.SelectedItem.Text = rdr["ternak"].ToString().Trim();
                                this.DLmobil.SelectedItem.Text = rdr["mobil"].ToString().Trim();
                                this.DLGiro.SelectedItem.Text = rdr["tabungan"].ToString().Trim();
                                this.DLPerhiasan.SelectedItem.Text = rdr["hiasan"].ToString().Trim();
                                this.DLSepeda.SelectedItem.Text = rdr["sepeda"].ToString().Trim();

                            }

                            this.LbMsgAset.Text = "Data sudah tesimpan";
                            this.LbMsgAset.ForeColor = System.Drawing.Color.Green;

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

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG ASET GAGAL !";
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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_harta_bm SET no_daftar=@no_daftar,sawah=@sawah,tanah=@tanah,ternak=@ternak,mobil=@mobil,tabungan=@tabungan,hiasan=@hiasan,sepeda=@sepeda,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tanah", DLTanah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ternak", DLternak.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@mobil", DLmobil.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sepeda", DLSepeda.SelectedItem.Text);
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.LbMsgUpdate.Text = "UPDATE BORANG ASET GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataAset(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiAset() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiAset();
            }
        }

    }
}