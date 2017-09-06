<%@ Page Title="" Language="C#" MasterPageFile="~/Daftar.Master" AutoEventWireup="true" CodeBehind="ValUp.aspx.cs" Inherits="smuntidar.WebForm5" EnableEventValidation="false" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 13px;
            color:White;
        }
        .style5
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="container top-atas" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12 col-lg-12">
            <br />
                <table align="center">
                    <tr>
                            
                        <td class="style5">
                            <strong>Validasi Data Peserta</strong></td>
                    </tr>
                    <tr>
                            
                        <td style="vertical-align:top">
                            Sebelum melakukan upload bukti/slip pembayaran, peserta diwajibkan untuk
                            mengulang kembali memasukkan data diri peserta.</td>
                    </tr>
                    <tr>
                            
                        <td style="vertical-align:top">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        <table class="table-condensed" style="background-color: #C5E5C5">
                    <tr>
                        <td class="style3" colspan="2" style="background-color:#339933" >
                            Form Validasi Data</td>
                    </tr>
                    <tr>
                        <td>
                            No. Pendaftaran</td>
                        <td>
                            <asp:TextBox ID="TBNoDaftar" runat="server" CssClass="form-control" placeholder="Periksa Email"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Peserta
                        </td>
                        <td>
                            <asp:TextBox ID="TbNama" CssClass="form-control" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jenis Identitas Diri</td>
                        <td>
                            <asp:DropDownList ID="DLIdentitas" CssClass="form-control" runat="server">
                                 <asp:ListItem>NISN</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No. Identitas
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="TbNoIdentitas" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Kode Keamanan</td>
                        <td>
                            <cc1:CaptchaControl ID="Captcha2" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="3"
                                CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="#C5E5C5" Style="text-align: center" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ketik ulang tulisan yang tampil
                            <br />
                            pada gambar diatas (case sensitive)
                        </td>
                        <td>
                            <asp:TextBox CssClass="form-control" ID="TbCaptcha2" runat="server" 
                                MaxLength="5" Width="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td style="background-color:#339933" colspan="2">
                            <asp:Button ID="BtnProses" runat="server" Text="Proses" 
                                onclick="BtnProses_Click" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    </table>
                <br />
                <asp:Label ID="Lbtg" runat="server" ForeColor="#F2F2FF" Text="Label"></asp:Label>
                <asp:Label ID="Lbemail" runat="server" ForeColor="#F2F2FF" Text="Label"></asp:Label>
                <br />
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
