<%@ Page Title="" Language="C#" MasterPageFile="~/SMM.Master" AutoEventWireup="true" CodeBehind="tagihan.aspx.cs" Inherits="smmuntidar.WebForm2" EnableEventValidation="false" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: 15px;
            color:White;
        }
        .style5
        {
            font-size: 13px;
        }
        .style6
        {
            font-size: 13px;
            background-color: #FFFFCC;
        }
        .style7
        {
        background-color: #DAFCE0;
    }
        .style8
        {
            font-size: 13px;
            background-color: #DAFCE0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="container top-atas" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12">
                <%-- <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td class="style5">
                            <strong>Aktifasi Biaya Pendaftaran SMM-UNTIDAR</strong>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            Pembayaran biaya seleksi <span class="sb"><strong>SMM-UNTIDAR HANYA DAPAT DIBAYARKAN
                                MELALUI BANK JATENG SAJA</strong></span>. Sebelum melakukan pembayaran di Bank
                            terlebih dahulu harus mendapatkan No Tagihan. Untuk mendapatkan No Tagihan silahkan
                            isi form di bawah ini, kemudian klik tombol "Buat No Tagihan"
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <table class="table-condensed" style="background-color: #FFCC66" align="center">
                                <tr>
                                    <td class="style3" colspan="2" style="background-color: #990033">
                                        <span class="style1"><strong>Pembuatan No. Tagihan Biaya SMM-UNTIDAR</strong></span>
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
                                        Jenis Identitas Diri
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DLIdentitas" CssClass="form-control" runat="server">
                                            <asp:ListItem>KTP</asp:ListItem>
                                            <asp:ListItem>SIM</asp:ListItem>
                                            <asp:ListItem Value="KK">Kartu Keluarga</asp:ListItem>
                                            <asp:ListItem>NISN</asp:ListItem>
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
                                        <asp:TextBox CssClass="form-control" ID="TbEmail" runat="server" MaxLength="30"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Jalur
                                    </td>
                                    <td>
                                        SMM-UNTIDAR
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kode Keamanan
                                    </td>
                                    <td>
                                        <cc1:CaptchaControl ID="Captcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="10"
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
                                        <asp:Button ID="Button1" runat="server" Text="Buat No Tagihan" OnClick="Button1_Click" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <strong><span class="style4">Biaya Pendaftaran SMM-UNTIDAR,&nbsp; Rp. 200.000.-&nbsp;
                                (Dua Ratus Ribu Rupiah)</span></strong><br />
                            <asp:Label ID="bl" runat="server" Text="Label" ForeColor="#F2F2FF"></asp:Label>
                            &nbsp;<asp:Label ID="pn" runat="server" Text="Label" ForeColor="#F2F2FF"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>--%>
                <br />
                <table align="center">
                    <tr>
                        <td class="style6">
                            <strong>A. Pembayaran Melalui Bank Jateng</strong>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td class="style8">
                            <strong>B. Pembayaran Melalui Bank BNI</strong></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="hll">
                            Pembayaran di wilayah jawa tengah atau wilayah sekitar yang menjangkaunya</td>
                        <td>
                            &nbsp;
                        </td>
                        <td style="vertical-align: top" class="style7">
                            Pembayaran di luar wilayah jawa tengah
                            dan tidak dapat menjangkau Bank Jateng</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="hll">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td style="vertical-align: top" class="style7">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="hll">
                            <table class="table-condensed" style="background-color: #FFCC66" align="center">
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
                                        <asp:TextBox CssClass="form-control" ID="TbNoIdentitas" runat="server" 
                                            MaxLength="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbEmail" placeholder="Email Pribadi Aktif"
                                            runat="server" MaxLength="175" TextMode="Email"></asp:TextBox>
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
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                            CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="#FFCC66" 
                                            Style="text-align: center" />
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
                                        <%--<asp:Button ID="BtnTgJateng" runat="server" Text="Buat No Tagihan (JATENG & SEKITARNYA)" 
                                            OnClick="Button1_Click" />--%>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                        <td class="style7">
                            <table class="table-condensed" style="background-color: #C5E5C5" align="center">
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
                                        <asp:TextBox CssClass="form-control" ID="TbNoIdentitas2" runat="server" MaxLength="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control" ID="TbEmail2" placeholder="Email Pribadi Aktif"
                                            runat="server" MaxLength="175" TextMode="Email"></asp:TextBox>
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
                                        Kode Keamanan</td>
                                    <td>
                                        <cc1:CaptchaControl ID="Captcha2" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                            CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
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
                                        <%--<asp:Button ID="BtTgNonJateng" runat="server" Text="Buat No Tagihan (KHUSUS LUAR JATENG)" 
                                            OnClick="Button2_Click" />--%>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="hll">
                            <strong><span class="style5">Biaya Pendaftaran Melalui Bank Jateng Rp. 200.000.-&nbsp;
                                (Dua Ratus Ribu Rupiah)</span></strong></td>
                        <td>
                        </td>
                        <td class="style7">
                            <strong><span class="style5">Biaya Pendaftaran Non Bank Jateng&nbsp;Dengan Model 
                            Pembayaran SKN (Kliring) Rp. 200.000.-&nbsp;
                                <br />
                            (Dua Ratus Ribu Rupiah) Yang Ditujukan Kepada Bendahara Penerimaan Untidar
                            <br />
                            Ditambah Dengan Beban Biaya Pengiriman.</span></strong><br />

                            <br />

                            <div style="font-size:16px"><asp:Label ID="LbSuccessMsg" runat="server" Text=""></asp:Label></div>

                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </div> <!-- End Content -->
        </div> <!-- End Row -->
    </div> <!-- End Container -->

    
</asp:Content>
