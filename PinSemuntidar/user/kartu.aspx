<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kartu.aspx.cs" Inherits="PinSemuntidar.user.kartu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/css/boots.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: large;
        }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            width: 115px;
            height: 123px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
        <table class="table-bordered" align="center">
            <tr>
                <td>
                    <img alt="" class="style2" src="../images/Logo-Untidar-96.png">
                </td>
                <td class="style2" colspan="3">
                    <strong><span class="style2">Seleksi Masuk Universitas Tidar (SM-UNTIDAR)</span></strong><br />
                    Tahun 2015/2016<br />
                    <strong><span class="style1">*** Kartu Peserta SMM-UNTIDAR 2015 ***</span></strong>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    Nomor :</td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    Identitas
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    Nama
                </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    Gelombang </td>
                <td>
                    &nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table id="sss" style="border: 1px solid">
                        <tr>
                            <td>
                                <br />
                                <br />
                                Cap Jempol Kiri
                                <br />
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td>
                    <br />
                    <br />
                    &nbsp;
                    <img alt="" class="style3" src="../images/default_large.png" /><br />
                    <br />
                    <br />
                    &nbsp;
                    Tanda Tangan
                </td>
                <td style="vertical-align:top">
                    &nbsp; Periode pendaftaran</td>
                <td style="vertical-align:top">
                    &nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
