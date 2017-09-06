using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;

namespace smuntidar.user
{
    //public partial class WebForm13 : System.Web.UI.Page
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

                //-----------------------------------Keterangan Biodata -----------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdBiodata = new SqlCommand("SpBiodataPendaftar", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdBiodata.CommandType = System.Data.CommandType.StoredProcedure;

                    CmdBiodata.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdBiodata.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                this.LbNama.Text = rdr["nama"].ToString();
                                this.LbTmpLahir.Text = rdr["kab_kota"].ToString();

                                DateTime dt = DateTime.Parse(rdr["tgl_lahir"].ToString());

                                this.LbTglLhair.Text = dt.ToString("dd-MM-yyyy");
                                this.LbGender.Text = rdr["gender"].ToString();
                                this.LbWarga.Text = rdr["warga"].ToString();
                                this.LbAgama.Text = rdr["agama"].ToString();
                                this.LbAlamat.Text =  rdr["alamat"].ToString();
                                this.LbHp.Text = rdr["ho_hp"].ToString();

                                this.LbSekolah.Text = rdr["sekolah"].ToString();
                                this.LbJurusan.Text = rdr["jurusan"].ToString();
                                this.LbThnLulus.Text = rdr["tahun_lls"].ToString();
                                
                                this.LbAdik.Text = rdr["adik"].ToString();
                                this.LbKakak.Text = rdr["kakak"].ToString();
                                this.LbNamaAyah.Text = rdr["father_name"].ToString();
                                this.LbNamaIbu.Text = rdr["mother_name"].ToString();
                                this.LbPendidikanAyah.Text = rdr["pendidikan_ayah"].ToString();
                                this.LbPendidikanIbu.Text = rdr["pendidikan_ibu"].ToString();
                                this.LbPekerjaanAyah.Text = rdr["pekerjaan_ayah"].ToString();
                                this.LbPekerjaanIbu.Text = rdr["pekerjaan_ibu"].ToString();
                                this.LbPenghasilan.Text = rdr["penghasilan"].ToString();

                                this.LbPilihanI.Text = rdr["pilihan_1"].ToString();
                                this.LbPilihanII.Text = rdr["pilihan_2"].ToString();
                            }
                        }
                    }
                }

                //LihatFoto(this.Session["no_tagihan"].ToString());
                LihatFoto2(this.Session["no_tagihan"].ToString());
            }
        }
        protected void LihatFoto(string no_tagihan)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan,foto from smuntidar_foto where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", no_tagihan); // this.Session["Name"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Byte[] bytes = (Byte[])reader["foto"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            Image1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void LihatFoto2(string no_tagihan)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, path_foto from smuntidar_foto where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString()); // this.Session["Name"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Image1.ImageUrl = "~/foto/" + reader["path_foto"].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}