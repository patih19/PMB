<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="identity.aspx.cs" Inherits="smuntidar.user.WebForm6" EnableEventValidation="false" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-9">
                <strong><span class="style3">Proses Ke-2 : Identitas Diri</span></strong><br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            Nama :
                        </td>
                        <td>
                            <asp:TextBox ID="TbNama" runat="server" MaxLength="40" Width="240px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Provinsi Tempat Lahir :
                        </td>
                        <td>
                            <asp:DropDownList ID="DLProv" runat="server">
                            </asp:DropDownList>
                            <asp:CascadingDropDown ID="CascadingDropDownProv" runat="server" Category="id_provinsi"
                                TargetControlID="DLProv" ServicePath="~/web_services/ServiceCS.asmx" ServiceMethod="Prov"
                                PromptText="PROVINSI">
                            </asp:CascadingDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Kabupaten/Kota Tempat Lahir :
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
                            Tempat Lahir :
                        </td>
                        <td>
                            <asp:TextBox ID="TBTmpLahir" runat="server" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tanggal lahir :
                        </td>
                        <td>
                            <asp:TextBox ID="TbTglLhir" runat="server" MaxLength="18"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TbTglLhir"
                                Format="yyyy-MM-dd">
                            </asp:CalendarExtender>
                        &nbsp;1989-03-24 (yyyy-mm-dd)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jenis Identitas :
                        </td>
                        <td>
                            <asp:DropDownList ID="DLIdentitas" runat="server">
                                <asp:ListItem>Identitas</asp:ListItem>
                                <asp:ListItem>KTP</asp:ListItem>
                                <asp:ListItem>SIM</asp:ListItem>
                                <asp:ListItem Value="KK">Kartu Keluarga</asp:ListItem>
                                <asp:ListItem>NISN</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nomor identitas :
                        </td>
                        <td>
                            <asp:TextBox ID="TBNoIdentitas" runat="server" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Jenis Kelamin :
                        </td>
                        <td>
                            <asp:RadioButton ID="RbLaki" Checked="true" runat="server" GroupName="gender" Text="Laki-Laki" />
                            <br />
                            <asp:RadioButton ID="RbPerempuan" runat="server" GroupName="gender" Text="Perempuan" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Warga Negara :
                        </td>
                        <td>
                            <asp:RadioButton ID="RbWNI" Checked="true" runat="server" GroupName="warga" Text="Warga Negara Indonesia" />
                            <br />
                            <asp:RadioButton ID="RbWNA" runat="server" GroupName="warga" Text="Warna Negara Asing" />
                            <br />
                            <asp:RadioButton ID="RbWNIK" runat="server" GroupName="warga" Text="Warga Negara Indonesia Keturunan" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Agama :
                        </td>
                        <td>
                            <asp:RadioButton ID="RbIslam" Checked="true" runat="server" GroupName="agama" Text="Islam" />
                            &nbsp;<asp:RadioButton ID="RbProtestan" runat="server" GroupName="agama" Text="Protestan" />
                            &nbsp;<asp:RadioButton ID="RbKatholik" runat="server" GroupName="agama" Text="Katholik" />
                            <br />
                            <asp:RadioButton ID="RbHindu" runat="server" GroupName="agama" Text="Hindu" />
                            &nbsp;<asp:RadioButton ID="RbBudha" runat="server" GroupName="agama" Text="Budha" />
                            &nbsp;<asp:RadioButton ID="RbKonghucu" runat="server" GroupName="agama" Text="Konghucu" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Golongan Darah :
                        </td>
                        <td>
                            <asp:RadioButton ID="RbA" runat="server" Text="A" />
                            &nbsp;<asp:RadioButton ID="RbAB" GroupName="darah" runat="server" Text="AB" />
                            &nbsp;<asp:RadioButton ID="RbB" GroupName="darah" runat="server" Text="B" />
                            &nbsp;<asp:RadioButton ID="RbO" Checked="true" GroupName="darah" runat="server" Text="O" />
                            &nbsp;<asp:RadioButton ID="RbNone" GroupName="darah" runat="server" Text="tidak tahu" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <asp:Button ID="Btlanjut" runat="server" Text="Lanjut &gt;&gt;" OnClick="Btlanjut_Click1" />
                        </td>
                    </tr>
                </table>
                <br />
                &nbsp;</div>
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. Pendaftaran:
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3"><a href='#' id='keluar' runat='server'>Logout </a></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

