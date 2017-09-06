<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="Raport.aspx.cs" Inherits="smuntidar.user.WebForm2" EnableEventValidation="false" %>
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
            <div class="col-md-9">
                <strong><span class="style3">Proses Ke-4b : Nilai Raport Per Semester</span></strong><br />
                <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            <strong>Nilai Raport</strong></td>
                    </tr>
                    <tr>
                        <td>
                            Isi form nilai rapor berikut sesuai semester. Contoh pengisian nilai sebagai 
                            berikut:<br />
                            <strong>87.50 ( gunakan titik untuk meggantikan koma pada nilai raport)</strong></td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Semester 1 :</strong><br />
                            <table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td>
                                        Mata Pelajaran
                                    </td>
                                    <td class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="TbBi1" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            TargetControlID="TbBi1" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="TbInggris1" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
                                            runat="server" TargetControlID="TbInggris1" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>

                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="TbMtk1" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
                                            runat="server" TargetControlID="TbMtk1" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Semester 2:</strong>
                            <table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td >
                                        Mata Pelajaran
                                    </td>
                                    <td class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="TbBi2" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
                                            runat="server" TargetControlID="TbBi2" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="TbInggris2" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
                                            runat="server" TargetControlID="TbInggris2" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="TbMtk2" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
                                            runat="server" TargetControlID="TbMtk2" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Semester 3:</strong><table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td>
                                        Mata Pelajaran
                                    </td>
                                    <td class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="TbBi3" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
                                            runat="server" TargetControlID="TbBi3" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="TbInggris3" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
                                            runat="server" TargetControlID="TbInggris3" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="TbMtk3" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
                                            runat="server" TargetControlID="TbMtk3" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Semester 4:</strong><table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td >
                                        Mata Pelajaran
                                    </td>
                                    <td class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="TbBi4" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
                                            runat="server" TargetControlID="TbBi4" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="TbInggris4" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
                                            runat="server" TargetControlID="TbInggris4" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="TbMtk4" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" 
                                            runat="server" TargetControlID="TbMtk4" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Semester 5:</strong><table class="table-bordered table-condensed" align="center">
                                <tr>
                                    <td >
                                        Mata Pelajaran
                                    </td>
                                    <td class="text-center">
                                        Nilai
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Bahasa Indonesia </td>
                                    <td>
                                        <asp:TextBox ID="TbBi5" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" 
                                            runat="server" TargetControlID="TbBi5" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td>Bahasa Inggris</td>
                                    <td>
                                        <asp:TextBox ID="TbInggris5" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" 
                                            runat="server" TargetControlID="TbInggris5" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>Matematika</td>
                                    <td>
                                        <asp:TextBox ID="TbMtk5" runat="server" Width="80px" MaxLength="5">00.00</asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" 
                                            runat="server" TargetControlID="TbMtk5" FilterType="Custom,Numbers" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                   
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
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

