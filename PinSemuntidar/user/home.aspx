<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="PinSemuntidar.user.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container top-buffer"  style="background-color: #F2F2FF;">
            <div class="row">
                <div class="col-md-9">
                    <br />
                    Terima kasih anda telah mendaftar di website Pendaftaran SM-UNTIDAR (Seleksi 
                    Masuk Universitas Tidar) Mohon selalu melihat situs
                    <a href="http://sm-untidar.untidar.ac.id">http://sm-untidar.untidar.ac.id</a> 
                    untuk memperoleh informasi terkini mengenai SM-UNTIDAR<br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
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
                <br />
                <div class="col-md-3 highlight">
                    <!-- ========= Login Form ========= -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            SM-UNTIDAR
                        </div>
                        <div class="panel-body">
                            No. Jurnal :
                            <asp:Label ID="LbTrans" runat="server"></asp:Label>
                            <hr />
                            <span class="style3">
                                <a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Biodata Peserta</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Jadwal & Lokasi Ujian</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/pilihan.aspx") %>'>Pilihan Program Studi</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/confirm.aspx") %>'>Upload Biodata</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/cetak.aspx") %>">Download Kartu Peserta</a><br />
                                <a href='#' id='keluar' runat='server'>Logout </a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div> <!-- End COntainer -->
</asp:Content>
