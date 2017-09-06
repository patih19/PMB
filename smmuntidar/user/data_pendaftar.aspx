<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="data_pendaftar.aspx.cs" Inherits="smmuntidar.user.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class=" col-xs-6 col-md-8 col-lg-9 ">
                <p class="style3">
                    <strong>Biodata Pendaftar</strong></p>
                    <br />
                    <table class="table-condensed table-bordered" align="center">
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#FFCC66"><strong>Identitas</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama</td>
                            <td>
                                <asp:Label ID="LbNama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Tempat / Tanggal Lahir</td>
                            <td>
                                <asp:Label ID="LbTmpLahir" runat="server"></asp:Label>
&nbsp;/
                                <asp:Label ID="LbTglLhair" runat="server"></asp:Label>
                            &nbsp;(dd-MM-yyyy)</td>
                        </tr>
                        <tr>
                            <td class="text-right">Jenis Kelamin</td>
                            <td>
                                <asp:Label ID="LbGender" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Warga Negara</td>
                            <td>
                                <asp:Label ID="LbWarga" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Agama</td>
                            <td>
                                <asp:Label ID="LbAgama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Alamat Rumah</td>
                            <td>
                                <asp:Label ID="LbAlamat" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">No Handphone</td>
                            <td>
                                <asp:Label ID="LbHp" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#FFCC66"><strong>Pendidikan Menengah</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama Sekolah</td>
                            <td>
                                <asp:Label ID="LbSekolah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Jurusan</td>
                            <td>
                                <asp:Label ID="LbJurusan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Tahun Lulus</td>
                            <td>
                                <asp:Label ID="LbThnLulus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#FFCC66"><strong>Keluarga</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Jumlah Adik</td>
                            <td>
                                <asp:Label ID="LbAdik" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Jumlah Kakak</td>
                            <td>
                                <asp:Label ID="LbKakak" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama Ayah</td>
                            <td>
                                <asp:Label ID="LbNamaAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama Ibu</td>
                            <td>
                                <asp:Label ID="LbNamaIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pendidikan Ayah</td>
                            <td>
                                <asp:Label ID="LbPendidikanAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pendidikan Ibu</td>
                            <td>
                                <asp:Label ID="LbPendidikanIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pekerjaan Ayah</td>
                            <td>
                                <asp:Label ID="LbPekerjaanAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pekerjaan Ibu</td>
                            <td>
                                <asp:Label ID="LbPekerjaanIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Penghasilan Orang Tua</td>
                            <td>
                                <asp:Label ID="LbPenghasilan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#FFCC66"><strong>Pilihan</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Pilihan I</td>
                            <td>
                                <asp:Label ID="LbPilihanI" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pilihan II</td>
                            <td>
                                <asp:Label ID="LbPilihanII" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#FFCC66"><strong>Foto</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">&nbsp;</td>
                            <td>
                                <asp:Image ID="Image1" runat="server" Width="160px" />
                            </td>
                        </tr>
                    </table >
                <br />
                <br />
                    <br />
                    <br />
            </div>
            <div class="col-xs-6 col-md-4 col-lg-3  highlight">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. Pendaftaran:
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3">
                                <a href="<%= Page.ResolveUrl("~/user/data_pendaftar.aspx") %>">Biodata Peserta</a><br />
                                <asp:LinkButton ID="LinkButtonKartu" runat="server" 
                                onclick="LinkButtonKartu_Click">Kartu Ujian SM-UNTIDAR</asp:LinkButton> 
                                <br />
                                <a href="#">Hasil Ujian</a><br />
                                <a href='#' id='keluar' runat='server'>Logout </a>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
