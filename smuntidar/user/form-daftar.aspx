<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="form-daftar.aspx.cs" Inherits="smuntidar.user.WebForm4" %>
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
                Selamat datang di Website Pendaftaran Peserta SM-UNTIDAR (Seleksi Masuk Universitas Tidar).<br />
                Situs Web ini khusus disediakan bagi Calon Peserta SM-UNTIDAR
                (Seleksi Masuk Universitas Tidar) yang akan melakukan pendaftaran secara online dan telah melakukan pembayaran di Bank 
                    JATENG<br />
                Untuk membantu proses pendaftaran ini berjala lancar perhatikan beberapa hal berikut di bawah ini :
                    <ol>
                        <li>Persiapkan dokumen anda untuk membantu pengisian, misalnya rapor, akta kelahiran, 
                            KK, dll.</li>
                        <li>Pastikan fasilitas Java Script pada web browser yang anda telah aktif.</li>
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
                            SM-UNTIDAR
                        </div>
                        <div class="panel-body">
                            No. Pendaftaran:
                            <asp:Label ID="LbTrans" runat="server"></asp:Label>
                            <hr />
                            <span class="style3"><a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Pendaftaran Online</a><br />
                                <a href='#' id='keluar' runat='server'>Logout </a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
        <!-- End COntainer -->
</asp:Content>

