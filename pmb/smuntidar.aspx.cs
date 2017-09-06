using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace pmb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //prevent back after login on page init
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["Name"] == null && this.Session["system"] == null)
            {
                // ---- avoid back after logout -----
                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.AppendHeader("Pragma", "no-cache");

                HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
                HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();
                // --- End aviod back after logout -------
            }
            else if (this.Session["system"].ToString() == "smuntidar" && (this.Session["level"].ToString() == "staff"))
            {
                // kehalaman smuntidar staff
                Response.Redirect("~/sm/staff/home.aspx");
            }
            else if (this.Session["system"].ToString() == "smuntidar" && (this.Session["level"].ToString() == "admin" || this.Session["level"].ToString() == "super"))
            {
                // kehalaman smuntidar admin
                Response.Redirect("~/sm/admin/home.aspx");
            }
            else if (this.Session["system"].ToString() == "umuntidar" && (this.Session["level"].ToString() == "staff"))
            {
                // kehalaman umuntidar staff
                Response.Redirect("~/um/staff/home.aspx");
            }
            else if (this.Session["system"].ToString() == "umuntidar" && (this.Session["level"].ToString() == "admin" || this.Session["level"].ToString() == "super"))
            {
                // kehalaman umuntidar admin
                Response.Redirect("~/um/admin/home.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // ---- avoid back after logout -----
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            // --- End aviod back after logout -------

            if (Page.IsPostBack) // user must login first
            {
                if (this.Session["Name"] == null && this.Session["system"] == null)
                {

                } 
                else if (this.Session["system"].ToString() == "smuntidar" && (this.Session["level"].ToString() == "staff"))
                {
                    // kehalaman smuntidar staff
                    Response.Redirect("~/sm/staff/home.aspx");
                }
                else if (this.Session["system"].ToString() == "smuntidar" && (this.Session["level"].ToString() == "admin" || this.Session["level"].ToString() == "super"))
                {
                    // kehalaman smuntidar admin
                    Response.Redirect("~/sm/admin/home.aspx");
                }
                else if (this.Session["system"].ToString() == "umuntidar" && (this.Session["level"].ToString() == "staff"))
                {
                    // kehalaman umuntidar staff
                    Response.Redirect("~/um/staff/home.aspx");
                }
                else if (this.Session["system"].ToString() == "umuntidar" && (this.Session["level"].ToString() == "admin" || this.Session["level"].ToString() == "super"))
                {
                    // kehalaman umuntidar admin
                    Response.Redirect("~/um/admin/home.aspx");
                }
            }
        }

        //Login button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (this.DLSystem.SelectedValue == "sim")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih SM-UNTIDAR atau UM-UNTIDAR');", true);
                return;
            }

            if (this.DLSystem.SelectedValue == "smuntidar")
            {
                if (this.Session["Name"] == null && this.Session["system"] == null)
                {
                    if (!Autentication(this.TextBox5.Text, this.TextBox6.Text))
                    {
                        return;
                    }
                    else
                    {
                        this.Session["Name"] = this.TextBox5.Text;
                        this.Session["system"] = "smuntidar";

                        // ---------------------- Lihat Level ---------------------------------
                        string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            con.Open();

                            SqlCommand CmdLevel = new SqlCommand("SpLihatLevel", con);
                            CmdLevel.CommandType = System.Data.CommandType.StoredProcedure;

                            CmdLevel.Parameters.AddWithValue("@user", this.TextBox5.Text);
                            CmdLevel.Parameters.AddWithValue("@passwd", this.TextBox6.Text);

                            using (SqlDataReader rdr = CmdLevel.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        if (rdr["tingkatan"].ToString() == "admin" || rdr["tingkatan"].ToString() == "super")
                                        {
                                            this.Session["level"] = "admin";
                                            Response.Redirect("~/sm/admin/home.aspx");
                                        }
                                        else if (this.Session["level"].ToString() == "staff")
                                        {
                                            this.Session["level"] = "staff";
                                            Response.Redirect("~/sm/staff/home.aspx");
                                        }
                                    }
                                }
                                else
                                {
                                    // -- Invalid Level
                                    // -- tidak mungkin karena usernya ada, kecualai level belum diisi
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/sm/admin/home.aspx");
                }

            }


            if (this.DLSystem.SelectedValue == "umuntidar")
            {

            }

        }

        private bool Autentication(string user, string passwd)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand CmdSmLogin = new SqlCommand("SpSmUserLogin", con);
                    CmdSmLogin.CommandType = System.Data.CommandType.StoredProcedure;

                    CmdSmLogin.Parameters.AddWithValue("@user", user);
                    CmdSmLogin.Parameters.AddWithValue("@passwd", passwd);

                    con.Open();
                    CmdSmLogin.ExecuteNonQuery();

                    return true;
                }


            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Login Gagal, " + ex.Message.ToString() + "');", true);
                return false;
            }
        }
    }
}