<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="pendidikan.aspx.cs" Inherits="smuntidar.user.WebForm9" %>
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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12">
                <strong><span class="style3">Proses Ke-4 : Latar Belakang Pendidikan</span></strong><br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td colspan="2">
                            <strong>Asal SMA</strong></td>
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
                            SMA/SMA/MA :
                        </td>
                        <td>
                            <asp:TextBox ID="TbSMAAsal" runat="server" Width="240px"></asp:TextBox>
                        </td>
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
                            <asp:DropDownList ID="DropDownList11" runat="server">
                                <asp:ListItem>Jurusan</asp:ListItem>
                                <asp:ListItem>IPA</asp:ListItem>
                                <asp:ListItem>IPS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Lulus Tahun:
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList8" runat="server">
                                <asp:ListItem Value="Tahun">Tahun Lulus</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Nilai Raport</strong></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            isi form nilai rapor berikut sesuai dengan semester, tanda desimal dapat 
                            menggunakan koma atau titik.<br />
                            Untuk angka desimal, gunakan dua digit di belakang koma</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Semester 1 :</strong><br />
                            <table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td rowspan="2">
                                        Mata Pelajaran
                                    </td>
                                    <td colspan="4" class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="text-center">
                                    KKM
                                    </td>
                                    <td class="text-center">
                                    Kognitif
                                    </td>
                                    <td class="text-center">
                                    Afektif
                                    </td>
                                     <td class="text-center">
                                    Psikomotorik
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="KKMBi1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogBi1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekBi1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoBi1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="KKMInggris1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogInggris1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekInggris1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoInggris1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="KKMMtk1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogMtk1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekMtk1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoMtk1" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Semester 2:</strong>
                            <table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td rowspan="2">
                                        Mata Pelajaran
                                    </td>
                                    <td colspan="4" class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="text-center">
                                    KKM
                                    </td>
                                    <td class="text-center">
                                    Kognitif
                                    </td>
                                    <td class="text-center">
                                    Afektif
                                    </td>
                                     <td class="text-center">
                                    Psikomotorik
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="KKMBi2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogBi2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekBi2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoBi2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="KKMInggris2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogInggris2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekInggris2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoInggris2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="KKMMtk2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogMtk2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekMtk2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoMtk2" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Semester 3:</strong><table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td rowspan="2">
                                        Mata Pelajaran
                                    </td>
                                    <td colspan="4" class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="text-center">
                                    KKM
                                    </td>
                                    <td class="text-center">
                                    Kognitif
                                    </td>
                                    <td class="text-center">
                                    Afektif
                                    </td>
                                     <td class="text-center">
                                    Psikomotorik
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="KKMBi3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogBi3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekBi3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoBi3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="KKMInggris3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogInggris3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekInggris3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoInggris3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="KKMMtk3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogMtk3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekMtk3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoMtk3" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Semester 4:</strong><table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td rowspan="2">
                                        Mata Pelajaran
                                    </td>
                                    <td colspan="4" class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="text-center">
                                    KKM
                                    </td>
                                    <td class="text-center">
                                    Kognitif
                                    </td>
                                    <td class="text-center">
                                    Afektif
                                    </td>
                                     <td class="text-center">
                                    Psikomotorik
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="KKMBi4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogBi4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekBi4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoBi4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="KKMInggris4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogInggris4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekInggris4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoInggris4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="KKMMtk4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogMtk4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekMtk4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoMtk4" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <strong>Semester 5:</strong><table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td rowspan="2">
                                        Mata Pelajaran
                                    </td>
                                    <td colspan="4" class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="text-center">
                                    KKM
                                    </td>
                                    <td class="text-center">
                                    Kognitif
                                    </td>
                                    <td class="text-center">
                                    Afektif
                                    </td>
                                     <td class="text-center">
                                    Psikomotorik
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="KKMBi5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogBi5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekBi5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoBi5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="KKMInggris5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogInggris5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekInggris5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoInggris5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="KKMMtk5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="KogMtk5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="AfekMtk5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PsikoMtk5" runat="server" Width="80px">00.00</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                <asp:Button ID="Button2" runat="server" Text="&lt;&lt; Kembali" />
                &nbsp;<asp:Button ID="BtLanjut" runat="server" Text="Lanjut &gt;&gt;" 
                                onclick="BtLanjut_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>

