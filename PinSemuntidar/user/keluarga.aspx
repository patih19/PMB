<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="keluarga.aspx.cs" Inherits="PinSemuntidar.user.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
        .style5
        {
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12">
                <strong><span class="style3">Proses Ke-5 : Latar Belakang Keluarga</span></strong><br />
                <br />
                <em>isian yang diberitanda * (asterik) wajib diisi :</em>
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            Jumlah Adik <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbJumAdik" runat="server"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jumlah Kakak <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbJumKakak" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Ayah <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbAyah" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Ibu <span class="style5">* </span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbIbu" runat="server"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Pendidikan Ayah<span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DLPendAyah" runat="server">
                                <asp:ListItem>SD </asp:ListItem>
                                <asp:ListItem>SMP</asp:ListItem>
                                <asp:ListItem>SMA</asp:ListItem>
                                <asp:ListItem>D3</asp:ListItem>
                                <asp:ListItem>D4/S1</asp:ListItem>
                                <asp:ListItem>S2</asp:ListItem>
                                <asp:ListItem>S3</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pendidikan Ibu <span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DlPendIbu" runat="server">
                                <asp:ListItem>SD</asp:ListItem>
                                <asp:ListItem>SMP</asp:ListItem>
                                <asp:ListItem>SMA</asp:ListItem>
                                <asp:ListItem>D3</asp:ListItem>
                                <asp:ListItem>D4/S1</asp:ListItem>
                                <asp:ListItem>S2</asp:ListItem>
                                <asp:ListItem>S3</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pekerjaan Ayah <span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DLKerjaanAyah" runat="server">
                                <asp:ListItem>PNS</asp:ListItem>
                                <asp:ListItem>TNI/POLRI</asp:ListItem>
                                <asp:ListItem>Wiraswasta</asp:ListItem>
                                <asp:ListItem>Karyawan</asp:ListItem>
                                <asp:ListItem>Pensiunan</asp:ListItem>
                                <asp:ListItem>lain-lain</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Pekerjaan Ibu <span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DLKerjaanIbu" runat="server">
                                <asp:ListItem>PNS</asp:ListItem>
                                <asp:ListItem>TNI/POLRI</asp:ListItem>
                                <asp:ListItem>Wiraswasta</asp:ListItem>
                                <asp:ListItem>Pensiunan</asp:ListItem>
                                <asp:ListItem>Karyawan</asp:ListItem>
                                <asp:ListItem>lain-lain</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Penghasilan Orang Tua <span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DLPendapatan" runat="server">
                                <asp:ListItem Value="kurang dari Rp 1,5 juta">kurang dari Rp 1,5 juta</asp:ListItem>
                                <asp:ListItem>Rp 1,5 juta  - Rp 2,5 juta</asp:ListItem>
                                <asp:ListItem>Rp 2,5 juta - Rp 3,5 juta</asp:ListItem>
                                <asp:ListItem>Rp 3,5 juta - Rp 4,5 juta</asp:ListItem>
                                <asp:ListItem>Rp 4,5 juta - Rp 5,5 juta</asp:ListItem>
                                <asp:ListItem>Rp 5,5 juta - Rp 7,5 juta</asp:ListItem>
                                <asp:ListItem>diatas Rp 7,5 juta</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                <asp:Button ID="BtAlamatBack" runat="server" Text="&lt;&lt; Kembali" />
                &nbsp;<asp:Button ID="BtLanjut" runat="server" Text="Lanjut &gt;&gt;" 
                                onclick="BtLanjut_Click" />
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
                &nbsp;<br />
            </div>
        </div>
    </div>
</asp:Content>
