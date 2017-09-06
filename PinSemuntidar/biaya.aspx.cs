using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PinSemuntidar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page Lastpage = (Page)Context.Handler;
                if (Lastpage is WebForm3)
                {
                    this.LbBill.Text = ((WebForm3)Lastpage).Bill;
                }
            }
        }

        public string Bill
        {
            get
            {
                return this.LbBill.Text;
            }
        }

        protected void SavePrint_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/doprint.aspx");
        }
    }
}