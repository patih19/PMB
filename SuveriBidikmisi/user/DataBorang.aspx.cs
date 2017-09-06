using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace SuveriBidikmisi.user
{
    public partial class DataBorang : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string NoDaftar;

            if (!Page.IsPostBack)
            {
                Page LastPage = (Page)Context.Handler;
                if (LastPage is Sort)
                {
                    //Response.Write(((Sort)LastPage).NPM.ToString().Trim());
                    //string CS1 = ConfigurationManager.ConnectionStrings["Tidar"].ConnectionString;
                    //using (SqlConnection con = new SqlConnection(CS1))
                    //{
                    //    try
                    //    {
                    //        con.Open();
                    //        SqlCommand CmdNoDaftar = new SqlCommand("SELECT no_daftar FROM bak_mahasiswa WHERE npm=@npm", con);
                    //        CmdNoDaftar.CommandType = System.Data.CommandType.Text;

                    //        CmdNoDaftar.Parameters.AddWithValue("@npm", ((Sort)LastPage).NPM.ToString().Trim());

                    //        using (SqlDataReader rdr = CmdNoDaftar.ExecuteReader())
                    //        {
                    //            if (rdr.HasRows)
                    //            {
                    //                while (rdr.Read())
                    //                {
                    //                    NoDaftar = rdr["no_daftar"].ToString().Trim();
                    //                }
                    //            }
                    //        }

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Response.Write(ex.Message.ToString());
                    //    }
                    //}

                    string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        try
                        {
                            con.Open();

                            SqlCommand Pribadi = new SqlCommand("SELECT * FROM ukt_pribadi_bm WHERE no_daftar=@no_daftar", con);
                            Pribadi.CommandType = System.Data.CommandType.Text;
                            Pribadi.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Pribadi.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbNama.Text = rdr["nama"].ToString().Trim();
                                        this.LbGender.Text = rdr["gender"].ToString().Trim();
                                        this.LbTempatLahir.Text = rdr["tmplahir"].ToString().Trim();

                                        DateTime dt = DateTime.Parse(rdr["tglahir"].ToString());
                                        this.LbTanggalLahir.Text = dt.ToString("dd-MMMM-yyyy");

                                        this.LbAlamat.Text = rdr["alamat"].ToString().Trim();
                                        this.LbHp.Text = rdr["hp"].ToString().Trim();
                                        this.LbTelpRumah.Text = rdr["telp"].ToString().Trim();

                                        this.LbNamaAyah.Text = rdr["ayah"].ToString().Trim();
                                        this.LbStatusAyah.Text = rdr["stayah"].ToString().Trim();
                                        this.LbPendidikanAyah.Text = rdr["pdayah"].ToString().Trim();
                                        this.LbPekerjaanAyah.Text = rdr["kerjaayah"].ToString().Trim();
                                        this.LbModalUsahaAyah.Text = rdr["modalayah"].ToString().Trim();
                                        this.LbLabaAyah.Text = rdr["labaayah"].ToString().Trim();

                                        this.LbNamaIbu.Text = rdr["ibu"].ToString().Trim();
                                        this.LbStatusIbu.Text = rdr["stibu"].ToString().Trim();
                                        this.LbPendidikanIbu.Text = rdr["pdibu"].ToString().Trim();
                                        this.LbPekerjaanIbu.Text = rdr["kerjaibu"].ToString().Trim();
                                        this.LbModalUsahaIbu.Text = rdr["modalibu"].ToString().Trim();
                                        this.LbLabaIbu.Text = rdr["labaibu"].ToString().Trim();
                                    }
                                }
                            }

                            SqlCommand Keluarga = new SqlCommand("SELECT * FROM ukt_keluarga_bm WHERE no_daftar=@no_daftar", con);
                            Keluarga.CommandType = System.Data.CommandType.Text;
                            Keluarga.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Keluarga.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbJumlahOrangSerumah.Text = rdr["orgrumah"].ToString().Trim();
                                        this.LbJumlahSaudara.Text = rdr["sdr"].ToString().Trim();
                                        this.LbJumlahSdrKuliah.Text = rdr["sdrkuliah"].ToString().Trim();
                                        this.LbJumSdrSekolah.Text = rdr["sdrsekolah"].ToString().Trim();
                                    }
                                }
                            }


                            SqlCommand Rumah = new SqlCommand("SELECT * FROM ukt_rumah_bm WHERE no_daftar=@no_daftar", con);
                            Rumah.CommandType = System.Data.CommandType.Text;
                            Rumah.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Rumah.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbStatusMilikRumah.Text = rdr["stsrumah"].ToString().Trim();
                                        this.LbSumberListrik.Text = rdr["smbrlistrik"].ToString().Trim();
                                        this.LbDayaListrik.Text = rdr["dylistrik"].ToString().Trim();
                                        this.LbBiayaListrikBulanan.Text = rdr["bylistrik"].ToString().Trim();
                                        this.LbSumberAir.Text = rdr["sbair"].ToString().Trim();
                                        this.LbBiayaAirBulanan.Text = rdr["byair"].ToString().Trim();
                                        this.LbLuasTanah.Text = rdr["lstanah"].ToString().Trim();
                                        this.LbLuasBangunan.Text = rdr["lsbangunan"].ToString().Trim();
                                        this.LbNJOP.Text = rdr["njop"].ToString().Trim();
                                        this.LbAtap.Text = rdr["atap"].ToString().Trim();
                                        this.LbLantaiRumah.Text = rdr["lantai"].ToString().Trim();
                                        this.LbRuangTengah.Text = rdr["rgtenngah"].ToString().Trim();
                                        this.LbDapur.Text = rdr["dpr"].ToString().Trim();
                                        this.LbCuciPiringGelas.Text = rdr["cuci"].ToString().Trim();
                                        this.LbKeperluanMandi.Text = rdr["mandi"].ToString().Trim();
                                        this.LbTeras.Text = rdr["teras"].ToString().Trim();
                                        this.LbGarasi.Text = rdr["garasi"].ToString().Trim();
                                    }
                                }
                            }


                            SqlCommand Lingkungan = new SqlCommand("SELECT * FROM ukt_lingkungan_bm WHERE no_daftar=@no_daftar", con);
                            Lingkungan.CommandType = System.Data.CommandType.Text;
                            Lingkungan.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Lingkungan.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbLuasTaman.Text = rdr["lstaman"].ToString().Trim();
                                        this.LbPagar.Text = rdr["pagar"].ToString().Trim();
                                        this.LbJalanMasuk.Text = rdr["jlnmasuk"].ToString().Trim();
                                        this.LbSelokan.Text = rdr["selokan"].ToString().Trim();

                                    }
                                }
                            }


                            SqlCommand Perabot = new SqlCommand("SELECT * FROM ukt_perabot_bm WHERE no_daftar=@no_daftar", con);
                            Perabot.CommandType = System.Data.CommandType.Text;
                            Perabot.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Perabot.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbHargaMejaKursiRuangTamu.Text = rdr["hrmjtamu"].ToString().Trim();
                                        this.LbHargaAlmarBifet.Text = rdr["hralmari"].ToString().Trim();
                                        this.LbHargaMejaKursiRuangTengah.Text = rdr["hrmjtengah"].ToString().Trim();
                                        this.LbHargaMejaKursiRuangMakan.Text = rdr["hrmjmakan"].ToString().Trim();
                                        this.LbHargaMejaKursiTeras.Text = rdr["hrnjteras"].ToString().Trim();
                                        this.LbHargaTempatTidur.Text = rdr["hrtmtidur"].ToString().Trim();
                                        this.LbHargaTV.Text = rdr["hrtv"].ToString().Trim();
                                        this.LbHargaKomputerLaptop.Text = rdr["hrkomp"].ToString().Trim();
                                        this.LbHargaPeralatanDapur.Text = rdr["hrdapur"].ToString().Trim();
                                        this.LbHargaMejaRias.Text = rdr["hrmjrias"].ToString().Trim();
                                    }
                                }
                            }

                            SqlCommand Fasilitas = new SqlCommand("SELECT * FROM ukt_falilitas_bm WHERE no_daftar=@no_daftar", con);
                            Fasilitas.CommandType = System.Data.CommandType.Text;
                            Fasilitas.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Fasilitas.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbBiayaTelpDanHp.Text = rdr["bytelphp"].ToString().Trim();
                                        this.LbBiayaInternet.Text = rdr["byint"].ToString().Trim();

                                    }
                                }
                            }


                            SqlCommand Ekonomi = new SqlCommand("SELECT * FROM ukt_ekonomi_bm WHERE no_daftar=@no_daftar", con);
                            Ekonomi.CommandType = System.Data.CommandType.Text;
                            Ekonomi.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());

                            using (SqlDataReader rdr = Ekonomi.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbPendapatanAyah.Text = rdr["pdptayah"].ToString().Trim();
                                        this.LbPendapatanIbu.Text = rdr["pdptibu"].ToString().Trim();
                                        this.LbHutangKeluarga.Text = rdr["htng"].ToString().Trim();
                                        this.LbCicilanHutang.Text = rdr["cicilan"].ToString().Trim();
                                    }
                                }
                            }

                            SqlCommand Aset = new SqlCommand("SELECT * FROM ukt_harta_bm WHERE no_daftar=@no_daftar", con);
                            Aset.CommandType = System.Data.CommandType.Text;
                            Aset.Parameters.AddWithValue("@no_daftar", ((Sort)LastPage).NPM.ToString().Trim());
                            using (SqlDataReader rdr = Aset.ExecuteReader())
                            {
                                if (rdr.HasRows)
                                {
                                    while (rdr.Read())
                                    {
                                        this.LbSawah.Text = rdr["sawah"].ToString().Trim();
                                        this.LbLadangKebun.Text = rdr["tanah"].ToString().Trim();
                                        this.LbTernak.Text = rdr["ternak"].ToString().Trim();
                                        this.LbMobil.Text = rdr["mobil"].ToString().Trim();
                                        this.LbTabungan.Text = rdr["tabungan"].ToString().Trim();
                                        this.LbPerhiasan.Text = rdr["hiasan"].ToString().Trim();
                                        this.LbSepedaMotor.Text = rdr["sepeda"].ToString().Trim();
                                    }
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                            return;
                        }
                    }


                    FotoRumahDepan(((Sort)LastPage).NPM.ToString().Trim());
                    FotoRuangTamu(((Sort)LastPage).NPM.ToString().Trim());
                    FotoRuangTengah(((Sort)LastPage).NPM.ToString().Trim());
                    FotoKamarTidur(((Sort)LastPage).NPM.ToString().Trim());
                    FotoDapur(((Sort)LastPage).NPM.ToString().Trim());
                    FotoKamarMandi(((Sort)LastPage).NPM.ToString().Trim());


                }
            }
        }

        protected void FotoRumahDepan(string no_daftar)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dpn_rumah from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", no_daftar); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_dpn_rumah"] == DBNull.Value)
                            {
                            }
                            else
                            {
                                this.ImgRumah.ImageUrl = "~/foto/" + reader["ft_dpn_rumah"].ToString();
                            }
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgRumah.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoRuangTamu(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar,ft_ruang_tamu from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", no_akun); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_ruang_tamu"] == DBNull.Value)
                            {

                            }
                            else
                            {
                                this.ImgRuangTamu.ImageUrl = "~/foto/" + reader["ft_ruang_tamu"].ToString();
                            }
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgRuangTamu.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoRuangTengah(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_ruang_tengah from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", no_akun); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_ruang_tengah"] == DBNull.Value)
                            {
                            }
                            else
                            {

                                this.ImgRuangTengah.ImageUrl = "~/foto/" + reader["ft_ruang_tengah"].ToString();
                            }
                        }
                    }
                    else
                    {

                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgRuangTengah.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoKamarTidur(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_kamar_tidur from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", no_akun); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_kamar_tidur"] == DBNull.Value)
                            {
                            }
                            else
                            {
                                this.ImgKamarTidur.ImageUrl = "~/foto/" + reader["ft_kamar_tidur"].ToString();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImgKamarTidur.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoDapur(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_dapur from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", no_akun); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_dapur"] == DBNull.Value)
                            {
                            }
                            else
                            {

                                this.ImageDapur.ImageUrl = "~/foto/" + reader["ft_dapur"].ToString();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImageDapur.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void FotoKamarMandi(string no_akun)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_daftar, ft_kamar_mandi from ukt_document_bm where no_daftar=@no_daftar", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_daftar", no_akun); // this.Session["NoDaftar"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader["ft_kamar_mandi"] == DBNull.Value)
                            {
                            }
                            else
                            {
                                this.ImageKamarMandi.ImageUrl = "~/foto/" + reader["ft_kamar_mandi"].ToString();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    ImageKamarMandi.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}