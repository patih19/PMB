﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace smuntidar.user
{
   // public partial class WebForm9 : System.Web.UI.Page
    public partial class WebForm9 : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtLanjut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user/keluarga.aspx");
        }
    }
}