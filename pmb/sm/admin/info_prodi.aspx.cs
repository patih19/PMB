using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace pmb.sm
{
    public partial class WebForm4 : pmb_login
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
            //Your Code here....
            this.Session["Name"] = null;
            this.Session["system"] = null;
            this.Session["level"] = null;
            this.Session.Remove("Name");
            this.Session.Remove("system");
            this.Session.Remove("level");
            this.Session.RemoveAll();
            this.Session.Abandon();

            this.Response.Redirect("~/pmb_untidar.aspx", false);
        }
        //---------------- End logout ------------------

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLihat_Click(object sender, EventArgs e)
        {
            this.LbProdi.Text = this.DLProdi.SelectedItem.Text;
            this.LbProdi.ForeColor = System.Drawing.Color.Blue;

            if (this.DLProdi.SelectedItem.Text == "Program Studi")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Program Studi');", true);
                return;
            }

            try
            {
                //-----------------------------------Cek Kelenngkapan Berkas -----------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdBerkas = new SqlCommand("SpStatistikprodi", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdBerkas.CommandType = System.Data.CommandType.StoredProcedure;

                    CmdBerkas.Parameters.AddWithValue("@prodi", this.DLProdi.SelectedItem.Text);

                    SqlParameter Pendaftar = new SqlParameter();
                    Pendaftar.ParameterName = "@pendftr";
                    Pendaftar.SqlDbType = System.Data.SqlDbType.Int;
                    Pendaftar.Direction = System.Data.ParameterDirection.Output;
                    Pendaftar.Size = 5;
                    CmdBerkas.Parameters.Add(Pendaftar);

                    SqlParameter kota = new SqlParameter();
                    kota.ParameterName = "@kota";
                    kota.SqlDbType = System.Data.SqlDbType.Int;
                    kota.Direction = System.Data.ParameterDirection.Output;
                    kota.Size = 10;
                    CmdBerkas.Parameters.Add(kota);

                    SqlParameter luarkota = new SqlParameter();
                    luarkota.ParameterName = "@luarkota";
                    luarkota.SqlDbType = System.Data.SqlDbType.Int;
                    luarkota.Direction = System.Data.ParameterDirection.Output;
                    luarkota.Size = 10;
                    CmdBerkas.Parameters.Add(luarkota);

                    SqlParameter lelaki = new SqlParameter();
                    lelaki.ParameterName = "@male";
                    lelaki.SqlDbType = System.Data.SqlDbType.Int;
                    lelaki.Direction = System.Data.ParameterDirection.Output;
                    lelaki.Size = 10;
                    CmdBerkas.Parameters.Add(lelaki);

                    SqlParameter perempuan = new SqlParameter();
                    perempuan.ParameterName = "@female";
                    perempuan.SqlDbType = System.Data.SqlDbType.Int;
                    perempuan.Direction = System.Data.ParameterDirection.Output;
                    perempuan.Size = 10;
                    CmdBerkas.Parameters.Add(perempuan);

                    SqlParameter sma = new SqlParameter();
                    sma.ParameterName = "@SMA";
                    sma.SqlDbType = System.Data.SqlDbType.Int;
                    sma.Direction = System.Data.ParameterDirection.Output;
                    sma.Size = 10;
                    CmdBerkas.Parameters.Add(sma);

                    SqlParameter smk = new SqlParameter();
                    smk.ParameterName = "@SMK";
                    smk.SqlDbType = System.Data.SqlDbType.Int;
                    smk.Direction = System.Data.ParameterDirection.Output;
                    smk.Size = 10;
                    CmdBerkas.Parameters.Add(smk);

                    SqlParameter tertinggi = new SqlParameter();
                    tertinggi.ParameterName = "@max";
                    tertinggi.SqlDbType = System.Data.SqlDbType.Decimal;
                    tertinggi.Direction = System.Data.ParameterDirection.Output;
                    tertinggi.Size = 10;
                    tertinggi.Precision = 5;
                    tertinggi.Scale = 3;
                    CmdBerkas.Parameters.Add(tertinggi);

                    SqlParameter terendah = new SqlParameter();
                    terendah.ParameterName = "@min";
                    terendah.SqlDbType = System.Data.SqlDbType.Decimal;
                    terendah.Direction = System.Data.ParameterDirection.Output;
                    terendah.Size = 10;
                    terendah.Precision = 5;
                    terendah.Scale = 3;
                    CmdBerkas.Parameters.Add(terendah);


                    CmdBerkas.ExecuteNonQuery();

                    this.LbPendaftar.Text = Pendaftar.Value.ToString();
                    this.LbDalamKota.Text = kota.Value.ToString();
                    this.LbLuarKota.Text = luarkota.Value.ToString();
                    this.LbLelaki.Text = lelaki.Value.ToString();
                    this.LbPerempuan.Text = perempuan.Value.ToString();
                    this.LbSMA.Text = sma.Value.ToString();
                    this.LbSMK.Text = smk.Value.ToString();
                    this.LbTinggi.Text = tertinggi.Value.ToString();
                    this.LbRendah.Text = terendah.Value.ToString();

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void DLProdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}