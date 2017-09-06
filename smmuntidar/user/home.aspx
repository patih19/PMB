<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="smmuntidar.user.WebForm10" %>
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
                    Terima kasih anda telah mendaftar di website Pendaftaran SMM-UNTIDAR (Seleksi 
                    Mandiri Masuk Universitas Tidar) Tahun 2017. Dimohon selalu melihat situs
                    <a href="http://smm.untidar.ac.id">http://sm.untidar.ac.id</a> untuk 
                    memperoleh informasi terkini.<br />
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
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            SM-UNTIDAR
                        </div>
                        <div class="panel-body">
                            No. 
                            Pendaftaran :
                            <asp:Label ID="LbTrans" runat="server"></asp:Label>
                            <hr />
                            <span class="style3">
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Biodata Peserta</a><br />
                                <!-- <a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Jadwal & Lokasi Ujian</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/pilihan.aspx") %>'>Pilihan Program Studi</a><br /> -->
                                <asp:LinkButton ID="LinkButtonKartu" runat="server" 
                                onclick="LinkButtonKartu_Click">Kartu Ujian SM-UNTIDAR</asp:LinkButton> <br />
                                <a>Hasil Ujian</a><br />
                                <a href='#' id='keluar' runat='server'>Logout </a>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
</asp:Content>
