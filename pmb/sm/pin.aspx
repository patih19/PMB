<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="pin.aspx.cs" Inherits="pmb.sm.WebForm3" %>
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
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-xs-6 col-md-8 col-lg-9">
                <strong><span class="style5">Lihat PIN Pendaftaran:<br />
                </span></strong>
                <br />
                <asp:GridView ID="GVToday" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" CssClass="table-condensed table-bordered">
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
                <br />
                <br />
            </div>
            <br />
            <div class="col-xs-6 col-md-4 col-lg-3  highlight">
            Welcome : 
                <asp:Label ID="LbUser" runat="server" Text=""></asp:Label> <br /> <br />
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Pelaporan
                    </div>
                    <div class="panel-body">
                        <span class="style3">
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Beranda</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Statistik</a><br />
                                <!-- <a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Jadwal & Lokasi Ujian</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/pilihan.aspx") %>'>Pilihan Program Studi</a><br /> -->
                                <a href='<%= Page.ResolveUrl("~/user/upload_rpt.aspx") %>'>Pendaftar Hari Ini</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/upload_pres.aspx") %>">Rekapitulasi Sementara</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/nilai.aspx") %>'> Pendaftar Gagal</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/nilai.aspx") %>'> Pendaftar Cabut</a></span></div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Fasilitas
                    </div>
                    <div class="panel-body">
                        <span class="style3">
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Cari Pendaftar</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Cek Kelengkapan Berkas</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Lihat PIN</a></span></div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        System
                    </div>
                    <div class="style4">
                        <a href='<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>'>Ganti Password</a><br />
                        <a href='#' id='keluar' runat='server'>Logout </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
