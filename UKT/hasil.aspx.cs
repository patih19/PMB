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
    public partial class WebForm10 : UktLogin
    {
        string JalurMasuk;
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    // ------------------- CEK JALUR MASUK -------------------
                    SqlCommand CmdCekJalur = new SqlCommand("SpCekJalurMasuk", con);
                    CmdCekJalur.CommandType = System.Data.CommandType.StoredProcedure;

                    CmdCekJalur.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = CmdCekJalur.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                JalurMasuk = rdr["jalur"].ToString();
                            }
                        }
                    }



                    if (JalurMasuk == "SNMPTN")
                    {

                    }
                    else if (JalurMasuk == "SBMPTN")
                    {
                        // -------------------- SBMPTN -----------------------------
                        SqlCommand cmdSB = new SqlCommand("SpHasilUkt", con);
                        cmdSB.CommandType = System.Data.CommandType.StoredProcedure;

                        cmdSB.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = cmdSB.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbUKT.Text = rdr["kd_peserta"].ToString();
                                    this.LBBiaya.Text = rdr["amount_total"].ToString();
                                }
                            }
                        }

                        //label terbayar dalam format rupiah Rp
                        decimal Terbayar = Convert.ToDecimal(this.LBBiaya.Text);
                        string FormattedString6 = string.Format
                            (new System.Globalization.CultureInfo("id"), "{0:c}", Terbayar);
                        this.LBBiaya.Text = FormattedString6; 

                    }
                    else if (JalurMasuk == "SMM-UNTIDAR")
                    {
                        // ------------------- SMM-UNTIDAR ----------------------
                        SqlCommand cmd = new SqlCommand("SpHasilUktSMM", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbUKT.Text = rdr["ukt"].ToString();
                                    this.LBBiaya.Text = rdr["amount_total"].ToString();
                                }
                            }
                        }

                        //label terbayar dalam format rupiah Rp
                        decimal Terbayar = Convert.ToDecimal(this.LBBiaya.Text);
                        string FormattedString6 = string.Format
                            (new System.Globalization.CultureInfo("id"), "{0:c}", Terbayar);
                        this.LBBiaya.Text = FormattedString6; 
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
}