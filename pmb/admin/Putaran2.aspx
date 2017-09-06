<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Putaran2.aspx.cs" Inherits="pmb.admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/DataTables/bootstrap.3.3.6.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/DataTables/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DataTables/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../Scripts/DataTables/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_GVHasilDua').DataTable({
                'iDisplayLength': 100,
                'aLengthMenu': [[100, 200, 300, 400, 500, 600, 700, -1], [100, 200, 300, 400, 500, 600, 700, "All"]],
                language: {
                    search: "Pencarian :",
                    searchPlaceholder: "Ketik Kata Kunci"
                }
            });
        });
    </script>
    <style type="text/css">
        table#ContentPlaceHolder1_GVHasilDua tr:hover { background-color :#d9edf7; }
        th { color:White !important; background-color:rgb(51, 123, 102); }
        table#ContentPlaceHolder1_GVHasilDua tbody tr:nth-child(odd){ background-color :#fff;}
        table#ContentPlaceHolder1_GVHasilDua tbody tr:nth-child(odd){ background-color :#EEF7EE;}
    </style>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container top-main-form" style="min-height: 450px; background-color: rgb(242, 242, 255);
        box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-lg-12">
                <div>
                    <br />
                    <asp:Panel ID="PanelHasilPutaranDua" runat="server">
                        <%--<div class="panel panel-default">
                            <div class="panel-heading ui-draggable-handle">
                                <strong>PENETAPAN HASIL AKHIR PUTARAN II</strong></div>
                            <div class="panel-body">
                                <table class="table-condensed">
                                    <tr>
                                        <td>
                                            Program Studi
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DLProdi" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="DLProdi_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">Program Studi</asp:ListItem>
                                                <asp:ListItem Value="20-201">S1 TEKNIK ELEKTRO</asp:ListItem>
                                                <asp:ListItem Value="21-201">S1 TEKNIK MESIN</asp:ListItem>
                                                <asp:ListItem Value="21-401">D3 TEKNIK MESIN</asp:ListItem>
                                                <asp:ListItem Value="22-201">S1 TEKNIK SIPIL</asp:ListItem>
                                                <asp:ListItem Value="54-211">S1 AGROTEKNOLOGI</asp:ListItem>
                                                <asp:ListItem Value="60-201">S1 EKONOMI PEMBANGUNAN</asp:ListItem>
                                                <asp:ListItem Value="62-401">D3 AKUNTANSI</asp:ListItem>
                                                <asp:ListItem Value="63-201">S1 ILMU ADMINISTRASI NEGARA</asp:ListItem>
                                                <asp:ListItem Value="88-201">S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</asp:ListItem>
                                                <asp:ListItem Value="88-203">S1 PENDIDIKAN BAHASA INGGRIS</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>--%>
                        <asp:Panel ID="PanelAddPeserta" runat="server">
                            <div class="panel panel-default">
                                <div class="panel-heading ui-draggable-handle">
                                    <strong>Input Peserta Tambahan (Afirmasi)</strong></div>
                                <div class="panel-body">
                                    <%--<asp:Button ID="BtnAddPeserta" runat="server" Text="Simpan Peserta" CssClass="btn btn-success"
                                        OnClick="BtnAddPeserta_Click" />--%>
                                    <asp:GridView ID="GVHasilDua" runat="server" CssClass="table table-condensed table-bordered table-striped table-hover"
                                        OnRowDataBound="GVHasilDua_RowDataBound" OnPreRender="GVHasilDua_PreRender">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    I
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnProdi1" runat="server" onclick="BtnProdi1_Click" 
                                                        Text="Pilihan I" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    II
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Button ID="BtnProdi2" runat="server" onclick="BtnProdi2_Click" 
                                                        Text="Pilihan 2" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="panel-footer">
                                </div>
                            </div>
                        </asp:Panel>

                    </asp:Panel>
                    <br />
                </div>
                <br />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
