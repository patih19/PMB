<%@ Page Title="" Language="C#" MasterPageFile="~/SMM.Master" AutoEventWireup="true" CodeBehind="ValUpload.aspx.cs" Inherits="smmuntidar.WebForm5" EnableEventValidation="false" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="container top-atas" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xl-12">
            <br />
                <table class="table-bordered table-bordered" align="center" >
                    <tr>
                            
                        <td class="style5">
                            <strong>Validasi Data Peserta</strong> <br />
                            Sebelum melakukan upload bukti/slip pembayaran, peserta diwajibkan untuk
                            mengisi kembali biodata peserta.</td>
                    </tr>
                    <tr>
                        <td>
                        <br />
                            <table class="table-condensed" style="background-color: #C5E5C5" align="center">
                                <tr>
                                    <td class="style3" colspan="2" style="background-color: #339933">
                                        Form Validasi Data
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kode Tagihan</td>
                                    <td>
                                        <asp:TextBox ID="TBKdTagihan" runat="server" CssClass="form-control" 
                                            placeholder="Periksa Email"></asp:TextBox>
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
                                        Jenis Identitas Diri
                                    </td>
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
                                        Kode Keamanan
                                    </td>
                                    <td>
                                        <cc1:CaptchaControl ID="Captcha2" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="3"
                                            CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="#C5E5C5" Style="text-align: center" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ketik ulang kode yang tampak
                                        <br />
                                        pada gambar diatas (case sensitive)
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbCaptcha2" runat="server" MaxLength="5"
                                            Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #339933" colspan="2">
                                       <%-- <asp:Button ID="BtnProses" runat="server" Text="submit" 
                                            OnClick="BtnProses_Click" CssClass="btn btn-default" />--%>
                                            <%--Maaf from masih dalam perbaikan ....--%></td>
                                </tr>
                            </table>
                            <br />
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
            </div> <!-- End Content -->
        </div> <!-- End Row -->
    </div> <!-- End Container -->
</asp:Content>
