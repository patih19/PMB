<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UKT.WebForm9" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Portal Login</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1><marquee direction="left" style="color: #003300">PENGISIAN DATA SOSIAL EKONOMI JALUR SM-UNTIDAR TAHUN AKADEMIK 2017/2018 AKAN DIBUKA PADA TANGGAL 18 JULI 2017 PUKUL 20.00 WIB.</marquee></h1>
    <div>
        <section class="container">
            <asp:Image ID="Image1" runat="server" 
            ImageUrl="~/img/Untidar Kemriting.png" />
            <br />
        <br />
            <div class="login">
                <h1>
                    Portal Sosial Ekonomi Mahasiswa Baru Untidar</h1>
                <p>
                    <asp:TextBox ID="TbUser" 
                        placeholder="No.SNMPTN / No.SBMPTN / No.SM-UNTIDAR" runat="server" 
                        Width="300px"></asp:TextBox></p>
                <p>
                    <asp:TextBox ID="TBPasswd" 
                        placeholder="Tgl. Lahir(SNMPTN) / KAP(SBMPTN) / PIN(SM)" runat="server" 
                        TextMode="Password" Width="300px"></asp:TextBox></p>
                <p class="remember_me">
                    <label>
                        <input type="checkbox" name="remember_me" id="Checkbox1">
                        Remember me on this computer
                    </label>
                </p>
                <p class="submit">
                    <asp:Button ID="BtnLogin" runat="server" Text="Login" 
                        onclick="BtnLogin_Click" /></p>
                        <!-- <br />
                        <div class ="remember_me"><strong>Login tanpa menggunakan tanda &quot; - &quot;<br />
                            No. SBMPTN :1152109999, KAP:115554053333</strong></div> -->
                        
            </div>
            <br />
        <asp:Label ID="LbResult" runat="server" ForeColor="#CC3300"></asp:Label>
            <br />
            <div class="login-help">
                <p>
                    Forgot your password? <a href="<%= Page.ResolveUrl("~/Log.aspx") %>">Click here to reset it</a>.</p>
            </div>

        </section>
        <section class="about">
           <!-- <p class="about-links">
                <a href="http://www.cssflow.com/snippets/login-form" target="_parent">View Article</a>
                <a href="http://www.cssflow.com/snippets/login-form.zip" target="_parent">Download</a>
            </p> -->
            <p class="about-author">
                &copy; 2015, TIM IT PUSKOMINFO UNTIDAR
            </p>
                <!-- <a href="http://www.cssflow.com/mit-license" target="_blank">MIT License</a>
                Original PSD by <a href="http://www.premiumpixels.com/freebies/clean-simple-login-form-psd/"
                    target="_blank">Orman Clark</a> -->

        </section>
    </div>
    </form>
</body>
</html>
