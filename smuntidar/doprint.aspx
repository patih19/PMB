<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doprint.aspx.cs" Inherits="smuntidar.doprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" /> 
    <link href="css/boots.css" rel="stylesheet" type="text/css" />
    <link href="css/header.css" rel="stylesheet" type="text/css" />
    <link href="css/keuangan.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-2.1.3.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        window.print();
    </script>
    <script type="text/javascript">
            function fixform() {
                if (opener.document.getElementById("aspnetForm").target != "_blank") return;
                opener.document.getElementById("aspnetForm").target = "";
                opener.document.getElementById("aspnetForm").action = opener.location.href;
            }
    </script>
    <style>
        table, th, td
        {
            border: 1px solid black;
            border-collapse : collapse;
        }
    </style>
    <style type="text/css">
        .style3
        {
            font-size: 14px;
        }
    </style>
</head>
<body onload="fixform()">
    <form id="form1" runat="server">
    <div>
        <div class="container top-atas" style="background-color: #F2F2FF;">
            <div class="row">
                <div class=" col-lg-12 col-md-10 col-xs-10">
                    <br />
                    <br />
                    <table class="table-condensed table-bordered" align="center">
                        <tr>
                            <td class="style3" style="background-color: #C1E0FF">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Logo-Untidar-96.png" 
                                    Width="96px" /> 
                            </td>
                            <td class="style3" colspan="2" style="background-color: #C1E0FF">
                                <strong>NO PENDAFTARAN &amp; BIAYA PENDAFTARAN<br />
                                SELEKSI MASUK UNIVERSITAS TIDAR<br />
                                TAHUN 2015/2016</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>No.
                                Pendaftaran</strong>
                            </td>
                            <td>
                                :
                                <asp:Label ID="LbNoDaftar" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>Nama Peserta </strong>
                            </td>
                            <td>
                                : 
                                <asp:Label ID="LbNama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <strong>Biaya Seleksi  </strong>
                            </td>
                            <td>
                               :
                                <asp:Label ID="Label3" runat="server" Style="font-weight: 700" Text="Rp. 200.000"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <!-- ===================  Informasi Bayar ================== -->
                    Pembayaran pendaftaran SM-UNTIDAR tahun 2015/2016 dilakukan dengan cara berikut :<br />
                    <ol>
                        <li style="direction: ltr">Tunjukkan formulir ini kepada Teller Bank Jateng untuk membayar
                            biaya pendaftaran</li>
                        <li>Teller akan menukarnya dengan PIN pendaftaran</li>
                    </ol>
                    Login menggunakan No. Pendaftaran dan PIN untuk mengisi form pendaftaran SM-UNTIDAR<em> (http://sm.untidar.ac.id)</em><br />
                    <br />
                    <!-- <asp:Button ID="BtnDownload" runat="server" OnClick="BtnDownload_Click" Text="Download" /> -->
                </div>
                <!-- End Content -->
            </div>
            <!-- End Row -->
        </div>
    </div>
    </form>

    </body>
</html>
