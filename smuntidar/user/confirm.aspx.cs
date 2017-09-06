﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace smuntidar.user
{
    //public partial class WebForm3 : System.Web.UI.Page
    public partial class WebForm3 : user_login
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtLanjut_Click(object sender, EventArgs e)
        {
            if (this.RBSetuju.Checked)
            {
                Response.Redirect("~/user/identity.aspx",false);
            } else
                if (this.RBBack.Checked)
                {
                    this.Session["Name"] = null;
                    this.Session["Passwd"] = null;
                    this.Session.Remove("Name");
                    this.Session.Remove("Passwd");
                    this.Session.Remove("no_tagihan");
                    this.Session.RemoveAll();

                    Response.Redirect("~/Pendaftaran.aspx",false);
                }
        }
    }
}