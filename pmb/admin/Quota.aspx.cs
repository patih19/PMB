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
    public partial class WebForm1 : System.Web.UI.Page
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM	dbo.smmuntidar_kuota WHERE thn =(SELECT TOP 1 thn FROM dbo.smmuntidar_kuota ORDER BY thn DESC)", con);
                    cmd.CommandType = System.Data.CommandType.Text;

                    DataTable TableData = new DataTable();
                    TableData.Columns.Add("No");
                    TableData.Columns.Add("Kode Prodi");
                    TableData.Columns.Add("Program Studi");
                    TableData.Columns.Add("Quota");
                    TableData.Columns.Add("Tahun");

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                DataRow datarow = TableData.NewRow();
                                datarow["No"] = rdr["no"];
                                datarow["Kode Prodi"] = rdr["id_prog_study"];
                                datarow["Program Studi"] = rdr["prodi"];
                                datarow["Quota"] = rdr["quota"];
                                datarow["Tahun"] = rdr["thn"];

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

        protected void Button_Click(object sender, EventArgs e)
        {
            //----Get the reference of the clicked button.----
            Button button = (sender as Button);

            //----Get the command argument----
            //string commandArgument = button.CommandArgument; ==> satu parameter

            // ini multi parameter
            string[] CommandArgument = button.CommandArgument.Split(',');
            string No = CommandArgument[0];
            string KodeProdi = CommandArgument[1];
            string Tahun = CommandArgument[2];
            string Quota = CommandArgument[3];

            //---Get the Repeater Item reference ---
            RepeaterItem item = button.NamingContainer as RepeaterItem;
            TextBox QuotaValue = (TextBox)item.FindControl("TbQuota");

            ////Ini loop all texbox value
            //int Total = 0;
            //foreach (RepeaterItem jumlah in this.RepeaterDataUKT.Items)
            //{
            //    TextBox textBox = (TextBox)jumlah.FindControl("TbQuota");
            //    Total = Total + Convert.ToInt16(textBox.Text);
            //}
            //this.LbQuota.Text = Total.ToString();

            //---Get the repeater item index ---
            //int index = item.ItemIndex;

            try
            {
                // ---------- Gridview SKS ------------------
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand CmdQuota = new SqlCommand("UPDATE dbo.smmuntidar_kuota SET quota=@quota WHERE id_prog_study=@idprodi AND thn=@tahun ", con);
                    CmdQuota.CommandType = System.Data.CommandType.Text;
                    CmdQuota.Parameters.AddWithValue("@quota", QuotaValue.Text);
                    CmdQuota.Parameters.AddWithValue("@idprodi", KodeProdi);
                    CmdQuota.Parameters.AddWithValue("@tahun", Tahun);

                    CmdQuota.ExecuteNonQuery();
                    
                    //---- refresh -----
                    Page_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }

        protected void RepeaterDataUKT_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {
            //Ini loop all texbox value
            int Total = 0;
            foreach (RepeaterItem jumlah in this.RepeaterDataUKT.Items)
            {
                TextBox textBox = (TextBox)jumlah.FindControl("TbQuota");
                Total = Total + Convert.ToInt16(textBox.Text);
            }
            this.LbQuota.Text = Total.ToString();
        }
    }
}