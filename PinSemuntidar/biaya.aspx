<%@ Page Title="" Language="C#" MasterPageFile="~/Pin.Master" AutoEventWireup="true" CodeBehind="biaya.aspx.cs" Inherits="PinSemuntidar.WebForm2" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
        }
        .style4
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12"> 
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td class="style3" colspan="2" style="background-color: #C1E0FF">
                            <strong>NO TAGIHAN & BIAYA SELEKSI MASUK UNIVERSITAS TIDAR</strong>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <strong>No. Jurnal / No. Tagihan </strong>
                        </td>
                        <td>
                            <asp:Label ID="LbBill" runat="server" 
                                Style="font-size: medium; font-weight: 700"></asp:Label>
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
                    Silakan Bayar No. Tagihan di atas dengan memilih salah satu cara di bawah ini :<br />
                    <br />
                    <ol>
                        <li>TELLER, Tunjukkan kertas ini ke Bank BNI, untuk kemudian dibayar secara cash atau
                            transfer. Teller bank, akan menukarnya dengan No. Jurnal / No. Tagihan dan PIN
                        </li>
                        <li>ATM, Masukkan No Tagihan di atas melalui ATM Bank </li>
                        <li>INTERNET BANKING / IB Masukkan No tagihan di atas melalui <em>https://ibank.bni.co.id
                        </em></li>
                    </ol>
                    <br />
                    Silakan pergunakan No Jurnal/Bill Reff dan PIN untuk melakukan pendaftaran online
                    SMUNTIDAR 2015 melalui situs internet : ......
                </div>
                <asp:Button ID="SavePrint" runat="server" Text="Simpan/Print" 
                    onclick="SavePrint_Click" />
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
