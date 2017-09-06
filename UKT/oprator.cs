using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UKT
{
    public class oprator : System.Web.UI.Page
    {
        // --------------- Halaman Khusus Operator PMB ------------------- //
        protected override void OnInit(EventArgs e)
        {
            if (this.Session["NamaUser"] != null && this.Session["Unit"].ToString() == "PMB")
            {
                
            }
            else if (this.Session["NamaUser"] != null && this.Session["Unit"].ToString() == "BAKPK")
            {
                Response.Redirect("~/user/mark.aspx");
            }
            else if (this.Session["NamaUser"] == null && this.Session["Unit"] == null)
            {
                // redirect to top directory belum jadi
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}