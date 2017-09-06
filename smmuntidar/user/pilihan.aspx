<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="pilihan.aspx.cs" Inherits="smmuntidar.user.WebForm17" %>
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
                <strong><span class="style3">Tahap Ke-6: Pilihan Program Studi</span></strong><br />
                <em>isian yang diberitanda <span class="sb">*</span> (asterik) wajib diisi </em>
                <br />
                <br />
                <br />
                <div class="panel panel-success">
                    <div class="panel-heading">
                        Kategori/Jenis Tes Berdasarkan Pilihan Program Studi&nbsp; 
                    </div>
                    <div class="panel-body">
                        <table class="table table-striped">
                            <tr style="background-color: #E2E2E2">
                                <td>
                                    <strong>No.
                                </strong>
                                </td>
                                <td>
                                    <strong>SAINTEK</strong>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <strong>No.</strong></td>
                                <td>
                                    <strong>SOSHUM</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1.&nbsp;
                                </td>
                                <td>
                                    S1 TEKNIK ELEKTRO</td>
                                <td>
                                    &nbsp;&nbsp;</td>
                                <td>
                                    1.</td>
                                <td>
                                    S1 EKONOMI PEMBANGUNAN</td>
                            </tr>
                            <tr>
                                <td>
                                    2.
                                </td>
                                <td>
                                    S1 TEKNIK MESIN</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    2.</td>
                                <td>
                                    D3 AKUNTANSI</td>
                            </tr>
                            <tr>
                                <td>
                                    3.
                                </td>
                                <td>
                                    D3 TEKNIK MESIN</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    3.</td>
                                <td>
                                    S1 ILMU ADMINISTRASI NEGARA</td>
                            </tr>
                            <tr>
                                <td>
                                    4.
                                </td>
                                <td>
                                    S1 TEKNIK SIPIL</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    4.</td>
                                <td>
                                    S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</td>
                            </tr>
                            <tr>
                                <td>
                                    5.
                                </td>
                                <td>
                                    S1 AGROTEKNOLOGI</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    5.</td>
                                <td>
                                   S1 PENDIDIKAN BAHASA INGGRIS</td>
                            </tr>
                            <tr>
                                <td>
                                    6.</td>
                                <td>
                                    S1 PETERNAKAN</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    6.</td>
                                <td>
                                    S1 HUKUM</td>
                            </tr>
                            <tr>
                                <td>
                                    7.</td>
                                <td>
                                    S1 PENDIDIKAN ILMU PENGETAHUAN ALAM</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    7.</td>
                                <td>
                                    S1 ILMU KOMUNIKASI</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    8.</td>
                                <td>
                                    S1 MANAJEMEN</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    9.</td>
                                <td>
                                    S1 AKUNTANSI</td>
                            </tr>
                            </table>
                    </div>
                </div>
                
                            <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            Prodi Pilihan 1 : <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DLPil1" runat="server">
                                <asp:ListItem>Pilihan I</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK ELEKTRO</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>D3 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK SIPIL</asp:ListItem>
                                <asp:ListItem>S1 AGROTEKNOLOGI</asp:ListItem>
                                <%--<asp:ListItem>S1 PETERNAKAN</asp:ListItem>--%>
                                <asp:ListItem>S1 PENDIDIKAN ILMU PENGETAHUAN ALAM</asp:ListItem>
                                <asp:ListItem>S1 EKONOMI PEMBANGUNAN</asp:ListItem>
                                <asp:ListItem>D3 AKUNTANSI</asp:ListItem>
                                <asp:ListItem>S1 ILMU ADMINISTRASI NEGARA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA INGGRIS</asp:ListItem>
                                <asp:ListItem>S1 HUKUM</asp:ListItem>
                                <asp:ListItem>S1 ILMU KOMUNIKASI</asp:ListItem>
                                <asp:ListItem>S1 MANAJEMEN</asp:ListItem>
                                <asp:ListItem>S1 AKUNTANSI</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Prodi Pilihan 2 : <span class="style5">*</span></td>
                        <td>
                            <asp:DropDownList ID="DlPil2" runat="server">
                                <asp:ListItem>Pilihan II</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK ELEKTRO</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>D3 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK SIPIL</asp:ListItem>
                                <asp:ListItem>S1 AGROTEKNOLOGI</asp:ListItem>
                                <%--<asp:ListItem>S1 PETERNAKAN</asp:ListItem>--%>
                                <asp:ListItem>S1 PENDIDIKAN ILMU PENGETAHUAN ALAM</asp:ListItem>
                                <asp:ListItem>S1 EKONOMI PEMBANGUNAN</asp:ListItem>
                                <asp:ListItem>D3 AKUNTANSI</asp:ListItem>
                                <asp:ListItem>S1 ILMU ADMINISTRASI NEGARA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA INGGRIS</asp:ListItem>
                                <asp:ListItem>S1 HUKUM</asp:ListItem>
                                <asp:ListItem>S1 ILMU KOMUNIKASI</asp:ListItem>
                                <asp:ListItem>S1 MANAJEMEN</asp:ListItem>
                                <asp:ListItem>S1 AKUNTANSI</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="BtprodiNxt" runat="server" Text="Lanjut &gt;&gt;" 
                                onclick="Button1_Click" />
                            &nbsp;<asp:Label ID="LbMsg" runat="server"></asp:Label>
                            <br />
                
                            Pilihan 
                            pertama dan kedua harus dalam satu kelompok</td>
                    </tr>
                    </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
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
                        <span class="style3">
                            <a href='#' id='keluar' runat='server'>Logout </a>
                        </span>
                    </div>
                </div>              
            </div>
        </div>
    </div>
</asp:Content>
