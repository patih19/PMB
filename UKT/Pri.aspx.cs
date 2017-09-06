using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace UKT
{
    // public partial class WebForm1 : System.Web.UI.Page
    public partial class WebForm1 : UktLogin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Response.Write(this.Session["NoDaftar"].ToString().Trim() +" ");

                // --------- jika proses komplet berlanjut ke step berikutnya (Borang Keluarga) ----------
                string CS1 = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS1))
                {
                    try
                    {
                        con.Open();

                        // Cek Bidikmisi
                        SqlCommand CekBdkMisi = new SqlCommand("SpCekBidikmisi", con);
                        CekBdkMisi.CommandType = System.Data.CommandType.StoredProcedure;
                        CekBdkMisi.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                        using (SqlDataReader rdr = CekBdkMisi.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    if (rdr["bdk"].ToString() == "1")
                                    {
                                        this.PanelBdk.Enabled = true;
                                        this.PanelBdk.Visible = true;
                                    }
                                    else
                                    {
                                        this.PanelBdk.Enabled = false;
                                        this.PanelBdk.Visible = false;
                                    }
                                }
                            }
                        }

                    } catch ( Exception ex)
                    {
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                        return;
                    }
                }
            }

            // --------- jika proses komplet berlanjut ke step berikutnya (Borang Keluarga) ----------
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();

                    // Cek Kelengkpan berkas pengisian
                    SqlCommand cmd = new SqlCommand("SELECT no_daftar,komplate, valid FROM dbo.ukt_pribadi WHERE no_daftar=@no_daftar", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["komplate"].ToString() == "yes" && rdr["valid"].ToString() == "yes")
                                {
                                    Response.Redirect("Kel.aspx", false);
                                }
                                else if (rdr["komplate"].ToString() == "yes" && rdr["valid"] == DBNull.Value)
                                {
                                    Response.Redirect("ValPri.aspx", false);
                                }
                            }
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
            // ---------------------------------End Cek Proses komplate ----------------------------------------------
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Form validasi
            if (this.TbNama.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Nama');", true);
                return;
            }
            if (this.TbAlamat.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Alamat');", true);
                return;
            }
            if (this.TbTgLahir.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Tanggal Lahir');", true);
                return;
            }
            if (this.TbEmail.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Email');", true);
                return;
            }
            if (this.TbHp.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi No HP');", true);
                return;
            }
            if (this.TbTelpRmh.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Telp Rumah');", true);
                return;
            }
            if (this.TbAyah.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Nama Ayah');", true);
                return;
            }
            if (this.TbIbu.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isi Nama Ibu');", true);
                return;
            }

            // Get Nilai 
            int Nilai = Convert.ToInt32(DLPendidikanAyah.SelectedValue) +
                Convert.ToInt32( DLKerjaanAyah.SelectedValue) + 
                Convert.ToInt32 (DLModalAyah.SelectedValue) + 
                Convert.ToInt32 (DLLabaAyah.SelectedValue) + 
                Convert.ToInt32 (DLPendidikanIbu.SelectedValue) + 
                Convert.ToInt32 (DLKerjaanIbu.SelectedValue) + 
                Convert.ToInt32 (DLModalIbu.SelectedValue) + 
                Convert.ToInt32 (DLLabaIbu.SelectedValue);

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    //open connection and begin transaction
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    //SpInsertIdentitas
                    // 1.) Insert Tagihan Periodik Mhs (mjd msh aktif) by using SpInsertTagihanPeriodikMhs ---
                    SqlCommand cmd = new SqlCommand("SpInsertPribadi", con);
                    //cmd.Transaction = trans;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@no_daftar", this.Session["NoDaftar"].ToString());
                    cmd.Parameters.AddWithValue("@nilai", Nilai);
                    cmd.Parameters.AddWithValue("@nama", TbNama.Text);
                    cmd.Parameters.AddWithValue("@gender", DlGender.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@alamat", TbAlamat.Text);
                    cmd.Parameters.AddWithValue("@tmplahir", TempatLahir.Text);
                    cmd.Parameters.AddWithValue("@tglahir", TbTgLahir.Text);
                    cmd.Parameters.AddWithValue("@email",TbEmail.Text );
                    cmd.Parameters.AddWithValue("@hp", TbHp.Text);
                    cmd.Parameters.AddWithValue("@telp", TbTelpRmh.Text);
                    cmd.Parameters.AddWithValue("@ayah", TbAyah.Text);
                    cmd.Parameters.AddWithValue("@stayah", DlStAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdayah", DLPendidikanAyah.SelectedItem.Text );
                    cmd.Parameters.AddWithValue("@kerjaayah", this.DLKerjaanAyah.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalayah", DLModalAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaayah", DLLabaAyah.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@ibu", TbIbu.Text);
                    cmd.Parameters.AddWithValue("@stibu", DLStatausIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@pdibu",DLPendidikanIbu.SelectedItem.Text );
                    cmd.Parameters.AddWithValue("@kerjaibu", this.DLKerjaanIbu.SelectedItem.Text.ToString());
                    cmd.Parameters.AddWithValue("@modalibu", DLModalIbu.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@labaibu", DLLabaIbu.SelectedItem.Text);

                    cmd.ExecuteNonQuery();

                    Response.Redirect("ValPri.aspx", false);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

    }
}