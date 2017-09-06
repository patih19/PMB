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
    public partial class WebForm5 : pmb_login
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
            //if (!Page.IsPostBack)
            //{
            //    // ----------------------------Lihat Hasil Pencarian------------------------------------------------
            //    string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(CS))
            //    {
            //        con.Open();

            //        // ---------------------- Cari Pendaftar ---------------------------------
            //        SqlCommand CmdToday = new SqlCommand("SpDaftarToday", con);
            //        CmdToday.CommandType = System.Data.CommandType.StoredProcedure;


            //        DataTable TblToday = new DataTable();
            //        TblToday.Columns.Add("Nomor Tagihan/Jurnal");
            //        TblToday.Columns.Add("Nama");
            //        TblToday.Columns.Add("Pilihan I");
            //        TblToday.Columns.Add("Pilihan II");
            //        TblToday.Columns.Add("Nilai");

            //        using (SqlDataReader rdr = CmdToday.ExecuteReader())
            //        {
            //            if (rdr.HasRows)
            //            {
            //                while (rdr.Read())
            //                {
            //                    DataRow datarow = TblToday.NewRow();
            //                    datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
            //                    datarow["Nama"] = rdr["nama"];
            //                    datarow["Pilihan I"] = rdr["pilihan_1"];
            //                    datarow["Pilihan II"] = rdr["pilihan_2"];
            //                    datarow["Nilai"] = rdr["nilai"];

            //                    TblToday.Rows.Add(datarow);
            //                }

            //                //Fill Gridview
            //                this.GVToday.DataSource = TblToday;
            //                this.GVToday.DataBind();

            //            }
            //            else
            //            {
            //                //clear Gridview
            //                TblToday.Rows.Clear();
            //                TblToday.Clear();
            //                GVToday.DataSource = TblToday;
            //                GVToday.DataBind();
            //            }
            //        }

            //        CmdToday.Dispose();
            //    }              
            //}
        }

        protected void BtFilter_Click(object sender, EventArgs e)
        {
            // ------------------- Validasi --------------------
            if (this.TbTgl1.Text == "" || this.TbTgl2.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Input Tanggal');", true);
                return;
            }

            LoadGridView(0, this.GVToday.PageSize);
 
        }

        protected void PageButton_Click(object sender, EventArgs e)
        {
            int PageIndex = int.Parse((sender as LinkButton).CommandArgument);
            PageIndex -= 1;
            GVToday.PageIndex = PageIndex;

            LoadGridView(PageIndex, this.GVToday.PageSize);
        }

        private void LoadGridView(int PageIndex, int PageSize)
        {
            int TotalRows = 0;

            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                // --------------------- Fill Gridview  ------------------------
                SqlCommand CmdKRS = new SqlCommand("SpViewPendaftar", con);
                CmdKRS.CommandType = System.Data.CommandType.StoredProcedure;

                CmdKRS.Parameters.AddWithValue("@index", PageIndex);
                CmdKRS.Parameters.AddWithValue("@size", this.GVToday.PageSize);
                CmdKRS.Parameters.AddWithValue("@tgl1", this.TbTgl1.Text);
                CmdKRS.Parameters.AddWithValue("@tgl2", this.TbTgl2.Text);

                SqlParameter TotalRow = new SqlParameter();
                TotalRow.ParameterName = "@totalRow";
                TotalRow.SqlDbType = System.Data.SqlDbType.Int;
                TotalRow.Size = 20;
                TotalRow.Direction = System.Data.ParameterDirection.Output;
                CmdKRS.Parameters.Add(TotalRow);

                DataTable TableKRS = new DataTable();
                TableKRS.Columns.Add("No");
                TableKRS.Columns.Add("No Jurnal");
                TableKRS.Columns.Add("Nama");
                TableKRS.Columns.Add("Pilihan I");
                TableKRS.Columns.Add("Pilihan II");
                TableKRS.Columns.Add("Nilai");

                using (SqlDataReader rdr = CmdKRS.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TableKRS.NewRow();
                            datarow["No"] = rdr["urutan"];
                            datarow["No Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];
                            datarow["Pilihan I"] = rdr["pilihan_1"];
                            datarow["Pilihan II"] = rdr["pilihan_2"];
                            datarow["Nilai"] = rdr["nilai"];

                            TableKRS.Rows.Add(datarow);
                        }

                        rdr.Close();
                        TotalRows = (int)CmdKRS.Parameters["@totalRow"].Value;

                        //this.DLKelas.SelectedIndex = 0;

                        //Fill Gridview
                        this.GVToday.DataSource = TableKRS;
                        this.GVToday.DataBind();
                    }
                    else
                    {
                        //clear Gridview
                        TableKRS.Rows.Clear();
                        TableKRS.Clear();
                        GVToday.DataSource = TableKRS;
                        GVToday.DataBind();
                    }
                }
            }

            //paging
            DataBindRepeater(PageIndex, this.GVToday.PageSize, TotalRows);
        }

        private void DataBindRepeater(int pageIndex, int pageSize, int totalRows)
        {
            int totalPage = totalRows / pageSize;
            if ((totalRows % pageSize) != 0)
            {
                totalPage += 1;
            }

            List<ListItem> pages = new List<ListItem>();
            if (totalPage > 1)
            {
                for (int i = 1; i <= totalPage; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != (pageIndex + 1)));
                }
            }

            Repeater1.DataSource = pages;
            Repeater1.DataBind();
        }

    }
}