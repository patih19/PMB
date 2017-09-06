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
    public partial class Pribadi : SuveriBidikmisi.user.user
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
                    LoadDataSurveiPribadi();
                }
                else if (string.IsNullOrEmpty(base.Request.QueryString["npm"]))
                {
                    this.GetDataPribadi(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiPribadi();
                }
                else
                {
                    this.Session["NoDaftar"] = null;
                    this.Session.Remove("NoDaftar");
                    this.Session["NoDaftar"] = base.Request.QueryString["npm"].ToString().Trim();
                    this.GetDataPribadi(this.Session["NoDaftar"].ToString());
                    LoadDataSurveiPribadi();
                }

                //Response.Write(this.Session["NoDaftar"].ToString());
            }
        }

        protected void GetDataPribadi(string npm)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_pribadi.no_daftar,ukt_pribadi.nama, ukt_pribadi.gender, ukt_pribadi.tmplahir, ukt_pribadi.tglahir, ukt_pribadi.alamat, ukt_pribadi.hp, ukt_pribadi.telp, ukt_pribadi.email, ukt_pribadi.ayah, ukt_pribadi.stayah, ukt_pribadi.pdayah, ukt_pribadi.kerjaayah, ukt_pribadi.modalayah, ukt_pribadi.labaayah, ukt_pribadi.ibu, ukt_pribadi.stibu, ukt_pribadi.pdibu, ukt_pribadi.kerjaibu, ukt_pribadi.modalibu, ukt_pribadi.labaibu FROM            ukt_pribadi INNER JOIN UntidarDb.dbo.bak_mahasiswa ON ukt_pribadi.no_daftar = UntidarDb.dbo.bak_mahasiswa.no_daftar WHERE        (UntidarDb.dbo.bak_mahasiswa.npm = @npm)", connection)
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
                            this.LbNama.Text = reader["nama"].ToString().Trim();
                            this.LbNama2.Text = reader["nama"].ToString().Trim();

                            this.LbGender.Text = reader["gender"].ToString().Trim();
                            this.LbGender2.Text = reader["gender"].ToString().Trim();

                            this.LbTempatLahir.Text = reader["tmplahir"].ToString().Trim();
                            this.LbTempatLahir2.Text = reader["tmplahir"].ToString().Trim();

                            this.LbTanggalLahir.Text = DateTime.Parse(reader["tglahir"].ToString()).ToString("dd-MMMM-yyyy");
                            this.LbTanggalLahir2.Text = DateTime.Parse(reader["tglahir"].ToString()).ToString("yyyy-MM-dd");

                            this.TbAlamat.Text = reader["alamat"].ToString().Trim();
                            this.TbAlamat2.Text = reader["alamat"].ToString().Trim();

                            this.LbHp.Text = reader["hp"].ToString().Trim();
                            this.TbHp2.Text = reader["hp"].ToString().Trim();

                            this.LbTelpRumah.Text = reader["telp"].ToString().Trim();
                            this.TbTelpRumah2.Text = reader["telp"].ToString().Trim();

                            this.LbEmail.Text = reader["email"].ToString().Trim();
                            this.TbEmail2.Text = reader["email"].ToString().Trim();

                            this.LbNamaAyah.Text = reader["ayah"].ToString().Trim();
                            this.LbNamaAyah2.Text = reader["ayah"].ToString().Trim();

                            this.LbStatusAyah.Text = reader["stayah"].ToString().Trim();
                            this.LbPendidikanAyah.Text = reader["pdayah"].ToString().Trim();
                            this.LbPekerjaanAyah.Text = reader["kerjaayah"].ToString().Trim();
                            this.LbModalUsahaAyah.Text = reader["modalayah"].ToString().Trim();
                            this.LbLabaAyah.Text = reader["labaayah"].ToString().Trim();

                            this.LbNamaIbu.Text = reader["ibu"].ToString().Trim();
                            this.LbNamaIbu2.Text = reader["ibu"].ToString().Trim();

                            this.LbStatusIbu.Text = reader["stibu"].ToString().Trim();
                            this.LbPendidikanIbu.Text = reader["pdibu"].ToString().Trim();
                            this.LbPekerjaanIbu.Text = reader["kerjaibu"].ToString().Trim();
                            this.LbModalUsahaIbu.Text = reader["modalibu"].ToString().Trim();
                            this.LbLabaIbu.Text = reader["labaibu"].ToString().Trim();
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


                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_pribadi_bm (no_daftar,nama,gender,alamat,tmplahir,tglahir,email,hp,telp,ayah,stayah,pdayah,kerjaayah, modalayah, labaayah, ibu,stibu,pdibu,kerjaibu,modalibu,labaibu,nilai,tahun ) " +
                                                    "VALUES (@no_daftar,@nama,@gender,@alamat,@tmplahir,@tglahir,@email,@hp,@telp,@ayah,@stayah,@pdayah,@kerjaayah, @modalayah, @labaayah, @ibu, @stibu,@pdibu,@kerjaibu,@modalibu,@labaibu,@nilai,@tahun)", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@nama", this.LbNama2.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", this.LbGender2.Text.Trim());
                    cmd.Parameters.AddWithValue("@alamat", this.TbAlamat2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tmplahir", this.LbTempatLahir2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tglahir", this.LbTanggalLahir2.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", this.TbEmail2.Text.Trim());
                    cmd.Parameters.AddWithValue("@hp", this.TbHp2.Text);
                    cmd.Parameters.AddWithValue("@telp", this.TbTelpRumah2.Text.Trim());
                    cmd.Parameters.AddWithValue("@ayah", this.LbNamaAyah2.Text.Trim());
                    cmd.Parameters.AddWithValue("@stayah", this.DlStAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", this.DLPendidikanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalayah", this.DLModalAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", this.DLLabaAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ibu", this.LbNamaIbu2.Text);
                    cmd.Parameters.AddWithValue("@stibu", this.DLStatausIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdibu", this.DLPendidikanIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaibu", this.DLKerjaanIbu.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalibu", this.DLModalIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaibu", this.DLLabaIbu.SelectedItem.Text);
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

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_pribadi_bm WHERE no_daftar=@no_daftar", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                //DlStAyah.Attributes.Add("style", "background-color: red");

                                this.LbNama2.Text = rdr["nama"].ToString().Trim();
                                this.LbGender2.Text = rdr["gender"].ToString().Trim();
                                this.LbTempatLahir2.Text = rdr["tmplahir"].ToString().Trim();

                                DateTime dt = DateTime.Parse(rdr["tglahir"].ToString());
                                this.LbTanggalLahir2.Text = dt.ToString("dd-MMMM-yyyy");

                                this.TbAlamat2.Text = rdr["alamat"].ToString().Trim();
                                this.TbHp2.Text = rdr["hp"].ToString().Trim();
                                this.TbTelpRumah2.Text = rdr["telp"].ToString().Trim();

                                this.LbNamaAyah2.Text = rdr["ayah"].ToString().Trim();
                                this.DlStAyah.SelectedItem.Text = rdr["stayah"].ToString().Trim();
                                this.DLPendidikanAyah.SelectedItem.Text = rdr["pdayah"].ToString().Trim();
                                this.DLKerjaanAyah.SelectedItem.Text = rdr["kerjaayah"].ToString().Trim();
                                this.DLModalAyah.SelectedItem.Text = rdr["modalayah"].ToString().Trim();
                                this.DLLabaAyah.SelectedItem.Text = rdr["labaayah"].ToString().Trim();

                                this.LbNamaIbu2.Text = rdr["ibu"].ToString().Trim();
                                this.DLStatausIbu.SelectedItem.Text = rdr["stibu"].ToString().Trim();
                                this.DLPendidikanIbu.SelectedItem.Text = rdr["pdibu"].ToString().Trim();
                                this.DLKerjaanIbu.SelectedItem.Text = rdr["kerjaibu"].ToString().Trim();
                                this.DLModalIbu.SelectedItem.Text = rdr["modalibu"].ToString().Trim();
                                this.DLLabaIbu.SelectedItem.Text = rdr["labaibu"].ToString().Trim();
                            }


                            this.LbMsgPribadi.Text = "Data sudah tesimpan";
                            this.LbMsgPribadi.ForeColor = System.Drawing.Color.Green;

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
                this.BtnUpdate.Visible = true;
                this.BtnUpdate.Enabled = true;

                //Response.Write("return");
                this.LbMsgUpdate.Text = "UPDATE BORANG PRIBADI GAGAL !";
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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_pribadi_bm SET nama=@nama,gender=@gender,alamat=@alamat,tmplahir=@tmplahir,tglahir=@tglahir,email=@email,hp=@hp,telp=@telp,ayah=@ayah,stayah=@stayah,pdayah=@pdayah,kerjaayah=@kerjaayah, modalayah=@modalayah, labaayah=@labaayah, ibu=@ibu,stibu=@stibu,pdibu=@pdibu,kerjaibu=@kerjaibu,modalibu=@modalibu,labaibu=@labaibu,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@nama", this.LbNama2.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", this.LbGender2.Text.Trim());
                    cmd.Parameters.AddWithValue("@alamat", this.TbAlamat2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tmplahir", this.LbTempatLahir2.Text.Trim());
                    cmd.Parameters.AddWithValue("@tglahir", this.LbTanggalLahir2.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", this.TbEmail2.Text.Trim());
                    cmd.Parameters.AddWithValue("@hp", this.TbHp2.Text);
                    cmd.Parameters.AddWithValue("@telp", this.TbTelpRumah2.Text.Trim());
                    cmd.Parameters.AddWithValue("@ayah", this.LbNamaAyah2.Text.Trim());

                    cmd.Parameters.AddWithValue("@stayah", this.DlStAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", this.DLPendidikanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah.SelectedItem.Text.ToString());
                    
                    cmd.Parameters.AddWithValue("@modalayah", this.DLModalAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", this.DLLabaAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ibu", this.LbNamaIbu2.Text);
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
                    this.LbMsgUpdate.Text = "UPDATE BORANG PRIBADI GAGAL !";
                    Response.Write(ex.Message.ToString());
                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }
        }

        protected void BtnUlangi_Click(object sender, EventArgs e)
        {
            this.GetDataPribadi(this.Session["NoDaftar"].ToString());

            this.BtnSave.Enabled = false;
            this.BtnSave.Visible = false;

            this.BtnUpdate.Enabled = true;
            this.BtnUpdate.Visible = true;

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            if (UpdateDataSurveiPribadi() == true)
            {
                this.LbMsgUpdate.Text = "";
                LoadDataSurveiPribadi();
            }
        }

    }
}