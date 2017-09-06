using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace smmuntidar.user
{
    public partial class Kartu : System.Web.UI.Page
    {
        string NoTagihan = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    //-----------------------------------Cek Kelenngkapan Berkas -----------------------------------------------
                    string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        //SqlTransaction trans = con.BeginTransaction();

                        SqlCommand Cmdstatistik = new SqlCommand("SpReadDataPendaftar", con);
                        //CmdPeriodik.Transaction = trans;
                        Cmdstatistik.CommandType = System.Data.CommandType.StoredProcedure;

                        //Cmdstatistik.Parameters.AddWithValue("@no_tagihan",this.Session["no_tagihan"].ToString());
                        Cmdstatistik.Parameters.AddWithValue("@no_tagihan", Request.QueryString["NoTagihan"].ToString());

                        this.NoTagihan = Request.QueryString["NoTagihan"].ToString();

                        SqlParameter NoDaftar = new SqlParameter();
                        NoDaftar.ParameterName = "@no_daftar";
                        NoDaftar.SqlDbType = System.Data.SqlDbType.VarChar;
                        NoDaftar.Direction = System.Data.ParameterDirection.Output;
                        NoDaftar.Size = 12;
                        Cmdstatistik.Parameters.Add(NoDaftar);

                        SqlParameter Ujian = new SqlParameter();
                        Ujian.ParameterName = "@no_ujian";
                        Ujian.SqlDbType = System.Data.SqlDbType.VarChar;
                        Ujian.Direction = System.Data.ParameterDirection.Output;
                        Ujian.Size = 10;
                        Cmdstatistik.Parameters.Add(Ujian);

                        SqlParameter Nama = new SqlParameter();
                        Nama.ParameterName = "@nama";
                        Nama.SqlDbType = System.Data.SqlDbType.VarChar;
                        Nama.Direction = System.Data.ParameterDirection.Output;
                        Nama.Size = 50;
                        Cmdstatistik.Parameters.Add(Nama);

                        SqlParameter Lls = new SqlParameter();
                        Lls.ParameterName = "@thnlls";
                        Lls.SqlDbType = System.Data.SqlDbType.VarChar;
                        Lls.Direction = System.Data.ParameterDirection.Output;
                        Lls.Size = 9;
                        Cmdstatistik.Parameters.Add(Lls);

                        SqlParameter Pilihan1 = new SqlParameter();
                        Pilihan1.ParameterName = "@pil1";
                        Pilihan1.SqlDbType = System.Data.SqlDbType.VarChar;
                        Pilihan1.Direction = System.Data.ParameterDirection.Output;
                        Pilihan1.Size = 50;
                        Cmdstatistik.Parameters.Add(Pilihan1);

                        SqlParameter Pilihan2 = new SqlParameter();
                        Pilihan2.ParameterName = "@pil2";
                        Pilihan2.SqlDbType = System.Data.SqlDbType.VarChar;
                        Pilihan2.Direction = System.Data.ParameterDirection.Output;
                        Pilihan2.Size = 50;
                        Cmdstatistik.Parameters.Add(Pilihan2);

                        SqlParameter Alamat = new SqlParameter();
                        Alamat.ParameterName = "@alamat";
                        Alamat.SqlDbType = System.Data.SqlDbType.VarChar;
                        Alamat.Direction = System.Data.ParameterDirection.Output;
                        Alamat.Size = 120;
                        Cmdstatistik.Parameters.Add(Alamat);

                        Cmdstatistik.ExecuteNonQuery();

                        this.LbNoDaftar.Text = NoDaftar.Value.ToString().ToUpper();
                        this.LbNama.Text = Nama.Value.ToString();
                        this.LbThnLls.Text = Lls.Value.ToString();
                        this.LbPilihan1.Text = Pilihan1.Value.ToString();
                        this.LbPilihan2.Text = Pilihan2.Value.ToString();
                        this.LbAlamat.Text = Alamat.Value.ToString();
                        this.LbNoUjian.Text = Ujian.Value.ToString();

                        // ----------- tentukan kelompok --------------------//
                        if (Pilihan1.Value.ToString().Trim() == "S1 TEKNIK ELEKTRO" || Pilihan1.Value.ToString().Trim() == "S1 TEKNIK MESIN" || Pilihan1.Value.ToString().Trim() == "D3 TEKNIK MESIN" || Pilihan1.Value.ToString().Trim() == "S1 TEKNIK SIPIL" || Pilihan1.Value.ToString().Trim() == "S1 AGROTEKNOLOGI" || Pilihan1.Value.ToString().Trim() == "S1 PETERNAKAN" || Pilihan1.Value.ToString().Trim() == "S1 PENDIDIKAN ILMU PENGETAHUAN ALAM")
                        {
                            this.LbKelompok.Text = "SAINTEK";
                        }
                        else
                        {
                            this.LbKelompok.Text = "SOSHUM";
                        }
                    }

                    LihatFoto2(NoTagihan);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }

            }
        }

        public void StreamFileToBrowser(string sFileName, byte[] fileBytes)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.AppendHeader("content-length", fileBytes.Length.ToString());
            context.Response.ContentType = "application/pdf";
            context.Response.AppendHeader("content-disposition", "attachment; filename=" + sFileName);
            context.Response.BinaryWrite(fileBytes);

            // use this instead of response.end to avoid thread aborted exception (known issue):
            // http://support.microsoft.com/kb/312629/EN-US
            context.ApplicationInstance.CompleteRequest();
        }

        //protected void BtnDwnload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // convert to PDF
        //        Doc theDoc = new Doc();
        //        //theDoc.Rect.Inset(80, 200);
        //        //theDoc.Rect.String = "50 50 550 550";
        //        //theDoc.HtmlOptions.Engine = EngineType.Gecko;

        //        //string url = HttpContext.Current.Request.Url.Authority;
        //        string url = HttpContext.Current.Request.Url.AbsoluteUri;

        //        theDoc.AddImageUrl(url);
        //        theDoc.TextStyle.LeftMargin = 20;

        //        byte[] theData = theDoc.GetData();
        //        StreamFileToBrowser("kartu ujian SMM-UNTIDAR 15.pdf", theData);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
        //    }
        //}

        protected void LihatFoto2(string no_tagihan)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, path_foto from smmuntidar_foto where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", NoTagihan); // this.Session["Name"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            this.Image2.ImageUrl = "~/foto/" + reader["path_foto"].ToString();
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
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}