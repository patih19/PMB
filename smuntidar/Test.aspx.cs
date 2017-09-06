using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using WebSupergoo.ABCpdf9;
using WebSupergoo.ABCpdf9.Objects;
using WebSupergoo.ABCpdf9.Atoms;
using WebSupergoo.ABCpdf9.Operations;

namespace smuntidar
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                    string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        //SqlTransaction trans = con.BeginTransaction();

                        SqlCommand CmdPeriodik = new SqlCommand("SELECT * FROM dbo.smuntidar_users WHERE username='umam'", con);
                        //CmdPeriodik.Transaction = trans;
                        CmdPeriodik.CommandType = System.Data.CommandType.Text;

                        //CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                        using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    this.Label1.Text = rdr["tingkatan"].ToString();
                                    this.Label2.Text = rdr["unit"].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            // convert to PDF
            Doc theDoc = new Doc();
            //theDoc.Rect.Inset(50, 100);
            //theDoc.Rect.String = "50 50 550 550";
            theDoc.HtmlOptions.Engine = EngineType.Gecko;

            //string url = HttpContext.Current.Request.Url.Authority;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            theDoc.AddImageUrl(url);
            theDoc.TextStyle.LeftMargin = 20;

            byte[] theData = theDoc.GetData();
            StreamFileToBrowser("xxx.pdf", theData);
        }
    }
}