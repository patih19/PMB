using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BandingUKT
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (this.Session["nama"] != null)
                {
                    Response.Redirect("~/Peserta.aspx");
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Session["nama"] == null)
                {
                    if (!Autentication(this.TbUser.Text.Trim(), this.TbPass.Text.Trim()))
                    {
                        return;
                    }
                    else
                    {
                        //this.Session["no_akun"] = this.TbUser.Text.Trim();
                        //this.Session["password"] = this.TbPassword.Text.Trim();

                        // ------------------- Add Sesion No Tagihan -----------------
                        string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            con.Open();
                            //SqlTransaction trans = con.BeginTransaction();

                            SqlCommand CmdPeriodik = new SqlCommand("select no, username from ukt_login_bm where username=@username AND password=@password", con);
                            //CmdPeriodik.Transaction = trans;
                            CmdPeriodik.CommandType = System.Data.CommandType.Text;

                            CmdPeriodik.Parameters.AddWithValue("@username", this.TbUser.Text.Trim());
                            CmdPeriodik.Parameters.AddWithValue("@password", this.TbPass.Text.Trim());

                            using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.Session["nama"] = rdr["username"].ToString();
                                    }
                                }
                                else
                                {
                                    // no akun tidak ditemukan / belum diinput
                                    return;
                                }
                            }
                        }

                        Response.Redirect("~/Peserta.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Peserta.aspx");
                }

            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        private bool Autentication(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    // ====================== CEK VALIDASI ==============================
                    SqlCommand CmdCekLogin = new SqlCommand("select no from ukt_login_bm where username=@username AND password=@password", connection);
                    CmdCekLogin.CommandType = System.Data.CommandType.Text;

                    CmdCekLogin.Parameters.AddWithValue("@username", username);
                    CmdCekLogin.Parameters.AddWithValue("@password", password);

                    SqlDataReader readerVal = CmdCekLogin.ExecuteReader();
                    if (readerVal.HasRows)
                    {
                        readerVal.Close();
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        readerVal.Close();
                        connection.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return false;
                }
            }

        }
    }
}