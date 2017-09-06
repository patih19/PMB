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
    //public partial class WebForm14 : System.Web.UI.Page
    public partial class WebForm14 : user_login
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

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_identitas where smmuntidar_identitas.no_tagihan=@no_tagihan", con);
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
                                    Response.Redirect("~/user/alamat.aspx", false);
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

        protected void Btlanjut_Click1(object sender, EventArgs e)
        {
            //------------------- filter ----------------------
            if (TbNama.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Nama');", true);
                return;
            }

            if (TBNoIdentitas.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi No Identitas');", true);
                return;
            }

            if (DLProv.SelectedItem.Text == "PROVINSI")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Provinsi');", true);
                return;
            }
            if (DDListKab.SelectedItem.Text == "KOTA/KABUPATEN")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Kota/Kabutapten');", true);
                return;
            }
            if (TBTmpLahir.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tempat Lahir');", true);
                return;
            }
            if (TbTglLhir.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tanggal Lahir');", true);
                return;
            }
            if (DLIdentitas.SelectedItem.Text == "Identitas")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Identitas');", true);
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

                    //SpInsertIdentitas
                    // 1.) Insert Tagihan Periodik Mhs (mjd msh aktif) by using SpInsertTagihanPeriodikMhs ---
                    SqlCommand cmd = new SqlCommand("SpInsertIdentitas", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    cmd.Parameters.AddWithValue("@nama", this.TbNama.Text);
                    cmd.Parameters.AddWithValue("@prov", this.DLProv.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kab_kota", DDListKab.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@lahir", TBTmpLahir.Text);
                    cmd.Parameters.AddWithValue("@tgl_lahir", TbTglLhir.Text);
                    cmd.Parameters.AddWithValue("@identitas", DLIdentitas.SelectedValue);
                    cmd.Parameters.AddWithValue("@no_identitas", TBNoIdentitas.Text);
                    // -------------- Gender -------------------
                    if (RbLaki.Checked)
                    {
                        cmd.Parameters.AddWithValue("@gender", "laki-laki");
                    }
                    else if (RbPerempuan.Checked)
                    {
                        cmd.Parameters.AddWithValue("@gender", "perempuan");
                    }
                    // ----------- Warga -----------------
                    if (RbWNI.Checked)
                    {
                        cmd.Parameters.AddWithValue("@warga", "WNI");
                    }
                    else if (RbWNA.Checked)
                    {
                        cmd.Parameters.AddWithValue("@warga", "WNA");
                    }
                    else if (RbWNIK.Checked)
                    {
                        cmd.Parameters.AddWithValue("@warga", "WNI Keturunan");
                    }
                    //------------ Agama ----------------
                    if (RbIslam.Checked)
                    {
                        cmd.Parameters.AddWithValue("@agama", "Islam");
                    }
                    else if (RbBudha.Checked)
                    {
                        cmd.Parameters.AddWithValue("@agama", "Budha");
                    }
                    else if (RbHindu.Checked)
                    {
                        cmd.Parameters.AddWithValue("@agama", "Hindu");
                    }
                    else if (RbKatholik.Checked)
                    {
                        cmd.Parameters.AddWithValue("@agama", "Katholik");
                    }
                    else if (RbKonghucu.Checked)
                    {
                        cmd.Parameters.AddWithValue("@agama", "Konghucu");
                    }
                    else if (RbProtestan.Checked)
                    {
                        cmd.Parameters.AddWithValue("@agama", "Protestan");
                    }
                    // -------------- Darah ------------------
                    if (RbA.Checked)
                    {
                        cmd.Parameters.AddWithValue("@darah", "A");
                    }
                    else if (RbB.Checked)
                    {
                        cmd.Parameters.AddWithValue("@darah", "B");
                    }
                    else if (RbAB.Checked)
                    {
                        cmd.Parameters.AddWithValue("@darah", "AB");
                    }
                    else if (RbO.Checked)
                    {
                        cmd.Parameters.AddWithValue("@darah", "O");
                    }
                    else if (RbNone.Checked)
                    {
                        cmd.Parameters.AddWithValue("@darah", "-");
                    }
                    cmd.ExecuteNonQuery();

                    //trans.Commit();
                    //trans.Dispose();
                    cmd.Dispose();
                    con.Close();
                    con.Dispose();

                    Response.Redirect("~/user/alamat.aspx", false);
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