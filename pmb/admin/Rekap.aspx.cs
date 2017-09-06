using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace pmb.admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
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
                    SqlCommand cmd = new SqlCommand("SpRekapDiterima", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    DataTable TableData = new DataTable();
                    TableData.Columns.Add("No");
                    TableData.Columns.Add("Program Studi");
                    TableData.Columns.Add("Quota");
                    TableData.Columns.Add("Jumlah");
                    TableData.Columns.Add("Kurang");

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableData.NewRow();
                                datarow["No"] = rdr["nomor"];
                                datarow["Program Studi"] = rdr["terima"];
                                datarow["Quota"] = rdr["quota"];
                                datarow["Jumlah"] = rdr["jumlah"];
                                datarow["Kurang"] = rdr["kurang"];

                                TableData.Rows.Add(datarow);
                            }

                            //Fill Gridview
                            this.RepeaterDiterima.DataSource = TableData;
                            this.RepeaterDiterima.DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                }
            }
        }

        protected void RepeaterDiterima_ItemDataBound(object sender, EventArgs e)
        {
            //Ini loop all texbox value
            int Total = 0;
            foreach (RepeaterItem jumlah in this.RepeaterDiterima.Items)
            {
                Label LbDiterima = (Label)jumlah.FindControl("LbDiterima");
                Total = Total + Convert.ToInt16(LbDiterima.Text);
            }
            this.LbQuotaDiterima.Text = Total.ToString();
        }
    }
}