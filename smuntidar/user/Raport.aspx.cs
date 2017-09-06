using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace smuntidar.user
{
    //public partial class WebForm2 : System.Web.UI.Page
    public partial class WebForm2 : user_login
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

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smuntidar_raport where smuntidar_raport.no_tagihan=@no_tagihan", con);
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
                                    Response.Redirect("~/user/keluarga.aspx",false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    Response.Redirect("~/user/confirm.aspx",false);
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
            // Validasi Input Nilai
            //----------------------------- 1 --------------------------------
            if (this.TbBi1.Text == "" || this.TbBi2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbInggris1.Text == "" || this.TbInggris1.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbMtk1.Text == "" || this.TbMtk1.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            //----------------------------- 2 --------------------------------
            else if ( this.TbBi2.Text == "" || this.TbBi2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbInggris2.Text == "" || this.TbInggris2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbMtk2.Text == "" || this.TbMtk2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            //----------------------------- 3 --------------------------------
            else if (this.TbBi3.Text == "" || this.TbBi3.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbInggris3.Text == "" || this.TbInggris3.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbMtk3.Text == "" || this.TbMtk3.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            //----------------------------- 4 --------------------------------
            else if (this.TbBi4.Text == "" || this.TbBi4.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if ( this.TbInggris4.Text == "" || this.TbInggris4.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbMtk4.Text == "" || this.TbMtk4.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            //----------------------------- 5 --------------------------------
            else if (this.TbBi5.Text == "" || this.TbBi5.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if ( this.TbInggris5.Text == "" || this.TbInggris5.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }
            else if (this.TbMtk5.Text == "" || this.TbMtk5.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nilai Tidak Boleh Kosong');", true);
                return;
            }


            // Cek Input Nilai
            //----------------------------- 1 --------------------------------

            //Response.Write("Nilai =" + Convert.ToDecimal(this.TbBi1.Text).ToString() + " </br>");
            //Response.Write("Nilai per 100 =" + (Convert.ToDecimal(this.TbBi1.Text) / 100 ).ToString() + " </br>");
            

            if (Convert.ToDecimal(this.TbBi1.Text) / 100 > 1 || Convert.ToDecimal(this.TbBi1.Text) / 100 <= 0.09m || this.TbBi1.Text == "" || this.TbBi1.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbInggris1.Text) / 100 > 1 || Convert.ToDecimal(this.TbInggris1.Text) / 100 <= 0.09m || this.TbInggris1.Text == "" || this.TbInggris1.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbMtk1.Text) / 100 > 1 || Convert.ToDecimal(this.TbMtk1.Text) / 100 <= 0.09m || Convert.ToDecimal(this.TbMtk1.Text) <= 0 || this.TbMtk1.Text == "" || this.TbMtk1.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            //----------------------------- 2 --------------------------------
            else if (Convert.ToDecimal(this.TbBi2.Text) / 100 > 1 || Convert.ToDecimal(this.TbBi2.Text) / 100 <= 0.09m || this.TbBi2.Text == "" || this.TbBi2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbInggris2.Text) / 100 > 1 || Convert.ToDecimal(this.TbInggris2.Text) / 100 <= 0.09m || this.TbInggris2.Text == "" || this.TbInggris2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbMtk2.Text) / 100 > 1 || Convert.ToDecimal(this.TbMtk2.Text) / 100 <= 0.09m || this.TbMtk2.Text == "" || this.TbMtk2.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            //----------------------------- 3 --------------------------------
            else if (Convert.ToDecimal(this.TbBi3.Text) / 100 > 1 || Convert.ToDecimal(this.TbBi3.Text) / 100 <= 0.09m || this.TbBi3.Text == "" || this.TbBi3.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbInggris3.Text) / 100 > 1 || Convert.ToDecimal(this.TbInggris3.Text) / 100 <= 0.09m || this.TbInggris3.Text == "" || this.TbInggris3.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbMtk3.Text) / 100 > 1 || Convert.ToDecimal(this.TbMtk3.Text) / 100 <= 0.09m || this.TbMtk3.Text == "" || this.TbMtk3.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            //----------------------------- 4 --------------------------------
            else if (Convert.ToDecimal(this.TbBi4.Text) / 100 > 1 || Convert.ToDecimal(this.TbBi4.Text) / 100 <= 0.09m || this.TbBi4.Text == "" || this.TbBi4.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbInggris4.Text) / 100 > 1 || Convert.ToDecimal(this.TbInggris4.Text) / 100 <= 0.09m || this.TbInggris4.Text == "" || this.TbInggris4.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbMtk4.Text) / 100 > 1 || Convert.ToDecimal(this.TbMtk4.Text) / 100 <= 0.09m || this.TbMtk4.Text == "" || this.TbMtk4.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            //----------------------------- 5 --------------------------------
            else if (Convert.ToDecimal(this.TbBi5.Text) / 100 > 1 || Convert.ToDecimal(this.TbBi5.Text) / 100 <= 0.09m || this.TbBi5.Text == "" || this.TbBi5.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbInggris5.Text) / 100 > 1 || Convert.ToDecimal(this.TbInggris5.Text) / 100 <= 0.09m || this.TbInggris5.Text == "" || this.TbInggris5.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }
            else if (Convert.ToDecimal(this.TbMtk5.Text) / 100 > 1 || Convert.ToDecimal(this.TbMtk5.Text) / 100 <= 0.09m || this.TbMtk5.Text == "" || this.TbMtk5.Text == "00.00")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Periksa Nilai');", true);
                return;
            }


             string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
             using (SqlConnection con = new SqlConnection(CS))
             {
                 //open connection and begin transaction
                 con.Open();
                 SqlTransaction trans = con.BeginTransaction();

                 try
                 {
                     // Insert Raport Semester 1
                     SqlCommand CmdSm1 = new SqlCommand("SpInsertRaport", con);
                     CmdSm1.Transaction = trans;
                     CmdSm1.CommandType = System.Data.CommandType.StoredProcedure;

                     CmdSm1.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     CmdSm1.Parameters.AddWithValue("@BI", this.TbBi1.Text);
                     CmdSm1.Parameters.AddWithValue("@BInggris", this.TbInggris1.Text);
                     CmdSm1.Parameters.AddWithValue("@Mtk", this.TbMtk1.Text);
                     CmdSm1.Parameters.AddWithValue("@semester", "1");
                     CmdSm1.ExecuteNonQuery();

                     // Insert Raport Semester 2
                     SqlCommand CmdSm2 = new SqlCommand("SpInsertRaport", con);
                     CmdSm2.Transaction = trans;
                     CmdSm2.CommandType = System.Data.CommandType.StoredProcedure;

                     CmdSm2.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     CmdSm2.Parameters.AddWithValue("@BI", this.TbBi2.Text);
                     CmdSm2.Parameters.AddWithValue("@BInggris", this.TbInggris2.Text);
                     CmdSm2.Parameters.AddWithValue("@Mtk", this.TbMtk2.Text);
                     CmdSm2.Parameters.AddWithValue("@semester", "2");
                     CmdSm2.ExecuteNonQuery();

                     // Insert Raport Semester 3
                     SqlCommand CmdSm3 = new SqlCommand("SpInsertRaport", con);
                     CmdSm3.Transaction = trans;
                     CmdSm3.CommandType = System.Data.CommandType.StoredProcedure;

                     CmdSm3.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     CmdSm3.Parameters.AddWithValue("@BI", this.TbBi3.Text);
                     CmdSm3.Parameters.AddWithValue("@BInggris", this.TbInggris3.Text);
                     CmdSm3.Parameters.AddWithValue("@Mtk", this.TbMtk3.Text);
                     CmdSm3.Parameters.AddWithValue("@semester", "3");
                     CmdSm3.ExecuteNonQuery();

                     // Insert Raport Semester 4
                     SqlCommand CmdSm4 = new SqlCommand("SpInsertRaport", con);
                     CmdSm4.Transaction = trans;
                     CmdSm4.CommandType = System.Data.CommandType.StoredProcedure;

                     CmdSm4.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     CmdSm4.Parameters.AddWithValue("@BI", this.TbBi4.Text);
                     CmdSm4.Parameters.AddWithValue("@BInggris", this.TbInggris4.Text);
                     CmdSm4.Parameters.AddWithValue("@Mtk", this.TbMtk4.Text);
                     CmdSm4.Parameters.AddWithValue("@semester", "4");
                     CmdSm4.ExecuteNonQuery();

                     // Insert Raport Semester 5
                     SqlCommand CmdSm5 = new SqlCommand("SpInsertRaport", con);
                     CmdSm5.Transaction = trans;
                     CmdSm5.CommandType = System.Data.CommandType.StoredProcedure;

                     CmdSm5.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     CmdSm5.Parameters.AddWithValue("@BI", this.TbBi5.Text);
                     CmdSm5.Parameters.AddWithValue("@BInggris", this.TbInggris5.Text);
                     CmdSm5.Parameters.AddWithValue("@Mtk", this.TbMtk5.Text);
                     CmdSm5.Parameters.AddWithValue("@semester", "5");
                     CmdSm5.ExecuteNonQuery();

                     trans.Commit();
                     trans.Dispose();
                     CmdSm1.Dispose();
                     CmdSm2.Dispose();
                     CmdSm3.Dispose();
                     CmdSm4.Dispose();
                     CmdSm5.Dispose();

                     // ----- INPUT NILAI RATA-RATA RAPORT TO TABLE NILAI ----
                     // -- jika memungkinkan terjadi permasalahan buatkan menu untuk update Nilai raport dengan mengeksekusi Stored Procedure
                     // -- "SpHitungRerataRaport" --

                     SqlCommand CmdNilai = new SqlCommand("SpHitungRerataRaport", con);
                     CmdNilai.CommandType = System.Data.CommandType.StoredProcedure;

                     CmdNilai.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     CmdNilai.ExecuteNonQuery();

                     CmdNilai.Dispose();

                     Response.Redirect("~/user/keluarga.aspx",false);
                 }
                 catch (Exception ex)
                 {
                     trans.Rollback();
                     trans.Dispose();
                     con.Close();
                     con.Dispose();

                     this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                     return;
                 }


             }
        }
    }
}