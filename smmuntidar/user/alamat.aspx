<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="alamat.aspx.cs" Inherits="smmuntidar.user.WebForm13" EnableEventValidation="false" %>
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
                <strong><span class="style3">Tahap Ke-3 : Alamat</span></strong><br />
                <br />
                <em>isian yang diberitanda * (asterik) wajib diisi :</em>
                <br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            Alamat Rumah <span class="style5">*</span>
                        </td>
                        <td class="text-left">
                            <asp:TextBox ID="TbAlamat" runat="server" Height="50px" Width="320px" 
                                TextMode="MultiLine"></asp:TextBox><br />
                            <span class="style4">Nama Jalan, no rumah, RT/RW, Kecamatan</span> </td>
                    </tr>
                    <tr>
                        <td>
                            Provinsi <span class="style5">*</span>
                        </td>
                        <td class="text-left">
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
                        <td class="text-left">
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
                        <td class="text-left">
                            <asp:TextBox ID="TbKdPos" runat="server" MaxLength="6"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtenderKTP" runat="server" Enabled="True"
                                TargetControlID="TbKdPos" FilterType="Numbers" FilterInterval="6">
                            </asp:FilteredTextBoxExtender>
                            <br />
                            <span class="style4">Mencari kode pos melalui situs</span>
                            <asp:HyperLink ID="LnkKDPOS" runat="server" Target="_blank">http://kodepos.posindonesia.co.id</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No Telp. Rumah :
                        </td>
                        <td class="text-left">
                            <asp:TextBox ID="TbTelpRumah" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True"
                                TargetControlID="TbTelpRumah" FilterType="Numbers" FilterInterval="10">
                            </asp:FilteredTextBoxExtender>
                            <br />
                            <span class="style4">contoh : 0293364519</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            No. Handphone <span class="style5">* </span>&nbsp;</td>
                        <td class="text-left">
                            <asp:TextBox ID="TbNoHp" runat="server" MaxLength="12"></asp:TextBox>
                           <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True"
                                TargetControlID="TbNoHp" FilterType="Numbers" FilterInterval="12">
                            </asp:FilteredTextBoxExtender>
                            <br />
                            <span class="style4">contoh : 08729780987</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email <span class="style5">*</span>:
                        </td>
                        <td class="text-left">
                            <asp:TextBox ID="TbEmail" runat="server" MaxLength="200"></asp:TextBox>
                            <br />
                            <span class="style4">contoh: udin@gmail.com
                                <br />
                                bagi yang belum memiliki email, daftar terlebih dahulu</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="text-left">
                            <br />
                            <asp:Button ID="BtLanjut" runat="server" Text="Lanjut &gt;&gt;" 
                                onclick="BtLanjut_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;<br />
            </div>
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. 
                        Pendaftaran :
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
