using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace smuntidar.user
{
    //public partial class WebForm14 : System.Web.UI.Page
    public partial class WebForm14 : user_login
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

                // ------------------------------------------------------------------------------------

                string CS = ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    // ----------------- Nilai Tiap Semester ---------------------------------
                    SqlCommand cmdNilaiSemester = new SqlCommand("SpViewNilaiRaport", con);
                    cmdNilaiSemester.CommandType = System.Data.CommandType.StoredProcedure;

                    cmdNilaiSemester.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    DataTable TableNilaiSemester = new DataTable();
                    TableNilaiSemester.Columns.Add("Semester");
                    TableNilaiSemester.Columns.Add("Bahasa Indonesia");
                    TableNilaiSemester.Columns.Add("Bahasa Inggris");
                    TableNilaiSemester.Columns.Add("Matematika");


                    using (SqlDataReader rdr = cmdNilaiSemester.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableNilaiSemester.NewRow();
                                datarow["Semester"] = rdr["semester"];
                                datarow["Bahasa Indonesia"] = rdr["BI"];
                                datarow["Bahasa Inggris"] = rdr["BInggris"];
                                datarow["Matematika"] = rdr["Mtk"];

                                TableNilaiSemester.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVNilaiSemester.DataSource = TableNilaiSemester;
                            this.GVNilaiSemester.DataBind();

                        }
                        else
                        {
                            //clear Gridview
                            TableNilaiSemester.Rows.Clear();
                            TableNilaiSemester.Clear();
                            GVNilaiSemester.DataSource = TableNilaiSemester;
                            GVNilaiSemester.DataBind();
                        }
                    }

                    cmdNilaiSemester.Dispose();


                    // ----------------- Nilai Akhir ---------------------------------
                    SqlCommand cmdNilaiAkhir = new SqlCommand("SpNilaiAkhir", con);
                    cmdNilaiAkhir.CommandType = System.Data.CommandType.StoredProcedure;

                    cmdNilaiAkhir.Parameters.AddWithValue("@no_tagihan", this.Session["no_tagihan"].ToString());

                    DataTable TableNilaiAkhir = new DataTable();
                    TableNilaiAkhir.Columns.Add("Bonus Kota/Kabupaten");
                    TableNilaiAkhir.Columns.Add("Bonus Provinsi");
                    TableNilaiAkhir.Columns.Add("Bonus Nasional");
                    TableNilaiAkhir.Columns.Add("Nilai Akhir");


                    using (SqlDataReader rdr = cmdNilaiAkhir.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableNilaiAkhir.NewRow();
                                datarow["Bonus Kota/Kabupaten"] = rdr["bonus_1"];
                                datarow["Bonus Provinsi"] = rdr["bonus_2"];
                                datarow["Bonus Nasional"] = rdr["bonus_3"];
                                datarow["Nilai Akhir"] = rdr["nilai"];

                                TableNilaiAkhir.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.GVNilaiAkhir.DataSource = TableNilaiAkhir;
                            this.GVNilaiAkhir.DataBind();

                        }
                        else
                        {
                            //clear Gridview
                            TableNilaiAkhir.Rows.Clear();
                            TableNilaiAkhir.Clear();
                            GVNilaiAkhir.DataSource = TableNilaiAkhir;
                            GVNilaiAkhir.DataBind();
                        }
                    }

                    cmdNilaiAkhir.Dispose();
                }
            }
        }
    }
}