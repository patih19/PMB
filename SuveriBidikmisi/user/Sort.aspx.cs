using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SuveriBidikmisi
{
    public partial class Sort : SuveriBidikmisi.user.user
    {
        public string NPM { get { return this.LbNPM.Text.Trim(); } }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                HtmlGenericControl control = (HtmlGenericControl)base.Master.FindControl("NavNilai");
                control.Attributes.Add("class", "dropdown active opened");
                HtmlGenericControl control2 = (HtmlGenericControl)base.Master.FindControl("NavExample");
                control2.Attributes.Add("style", "display: none;");

                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand command = new SqlCommand("SpUKTReadNilaiAkhirBidikmisi", con);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    DataTable Table = new DataTable();
                    Table.Columns.Add("No");
                    Table.Columns.Add("NPM");
                    Table.Columns.Add("Nama");
                    Table.Columns.Add("Nilai");
                    //Table.Columns.Add("Jalur");
                    //Table.Columns.Add("Lolos");
                    Table.Columns.Add("Tahun");
                    con.Open();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = Table.NewRow();
                                datarow["No"] = rdr["nomor"];
                                datarow["NPM"] = rdr["npm"];
                                datarow["Nama"] = rdr["nama"].ToString().ToUpper(); ;
                                datarow["Nilai"] = rdr["Point"];
                                datarow["Tahun"] = rdr["thn_angkatan"];

                                Table.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVCekInput.DataSource = Table;
                            this.GVCekInput.DataBind();

                            Table.Dispose();
                        }
                        else
                        {
                            //clear Gridview
                            Table.Rows.Clear();
                            Table.Clear();
                            GVCekInput.DataSource = Table;
                            GVCekInput.DataBind();
                        }
                    }
                }

                //-- hitung lolos --
                HitungLolos();
            }
        }

        protected void GVCekInput_PreRender(object sender, EventArgs e)
        {
            if (this.GVCekInput.Rows.Count > 0)
            {
                // this replace <td> with <th> and add the scope attribute
                GVCekInput.UseAccessibleHeader = true;

                //this will add the <thead> and <tbody> elements
                GVCekInput.HeaderRow.TableSection = TableRowSection.TableHeader;

                //this adds the <tfoot> element
                //remove if you don't have a footer row
                //GVJadwal.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            this.LbNPM.Text=this.GVCekInput.Rows[index].Cells[1].Text.ToString().Trim();

            Server.Transfer("~/user/DataBorang.aspx");

            //this.GVCekInput.Rows[index].Cells[1].Text.Trim();
            //Response.Redirect("~/user/pribadi.aspx?npm=" + this.GVCekInput.Rows[index].Cells[1].Text.Trim() + "");
        }

        protected void GVCekInput_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            List<TableCell> columns = new List<TableCell>();

            foreach (DataControlField column in this.GVCekInput.Columns)
            {
                TableCell cell = row.Cells[0];
                row.Cells.Remove(cell);
                columns.Add(cell);
            }

            row.Cells.AddRange(columns.ToArray());
        }

        protected void RBLolos_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            //Response.Write(this.GVCekInput.Rows[index].Cells[0].Text.Trim());

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ukt_nilai_bm (npm,nilai,lolos) VALUES (@npm,@nilai,1)", con);
                command.CommandType = System.Data.CommandType.Text;

                command.Parameters.AddWithValue("@npm", this.GVCekInput.Rows[index].Cells[1].Text.Trim());
                command.Parameters.AddWithValue("@nilai", this.GVCekInput.Rows[index].Cells[3].Text.Trim());

                command.ExecuteNonQuery();
            }

            HitungLolos();

            Page_Load(this, null);
        }

        protected void RbTidak_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow GvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = GvRow.RowIndex;

            //Response.Write(this.GVCekInput.Rows[index].Cells[0].Text.Trim());

            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand command = new SqlCommand("DELETE FROM ukt_nilai_bm WHERE npm=@npm", con);
                command.CommandType = System.Data.CommandType.Text;

                command.Parameters.AddWithValue("@npm", this.GVCekInput.Rows[index].Cells[1].Text.Trim());

                command.ExecuteNonQuery();
            }

            HitungLolos();

            Page_Load(this, null);
        }

        protected void GVCekInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM "+ 
                                                        "( "+
	                                                        "SELECT Mhs.npm,Mhs.nama,Mhs.thn_angkatan,Survei.lolos "+
	                                                        "FROM "+
	                                                        "( "+
		                                                        "SELECT        UntidarDb.dbo.bak_mahasiswa.npm, UntidarDb.dbo.bak_mahasiswa.nama,UntidarDb.dbo.bak_mahasiswa.gelombang,bak_mahasiswa.bdk, SbTemp.reg AS reg_sbmptn, SnmptnTemp.reg AS reg_snmptn, PmdkDiplomaTemp.reg AS reg_pmdk, SMMTemp.reg as reg_smuntidar, bak_mahasiswa.thn_angkatan  "+
		                                                        "FROM            UntidarDb.dbo.bak_mahasiswa LEFT OUTER JOIN  "+
										                                                        "SbTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SbTemp.kd_peserta LEFT OUTER JOIN "+ 
									                                                        "PmdkDiplomaTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = PmdkDiplomaTemp.no_pendaftar LEFT OUTER JOIN  "+
									                                                        "SnmptnTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SnmptnTemp.nomor_pendaftaran LEFT OUTER JOIN "+ 
									                                                        "SMMTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SMMTemp.no_pendaftar "+ 
		                                                       "WHERE bak_mahasiswa.thn_angkatan=(SELECT TOP 1 thn_angkatan FROM UntidarDb.dbo.bak_mahasiswa GROUP BY thn_angkatan ORDER BY thn_angkatan DESC ) and (bak_mahasiswa.bdk = 1)  AND (UntidarDb.dbo.bak_mahasiswa.status='A')  "+
				                                                      " and((SbTemp.reg = 'datang') or  (SnmptnTemp.reg ='datang') or  (PmdkDiplomaTemp.reg ='datang') or( SMMTemp.reg ='datang'))  "+
	                                                        ") AS Mhs "+ 
	                                                        "LEFT OUTER JOIN  "+
	                                                        "(  "+
		                                                        "SELECT npm, nilai, lolos FROM ukt_nilai_bm	 "+
	                                                        ") AS Survei "+ 
	                                                        "ON	Survei.npm = Mhs.npm "+
                                                        ") AS LIST WHERE LIST.npm=@npm", con);
                    command.CommandType = System.Data.CommandType.Text;
                    command.Parameters.AddWithValue("@npm", e.Row.Cells[1].Text.Trim());

                    con.Open();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                if (rdr["lolos"] == DBNull.Value)
                                {
                                    RadioButton RbLolos = (RadioButton)e.Row.Cells[5].FindControl("RbLolos");
                                    RadioButton RbTidakLolos = (RadioButton)e.Row.Cells[5].FindControl("RbTidak");
                                    RbLolos.Checked = false;
                                    RbTidakLolos.Checked = true;
                                }
                                else if (rdr["lolos"].ToString().Trim() == "0")
                                {
                                    RadioButton RbLolos = (RadioButton)e.Row.Cells[5].FindControl("RbLolos");
                                    RadioButton RbTidakLolos = (RadioButton)e.Row.Cells[5].FindControl("RbTidak");
                                    RbLolos.Checked = false;
                                    RbTidakLolos.Checked = true;
                                }
                                else if (rdr["lolos"].ToString().Trim() == "1")
                                {
                                    RadioButton RbLolos = (RadioButton)e.Row.Cells[5].FindControl("RbLolos");
                                    RadioButton RbTidakLolos = (RadioButton)e.Row.Cells[5].FindControl("RbTidak");
                                    RbLolos.Checked = true;
                                    RbTidakLolos.Checked = false;
                                }
                            }

                        } else
                        {

                        }
                    }
                }
            }
        }

        protected void HitungLolos()
        {
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand CmdLolos = new SqlCommand("SELECT COUNT(lolos) AS JumlahLolos FROM " +
                                                    "( " +
                                                        "SELECT Mhs.npm,Mhs.nama,Mhs.thn_angkatan,Survei.lolos " +
                                                        "FROM " +
                                                        "( " +
                                                            "SELECT        UntidarDb.dbo.bak_mahasiswa.npm, UntidarDb.dbo.bak_mahasiswa.nama,UntidarDb.dbo.bak_mahasiswa.gelombang,bak_mahasiswa.bdk, SbTemp.reg AS reg_sbmptn, SnmptnTemp.reg AS reg_snmptn, PmdkDiplomaTemp.reg AS reg_pmdk, SMMTemp.reg as reg_smuntidar, bak_mahasiswa.thn_angkatan " +
                                                            "FROM            UntidarDb.dbo.bak_mahasiswa LEFT OUTER JOIN " +
                                                                                            "SbTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SbTemp.kd_peserta LEFT OUTER JOIN  " +
                                                                                        "PmdkDiplomaTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = PmdkDiplomaTemp.no_pendaftar LEFT OUTER JOIN  " +
                                                                                        "SnmptnTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SnmptnTemp.nomor_pendaftaran LEFT OUTER JOIN " +
                                                                                        "SMMTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SMMTemp.no_pendaftar  " +
                                                            "WHERE bak_mahasiswa.thn_angkatan=(SELECT TOP 1 thn_angkatan FROM UntidarDb.dbo.bak_mahasiswa GROUP BY thn_angkatan ORDER BY thn_angkatan DESC ) and (bak_mahasiswa.bdk = 1)  AND (UntidarDb.dbo.bak_mahasiswa.status='A') " +
                                                                    "and((SbTemp.reg = 'datang') or  (SnmptnTemp.reg ='datang') or  (PmdkDiplomaTemp.reg ='datang') or( SMMTemp.reg ='datang'))  " +
                                                        ") AS Mhs  " +
                                                        "LEFT OUTER JOIN  " +
                                                        "(  " +
                                                            "SELECT npm, nilai, lolos FROM ukt_nilai_bm	 " +
                                                        ") AS Survei " +
                                                        "ON	Survei.npm = Mhs.npm " +
                                                    ") AS LIST WHERE LIST.lolos = 1", con);
                CmdLolos.CommandType = System.Data.CommandType.Text;

                con.Open();
                using (SqlDataReader rdr = CmdLolos.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            this.LbLolos.Text = rdr["JumlahLolos"].ToString().Trim();
                        }
                    }
                }


                //SqlCommand CmdSurvey = new SqlCommand("SELECT COUNT(npm) AS JumlahLolos FROM " +
                //                    "( " +
                //                        "SELECT Mhs.npm,Mhs.nama,Mhs.thn_angkatan,Survei.lolos " +
                //                        "FROM " +
                //                        "( " +
                //                            "SELECT        UntidarDb.dbo.bak_mahasiswa.npm, UntidarDb.dbo.bak_mahasiswa.nama,UntidarDb.dbo.bak_mahasiswa.gelombang,bak_mahasiswa.bdk, SbTemp.reg AS reg_sbmptn, SnmptnTemp.reg AS reg_snmptn, PmdkDiplomaTemp.reg AS reg_pmdk, SMMTemp.reg as reg_smuntidar, bak_mahasiswa.thn_angkatan " +
                //                            "FROM            UntidarDb.dbo.bak_mahasiswa LEFT OUTER JOIN " +
                //                                                            "SbTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SbTemp.kd_peserta LEFT OUTER JOIN  " +
                //                                                        "PmdkDiplomaTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = PmdkDiplomaTemp.no_pendaftar LEFT OUTER JOIN  " +
                //                                                        "SnmptnTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SnmptnTemp.nomor_pendaftaran LEFT OUTER JOIN " +
                //                                                        "SMMTemp ON UntidarDb.dbo.bak_mahasiswa.no_daftar = SMMTemp.no_pendaftar  " +
                //                            "WHERE bak_mahasiswa.thn_angkatan=(SELECT TOP 1 thn_angkatan FROM UntidarDb.dbo.bak_mahasiswa GROUP BY thn_angkatan ORDER BY thn_angkatan DESC ) and (bak_mahasiswa.bdk = 1)  AND (UntidarDb.dbo.bak_mahasiswa.status='A') " +
                //                                    "and((SbTemp.reg = 'datang') or  (SnmptnTemp.reg ='datang') or  (PmdkDiplomaTemp.reg ='datang') or( SMMTemp.reg ='datang'))  " +
                //                        ") AS Mhs  " +
                //                        "LEFT OUTER JOIN  " +
                //                        "(  " +
                //                            "SELECT npm, nilai, lolos FROM ukt_nilai_bm	 " +
                //                        ") AS Survei " +
                //                        "ON	Survei.npm = Mhs.npm " +
                //                    ") AS LIST WHERE LIST.lolos IS NULL", con);
                //CmdSurvey.CommandType = System.Data.CommandType.Text;

                //using (SqlDataReader rdr = CmdSurvey.ExecuteReader())
                //{
                //    if (rdr.HasRows)
                //    {
                //        while (rdr.Read())
                //        {
                //            this.LbSurvey.Text = rdr["JumlahLolos"].ToString().Trim();
                //        }
                //    }
                //}

            }
        }
    }
}