<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="pendidikan.aspx.cs" Inherits="smmuntidar.user.WebForm15" EnableEventValidation="false" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

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
            color: #000000;
        }
        .style6
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

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
                <strong><span class="style6">Tahap Ke-4 : Latar Belakang Pendidikan</span></strong><br 
                    class="style5" />
                <br class="style5" />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td colspan="2">
                            <strong>Asal SMA / SMK</strong></td>
                    </tr>
                    <tr>
                        <td>
                            Provinsi :</td>
                        <td>
                            <asp:DropDownList ID="DLProv" runat="server">
                            </asp:DropDownList>
                            <asp:CascadingDropDown ID="CascadingDropDownProv2" runat="server" Category="id_provinsi"
                                TargetControlID="DLProv" ServicePath="~/web_services/ServiceCS.asmx" ServiceMethod="Prov"
                                PromptText="PROVINSI">
                            </asp:CascadingDropDown>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Kabupaten / Kota :
                        </td>
                        <td>
                            <asp:DropDownList ID="DDListKab" runat="server">
                            </asp:DropDownList>
                            <asp:CascadingDropDown ID="CascadingDDKotakab" runat="server" TargetControlID="DDListKab"
                                ServicePath="~/web_services/ServiceCS.asmx" ServiceMethod="Kotakab" ParentControlID="DLProv"
                                LoadingText="LOADING" PromptText="KOTA/KABUPATEN" Category="id_kotakab">
                            </asp:CascadingDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sekolah :</td>
                        <td>
                            <asp:DropDownList ID="DLJenisSekolah" runat="server">
                                <asp:ListItem>Pilih Sekolah</asp:ListItem>
                                <asp:ListItem>SMA</asp:ListItem>
                                <asp:ListItem>SMK</asp:ListItem>
                                <asp:ListItem>MA</asp:ListItem>
                                <asp:ListItem>MAK</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sekolah Asal: 
                        </td>
                        <td>
                            <asp:TextBox ID="TbSMAAsal" runat="server" Width="240px"></asp:TextBox><br />
                             <span class="style4">contoh: <em>SMA Negeri 5 Surakarta</em></span></td>
                    </tr>
                    <tr>
                        <td>
                            Status Sekolah:
                        </td>
                        <td>
                            <asp:DropDownList ID="DLStatusSkolah" runat="server">
                                <asp:ListItem>Status</asp:ListItem>
                                <asp:ListItem>Negeri</asp:ListItem>
                                <asp:ListItem>Swasta</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jurusan:</td>
                        <td>
                            <asp:DropDownList ID="DLJurusan" runat="server">
                                <asp:ListItem>Jurusan</asp:ListItem>
                                <asp:ListItem>IPA</asp:ListItem>
                                <asp:ListItem>IPS</asp:ListItem>
                                <asp:ListItem>Bahasa</asp:ListItem>
                                <asp:ListItem>----------</asp:ListItem>
                                <asp:ListItem>Bangunan</asp:ListItem>
                                <asp:ListItem>Elektro</asp:ListItem>
                                <asp:ListItem>TKJ</asp:ListItem>
                                <asp:ListItem>Rekayasa Perangkat Lunak</asp:ListItem>
                                <asp:ListItem>Listrik</asp:ListItem>
                                <asp:ListItem>Mesin</asp:ListItem>
                                <asp:ListItem>Otomotif</asp:ListItem>
                                <asp:ListItem>Akuntansi</asp:ListItem>
                                <asp:ListItem>Administrasi Perkantoran</asp:ListItem>
                                <asp:ListItem>Pemasaran</asp:ListItem>
                                <asp:ListItem>Tata Boga</asp:ListItem>
                                <asp:ListItem>Perhotelan</asp:ListItem>
                                <asp:ListItem>Kecantikan</asp:ListItem>
                                <asp:ListItem>Tata Busana</asp:ListItem>
                                <asp:ListItem>Lain-lain</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tahun Lulus:
                        </td>
                        <td>
                            <asp:DropDownList ID="DLTahunLls" runat="server">
                                <asp:ListItem Value="Tahun">Tahun Lulus</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
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
            </div>
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SMM-UNTIDAR
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
