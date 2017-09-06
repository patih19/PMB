<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="LsBerkasGagal.aspx.cs" Inherits="pmb.sm.WebForm15" %>
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
                <strong><span class="style5">Daftar Berkas Gagal / Tidak Sah :<br />
                </span></strong>
                <br />
                <asp:GridView ID="GVHasil" CssClass="table-condensed table-bordered" 
                    runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
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
