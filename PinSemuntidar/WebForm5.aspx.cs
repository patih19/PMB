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
using System.IO; 
namespace PinSemuntidar
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Doc theDoc = new Doc();
            //theDoc.Rect.Inset(90, 150);
            theDoc.HtmlOptions.Engine = EngineType.Gecko;

            theDoc.AddImageUrl("http://google.com");
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
    }
}