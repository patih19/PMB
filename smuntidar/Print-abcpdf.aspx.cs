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


namespace smuntidar
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Doc theDoc = new Doc();
            theDoc.Rect.Inset(72, 144);
            theDoc.HtmlOptions.Engine = EngineType.Gecko;

            theDoc.Page = theDoc.AddPage();
            int theID;
            //string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //string url2 = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
            string url = "http://localhost";
            theID = theDoc.AddImageUrl(url);

            while (true)
            {
                theDoc.FrameRect(); // add a black border
                if (!theDoc.Chainable(theID))
                    break;
                theDoc.Page = theDoc.AddPage();
                theID = theDoc.AddImageToChain(theID);
            }

            for (int i = 1; i <= theDoc.PageCount; i++)
            {
                theDoc.PageNumber = i;
                theDoc.Flatten();
            }

            theDoc.Save(Server.MapPath("pagedhtml.pdf"));
            theDoc.Clear();

            //// -============================= SCRIPT OK ======================== 
            //Doc theDoc = new Doc();
            ////theDoc.Rect.Inset(90, 150);
            //theDoc.HtmlOptions.Engine = EngineType.Gecko;
            //theDoc.AddImageUrl("http://google.com");
            //theDoc.TextStyle.LeftMargin = 50;

            //byte[] theData = theDoc.GetData();
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "inline; filename=MyPDF.PDF");
            //Response.AddHeader("content-length", theData.Length.ToString());
            //Response.BinaryWrite(theData);
            //Response.End();
            //// ====================================================================

            //Response.Redirect("~/WebForm5.aspx");
            //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("~/WebForm5.aspx")));
            //string url = "http://google.com";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('" + url + "');", true);

            //ClientScript.RegisterStartupScript(GetType(), "Javascript", "SetTarget()", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/WebForm5.aspx");

            Doc theDoc = new Doc();
            //theDoc.Rect.Inset(90, 150);
            theDoc.HtmlOptions.Engine = EngineType.Gecko;

            theDoc.AddImageUrl("http://localhost/smuntidar/home.aspx");
            theDoc.TextStyle.LeftMargin = 50;

            byte[] theData = theDoc.GetData();
            StreamFileToBrowser("xxx.pdf", theData);
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/WebForm5.aspx");

            //Response.Redirect("~/WebForm5.aspx");
            //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("~/WebForm5.aspx")));
        }
    }
}