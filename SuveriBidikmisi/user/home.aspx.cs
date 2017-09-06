using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SuveriBidikmisi
{
    public partial class home : SuveriBidikmisi.user.user
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                HtmlGenericControl control = (HtmlGenericControl)base.Master.FindControl("NavHome");
                control.Attributes.Add("class", "dropdown active opened");
                HtmlGenericControl control2 = (HtmlGenericControl)base.Master.FindControl("NavExample");
                control2.Attributes.Add("style", "display: none;");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }



    }
}