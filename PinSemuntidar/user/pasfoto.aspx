<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="pasfoto.aspx.cs" Inherits="PinSemuntidar.user.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
        .style4
        {
            width: 272px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12">
                <strong><span class="style3">Proses Ke-7: UPLOAD FOTO</span></strong><br />
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td class="style4">
                            Max Foto Size 100 Kb
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:FileUpload ID="FileUploadFoto" runat="server" Height="20px" Width="221px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:Image ID="ImageFoto" runat="server" Height="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="Upload" />
                            &nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:Button ID="BtAlamatBack" runat="server" Text="Kembali" />
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="Selesai" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
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
                &nbsp;<br />
            </div>
        </div>
    </div>
</asp:Content>
