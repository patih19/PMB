<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Diterima.aspx.cs" Inherits="pmb.admin.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/DataTables/bootstrap.3.3.6.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/DataTables/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DataTables/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../Scripts/DataTables/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_GVHasilDiterima').DataTable({
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
        table#ContentPlaceHolder1_GVHasilDiterima tr:hover { background-color :#d9edf7; }
        th { color:White !important; background-color:rgb(51, 123, 102); }
        table#ContentPlaceHolder1_GVHasilDiterima tbody tr:nth-child(odd){ background-color :#fff;}
        table#ContentPlaceHolder1_GVHasilDiterima tbody tr:nth-child(odd){ background-color :#EEF7EE;}
    </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-main-form" style="min-height: 450px; background-color: rgb(242, 242, 255);
        box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-lg-12">
                <br />
                <asp:Panel ID="PanelAddPeserta" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading ui-draggable-handle">
                            <strong>DATA PESERTA DITERIMA</strong></div>
                        <div class="panel-body">
                            <asp:GridView ID="GVHasilDiterima" runat="server" CssClass="table table-condensed table-bordered table-striped table-hover"
                                OnRowDataBound="GVHasilDiterima_RowDataBound" OnPreRender="GVHasilDiterima_PreRender">
                            </asp:GridView>
                        </div>
                        <div class="panel-footer">
                        </div>
                    </div>
                </asp:Panel>
                <br />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
