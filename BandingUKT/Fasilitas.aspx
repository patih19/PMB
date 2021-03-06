﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Fasilitas.aspx.cs" Inherits="BandingUKT.Fasilitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Fasilitas</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg1" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgFasilitas1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Isian Borang Fasilitas (Data Borang)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya telepon & pulsa handphone per bulan sekeluarga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTelepon1" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata biaya telepon & pulsa handphone</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.100.000-Rp.200.000</asp:ListItem>
                                    <asp:ListItem Value="6">>Rp.200.000-Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="8">>Rp.500.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya internet per bulan sekeluarga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLInternet1" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata biaya internet per bulan sekeluarga</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.200.000</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.200.000-Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="6">>Rp.500.000-Rp.750.000</asp:ListItem>
                                    <asp:ListItem Value="8">>Rp.750.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <asp:Button ID="BtnSave1" class="btn btn-success" runat="server" Text="Simpan" OnClick="BtnSave1_Click" />
                                <asp:Button ID="BtnUpdate1" class="btn btn-success" runat="server" Text="Update" OnClick="BtnUpdate1_Click" />
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
                            <asp:Label ID="LbMsgFasilitas" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Basic Fields (Data Survey)</h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya telepon & pulsa handphone per bulan sekeluarga</label>
                                        <asp:DropDownList CssClass="form-control" ID="DLTelepon" runat="server">
                                            <asp:ListItem Value="-1">Rata-rata biaya telepon & pulsa handphone</asp:ListItem>
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.100.000</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.100.000-Rp.200.000</asp:ListItem>
                                            <asp:ListItem Value="6">>Rp.200.000-Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="8">>Rp.500.000</asp:ListItem>
                                        </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya internet per bulan sekeluarga</label>
                                        <asp:DropDownList CssClass="form-control" ID="DLInternet" runat="server">
                                            <asp:ListItem Value="-1">Rata-rata biaya internet per bulan sekeluarga</asp:ListItem>
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.200.000</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.200.000-Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="6">>Rp.500.000-Rp.750.000</asp:ListItem>
                                            <asp:ListItem Value="8">>Rp.750.000</asp:ListItem>
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
