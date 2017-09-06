<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kartu.aspx.cs" Inherits="smmuntidar.user.Kartu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <!-- <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css"> -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-family: Arial;
            font-size: large;
            text-align: center;
            font-weight: 700;
        }
        .style2
        {
            color: #0099CC;
        }
        .borderless
        {
            border: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table-condensed borderless" align="center">
            <tr>
                <td>
                    <table class="table-condensed">
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="100px" 
                                    ImageUrl="~/gambar/LOGO-UNTIDAR-2017.png" />
                            </td>
                            <td class="style2">
                                <span class="style1">KARTU TANDA PESERTA</span><br class="style1" />
                                <span class="style1">SM-UNTIDAR TAHUN 2017/2018</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table> <tr> <td> <strong>Nomor Ujian</strong></td> <td> : <asp:Label ID="LbNoUjian"
                runat="server" style="font-weight: 700"></asp:Label> </td> </tr> <tr> <td> <strong>Kelompok</strong></td>
                <td> : <asp:Label ID="LbKelompok" runat="server" style="font-weight: 700"></asp:Label>
                </td> </tr> </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="font-size: 13px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image2" runat="server" Width="165px" />
                                </td>
                                <td>
                                    &nbsp;&nbsp;
                                </td>
                                <td style="vertical-align: top"> 
                                <table class="table-condensed table-bordered"> <tr>
            <td> Nama Peserta </td> <td> : 
                                <asp:Label ID="LbNama" runat="server"></asp:Label>
            </td> </tr> <tr> <td> Tahun Lulus </td> <td> : 
                                <asp:Label ID="LbThnLls" runat="server"></asp:Label>
            </td> </tr> <tr> <td> Pilihan I </td> <td> : 
                                <asp:Label ID="LbPilihan1" runat="server"></asp:Label>
            </td> </tr> <tr> <td> Pilihan II </td> <td> : 
                                <asp:Label ID="LbPilihan2" runat="server"></asp:Label>
            </td> </tr> <tr> <td> Alamat </td> <td> : 
                                <asp:Label ID="LbAlamat" runat="server"></asp:Label>
            </td> </tr> <tr> <td> Nomor Pendaftaran </td> <td> : 
                                <asp:Label ID="LbNoDaftar" runat="server"></asp:Label>
            </td> </tr> </table> <!-- <table class="table-condensed table-bordered"> <tr> <td>
            WIB </td> <td> KEGIATAN </td> </tr> <tr> <td> 07.00-08.00 </td> <td> MASUK RUANG
            UJIAN, MENGISI BIODATA </td> </tr> <tr> <td> 07.00-08.00 </td> <td> MASUK RUANG
            UJIAN, MENGISI BIODATA </td> </tr> <tr> <td> 07.00-08.00 </td> <td> MASUK RUANG
            UJIAN, MENGISI BIODATA </td> </tr> </table> --> </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>PERLENGKAPAN YANG HARUS DIBAWA SAAT UJIAN</strong><br />
                    - Tanda bukti pendaftaran<br />
                    - Pensil 2B, karet penghapus, peraut pensil<br />
                    <br />
                    <strong>PERNYATAAN</strong><br />
                    Dengan ini saya menyatakan bahwa data yang saya isikan pada laman pendaftaran online<br />
                    SM-UNTIDAR tahun 2017/2018 adalah benar. Saya bersedia menerima sanksi pembatalan penerimaan<br />
                    apabila saya menggar pernyataan ini.<br />
                    <br />
                    <strong>PENGUMUMAN</strong><br />
                    Pengumuman Lokasi dan Ruang Ujian 
                    dapat dilihat pada laman <a href="http://sm.untidar.ac.id">
                    http://sm.untidar.ac.id</a> tanggal
                    <strong>05 Juli 2017</strong><br />
                    <br />
                    <br />
                    <br />
                    (..........................................) <em>
                        <br />
                        nama terang &amp; tanda tangan </em>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
