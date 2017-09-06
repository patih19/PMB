using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace PinSemuntidar
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
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
            if (this.TbCaptcha.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Harus Diisi');", true);
                return;
            }

            this.Captcha.ValidateCaptcha(this.TbCaptcha.Text.Trim());
            if (this.Captcha.UserValidated)
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    //open connection and begin transaction
                    con.Open();
                    SqlTransaction trans = con.BeginTransaction();

                    try
                    {
                        // Insert Tagihan pendaftar
                        SqlCommand CmdTagihan = new SqlCommand("SpInsertNoTagihanSmuntidar", con);
                        CmdTagihan.Transaction = trans;
                        CmdTagihan.CommandType = System.Data.CommandType.StoredProcedure;

                        CmdTagihan.Parameters.AddWithValue("@nama", this.TbNama.Text);
                        CmdTagihan.Parameters.AddWithValue("@identitas", this.DLIdentitas.SelectedItem.Text);
                        CmdTagihan.Parameters.AddWithValue("@no_identitas", this.TbNoIdentitas.Text);
                        string strPIN = PinRandom(12);
                        CmdTagihan.Parameters.AddWithValue("@pin", strPIN);
                        CmdTagihan.ExecuteNonQuery();

                        trans.Commit();
                        trans.Dispose();
                        CmdTagihan.Dispose();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        con.Close();
                        con.Dispose();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                        return;
                    }
                }

                // Get Bill Number
                string CS2 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con2 = new SqlConnection(CS2))
                {
                    //open connection and begin transaction
                    con2.Open();

                    try
                    {
                        SqlCommand CmdNoTagihan = new SqlCommand("select no_tagihan from smuntidar_tagihan where nama=@nama AND no_identitas=@no_iden", con2);
                        CmdNoTagihan.CommandType = System.Data.CommandType.Text;

                        CmdNoTagihan.Parameters.AddWithValue("@nama", this.TbNama.Text);
                        CmdNoTagihan.Parameters.AddWithValue("@no_iden", this.TbNoIdentitas.Text);

                        using (SqlDataReader sqlDataReader = CmdNoTagihan.ExecuteReader())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                while (sqlDataReader.Read())
                                {
                                    this.bl.Text = sqlDataReader["no_tagihan"].ToString();
                                }
                            }
                        }

                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('INPUT DATA BERHASIL ...');", true);

                        Server.Transfer("~/biaya.aspx");

                        con2.Close();
                        con2.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con2.Close();
                        con2.Dispose();
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                        return;
                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Kode Keamanan Tidak Valid');", true);
                return;
            }
        }

        public string Bill
        {
            get
            {
                return this.bl.Text;
            }
        }

        private static string PinRandom(int size)
        {
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] numArray = new byte[size];
            cryptoServiceProvider.GetBytes(numArray);
            return Convert.ToBase64String(numArray);
        }
    }
}