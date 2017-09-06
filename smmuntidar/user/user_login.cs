using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smmuntidar.user
{
    public class user_login : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["Name"] == null && this.Session["password"] == null)
            {
                Response.Redirect("~/Pendaftaran.aspx");
            }
        }
    }
}