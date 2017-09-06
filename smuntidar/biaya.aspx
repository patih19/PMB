<%@ Page Title="" Language="C#" MasterPageFile="~/Daftar.Master" AutoEventWireup="true" CodeBehind="biaya.aspx.cs" Inherits="smuntidar.WebForm2" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-atas" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12"> 
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td class="style3" colspan="2" style="background-color: #C1E0FF">
                            <strong>NO TAGIHAN & BIAYA SELEKSI MASUK UNIVERSITAS TIDAR</strong></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Nomor Pendaftaran</strong></td>
                        <td>
                            <asp:Label ID="LbNoDaftar" runat="server" Style="font-size: medium; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Nama</strong></td>
                        <td>
                            <asp:Label ID="LbNama" runat="server" 
                                style="font-size: medium; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Biaya Seleksi </strong>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Style="font-weight: 700" 
                                Text="Rp. 200.000"></asp:Label>
                        </td>
                    </tr>
                    </table>
                <br />
                <br />
                <br />
                <br />
                <!-- ===================  Informasi Bayar ================== -->
                <div class="highlight">
                    <br />
                    <!-- ===================  Informasi Bayar ================== -->
                    Pembayaran pendaftaran SM-UNTIDAR tahun 2015/2016 dilakukan dengan cara berikut :<br />
                    <ol>
                        <li style="direction: ltr">Tunjukkan formulir ini kepada Teller Bank Jateng untuk membayar
                            biaya pendaftaran</li>
                        <li>Teller akan menukarnya dengan PIN pendaftaran</li>
                    </ol>
                    Login menggunakan No Pendaftaran dan PIN untuk mengisi form pendaftaran online 
                    SM-UNTIDAR <em>(http://sm.untidar.ac.id)</em><br />
                </div>
                <asp:Button ID="SavePrint" runat="server" Text="Simpan/Print" 
                    onclick="SavePrint_Click" OnClientClick="document.forms[0].target ='_blank';" />

                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div> <!-- End Content -->
        </div> <!-- End Row -->
    </div> <!-- End Container -->
</asp:Content>
