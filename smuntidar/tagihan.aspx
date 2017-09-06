<%@ Page Title="" Language="C#" MasterPageFile="~/Daftar.Master" AutoEventWireup="true" CodeBehind="tagihan.aspx.cs" Inherits="smuntidar.WebForm3" EnableEventValidation="false" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 13px;
            color:White;
        }
        .style4
        {
            font-size: 12px;
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
                <br />
                <table align="center">
                    <tr>
                        <td class="style5">
                            <strong>A. Pembayaran Melalui Bank Jateng</strong>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td class="style5">
                            <strong>B. Pembayaran Non Bank Jateng</strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            Pembayaran di wilayah jawa tengah atau wilayah sekitar yang menjangkaunya
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="vertical-align: top">
                            Pembayaran di luar wilayah jawa tengah
                            dan tidak dapat menjangkau Bank Jateng</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="vertical-align: top">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <table class="table-condensed" style="background-color: #FFCC66">
                                <tr>
                                    <td class="style3" colspan="2" style="background-color: #990033">
                                        <span class="style1"><strong>Tagihan Biaya Seleksi SM-UNTIDAR</strong></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nama Peserta
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbNama" CssClass="form-control" runat="server" placeholder="Sesuai Ijazah"
                                            MaxLength="40" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Jenis Identitas Diri
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DLIdentitas" CssClass="form-control" runat="server">
                                            <asp:ListItem>NISN</asp:ListItem>
                                            <asp:ListItem>KTP</asp:ListItem>
                                            <asp:ListItem>SIM</asp:ListItem>
                                            <asp:ListItem Value="KK">Kartu Keluarga</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        No. Identitas
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbNoIdentitas" runat="server" MaxLength="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbEmail" placeholder="Direkomdendasikan Gmail"
                                            runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Jalur
                                    </td>
                                    <td>
                                        SM-UNTIDAR
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kode Keamanan
                                    </td>
                                    <td>
                                        <cc1:CaptchaControl ID="Captcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="11"
                                            CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="#FFCC66" Style="text-align: center" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ketik ulang tulisan yang tampil
                                        <br />
                                        pada gambar diatas (case sensitive)
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbCaptcha" runat="server" MaxLength="5"
                                            Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #990033" colspan="2">
                                        <asp:Button ID="Button1" runat="server" Text="Buat No Tagihan" 
                                            OnClick="Button1_Click" Enabled="False" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                        <td>
                            <table class="table-condensed" style="background-color: #C5E5C5">
                                <tr>
                                    <td class="style3" colspan="2" style="background-color: #339933">
                                        <span class="style1"><strong>Tagihan Biaya Seleksi SM-UNTIDAR</strong></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nama Peserta
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbNama2" CssClass="form-control" placeholder="Sesuai Ijazah" runat="server"
                                            MaxLength="40" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Jenis Identitas Diri
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DLIdentitas2" CssClass="form-control" runat="server">
                                            <asp:ListItem>NISN</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        No. Identitas
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbNoIdentitas2" runat="server" MaxLength="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbEmail2" placeholder="Direkomdendasikan Gmail"
                                            runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Jalur
                                    </td>
                                    <td>
                                        SM-UNTIDAR
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kode Keamanan
                                    </td>
                                    <td>
                                        <cc1:CaptchaControl ID="Captcha2" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="11"
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
                                        <asp:TextBox CssClass="form-control" ID="TbCaptcha2" runat="server" MaxLength="5"
                                            Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #339933" colspan="2">
                                        <asp:Button ID="Button2" runat="server" Text="Buat No Tagihan" 
                                            OnClick="Button2_Click" Enabled="False" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <strong><span class="style4">Biaya Pendaftaran Melalui Bank Jateng Rp. 200.000.-&nbsp;
                                (Dua Ratus Ribu Rupiah)</span></strong><br />
                        </td>
                        <td>
                        </td>
                        <td>
                            <strong><span class="style4">Biaya Pendaftaran Non Bank Jateng&nbsp; Rp. 200.000.-&nbsp;
                                (Dua Ratus Ribu Rupiah)
                                <br />
                                + Beban Biaya Transfer Bank Terkait</span></strong><br />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="bl" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <asp:Label ID="pn" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <asp:Label ID="bl2" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <asp:Label ID="pn2" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <asp:Label ID="tg" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <br />
                <br />
                <br />
            </div>
            <!-- End Content -->
        </div>
        <!-- End Row -->
    </div>
    <!-- End Container -->
</asp:Content>
