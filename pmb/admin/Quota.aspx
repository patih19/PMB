<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Quota.aspx.cs" Inherits="pmb.admin.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/DataTables/bootstrap.3.3.6.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/DataTables/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DataTables/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../Scripts/DataTables/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(document).ready(function () {
            $('#TblQuota').DataTable({
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
        table#TblQuota tr:hover { background-color :#d9edf7; }
        th { color:White !important; background-color:rgb(51, 123, 102); }
        table#TblQuota tbody tr:nth-child(odd){ background-color :#fff;}
        table#TblQuota tbody tr:nth-child(odd){ background-color :#EEF7EE;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-main-form" style="min-height: 450px; background-color: rgb(242, 242, 255); box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-lg-12">
                <br />
                <div class="panel panel-default">
                    <div class="panel-heading ui-draggable-handle">
                        <strong>QUOTA SM</strong></div>
                    <div class="panel-body">
                        <br />
                        <asp:Repeater ID="RepeaterDataUKT" runat="server" OnItemDataBound="RepeaterDataUKT_ItemDataBound1">
                            <HeaderTemplate>
                                <table class=" table table-condensed table-bordered" style="page-break-before: always"
                                    id="TblQuota">
                                    <thead>
                                        <tr>
                                            <th>
                                                No.
                                            </th>
                                            <th>
                                                Kode Program Studi
                                            </th>
                                            <th>
                                                Program Studi
                                            </th>
                                            <th>
                                                Quota
                                            </th>
                                            <th>
                                                Tahun
                                            </th>
                                            <th>
                                                Save
                                            </th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="page-break-inside: avoid !important">
                                    <td>
                                        <asp:Label ID="LblNomerDaftar" runat="server" Text='<%# Eval("No") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("Kode Prodi") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Program Studi") %>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TbQuota" runat="server" Text='<%# Eval("Quota") %>'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Tahun") %>' />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnSave" runat="server" Text="simpan" OnClick="Button_Click" CommandArgument='<%#Eval("No") + "," + Eval("Kode Prodi") + "," + Eval("Tahun")+ "," + Eval("Quota") %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="panel-footer">
                        <strong>Jumlah Quota : </strong><strong>
                            <asp:Label ID="LbQuota" runat="server" Text=""></asp:Label></strong>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
