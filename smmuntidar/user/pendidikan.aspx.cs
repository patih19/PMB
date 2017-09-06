using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace smmuntidar.user
{
    //public partial class WebForm15 : System.Web.UI.Page
    public partial class WebForm15 : user_login
    {
        //------------- LogOut ------------------------------//
        protected override void OnInit(EventArgs e)
        {
            // Your code
            base.OnInit(e);
            keluar.ServerClick += new EventHandler(logout_ServerClick);
        }

        protected void logout_ServerClick(object sender, EventArgs e)
        {
            //Your Code here....
            this.Session["Name"] = null;
            this.Session["Passwd"] = null;
            this.Session.Remove("Name");
            this.Session.Remove("Passwd");
            this.Session.Remove("no_tagihan");
            this.Session.RemoveAll();

            this.Response.Redirect("~/Pendaftaran.aspx", false);
        }
        //---------------- End logout ------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LbTrans.Text = this.Session["Name"].ToString();

                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_pendidikan where smmuntidar_pendidikan.no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["proses_komplet"].ToString() == "ok")
                                {
                                    Response.Redirect("~/user/keluarga.aspx", false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    Response.Redirect("~/user/confirm.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            // data no tagihan tidak ditemukan, sepertinya tidak mungkin kaarena user sudah bisa login
                        }
                    }
                }
                //---------------------------------- End Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
            }
        }

        protected void BtLanjut_Click(object sender, EventArgs e)
        {
            //Form Validation
            if (DLProv.SelectedItem.Text == "PROVINSI")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('pilih Provinsi');", true);
                return;
            }
            if (DDListKab.SelectedItem.Text == "KOTA/KABUPATEN")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('pilih Kota/Kabupaten');", true);
                return;
            }
            if (this.DLJenisSekolah.SelectedItem.Text == "Pilih Sekolah")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih SMA atau SMK');", true);
                return;
            }
            if (TbSMAAsal.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('isikan Nama Sekolah Asal');", true);
                return;
            }
            if (DLStatusSkolah.SelectedItem.Text == "Status")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('pilih Satus Sekolah');", true);
                return;
            }
            if (DLJurusan.SelectedItem.Text == "Jurusan")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('pilih Jurusan');", true);
                return;
            }
            if (DLJurusan.SelectedItem.Text == "----------")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('pilih Jurusan');", true);
                return;
            }
            if (DLTahunLls.SelectedItem.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('pilih Tahun Lulus');", true);
                return;
            }

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    //open connection and begin transaction
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    // 1.) Insert to DB ---
                    SqlCommand cmd = new SqlCommand("SpInsertPendidikan", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    cmd.Parameters.AddWithValue("@prov", this.DLProv.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kab_kota", DDListKab.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@school", this.DLJenisSekolah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sekolah", TbSMAAsal.Text);
                    cmd.Parameters.AddWithValue("@status", DLStatusSkolah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jurusan", DLJurusan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tahun_lulus", DLTahunLls.SelectedItem.Text);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    Response.Redirect("~/user/keluarga.aspx", false);
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}