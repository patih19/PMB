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
    public partial class WebForm9 : System.Web.UI.Page
    {
        //prevent back after login on page init
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["NoDaftar"] == null || this.Session["PIN"] == null || this.Session["NamaUser"] == null || this.Session["Unit"] == null)
            {
                // ---- avoid back after logout -----
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.Cache.AppendCacheExtension("no-cache");
                Response.Expires = 0;

                Page.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

                HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
                HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
                HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();
                // --- End aviod back after logout -------
            }
            else if (this.Session["NoDaftar"] != null && this.Session["PIN"] != null)
            {
                Response.Redirect("~/Pri.aspx");
            }
            else if (this.Session["NamaUser"] != null && this.Session["Unit"].ToString()=="PMB")
            {
                Response.Redirect("~/op/lst.aspx");
            }
            else if (this.Session["NamaUser"] != null && this.Session["Unit"].ToString() == "BAKPK")
            {
                Response.Redirect("~/user/mark.aspx");
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            // ---- avoid back after logout -----
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.AppendCacheExtension("no-cache");
            Response.Expires = 0;

            Page.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);

            HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(false);
            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            // --- End aviod back after logout -------


            if (this.TbUser.Text == "" || this.TBPasswd.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('FIELD TIDAK BOLEH KOSONG');", true);
                return;
            }

            if (this.Session["NoDaftar"] == null && this.Session["PIN"] == null)
            {
                if (!Autentication(this.TbUser.Text, this.TBPasswd.Text))
                {
                    return;
                }
                else
                {

                    try
                    {
                        //-------------------- Lihat Pengguna { mhs,unit(pmb,bakpk) } ----------------//
                        string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            con.Open();
                            // a. ------- Pendaftar / Calon Mahasiswa -------
                            SqlCommand CmdCekMhs = new SqlCommand("SpCekMhs", con);
                            CmdCekMhs.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdCekMhs.Parameters.AddWithValue("@no_daftar", this.TbUser.Text);

                            using (SqlDataReader rdr = CmdCekMhs.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.Session["Jalur"] = rdr["jalur"].ToString().Trim();
                                    }

                                    this.Session["NoDaftar"] = this.TbUser.Text;
                                    this.Session["PIN"] = this.TBPasswd.Text;

                                    Response.Redirect("Pri.aspx");
                                    return;
                                }
                            }

                            // b. --------- Unit Pengguna --------------
                            SqlCommand CmdCekUnit = new SqlCommand("SpCekUnitPengguna", con);
                            CmdCekUnit.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdCekUnit.Parameters.AddWithValue("@namauser", this.TbUser.Text);

                            using (SqlDataReader rdrUnit = CmdCekUnit.ExecuteReader())
                            {
                                if (rdrUnit.HasRows)
                                {
                                    this.Session["NamaUser"] = this.TbUser.Text;

                                    while (rdrUnit.Read())
                                    {
                                        string unit = rdrUnit["unit"].ToString();
                                        if (unit == "pmb")
                                        {
                                            this.Session["Unit"] = "PMB";
                                            Response.Redirect("~/op/lst.aspx");
                                        }
                                        else if (unit == "bakpk")
                                        {
                                            this.Session["Unit"] = "BAKPK";
                                            Response.Redirect("~/user/mark.aspx");
                                        }
                                        else if (unit == "puskom")
                                        {
                                            this.Session["Unit"] = "PUSKOM";
                                        }
                                    }
                                }
                                else
                                {
                                    Response.Redirect("~/Login.aspx");
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message.ToString());
                    }
                }
            }
        }

        private bool Autentication(string no_daftar, string pin)
        {
            this.LbResult.Text = "";
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmdLogin = new SqlCommand("SpUKTLogin", con);
                    cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

                    cmdLogin.Parameters.AddWithValue("@no_daftar", no_daftar);
                    cmdLogin.Parameters.AddWithValue("@pin", pin);

                    con.Open();
                    cmdLogin.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message.ToString());
                this.TbUser.Text = "";
                this.TBPasswd.Text = "";
                //this.TBReCaptcha.Text = "";
                this.LbResult.Text = ex.Message.ToString();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                return false;
            }
        }
    }
}