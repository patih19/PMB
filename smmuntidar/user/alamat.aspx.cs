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
    public partial class WebForm13 : user_login
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
                this.LbTrans.Text = Session["Name"].ToString();

                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_alamat where smmuntidar_alamat.no_tagihan=@no_tagihan", con);
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
                                    Response.Redirect("~/user/pendidikan.aspx", false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    //Response.Redirect("~/user/confirm.aspx", false);
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
            //form validation
            if (this.TbAlamat.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Alamat harus diisi');", true);
                return;
            }
            if (this.DropDownListProv.SelectedItem.Text == "PROVINSI")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Provinsi');", true);
                return;
            }
            if (this.DropDownListKab.SelectedItem.Text == "KOTA/KABUPATEN")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Kota/Kabupaten');", true);
                return;
            }
            if (this.TbKdPos.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode POS harus diisi');", true);
                return;
            }
            if (this.TbNoHp.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('No Handphone harus diisi');", true);
                return;
            }
            if (this.TbEmail.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('emial harus diisi');", true);
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
                    SqlCommand cmd = new SqlCommand("SpInsertAlamat", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    cmd.Parameters.AddWithValue("@alamat", this.TbAlamat.Text);
                    cmd.Parameters.AddWithValue("@prov", this.DropDownListProv.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@kab_kota", this.DropDownListKab.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pos", this.TbKdPos.Text);
                    if (TbTelpRumah.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@telp", "-");
                    }
                    else if (TbTelpRumah.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@telp", this.TbTelpRumah.Text);
                    }
                    cmd.Parameters.AddWithValue("@hp", this.TbNoHp.Text);
                    cmd.Parameters.AddWithValue("@email", this.TbEmail.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("~/user/pendidikan.aspx", false);
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