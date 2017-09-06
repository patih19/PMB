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

namespace smmuntidar.user
{
    //public partial class WebForm17 : System.Web.UI.Page
    public partial class WebForm17 : user_login
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
            this.Session["Passwd"] = null;
            this.Session.Remove("Name");
            this.Session.Remove("Passwd");
            this.Session.Remove("no_tagihan");
            this.Session.RemoveAll();

            this.Response.Redirect("~/Pendaftaran.aspx", false);
        }
        //---------------- End logout ------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LbTrans.Text = this.Session["Name"].ToString();

                // -------------- Cek Kelengkapan Pengisian Form Pendaftaran -----------------
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_pilihan where smmuntidar_pilihan.no_tagihan=@no_tagihan", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdPeriodik.CommandType = System.Data.CommandType.Text;

                    CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["proses_komplet"].ToString() == "ok")
                                {
                                    Response.Redirect("~/user/sumbangan.aspx", false);
                                }
                                else //proses pengisian biodata pendaftaran belum lengkap
                                {
                                    Response.Redirect("~/user/confirm.aspx", false);
                                }
                            }
                        }
                        else
                        {
                            // ------------- keterangan ---------------- //
                            // ini diaktifkan => setelah masa daftar/create tagihan ditutup
                            // dan masa pengisian juga ditutup
                            TutupPengisian();
                        }
                    }
                }
                //---------------------------------- End Cek Kelengkapan Pengisisan Proses Pendaftaran ----------------------
            }
        }

        protected void TutupPengisian()
        {
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                //SqlTransaction trans = con.BeginTransaction();

                SqlCommand CmdPeriodik = new SqlCommand("select proses_komplet from smmuntidar_foto where smmuntidar_foto.no_tagihan=@no_tagihan", con);
                //CmdPeriodik.Transaction = trans;
                CmdPeriodik.CommandType = System.Data.CommandType.Text;

                CmdPeriodik.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                using (SqlDataReader rdr = CmdPeriodik.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            if (rdr["proses_komplet"].ToString() == "ok")
                            {
                               
                            }
                            else //proses pengisian biodata pendaftaran belum lengkap
                            {
                                this.LbMsg.Text = "MASA PENGISIAN SUDAH DITUTUP ...";
                                this.LbMsg.ForeColor = System.Drawing.Color.Red;
                                this.BtprodiNxt.Enabled = false;
                                this.BtprodiNxt.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        this.LbMsg.Text = "MASA PENGISIAN SUDAH DITUTUP ...";
                        this.LbMsg.ForeColor = System.Drawing.Color.Red;
                        this.BtprodiNxt.Enabled = false;
                        this.BtprodiNxt.Visible = false;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.DLPil1.SelectedItem.Text == "Pilihan I")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pilihan Pertama ');", true);
                return;
            }

            if (this.DlPil2.SelectedItem.Text == "Pilihan II")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Pilih Pilihan Kedua ');", true);
                return;
            }

            if (this.DLPil1.SelectedItem.Text == this.DlPil2.SelectedItem.Text)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Program Studi Tidak Boleh Sama');", true);
                return;
            }

            // ----------- mark pilihan I dan II ------------------
            int pilihan1 = 0;
            int pilihan2 = 0;

            if (this.DLPil1.SelectedItem.Text.Trim() == "S1 TEKNIK ELEKTRO" || this.DLPil1.SelectedItem.Text.Trim() == "S1 TEKNIK MESIN" || this.DLPil1.SelectedItem.Text.Trim() == "D3 TEKNIK MESIN" || this.DLPil1.SelectedItem.Text.Trim() == "S1 TEKNIK SIPIL" || this.DLPil1.SelectedItem.Text.Trim() == "S1 AGROTEKNOLOGI" || this.DLPil1.SelectedItem.Text.Trim() == "S1 PETERNAKAN" || this.DLPil1.SelectedItem.Text.Trim() == "S1 PENDIDIKAN ILMU PENGETAHUAN ALAM")
            {
                pilihan1 = 1;
            }
            else
            {
                pilihan1 = 2;
            }

            if (this.DlPil2.SelectedItem.Text.Trim() == "S1 TEKNIK ELEKTRO" || this.DlPil2.SelectedItem.Text.Trim() == "S1 TEKNIK MESIN" || this.DlPil2.SelectedItem.Text.Trim() == "D3 TEKNIK MESIN" || this.DlPil2.SelectedItem.Text.Trim() == "S1 TEKNIK SIPIL" || this.DlPil2.SelectedItem.Text.Trim() == "S1 AGROTEKNOLOGI" || this.DlPil2.SelectedItem.Text.Trim() == "S1 PETERNAKAN" || this.DlPil2.SelectedItem.Text.Trim() == "S1 PENDIDIKAN ILMU PENGETAHUAN ALAM")
            {
                pilihan2 = 1;
            }
            else
            {
                pilihan2 = 2;
            }

            //----------------- Cek Pilihan I dan II -------------------------
            if (pilihan1 == 1 && pilihan2==1)
            {

            }
            else if (pilihan1 == 2 && pilihan2 == 2)
            {

            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kelompok harus sama');", true);
                return;
            }


            //Action to save to DB
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            string jenis = "";
            using (SqlConnection con = new SqlConnection(CS))
            {

                //open connection and begin transaction
                con.Open();
                SqlTransaction trans = con.BeginTransaction();
                try
                {
                    // Insert to DB ---
                    SqlCommand cmd = new SqlCommand("SpInsertPilihan", con);
                    cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    cmd.Parameters.AddWithValue("@pil1", this.DLPil1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pil2", this.DlPil2.SelectedItem.Text);

                    //if (this.DlPil2.SelectedItem.Text == "")
                    //{
                    //    cmd.Parameters.AddWithValue("@pil2", DBNull.Value);
                    //}
                    //else if (this.DlPil2.SelectedItem.Text != "")
                    //{
                    //    cmd.Parameters.AddWithValue("@pil2", this.DlPil2.SelectedItem.Text);
                    //}

                    cmd.ExecuteNonQuery();


                    if (this.DLPil1.SelectedItem.Text.Trim() == "S1 TEKNIK ELEKTRO" || this.DLPil1.SelectedItem.Text.Trim() == "S1 TEKNIK MESIN" || this.DLPil1.SelectedItem.Text.Trim() == "D3 TEKNIK MESIN" || this.DLPil1.SelectedItem.Text.Trim() == "S1 TEKNIK SIPIL" || this.DLPil1.SelectedItem.Text.Trim() == "S1 AGROTEKNOLOGI" || this.DLPil1.SelectedItem.Text.Trim() == "S1 PETERNAKAN" || this.DLPil1.SelectedItem.Text.Trim() == "S1 PENDIDIKAN ILMU PENGETAHUAN ALAM")
                    {
                        jenis = "1";
                    }
                    else
                    {
                        jenis = "2";
                    }

                    SqlCommand cmdup = new SqlCommand("UPDATE dbo.smmuntidar_tagihan SET no_ujian=@New_Nomor WHERE no_tagihan=@no_tagihan", con);
                    cmdup.Transaction = trans;
                    cmdup.CommandType = System.Data.CommandType.Text;

                    cmdup.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());
                    cmdup.Parameters.AddWithValue("@New_Nomor", jenis + this.Session["Name"].ToString());

                    cmdup.ExecuteNonQuery();

                    trans.Commit();
                    cmd.Dispose();
                    cmdup.Dispose();

                    Response.Redirect("~/user/sumbangan.aspx", false);
                }
                catch (Exception ex)
                {
                    trans.Commit();
                    con.Close();
                    con.Dispose();

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
    }
}