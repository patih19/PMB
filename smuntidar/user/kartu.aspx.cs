using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace smuntidar.user
{
    //public partial class kartu : System.Web.UI.Page
    public partial class kartu : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smuntidar_foto where smuntidar_foto.no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["Name"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["proses_komplet"].ToString() == "ok")
                                {

                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    Response.Redirect("~/user/confirm.aspx");
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
    }
}