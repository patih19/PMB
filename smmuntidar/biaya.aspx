<%@ Page Title="" Language="C#" MasterPageFile="~/SMM.Master" AutoEventWireup="true" CodeBehind="biaya.aspx.cs" Inherits="smmuntidar.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
        }
        .style4
        {
            background-color: #FFFF99;
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
                            <strong>NO PEMBAYARAN DAN BIAYA PENDAFTARAN
                            <br />
                            SM-UNTIDAR TAHUN 2017/2018</strong></td>
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
                    <p></p>
                <!-- ===================  Informasi Bayar ================== -->
                <div class="highlight">
                    <br />
                    <!-- ===================  Informasi Bayar ================== -->
                    Prosedur pembayaran biaya pendaftaran SM-UNTIDAR tahun 2017/2018 sebagai berikut :<br />
                    <ol>
                        <li style="direction: ltr">Tunjukkan formulir pembayaran kepada Teller Bank BDP Jateng untuk membayar
                            biaya pendaftaran</li>
                        <li>Teller akan menukarnya dengan slip pembayaran yang terdapat PIN pendaftaran</li>
                    </ol>
                    login menggunakan <strong>Nomor Pendaftaran</strong> dan <strong>PIN</strong> untuk mengisi form pendaftaran online 
                    SM-UNTIDAR <em>(http://sm.untidar.ac.id)</em><br />
                </div>
                <%--<asp:Button ID="SavePrint" runat="server" Text="Simpan/Print" 
                    onclick="SavePrint_Click" OnClientClick="document.forms[0].target ='_blank';" />--%>

                <span class="style4">

                <em>Formulir pembayaran sudah dikirm, silahkan periksa email  
                </em> 
                </span> 
                <br />
                <br />
                <br />
                <br />
            </div> <!-- End Content -->
        </div> <!-- End Row -->
    </div> <!-- End Container -->
</asp:Content>
