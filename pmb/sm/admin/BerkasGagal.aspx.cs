using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace pmb.sm
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelDetailPendaftar.Enabled = false;
                this.PanelDetailPendaftar.Visible = false;
            }
        }

        protected void BtnCari_Click(object sender, EventArgs e)
        {
            //Validasi
            if (this.TbCari.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Isikan Nomor Peserta');", true);
                return;
            }

            this.LbKeterangan.Text = "";

            //-----------------------------------Keterangan Biodata -----------------------------------------------
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                //SqlTransaction trans = con.BeginTransaction();

                SqlCommand CmdBiodata = new SqlCommand("SpBiodataPendaftar", con);
                //CmdPeriodik.Transaction = trans;
                CmdBiodata.CommandType = System.Data.CommandType.StoredProcedure;

                CmdBiodata.Parameters.AddWithValue("@no_tagihan", this.TbCari.Text);
                // CmdBiodata.Parameters.AddWithValue("@no_tagihan", this.GVPendaftar.SelectedRow.Cells[1].Text);

                using (SqlDataReader rdr = CmdBiodata.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        this.PanelDetailPendaftar.Enabled = true;
                        this.PanelDetailPendaftar.Visible = true;

                        while (rdr.Read())
                        {
                            this.LbNama.Text = rdr["nama"].ToString();
                            this.LbTmpLahir.Text = rdr["kab_kota"].ToString();

                            DateTime dt = DateTime.Parse(rdr["tgl_lahir"].ToString());

                            this.LbTglLhair.Text = dt.ToString("dd-MM-yyyy");
                            this.LbGender.Text = rdr["gender"].ToString();
                            this.LbWarga.Text = rdr["warga"].ToString();
                            this.LbAgama.Text = rdr["agama"].ToString();
                            this.LbAlamat.Text = rdr["alamat"].ToString();
                            this.LbHp.Text = rdr["ho_hp"].ToString();

                            this.LbSekolah.Text = rdr["sekolah"].ToString();
                            this.LbJurusan.Text = rdr["jurusan"].ToString();
                            this.LbThnLulus.Text = rdr["tahun_lls"].ToString();

                            this.LbAdik.Text = rdr["adik"].ToString();
                            this.LbKakak.Text = rdr["kakak"].ToString();
                            this.LbNamaAyah.Text = rdr["father_name"].ToString();
                            this.LbNamaIbu.Text = rdr["mother_name"].ToString();
                            this.LbPendidikanAyah.Text = rdr["pendidikan_ayah"].ToString();
                            this.LbPendidikanIbu.Text = rdr["pendidikan_ibu"].ToString();
                            this.LbPekerjaanAyah.Text = rdr["pekerjaan_ayah"].ToString();
                            this.LbPekerjaanIbu.Text = rdr["pekerjaan_ibu"].ToString();
                            this.LbPenghasilan.Text = rdr["penghasilan"].ToString();

                            this.LbPilihanI.Text = rdr["pilihan_1"].ToString();
                            this.LbPilihanII.Text = rdr["pilihan_2"].ToString();

                            this.LbNoTagihan.Text = this.TbCari.Text;
                        }
                    }
                }
                CmdBiodata.Dispose();

                // LihatFoto(this.Session["Name"].ToString());

            }
        }

        protected void BtnProses_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                //SqlTransaction trans = con.BeginTransaction();

                SqlCommand CmdGagalBerkas = new SqlCommand("SpInsertGagalBerkas", con);
                //CmdPeriodik.Transaction = trans;
                CmdGagalBerkas.CommandType = System.Data.CommandType.StoredProcedure;
                CmdGagalBerkas.Parameters.AddWithValue("@no_tagihan", LbNoTagihan.Text);

                CmdGagalBerkas.ExecuteNonQuery();

                this.LbKeterangan.Text = "Proses Berhasil";
                this.LbKeterangan.ForeColor = System.Drawing.Color.Green;

                this.LbNoTagihan.Text = "";

                this.PanelDetailPendaftar.Enabled = false;
                this.PanelDetailPendaftar.Visible = false;
            }
        }
    }
}