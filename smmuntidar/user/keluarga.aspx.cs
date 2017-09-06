
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
    //public partial class WebForm16 : System.Web.UI.Page
    public partial class WebForm16 : user_login
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

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_keluarga where smmuntidar_keluarga.no_tagihan=@no_tagihan", con);
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
                                    Response.Redirect("~/user/pilihan.aspx", false);
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
            // Form Validation
            if (this.TbJumAdik.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Jumlah Adik harus diisi');", true);
                return;
            }
            if (this.TbJumKakak.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Jumlah Kakak harus diisi');", true);
                return;
            }
            if (TbAyah.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama Ayah harus diisi');", true);
                return;
            }
            if (TbIbu.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama Ibu harus diisi');", true);
                return;
            }
            if (DLPendAyah.SelectedItem.Text == "Pendidikan")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pendidikan Ayah');", true);
                return;
            }
            if (DlPendIbu.SelectedItem.Text == "Pendidikan")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pendidikan Ibu');", true);
                return;
            }
            if (DLKerjaanAyah.SelectedItem.Text == "Pekerjaan")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pekerjaan Ayah');", true);
                return;
            }
            if (DLKerjaanIbu.SelectedItem.Text == "Pekerjaan")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pekerjaan Ibu');", true);
                return;
            }
            if (DLPenghasilan.SelectedItem.Text == "Penghasilan")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Penfhasilan Orang Tua');", true);
                return;
            }

            //Action to save to DB
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    //open connection and begin transaction
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    //SpInsertIdentitas
                    // 1.) Insert to DB ---
                    SqlCommand cmd = new SqlCommand("SpInsertKeluarga", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    cmd.Parameters.AddWithValue("@adik", this.TbJumAdik.Text);
                    cmd.Parameters.AddWithValue("@kakak", this.TbJumKakak.Text);
                    cmd.Parameters.AddWithValue("@nama_ayah", this.TbAyah.Text);
                    cmd.Parameters.AddWithValue("@nama_ibu", this.TbIbu.Text);
                    cmd.Parameters.AddWithValue("@pendidikan_ayah", DLPendAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pendidikan_ibu", DlPendIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pekerjaan_ayah", DLKerjaanAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pekerjaan_ibu", DLKerjaanIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pnghasilan", DLPenghasilan.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("~/user/pilihan.aspx", false);
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