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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //this.PanelAddPeserta.Visible = false;
                //this.PanelAddPeserta.Enabled = false;
                LoadData();
            }
        }

        protected void LoadData()
        {
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand CmdTerimaPertama = new SqlCommand("SELECT smmuntidar_nilai.no_tagihan,smmuntidar_tagihan.no_pendaftar, UPPER(smmuntidar_identitas.nama) AS nama, smmuntidar_pilihan.id_prodi_satu, smmuntidar_pilihan.pilihan_1, smmuntidar_pilihan.id_prodi_dua," +
                                             "smmuntidar_pilihan.pilihan_2, smmuntidar_nilai.nilai, smmuntidar_tagihan.tahun " +
                    "FROM            smmuntidar_nilai INNER JOIN " +
                                             "smmuntidar_tagihan ON smmuntidar_nilai.no_tagihan = smmuntidar_tagihan.no_tagihan INNER JOIN " +
                                             "smmuntidar_identitas ON smmuntidar_tagihan.no_tagihan = smmuntidar_identitas.no_tagihan INNER JOIN " +
                                             "smmuntidar_pilihan ON smmuntidar_tagihan.no_tagihan = smmuntidar_pilihan.no_tagihan " +
                    "WHERE        (smmuntidar_nilai.terima IS NULL) AND (smmuntidar_nilai.id_prodi IS NULL) AND (smmuntidar_nilai.chk_terima IS NULL) AND (smmuntidar_nilai.prodi_ke IS NULL) AND " +
                                             "(smmuntidar_nilai.diterima_putaran IS NULL) AND (smmuntidar_tagihan.tahun = " +
                                                 "(SELECT        TOP (1) tahun " +
                                                   "FROM            smmuntidar_tagihan AS smmuntidar_tagihan_1 " +
                                                   "GROUP BY tahun ORDER BY tahun DESC))", con);
                CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

                DataTable Table = new DataTable();
                Table.Columns.Add("No Tagihan");
                Table.Columns.Add("No Daftar");
                Table.Columns.Add("Nama");
                Table.Columns.Add("Id Prodi Satu");
                Table.Columns.Add("Program Studi I");
                Table.Columns.Add("Id Prodi Dua");
                Table.Columns.Add("Program Studi II");
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
                            datarow["No Tagihan"] = rdr["no_tagihan"];
                            datarow["No Daftar"] = rdr["no_pendaftar"];
                            datarow["Nama"] = rdr["nama"].ToString().ToUpper(); ;
                            datarow["Id Prodi Satu"] = rdr["id_prodi_satu"];
                            datarow["Program Studi I"] = rdr["pilihan_1"];
                            datarow["Id Prodi Dua"] = rdr["id_prodi_dua"];
                            datarow["Program Studi II"] = rdr["pilihan_2"];
                            datarow["Nilai"] = rdr["nilai"];
                            datarow["Tahun"] = rdr["tahun"];

                            Table.Rows.Add(datarow);
                        }

                        //Fill Gridview
                        this.GVHasilDua.DataSource = Table;
                        this.GVHasilDua.DataBind();

                        Table.Dispose();
                    }
                    else
                    {
                        //clear Gridview
                        Table.Rows.Clear();
                        Table.Clear();
                        GVHasilDua.DataSource = Table;
                        GVHasilDua.DataBind();
                    }
                }
            }
        }

        protected void GVHasilDua_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false; // no tagihan
            e.Row.Cells[5].Visible = false; // id prodi satu
            e.Row.Cells[7].Visible = false; // id prodi 2
            e.Row.Cells[10].Visible = false; // tahun

        }

        protected void GVHasilDua_PreRender(object sender, EventArgs e)
        {
            if (this.GVHasilDua.Rows.Count > 0)
            {
                // this replace <td> with <th> and add the scope attribute
                GVHasilDua.UseAccessibleHeader = true;

                //this will add the <thead> and <tbody> elements
                GVHasilDua.HeaderRow.TableSection = TableRowSection.TableHeader;

                //this adds the <tfoot> element
                //remove if you don't have a footer row
                //GVJadwal.FooterRow.TableSection = TableRowSection.TableFooter;

            }
        }

        //protected void BtnAddPeserta_Click(object sender, EventArgs e)
        //{
        //    // hitung checkbox selected
        //    int cnt = 0;
        //    int rowchecked = 0;
        //    for (int i = 0; i < this.GVHasilDua.Rows.Count; i++)
        //    {
        //        CheckBox CB = (CheckBox)this.GVHasilDua.Rows[i].FindControl("CbTambahan");
        //        if (CB.Checked == true)
        //        {
        //            cnt += 1;
        //            rowchecked = i;
        //        }
        //    }
        //    // checkbox selected
        //    if (cnt < 1)
        //    {
        //        //client message belum pilih check list.....
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Peserta Belum Dipilih');", true);
        //        //ScriptManager.RegisterStartupScript((Control)this.BtnEditSKS, this.GetType(), "redirectMe", "alert('Piliah Salah Satu Biaya Angsuran');", true);
        //        return;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < this.GVHasilDua.Rows.Count; i++)
        //        {
        //            CheckBox CB = (CheckBox)this.GVHasilDua.Rows[i].FindControl("CbTambahan");
        //            if (CB.Checked == true)
        //            {
        //                //Response.Write(this.GVHasilDua.Rows[i].Cells[1].Text);

        //                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
        //                using (SqlConnection con = new SqlConnection(CS))
        //                {
        //                    con.Open();

        //                    SqlCommand CmdTerimaPertama = new SqlCommand("SpAddPesertaDiterima", con);
        //                    CmdTerimaPertama.CommandType = System.Data.CommandType.StoredProcedure;

        //                    CmdTerimaPertama.Parameters.AddWithValue("@no_daftar", this.GVHasilDua.Rows[i].Cells[1].Text.Trim());
        //                    CmdTerimaPertama.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text.Trim());

        //                    CmdTerimaPertama.ExecuteNonQuery();
        //                }

        //            }
        //        }

        //        DLProdi_SelectedIndexChanged(DLProdi, EventArgs.Empty);
        //    }
        //}

        //protected void DLProdi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        SqlCommand CmdDitolakPerProdi = new SqlCommand("SpListTidakDiterimaSmProdi", con);
        //        CmdDitolakPerProdi.CommandType = System.Data.CommandType.StoredProcedure;

        //        CmdDitolakPerProdi.Parameters.AddWithValue("@prodi",this.DLProdi.SelectedItem.Text);

        //        DataTable Table = new DataTable();
        //        Table.Columns.Add("No Daftar");
        //        Table.Columns.Add("Nama");
        //        Table.Columns.Add("Nilai");
        //        Table.Columns.Add("SPI");
        //        Table.Columns.Add("Skor");
        //        Table.Columns.Add("Provinsi");
        //        Table.Columns.Add("Pilihan I");
        //        Table.Columns.Add("Pilihan II");

        //        con.Open();
        //        using (SqlDataReader rdr = CmdDitolakPerProdi.ExecuteReader())
        //        {
        //            if (rdr.HasRows)
        //            {
        //                this.PanelAddPeserta.Visible = true;
        //                this.PanelAddPeserta.Enabled = true;

        //                this.BtnAddPeserta.Text = "Tambahkan Ke " + this.DLProdi.SelectedItem.Text;

        //                while (rdr.Read())
        //                {
        //                    DataRow datarow = Table.NewRow();
        //                    datarow["No Daftar"] = rdr["no_pendaftar"];
        //                    datarow["Nama"] = rdr["nama"].ToString().ToUpper(); ;
        //                    datarow["Nilai"] = rdr["nilai"];
        //                    datarow["SPI"] = rdr["sumbangan"];
        //                    datarow["Skor"] = String.Format("{0:0.##}", rdr["sekor"]);
        //                    datarow["Provinsi"] = rdr["prov"];
        //                    datarow["Pilihan I"] = rdr["pilihan_1"];
        //                    datarow["Pilihan II"] = rdr["pilihan_2"];

        //                    Table.Rows.Add(datarow);
        //                }

        //                //Fill Gridview
        //                this.GVHasilDua.DataSource = Table;
        //                this.GVHasilDua.DataBind();

        //                Table.Dispose();
        //            }
        //            else
        //            {
        //                //clear Gridview
        //                Table.Rows.Clear();
        //                Table.Clear();
        //                GVHasilDua.DataSource = Table;
        //                GVHasilDua.DataBind();
        //            }
        //        }
        //    }
        //}

        protected void BtnProdi1_Click(object sender, EventArgs e)
        {
            // get index row 
            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            // get id prodi 1
            // this.GVHasilDua.Rows[index].Cells[5].Text.Trim();

            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                SqlCommand CmdTerimaPertama = new SqlCommand("update smmuntidar_nilai set chk_terima='yes', diterima_putaran=2, prodi_ke=1, id_prodi=@IdProdi, terima=@Diterima where no_tagihan=@NoTagihan", con);
                CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

                CmdTerimaPertama.Parameters.AddWithValue("@IdProdi",this.GVHasilDua.Rows[index].Cells[5].Text.Trim());
                CmdTerimaPertama.Parameters.AddWithValue("@Diterima",this.GVHasilDua.Rows[index].Cells[6].Text.Trim());
                CmdTerimaPertama.Parameters.AddWithValue("@NoTagihan", this.GVHasilDua.Rows[index].Cells[2].Text.Trim());

                CmdTerimaPertama.ExecuteNonQuery();

                CmdTerimaPertama.Dispose();
                con.Close();

                LoadData();
            }


        }

        protected void BtnProdi2_Click(object sender, EventArgs e)
        {
            // get index row 
            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            // get id prodi 2
            //this.GVHasilDua.Rows[index].Cells[7].Text.Trim();

            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {

                con.Open();

                SqlCommand CmdTerimaPertama = new SqlCommand("update smmuntidar_nilai set chk_terima='yes', diterima_putaran=2, prodi_ke=2, id_prodi=@IdProdi, terima=@Diterima where no_tagihan=@NoTagihan", con);
                CmdTerimaPertama.CommandType = System.Data.CommandType.Text;

                CmdTerimaPertama.Parameters.AddWithValue("@IdProdi", this.GVHasilDua.Rows[index].Cells[7].Text.Trim());
                CmdTerimaPertama.Parameters.AddWithValue("@Diterima", this.GVHasilDua.Rows[index].Cells[8].Text.Trim());
                CmdTerimaPertama.Parameters.AddWithValue("@NoTagihan", this.GVHasilDua.Rows[index].Cells[2].Text.Trim());

                CmdTerimaPertama.ExecuteNonQuery();

                CmdTerimaPertama.Dispose();

                con.Close();
                LoadData();
            }
        }
    }
}