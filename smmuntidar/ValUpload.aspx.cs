using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace smmuntidar
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public string NoTagihan
        { get; set; }

        public string Email
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnProses_Click(object sender, EventArgs e)
        {
            //this.tg.Text = no_pendaftaran.Value.ToString();

            //Filter Input
            if (this.TbNama.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nama Harus Diisi');", true);
                return;
            }
            if (this.TbNoIdentitas.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Nomor Identitas Harus Diisi');", true);
                return;
            }
            if (this.TbCaptcha2.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Harus Diisi');", true);
                return;
            }

            this.Captcha2.ValidateCaptcha(this.TbCaptcha2.Text.Trim());
            if (this.Captcha2.UserValidated)
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    //open connection and begin transaction
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    try
                    {
                        // ------ Cek Masa Pendaftaran -------
                        SqlCommand CmdCekMasa = new SqlCommand("SpCekMasaDaftar", con);
                        //CmdCekMasa.Transaction = trans;
                        CmdCekMasa.CommandType = System.Data.CommandType.StoredProcedure;

                        CmdCekMasa.Parameters.AddWithValue("@jenis_keg", "daftar");

                        SqlParameter Status = new SqlParameter();
                        Status.ParameterName = "@output";
                        Status.SqlDbType = System.Data.SqlDbType.VarChar;
                        Status.Size = 50;
                        Status.Direction = System.Data.ParameterDirection.Output;
                        CmdCekMasa.Parameters.Add(Status);

                        CmdCekMasa.ExecuteNonQuery();

                        if (Status.Value.ToString() != "BUKA")
                        {
                            //trans.Rollback();
                            con.Close();

                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Proses Tidak Sesuai Jadwal Pendaftaran !!!');", true);
                            return;
                        }

                        // Insert Tagihan pendaftar
                        SqlCommand CmdTagihan = new SqlCommand("SpValUp", con);
                        //CmdTagihan.Transaction = trans;
                        CmdTagihan.CommandType = System.Data.CommandType.StoredProcedure;

                        CmdTagihan.Parameters.AddWithValue("@kode_tagihan", this.TBKdTagihan.Text.Trim());
                        CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama.Text.Trim());
                        CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas.SelectedItem.Text.Trim());
                        CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas.Text.Trim());

                        SqlParameter no_tagihan = new SqlParameter();
                        no_tagihan.ParameterName = "@no_tagihan";
                        no_tagihan.SqlDbType = System.Data.SqlDbType.VarChar;
                        no_tagihan.Direction = System.Data.ParameterDirection.Output;
                        no_tagihan.Size = 20;
                        CmdTagihan.Parameters.Add(no_tagihan);

                        SqlParameter email = new SqlParameter();
                        email.ParameterName = "@email";
                        email.SqlDbType = System.Data.SqlDbType.VarChar;
                        email.Direction = System.Data.ParameterDirection.Output;
                        email.Size = 200;
                        CmdTagihan.Parameters.Add(email);

                        CmdTagihan.ExecuteNonQuery();

                        NoTagihan = no_tagihan.Value.ToString();
                        Email = email.Value.ToString();

                        //trans.Commit();
                        //trans.Dispose();
                        CmdTagihan.Dispose();

                    }
                    catch (Exception ex)
                    {
                        //trans.Rollback();
                        con.Close();
                        con.Dispose();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                        return;
                    }
                }
                Server.Transfer("~/Upload.aspx"); 
                //Response.Redirect("~/biaya.aspx");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                return;
            }
        }
    }
}