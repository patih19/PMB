<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="alamat.aspx.cs" Inherits="PinSemuntidar.user.WebForm4" EnableEventValidation="false" %>
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
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12">
                <strong><span class="style3">Proses Ke-3 : Alamat</span></strong><br />
                <br />
                <em>isian yang diberitanda * (asterik) wajib diisi :</em>
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            Alamat Rumah <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbAlamat" runat="server" Height="20px" Width="320px"></asp:TextBox><br />
                            <span class="style4">Nama Jalan, no rumah, RT/RW</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Provinsi <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListProv" runat="server" Width="200px">
                            </asp:DropDownList>
                            <asp:CascadingDropDown ID="CascadingDropDownProv" runat="server" Category="id_provinsi"
                            TargetControlID="DropDownListProv" ServicePath="~/web_services/ServiceCS.asmx"
                            ServiceMethod="Prov" PromptText="PROVINSI">
                        </asp:CascadingDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Kabupaten/Kota <span class="style5">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListKab" runat="server">
                            </asp:DropDownList>
                            <asp:CascadingDropDown ID="CascadingDropDownKotakab" runat="server" TargetControlID="DropDownListKab"
                            ServicePath="~/web_services/ServiceCS.asmx" ServiceMethod="Kotakab" ParentControlID="DropDownListProv"
                            LoadingText="LOADING" PromptText="KOTA/KABUPATEN" Category="id_kotakab">
                        </asp:CascadingDropDown>
                            <br />
                            <span class="style4">provinsi terlebih dahulu sebelum memilih kab./kota</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Kode Pos <span class="style5">* </span>
                        </td>
                        <td>
                            <asp:TextBox ID="TbKdPos" runat="server"></asp:TextBox>
                            <br />
                            <span class="style4">Mencari kode pos melalui situs</span> <em><a href="http://kodepos.posindonesia.co.id">
                                http://kodepos.posindonesia.co.id</a></em>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No Telp. Rumah :
                        </td>
                        <td>
                            <asp:TextBox ID="TbTelpRumah" runat="server"></asp:TextBox>
                            <br />
                            <span class="style4">contoh : 0293364519</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No. Handphone <span class="style5">* </span>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="TbNoHp" runat="server"></asp:TextBox>
                            <br />
                            <span class="style4">tambahkan kode area tanpa spasi atau titik<br />
                                contoh : 08729780987</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email :
                        </td>
                        <td>
                            <asp:TextBox ID="TbEmail" runat="server"></asp:TextBox>
                            <br />
                            <span class="style4">contoh: nama@gmail.com
                                <br />
                                bagi yang belum memiliki email, daftar terlebih dahulu</span>
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
                &nbsp;<br />
            </div>
        </div>
    </div>
</asp:Content>
