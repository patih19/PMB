<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="keluarga.aspx.cs" Inherits="smmuntidar.user.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
        .style4
        {
            color: #808080;
        }
        .style5
        {
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container top-buffer" style="background-color: #F2F2FF;">
<p></p>
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="PanelBdk" runat="server" CssClass="form-control" BackColor="#FFFF99">
                        Pengisian formulir pendaftaran urut mulai<strong> tahap 1 (satu) sampai 8 
                        (delapan)
                        </strong>
                </asp:Panel>
            </div>
        </div>
        <p></p>
        <div class="row">
            <div class="col-md-9">
                <strong><span class="style3">Tahap Ke-5 : Latar Belakang Keluarga</span></strong><br />
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
                            <asp:TextBox ID="TbJumAdik" runat="server" MaxLength="1" Width="40px"></asp:TextBox>
                            <br />
                             <span class="style4">Jika tidak memiliki isikan 0 </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jumlah Kakak <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbJumKakak" runat="server" MaxLength="1" Width="40px"></asp:TextBox> <br />
                            <span class="style4">Jika tidak memiliki isikan 0 </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Ayah <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbAyah" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nama Ibu <span class="style5">* </span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbIbu" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Pendidikan Ayah<span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DLPendAyah" runat="server">
                                <asp:ListItem>Pendidikan</asp:ListItem>
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
                                <asp:ListItem>Pendidikan</asp:ListItem>
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
                                <asp:ListItem>Pekerjaan</asp:ListItem>
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
                                <asp:ListItem>Pekerjaan</asp:ListItem>
                                <asp:ListItem>PNS</asp:ListItem>
                                <asp:ListItem>TNI/POLRI</asp:ListItem>
                                <asp:ListItem>Wiraswasta</asp:ListItem>
                                <asp:ListItem>Pensiunan</asp:ListItem>
                                <asp:ListItem>Karyawan</asp:ListItem>
                                <asp:ListItem>Ibu Rumah Tangga</asp:ListItem>
                                <asp:ListItem>Petani</asp:ListItem>
                                <asp:ListItem>lain-lain</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Penghasilan Orang Tua <span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DLPenghasilan" runat="server">
                                <asp:ListItem>Penghasilan</asp:ListItem>
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
                            <asp:Button ID="BtLanjut" runat="server" Text="Lanjut &gt;&gt;" 
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
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. Pendaftaran :
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3"><a href='#' id='keluar' runat='server'>Logout </a></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
