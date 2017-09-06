using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKT
{
    public class UktLogin : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["NoDaftar"] == null && this.Session["PIN"] == null && this.Session["Jalur"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //base.OnInit(e);
        }
    }
}