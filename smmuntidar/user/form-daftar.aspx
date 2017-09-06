<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="form-daftar.aspx.cs" Inherits="smmuntidar.user.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-9">
                <br />
                Selamat datang di website pendaftaran SM-UNTIDAR (Seleksi Mandiri Universitas
                Tidar).<br />
                Situs Web ini khusus disediakan bagi calon peserta SM-UNTIDAR yang akan 
                melakukan pendaftaran secara online dan telah melakukan pembayaran di Bank BPD 
                Jateng atau BANK BNI.<br />
                Untuk membantu proses pendaftaran ini berjala lancar perhatikan beberapa hal berikut
                di bawah ini :
                <ol>
                    <li>Persiapkan dokumen anda untuk membantu pengisian online.</li>
                    <li>Pastikan fasilitas javascript pada web browser yang anda telah aktif.</li>
                    <li>Isilah Boidata Peserta dan Pilihan Program Studi dengan lengkap </li>
                    <li>Bacalah dengan teliti setiap instruksi yang terdapat pada setiap halamannya.</li>
                </ol>
                <br />
                Untuk Proses Selanjutnya klik menu <em>Pendaftaran Online</em>
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
                        SMM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. 
                        Pendaftaran :
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Pendaftaran
                            Online</a><br />
                            <a href='#' id='keluar' runat='server'>Logout </a></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
