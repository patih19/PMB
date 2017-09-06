using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuveriBidikmisi
{
    public partial class Survei : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            keluar.ServerClick += new EventHandler(keluar_ServerClick);
        }

        protected void keluar_ServerClick(object sender, EventArgs e)
        {
            this.Session["nama"] = (object)null;
            this.Session.Remove("nama");
            this.Session.RemoveAll();
            this.Response.Redirect("~/Login.aspx");
        }
    }
}