using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace smuntidar
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        // prevent back after login on page init
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["Name"] == null && this.Session["password"] == null)
            {

            }
            else
            {
                Response.Redirect("~/user/home.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // ---- avoid back after logout -----
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            // --- End aviod back after logout -------

            if (Page.IsPostBack) // user must login first
            {
                if (this.Session["Name"] != null && this.Session["password"] != null)
                {
                    Response.Redirect("~/user/home.aspx");
                }
                else
                {
                    return;
                }
            }

            if (!Page.IsPostBack)
            {

                //Response.Redirect("http://untidar.ac.id");

                try
                {
                    //-----------------------------------Cek Kelenngkapan Berkas -----------------------------------------------
                    string CS1 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS1))
                    {
                        con.Open();
                        //SqlTransaction trans = con.BeginTransaction();

                        SqlCommand Cmdstatistik = new SqlCommand("SpStatistik", con);
                        //CmdPeriodik.Transaction = trans;
                        Cmdstatistik.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter Pendaftar = new SqlParameter();
                        Pendaftar.ParameterName = "@pendaftar";
                        Pendaftar.SqlDbType = System.Data.SqlDbType.Int;
                        Pendaftar.Direction = System.Data.ParameterDirection.Output;
                        Pendaftar.Size = 5;
                        Cmdstatistik.Parameters.Add(Pendaftar);


                        SqlParameter Kota = new SqlParameter();
                        Kota.ParameterName = "@kota";
                        Kota.SqlDbType = System.Data.SqlDbType.Int;
                        Kota.Direction = System.Data.ParameterDirection.Output;
                        Kota.Size = 5;
                        Cmdstatistik.Parameters.Add(Kota);

                        SqlParameter LuarKota = new SqlParameter();
                        LuarKota.ParameterName = "@luarkota";
                        LuarKota.SqlDbType = System.Data.SqlDbType.Int;
                        LuarKota.Direction = System.Data.ParameterDirection.Output;
                        LuarKota.Size = 5;
                        Cmdstatistik.Parameters.Add(LuarKota);

                        SqlParameter Lelaki = new SqlParameter();
                        Lelaki.ParameterName = "@lelaki";
                        Lelaki.SqlDbType = System.Data.SqlDbType.Int;
                        Lelaki.Direction = System.Data.ParameterDirection.Output;
                        Lelaki.Size = 5;
                        Cmdstatistik.Parameters.Add(Lelaki);

                        SqlParameter Perempuan = new SqlParameter();
                        Perempuan.ParameterName = "@perempuan";
                        Perempuan.SqlDbType = System.Data.SqlDbType.Int;
                        Perempuan.Direction = System.Data.ParameterDirection.Output;
                        Perempuan.Size = 5;
                        Cmdstatistik.Parameters.Add(Perempuan);

                        SqlParameter SMA = new SqlParameter();
                        SMA.ParameterName = "@SMA";
                        SMA.SqlDbType = System.Data.SqlDbType.Int;
                        SMA.Direction = System.Data.ParameterDirection.Output;
                        SMA.Size = 5;
                        Cmdstatistik.Parameters.Add(SMA);

                        SqlParameter SMK = new SqlParameter();
                        SMK.ParameterName = "@SMK";
                        SMK.SqlDbType = System.Data.SqlDbType.Int;
                        SMK.Direction = System.Data.ParameterDirection.Output;
                        SMK.Size = 5;
                        Cmdstatistik.Parameters.Add(SMK);

                        Cmdstatistik.ExecuteNonQuery();

                        this.LbPendaftar.Text = Pendaftar.Value.ToString();
                        this.LbDalamKota.Text = Kota.Value.ToString();
                        this.LbLuarKota.Text = LuarKota.Value.ToString();
                        this.LbLelaki.Text = Lelaki.Value.ToString();
                        this.LbPerempuan.Text = Perempuan.Value.ToString();
                        this.LbSMA.Text = SMA.Value.ToString();
                        this.LbSMK.Text = SMK.Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }


                // ------------------------------------------------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ----------------- Nilai Tiap Semester ---------------------------------
                    SqlCommand CmdProdiStatistik = new SqlCommand("SpPendaftarProdi", con);
                    CmdProdiStatistik.CommandType = System.Data.CommandType.StoredProcedure;

                    DataTable TablePendaftar = new DataTable();
                    TablePendaftar.Columns.Add("Program Studi");
                    TablePendaftar.Columns.Add("Terendah");
                    TablePendaftar.Columns.Add("Tertinggi");
                    TablePendaftar.Columns.Add("Jumlah");

                    using (SqlDataReader rdr = CmdProdiStatistik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TablePendaftar.NewRow();
                                datarow["Program Studi"] = rdr["pilihan_1"];
                                datarow["Terendah"] = rdr["bawah"];
                                datarow["Tertinggi"] = rdr["atas"];
                                datarow["Jumlah"] = rdr["jumlah"];

                                TablePendaftar.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVProdi.DataSource = TablePendaftar;
                            this.GVProdi.DataBind();

                        }
                        else
                        {
                            //clear Gridview
                            TablePendaftar.Rows.Clear();
                            TablePendaftar.Clear();
                            GVProdi.DataSource = TablePendaftar;
                            GVProdi.DataBind();
                        }
                    }

                    CmdProdiStatistik.Dispose();
                }

            }
        }

        protected void BtLogin_Click(object sender, EventArgs e)
        {
            // filter
            this.Captcha.ValidateCaptcha(this.TBReCaptcha.Text.Trim());
            if (this.Captcha.UserValidated)
            {
                if (this.Session["Name"] == null && this.Session["password"] == null)
                {
                    if (!Autentication(this.TBNoDaftar.Text, this.TBPin.Text))
                    {
                        return;
                    }
                    else
                    {
                        this.Session["Name"] = this.TBNoDaftar.Text;
                        this.Session["password"] = this.TBPin.Text;

                        // -------------- Add Sesion No Tagihan -----------------
                        string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            con.Open();
                            //SqlTransaction trans = con.BeginTransaction();

                            // 1. ------ Cek Masa Pendaftaran -------
                            SqlCommand CmdCekMasa = new SqlCommand("SpCekMasaDaftar", con);
                            //CmdCekMasa.Transaction = trans;
                            CmdCekMasa.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdCekMasa.Parameters.AddWithValue("@jenis_keg", "daftar");

                            SqlParameter Status = new SqlParameter();
                            Status.ParameterName = "@output";
                            Status.SqlDbType = System.Data.SqlDbType.VarChar;
                            Status.Size = 50;
                            Status.Direction = System.Data.ParameterDirection.Output;
                            CmdCekMasa.Parameters.Add(Status);

                            CmdCekMasa.ExecuteNonQuery();

                            if (Status.Value.ToString() != "BUKA")
                            {
                                this.Session["Name"] = null;
                                this.Session["password"] = null;
                                this.Session.RemoveAll();

                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Proses Tidak Sesuai Jadwal Pendaftaran !');", true);
                                return;
                            }

                            //2. Check Nomor Pendaftaran dan pinnya
                            SqlCommand CmdPeriodik = new SqlCommand("select no_tagihan from smuntidar_tagihan where no_pendaftar=@no_daftar AND pin=@pin", con);
                            //CmdPeriodik.Transaction = trans;
                            CmdPeriodik.CommandType = System.Data.CommandType.Text;

                            CmdPeriodik.Parameters.AddWithValue("@no_daftar", this.TBNoDaftar.Text);
                            CmdPeriodik.Parameters.AddWithValue("@pin", this.TBPin.Text);

                            using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.Session["no_tagihan"] = rdr["no_tagihan"].ToString();
                                    }
                                }
                                else
                                {
                                    // no tagihan tidak ditemukan / belum diinput
                                }
                            }
                        }


                        Response.Redirect("~/user/home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/user/home.aspx");
                }
            }
            else
            {
                this.TBReCaptcha.Text = "";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                return;
            }
        }

        private bool Autentication(string no_daftar, string pin)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmdLogin = new SqlCommand("SpSmintidarLogin", con);
                    cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

                    cmdLogin.Parameters.AddWithValue("@no_daftar", no_daftar);
                    cmdLogin.Parameters.AddWithValue("@pin", pin);

                    con.Open();
                    cmdLogin.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                this.TBReCaptcha.Text = "";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Login Gagal, " + ex.Message.ToString() + "');", true);
                return false;
            }
        }
    }
}