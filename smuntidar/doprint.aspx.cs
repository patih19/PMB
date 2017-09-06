using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSupergoo.ABCpdf9;
using WebSupergoo.ABCpdf9.Objects;
using WebSupergoo.ABCpdf9.Atoms;
using WebSupergoo.ABCpdf9.Operations;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace smuntidar
{
    public partial class doprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //this.Session["NoTagihan"] = Request.QueryString["req"].ToString();
                    this.Session["NoTagihan"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["req"]));


                    string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        //SqlTransaction trans = con.BeginTransaction();

                        SqlCommand CmdPrint = new SqlCommand("SELECT * FROM dbo.smuntidar_tagihan WHERE no_pendaftar=@no_pendaftar", con);
                        //CmdPeriodik.Transaction = trans;
                        //CmdPeriodik.CommandType = System.Data.CommandType.Text;

                        string ses = this.Session["NoTagihan"].ToString();

                        CmdPrint.Parameters.AddWithValue("@no_pendaftar", this.Session["NoTagihan"].ToString());

                        using (SqlDataReader rdr = CmdPrint.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.LbNama.Text = rdr["nama"].ToString();
                                    this.LbNoDaftar.Text = rdr["no_pendaftar"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert(' Login Gagal, " + ex.Message.ToString() + "');", true);
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

        protected void BtnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                this.BtnDownload.Visible = false;

                // convert to PDF
                Doc theDoc = new Doc();
                theDoc.Rect.Inset(80, 200);
                //theDoc.Rect.String = "50 50 550 550";
                //theDoc.HtmlOptions.Engine = EngineType.Gecko;

                //string url = HttpContext.Current.Request.Url.Authority;
                string url = HttpContext.Current.Request.Url.AbsoluteUri;

                theDoc.AddImageUrl(url);
                theDoc.TextStyle.LeftMargin = 20;

                byte[] theData = theDoc.GetData();
                StreamFileToBrowser("xxx.pdf", theData);
            }
            catch (Exception ex)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        //Decrypting the QueryString Parameter Values
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "##UniversitasTidar123##";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}