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

namespace smuntidar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelDetailPendaftar.Enabled = false;
                this.PanelDetailPendaftar.Visible = false;
            }
        }

        protected void DLProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DLProdi.SelectedItem.Text == "Program Studi")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Program Studi');", true);
                return;
            }

            this.PanelDetailPendaftar.Enabled = true;
            this.PanelDetailPendaftar.Visible = true;

            LoadGridView(0, this.GVPendaftar.PageSize);
 

        }

        private void LoadGridView(int PageIndex, int PageSize)
        {
            int TotalRows = 0;

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                // --------------------- Fill Gridview  ------------------------
                SqlCommand CmdKRS = new SqlCommand("SpViewPendaftar2", con);
                CmdKRS.CommandType = System.Data.CommandType.StoredProcedure;

                CmdKRS.Parameters.AddWithValue("@index", PageIndex);
                CmdKRS.Parameters.AddWithValue("@size", this.GVPendaftar.PageSize);
                CmdKRS.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text);

                SqlParameter TotalRow = new SqlParameter();
                TotalRow.ParameterName = "@totalRow";
                TotalRow.SqlDbType = System.Data.SqlDbType.Int;
                TotalRow.Size = 20;
                TotalRow.Direction = System.Data.ParameterDirection.Output;
                CmdKRS.Parameters.Add(TotalRow);

                DataTable TableKRS = new DataTable();
                TableKRS.Columns.Add("No");
                TableKRS.Columns.Add("No Jurnal/Tagihan");
                TableKRS.Columns.Add("Nama");
                TableKRS.Columns.Add("Nilai Akhir");

                using (SqlDataReader rdr = CmdKRS.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TableKRS.NewRow();
                            datarow["No"] = rdr["urutan"];
                            datarow["No Jurnal/Tagihan"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];
                            datarow["Nilai Akhir"] = rdr["nilai"];

                            TableKRS.Rows.Add(datarow);
                        }

                        rdr.Close();
                        TotalRows = (int)CmdKRS.Parameters["@totalRow"].Value;

                        //this.DLKelas.SelectedIndex = 0;

                        //Fill Gridview
                        this.GVPendaftar.DataSource = TableKRS;
                        this.GVPendaftar.DataBind();
                    }
                    else
                    {
                        //clear Gridview
                        TableKRS.Rows.Clear();
                        TableKRS.Clear();
                        GVPendaftar.DataSource = TableKRS;
                        GVPendaftar.DataBind();
                    }
                }
            }

            //paging
            DataBindRepeater(PageIndex, this.GVPendaftar.PageSize, TotalRows);
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
            this.GVPendaftar.PageIndex = PageIndex;

            LoadGridView(PageIndex, this.GVPendaftar.PageSize);
        }
    }
}