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
    public partial class Lingkungan : User
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
                    this.GetDataLingkungan(this.Session["NoDaftar"].ToString());                   
                }
            }
        }

        protected void GetDataLingkungan(string npm)
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
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_lingkungan_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_lingkungan WHERE no_daftar=@no_daftar", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", NoDaftar);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");
                                    this.DLLuasTaman1.SelectedIndex = DLLuasTaman1.Items.IndexOf(DLLuasTaman1.Items.FindByText(rdr["lstaman"].ToString().Trim()));
                                    this.DLPagar1.SelectedIndex = DLPagar1.Items.IndexOf(DLPagar1.Items.FindByText(rdr["pagar"].ToString().Trim()));
                                    this.DLJalanMasuk1.SelectedIndex = DLJalanMasuk1.Items.IndexOf(DLJalanMasuk1.Items.FindByText(rdr["jlnmasuk"].ToString().Trim()));
                                    this.DLSelokan1.SelectedIndex = DLSelokan1.Items.IndexOf(DLSelokan1.Items.FindByText(rdr["selokan"].ToString().Trim()));
                                }

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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_lingkungan_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLLuasTaman1.SelectedIndex = DLLuasTaman1.Items.IndexOf(DLLuasTaman1.Items.FindByText(rdr["lstaman"].ToString().Trim()));
                                    this.DLPagar1.SelectedIndex = DLPagar1.Items.IndexOf(DLPagar1.Items.FindByText(rdr["pagar"].ToString().Trim()));
                                    this.DLJalanMasuk1.SelectedIndex = DLJalanMasuk1.Items.IndexOf(DLJalanMasuk1.Items.FindByText(rdr["jlnmasuk"].ToString().Trim()));
                                    this.DLSelokan1.SelectedIndex = DLSelokan1.Items.IndexOf(DLSelokan1.Items.FindByText(rdr["selokan"].ToString().Trim()));

                                }

                                this.LbMsgLingkungan1.Text = "Data sudah tesimpan";
                                this.LbMsgLingkungan1.ForeColor = System.Drawing.Color.Green;

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

            //---- GET DATA BARU (BANDING) ----//
            string StrPribadiBanding = "";
            string CS3 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS3))
            {
                try
                {
                    con.Open();

                    // ----- Cek Input Borang Pribadi ----- //
                    SqlCommand CekPribadi = new SqlCommand("SELECT no_daftar FROM ukt_lingkungan_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
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
                        SqlCommand PribadiAsli = new SqlCommand("SELECT * FROM ukt_lingkungan_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                        PribadiAsli.CommandType = System.Data.CommandType.Text;
                        PribadiAsli.Parameters.AddWithValue("@no_daftar", npm);

                        using (SqlDataReader rdr = PribadiAsli.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    //DlStAyah.Attributes.Add("style", "background-color: red");

                                    this.DLLuasTaman.SelectedIndex = DLLuasTaman.Items.IndexOf(DLLuasTaman.Items.FindByText(rdr["lstaman"].ToString().Trim()));
                                    this.DLPagar.SelectedIndex = DLPagar.Items.IndexOf(DLPagar.Items.FindByText(rdr["pagar"].ToString().Trim()));
                                    this.DLJalanMasuk.SelectedIndex = DLJalanMasuk.Items.IndexOf(DLJalanMasuk.Items.FindByText(rdr["jlnmasuk"].ToString().Trim()));
                                    this.DLSelokan.SelectedIndex = DLSelokan.Items.IndexOf(DLSelokan.Items.FindByText(rdr["selokan"].ToString().Trim()));
                                }

                                this.LbMsgLingkungan.Text = "Data sudah tesimpan";
                                this.LbMsgLingkungan.ForeColor = System.Drawing.Color.Green;

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

                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_lingkungan_banding (no_daftar,lstaman,pagar,jlnmasuk,selokan,nilai,data_banding) " +
                                                    "VALUES (@no_daftar,@lstaman,@pagar,@jlnmasuk,@selokan,@nilai,@data_banding) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@lstaman", DLLuasTaman.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pagar", DLPagar.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jlnmasuk", DLJalanMasuk.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@selokan", DLSelokan.SelectedItem.Text);
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

        protected void SaveDataLamaLingkungan()
        {
            if (this.DLLuasTaman1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi luas taman');", true);
                return;
            }
            if (this.DLPagar1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi pagar');", true);
                return;
            }
            if (this.DLJalanMasuk1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi jalan masuk');", true);
                return;
            }
            if (this.DLSelokan1.SelectedValue == "-1")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi selokan air');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLLuasTaman1.SelectedValue) +
                        Convert.ToInt32(DLPagar1.SelectedValue) +
                        Convert.ToInt32(DLJalanMasuk1.SelectedValue) +
                        Convert.ToInt32(DLSelokan1.SelectedValue);

            //string tahun = "";

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO ukt_lingkungan_banding (no_daftar,lstaman,pagar,jlnmasuk,selokan,nilai,data_banding) " +
                                                    "VALUES (@no_daftar,@lstaman,@pagar,@jlnmasuk,@selokan,@nilai,@data_banding) ", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@lstaman", DLLuasTaman1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pagar", DLPagar1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jlnmasuk", DLJalanMasuk1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@selokan", DLSelokan1.SelectedItem.Text);
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

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_lingkungan_banding WHERE no_daftar=@no_daftar AND data_banding='banding'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLLuasTaman.SelectedIndex = DLLuasTaman.Items.IndexOf(DLLuasTaman.Items.FindByText(rdr["lstaman"].ToString().Trim()));
                                this.DLPagar.SelectedIndex = DLPagar.Items.IndexOf(DLPagar.Items.FindByText(rdr["pagar"].ToString().Trim()));
                                this.DLJalanMasuk.SelectedIndex = DLJalanMasuk.Items.IndexOf(DLJalanMasuk.Items.FindByText(rdr["jlnmasuk"].ToString().Trim()));
                                this.DLSelokan.SelectedIndex = DLSelokan.Items.IndexOf(DLSelokan.Items.FindByText(rdr["selokan"].ToString().Trim()));
                            }

                            this.LbMsgLingkungan.Text = "Data sudah tesimpan";
                            this.LbMsgLingkungan.ForeColor = System.Drawing.Color.Green;

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

        protected void LoadDataLamaLingkungan()
        {
            this.DLLuasTaman1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLPagar1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLJalanMasuk1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
            this.DLSelokan1.BorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_lingkungan_banding WHERE no_daftar=@no_daftar AND data_banding='lama'", con);
                    Pribadi.CommandType = System.Data.CommandType.Text;
                    Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = Pribadi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.DLLuasTaman1.SelectedIndex = DLLuasTaman1.Items.IndexOf(DLLuasTaman1.Items.FindByText(rdr["lstaman"].ToString().Trim()));
                                this.DLPagar1.SelectedIndex = DLPagar1.Items.IndexOf(DLPagar1.Items.FindByText(rdr["pagar"].ToString().Trim()));
                                this.DLJalanMasuk1.SelectedIndex = DLJalanMasuk1.Items.IndexOf(DLJalanMasuk1.Items.FindByText(rdr["jlnmasuk"].ToString().Trim()));
                                this.DLSelokan1.SelectedIndex = DLSelokan1.Items.IndexOf(DLSelokan1.Items.FindByText(rdr["selokan"].ToString().Trim()));
                            }

                            this.LbMsgLingkungan1.Text = "Data sudah tesimpan";
                            this.LbMsgLingkungan1.ForeColor = System.Drawing.Color.Green;

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
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLLuasTaman.SelectedValue) +
                        Convert.ToInt32(DLPagar.SelectedValue) +
                        Convert.ToInt32(DLJalanMasuk.SelectedValue) +
                        Convert.ToInt32(DLSelokan.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_lingkungan_banding SET lstaman=@lstaman,pagar=@pagar,jlnmasuk=@jlnmasuk,selokan=@selokan,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='banding'", con);

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
                    Response.Write(ex.Message.ToString());
                    return false;
                }
            }
        }

        private bool UpdateDataLamaLingkungan()
        {

            int error = 0;

            if (this.DLLuasTaman1.SelectedValue == "-1")
            {
                this.DLLuasTaman1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLPagar1.SelectedValue == "-1")
            {
                this.DLPagar1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLJalanMasuk1.SelectedValue == "-1")
            {
                this.DLJalanMasuk1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }
            if (this.DLSelokan1.SelectedValue == "-1")
            {
                this.DLSelokan1.BorderColor = System.Drawing.Color.Pink;
                error = 1;
            }

            if (error == 1)
            {
                this.BtnUpdate1.Visible = true;
                this.BtnUpdate1.Enabled = true;
                return false;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLLuasTaman1.SelectedValue) +
                        Convert.ToInt32(DLPagar1.SelectedValue) +
                        Convert.ToInt32(DLJalanMasuk1.SelectedValue) +
                        Convert.ToInt32(DLSelokan1.SelectedValue);

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

                    SqlCommand cmd = new SqlCommand("UPDATE ukt_lingkungan_banding SET lstaman=@lstaman,pagar=@pagar,jlnmasuk=@jlnmasuk,selokan=@selokan,nilai=@nilai " +
                                                    "WHERE no_daftar=@no_daftar AND data_banding='lama'", con);

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@lstaman", DLLuasTaman1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pagar", DLPagar1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jlnmasuk", DLJalanMasuk1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@selokan", DLSelokan1.SelectedItem.Text);
                    //cmd.Parameters.AddWithValue("@tahun", tahun);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    return false;
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SaveDataSurveiLingkungan();
            LoadDataSurveiLingkungan();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDataSurveiLingkungan() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataSurveiLingkungan();
            }
        }

        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            SaveDataLamaLingkungan();
            LoadDataLamaLingkungan();
        }

        protected void BtnUpdate1_Click(object sender, EventArgs e)
        {
            if (UpdateDataLamaLingkungan() == true)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Update berhasil');", true);
                LoadDataLamaLingkungan();
            }
        }
    }
}