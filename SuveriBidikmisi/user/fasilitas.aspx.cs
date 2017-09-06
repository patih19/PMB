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
    public partial class Fasilitas : SuveriBidikmisi.user.user
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
                    this.GetDataFasilitas(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiFasilitas();
                }
            }
        }

        protected void GetDataFasilitas(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_falilitas.no_daftar, ukt_falilitas.bytelphp, ukt_falilitas.byint FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN  ukt_falilitas ON UntidarDb.dbo.bak_mahasiswa.no_daftar = ukt_falilitas.no_daftar WHERE (UntidarDb.dbo.bak_mahasiswa.npm =@npm)", connection)
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
                            this.LbBiayaTelpDanHp.Text = reader["bytelphp"].ToString().Trim();
                            this.LbBiayaInternet.Text = reader["byint"].ToString().Trim();
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
            SaveDataSurveiFasilitas();
            LoadDataSurveiFasilitas();
        }

        protected void SaveDataSurveiFasilitas()
        {
            if (this.DLTelepon.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata biaya telepon & pulsa handphone per bulan sekeluarga');", true);
                return;
            }
            if (this.DLInternet.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Rata-rata biaya internet per bulan sekeluarga');", true);
                return;
            }


            // Get Nilai 
            // Get Nilai 
            int Nilai = Convert.ToInt32(DLTelepon.SelectedValue) +
                Convert.ToInt32(DLInternet.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("insert into ukt_falilitas_bm (no_daftar,bytelphp,byint,nilai,tahun) " +
                                                    "values (@no_daftar,@bytelphp,@byint,@nilai,@tahun) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@bytelphp", DLTelepon.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@byint", DLInternet.SelectedItem.Text);
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

        protected void LoadDataSurveiFasilitas()
        {
            this.DLTelepon.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLInternet.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_falilitas_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLTelepon.SelectedItem.Text = rdr["bytelphp"].ToString().Trim();
                                this.DLInternet.SelectedItem.Text = rdr["byint"].ToString().Trim();

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

        private bool UpdateDataSurveiFasilitas()
        {

            int error = 0;

            if (this.DLInternet.SelectedValue == "-1")
            {
                this.DLInternet.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLTelepon.SelectedValue == "-1")
            {
                this.DLTelepon.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }


            if (error == 1)
            {
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG FASILITAS GAGAL !";
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLTelepon.SelectedValue) +
                Convert.ToInt32(DLInternet.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_falilitas_bm set bytelphp=@bytelphp,byint=@byint,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@bytelphp", DLTelepon.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@byint", DLInternet.SelectedItem.Text);

                    //cmd.Parameters.AddWithValue("@tahun", tahun);


                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    this.LbMsgUpdate.Text = "UPDATE BORANG FASILITAS GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataFasilitas(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiFasilitas() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiFasilitas();
            }
        }
    }
}