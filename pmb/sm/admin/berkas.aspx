<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="berkas.aspx.cs" Inherits="pmb.sm.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
        .style4
        {
            padding: 15px;
            font-size: medium;
        }
        .style5
        {
            font-size: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-xs-6 col-md-8 col-lg-9">
                <strong><span class="style5">Cek Kelengkapan Berkas Pendaftar :<br />
                </span></strong>
                <br />
                <table class="table-condensed table-bordered">
                    <tr>
                        <td>
                            Masukkan No Tagihan/ Jurnal:
                        </td>
                        <td>
                            <asp:TextBox ID="TbNoTagihan" runat="server" CssClass="form-control" 
                                Width="150px" MaxLength="25"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="CekBerkas" runat="server" onclick="CekBerkas_Click" 
                                Text="Cek" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Panel ID="PanelDetailPendaftar" runat="server">
                    <table class="table-condensed table-bordered">
                        <tr>
                            <td class="text-right"><strong>Jenis </strong></td>
                            <td>
                                <strong>Kelengkapan</strong></td>
                            <td>
                                <strong>Keterangan</strong></td>
                                <td>
                                    <strong>Berkas</strong>
                                </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Nama</td>
                            <td>
                                <asp:Label ID="LbNama" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Foto</td>
                            <td>
                                <asp:Label ID="LbFoto" runat="server">Foto</asp:Label>
                            </td>
                            <td>
                                Wajib</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">Raport Semester 1</td>
                            <td>
                                <asp:Label ID="LbRpt1" runat="server">Raport Semester 1</asp:Label>
                                &nbsp;&nbsp;</td>
                            <td>
                                Wajib</td>
                            <td>
                                <asp:Button ID="BtnSms1" runat="server" Text="Lihat" onclick="BtnSms1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Raport Semester 2</td>
                            <td>
                                <asp:Label ID="LbRpt2" runat="server">Raport Semester 2</asp:Label>
                            </td>
                            <td>
                                Wajib</td>
                            <td>
                                <asp:Button ID="BtnSms2" runat="server" onclick="BtnSms2_Click" Text="Lihat" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Raport Semester 3</td>
                            <td>
                                <asp:Label ID="LbRpt3" runat="server">Raport Semester 3</asp:Label>
                            </td>
                            <td>
                                Wajib</td>
                            <td>
                                <asp:Button ID="BtnSms3" runat="server" onclick="BtnSms3_Click" Text="Lihat" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Raport Semester 4</td>
                            <td>
                                <asp:Label ID="LbRpt4" runat="server" Text="Raport Semester 4"></asp:Label>
                            </td>
                            <td>
                                Wajib</td>
                            <td>
                                <asp:Button ID="BtnSms4" runat="server" onclick="BtnSms4_Click" Text="Lihat" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Raport Semester 5</td>
                            <td>
                                <asp:Label ID="LbRpt5" runat="server" Text="Raport Semester 5"></asp:Label>
                            </td>
                            <td>
                                Wajib</td>
                            <td>
                                <asp:Button ID="BtnSms5" runat="server" onclick="BtnSms5_Click" Text="Lihat" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pestasi Kota/Kabupaten</td>
                            <td>
                                <asp:Label ID="LbKota" runat="server" Text="Prestasi Tingkat Kota/Kabupaten"></asp:Label>
                            </td>
                            <td>
                                Tambahan</td>
                            <td>
                                <asp:Button ID="BtnPresKota" runat="server" onclick="BtnPresKota_Click" 
                                    Text="Lihat" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Prestasi Provinsi</td>
                            <td>
                                <asp:Label ID="LbProv" runat="server" Text="Prestasi Tingkat Provinsi"></asp:Label>
                            </td>
                            <td>
                                Tambahan</td>
                            <td>
                                <asp:Button ID="BtnPresProv" runat="server" onclick="BtnPresProv_Click" 
                                    Text="Lihat" />
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Prestasi Nasional</td>
                            <td>
                                <asp:Label ID="LbNasional" runat="server" Text="Prestasi Tingkat Nasional"></asp:Label>
                            </td>
                            <td>
                                Tambahan</td>
                            <td>
                                <asp:Button ID="BtnPresNas" runat="server" onclick="BtnPresNas_Click" 
                                    Text="Lihat" />
                            </td>
                        </tr>
                    </table >
                </asp:Panel>
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            <asp:Label ID="LblSemester" runat="server" Text="" Style="font-size: small; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" CssClass="img-responsive" />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="col-xs-6 col-md-4 col-lg-3  highlight">
                Welcome :
                <asp:Label ID="LbUser" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Pelaporan Harian
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/home.aspx") %>">Beranda</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/today.aspx") %>">Pendaftar Hari Ini</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/info_prodi.aspx") %>">Rekapitulasi Sementara</a><br />
                        </span>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Pelaporan Akhir
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/hasil.aspx") %>">Pendaftar
                            Diterima</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/gagal.aspx") %>">Pendaftar Tidak Diterima</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/cabut.aspx") %>">Pendaftar Cabut</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/LsBerkasGagal.aspx") %>">Pendaftar Berkas Gagal</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/statistik.aspx") %>">Statistik Akhir</a>
                        </span>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Berkas Pendaftaran
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/berkas.aspx") %>">Cek Kelengkapan Berkas</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/BerkasInvalid.aspx") %>">Validasi Cabut Pendaftaran</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/BerkasGagal.aspx") %>">Validasi Berkas Gagal</a>
                        </span>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Fasilitas
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/search.aspx") %>">Cari Pendaftar</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/ViewPin.aspx") %>">Lihat PIN</a></span></div>
                </div>
                <div class="panel panel-danger">
                    <div class="panel-heading">
                        Bukti Pembayaran</div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/req.aspx") %>">Cek Berkas</a></span></div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        System</div>
                    <div class="style4">
                        <a href='#'>Ganti Password</a><br />
                        <a href='#' id='keluar' runat='server'>Logout </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
