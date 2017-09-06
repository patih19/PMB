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
    public partial class WebForm19 : UktLogin
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

                        SqlCommand Rumah = new SqlCommand("SELECT * FROM ukt_rumah WHERE no_daftar=@no_daftar", con);
                        Rumah.CommandType = System.Data.CommandType.Text;
                        Rumah.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = Rumah.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbStatusMilikRumah.Text = rdr["stsrumah"].ToString().Trim();
                                    this.LbSumberListrik.Text = rdr["smbrlistrik"].ToString().Trim();
                                    this.LbDayaListrik.Text = rdr["dylistrik"].ToString().Trim();
                                    this.LbBiayaListrikBulanan.Text = rdr["bylistrik"].ToString().Trim();
                                    this.LbSumberAir.Text = rdr["sbair"].ToString().Trim();
                                    this.LbBiayaAirBulanan.Text = rdr["byair"].ToString().Trim();
                                    this.LbLuasTanah.Text = rdr["lstanah"].ToString().Trim();
                                    this.LbLuasBangunan.Text = rdr["lsbangunan"].ToString().Trim();
                                    this.LbNJOP.Text = rdr["njop"].ToString().Trim();
                                    this.LbAtap.Text = rdr["atap"].ToString().Trim();
                                    this.LbLantaiRumah.Text = rdr["lantai"].ToString().Trim();
                                    this.LbRuangTengah.Text = rdr["rgtenngah"].ToString().Trim();
                                    this.LbDapur.Text = rdr["dpr"].ToString().Trim();
                                    this.LbCuciPiringGelas.Text = rdr["cuci"].ToString().Trim();
                                    this.LbKeperluanMandi.Text = rdr["mandi"].ToString().Trim();
                                    this.LbTeras.Text = rdr["teras"].ToString().Trim();
                                    this.LbGarasi.Text = rdr["garasi"].ToString().Trim();
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
            {
                try
                {
                    //open connection and begin transaction
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    //SpInsertIdentitas
                    // 1.) Insert Tagihan Periodik Mhs (mjd msh aktif) by using SpInsertTagihanPeriodikMhs ---
                    SqlCommand cmd = new SqlCommand("UPDATE ukt_rumah set valid='yes' WHERE no_daftar = @no_daftar ", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Lng.aspx", false);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM ukt_rumah WHERE no_daftar = @no_daftar ", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Rm.aspx", false);
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