<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Perabot.aspx.cs" Inherits="BandingUKT.Perabot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Perabot</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg1" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgPerabot1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Isian Borang Perabot (Data Borang)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang tamu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLBeliMKTamu1" runat="server">
                                    <asp:ListItem Value="-1"> Harga beli meja kursi ruang tamu</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli almari bifet dan sejenisnya</label>
                                <asp:DropDownList CssClass="form-control" ID="DLAlmariBft1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli almari bifet dan sejenisnya</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang tengah/keluarga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMKRuangTengah1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja kursi ruang tengah/keluarga</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang makan</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMKRuangMakan1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja kursi ruang makan</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang teras</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMKRuangTeras1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja kursi ruang teras</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli tempat tidur</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTmpTidur1" runat="server">
                                    <asp:ListItem Value="-1"> Harga beli tempat tidur</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli televisi</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTV1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli televisi</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.0,5 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.0,5 juta-Rp.1,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.1,5 juta-Rp.3 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.3 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli keseluruhan komputer, laptop dan printer</label>
                                <asp:DropDownList CssClass="form-control" ID="DLKomp1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli keseluruhan komputer, laptop dan printer</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli keseluruhan gas,oven & perabot dapur</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPerabotDapur1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli keseluruhan gas,oven & perabot dapur</asp:ListItem>
                                    <asp:ListItem Value="1">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="2">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.5 juta-Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.10 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja rias</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMejaRias1" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja rias</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <asp:Button ID="BtnSave1" class="btn btn-success" runat="server" Text="Simpan" OnClick="BtnSave1_Click" />
                                <asp:Button ID="BtnUpdate1" class="btn btn-success" runat="server" Text="Update"
                                    OnClick="BtnUpdate1_Click" />
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
                            <asp:Label ID="LbMsgPerabot" runat="server" Text=""></asp:Label>
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
                                    Harga beli meja kursi ruang tamu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLBeliMKTamu" runat="server">
                                    <asp:ListItem Value="-1"> Harga beli meja kursi ruang tamu</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli almari bifet dan sejenisnya</label>
                                <asp:DropDownList CssClass="form-control" ID="DLAlmariBft" runat="server">
                                    <asp:ListItem Value="-1">Harga beli almari bifet dan sejenisnya</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang tengah/keluarga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMKRuangTengah" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja kursi ruang tengah/keluarga</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang makan</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMKRuangMakan" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja kursi ruang makan</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja kursi ruang teras</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMKRuangTeras" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja kursi ruang teras</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli tempat tidur</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTmpTidur" runat="server">
                                    <asp:ListItem Value="-1"> Harga beli tempat tidur</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli televisi</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTV" runat="server">
                                    <asp:ListItem Value="-1">Harga beli televisi</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.0,5 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.0,5 juta-Rp.1,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.1,5 juta-Rp.3 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.3 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli keseluruhan komputer, laptop dan printer</label>
                                <asp:DropDownList CssClass="form-control" ID="DLKomp" runat="server">
                                    <asp:ListItem Value="-1">Harga beli keseluruhan komputer, laptop dan printer</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli keseluruhan gas,oven & perabot dapur</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPerabotDapur" runat="server">
                                    <asp:ListItem Value="-1">Harga beli keseluruhan gas,oven & perabot dapur</asp:ListItem>
                                    <asp:ListItem Value="1">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="2">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.5 juta-Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.10 juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Harga beli meja rias</label>
                                <asp:DropDownList CssClass="form-control" ID="DLMejaRias" runat="server">
                                    <asp:ListItem Value="-1">Harga beli meja rias</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
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
