<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="ValLng.aspx.cs" Inherits="UKT.WebForm20" %>
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
                                <strong>BORANG LINGKUNGAN RUMAH (4)</strong>
                            </td>
                            <td class="style22">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Luas taman M<sup style="box-sizing: border-box; position: relative; font-size: 9px;
                                    line-height: 0; vertical-align: baseline; top: -0.5em; outline: none; direction: ltr;
                                    color: rgb(101, 109, 120); font-family: &quot; open sans&quot; , sans-serif;
                                    font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal;
                                    font-weight: 600; letter-spacing: normal; orphans: 2; text-align: right; text-indent: 0px;
                                    text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px;
                                    background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">2</sup>
                            </td>
                            <td>
                                <asp:Label ID="LbLuasTaman" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Pagar
                            </td>
                            <td>
                                <asp:Label ID="LbPagar" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Jalan masuk dari jalan raya
                            </td>
                            <td>
                                <asp:Label ID="LbJalanMasuk" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Selokan air
                            </td>
                            <td>
                                <asp:Label ID="LbSelokan" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <strong>Sebelum data disimpan pastikan pengisian Borang Lingkungan Rumah Sudah Benar
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
