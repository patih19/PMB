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

namespace SuveriBidikmisi
{
    public partial class CekInput : SuveriBidikmisi.user.user
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                HtmlGenericControl control = (HtmlGenericControl)base.Master.FindControl("NavMonitor");
                control.Attributes.Add("class", "dropdown active opened");
                HtmlGenericControl control2 = (HtmlGenericControl)base.Master.FindControl("NavExample");
                control2.Attributes.Add("style", "display: none;");


                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand command = new SqlCommand("select * from " +
                                                        "( " +

                                                            "SELECT        UntidarDb.dbo.bak_mahasiswa.npm, UntidarDb.dbo.bak_mahasiswa.nama,UntidarDb.dbo.bak_mahasiswa.gelombang,bak_mahasiswa.bdk, SbTemp.reg AS reg_sbmptn, SnmptnTemp.reg AS reg_snmptn, PmdkDiplomaTemp.reg AS reg_pmdk, SMMTemp.reg as reg_smuntidar, bak_mahasiswa.thn_angkatan " +
                                                            "FROM            UntidarDb.dbo.bak_mahasiswa LEFT OUTER JOIN " +
                                                                                     "SbTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SbTemp.kd_peserta LEFT OUTER JOIN " +
                                                                                     "PmdkDiplomaTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = PmdkDiplomaTemp.no_pendaftar LEFT OUTER JOIN " +
                                                                                     "SnmptnTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SnmptnTemp.nomor_pendaftaran LEFT OUTER JOIN " +
                                                                                     "SMMTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SMMTemp.no_pendaftar " +
                                                            "WHERE bak_mahasiswa.thn_angkatan=(SELECT TOP 1 thn_angkatan FROM UntidarDb.dbo.bak_mahasiswa GROUP BY thn_angkatan ORDER BY thn_angkatan DESC ) and (bak_mahasiswa.bdk = 1) " +
                                                                 "and((SbTemp.reg = 'datang') or  (SnmptnTemp.reg ='datang') or  (PmdkDiplomaTemp.reg ='datang') or( SMMTemp.reg ='datang')) " +
                                                        ") as Mhs " +
                                                        "LEFT OUTER JOIN " +
                                                        "( " +
                                                                "SELECT        ukt_pribadi_bm.no_daftar AS pribadi, ukt_keluarga_bm.no_daftar AS keluarga, ukt_rumah_bm.no_daftar AS rumah, ukt_lingkungan_bm.no_daftar AS lingkungan, ukt_perabot_bm.no_daftar AS perabot, " +
                                                                                         "ukt_falilitas_bm.no_daftar AS fasilitas, ukt_ekonomi_bm.no_daftar AS ekonomi, ukt_harta_bm.no_daftar AS harta, ukt_document_bm.no_daftar AS dokumen " +
                                                                "FROM            ukt_pribadi_bm LEFT OUTER JOIN " +
                                                                                         "ukt_ekonomi_bm ON ukt_pribadi_bm.no_daftar = ukt_ekonomi_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_falilitas_bm ON ukt_pribadi_bm.no_daftar = ukt_falilitas_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_harta_bm ON ukt_pribadi_bm.no_daftar = ukt_harta_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_keluarga_bm ON ukt_pribadi_bm.no_daftar = ukt_keluarga_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_lingkungan_bm ON ukt_pribadi_bm.no_daftar = ukt_lingkungan_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_perabot_bm ON ukt_pribadi_bm.no_daftar = ukt_perabot_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_rumah_bm ON ukt_pribadi_bm.no_daftar = ukt_rumah_bm.no_daftar LEFT OUTER JOIN " +
                                                                                         "ukt_document_bm ON ukt_pribadi_bm.no_daftar = ukt_document_bm.no_daftar " +
                                                               " WHERE ukt_pribadi_bm.no_daftar is not null " +
                                                        ") as Survei " +
                                                        "ON	Survei.pribadi = Mhs.npm", con);
                    command.CommandType = System.Data.CommandType.Text;

                    DataTable Table = new DataTable();
                    Table.Columns.Add("NPM");
                    Table.Columns.Add("Nama");
                    //Table.Columns.Add("Jalur");
                    Table.Columns.Add("Pribadi");
                    Table.Columns.Add("Keluarga");
                    Table.Columns.Add("Rumah");
                    Table.Columns.Add("Lingkungan");
                    Table.Columns.Add("Perabot");
                    Table.Columns.Add("Fasilitas");
                    Table.Columns.Add("Ekonomi");
                    Table.Columns.Add("Harta");
                    Table.Columns.Add("Dokumen");


                    con.Open();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = Table.NewRow();
                                datarow["NPM"] = rdr["npm"];
                                datarow["Nama"] = rdr["nama"].ToString().ToUpper(); ;
                               // datarow["Jalur"] = rdr["gelombang"];

                                if (rdr["pribadi"] != DBNull.Value)
                                {
                                    datarow["Pribadi"] = "ok";
                                }
                                else
                                {
                                    datarow["Pribadi"] = "-";
                                }

                                if (rdr["keluarga"] != DBNull.Value)
                                {
                                    datarow["Keluarga"] = "ok";
                                }
                                else
                                {
                                    datarow["Keluarga"] = "-";
                                }

                                if (rdr["rumah"] != DBNull.Value)
                                {
                                    datarow["Rumah"] = "ok";
                                }
                                else
                                {
                                    datarow["Rumah"] = "-";
                                }

                                if (rdr["lingkungan"] != DBNull.Value)
                                {
                                    datarow["Lingkungan"] = "ok";
                                }
                                else
                                {
                                    datarow["Lingkungan"] = "-";
                                }

                                if (rdr["perabot"] != DBNull.Value)
                                {
                                    datarow["Perabot"] = "ok";
                                }
                                else
                                {
                                    datarow["Perabot"] = "-";
                                }

                                if (rdr["fasilitas"] != DBNull.Value)
                                {
                                    datarow["Fasilitas"] = "ok";
                                }
                                else
                                {
                                    datarow["Fasilitas"] = "-";
                                }

                                if (rdr["ekonomi"] != DBNull.Value)
                                {
                                    datarow["Ekonomi"] = "ok";
                                }
                                else
                                {
                                    datarow["Ekonomi"] = "-";
                                }

                                if (rdr["harta"] != DBNull.Value)
                                {
                                    datarow["Harta"] = "ok";
                                }
                                else
                                {
                                    datarow["Harta"] = "-";
                                }

                                if (rdr["dokumen"] != DBNull.Value)
                                {
                                    datarow["Dokumen"] = "ok";
                                }
                                else
                                {
                                    datarow["Dokumen"] = "-";
                                }

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            //this.GVCekInput.Rows[index].Cells[1].Text.Trim();
            Response.Redirect("~/user/pribadi.aspx?npm="+this.GVCekInput.Rows[index].Cells[1].Text.Trim()+"");
        }
    }
}