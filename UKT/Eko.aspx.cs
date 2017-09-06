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
    public partial class WebForm7 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // --------- jika proses komplet berlanjut ke step berikutnya (Borang Harta/Aset) ----------
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate,valid FROM dbo.ukt_ekonomi WHERE no_daftar=@no_daftar", con);
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
                                    Response.Redirect("Ast.aspx", false);
                                }
                                else if (rdr["komplate"].ToString() == "yes" && rdr["valid"] == DBNull.Value)
                                {
                                    Response.Redirect("ValEko.aspx", false);
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
            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendapatanAyah.SelectedValue) +
                Convert.ToInt32(DLPendapatanIbu.SelectedValue) +
                Convert.ToInt32(DLHutang.SelectedValue) +
                Convert.ToInt32(DlCicilan.SelectedValue);

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
                    SqlCommand cmd = new SqlCommand("SpInsertEkonomi", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@pdptayah", DLPendapatanAyah.SelectedItem.Text );
                    cmd.Parameters.AddWithValue("@pdptibu", DLPendapatanIbu.SelectedItem.Text );
                    cmd.Parameters.AddWithValue("@htng", DLHutang.SelectedItem.Text );
                    cmd.Parameters.AddWithValue("@cicilan", DlCicilan.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("ValEko.aspx", false);
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