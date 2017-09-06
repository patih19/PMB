using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace UKT
{
    public partial class WebForm8 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // jika sudah mendapat kategori UKT tampilkan hasil
            string CS2 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS2))
            {
                try
                {
                    //con.Open();
                    //SqlCommand cmd = new SqlCommand("SpCekKategoriUKT", con);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    //cmd.ExecuteNonQuery();
                    //Response.Redirect("Upload.aspx", false);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate,valid FROM dbo.ukt_harta WHERE no_daftar=@no_daftar", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["komplate"].ToString() == "yes" && rdr["valid"].ToString() == "yes")
                                {
                                    Response.Redirect("Upload.aspx", false);
                                }
                                else if (rdr["komplate"].ToString() == "yes" && rdr["valid"] == DBNull.Value)
                                {
                                    Response.Redirect("ValAst.aspx", false);
                                }
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
            // ------------------------------------------------------------------------------------

            //// --------- jika proses komplet berlanjut ke step berikutnya (Borang Harta/Aset) ----------
            //string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    try
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate FROM dbo.ukt_harta WHERE no_daftar=@no_daftar", con);
            //        cmd.CommandType = System.Data.CommandType.Text;
            //        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

            //        using (SqlDataReader rdr = cmd.ExecuteReader())
            //        {
            //            if (rdr.HasRows)
            //            {
            //                while (rdr.Read())
            //                {
            //                    if (rdr["komplate"].ToString() == "yes")
            //                    {
            //                        //Response.Redirect("hasil.aspx", false);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
            //        return;
            //    }
            //}
            //// ---------------------------------End Cek Proses komplate ----------------------------------------------

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Get Nilai 
            int Nilai = Convert.ToInt32(DLSawah.SelectedValue) +
                Convert.ToInt32(DLTanah.SelectedValue) +
                Convert.ToInt32(DLternak.SelectedValue) +
                Convert.ToInt32(DLmobil.SelectedValue) +
                Convert.ToInt32(DLGiro.SelectedValue) +
                Convert.ToInt32(DLPerhiasan.SelectedValue) +
                Convert.ToInt32(DLSepeda.SelectedValue);

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
                    SqlCommand cmd = new SqlCommand("SpInsertHarta", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@sawah", DLSawah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tanah", DLTanah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ternak", DLternak.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@mobil", DLmobil.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@tabungan", DLGiro.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hiasan", DLPerhiasan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sepeda",DLSepeda.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("ValAst.aspx", false);
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }


            ////=======================================================================================
            //// ------------------------------ PENENTUAN UKT -----------------------------------------
            //// --------------------------- Jenis Reg masih MANUAL -----------------------------------
            //// 1 = SBMPTN
            //// 2 = SM
            //// 3 = SMM
            //// ========================================================================================
            //string CS2 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS2))
            //{
            //    try
            //    {
            //        con.Open();
            //        //SqlTransaction trans = con.BeginTransaction();

            //        SqlCommand cmd = new SqlCommand("SPCekBerkasAndGetUKT2", con);
            //        //cmd.Transaction = trans;

            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

            //        // --- =================== MANUAL SBMPTN=============== ----//
            //        cmd.Parameters.AddWithValue("@JenisReq", 3);

            //        cmd.ExecuteNonQuery();

            //    }
            //    catch (Exception ex)
            //    {
            //        //trans.Rollback();
            //        con.Close();
            //        con.Dispose();

            //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
            //        return;
            //    }
            //}



        }
    }
}