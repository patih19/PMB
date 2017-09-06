<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Putaran1.aspx.cs" Inherits="pmb.admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/DataTables/bootstrap.3.3.6.css" rel="stylesheet" type="text/css" />
    <link href="../Scripts/DataTables/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DataTables/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="../Scripts/DataTables/dataTables.bootstrap.min.js" type="text/javascript"></script>
    <script type="text/jscript">
        $(document).ready(function () {
            $('#ContentPlaceHolder1_GVHasilSatu').DataTable({
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
        table#ContentPlaceHolder1_GVHasilSatu tr:hover { background-color :#d9edf7; }
        th { color:White !important; background-color:rgb(51, 123, 102); }
        table#ContentPlaceHolder1_GVHasilSatu tbody tr:nth-child(odd){ background-color :#fff;}
        table#ContentPlaceHolder1_GVHasilSatu tbody tr:nth-child(odd){ background-color :#EEF7EE;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-main-form" style="min-height: 450px; background-color: rgb(242, 242, 255);
        box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
        <div class="row">
            <div class="col-xs-12 col-md-12 col-lg-12">
                <div>
                    <br />
                    <asp:Panel ID="PanelSortPuatarnSatu" runat="server">
                        <div class="panel panel-default">
                            <div class="panel-heading ui-draggable-handle">
                                <strong>PUTARAN I</strong></div>
                            <div class="panel-body">
                                Dalam tahap ini sistem akan menentukan peserta yang diterima sesuai dengan 
                                jumlah quota tiap program studi.</div>
                            <div class="panel-footer">
                                &nbsp;<asp:Button ID="BtnSort" runat="server" Text="Hitung" OnClick="BtnSort_Click"
                                    CssClass="btn btn-primary"  onclientclick="return confirm('Quota PENERIMAAN Sudah Ditetapkan ?');"/>
                                <asp:Label ID="LbSortI" runat="server"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                   
<%--                    <asp:Panel ID="PanelHasilPutaranSatu" runat="server">
                        <div class="panel panel-default">
                            <div class="panel-heading ui-draggable-handle">
                            <strong>PENETAPAN HASIL AKHIR PUTARAN I </strong> 
                            </div>
                            <div class="panel-body">
                                <asp:Panel ID="PanelJadwal" runat="server">
                                    <asp:GridView ID="GVHasilSatu" runat="server" CssClass="table table-condensed table-bordered table-striped table-hover"
                                        OnRowDataBound="GVJadwal_RowDataBound" OnPreRender="GVJadwal_PreRender">
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                            <div class="panel-footer">
                            </div>
                        </div>
                    </asp:Panel>--%>
                    <br />
                </div>
                <br />
            </div>
            <br />
        </div>
    </div>
</asp:Content>
