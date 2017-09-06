using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandingUKT
{
    public class User : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["nama"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
}