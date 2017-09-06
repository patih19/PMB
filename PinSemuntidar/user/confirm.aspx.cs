using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PinSemuntidar.user
{
    // public partial class WebForm2 : System.Web.UI.Page
    public partial class WebForm2 : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtLanjut_Click(object sender, EventArgs e)
        {
            if (this.RBSetuju.Checked == true)
            {
                Response.Redirect("~/user/identity.aspx");
            }
        }
    }
}