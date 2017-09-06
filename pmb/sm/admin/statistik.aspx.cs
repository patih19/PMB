using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace pmb.sm
{
    public partial class WebForm8 : pmb_login
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
            if (!Page.IsPostBack)
            {
                try
                {
                    //-----------------------------------Cek Kelenngkapan Berkas -----------------------------------------------
                    string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        //SqlTransaction trans = con.BeginTransaction();

                        SqlCommand Cmdstatistik = new SqlCommand("SpStatistik", con);
                        //CmdPeriodik.Transaction = trans;
                        Cmdstatistik.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter Pendaftar = new SqlParameter();
                        Pendaftar.ParameterName = "@pendaftar";
                        Pendaftar.SqlDbType = System.Data.SqlDbType.Int;
                        Pendaftar.Direction = System.Data.ParameterDirection.Output;
                        Pendaftar.Size = 5;
                        Cmdstatistik.Parameters.Add(Pendaftar);

                        SqlParameter Diterima = new SqlParameter();
                        Diterima.ParameterName = "@diterima";
                        Diterima.SqlDbType = System.Data.SqlDbType.Int;
                        Diterima.Direction = System.Data.ParameterDirection.Output;
                        Diterima.Size = 5;
                        Cmdstatistik.Parameters.Add(Diterima);

                        SqlParameter Kota = new SqlParameter();
                        Kota.ParameterName = "@kota";
                        Kota.SqlDbType = System.Data.SqlDbType.Int;
                        Kota.Direction = System.Data.ParameterDirection.Output;
                        Kota.Size = 5;
                        Cmdstatistik.Parameters.Add(Kota);

                        SqlParameter LuarKota = new SqlParameter();
                        LuarKota.ParameterName = "@luarkota";
                        LuarKota.SqlDbType = System.Data.SqlDbType.Int;
                        LuarKota.Direction = System.Data.ParameterDirection.Output;
                        LuarKota.Size = 5;
                        Cmdstatistik.Parameters.Add(LuarKota);

                        SqlParameter Lelaki = new SqlParameter();
                        Lelaki.ParameterName = "@lelaki";
                        Lelaki.SqlDbType = System.Data.SqlDbType.Int;
                        Lelaki.Direction = System.Data.ParameterDirection.Output;
                        Lelaki.Size = 5;
                        Cmdstatistik.Parameters.Add(Lelaki);

                        SqlParameter Perempuan = new SqlParameter();
                        Perempuan.ParameterName = "@perempuan";
                        Perempuan.SqlDbType = System.Data.SqlDbType.Int;
                        Perempuan.Direction = System.Data.ParameterDirection.Output;
                        Perempuan.Size = 5;
                        Cmdstatistik.Parameters.Add(Perempuan);

                        SqlParameter SMA = new SqlParameter();
                        SMA.ParameterName = "@SMA";
                        SMA.SqlDbType = System.Data.SqlDbType.Int;
                        SMA.Direction = System.Data.ParameterDirection.Output;
                        SMA.Size = 5;
                        Cmdstatistik.Parameters.Add(SMA);

                        SqlParameter SMK = new SqlParameter();
                        SMK.ParameterName = "@SMK";
                        SMK.SqlDbType = System.Data.SqlDbType.Int;
                        SMK.Direction = System.Data.ParameterDirection.Output;
                        SMK.Size = 5;
                        Cmdstatistik.Parameters.Add(SMK);

                        SqlParameter elektro = new SqlParameter();
                        elektro.ParameterName = "@elektro";
                        elektro.SqlDbType = System.Data.SqlDbType.Int;
                        elektro.Direction = System.Data.ParameterDirection.Output;
                        elektro.Size = 5;
                        Cmdstatistik.Parameters.Add(elektro);

                        SqlParameter mesin = new SqlParameter();
                        mesin.ParameterName = "@mesin";
                        mesin.SqlDbType = System.Data.SqlDbType.Int;
                        mesin.Direction = System.Data.ParameterDirection.Output;
                        mesin.Size = 5;
                        Cmdstatistik.Parameters.Add(mesin);

                        SqlParameter oto = new SqlParameter();
                        oto.ParameterName = "@otomotif";
                        oto.SqlDbType = System.Data.SqlDbType.Int;
                        oto.Direction = System.Data.ParameterDirection.Output;
                        oto.Size = 5;
                        Cmdstatistik.Parameters.Add(oto);


                        SqlParameter sipil = new SqlParameter();
                        sipil.ParameterName = "@sipil";
                        sipil.SqlDbType = System.Data.SqlDbType.Int;
                        sipil.Direction = System.Data.ParameterDirection.Output;
                        sipil.Size = 5;
                        Cmdstatistik.Parameters.Add(sipil);


                        SqlParameter pertanian = new SqlParameter();
                        pertanian.ParameterName = "@pertanian";
                        pertanian.SqlDbType = System.Data.SqlDbType.Int;
                        pertanian.Direction = System.Data.ParameterDirection.Output;
                        pertanian.Size = 5;
                        Cmdstatistik.Parameters.Add(pertanian);


                        SqlParameter ekonomi = new SqlParameter();
                        ekonomi.ParameterName = "@ekonomi";
                        ekonomi.SqlDbType = System.Data.SqlDbType.Int;
                        ekonomi.Direction = System.Data.ParameterDirection.Output;
                        ekonomi.Size = 5;
                        Cmdstatistik.Parameters.Add(ekonomi);


                        SqlParameter akuntansi = new SqlParameter();
                        akuntansi.ParameterName = "@akuntansi";
                        akuntansi.SqlDbType = System.Data.SqlDbType.Int;
                        akuntansi.Direction = System.Data.ParameterDirection.Output;
                        akuntansi.Size = 5;
                        Cmdstatistik.Parameters.Add(akuntansi);

                        SqlParameter sospol = new SqlParameter();
                        sospol.ParameterName = "@sospol";
                        sospol.SqlDbType = System.Data.SqlDbType.Int;
                        sospol.Direction = System.Data.ParameterDirection.Output;
                        sospol.Size = 5;
                        Cmdstatistik.Parameters.Add(sospol);

                        SqlParameter indo = new SqlParameter();
                        indo.ParameterName = "@indonesia";
                        indo.SqlDbType = System.Data.SqlDbType.Int;
                        indo.Direction = System.Data.ParameterDirection.Output;
                        indo.Size = 5;
                        Cmdstatistik.Parameters.Add(indo);

                        SqlParameter inggris = new SqlParameter();
                        inggris.ParameterName = "@inggris";
                        inggris.SqlDbType = System.Data.SqlDbType.Int;
                        inggris.Direction = System.Data.ParameterDirection.Output;
                        inggris.Size = 5;
                        Cmdstatistik.Parameters.Add(inggris);


                        Cmdstatistik.ExecuteNonQuery();


                        this.LbPendaftar.Text = Pendaftar.Value.ToString();
                        this.LbPendaftar.Text = Pendaftar.Value.ToString();
                        this.LbDiterima.Text = Diterima.Value.ToString();
                        this.LbDalamKota.Text = Kota.Value.ToString();
                        this.LbLuarKota.Text = LuarKota.Value.ToString();
                        this.LbLelaki.Text = Lelaki.Value.ToString();
                        this.LbPerempuan.Text = Perempuan.Value.ToString();
                        this.LbSMA.Text = SMA.Value.ToString();
                        this.LbSMK.Text = SMK.Value.ToString();
                        this.LbElektro.Text = elektro.Value.ToString();
                        this.LbMesin.Text =  mesin.Value.ToString();
                        this.LbOtomotif.Text = oto.Value.ToString();
                        this.LbSipil.Text = sipil.Value.ToString();
                        this.LbPertaninan.Text = pertanian.Value.ToString();
                        this.LbEkonomi.Text = ekonomi.Value.ToString();
                        this.LbAkuntansi.Text = akuntansi.Value.ToString();
                        this.LbSospol.Text =  sospol.Value.ToString();
                        this.LbIndonesia.Text = indo.Value.ToString();
                        this.LbInggris.Text = inggris.Value.ToString();


                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }
    }
}