<%@ Page Title="" Language="C#" MasterPageFile="~/SMM.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="smmuntidar.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container top-atas" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12 col-lg-12">
            <br />
                <table class ="table-condensed table-bordered" align="center">
                    <tr>
                            
                        <td class="style5">
                            <strong>Upload Slip/Bukti Pembayaran</strong></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            Persyaratan Upload :<br />
                            <ol>
                                <li>Format file dalam bentuk image dengan jenis gambar jpg, png atau
                                    jpeg</li>
                                <li>Besar ukuran file antara 300 - 500 Kb</li>
                                <li>File harus berwarna full color tidak diperkenankan berwarna hitam 
                                    putih/grayscale</li>
                                <li>Upload Hanya dapat dilakukan satu kali saja</li>
                            </ol>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <table class="table-condensed" style="background-color: #C5E5C5">
                    <tr>
                        <td class="style1" style="background-color:#339933" >
                            <strong>Form Upload</strong></td>
                        <td class="style1" style="background-color:#339933" >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="None" />
                        </td>
                        <td>
                            <asp:Button ID="BtnUpload" CssClass="btn btn-primary" runat="server" Text="Upload" 
                                onclick="BtnUpload_Click" />
                        </td>
                    </tr>
                    </table>
                            <asp:Label ID="LbSuccess" runat="server" ForeColor="#339933"></asp:Label> 
                            <asp:Label ID="LbGagal" runat="server" ForeColor="#CC3300"></asp:Label>
                            <asp:Label ID="LbNoTag" runat="server" ForeColor="#CC3300" 
                                style="color: #F2F2FF; background-color: #F2F2FF"></asp:Label>
                            <asp:Label ID="LbEmail" runat="server" ForeColor="#CC3300" 
                                style="color: #F2F2FF; background-color: #F2F2FF"></asp:Label>

                        </td>
                    </tr>
                    </table>
                <asp:Label ID="bl" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <asp:Label ID="pn" runat="server" ForeColor="#F2F2FF"></asp:Label>

                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div> <!-- End Content -->
        </div> <!-- End Row -->
    </div>
</asp:Content>
