<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="statistik.aspx.cs" Inherits="pmb.sm.WebForm8" %>
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
                <strong><span class="style5">Statistik Pendaftaran:<br />
                </span></strong>
                <br />
                    <table class="table-condensed table-bordered">
                        <tr>
                            <td class="text-right">
                                <strong>PENDAFTAR</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Jumlah Pendaftar</td>
                            <td>
                                <asp:Label ID="LbPendaftar" runat="server">Jumlah Pendaftar</asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <strong>PENDAFTAR DITERIMA</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Jumlah diterima</td>
                            <td>
                                <asp:Label ID="LbDiterima" runat="server" Text="Diterima"></asp:Label>
&nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <strong>WILAYAH ASAL SEKOLAH</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Dalam Kota</td>
                            <td>
                                <asp:Label ID="LbDalamKota" runat="server">Dalam Kota</asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">Luar Kota</td>
                            <td>
                                <asp:Label ID="LbLuarKota" runat="server">Luar Kota</asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right"><strong>JENIS KELAMIN</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Laki-laki</td>
                            <td>
                                <asp:Label ID="LbLelaki" runat="server">Laki-laki</asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Perempuan</td>
                            <td>
                                <asp:Label ID="LbPerempuan" runat="server">Perempuan</asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <strong>ASAL SEKOLAH</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                SMK</td>
                            <td>
                                <asp:Label ID="LbSMK" runat="server" Text="SMK"></asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                SMA</td>
                            <td>
                                <asp:Label ID="LbSMA" runat="server" Text="SMA"></asp:Label>
                                &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <strong>PENDAFTAR DITERIMA</strong></td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                S1 TEKNIK ELEKTRO</td>
                            <td>
                                <asp:Label ID="LbElektro" runat="server" Text="Elektro"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label2" runat="server" Text="S1 TEKNIK MESIN"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbMesin" runat="server" Text="Mesin"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label3" runat="server" Text="D3 TEKNIK MESIN"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbOtomotif" runat="server" Text="Otomotif"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label4" runat="server" Text="S1 TEKNIK SIPIL"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbSipil" runat="server" Text="Sipil"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label5" runat="server" Text="S1 AGROTEKNOLOGI"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbPertaninan" runat="server" Text="Pertaninan"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label6" runat="server" Text="S1 EKONOMI PEMBANGUNAN"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbEkonomi" runat="server" Text="Ekonomi"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label7" runat="server" Text="D3 AKUNTANSI"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbAkuntansi" runat="server" Text="Akuntansi"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label8" runat="server" Text="S1 ILMU ADMINISTRASI NEGARA"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbSospol" runat="server" Text="Sospol"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label9" runat="server" 
                                    Text="S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbIndonesia" runat="server" Text="Bahasa Indonesia"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                <asp:Label ID="Label10" runat="server" Text="S1 PENDIDIKAN BAHASA INGGRIS"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbInggris" runat="server" Text="Bahasa Inggris"></asp:Label>
                            &nbsp;orang</td>
                        </tr>
                    </table >
                <br />
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
