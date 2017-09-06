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
using System.Net;

namespace pmb.sm
{
    public partial class WebForm10 : pmb_login
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
            this.Session["Name"] = (object)null;
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

        }

        protected void CekBerkas_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "";

            try
            {
                //-----------------------------------Cek Kelenngkapan Berkas -----------------------------------------------
                string CS = ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    //SqlTransaction trans = con.BeginTransaction();

                    SqlCommand CmdBerkas = new SqlCommand("SpCekBerkas", con);
                    //CmdPeriodik.Transaction = trans;
                    CmdBerkas.CommandType = System.Data.CommandType.StoredProcedure;

                    CmdBerkas.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);

                    SqlParameter OutNama = new SqlParameter();
                    OutNama.ParameterName = "@nama";
                    OutNama.SqlDbType = System.Data.SqlDbType.VarChar;
                    OutNama.Direction = System.Data.ParameterDirection.Output;
                    OutNama.Size = 50;
                    CmdBerkas.Parameters.Add(OutNama);

                    SqlParameter OutFoto = new SqlParameter();
                    OutFoto.ParameterName = "@cek_foto";
                    OutFoto.SqlDbType = System.Data.SqlDbType.VarChar;
                    OutFoto.Direction = System.Data.ParameterDirection.Output;
                    OutFoto.Size = 5;
                    CmdBerkas.Parameters.Add(OutFoto);

                    SqlParameter raport1 = new SqlParameter();
                    raport1.ParameterName = "@rpt1";
                    raport1.SqlDbType = System.Data.SqlDbType.VarChar;
                    raport1.Direction = System.Data.ParameterDirection.Output;
                    raport1.Size = 300;
                    CmdBerkas.Parameters.Add(raport1);

                    SqlParameter raport2 = new SqlParameter();
                    raport2.ParameterName = "@rpt2";
                    raport2.SqlDbType = System.Data.SqlDbType.VarChar;
                    raport2.Direction = System.Data.ParameterDirection.Output;
                    raport2.Size = 300;
                    CmdBerkas.Parameters.Add(raport2);

                    SqlParameter raport3 = new SqlParameter();
                    raport3.ParameterName = "@rpt3";
                    raport3.SqlDbType = System.Data.SqlDbType.VarChar;
                    raport3.Direction = System.Data.ParameterDirection.Output;
                    raport3.Size = 300;
                    CmdBerkas.Parameters.Add(raport3);

                    SqlParameter raport4 = new SqlParameter();
                    raport4.ParameterName = "@rpt4";
                    raport4.SqlDbType = System.Data.SqlDbType.VarChar;
                    raport4.Direction = System.Data.ParameterDirection.Output;
                    raport4.Size = 300;
                    CmdBerkas.Parameters.Add(raport4);

                    SqlParameter raport5 = new SqlParameter();
                    raport5.ParameterName = "@rpt5";
                    raport5.SqlDbType = System.Data.SqlDbType.VarChar;
                    raport5.Direction = System.Data.ParameterDirection.Output;
                    raport5.Size = 300;
                    CmdBerkas.Parameters.Add(raport5);

                    SqlParameter bonus1 = new SqlParameter();
                    bonus1.ParameterName = "@bonus1";
                    bonus1.SqlDbType = System.Data.SqlDbType.VarChar;
                    bonus1.Direction = System.Data.ParameterDirection.Output;
                    bonus1.Size = 200;
                    CmdBerkas.Parameters.Add(bonus1);

                    SqlParameter bonus2 = new SqlParameter();
                    bonus2.ParameterName = "@bonus2";
                    bonus2.SqlDbType = System.Data.SqlDbType.VarChar;
                    bonus2.Direction = System.Data.ParameterDirection.Output;
                    bonus2.Size = 200;
                    CmdBerkas.Parameters.Add(bonus2);

                    SqlParameter bonus3 = new SqlParameter();
                    bonus3.ParameterName = "@bonus3";
                    bonus3.SqlDbType = System.Data.SqlDbType.VarChar;
                    bonus3.Direction = System.Data.ParameterDirection.Output;
                    bonus3.Size = 200;
                    CmdBerkas.Parameters.Add(bonus3);


                    CmdBerkas.ExecuteNonQuery();

                    if (OutNama.Value.ToString() != "")
                    {
                        this.LbNama.Text = OutNama.Value.ToString();
                    }

                    if (OutFoto.Value.ToString() == "ok")
                    {
                        this.LbFoto.Text = "Berkas Foto Ada";
                        LbFoto.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbFoto.Text = "Berkas Foto Tidak Ada";
                        LbFoto.ForeColor = System.Drawing.Color.Red;
                    }

                    if (raport1.Value.ToString() != "")
                    {
                        this.LbRpt1.Text = "Berkas Raport Semester 1 Ada";
                        LbRpt1.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbRpt1.Text = " Berkas Raport Semester 1 Tidak Ada";
                        LbRpt1.ForeColor = System.Drawing.Color.Red;
                    }
                    if (raport2.Value.ToString() != "")
                    {
                        this.LbRpt2.Text = "Berkas Raport Semester 2 Ada";
                        LbRpt2.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbRpt2.Text = "Berkas Raport Semester 2 Tidak Ada";
                        LbRpt2.ForeColor = System.Drawing.Color.Red;
                    }

                    if (raport3.Value.ToString() != "")
                    {
                        this.LbRpt3.Text = "Berkas Raport Semester 3 Ada";
                        LbRpt3.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbRpt3.Text = "Berkas Raport Semester 3 Tidak Ada";
                        LbRpt3.ForeColor = System.Drawing.Color.Red;
                    }

                    if (raport4.Value.ToString() != "")
                    {
                        this.LbRpt4.Text = "Berkas Raport Semester 4 Ada";
                        LbRpt4.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbRpt4.Text = "Berkas Raport Semester 4 Tidak Ada";
                        LbRpt4.ForeColor = System.Drawing.Color.Red;
                    }

                    if (raport5.Value.ToString() != "")
                    {
                        this.LbRpt5.Text = "Berkas Raport Semester 5 Ada";
                        LbRpt5.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbRpt5.Text = "Berkas Raport Semester 5 Tidak Ada";
                        LbRpt5.ForeColor = System.Drawing.Color.Red;
                    }

                    if (bonus1.Value.ToString() != "")
                    {
                        this.LbKota.Text = "Berkas Prestasi Kota/Kabupaten Ada";
                        LbKota.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbKota.Text = "Berkas Prestasi Kota/Kabupaten Tidak Ada";
                        LbKota.ForeColor = System.Drawing.Color.Red;
                    }

                    if (bonus2.Value.ToString() != "")
                    {
                        this.LbProv.Text = "Berkas Prestasi Provinsi Ada";
                        LbProv.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbProv.Text = "Berkas Prestasi Provinsi Tidak Ada";
                        LbProv.ForeColor = System.Drawing.Color.Red;
                    }

                    if (bonus3.Value.ToString() != "")
                    {
                        this.LbNasional.Text = "Berkas Prestasi Nasional Ada";
                        LbNasional.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LbNasional.Text = "Berkas Prestasi Nasional Tidak Ada";
                        LbNasional.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void LihatFoto(string no_tagihan, string semester)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no, raport from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", no_tagihan); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", semester);
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Byte[] bytes = (Byte[])reader["raport"];
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

        protected void LihatFoto2(string no_tagihan, string semester)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    //========================== READER IMAGE FROM DB =========================
                    SqlCommand CmdDisplay = new SqlCommand("select no, path from smuntidar_raport where no_tagihan=@no_tagihan and semester=@semester", connection);
                    CmdDisplay.Parameters.AddWithValue("@no_tagihan", no_tagihan); // this.Session["Name"].ToString());
                    CmdDisplay.Parameters.AddWithValue("@semester", semester);
                    SqlDataReader reader = CmdDisplay.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //------------ read on real server ---------------
                            try
                            {
                                Response.Write(reader["path"].ToString());

                                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://sm.untidar.ac.id/rpt/" + reader["path"].ToString());
                                req.AllowAutoRedirect = false;
                                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                if (res.StatusCode == HttpStatusCode.OK)
                                {
                                    Image1.ImageUrl = "http://sm.untidar.ac.id/rpt/" + reader["path"].ToString();
                                }
                            }
                            catch (Exception)
                            {
                                Image1.ImageUrl = "";
                                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                            }

                            //------------ read on local server ---------------
                            try
                            {
                                //if (Image1.ImageUrl == "")
                                //{
                                //    HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/smuntidar/rpt/" + reader["path"].ToString());
                                //    req2.AllowAutoRedirect = false;
                                //    HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                                //    if (res2.StatusCode == HttpStatusCode.OK)
                                //    {
                                //        Image1.ImageUrl = "http://localhost/smuntidar/rpt/" + reader["path"].ToString();
                                //    }
                                //    else
                                //    {
                                //        Image1.ImageUrl = "";
                                //    }
                                //}
                            }
                            catch (Exception ex)
                            {
                                Image1.ImageUrl = "";
                                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine("No Image found.");
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

        protected void LihatFotoPres(string no_tagihan, string prestasi)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    if (prestasi == "KOTA")
                    {
                        //========================== READER IMAGE FROM DB =========================
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, img_bonus_1 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);
                        SqlDataReader reader = CmdDisplay.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Byte[] bytes = (Byte[])reader["img_bonus_1"];
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
                    else if (prestasi == "PROV")
                    {
                        //========================== READER IMAGE FROM DB =========================
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, img_bonus_2 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);
                        SqlDataReader reader = CmdDisplay.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Byte[] bytes = (Byte[])reader["img_bonus_2"];
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
                    else if (prestasi == "NAS")
                    {
                        //========================== READER IMAGE FROM DB =========================
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, img_bonus_3 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);
                        SqlDataReader reader = CmdDisplay.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Byte[] bytes = (Byte[])reader["img_bonus_3"];
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
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void LihatFotoPres2(string no_tagihan, string prestasi)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sm-untidar"].ConnectionString))
            {
                try
                {
                    connection.Open();

                    if (prestasi == "KOTA")
                    {
                        //========================== READER IMAGE FROM DB =========================
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, pth_bns1 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);
                        SqlDataReader reader = CmdDisplay.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //------------ read on real server ---------------
                                try
                                {
                                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://sm.untidar.ac.id/pres/" + reader["pth_bns1"].ToString());
                                    req.AllowAutoRedirect = false;
                                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                    if (res.StatusCode == HttpStatusCode.OK)
                                    {
                                        Image1.ImageUrl = "http://sm.untidar.ac.id/pres/" + reader["pth_bns1"].ToString();
                                    }
                                }
                                catch (Exception)
                                {
                                    Image1.ImageUrl = "";
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }

                                //------------Jika tidak ditemukan ==> read on local server ---------------
                                try
                                {
                                    if (Image1.ImageUrl == "")
                                    {
                                        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/smuntidar/pres/" + reader["pth_bns1"].ToString());
                                        req2.AllowAutoRedirect = false;
                                        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                                        if (res2.StatusCode == HttpStatusCode.OK)
                                        {
                                            Image1.ImageUrl = "http://localhost/smuntidar/pres/" + reader["pth_bns1"].ToString();
                                        }
                                        else
                                        {
                                            Image1.ImageUrl = "";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Image1.ImageUrl = "";
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Image found.");
                        }
                        reader.Close();
                        //======================== END READER =========================
                    }
                    else if (prestasi == "PROV")
                    {
                        //========================== READER IMAGE FROM DB =========================
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, pth_bns2 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);
                        SqlDataReader reader = CmdDisplay.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //------------ read on real server ---------------
                                try
                                {
                                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://sm.untidar.ac.id/pres/" + reader["pth_bns2"].ToString());
                                    req.AllowAutoRedirect = false;
                                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                    if (res.StatusCode == HttpStatusCode.OK)
                                    {
                                        Image1.ImageUrl = "http://sm.untidar.ac.id/pres/" + reader["pth_bns2"].ToString();
                                    }
                                }
                                catch (Exception)
                                {
                                    Image1.ImageUrl = "";
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }

                                //------------Jika tidak ditemukan ==> read on local server ---------------
                                try
                                {
                                    if (Image1.ImageUrl == "")
                                    {
                                        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/smuntidar/pres/" + reader["pth_bns2"].ToString());
                                        req2.AllowAutoRedirect = false;
                                        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                                        if (res2.StatusCode == HttpStatusCode.OK)
                                        {
                                            Image1.ImageUrl = "http://localhost/smuntidar/pres/" + reader["pth_bns2"].ToString();
                                        }
                                        else
                                        {
                                            Image1.ImageUrl = "";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Image1.ImageUrl = "";
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Image found.");
                        }
                        reader.Close();
                        //======================== END READER =========================
                    }
                    else if (prestasi == "NAS")
                    {
                        //========================== READER IMAGE FROM DB =========================
                        SqlCommand CmdDisplay = new SqlCommand("select no_tagihan, pth_bns3 from smuntidar_nilai where no_tagihan=@no_tagihan", connection);
                        CmdDisplay.Parameters.AddWithValue("@no_tagihan", this.TbNoTagihan.Text);
                        SqlDataReader reader = CmdDisplay.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //------------ read on real server ---------------
                                try
                                {
                                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://sm.untidar.ac.id/pres/" + reader["pth_bns3"].ToString());
                                    req.AllowAutoRedirect = false;
                                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                                    if (res.StatusCode == HttpStatusCode.OK)
                                    {
                                    Image1.ImageUrl = "http://sm.untidar.ac.id/pres/" + reader["pth_bns3"].ToString();
                                    }
                                }
                                catch (Exception)
                                {
                                    Image1.ImageUrl = "";
                                    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }

                                //------------Jika tidak ditemukan ==> read on local server ---------------
                                try
                                {
                                    if (Image1.ImageUrl == "")
                                    {
                                        HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create("http://localhost/smuntidar/pres/" + reader["pth_bns3"].ToString());
                                        req2.AllowAutoRedirect = false;
                                        HttpWebResponse res2 = (HttpWebResponse)req2.GetResponse();

                                        if (res2.StatusCode == HttpStatusCode.OK)
                                        {
                                            Image1.ImageUrl = "http://localhost/smuntidar/pres/" + reader["pth_bns3"].ToString();
                                        }
                                        else
                                        {
                                            Image1.ImageUrl = "";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Image1.ImageUrl = "";
                                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Image found.");
                        }
                        reader.Close();
                        //======================== END READER =========================
                    }
                }
                catch (Exception ex)
                {
                    Image1.ImageUrl = null;
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ex", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }

        protected void BtnSms1_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.TbNoTagihan.Text, "1");
            LblSemester.Text = " Raport Semester 1 (Satu)";
        }

        protected void BtnSms2_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.TbNoTagihan.Text, "2");
            LblSemester.Text = " Raport Semester 2 (Dua)";
        }

        protected void BtnSms3_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.TbNoTagihan.Text, "3");
            LblSemester.Text = " Raport Semester 3 (Tiga)";
        }

        protected void BtnSms4_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.TbNoTagihan.Text, "4");
            LblSemester.Text = " Raport Semester 4 (Empat)";
        }

        protected void BtnSms5_Click(object sender, EventArgs e)
        {
            LihatFoto2(this.TbNoTagihan.Text, "5");
            LblSemester.Text = " Raport Semester 5 (Empat)";
        }

        protected void BtnPresKota_Click(object sender, EventArgs e)
        {
            LihatFotoPres2(this.TbNoTagihan.Text, "KOTA");
            LblSemester.Text = "Tingkat Kota/Kabupaten";
        }

        protected void BtnPresProv_Click(object sender, EventArgs e)
        {
            LihatFotoPres2(this.TbNoTagihan.Text, "PROV");
            LblSemester.Text = "Tingkat Provinsi";
        }

        protected void BtnPresNas_Click(object sender, EventArgs e)
        {
            LihatFotoPres2(this.TbNoTagihan.Text, "NAS");
            LblSemester.Text = "Tingkat Nasional";
        }
    }
}