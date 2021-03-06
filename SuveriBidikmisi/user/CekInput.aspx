﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="CekInput.aspx.cs" Inherits="SuveriBidikmisi.CekInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/libs/jquery-1.11.2.js") %>"></script>

    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/libs/bootstrap.min.js") %>"></script>
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datatables/jquery.dataTables.min.js")%>"></script>
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datatables/dataTables.bootstrap.min.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datatables/DT_bootstrap.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/tableCheckable/jquery.tableCheckable.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/icheck/jquery.icheck.min.js")%>"></script> 

    <script type="text/jscript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_GVCekInput').DataTable({
                'iDisplayLength': 100,
                'aLengthMenu': [[100, 200, 300, 400, 500, 600, 700, -1], [100, 200, 300, 400, 500, 600, 700, "All"]],
                language: {
                    search: "Pencarian :",
                    searchPlaceholder: "Ketik Kata Kunci"
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Monitor Input</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <div class="col-md-12">
                <div class="portlet">
                    <%--<div class="portlet-header">
                        <h3>
                            <i class="fa fa-table"></i>Kitchen Sink
                        </h3>
                    </div>--%>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <asp:GridView ID="GVCekInput" 
                            CssClass="table table-condensed table-bordered table-striped table-hover" 
                            runat="server" onprerender="GVCekInput_PreRender">
                            <Columns>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        INPUT
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        INPUT
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Input" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.portlet-content -->
                </div>
                <!-- /.portlet -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /#content-container -->



    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/App.js") %>"></script>
</asp:Content>
