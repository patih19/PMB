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

namespace pmb.sm
{
    public partial class WebForm7 : pmb_login
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

            // ----------------------------Lihat Hasil Pencarian------------------------------------------------
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                // ---------------------- Cari Pendaftar Cabut ---------------------------------
                SqlCommand CmdCabut = new SqlCommand("SpCariPendaftarCabut", con);
                CmdCabut.CommandType = System.Data.CommandType.StoredProcedure;

                CmdCabut.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text);

                DataTable TblPendaftr = new DataTable();
                TblPendaftr.Columns.Add("Nomor Tagihan/Jurnal");
                TblPendaftr.Columns.Add("Program Studi I");
                TblPendaftr.Columns.Add("Program Studi II");
                TblPendaftr.Columns.Add("Nilai");

                using (SqlDataReader rdr = CmdCabut.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TblPendaftr.NewRow();
                            datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
                            datarow["Program Studi I"] = rdr["prodi1"];
                            datarow["Program Studi II"] = rdr["prodi2"];
                            datarow["Nilai"] = rdr["nilai"];

                            TblPendaftr.Rows.Add(datarow);
                        }
                        //Fill Gridview
                        this.GVCabut.DataSource = TblPendaftr;
                        this.GVCabut.DataBind();
                    }
                    else
                    {
                        //clear Gridview
                        TblPendaftr.Rows.Clear();
                        TblPendaftr.Clear();
                        this.GVCabut.DataSource = TblPendaftr;
                        this.GVCabut.DataBind();

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Data Tidak Ditemukan');", true);
                        return;
                    }
                }
                CmdCabut.Dispose();
            }
        }
    }
}