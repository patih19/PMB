<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="ValPrbt.aspx.cs" Inherits="UKT.WebForm21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
        .style22
        {
            font-size: 14px;
            background-color: #FFFFCC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container top-atas" style="min-height: 450px; background-color: White;
        box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
        <div class="row">
            <div class="col-md-12">
                <div class="form-horizontal" style="font-size: 13px">
                    <p>
                    </p>
                    <table class=" table table-condensed table-hover">
                        <tr>
                            <td class="style22">
                                <strong>BORANG PERABOT RUMAH (5)</strong>
                            </td>
                            <td class="style22">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli meja kursi ruang tamu
                            </td>
                            <td>
                                <asp:Label ID="LbHargaMejaKursiRuangTamu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli almari,bifet dan sejenisnya (total harga belinya) 
                            </td>
                            <td>
                                <asp:Label ID="LbHargaAlmarBifet" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli meja kursi ruang tengah/keluarga (harga belinya)
                            </td>
                            <td>
                                <asp:Label ID="LbHargaMejaKursiRuangTengah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli meja kursi ruang makan
                            </td>
                            <td>
                                <asp:Label ID="LbHargaMejaKursiRuangMakan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli meja kursi ruang teras
                            </td>
                            <td>
                                <asp:Label ID="LbHargaMejaKursiTeras" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Harga beli tempat tidur
                            </td>
                            <td>
                                <asp:Label ID="LbHargaTempatTidur" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli televisi
                            </td>
                            <td>
                                <asp:Label ID="LbHargaTV" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli keseluruhan komputer,laptop & printer
                            </td>
                            <td>
                                <asp:Label ID="LbHargaKomputerLaptop" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli keseluruhan gas,oven & perabot dapur
                            </td>
                            <td>
                                <asp:Label ID="LbHargaPeralatanDapur" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Harga beli meja rias
                            </td>
                            <td>
                                <asp:Label ID="LbHargaMejaRias" runat="server"></asp:Label>
                            </td>
                        </tr>
                        </table>
                    <hr />
                    <strong>Sebelum data disimpan pastikan pengisian Borang Perabot Rumah Sudah Benar !</strong>
                    <br />
                    <p>
                    </p>
                    <asp:Button CssClass="btn btn-danger" ID="BtnCancel" runat="server" 
                        Text="Ulangi" onclick="BtnCancel_Click" />
                    &nbsp;<asp:Button CssClass="btn btn-success" ID="BtnSave" runat="server" 
                        Text="SIMPAN" onclick="BtnSave_Click" 
                        onclientclick="return confirm('Anda Yakin Data Tersebut Benar ?');" />
                </div>
                <p>
                </p>
                <p>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
