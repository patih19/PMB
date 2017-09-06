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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand CmdTerimaPertama = new SqlCommand("SELECT smmuntidar_tagihan.no_pendaftar, UPPER( smmuntidar_tagihan.nama) as nama, smmuntidar_nilai.terima, smmuntidar_nilai.diterima_putaran, smmuntidar_nilai.prodi_ke, smmuntidar_nilai.nilai, smmuntidar_tagihan.tahun " +
                        "FROM            smmuntidar_nilai INNER JOIN " +
                                                 "smmuntidar_tagihan ON smmuntidar_nilai.no_tagihan = smmuntidar_tagihan.no_tagihan INNER JOIN " +
                                                 "smmuntidar_identitas ON smmuntidar_tagihan.no_tagihan = smmuntidar_identitas.no_tagihan " +
                        "where terima is not null AND id_prodi is not null AND chk_terima is not null and prodi_ke is not null and diterima_putaran =1 and smmuntidar_tagihan.tahun =(select top 1 tahun from smmuntidar_tagihan group by tahun order by smmuntidar_tagihan.tahun desc)" +
                        "order by terima, nilai desc", con);
                    CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

                    DataTable Table = new DataTable();
                    Table.Columns.Add("No Daftar");
                    Table.Columns.Add("Nama");
                    Table.Columns.Add("Program Studi");
                    Table.Columns.Add("Putaran");
                    //Table.Columns.Add("Pilihan");
                    Table.Columns.Add("Nilai");
                    Table.Columns.Add("Tahun");

                    con.Open();
                    using (SqlDataReader rdr = CmdTerimaPertama.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = Table.NewRow();
                                datarow["No Daftar"] = rdr["no_pendaftar"];
                                datarow["Nama"] = rdr["nama"].ToString().ToUpper(); ;
                                datarow["Program Studi"] = rdr["terima"];
                                datarow["Putaran"] = rdr["diterima_putaran"];
                                //datarow["Pilihan"] = rdr["prodi_ke"];
                                datarow["Nilai"] = rdr["nilai"];
                                datarow["Tahun"] = rdr["tahun"];

                                Table.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVHasilDiterima1.DataSource = Table;
                            this.GVHasilDiterima1.DataBind();

                            Table.Dispose();
                        }
                        else
                        {
                            //clear Gridview
                            Table.Rows.Clear();
                            Table.Clear();
                            GVHasilDiterima1.DataSource = Table;
                            GVHasilDiterima1.DataBind();
                        }
                    }
                }
            }
        }

        protected void GVHasilDiterima1_PreRender(object sender, EventArgs e)
        {
            if (this.GVHasilDiterima1.Rows.Count > 0)
            {
                // this replace <td> with <th> and add the scope attribute
                GVHasilDiterima1.UseAccessibleHeader = true;

                //this will add the <thead> and <tbody> elements
                GVHasilDiterima1.HeaderRow.TableSection = TableRowSection.TableHeader;

                //this adds the <tfoot> element
                //remove if you don't have a footer row
                //GVJadwal.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void GVHasilDiterima1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //// get index row 
            //GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            //int index = GvRow.RowIndex;

            //// get id prodi 1
            //// this.GVHasilDua.Rows[index].Cells[5].Text.Trim();

            //string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    con.Open();

            //    SqlCommand CmdTerimaPertama = new SqlCommand("update smmuntidar_nilai set ditolak_putran_satu = null, chk_terima=null, diterima_putaran=null, prodi_ke=null, id_prodi=null, terima= null where no_tagihan = "+
            //                                                "( "+
            //                                                    "SELECT no_tagihan FROM dbo.smmuntidar_tagihan WHERE no_pendaftar=@No_daftar"+
            //                                                ")", con);
            //    CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

            //    CmdTerimaPertama.Parameters.AddWithValue("@IdProdi", this.GVHasilDiterima1.Rows[index].Cells[5].Text.Trim());
            //    CmdTerimaPertama.Parameters.AddWithValue("@Diterima", this.GVHasilDiterima1.Rows[index].Cells[6].Text.Trim());
            //    CmdTerimaPertama.Parameters.AddWithValue("@NoTagihan", this.GVHasilDiterima1.Rows[index].Cells[2].Text.Trim());

            //    CmdTerimaPertama.ExecuteNonQuery();

            //    CmdTerimaPertama.Dispose();
            //    con.Close();

            //   // LoadData();
            //}

        }
    }
}