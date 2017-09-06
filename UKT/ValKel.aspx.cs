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
    public partial class WebForm18 : UktLogin
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

                        SqlCommand Keluarga = new SqlCommand("SELECT * FROM ukt_keluarga WHERE no_daftar=@no_daftar", con);
                        Keluarga.CommandType = System.Data.CommandType.Text;
                        Keluarga.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = Keluarga.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbJumlahOrangSerumah.Text = rdr["orgrumah"].ToString().Trim();
                                    this.LbJumlahSaudara.Text = rdr["sdr"].ToString().Trim();
                                    this.LbJumlahSdrKuliah.Text = rdr["sdrkuliah"].ToString().Trim();
                                    this.LbJumSdrSekolah.Text = rdr["sdrsekolah"].ToString().Trim();
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
                    SqlCommand cmd = new SqlCommand("UPDATE ukt_keluarga SET valid='yes' WHERE no_daftar = @no_daftar ", con);
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM ukt_keluarga WHERE no_daftar = @no_daftar ", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Kel.aspx", false);
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
