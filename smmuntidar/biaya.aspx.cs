using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace smmuntidar
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page Lastpage = (Page)Context.Handler;
                if (Lastpage is WebForm2)
                {
                    this.LbNama.Text = ((WebForm2)Lastpage).NamaJateng;
                    this.LbNoDaftar.Text = ((WebForm2)Lastpage).NoPendaftarJateng;
                }
            }
        }

        public string NoDaftar
        {
            get { return this.LbNoDaftar.Text; }
        }
        public string Nama
        {
            get { return this.LbNama.Text; }
        }

        protected void SavePrint_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/doprint.aspx?req=" + this.LbNoDaftar.Text);
            string no_daftar = HttpUtility.UrlEncode(Encrypt(LbNoDaftar.Text.Trim()));
            Response.Redirect(string.Format("~/doprint.aspx?req={0}", no_daftar));
        }

        // Encrypting the QueryString Parameter Values
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "##UniversitasTidar123##";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}