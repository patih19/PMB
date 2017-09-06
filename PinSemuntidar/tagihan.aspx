<%@ Page Title="" Language="C#" MasterPageFile="~/Pin.Master" AutoEventWireup="true" CodeBehind="tagihan.aspx.cs" Inherits="PinSemuntidar.WebForm3" EnableEventValidation="false" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
        }
        .style4
        {
            font-size: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-9">
            Pembayaran biaya seleksi SM-UNTIDAR dilakukan di Bank BNI melalui chanel ATM atau Teller.
            Sebelum melakukan pembayaran di Bank terlebih dahulu harus mendapatkan No Tagihan. Untuk mendapatkan
            No Tagihan silahkan isi form di bawah ini, kemudian klik tombol "Buat No Tagihan"<br />
                <br /> <br />
                <table class="table-condensed" style="background-color: #FFCC66" align="center">
                    <tr>
                        <td class="style3" colspan="2" style="background-color:#990033" >
                            <span class="style1">
                            <strong>Pembuatan No. Tagihan Biaya Seleksi SM-UNTIDAR</strong></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Calon Peserta
                        </td>
                        <td>
                            <asp:TextBox ID="TbNama" CssClass="form-control" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jenis Identitas Diri</td>
                        <td>
                            <asp:DropDownList ID="DLIdentitas" runat="server">
                                <asp:ListItem>KTP</asp:ListItem>
                                <asp:ListItem>SIM</asp:ListItem>
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
                            Jalur</td>
                        <td>
                            SM-UNTIDAR</td>
                    </tr>
                    <tr>
                        <td>
                            Kode Keamanan
                        </td>
                        <td>
                            <cc1:CaptchaControl ID="Captcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="3"
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
                            <asp:TextBox CssClass="form-control" ID="TbCaptcha" runat="server" MaxLength="5" Width="70px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td style="background-color:#990033" colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="Buat No Tagihan" 
                                onclick="Button1_Click" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <asp:Label ID="bl" runat="server" ForeColor="#F2F2FF"></asp:Label>
                <br />
                <strong><span class="style4">Biaya Pendaftaran SM-UNTIDAR,&nbsp; Rp. 200.000.-&nbsp; 
                (Dua Ratus Ribu Rupiah)</span></strong><br />
                <br />
                <br />
                <br />
            </div> <!-- End Content -->
        </div> <!-- End Row -->
    </div> <!-- End Container -->
</asp:Content>