<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="upload_pres.aspx.cs" Inherits="smuntidar.user.WebForm12" %>
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
                    <strong>Upload File Prestasi</strong></p> <br />
                    Ketentuan Upload:
                    <ol>
                        <li>Format file yang akan diupload harus dalam bentuk image dengan format jpg, png atau 
                            jpeg</li>
                        <li>Besar ukuran file antara 100 - 200 Kb</li>
                        <li>File yang diupload jangan sampai salah atau tertukar </li>
                    </ol>
                <br />
                    <br />
                    <table class="table-condensed table-bordered" align="center">
                        <tr>
                            <td class="text-center"><strong>Jenis Prestasi</strong></td>
                            <td><strong>File Scan Prestasi</strong></td>
                            <td><strong>Upload</strong></td>
                            <td><strong>Lihat</strong></td>
                            <td><strong>Keterangan</strong></td>
                        </tr>
                        <tr>
                            <td class="text-left">Tingkat Kota/Kabupaten</td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Upload" onclick="Button1_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnLihat1" runat="server" Text="Lihat" 
                                    onclick="BtnLihat1_Click" />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">Tingkat Provinsi</td>
                            <td>
                                <asp:FileUpload ID="FileUpload2" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="BtnBnsProv" runat="server" Text="Upload" 
                                    onclick="Button2_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnLihat2" runat="server" Text="Lihat" 
                                    onclick="BtnLihat2_Click" />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left">Tingkat Nasional</td>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="BtnBnsNas" runat="server" Text="Upload" 
                                    onclick="Button3_Click" />
                            </td>
                             <td>
                                <asp:Button ID="Btnlihat3" runat="server" Text="Lihat" 
                                     onclick="Btnlihat3_Click" />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        </table >
                    <br />
                    <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            <asp:Image ID="Image1" runat="server" />
                        </td>
                    </tr>
                </table>
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
                                <!-- <a href="<%= Page.ResolveUrl("~/user/confirm.aspx") %>">Jadwal & Lokasi Ujian</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/pilihan.aspx") %>'>Pilihan Program Studi</a><br /> -->
                                <a href='<%= Page.ResolveUrl("~/user/upload_rpt.aspx") %>'>Upload Nilai Raport</a><br />
                                <a href="<%= Page.ResolveUrl("~/user/upload_pres.aspx") %>">Upload Piagam/Prestasi</a><br />
                                <a href='<%= Page.ResolveUrl("~/user/nilai.aspx") %>'> Nilai Akhir</a><br />
                                <a href='#' id='keluar' runat='server'>Logout </a>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

