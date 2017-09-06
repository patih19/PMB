using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PinSemuntidar
{
    public partial class doprint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page Lastpage = (Page)Context.Handler;
                if (Lastpage is WebForm2)
                {
                    this.LbBill.Text = ((WebForm2)Lastpage).Bill;
                }
            }
        }

        protected void BtnMakasih_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pendaftaran.aspx");
        }
    }
}