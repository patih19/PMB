﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PinSemuntidar.user
{
    public partial class WebForm7 : System.Web.UI.Page
    // public partial class WebForm7 : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user/pasfoto.aspx");
        }
    }
}