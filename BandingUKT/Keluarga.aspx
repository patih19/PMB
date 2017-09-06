<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Keluarga.aspx.cs" Inherits="BandingUKT.Keluarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Keluarga</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">

            <!-- /.col -->
            <div class="col-sm-6">
            <asp:Panel ID="PanelMsg1" runat="server">
                <div class="col-sm-12">
                    <div class="alert alert-success">
                        <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                        <asp:Label ID="LbMsgKel1" runat="server" Text=""></asp:Label>
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
                        <div id="Div2" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah orang serumah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLOrgRumah1" runat="server">
                                    <asp:ListItem Value="-1">Jumah Orang Serumah</asp:ListItem>
                                    <asp:ListItem Value="1">> 5 orang</asp:ListItem>
                                    <asp:ListItem Value="2">5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">4 orang</asp:ListItem>
                                    <asp:ListItem Value="5">3 orang</asp:ListItem>
                                    <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah saudara kandung</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSdrKandung1" runat="server">
                                    <asp:ListItem Value="-1">Jumlah Saudara Kandung</asp:ListItem>
                                    <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                    <asp:ListItem Value="2">5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">4 orang</asp:ListItem>
                                    <asp:ListItem Value="5">3 orang</asp:ListItem>
                                    <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah saudara kandung sedang kuliah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSdrKandungKuliah1" runat="server">
                                    <asp:ListItem Value="-1">Sudara Kandung Kuliah</asp:ListItem>
                                    <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">5 orang</asp:ListItem>
                                    <asp:ListItem Value="5">4 orang</asp:ListItem>
                                    <asp:ListItem Value="7">3 orang</asp:ListItem>
                                    <asp:ListItem Value="10"><= 2 orang</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah saudara kandung sekolah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSdrKandungSekolah1" runat="server">
                                    <asp:ListItem Value="-1">Sudara Sekolah</asp:ListItem>
                                    <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                    <asp:ListItem Value="2">5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">4 orang</asp:ListItem>
                                    <asp:ListItem Value="5">3 orang</asp:ListItem>
                                    <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
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
            <!-- /.col -->
            <div class="col-sm-6">
            <asp:Panel ID="PanelMsg" runat="server">
                <div class="col-sm-12">
                    <div class="alert alert-success">
                        <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                        <asp:Label ID="LbMsgKel" runat="server" Text=""></asp:Label>
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
                                    Jumlah orang serumah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLOrgRumah" runat="server">
                                    <asp:ListItem Value="-1">Jumah Orang Serumah</asp:ListItem>
                                    <asp:ListItem Value="1">> 5 orang</asp:ListItem>
                                    <asp:ListItem Value="2">5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">4 orang</asp:ListItem>
                                    <asp:ListItem Value="5">3 orang</asp:ListItem>
                                    <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah saudara kandung</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSdrKandung" runat="server">
                                    <asp:ListItem Value="-1">Jumlah Saudara Kandung</asp:ListItem>
                                    <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                    <asp:ListItem Value="2">5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">4 orang</asp:ListItem>
                                    <asp:ListItem Value="5">3 orang</asp:ListItem>
                                    <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah saudara kandung sedang kuliah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSdrKandungKuliah" runat="server">
                                    <asp:ListItem Value="-1">Sudara Kandung Kuliah</asp:ListItem>
                                    <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">5 orang</asp:ListItem>
                                    <asp:ListItem Value="5">4 orang</asp:ListItem>
                                    <asp:ListItem Value="7">3 orang</asp:ListItem>
                                    <asp:ListItem Value="10"><= 2 orang</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Jumlah saudara kandung sekolah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSdrKandungSekolah" runat="server">
                                    <asp:ListItem Value="-1">Sudara Sekolah</asp:ListItem>
                                    <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                    <asp:ListItem Value="2">5 orang</asp:ListItem>
                                    <asp:ListItem Value="3">4 orang</asp:ListItem>
                                    <asp:ListItem Value="5">3 orang</asp:ListItem>
                                    <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
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
