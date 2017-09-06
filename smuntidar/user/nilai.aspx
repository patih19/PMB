<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="nilai.aspx.cs" Inherits="smuntidar.user.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class=" col-xs-6 col-md-8 col-lg-9 ">
                <p class="style3">
                    <strong>Ringkasan Nilai </strong></p> <br />
                    Nilai Raport Tiap Semester<br />
                    <asp:GridView ID="GVNilaiSemester" runat="server" CellPadding="4" 
                    CssClass="table-condensed table-bordered" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <br />
                <br />
                Nilai Akhir<br />
                    <asp:GridView ID="GVNilaiAkhir" runat="server" CellPadding="4" 
                    CssClass="table-condensed table-bordered" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
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
                <br />
                <br />
                <br />
                <br />
                    <br />
                    <br />
            </div>
            <div class="col-xs-6 col-md-4 col-lg-3  highlight">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. Pendaftaran:
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3">
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Biodata Peserta</a><br />
                                <!-- <a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Jadwal & Lokasi Ujian</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/pilihan.aspx") %>'>Pilihan Program Studi</a><br /> -->
                                <a href='<%= Page.ResolveUrl("~/user/upload_rpt.aspx") %>'>Upload Nilai Raport</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/upload_pres.aspx") %>">Upload Piagam/Prestasi</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/nilai.aspx") %>'> Nilai Akhir</a><br />
                                <a href='#' id='keluar' runat='server'>Logout </a>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

