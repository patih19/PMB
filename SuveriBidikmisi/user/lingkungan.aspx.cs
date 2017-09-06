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
    public partial class lingkungan : SuveriBidikmisi.user.user
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
                    this.GetDataLingkungan(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiLingkungan();
                }
            }
        }

        protected void GetDataLingkungan(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_lingkungan.no_daftar, ukt_lingkungan.lstaman, ukt_lingkungan.pagar, ukt_lingkungan.jlnmasuk, ukt_lingkungan.selokan, ukt_lingkungan.nilai FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN ukt_lingkungan ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_lingkungan.no_daftar WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
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
                            this.LbLuasTaman.Text = reader["lstaman"].ToString().Trim();
                            this.LbPagar.Text = reader["pagar"].ToString().Trim();
                            this.LbJalanMasuk.Text = reader["jlnmasuk"].ToString().Trim();
                            this.LbSelokan.Text = reader["selokan"].ToString().Trim();
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
            SaveDataSurveiLingkungan();
            LoadDataSurveiLingkungan();
        }

        protected void SaveDataSurveiLingkungan()
        {
            if (this.DLLuasTaman.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi luas taman');", true);
                return;
            }
            if (this.DLPagar.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi pagar');", true);
                return;
            }
            if (this.DLJalanMasuk.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi jalan masuk');", true);
                return;
            }
            if (this.DLSelokan.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi selokan air');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLLuasTaman.SelectedValue) +
                        Convert.ToInt32(DLPagar.SelectedValue) +
                        Convert.ToInt32(DLJalanMasuk.SelectedValue) +
                        Convert.ToInt32(DLSelokan.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_lingkungan_bm (no_daftar,lstaman,pagar,jlnmasuk,selokan,nilai,tahun) "+
                                                    "VALUES (@no_daftar,@lstaman,@pagar,@jlnmasuk,@selokan,@nilai,@tahun) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@lstaman", DLLuasTaman.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pagar", DLPagar.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jlnmasuk", DLJalanMasuk.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@selokan", DLSelokan.SelectedItem.Text);
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

        protected void LoadDataSurveiLingkungan()
        {
            this.DLLuasTaman.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPagar.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLJalanMasuk.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSelokan.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_lingkungan_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLLuasTaman.SelectedItem.Text = rdr["lstaman"].ToString().Trim();
                                this.DLPagar.SelectedItem.Text = rdr["pagar"].ToString().Trim();
                                this.DLJalanMasuk.SelectedItem.Text = rdr["jlnmasuk"].ToString().Trim();
                                this.DLSelokan.SelectedItem.Text = rdr["selokan"].ToString().Trim();
                            }


                            this.LbMsgLingkungan.Text = "Data sudah tesimpan";
                            this.LbMsgLingkungan.ForeColor = System.Drawing.Color.Green;

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

            if (this.DLLuasTaman.SelectedValue == "-1")
            {
                this.DLLuasTaman.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPagar.SelectedValue == "-1")
            {
                this.DLPagar.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLJalanMasuk.SelectedValue == "-1")
            {
                this.DLJalanMasuk.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSelokan.SelectedValue == "-1")
            {
                this.DLSelokan.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG LINGKUNGAN GAGAL !";
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLLuasTaman.SelectedValue) +
                        Convert.ToInt32(DLPagar.SelectedValue) +
                        Convert.ToInt32(DLJalanMasuk.SelectedValue) +
                        Convert.ToInt32(DLSelokan.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_lingkungan_bm SET lstaman=@lstaman,pagar=@pagar,jlnmasuk=@jlnmasuk,selokan=@selokan,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@lstaman", DLLuasTaman.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pagar", DLPagar.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jlnmasuk", DLJalanMasuk.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@selokan", DLSelokan.SelectedItem.Text);
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.LbMsgUpdate.Text = "UPDATE BORANG LINGKUNGAN GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataLingkungan(this.Session["NoDaftar"].ToString());

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
                LoadDataSurveiLingkungan();
            }
        }

    }
}