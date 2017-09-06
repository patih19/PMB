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
    public partial class WebForm3 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // --------- jika proses komplet berlanjut ke step berikutnya (Borang Lingkungan) ----------
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate,valid FROM dbo.ukt_rumah WHERE no_daftar=@no_daftar", con);
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
                                    Response.Redirect("Lng.aspx", false);
                                }
                                else if (rdr["komplate"].ToString() == "yes" && rdr["valid"] == DBNull.Value)
                                {
                                    Response.Redirect("ValRm.aspx", false);
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
            // ---------------------------------End Cek Proses komplate ----------------------------------------------
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int Nilai = Convert.ToInt32(DLStatusRumah.SelectedValue) +
                Convert.ToInt32(DlSmbrListrik.SelectedValue) +
                Convert.ToInt32(DLKwh.SelectedValue) +
                Convert.ToInt32(DlBiayaListrik.SelectedValue) +
                Convert.ToInt32(DLSmbrAir.SelectedValue) +
                Convert.ToInt32(DLBiayaAir.SelectedValue) +
                Convert.ToInt32(DLLsTanah.SelectedValue) +
                Convert.ToInt32(DLLsBangunan.SelectedValue) +
                Convert.ToInt32(DLNJOP.SelectedValue) +
                Convert.ToInt32(DLAtap.SelectedValue) +
                Convert.ToInt32(DLLantai.SelectedValue) +
                Convert.ToInt32(DLRgTengah.SelectedValue) +
                Convert.ToInt32(DLDapur.SelectedValue) +
                Convert.ToInt32(DLCuci.SelectedValue) +
                Convert.ToInt32(DLKmMandi.SelectedValue) +
                Convert.ToInt32(DLTeras.SelectedValue) +
                Convert.ToInt32(DLGarasi.SelectedValue);

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
                    SqlCommand cmd = new SqlCommand("SpinsertRumah", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@stsrumah", DLStatusRumah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@smbrlistrik", DlSmbrListrik.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@dylistrik", DLKwh.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@bylistrik", DlBiayaListrik.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@sbair", DLSmbrAir.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@byair", DLBiayaAir.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@lstanah", DLLsTanah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@lsbangunan", DLLsBangunan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@njop", DLNJOP.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@atap", DLAtap.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@lantai", DLLantai.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@rgtenngah", DLRgTengah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@dpr", DLDapur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@cuci", DLCuci.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@mandi", DLKmMandi.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@teras", DLTeras.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@garasi", DLGarasi.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("ValRm.aspx", false);
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