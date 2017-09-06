<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="upload_rpt.aspx.cs" Inherits="smuntidar.user.WebForm11" %>
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
                    <strong>Upload Raport Semester 1 s.d 5</strong></p> <br />
                    Ketentuan Upload:
                    <ol>
                        <li>File yang diupload harus dalam bentuk image dengan format jpg, png atau 
                            jpeg</li>
                        <li>Ukuran masing - masing file maksimal 200 Kb</li>
                        <li>Proses upload dilakukan satu per satu tiap semester</li>
                        <li>File yang diupload jangan sampai salah atau tertukar </li>
                    </ol>
                    <br />
                    <br />
                    <table class="table-condensed table-bordered" align="center">
                        <tr>
                            <td class="text-center"><strong>Semester</strong></td>
                            <td><strong>Raport</strong></td>
                            <td><strong>Upload</strong></td>
                            <td><strong>Lihat</strong></td>
                            <td><strong>Keterangan</strong></td>
                        </tr>
                        <tr>
                            <td class="text-center">1</td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDisk1" runat="server" onclick="BtnDisk1_Click" Text="Upload" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDskLihat1" runat="server" onclick="BtnDskLihat1_Click" Text="Lihat" />
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">2</td>
                            <td>
                                <asp:FileUpload ID="FileUpload20" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDisk2" runat="server" onclick="BtnDisk2_Click" Text="Upload" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDskLihat2" runat="server" onclick="BtnDskLihat2_Click" Text="Lihat" />
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">3</td>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDisk3" runat="server" onclick="BtnDisk3_Click" 
                                    Text="Upload" />
                            </td>
                             <td>
                                &nbsp;<asp:Button ID="BtnDskLihat3" runat="server" onclick="BtnDskLihat3_Click" Text="Lihat" />
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">4</td>
                            <td>
                                <asp:FileUpload ID="FileUpload4" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDisk4" runat="server" onclick="BtnDisk4_Click" Text="Upload" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="Button8" runat="server" onclick="Button8_Click" Text="lihat" />
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">5</td>
                            <td>
                                <asp:FileUpload ID="FileUpload5" runat="server" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDisk5" runat="server" onclick="BtnDisk5_Click" Text="Upload" />
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="BtnDskLihat5" runat="server" onclick="BtnDskLihat5_Click" Text="Lihat" />
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table >
                    <br />
                    <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            <asp:Label ID="LblSemester" runat="server" Text="" 
                                style="font-size: small; font-weight: 700"></asp:Label>
                        </td>
                    </tr>
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
