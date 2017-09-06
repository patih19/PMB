using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace pmb.sm
{
    public partial class WebForm9 : pmb_login
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
            this.Session["system"] = null;
            this.Session["level"] = null;
            this.Session.Remove("Name");
            this.Session.Remove("system");
            this.Session.Remove("level");
            this.Session.RemoveAll();
            this.Session.Abandon();

            this.Response.Redirect("~/pmb_untidar.aspx", false);
        }
        //---------------- End logout ------------------

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLihat_Click(object sender, EventArgs e)
        {

            if (this.DLProdi.SelectedItem.Text == "Program Studi")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Program Studi');", true);
                return;
            }

            this.LbProdi.Text = DLProdi.SelectedItem.Text;
            this.LbProdi.ForeColor = System.Drawing.Color.Blue;

            // ----------------------------Lihat Hasil Pencarian------------------------------------------------
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                // ---------------------- Lihat Pendaftar Diterima ---------------------------------
                SqlCommand CmdHasil = new SqlCommand("SpListDiterima", con);
                CmdHasil.CommandType = System.Data.CommandType.StoredProcedure;

                CmdHasil.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text);

                DataTable TblHasil = new DataTable();
                TblHasil.Columns.Add("Nomor Tagihan/Jurnal");
                TblHasil.Columns.Add("Nama");
                TblHasil.Columns.Add("Nilai");


                using (SqlDataReader rdr = CmdHasil.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TblHasil.NewRow();
                            datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];
                            datarow["Nilai"] = rdr["nilai"];

                            TblHasil.Rows.Add(datarow);
                        }

                        //Fill Gridview
                        this.GVHasil.DataSource = TblHasil;
                        this.GVHasil.DataBind();

                    }
                    else
                    {
                        //clear Gridview
                        TblHasil.Rows.Clear();
                        TblHasil.Clear();
                        this.GVHasil.DataSource = TblHasil;
                        this.GVHasil.DataBind();

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Data Tidak Ditemukan');", true);
                        return;
                    }
                }

                CmdHasil.Dispose();
            }
        }
    }
}