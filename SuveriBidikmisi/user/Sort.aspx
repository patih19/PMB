<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="Sort.aspx.cs" Inherits="SuveriBidikmisi.Sort" %>
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
                'ordering': false,
                'iDisplayLength': 500,
                'aLengthMenu': [[500, 600, 700, -1], [500, 600, 700, "All"]],
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
                <h4> Jumlah Lolos Bidikmisi :
                <asp:Label ID="LbLolos" runat="server" Text=""></asp:Label></h4>
            </div>
            <hr />
            <div class="col-md-12">
                <div class="portlet">
                    <%--<div class="portlet-header">
                        <h3>
                            <i class="fa fa-table"></i>Kitchen Sink
                        </h3>
                    </div>--%>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <asp:GridView ID="GVCekInput" CssClass="table table-condensed table-bordered table-striped table-hover"
                            runat="server" OnPreRender="GVCekInput_PreRender" OnRowCreated="GVCekInput_RowCreated"
                            OnRowDataBound="GVCekInput_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Lolos Bidikmisi
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:RadioButton ID="RBLolos" runat="server" AutoPostBack="True" GroupName="LolosBM"
                                            OnCheckedChanged="RBLolos_CheckedChanged" Text="Ya" />
                                        &nbsp;<asp:RadioButton ID="RbTidak" runat="server" AutoPostBack="True" GroupName="LolosBM"
                                            OnCheckedChanged="RbTidak_CheckedChanged" Text="Tidak" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        INPUT
                                    </EditItemTemplate>
                                    <HeaderTemplate>
                                        DATA BORANG
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="BtnOpenBorang" runat="server" OnClick="Button1_Click" OnClientClick="aspnetForm.target='_blank';"
                                            Text="Open" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="LbNPM" CssClass="hidden" runat="server" Text=""></asp:Label>
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
</asp:Content>
