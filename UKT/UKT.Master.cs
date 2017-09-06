using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UKT
{
    public partial class UKT : System.Web.UI.MasterPage
    {
        //------------- LogOut ------------------------------//
        protected override void OnInit(EventArgs e)
        {
            // Your code
            base.OnInit(e);
            keluar.ServerClick += new EventHandler(logout_ServerClick);
        }

        protected void logout_ServerClick(object sender, EventArgs e)
        {
            // Old Code ... Your Code here....
            this.Session["NoDaftar"] = (object)null;
            this.Session["PIN"] = (object)null;
            this.Session["Jalur"] = (object)null;
            this.Session.Remove("NoDaftar");
            this.Session.Remove("PIN");
            this.Session.Remove("Jalur");
            this.Session.RemoveAll();

            this.Response.Redirect("Login.aspx");
        }
        // -------------- End Logout ----------------------------

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}