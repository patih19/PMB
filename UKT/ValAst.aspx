<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="ValAst.aspx.cs" Inherits="UKT.WebForm24" %>
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
                                <strong>BORANG KEPEMILIKAN HARTA/ASET KELUARGA (8)</strong>
                            </td>
                            <td class="style22">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sawah (perkiraan harga jual sekarang)</td>
                            <td>
                                <asp:Label ID="LbSawah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tanah,ladang,kebun (perkiraan harga jual sekarang)</td>
                            <td>
                                <asp:Label ID="LbLadangKebun" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ternak (perkiraan harga jual sekarang)</td>
                            <td>
                                <asp:Label ID="LbTernak" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Mobil (perkiraan harga jual sekarang)</td>
                            <td>
                                <asp:Label ID="LbMobil" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Tabungan,giro,deposito</td>
                            <td>
                                <asp:Label ID="LbTabungan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Perhiasan (perkiraan harga jual sekarang)</td>
                            <td>
                                <asp:Label ID="LbPerhiasan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Sepeda, speda motor dan sejenisnya (perkiraan harga jual sekarang)</td>
                            <td>
                                <asp:Label ID="LbSepedaMotor" runat="server"></asp:Label>
                            </td>
                        </tr>
                        </table>
                    <hr />
                    <strong>Sebelum data disimpan pastikan pengisian Borang Aset Keluarga Sudah Benar
                        !</strong>
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
