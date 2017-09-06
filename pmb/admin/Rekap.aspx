<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Rekap.aspx.cs" Inherits="pmb.admin.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/DataTables/bootstrap.3.3.6.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-main-form" style="min-height: 450px; background-color: rgb(242, 242, 255); box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-lg-12">
            <br />
                <asp:Repeater ID="RepeaterDiterima" runat="server" OnItemDataBound="RepeaterDiterima_ItemDataBound">
                    <HeaderTemplate>
                        <table class=" table table-condensed table-bordered table-striped" style="page-break-before: always">
                            <tr>
                                <th>
                                    No.
                                </th>
                                <th>
                                    Program Studi
                                </th>
                                <th>
                                    Quota
                                </th>
                                <th>
                                    Jumlah
                                </th>
                                <th>
                                    Kurang
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="page-break-inside: avoid !important">
                            <td>
                                <asp:Label ID="LblNo" runat="server" Text='<%# Eval("No") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lbProdi" runat="server" Text='<%# Eval("Program Studi") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LbQuota" runat="server" Text='<%# Eval("Quota") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LbDiterima" runat="server" Text='<%# Eval("Jumlah") %>' />
                            </td>
                            <td>
                                <asp:Label ID="LbKurang" runat="server" Text='<%# Eval("Kurang") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <strong>Jumlah Diterima : </strong> <strong><asp:Label ID="LbQuotaDiterima" runat="server" Text=""></asp:Label></strong> <br />
                <p></p>
            </div>
        </div>
    </div>
</asp:Content>
