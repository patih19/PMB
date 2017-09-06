using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;
using SuveriBidikmisi.model;
using System.Data;
using System.Web.Script.Serialization;

namespace SuveriBidikmisi.services
{
    /// <summary>
    /// Summary description for beasiswa
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class beasiswa : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true), ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void GetBorang(string npm)
        {
            List<MhsBdkClass> list = new List<MhsBdkClass>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT ukt_pribadi.no_daftar, UntidarDb.dbo.bak_mahasiswa.nama FROM ukt_pribadi INNER JOIN UntidarDb.dbo.bak_mahasiswa ON\tUntidarDb.dbo.bak_mahasiswa.no_daftar = dbo.ukt_pribadi.no_daftar WHERE npm=@npm", connection)
                {
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@npm", npm);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MhsBdkClass item = new MhsBdkClass
                            {
                                no_pendaftaran = reader["no_daftar"].ToString()
                            };
                            list.Add(item);
                        }
                    }
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            base.Context.Response.Write(serializer.Serialize(list));
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true), WebMethod(EnableSession = true)]
        public void GetEmployees(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int num = iDisplayLength;
            int num2 = iDisplayStart;
            int num3 = iSortCol_0;
            string str = sSortDir_0;
            string str2 = sSearch;
            string connectionString = ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString;
            List<MhsBdkClass> list = new List<MhsBdkClass>();
            int num4 = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("spGetEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@DisplayLength",
                    Value = num
                };
                command.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter
                {
                    ParameterName = "@DisplayStart",
                    Value = num2
                };
                command.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter
                {
                    ParameterName = "@SortCol",
                    Value = num3
                };
                command.Parameters.Add(parameter3);
                SqlParameter parameter4 = new SqlParameter
                {
                    ParameterName = "@SortDir",
                    Value = str
                };
                command.Parameters.Add(parameter4);
                SqlParameter parameter5 = new SqlParameter
                {
                    ParameterName = "@Search",
                    Value = string.IsNullOrEmpty(str2) ? null : str2
                };
                command.Parameters.Add(parameter5);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MhsBdkClass item = new MhsBdkClass
                    {
                        npm = reader["npm"].ToString()
                    };
                    num4 = Convert.ToInt32(reader["TotalCount"]);
                    item.nama = reader["nama"].ToString();
                    item.gender = reader["gender"].ToString();
                    item.prog_study = reader["prog_study"].ToString();
                    item.gelombang = reader["gelombang"].ToString();
                    item.poto = reader["poto"].ToString();
                    item.thn_angkatan = reader["thn_angkatan"].ToString();
                    list.Add(item);
                }
            }
            var type = new
            {
                iTotalRecords = this.GetEmployeeTotalCount(),
                iTotalDisplayRecords = num4,
                aaData = list
            };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            base.Context.Response.Write(serializer.Serialize(type));
        }

        private int GetEmployeeTotalCount()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT     COUNT(bak_mahasiswa.npm) FROM         bak_mahasiswa INNER JOIN bak_prog_study ON bak_mahasiswa.id_prog_study = bak_prog_study.id_prog_study WHERE     (bak_mahasiswa.bdk = 1) AND (bak_mahasiswa.thn_angkatan = (SELECT TOP (1) thn_angkatan FROM bak_mahasiswa AS bak_mahasiswa_1 GROUP BY thn_angkatan ORDER BY thn_angkatan DESC))  ", connection);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true), WebMethod(EnableSession = true)]
        public void CekInput()
        {
            List<CekInputClass> list = new List<CekInputClass>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                connection.Open();
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
                                                    "ON	Survei.pribadi = Mhs.npm", connection)
                                                    {
                                                        CommandType = CommandType.Text
                                                    };


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CekInputClass Data = new CekInputClass
                            {
                                npm = reader["npm"].ToString(),
                                nama = reader["nama"].ToString(),
                                gelombang = reader["gelombang"].ToString(),
                                bdk = reader["bdk"].ToString(),
                                thn_angkatan = reader["thn_angkatan"].ToString(),
                                pribadi = reader["pribadi"].ToString(),
                                keluarga = reader["keluarga"].ToString(),
                                rumah = reader["rumah"].ToString(),
                                lingkungan = reader["lingkungan"].ToString(),
                                perabot = reader["perabot"].ToString(),
                                fasilitas = reader["fasilitas"].ToString(),
                                ekonomi = reader["ekonomi"].ToString(),
                                harta = reader["harta"].ToString(),
                                dokumen = reader["dokumen"].ToString(),
                            };

                            list.Add(Data);
                        }
                    }
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            base.Context.Response.Write(serializer.Serialize(list));
        }

    }
}
