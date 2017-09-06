using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PinSemuntidar.user
{
    // public partial class WebForm3 : System.Web.UI.Page
    public partial class WebForm3 : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btlanjut_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/user/alamat.aspx");
        }
    }
}