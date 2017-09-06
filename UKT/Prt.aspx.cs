using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace UKT
{
    public partial class Prt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    //SqlDataAdapter da = new SqlDataAdapter("SpDetailDataUKT", con);
                    //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ////ndf ==> Nomor Pendaftaran
                    //da.SelectCommand.Parameters.Add("@no_daftar", SqlDbType.Text).Value = Convert.ToString(Request.QueryString["ndf"]);
                    //DataSet ds = new DataSet();

                    //da.Fill(ds);
                    //this.RepeaterDataUKT.DataSource = ds;
                    //this.RepeaterDataUKT.DataBind();


                    con.Open();
                    SqlCommand cmd = new SqlCommand("SpDetailDataUKT", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@no_daftar", Convert.ToString(Request.QueryString["ndf"]));

                    DataTable TableData = new DataTable();
                    TableData.Columns.Add("NoDaftar");
                    TableData.Columns.Add("nama");
                    TableData.Columns.Add("gender");
                    TableData.Columns.Add("alamat");
                    TableData.Columns.Add("tglahir");
                    TableData.Columns.Add("hp");
                    TableData.Columns.Add("ayah");
                    TableData.Columns.Add("ibu");
                    TableData.Columns.Add("pdayah");
                    TableData.Columns.Add("pdibu");
                    TableData.Columns.Add("dylistrik");
                    TableData.Columns.Add("bylistrik");
                    TableData.Columns.Add("sbair");
                    TableData.Columns.Add("byair");
                    TableData.Columns.Add("lstanah");
                    TableData.Columns.Add("lsbangunan");
                    TableData.Columns.Add("atap");
                    TableData.Columns.Add("lantai");
                    TableData.Columns.Add("rgtenngah");
                    TableData.Columns.Add("dpr");
                    TableData.Columns.Add("cuci");
                    TableData.Columns.Add("lstaman");
                    TableData.Columns.Add("garasi");
                    TableData.Columns.Add("jlnmasuk");
                    TableData.Columns.Add("bytelphp");
                    TableData.Columns.Add("byint");
                    TableData.Columns.Add("pdptayah");
                    TableData.Columns.Add("pdptibu");
                    TableData.Columns.Add("htng");
                    TableData.Columns.Add("sawah");
                    TableData.Columns.Add("tanah");
                    TableData.Columns.Add("ternak");
                    TableData.Columns.Add("mobil");
                    TableData.Columns.Add("hiasan");
                    TableData.Columns.Add("sepeda");
                    TableData.Columns.Add("kk");
                    TableData.Columns.Add("FtRumah");
                    TableData.Columns.Add("penghasilan");
                    TableData.Columns.Add("listrik");
                    TableData.Columns.Add("stnk");
                    TableData.Columns.Add("air");
                    TableData.Columns.Add("telp");

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableData.NewRow();
                                datarow["NoDaftar"] = rdr["no_daftar"];
                                datarow["nama"] = rdr["nama"];
                                datarow["gender"] = rdr["gender"];
                                datarow["alamat"] = rdr["alamat"];
                                //datarow["tglahir"] = rdr["tglahir"];
                                datarow["tglahir"] = Convert.ToDateTime(rdr["tglahir"]).ToString("dd-MMMM-yyyy");
                                datarow["hp"] = rdr["hp"];
                                datarow["ayah"] = rdr["ayah"];
                                datarow["ibu"] = rdr["ibu"];
                                datarow["pdayah"] = rdr["pdayah"];
                                datarow["pdibu"] = rdr["pdibu"];
                                datarow["dylistrik"] = rdr["dylistrik"];
                                datarow["bylistrik"] = rdr["bylistrik"];
                                datarow["sbair"] = rdr["sbair"];
                                datarow["byair"] = rdr["byair"];
                                datarow["lstanah"] = rdr["lstanah"];
                                datarow["lsbangunan"] = rdr["lsbangunan"];
                                datarow["atap"] = rdr["atap"];
                                datarow["lantai"] = rdr["lantai"];
                                datarow["rgtenngah"] = rdr["rgtenngah"];
                                datarow["dpr"] = rdr["dpr"];
                                datarow["cuci"] = rdr["cuci"];
                                datarow["lstaman"] = rdr["lstaman"];
                                datarow["garasi"] = rdr["garasi"];
                                datarow["jlnmasuk"] = rdr["jlnmasuk"];
                                datarow["bytelphp"] = rdr["bytelphp"];
                                datarow["byint"] = rdr["byint"];
                                datarow["pdptayah"] = rdr["pdptayah"];
                                datarow["pdptibu"] = rdr["pdptibu"];
                                datarow["htng"] = rdr["htng"];
                                datarow["sawah"] = rdr["sawah"];
                                datarow["tanah"] = rdr["tanah"];
                                datarow["ternak"] = rdr["ternak"];
                                datarow["mobil"] = rdr["mobil"];
                                datarow["hiasan"] = rdr["hiasan"];
                                datarow["sepeda"] = rdr["sepeda"];
                                datarow["kk"] = "document/" + rdr["kk"].ToString();
                                datarow["FtRumah"] = "document/" + rdr["ft_dpn_rumah"].ToString();
                                datarow["penghasilan"] = "document/" + rdr["penghasilan"].ToString();
                                
                                if (rdr["listrik"] != DBNull.Value)
                                {
                                    datarow["listrik"] = "document/" + rdr["listrik"].ToString();
                                }
                                else
                                {
                                    //datarow["listrik"] = "";
                                }

                                if (rdr["stnk"] != DBNull.Value)
                                {
                                    datarow["stnk"] = "document/" + rdr["stnk"].ToString();
                                }
                                else
                                {
                                    //datarow["stnk"] = "";
                                }

                                if (rdr["telp"] != DBNull.Value)
                                {
                                    datarow["telp"] = "document/" + rdr["telp"].ToString();
                                }
                                else
                                {
                                    //datarow["telp"] = "";
                                }

                                if (rdr["air"] != DBNull.Value)
                                {
                                    datarow["air"] = "document/" + rdr["air"].ToString();
                                }
                                else
                                {
                                    //datarow["air"] = "";
                                }

                                TableData.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.RepeaterDataUKT.DataSource = TableData;
                            this.RepeaterDataUKT.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
        }
    }
}