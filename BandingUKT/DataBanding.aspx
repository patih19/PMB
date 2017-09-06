<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="DataBanding.aspx.cs" Inherits="BandingUKT.DataBanding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <!-- /.table-responsive -->
                        <asp:GridView ID="GVDataBanding" 
                            CssClass="table table-condensed table-bordered table-striped table-hover" 
                            runat="server">
                        </asp:GridView>
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
