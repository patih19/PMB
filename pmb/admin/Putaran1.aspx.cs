using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace pmb.admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelSortPuatarnSatu.Visible = true;
                this.PanelSortPuatarnSatu.Enabled = true;


                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand CmdTerimaPertama = new SqlCommand("SELECT no_tagihan,diterima_putaran,tahun FROM smmuntidar_nilai WHERE tahun =(select top 1 tahun from smmuntidar_tagihan group by tahun order by tahun desc)", con);
                    CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

                   
                    using (SqlDataReader rdr = CmdTerimaPertama.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            this.LbSortI.Text = "Putaran Satu Sudah Ditutup";
                            this.BtnSort.Enabled = false;
                            this.BtnSort.Visible = false;
                        }

                    }
                }
            }
        }

        protected void BtnSort_Click(object sender, EventArgs e)
        {
            try
            {
                //// ---------- Gridview SKS ------------------
                //string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                //using (SqlConnection con = new SqlConnection(CS))
                //{
                //    con.Open();
                //    SqlCommand CmdQuota = new SqlCommand("SpHitungNilaiDanSpi", con);
                //    CmdQuota.CommandType = System.Data.CommandType.StoredProcedure;
                //    CmdQuota.ExecuteNonQuery();

                //    //---- refresh -----
                //    //Page_Load(this, null);
                //    Response.Redirect(Request.RawUrl);

                //}
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }
}