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
    public partial class WebForm4 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // --------- jika proses komplet berlanjut ke step berikutnya (Borang Perabot) ----------
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate,valid FROM dbo.ukt_lingkungan WHERE no_daftar=@no_daftar", con);
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
                                    Response.Redirect("Prbt.aspx", false);
                                }
                                else if (rdr["komplate"].ToString() == "yes" && rdr["valid"] == DBNull.Value)
                                {
                                    Response.Redirect("ValLng.aspx", false);
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
            int Nilai = Convert.ToInt32(DLLuasTaman.SelectedValue) +
                        Convert.ToInt32(DLPagar.SelectedValue) +
                        Convert.ToInt32(DLJalanMasuk.SelectedValue) +
                        Convert.ToInt32(DLSelokan.SelectedValue);

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SpInsertLingkungan", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@lstaman", DLLuasTaman.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pagar", DLPagar.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@jlnmasuk", DLJalanMasuk.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@selokan", DLSelokan.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("ValLng.aspx", false);
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