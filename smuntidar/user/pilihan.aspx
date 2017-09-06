<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="pilihan.aspx.cs" Inherits="smuntidar.user.WebForm10" %>
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
            <div class="col-md-9">
                <strong><span class="style3">Proses Ke-6: Pilihan Program Studi</span></strong><br />
                <br />
                <em>isian yang diberitanda * (asterik) wajib diisi :</em>
                <br />
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
                                <asp:ListItem>S1 EKONOMI PEMBANGUNAN</asp:ListItem>
                                <asp:ListItem>D3 AKUNTANSI</asp:ListItem>
                                <asp:ListItem>S1 ILMU ADMINISTRASI NEGARA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA INGGRIS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Prodi Pilihan 2 :<span class="style5"> *</span> </td>
                        <td>
                            <asp:DropDownList ID="DlPil2" runat="server">
                                <asp:ListItem>Pilihan II</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK ELEKTRO</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>D3 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK SIPIL</asp:ListItem>
                                <asp:ListItem>S1 AGROTEKNOLOGI</asp:ListItem>
                                <asp:ListItem>S1 EKONOMI PEMBANGUNAN</asp:ListItem>
                                <asp:ListItem>D3 AKUNTANSI</asp:ListItem>
                                <asp:ListItem>S1 ILMU ADMINISTRASI NEGARA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA INGGRIS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="BtprodiNxt" runat="server" Text="Lanjut &gt;&gt;" 
                                onclick="Button1_Click" />
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
                        No. Pendaftaran:
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


