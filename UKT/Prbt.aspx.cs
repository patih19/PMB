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
    public partial class WebForm5 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // --------- jika proses komplet berlanjut ke step berikutnya (Borang Fasilitas) ----------
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate,valid FROM dbo.ukt_perabot WHERE no_daftar=@no_daftar", con);
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
                                    Response.Redirect("Fslt.aspx", false);
                                }
                                else if (rdr["komplate"].ToString() == "yes" && rdr["valid"] == DBNull.Value)
                                {
                                    Response.Redirect("ValPrbt.aspx", false);
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
            int Nilai = Convert.ToInt32(DLBeliMKTamu.SelectedValue) +
            Convert.ToInt32(DLAlmariBft.SelectedValue) +
            Convert.ToInt32(DLMKRuangTengah.SelectedValue) +
            Convert.ToInt32(DLMKRuangMakan.SelectedValue) +
            Convert.ToInt32(DLMKRuangTeras.SelectedValue) +
            Convert.ToInt32(DLTmpTidur.SelectedValue) +
            Convert.ToInt32(DLTV.SelectedValue) +
            Convert.ToInt32(DLKomp.SelectedValue) +
            Convert.ToInt32(DLPerabotDapur.SelectedValue) +
            Convert.ToInt32(DLMejaRias.SelectedValue);

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SpInsertPerabot", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@hrmjtamu",DLBeliMKTamu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hralmari",DLAlmariBft.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjtengah", DLMKRuangTengah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjmakan", DLMKRuangMakan.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrnjteras", DLMKRuangTeras.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtmtidur", DLTmpTidur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrtv", DLTV.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrkomp", DLKomp.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrdapur", DLPerabotDapur.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@hrmjrias", DLMejaRias.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("ValPrbt.aspx", false);
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