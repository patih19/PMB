<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prt.aspx.cs" Inherits="UKT.Prt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col-lg-10 col-md-10">
                    <asp:Repeater ID="RepeaterDataUKT" runat="server">
                        <HeaderTemplate>
                            <table class=" table-condensed table-bordered" style="page-break-before: always">
                                <tr>
                                    <th colspan="2">
                                        DETAIL BIODATA SOSIAL EKONOMI CALON MAHASISWA UNIVERSITAS TIDAR
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>DATA PRIBADI</strong>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Nomor Pendaftaran
                                </td>
                                <td>
                                    <asp:Label ID="LblNomerDaftar" runat="server" Text='<%# Eval("NoDaftar") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Nama
                                </td>
                                <td>
                                    <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("nama") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Jenis Kelamin
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("gender") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Alamat
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("alamat") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Tanggal Lahir
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("tglahir", "{0:dd-MMMM-yyyy}") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    No. Handphone
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("hp") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Nama Ayah
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ayah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Nama Ibu
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("ibu") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Pendidikan Ayah
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("pdayah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Pendidikan Ibu
                                </td>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Text='<%# Eval("pdibu") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>DATA RUMAH</strong>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Daya Listrik
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("dylistrik") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Biaya Listrik
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("bylistrik") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Sumber Air
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("sbair") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Biaya Air
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("byair") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Luas Tanah
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("lstanah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Luas Bangunan
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("lsbangunan") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Atap
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("atap") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Lantai
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("lantai") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Ruang Tengah
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("rgtenngah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Dapur
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("dpr") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Tempat Cuci
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("cuci") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>DATA LINGKUNGAN</strong>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Luas Taman
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("lstaman") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Pagar
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("garasi") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Jalan Masuk Rumah
                                </td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text='<%# Eval("jlnmasuk") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>DATA FASILITAS</strong>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Biaya Telepon
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("bytelphp") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Biaya Internet
                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("byint") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>DATA PENDAPATAN</strong>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Pendapatan Ayah
                                </td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text='<%# Eval("pdptayah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Pendapatan Ibu
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text='<%# Eval("pdptibu") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Hutang
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text='<%# Eval("htng") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>DATA HARTA</strong>
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Sawah
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Text='<%# Eval("sawah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Tanah
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text='<%# Eval("tanah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Ternak
                                </td>
                                <td>
                                    <asp:Label ID="Label29" runat="server" Text='<%# Eval("ternak") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Mobil
                                </td>
                                <td>
                                    <asp:Label ID="Label30" runat="server" Text='<%# Eval("mobil") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Perhiasan
                                </td>
                                <td>
                                    <asp:Label ID="Label31" runat="server" Text='<%# Eval("hiasan") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td>
                                    Sepeda
                                </td>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text='<%# Eval("sepeda") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>Kartu Keluarga</strong> <br />
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("kk") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>Foto Rumah (tampak depan)</strong> <br />
                                    <asp:Image ID="Image6" runat="server" ImageUrl='<%# Bind("FtRumah") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>Penghasilan</strong> <br />
                                    <asp:Image ID="Image7" runat="server" ImageUrl='<%# Bind("penghasilan") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>Rekening Listrik</strong> <br />
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Bind("listrik") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>STNK</strong> <br />
                                    <asp:Image ID="Image3" runat="server" ImageUrl='<%# Bind("stnk") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>Rekening Air</strong> <br />
                                    <asp:Image ID="Image4" runat="server" ImageUrl='<%# Bind("air") %>' />
                                </td>
                            </tr>
                            <tr style="page-break-inside: avoid !important">
                                <td colspan="2">
                                    <strong>Rekening Telepon</strong> <br />
                                    <asp:Image ID="Image5" runat="server" ImageUrl='<%# Bind("telp") %>' />
                                </td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
