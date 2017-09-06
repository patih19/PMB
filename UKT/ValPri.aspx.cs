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
    public partial class WebForm17 : UktLogin
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

                        SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_pribadi WHERE no_daftar=@no_daftar", con);
                        Pribadi.CommandType = System.Data.CommandType.Text;
                        Pribadi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = Pribadi.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbNama.Text = rdr["nama"].ToString().Trim();
                                    this.LbGender.Text = rdr["gender"].ToString().Trim();
                                    this.LbTempatLahir.Text = rdr["tmplahir"].ToString().Trim();

                                    DateTime dt = DateTime.Parse(rdr["tglahir"].ToString());
                                    this.LbTanggalLahir.Text = dt.ToString("dd-MMMM-yyyy");

                                    this.LbAlamat.Text = rdr["alamat"].ToString().Trim();
                                    this.LbHp.Text = rdr["hp"].ToString().Trim();
                                    this.LbTelpRumah.Text = rdr["telp"].ToString().Trim();

                                    this.LbNamaAyah.Text = rdr["ayah"].ToString().Trim();
                                    this.LbStatusAyah.Text = rdr["stayah"].ToString().Trim();
                                    this.LbPendidikanAyah.Text = rdr["pdayah"].ToString().Trim();
                                    this.LbPekerjaanAyah.Text = rdr["kerjaayah"].ToString().Trim();
                                    this.LbModalUsahaAyah.Text = rdr["modalayah"].ToString().Trim();
                                    this.LbLabaAyah.Text = rdr["labaayah"].ToString().Trim();

                                    this.LbNamaIbu.Text = rdr["ibu"].ToString().Trim();
                                    this.LbStatusIbu.Text = rdr["stibu"].ToString().Trim();
                                    this.LbPendidikanIbu.Text = rdr["pdibu"].ToString().Trim();
                                    this.LbPekerjaanIbu.Text = rdr["kerjaibu"].ToString().Trim();
                                    this.LbModalUsahaIbu.Text = rdr["modalibu"].ToString().Trim();
                                    this.LbLabaIbu.Text = rdr["labaibu"].ToString().Trim();
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

        protected void Button1_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("UPDATE ukt_pribadi set	valid='yes' WHERE no_daftar = @no_daftar ", con);
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

        protected void Button2_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("DELETE FROM ukt_pribadi WHERE no_daftar = @no_daftar ", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    cmd.ExecuteNonQuery();

                    Response.Redirect("Pri.aspx", false);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
            //Response.Redirect("Pri.aspx", false);
        }
    }
}