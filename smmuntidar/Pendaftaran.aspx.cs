using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace smmuntidar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public decimal _TotalPendaftar
        {
            get
            {
                return Convert.ToDecimal(this.ViewState["TotalSKS"].ToString());
            }
            set
            {
                this.ViewState["TotalSKS"] = (object)value;
            }
        }

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

            if (!Page.IsPostBack)
            {
                // ------------------------------------------------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ----------------- Pilihan Prodi ---------------------------------
                    SqlCommand CmdPilihanProdi = new SqlCommand(  "SELECT UntidarDb.dbo.bak_prog_study.id_prog_study, UntidarDb.dbo.bak_prog_study.prog_study, UntidarDb.dbo.bak_fakultas.fak_name "+
                                                                    "FROM UntidarDb.dbo.bak_prog_study INNER JOIN "+
                                                                    "UntidarDb.dbo.bak_fakultas ON UntidarDb.dbo.bak_prog_study.id_fakultas = UntidarDb.dbo.bak_fakultas.kode", con);
                    CmdPilihanProdi.CommandType = System.Data.CommandType.Text;

                    DataTable TableProdi = new DataTable();
                    TableProdi.Columns.Add("Program Studi");
                    TableProdi.Columns.Add("Fakultas");

                    using (SqlDataReader rdr = CmdPilihanProdi.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableProdi.NewRow();
                                datarow["Program Studi"] = rdr["prog_study"];
                                datarow["Fakultas"] = rdr["fak_name"];

                                TableProdi.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVPilihanProdi.DataSource = TableProdi;
                            this.GVPilihanProdi.DataBind();

                        }
                        else
                        {
                            //clear Gridview
                            TableProdi.Rows.Clear();
                            TableProdi.Clear();
                            GVPilihanProdi.DataSource = TableProdi;
                            GVPilihanProdi.DataBind();
                        }
                    }

                    CmdPilihanProdi.Dispose();




                    //// ----------------- Jumlah Peserta Tiap Prodi ---------------------------------
                    //SqlCommand CmdProdiStatistik = new SqlCommand("SpPendaftarProdiSMM", con);
                    //CmdProdiStatistik.CommandType = System.Data.CommandType.StoredProcedure;

                    //DataTable TablePendaftar = new DataTable();
                    //TablePendaftar.Columns.Add("Program Studi");
                    //TablePendaftar.Columns.Add("Jumlah");

                    //using (SqlDataReader rdr = CmdProdiStatistik.ExecuteReader())
                    //{
                    //    if (rdr.HasRows)
                    //    {
                    //        while (rdr.Read())
                    //        {
                    //            DataRow datarow = TablePendaftar.NewRow();
                    //            datarow["Program Studi"] = rdr["pilihan_1"];
                    //            datarow["Jumlah"] = rdr["jumlah"];

                    //            TablePendaftar.Rows.Add(datarow);
                    //        }

                    //        //Fill Gridview
                    //        this.GVProdi.DataSource = TablePendaftar;
                    //        this.GVProdi.DataBind();

                    //    }
                    //    else
                    //    {
                    //        //clear Gridview
                    //        TablePendaftar.Rows.Clear();
                    //        TablePendaftar.Clear();
                    //        GVProdi.DataSource = TablePendaftar;
                    //        GVProdi.DataBind();
                    //    }
                    //}

                    //CmdProdiStatistik.Dispose();


                    // ----------------- Jumlah Peserta No Foto  ---------------------------------
                    SqlCommand CmdNoFoto = new SqlCommand("SpNoFoto", con);
                    CmdNoFoto.CommandType = System.Data.CommandType.StoredProcedure;

                    DataTable TableNoFoto = new DataTable();
                    TableNoFoto.Columns.Add("No Pendaftaran");
                    TableNoFoto.Columns.Add("Nama");
                    TableNoFoto.Columns.Add("Pilihan I");

                    using (SqlDataReader rdr = CmdNoFoto.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableNoFoto.NewRow();
                                datarow["No Pendaftaran"] = rdr["no_pendaftar"];
                                datarow["Nama"] = rdr["nama"].ToString().ToUpper();
                                datarow["Pilihan I"] = rdr["pilihan_1"];

                                TableNoFoto.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVNoFoto.DataSource = TableNoFoto;
                            this.GVNoFoto.DataBind();

                        }
                        else
                        {
                            //clear Gridview
                            TableNoFoto.Rows.Clear();
                            TableNoFoto.Clear();
                            GVNoFoto.DataSource = TableNoFoto;
                            GVNoFoto.DataBind();
                        }
                    }

                    CmdNoFoto.Dispose();
                }
            }


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
        }

        protected void BtLogin_Click(object sender, EventArgs e)
        {
            try
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
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Proses Tidak Sesuai Jadwal Pendaftaran !');", true);
                                    return;
                                }

                                SqlCommand CmdPeriodik = new SqlCommand("select no_tagihan from smmuntidar_tagihan where no_pendaftar=@no_daftar AND pin=@pin", con);
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

                           // Response.Redirect("~/user/home.aspx");
                            Response.Redirect("~/user/identity.aspx");
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
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        private bool Autentication(string no_daftar, string pin)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmdLogin = new SqlCommand("SpSmmUntidarLogin", con);
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

        // Format Rupiah Biaya SKS Mahasiswa
        int TotalPendaftar = 0;
        protected void GVProdi_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int jumlah = Convert.ToInt32(e.Row.Cells[1].Text);
                TotalPendaftar += jumlah;
                this._TotalPendaftar = TotalPendaftar;

                //string FormattedString1 = string.Format
                //    (new System.Globalization.CultureInfo("id"), "{0:c}", jumlah);
                //e.Row.Cells[1].Text = FormattedString1;
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Jumlah ";
                e.Row.Cells[1].Text = TotalPendaftar.ToString();

                //int Jumlah = Convert.ToInt32(e.Row.Cells[1].Text);
                //string FormattedString4 = string.Format
                //    (new System.Globalization.CultureInfo("id"), "{0:c}", Jumlah);
                //e.Row.Cells[1].Text = FormattedString4;
            }
        }
    }
}