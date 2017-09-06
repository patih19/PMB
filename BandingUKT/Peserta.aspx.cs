using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BandingUKT
{
    public partial class Peserta : User
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HtmlGenericControl control = (HtmlGenericControl)base.Master.FindControl("NavMonitor");
                control.Attributes.Add("class", "dropdown active opened");
                HtmlGenericControl control2 = (HtmlGenericControl)base.Master.FindControl("NavExample");
                control2.Attributes.Add("style", "display: none;");

                this.PanelMhs.Enabled = false;
                this.PanelMhs.Visible = false;
            }
        }

        protected void BtnInput_Click(object sender, EventArgs e)
        {

            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            //this.GVCekInput.Rows[index].Cells[1].Text.Trim();
            Response.Redirect("~/Pribadi.aspx?npm=" + this.GVCekInput.Rows[index].Cells[1].Text.Trim() + "");
        }

        protected void GVCekInput_PreRender(object sender, EventArgs e)
        {
            if (this.GVCekInput.Rows.Count > 0)
            {
                // this replace <td> with <th> and add the scope attribute
                GVCekInput.UseAccessibleHeader = true;

                //this will add the <thead> and <tbody> elements
                GVCekInput.HeaderRow.TableSection = TableRowSection.TableHeader;

                //this adds the <tfoot> element
                //remove if you don't have a footer row
                //GVJadwal.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void BtnCari_Click(object sender, EventArgs e)
        {
            HtmlGenericControl control = (HtmlGenericControl)base.Master.FindControl("NavMonitor");
            control.Attributes.Add("class", "dropdown active opened");
            HtmlGenericControl control2 = (HtmlGenericControl)base.Master.FindControl("NavExample");
            control2.Attributes.Add("style", "display: none;");


            string CS = ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand("SELECT bak_mahasiswa.npm, bak_mahasiswa.nama, bak_prog_study.prog_study, bak_mahasiswa.thn_angkatan, bak_mahasiswa.gelombang "+
                                                    "FROM            bak_mahasiswa INNER JOIN "+
                                                                             "bak_prog_study ON bak_mahasiswa.id_prog_study = bak_prog_study.id_prog_study "+
                                                    "WHERE bak_mahasiswa.status='A' AND npm=@npm", con);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@npm", this.TbNpm.Text.Trim());


                DataTable Table = new DataTable();
                Table.Columns.Add("NPM");
                Table.Columns.Add("Nama");
                //Table.Columns.Add("Jalur");
                Table.Columns.Add("Program Studi");
                Table.Columns.Add("Tahun");
                Table.Columns.Add("Jalur");


                con.Open();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        this.PanelMhs.Enabled = true;
                        this.PanelMhs.Visible = true;

                        while (rdr.Read())
                        {
                            DataRow datarow = Table.NewRow();
                            datarow["NPM"] = rdr["npm"];
                            datarow["Nama"] = rdr["nama"].ToString().ToUpper();
                            datarow["Program Studi"] = rdr["prog_study"].ToString().ToUpper();
                            datarow["Tahun"] = rdr["thn_angkatan"].ToString().ToUpper();
                            datarow["Jalur"] = rdr["gelombang"].ToString().ToUpper();

                            Table.Rows.Add(datarow);
                        }

                        //Fill Gridview
                        this.GVCekInput.DataSource = Table;
                        this.GVCekInput.DataBind();

                        Table.Dispose();
                    }
                    else
                    {
                        //clear Gridview
                        Table.Rows.Clear();
                        Table.Clear();
                        GVCekInput.DataSource = Table;
                        GVCekInput.DataBind();
                    }
                }
            }
        }
    }
}