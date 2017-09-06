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
using System.Globalization;

namespace pmb.sm
{
    public partial class WebForm3 : pmb_login
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
            if(!Page.IsPostBack)
            {
                this.PnlPIN.Enabled = false;
                this.PnlPIN.Visible = false;
            }
        }

        protected void BtnCari_Click(object sender, EventArgs e)
        {
            if (this.TbNama.Text=="")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Kriteria Pencarian');", true);
                return;
            }

            this.PnlPIN.Enabled = false;
            this.PnlPIN.Visible = false;

            // ----------------------------Lihat Hasil Pencarian------------------------------------------------
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                // ---------------------- Cari Pendaftar ---------------------------------
                SqlCommand CmdCari = new SqlCommand("SpCariPendaftar2", con);
                CmdCari.CommandType = System.Data.CommandType.StoredProcedure;

                CmdCari.Parameters.AddWithValue("@var", this.TbNama.Text);

                DataTable TblPendaftr = new DataTable();
                TblPendaftr.Columns.Add("Nomor Tagihan/Jurnal");
                TblPendaftr.Columns.Add("Nama");


                using (SqlDataReader rdr = CmdCari.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TblPendaftr.NewRow();
                            datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];

                            TblPendaftr.Rows.Add(datarow);
                        }

                        //Fill Gridview
                        this.GVTerdaftar.DataSource = TblPendaftr;
                        this.GVTerdaftar.DataBind();

                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Data Tidak Ditemukan');", true);
                        this.TbNama.Text = "";
                        this.LbNoTagihan.Text = "";

                        //clear Gridview 
                        TblPendaftr.Rows.Clear();
                        TblPendaftr.Clear();
                        GVTerdaftar.DataSource = TblPendaftr;
                        GVTerdaftar.DataBind();
                    }
                }

                CmdCari.Dispose();
            }
        }

        protected void BtnLihat_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                //SqlTransaction trans = con.BeginTransaction();

                SqlCommand CmdPIN = new SqlCommand("SpLihatPIN", con);
                //CmdPeriodik.Transaction = trans;
                CmdPIN.CommandType = System.Data.CommandType.StoredProcedure;
                CmdPIN.Parameters.AddWithValue("@no_tagihan", this.GVTerdaftar.Rows[0].Cells[1].Text);

                DataTable TblPendaftr = new DataTable();
                TblPendaftr.Columns.Add("Nomor Tagihan/Jurnal");
                TblPendaftr.Columns.Add("Nama");
                TblPendaftr.Columns.Add("PIN");

                using (SqlDataReader rdr = CmdPIN.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TblPendaftr.NewRow();
                            datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];
                            datarow["PIN"] = rdr["pin"];

                            TblPendaftr.Rows.Add(datarow);
                        }

                        this.PnlPIN.Enabled = true;
                        this.PnlPIN.Visible = true;

                        //Fill Gridview
                        this.GVPin.DataSource = TblPendaftr;
                        this.GVPin.DataBind();
                    }
                    else
                    {
                        //clear Gridview
                        TblPendaftr.Rows.Clear();
                        TblPendaftr.Clear();
                        GVPin.DataSource = TblPendaftr;
                        GVPin.DataBind();
                    }
                }
                CmdPIN.Dispose();

                // LihatFoto(this.Session["Name"].ToString());
            }
        }

        protected void GVTerdaftar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ------------- GET ROW INDEX --------------------
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = this.GVTerdaftar.SelectedRow;

            // Display the first name from the selected row.
            // In this example, the third column (index 1) contains
            // the first name.
            this.LbNoTagihan.Text = "Nomor Tagihan : " + row.Cells[1].Text;

            //-------------- View PIN --------------------
           string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
           using (SqlConnection con = new SqlConnection(CS))
           {
               con.Open();
               //SqlTransaction trans = con.BeginTransaction();

               SqlCommand CmdPIN = new SqlCommand("SpLihatPIN", con);
               //CmdPeriodik.Transaction = trans;
               CmdPIN.CommandType = System.Data.CommandType.StoredProcedure;
               CmdPIN.Parameters.AddWithValue("@no_tagihan", row.Cells[1].Text);

               DataTable TblPendaftr = new DataTable();
               TblPendaftr.Columns.Add("Nomor Tagihan/Jurnal");
               TblPendaftr.Columns.Add("Nama");
               TblPendaftr.Columns.Add("PIN");

               using (SqlDataReader rdr = CmdPIN.ExecuteReader())
               {
                   if (rdr.HasRows)
                   {
                       while (rdr.Read())
                       {
                           DataRow datarow = TblPendaftr.NewRow();
                           datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
                           datarow["Nama"] = rdr["nama"];
                           datarow["PIN"] = rdr["pin"];

                           TblPendaftr.Rows.Add(datarow);
                       }

                       this.PnlPIN.Enabled = true;
                       this.PnlPIN.Visible = true;

                       //Fill Gridview
                       this.GVPin.DataSource = TblPendaftr;
                       this.GVPin.DataBind();
                   }
                   else
                   {
                       //clear Gridview
                       TblPendaftr.Rows.Clear();
                       TblPendaftr.Clear();
                       GVPin.DataSource = TblPendaftr;
                       GVPin.DataBind();
                   }
               }
               CmdPIN.Dispose();
           }
        }
    }
}