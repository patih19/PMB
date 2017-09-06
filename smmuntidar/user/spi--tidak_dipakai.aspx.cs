using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace smmuntidar.user
{
    //public partial class WebForm2 : System.Web.UI.Page
    public partial class WebForm2 : user_login
    {
        //------------- LogOut ------------------------------//
        protected override void OnInit(EventArgs e)
        {
            // Your code
            base.OnInit(e);
            keluar.ServerClick += new EventHandler(logout_ServerClick);
        }

        protected void logout_ServerClick(object sender, EventArgs e)
        {
            //Your Code here....
            this.Session["Name"] = null;
            this.Session["Passwd"] = null;
            this.Session.Remove("Name");
            this.Session.Remove("Passwd");
            this.Session.Remove("no_tagihan");
            this.Session.RemoveAll();

            this.Response.Redirect("~/Pendaftaran.aspx", false);
        }
        //---------------- End logout ------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //hide panel biaya
                this.PanelBiaya.Visible = false;
                this.PanelBiaya.Enabled = false;

                this.LbTrans.Text = this.Session["Name"].ToString();

                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_spi where smmuntidar_spi.no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["proses_komplet"].ToString() == "ok")
                                {
                                    Response.Redirect("~/user/pasfoto.aspx", false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    Response.Redirect("~/user/confirm.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            // data no tagihan tidak ditemukan, sepertinya tidak mungkin kaarena user sudah bisa login
                        }
                    }
                }
                //---------------------------------- End Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
            }
        }

        protected void BtnSpi_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(500);

                //Response.Write(int.Parse(Regex.Replace(this.TbSumbangan.Text, @",.*|\D", "")).ToString());
                decimal sumbangan = int.Parse(Regex.Replace(this.TbSumbangan.Text, @",.*|\D", ""));

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                        //========================== INPUT SPI =========================
                        SqlCommand cmdSPI = new SqlCommand("SpInsertSPI", connection);
                        cmdSPI.CommandType = System.Data.CommandType.StoredProcedure;

                        cmdSPI.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                        cmdSPI.Parameters.AddWithValue("@sumb", sumbangan);
                        cmdSPI.ExecuteNonQuery();

                        Response.Redirect("~/user/pasfoto.aspx", false);

                    }
                    catch (Exception ex)
                    {
                        this.LbError.Text = ex.Message.ToString();
                        this.LbError.ForeColor = System.Drawing.Color.Red;
                    }
                }                
            }
            catch (Exception ex)
            {
                this.LbError.Text = ex.Message.ToString();
            }
        }

        protected void TbSumbangan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);

                this.PanelBiaya.Enabled = true;
                this.PanelBiaya.Visible = true;

                int SumbSPI = Convert.ToInt32(this.TbSumbangan.Text);
                string FormattedString = string.Format
                    (new System.Globalization.CultureInfo("id"), "{0:c}", SumbSPI);

                this.LbSumbangan.Text = FormattedString;
                this.LbError.ForeColor = System.Drawing.Color.Black;

                this.LbError.Text = "";
            }
            catch (Exception )
            {
                this.PanelBiaya.Enabled = false;
                this.PanelBiaya.Visible = false;

                //this.LbError.Text = ex.Message.ToString();
                //this.LbError.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}