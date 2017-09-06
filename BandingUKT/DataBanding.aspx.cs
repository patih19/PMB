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
    public partial class DataBanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataBanding()
        {
            string CS = ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand command = new SqlCommand(""+
                "SELECT        UntidarDb.dbo.bak_mahasiswa.npm, UntidarDb.dbo.bak_mahasiswa.nama, ukt_pribadi_banding.pdayah,ukt_pribadi_banding.kerjaayah,ukt_pribadi_banding.modalayah,ukt_pribadi_banding.labaayah, ukt_pribadi_banding.pdibu, ukt_pribadi_banding.kerjaibu,ukt_pribadi_banding.modalibu,ukt_pribadi_banding.labaibu, ukt_pribadi_banding.data_banding, ukt_keluarga_banding.orgrumah, " +
                                         "ukt_keluarga_banding.sdr, ukt_keluarga_banding.sdrkuliah, ukt_keluarga_banding.sdrsekolah, ukt_rumah_banding.stsrumah, ukt_rumah_banding.smbrlistrik, ukt_rumah_banding.dylistrik, "+
                                         "ukt_rumah_banding.bylistrik, ukt_rumah_banding.sbair, ukt_rumah_banding.byair, ukt_rumah_banding.lstanah, ukt_rumah_banding.lsbangunan, ukt_rumah_banding.njop, ukt_rumah_banding.atap, "+
                                         "ukt_rumah_banding.lantai, ukt_rumah_banding.rgtenngah, ukt_rumah_banding.dpr, ukt_rumah_banding.cuci, ukt_rumah_banding.mandi, ukt_rumah_banding.teras, ukt_rumah_banding.garasi, "+
                                         "ukt_lingkungan_banding.lstaman, ukt_lingkungan_banding.pagar, ukt_perabot_banding.hrmjtamu, ukt_perabot_banding.hralmari, ukt_perabot_banding.hrmjtengah, ukt_perabot_banding.hrmjmakan, "+
                                         "ukt_perabot_banding.hrnjteras, ukt_perabot_banding.hrtmtidur, ukt_perabot_banding.hrtv, ukt_perabot_banding.hrkomp, ukt_perabot_banding.hrdapur, ukt_falilitas_banding.bytelphp, ukt_falilitas_banding.byint, "+
                                         "ukt_ekonomi_banding.pdptayah, ukt_ekonomi_banding.pdptibu, ukt_ekonomi_banding.htng, ukt_ekonomi_banding.cicilan, ukt_harta_banding.sawah, ukt_harta_banding.tanah, ukt_harta_banding.ternak, "+
                                         "ukt_harta_banding.mobil, ukt_harta_banding.tabungan, ukt_harta_banding.hiasan, ukt_harta_banding.sepeda, "+
                                         "ukt_ekonomi_banding.nilai + ukt_falilitas_banding.nilai + ukt_harta_banding.nilai + ukt_keluarga_banding.nilai + ukt_lingkungan_banding.nilai + ukt_perabot_banding.nilai + ukt_pribadi_banding.nilai + ukt_rumah_banding.nilai "+
                                        " AS nilai_total "+
                "FROM            UntidarDb.dbo.bak_mahasiswa INNER JOIN "+
                                         "ukt_ekonomi_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_ekonomi_banding.no_daftar INNER JOIN "+
                                         "ukt_falilitas_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_falilitas_banding.no_daftar INNER JOIN "+
                                         "ukt_harta_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_harta_banding.no_daftar INNER JOIN "+
                                         "ukt_lingkungan_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_lingkungan_banding.no_daftar INNER JOIN "+
                                         "ukt_keluarga_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_keluarga_banding.no_daftar INNER JOIN "+
                                         "ukt_perabot_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_perabot_banding.no_daftar INNER JOIN "+
                                         "ukt_pribadi_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_pribadi_banding.no_daftar INNER JOIN "+
                                         "ukt_rumah_banding ON UntidarDb.dbo.bak_mahasiswa.npm = ukt_rumah_banding.no_daftar "+
               " WHERE        (ukt_ekonomi_banding.data_banding = 'lama') AND (ukt_falilitas_banding.data_banding = 'lama') AND (ukt_harta_banding.data_banding = 'lama') AND (ukt_lingkungan_banding.data_banding = 'lama') AND  "+
                                         "(ukt_keluarga_banding.data_banding = 'lama') AND (ukt_perabot_banding.data_banding = 'lama') AND (ukt_pribadi_banding.data_banding = 'lama') AND (ukt_rumah_banding.data_banding = 'lama') "+
               "ORDER BY nilai_total DESC "+
                "", con);
                command.CommandType = System.Data.CommandType.Text;

                DataTable Table = new DataTable();
                Table.Columns.Add("NPM");
                Table.Columns.Add("Nama");
                Table.Columns.Add("Pendidikan Ayah");
                Table.Columns.Add("Pekerjaan Ayah");
                Table.Columns.Add("Modal Ayah");
                Table.Columns.Add("Laba Ayah");
                Table.Columns.Add("Pendidikan Ibu");
                Table.Columns.Add("Pekerjaan Ibu");
                Table.Columns.Add("Modal Ibu");
                Table.Columns.Add("Laba Ibu");




                con.Open();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
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
                        this.GVDataBanding.DataSource = Table;
                        this.GVDataBanding.DataBind();

                        Table.Dispose();
                    }
                    else
                    {
                        //clear Gridview
                        Table.Rows.Clear();
                        Table.Clear();
                        GVDataBanding.DataSource = Table;
                        GVDataBanding.DataBind();
                    }
                }
            }
        }
    }
}