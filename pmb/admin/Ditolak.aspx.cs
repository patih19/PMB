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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand CmdTerimaPertama = new SqlCommand("SELECT smmuntidar_tagihan.no_pendaftar, UPPER(smmuntidar_identitas.nama) AS nama, smmuntidar_pilihan.pilihan_1, smmuntidar_pilihan.pilihan_2, smmuntidar_nilai.nilai, smmuntidar_tagihan.tahun "+
                            "FROM            smmuntidar_nilai INNER JOIN "+
                                                     "smmuntidar_tagihan ON smmuntidar_nilai.no_tagihan = smmuntidar_tagihan.no_tagihan INNER JOIN "+
                                                     "smmuntidar_identitas ON smmuntidar_tagihan.no_tagihan = smmuntidar_identitas.no_tagihan INNER JOIN "+
                                                     "smmuntidar_pilihan ON smmuntidar_tagihan.no_tagihan = smmuntidar_pilihan.no_tagihan "+
                            "WHERE        (smmuntidar_nilai.terima IS NULL) AND (smmuntidar_nilai.id_prodi IS NULL) AND (smmuntidar_nilai.chk_terima IS NULL) AND (smmuntidar_nilai.prodi_ke IS NULL) AND "+
                                                     "(smmuntidar_nilai.diterima_putaran IS NULL) AND (smmuntidar_tagihan.tahun = "+
                                                         "(SELECT        TOP (1) tahun "+
                                                           "FROM            smmuntidar_tagihan AS smmuntidar_tagihan_1 "+
                                                           "GROUP BY tahun ORDER BY tahun DESC))" +
                                    "order by terima, nilai desc", con);
                    CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

                    DataTable Table = new DataTable();
                    Table.Columns.Add("No Pendaftaran");
                    Table.Columns.Add("Nama");
                    Table.Columns.Add("Pilihan I");
                    Table.Columns.Add("Pilihan II");
                    Table.Columns.Add("Nilai");
                    //Table.Columns.Add("Tahun");

                    con.Open();
                    using (SqlDataReader rdr = CmdTerimaPertama.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = Table.NewRow();
                                datarow["No Pendaftaran"] = rdr["no_pendaftar"];
                                datarow["Nama"] = rdr["nama"].ToString().ToUpper(); ;
                                datarow["Pilihan I"] = rdr["pilihan_1"];
                                datarow["Pilihan II"] = rdr["pilihan_2"];
                                datarow["Nilai"] = rdr["nilai"];
                                //datarow["Tahun"] = rdr["tahun"];

                                Table.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVHasilDitolak.DataSource = Table;
                            this.GVHasilDitolak.DataBind();

                            Table.Dispose();
                        }
                        else
                        {
                            //clear Gridview
                            Table.Rows.Clear();
                            Table.Clear();
                            GVHasilDitolak.DataSource = Table;
                            GVHasilDitolak.DataBind();
                        }
                    }
                }
            }
        }

        protected void GVHasilDitolak_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GVHasilDitolak_PreRender(object sender, EventArgs e)
        {
            if (this.GVHasilDitolak.Rows.Count > 0)
            {
                // this replace <td> with <th> and add the scope attribute
                GVHasilDitolak.UseAccessibleHeader = true;

                //this will add the <thead> and <tbody> elements
                GVHasilDitolak.HeaderRow.TableSection = TableRowSection.TableHeader;

                //this adds the <tfoot> element
                //remove if you don't have a footer row
                //GVJadwal.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }
    }
}