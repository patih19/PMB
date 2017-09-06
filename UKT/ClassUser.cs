using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKT
{
    // ---------------- PAGE KHUSUS UNTUK OPERATOR UNIT (BAKPK) -------------------------------//
    public class ClassUser : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["NamaUser"] != null && this.Session["Unit"].ToString() == "BAKPK")
            {

            }
            else if (this.Session["NamaUser"] != null && this.Session["Unit"].ToString() == "PMB")
            {
                Response.Redirect("~/op/lst.aspx");
            }
            else if (this.Session["NamaUser"] == null && this.Session["Unit"] == null)
            {
                // redirect to top directory belum jadi
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}