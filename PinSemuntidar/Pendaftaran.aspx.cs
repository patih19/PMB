using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PinSemuntidar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // prevent back after login on page init
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["Name"] == null && this.Session["password"] == null)
            {

            }
            else
            {
                Response.Redirect("~/user/home.aspx");
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
                if (this.Session["Name"] != null && this.Session["password"] != null)
                {
                    Response.Redirect("~/user/home.aspx");
                }
                else
                {
                    return;
                }
            }
        }

        protected void BtLogin_Click(object sender, EventArgs e)
        {
            this.Captcha.ValidateCaptcha(this.TBReCaptcha.Text.Trim());
            if (this.Captcha.UserValidated)
            {

                if (this.Session["Name"] == null && this.Session["password"] == null)
                {
                    if (!Autentication(this.TBNoTagihan.Text, this.TBPin.Text))
                    {
                        return;
                    }
                    else
                    {
                        this.Session["Name"] = this.TBNoTagihan.Text;
                        this.Session["password"] = this.TBPin.Text;
                        Response.Redirect("~/user/home.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/user/home.aspx");
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                return;
            }
        }

        private bool Autentication(string bill, string pin)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmdLogin = new SqlCommand("SpSmintidarLogin", con);
                    cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

                    cmdLogin.Parameters.AddWithValue("@bill", bill);
                    cmdLogin.Parameters.AddWithValue("@pin", pin);

                    con.Open();
                    cmdLogin.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Login Gagal, " + ex.Message.ToString() + "');", true);
                //ex.Message.ToString();
                return false;
            }
        }
    }
}