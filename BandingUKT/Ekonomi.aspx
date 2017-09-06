<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Ekonomi.aspx.cs" Inherits="BandingUKT.Ekonomi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Ekonomi</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg1" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgEkonomi1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Isian Borang Ekonomi (Data Borang)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                    <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata total pendapatan ayah/wali</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendapatanAyah1" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata total pendapatan ayah/wali</asp:ListItem>
                                    <asp:ListItem Value="0">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2"><= Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">&gt;Rp.500.000 - Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="7">&gt;Rp.1 juta - Rp.1,5 juta</asp:ListItem>
                                    <asp:ListItem Value="10">&gt;Rp.1,5 juta - Rp.2juta</asp:ListItem>
                                    <asp:ListItem Value="15">&gt;Rp.2 juta - Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="20">&gt;Rp.2,5 juta - Rp.3 Juta</asp:ListItem>
                                    <asp:ListItem Value="25">&gt;Rp.3 juta - Rp.4 juta</asp:ListItem>
                                    <asp:ListItem Value="30">&gt;Rp.4 juta - Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="35">&gt;Rp.5 juta - 7,5 juta</asp:ListItem>
                                    <asp:ListItem Value="50">&gt;Rp.7,5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata total pendapatan ibu/wali</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendapatanIbu1" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata total pendapatan ibu/wali</asp:ListItem>
                                    <asp:ListItem Value="0">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2"><= Rp.Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">&gt;Rp.500.000 - Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="7">&gt;Rp.1 juta - Rp.1,5 juta</asp:ListItem>
                                    <asp:ListItem Value="10">&gt;Rp.1,5 juta - Rp.2juta</asp:ListItem>
                                    <asp:ListItem Value="15">&gt;Rp.2 juta - Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="20">&gt;Rp.2,5 juta - Rp.3 Juta</asp:ListItem>
                                    <asp:ListItem Value="25">&gt;Rp.3 juta - Rp.4 juta</asp:ListItem>
                                    <asp:ListItem Value="30">&gt;Rp.4 juta - Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="35">&gt;Rp.5 juta - 7,5 juta</asp:ListItem>
                                    <asp:ListItem Value="50">&gt;Rp.7,5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Total hutang kelurga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLHutang1" runat="server">
                                    <asp:ListItem Value="-1">Total hutang kelurga</asp:ListItem>
                                    <asp:ListItem Value="6">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0 - Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.1 juta - Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="3">Rp.10 juta-Rp.50 juta</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.50 juta-Rp.100 juta</asp:ListItem>
                                    <asp:ListItem Value="1">>Rp.100 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Cicilan hutang per bulan</label>
                                <asp:DropDownList CssClass="form-control" ID="DlCicilan1" runat="server">
                                    <asp:ListItem Value="-1">Cicilan hutang per bulan</asp:ListItem>
                                    <asp:ListItem Value="6">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0-Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.500.000-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">Rp.1 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.5 juta-Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="1">>Rp.10 juta</asp:ListItem>
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
                            <asp:Label ID="LbMsgEkonomi" runat="server" Text=""></asp:Label>
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
                                    Rata-rata total pendapatan ayah/wali</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendapatanAyah" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata total pendapatan ayah/wali</asp:ListItem>
                                    <asp:ListItem Value="0">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2"><= Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">&gt;Rp.500.000 - Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="7">&gt;Rp.1 juta - Rp.1,5 juta</asp:ListItem>
                                    <asp:ListItem Value="10">&gt;Rp.1,5 juta - Rp.2juta</asp:ListItem>
                                    <asp:ListItem Value="15">&gt;Rp.2 juta - Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="20">&gt;Rp.2,5 juta - Rp.3 Juta</asp:ListItem>
                                    <asp:ListItem Value="25">&gt;Rp.3 juta - Rp.4 juta</asp:ListItem>
                                    <asp:ListItem Value="30">&gt;Rp.4 juta - Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="35">&gt;Rp.5 juta - 7,5 juta</asp:ListItem>
                                    <asp:ListItem Value="50">&gt;Rp.7,5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata total pendapatan ibu/wali</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendapatanIbu" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata total pendapatan ibu/wali</asp:ListItem>
                                    <asp:ListItem Value="0">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2"><= Rp.Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">&gt;Rp.500.000 - Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="7">&gt;Rp.1 juta - Rp.1,5 juta</asp:ListItem>
                                    <asp:ListItem Value="10">&gt;Rp.1,5 juta - Rp.2juta</asp:ListItem>
                                    <asp:ListItem Value="15">&gt;Rp.2 juta - Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="20">&gt;Rp.2,5 juta - Rp.3 Juta</asp:ListItem>
                                    <asp:ListItem Value="25">&gt;Rp.3 juta - Rp.4 juta</asp:ListItem>
                                    <asp:ListItem Value="30">&gt;Rp.4 juta - Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="35">&gt;Rp.5 juta - 7,5 juta</asp:ListItem>
                                    <asp:ListItem Value="50">&gt;Rp.7,5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Total hutang kelurga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLHutang" runat="server">
                                    <asp:ListItem Value="-1">Total hutang kelurga</asp:ListItem>
                                    <asp:ListItem Value="6">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0 - Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.1 juta - Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="3">Rp.10 juta-Rp.50 juta</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.50 juta-Rp.100 juta</asp:ListItem>
                                    <asp:ListItem Value="1">>Rp.100 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Cicilan hutang per bulan</label>
                                <asp:DropDownList CssClass="form-control" ID="DlCicilan" runat="server">
                                    <asp:ListItem Value="-1">Cicilan hutang per bulan</asp:ListItem>
                                    <asp:ListItem Value="6">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0-Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.500.000-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">Rp.1 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.5 juta-Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="1">>Rp.10 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <asp:Button ID="BtnSave" class="btn btn-success" runat="server" Text="Simpan" OnClick="BtnSave_Click" />
                                <asp:Button ID="BtnUpdate" class="btn btn-success" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
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
