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
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // ----------------------------Lihat Hasil Pencarian------------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ---------------------- Lihat Pendaftar Diterima ---------------------------------
                    SqlCommand CmdHasil = new SqlCommand("SpLihatBerkasGagal", con);
                    CmdHasil.CommandType = System.Data.CommandType.StoredProcedure;

                    //CmdHasil.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text);

                    DataTable TblHasil = new DataTable();
                    TblHasil.Columns.Add("No.Tagihan");
                    TblHasil.Columns.Add("Nama");
                    TblHasil.Columns.Add("Pilihan I");
                    TblHasil.Columns.Add("Pilihan II");
                    TblHasil.Columns.Add("Nilai");


                    using (SqlDataReader rdr = CmdHasil.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TblHasil.NewRow();
                                datarow["No.Tagihan"] = rdr["no_tagihan"];
                                datarow["Nama"] = rdr["nama"];
                                datarow["Pilihan I"] = rdr["pilihan_1"];
                                datarow["Pilihan II"] = rdr["pilihan_2"];
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
}