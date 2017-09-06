using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace smuntidar.user
{
    //public partial class WebForm10 : System.Web.UI.Page
    public partial class WebForm10 : user_login
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
                this.LbTrans.Text = this.Session["Name"].ToString();

                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smuntidar_pilihan where smuntidar_pilihan.no_tagihan=@no_tagihan", con);
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
                                    Response.Redirect("~/user/pasfoto.aspx",false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    Response.Redirect("~/user/confirm.aspx",false);
                                }
                            }
                        }
                        else
                        {
                            // data no tagihan tidak ditemukan, sepertinya tidak mungkin karena user sudah bisa login
                        }
                    }
                }
                //---------------------------------- End Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.DLPil1.SelectedItem.Text == "Pilihan I")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pilihan Pertama ');", true);
                return;
            }

            if (this.DlPil2.SelectedItem.Text == "Pilihan II")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pilihan Kedua ');", true);
                return;
            }

            if (this.DLPil1.SelectedItem.Text == this.DlPil2.SelectedItem.Text)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Program Studi Tidak Boleh Sama');", true);
                return;
            }

            //Action to save to DB
             string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
             using (SqlConnection con = new SqlConnection(CS))
             {
                 try
                 {
                     //open connection and begin transaction
                     con.Open();
                     //SqlTransaction trans = con.BeginTransaction();

                     // Insert to DB ---
                     SqlCommand cmd = new SqlCommand("SpInsertPilihan", con);
                     //cmd.Transaction = trans;
                     cmd.CommandType = System.Data.CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                     cmd.Parameters.AddWithValue("@pil1", this.DLPil1.SelectedItem.Text);
                     if (this.DlPil2.SelectedItem.Text == "")
                     {
                         cmd.Parameters.AddWithValue("@pil2", DBNull.Value);
                     }
                     else if (this.DlPil2.SelectedItem.Text != "")
                     {
                         cmd.Parameters.AddWithValue("@pil2", this.DlPil2.SelectedItem.Text);
                     }

                     cmd.ExecuteNonQuery();

                     Response.Redirect("~/user/pasfoto.aspx",false);
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