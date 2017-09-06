<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Lingkungan.aspx.cs" Inherits="BandingUKT.Lingkungan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Lingkungan</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg1" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgLingkungan1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Basic Fields (Data Borang)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                        <div class="form-group">
                            <label for="validateSelect">
                                Luas taman M<sup>2</sup></label>
                            <asp:DropDownList CssClass="form-control" ID="DLLuasTaman1" runat="server">
                                <asp:ListItem Value="-1">Luas taman</asp:ListItem>
                                <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                <asp:ListItem Value="2">1-5</asp:ListItem>
                                <asp:ListItem Value="3">6-20</asp:ListItem>
                                <asp:ListItem Value="4">21-50</asp:ListItem>
                                <asp:ListItem Value="5">>50</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Pagar</label>
                            <asp:DropDownList CssClass="form-control" ID="DLPagar1" runat="server">
                                <asp:ListItem Value="-1">Pagar</asp:ListItem>
                                <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                <asp:ListItem Value="2">bambu</asp:ListItem>
                                <asp:ListItem Value="3">tembok/berbatasan dengan tetangga</asp:ListItem>
                                <asp:ListItem Value="4">tembok keramik</asp:ListItem>
                                <asp:ListItem Value="5">tralis/besi</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Jalan 
                            masuk dari jalan raya</label>
                            <asp:DropDownList CssClass="form-control" ID="DLJalanMasuk1" runat="server">
                                <asp:ListItem Value="-1">Jalan masuk dari jalan raya</asp:ListItem>
                                <asp:ListItem Value="1">tanah</asp:ListItem>
                                <asp:ListItem Value="2">plester</asp:ListItem>
                                <asp:ListItem Value="3">paving</asp:ListItem>
                                <asp:ListItem Value="4">aspal</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Selokan air</label>
                            <asp:DropDownList CssClass="form-control" ID="DLSelokan1" runat="server">
                                <asp:ListItem Value="-1">Selokan air</asp:ListItem>
                                <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                <asp:ListItem Value="2">tanah</asp:ListItem>
                                <asp:ListItem Value="3">batu bata</asp:ListItem>
                                <asp:ListItem Value="4">plester</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- /.form-group -->
                        <div class="form-group">
                            <asp:Button ID="BtnSave1" class="btn btn-success" runat="server" Text="Simpan" 
                                onclick="BtnSave1_Click" />
                            <asp:Button ID="BtnUpdate1"  class="btn btn-success"  runat="server" 
                                Text="Update" onclick="BtnUpdate1_Click" />
                        </div>
                        </div>
                    </div>
                    <!-- /.portlet-content -->
                </div>
                <!-- /.portlet -->
            </div>
            <!-- /.col -->
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgLingkungan" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Basic Fields (Data Survey)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                        <div class="form-group">
                            <label for="validateSelect">
                                Luas taman M<sup>2</sup></label>
                            <asp:DropDownList CssClass="form-control" ID="DLLuasTaman" runat="server">
                                <asp:ListItem Value="-1">Luas taman</asp:ListItem>
                                <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                <asp:ListItem Value="2">1-5</asp:ListItem>
                                <asp:ListItem Value="3">6-20</asp:ListItem>
                                <asp:ListItem Value="4">21-50</asp:ListItem>
                                <asp:ListItem Value="5">>50</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Pagar</label>
                            <asp:DropDownList CssClass="form-control" ID="DLPagar" runat="server">
                                <asp:ListItem Value="-1">Pagar</asp:ListItem>
                                <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                <asp:ListItem Value="2">bambu</asp:ListItem>
                                <asp:ListItem Value="3">tembok/berbatasan dengan tetangga</asp:ListItem>
                                <asp:ListItem Value="4">tembok keramik</asp:ListItem>
                                <asp:ListItem Value="5">tralis/besi</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Jalan 
                            masuk dari jalan raya</label>
                            <asp:DropDownList CssClass="form-control" ID="DLJalanMasuk" runat="server">
                                <asp:ListItem Value="-1">Jalan masuk dari jalan raya</asp:ListItem>
                                <asp:ListItem Value="1">tanah</asp:ListItem>
                                <asp:ListItem Value="2">plester</asp:ListItem>
                                <asp:ListItem Value="3">paving</asp:ListItem>
                                <asp:ListItem Value="4">aspal</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Selokan air</label>
                            <asp:DropDownList CssClass="form-control" ID="DLSelokan" runat="server">
                                <asp:ListItem Value="-1">Selokan air</asp:ListItem>
                                <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                <asp:ListItem Value="2">tanah</asp:ListItem>
                                <asp:ListItem Value="3">batu bata</asp:ListItem>
                                <asp:ListItem Value="4">plester</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <!-- /.form-group -->
                        <div class="form-group">
                            <asp:Button ID="BtnSave" class="btn btn-success" runat="server" Text="Simpan" 
                                onclick="BtnSave_Click" />
                            <asp:Button ID="BtnUpdate"  class="btn btn-success"  runat="server" 
                                Text="Update" onclick="BtnUpdate_Click" />
                        </div>
                        </div>
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
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/libs/jquery-1.9.1.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/libs/jquery-ui-1.9.2.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/libs/bootstrap.min.js") %>"></script>
 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/parsley/parsley.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/icheck/jquery.icheck.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/datepicker/bootstrap-datepicker.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/timepicker/bootstrap-timepicker.js")%>"></script> 
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/simplecolorpicker/jquery.simplecolorpicker.js")%>"></script>
    <script type="text/javascript"  src="<%= Page.ResolveUrl("~/js/plugins/select2/select2.js")%>"></script> 

    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/App.js") %>"></script>
    <script type="text/javascript">
        $(function () {
            $('.select2-input').select2({
                placeholder: "Select..."
            });

            // Just for the demo
            $('#time-2').val('');
        });

    </script>
</asp:Content>
