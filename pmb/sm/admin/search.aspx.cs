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
    public partial class WebForm2 : pmb_login
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
                this.PanelDetailPendaftar.Enabled = false;
                this.PanelDetailPendaftar.Visible = false;
            }
        }
        // Search User Account
        protected void Button1_Click(object sender, EventArgs e)
        {
            //-- validasi --
            if (this.TbCari.Text == "")
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('Input No tagihan atau Nama Pendaftar');", true);
                return;
            }

            this.PanelDetailPendaftar.Enabled = false;
            this.PanelDetailPendaftar.Visible = false;

            // ----------------------------Lihat Hasil Pencarian------------------------------------------------
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                // ---------------------- Cari Pendaftar ---------------------------------
                SqlCommand CmdCari = new SqlCommand("SpCariPendaftar2", con);
                CmdCari.CommandType = System.Data.CommandType.StoredProcedure;

                CmdCari.Parameters.AddWithValue("@var", this.TbCari.Text);

                DataTable TblPendaftr = new DataTable();
                TblPendaftr.Columns.Add("Nomor Tagihan/Jurnal");
                TblPendaftr.Columns.Add("Nama");


                using (SqlDataReader rdr = CmdCari.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            DataRow datarow = TblPendaftr.NewRow();
                            datarow["Nomor Tagihan/Jurnal"] = rdr["no_tagihan"];
                            datarow["Nama"] = rdr["nama"];

                            TblPendaftr.Rows.Add(datarow);
                        }

                        //Fill Gridview
                        this.GVDaftar.DataSource = TblPendaftr;
                        this.GVDaftar.DataBind();

                    }
                    else
                    {
                        //clear Gridview
                        TblPendaftr.Rows.Clear();
                        TblPendaftr.Clear();
                        this.GVDaftar.DataSource = TblPendaftr;
                        this.GVDaftar.DataBind();
                    }
                }

                CmdCari.Dispose();
            }
        }

        protected void LihatFoto(string no_tagihan)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no_tagihan,foto from smuntidar_foto where no_tagihan=@no_tagihan", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", no_tagihan); // this.Session["Name"].ToString());
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Byte[] bytes = (Byte[])reader["foto"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            Image1.ImageUrl = "data:image/png;base64," + base64String;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Image found.");
                    }
                    reader.Close();
                    //======================== END READER =========================
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void GVDaftar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GVDaftar.SelectedRow;

            // Display the first name from the selected row.
            // In this example, the third column (index 1) contains
            // the first name.
            this.Label11.Text = "Nomor Tagihan : " + row.Cells[1].Text ;


            this.PanelDetailPendaftar.Enabled = true;
            this.PanelDetailPendaftar.Visible = true;

            //-----------------------------------Keterangan Biodata -----------------------------------------------
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                //SqlTransaction trans = con.BeginTransaction();

                SqlCommand CmdBiodata = new SqlCommand("SpBiodataPendaftar", con);
                //CmdPeriodik.Transaction = trans;
                CmdBiodata.CommandType = System.Data.CommandType.StoredProcedure;

                CmdBiodata.Parameters.AddWithValue("@no_tagihan", row.Cells[1].Text);
                // CmdBiodata.Parameters.AddWithValue("@no_tagihan", this.GVPendaftar.SelectedRow.Cells[1].Text);

                using (SqlDataReader rdr = CmdBiodata.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
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
                        }
                    }
                }
                CmdBiodata.Dispose();

                // LihatFoto(this.Session["Name"].ToString());

                // ----------------- Nilai Akhir ---------------------------------
                SqlCommand cmdNilaiAkhir = new SqlCommand("SpNilaiAkhir", con);
                cmdNilaiAkhir.CommandType = System.Data.CommandType.StoredProcedure;

                cmdNilaiAkhir.Parameters.AddWithValue("@no_tagihan", row.Cells[1].Text);


                using (SqlDataReader rdr = cmdNilaiAkhir.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            this.LbNilai.Text = rdr["nilai"].ToString();
                        }

                    }
                    else
                    {
                        //Nilai Tidak ditemukan
                    }
                }

                cmdNilaiAkhir.Dispose();
            }

        }

    }
}