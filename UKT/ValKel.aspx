﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="ValKel.aspx.cs" Inherits="UKT.WebForm18" %>
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
            <div class="form-horizontal" style="font-size:13px">
            <p></p>
            <table class=" table table-condensed table-hover">
                <tr>
                    <td class="style22">
                        <strong>BORANG KELUARGA (2)</strong></td>
                    <td class="style22">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah orang serumah
                    </td>
                    <td>
                        <asp:Label ID="LbJumlahOrangSerumah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah saudara kandung
                    </td>
                    <td>
                        <asp:Label ID="LbJumlahSaudara" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah saudara kandung sedang kuliah
                    </td>
                    <td>
                        <asp:Label ID="LbJumlahSdrKuliah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah saudara kandung sekolah
                    </td>
                    <td>
                        <asp:Label ID="LbJumSdrSekolah" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
            <hr />
                <strong>Sebelum data disimpan pastikan pengisian Borang Keluarga Sudah Benar !</strong> <br />
                <p></p>
                <asp:Button CssClass="btn btn-danger" ID="BtnCancel" runat="server" 
                    Text="Ulangi" onclick="BtnCancel_Click" />
                &nbsp;<asp:Button CssClass="btn btn-success" ID="BtnSave" runat="server" 
                    Text="SIMPAN" onclick="BtnSave_Click" 
                    onclientclick="return confirm('Anda Yakin Data Tersebut Benar ?');" />
            </div>
            <p></p>
            <p></p>
        </div>
    </div> 
</div>
</asp:Content>
