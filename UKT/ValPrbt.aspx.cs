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
    public partial class WebForm21 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string CS1 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS1))
                {
                    try
                    {
                        con.Open();

                        SqlCommand Perabot = new SqlCommand("SELECT * FROM ukt_perabot WHERE no_daftar=@no_daftar", con);
                        Perabot.CommandType = System.Data.CommandType.Text;
                        Perabot.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = Perabot.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbHargaMejaKursiRuangTamu.Text = rdr["hrmjtamu"].ToString().Trim();
                                    this.LbHargaAlmarBifet.Text = rdr["hralmari"].ToString().Trim();
                                    this.LbHargaMejaKursiRuangTengah.Text = rdr["hrmjtengah"].ToString().Trim();
                                    this.LbHargaMejaKursiRuangMakan.Text = rdr["hrmjmakan"].ToString().Trim();
                                    this.LbHargaMejaKursiTeras.Text = rdr["hrnjteras"].ToString().Trim();
                                    this.LbHargaTempatTidur.Text = rdr["hrtmtidur"].ToString().Trim();
                                    this.LbHargaTV.Text = rdr["hrtv"].ToString().Trim();
                                    this.LbHargaKomputerLaptop.Text = rdr["hrkomp"].ToString().Trim();
                                    this.LbHargaPeralatanDapur.Text = rdr["hrdapur"].ToString().Trim();
                                    this.LbHargaMejaRias.Text = rdr["hrmjrias"].ToString().Trim();
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
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
                try
                {
                    //open connection and begin transaction
                    con.Open();

                    //SqlTransaction trans = con.BeginTransaction();

                    //SpInsertIdentitas
                    // 1.) Insert Tagihan Periodik Mhs (mjd msh aktif) by using SpInsertTagihanPeriodikMhs ---
                    SqlCommand cmd = new SqlCommand("UPDATE ukt_perabot SET valid='yes' WHERE no_daftar = @no_daftar ", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Fslt.aspx", false);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            // delete data (sementara), tahun depan update data !!!

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
                    SqlCommand cmd = new SqlCommand("DELETE FROM ukt_perabot WHERE no_daftar = @no_daftar ", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Prbt.aspx", false);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}