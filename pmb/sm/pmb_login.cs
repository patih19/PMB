using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pmb.sm
{
    public class pmb_login : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["Name"] == null && this.Session["system"] == null)
            {
                Response.Redirect("~/pmb_untidar.aspx");
            }
        }
    }
}