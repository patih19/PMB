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
    public partial class WebForm6 : pmb_login
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
            if (!Page.IsPostBack)
            {
                LoadGridView(0, this.GVGagal.PageSize);
            }
        }

        protected void BtnLihat_Click(object sender, EventArgs e)
        {
            if (this.DLProdi.SelectedItem.Text == "Program Studi")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Program Studi');", true);
                return;
            }
            
            // Tiap Prodi
            if (this.DLProdi.SelectedItem.Text != "ALL")
            {
                LoadGridView2(0, this.GVGagal.PageSize);
            }
                // Semua Prodi
            else if (this.DLProdi.SelectedItem.Text == "ALL")
            {
                LoadGridView(0, this.GVGagal.PageSize);
            }


        }

        // all prodi
        private void LoadGridView(int PageIndex, int PageSize)
        {
            int TotalRows = 0;

            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                // --------------------- Fill Gridview  ------------------------
                SqlCommand CmdKRS = new SqlCommand("SpListDitolak", con);
                CmdKRS.CommandType = System.Data.CommandType.StoredProcedure;

                CmdKRS.Parameters.AddWithValue("@index", PageIndex);
                CmdKRS.Parameters.AddWithValue("@size", this.GVGagal.PageSize);


                SqlParameter TotalRow = new SqlParameter();
                TotalRow.ParameterName = "@totalRow";
                TotalRow.SqlDbType = System.Data.SqlDbType.Int;
                TotalRow.Size = 20;
                TotalRow.Direction = System.Data.ParameterDirection.Output;
                CmdKRS.Parameters.Add(TotalRow);

                DataTable TableTolak = new DataTable();
                TableTolak.Columns.Add("No");
                TableTolak.Columns.Add("No Jurnal");
                TableTolak.Columns.Add("Nama");
                TableTolak.Columns.Add("Pilihan I");
                TableTolak.Columns.Add("Pilihan II");
                TableTolak.Columns.Add("Nilai");

                using (SqlDataReader rdr = CmdKRS.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TableTolak.NewRow();
                            datarow["No"] = rdr["urutan"];
                            datarow["No Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];
                            datarow["Pilihan I"] = rdr["pilihan_1"];
                            datarow["Pilihan II"] = rdr["pilihan_2"];
                            datarow["Nilai"] = rdr["nilai"];

                            TableTolak.Rows.Add(datarow);
                        }

                        rdr.Close();
                        TotalRows = (int)CmdKRS.Parameters["@totalRow"].Value;

                        //this.DLKelas.SelectedIndex = 0;

                        //Fill Gridview
                        this.GVGagal.DataSource = TableTolak;
                        this.GVGagal.DataBind();
                    }
                    else
                    {
                        //clear Gridview
                        TableTolak.Rows.Clear();
                        TableTolak.Clear();
                        GVGagal.DataSource = TableTolak;
                        GVGagal.DataBind();
                    }
                }
            }

            //paging
            DataBindRepeater(PageIndex, this.GVGagal.PageSize, TotalRows);
        }

        //per prodi
        private void LoadGridView2(int PageIndex, int PageSize)
        {
            int TotalRows = 0;

            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                // --------------------- Fill Gridview  ------------------------
                SqlCommand CmdKRS = new SqlCommand("SpListDitolakProdi", con);
                CmdKRS.CommandType = System.Data.CommandType.StoredProcedure;

                CmdKRS.Parameters.AddWithValue("@index", PageIndex);
                CmdKRS.Parameters.AddWithValue("@size", this.GVGagal.PageSize);
                CmdKRS.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text);


                SqlParameter TotalRow = new SqlParameter();
                TotalRow.ParameterName = "@totalRow";
                TotalRow.SqlDbType = System.Data.SqlDbType.Int;
                TotalRow.Size = 20;
                TotalRow.Direction = System.Data.ParameterDirection.Output;
                CmdKRS.Parameters.Add(TotalRow);

                DataTable TableTolak = new DataTable();
                TableTolak.Columns.Add("No");
                TableTolak.Columns.Add("No Jurnal");
                TableTolak.Columns.Add("Nama");
                TableTolak.Columns.Add("Pilihan I");
                TableTolak.Columns.Add("Pilihan II");
                TableTolak.Columns.Add("Nilai");

                using (SqlDataReader rdr = CmdKRS.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TableTolak.NewRow();
                            datarow["No"] = rdr["urutan"];
                            datarow["No Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];
                            datarow["Pilihan I"] = rdr["pilihan_1"];
                            datarow["Pilihan II"] = rdr["pilihan_2"];
                            datarow["Nilai"] = rdr["nilai"];

                            TableTolak.Rows.Add(datarow);
                        }

                        rdr.Close();
                        TotalRows = (int)CmdKRS.Parameters["@totalRow"].Value;

                        //this.DLKelas.SelectedIndex = 0;

                        //Fill Gridview
                        this.GVGagal.DataSource = TableTolak;
                        this.GVGagal.DataBind();
                    }
                    else
                    {
                        //clear Gridview
                        TableTolak.Rows.Clear();
                        TableTolak.Clear();
                        GVGagal.DataSource = TableTolak;
                        GVGagal.DataBind();
                    }
                }
            }

            //paging
            DataBindRepeater(PageIndex, this.GVGagal.PageSize, TotalRows);
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

        protected void PageButton_Click(object sender, EventArgs e)
        {
            int PageIndex = int.Parse((sender as LinkButton).CommandArgument);
            PageIndex -= 1;
            this.GVGagal.PageIndex = PageIndex;

            LoadGridView(PageIndex, this.GVGagal.PageSize);
        }
    }
}