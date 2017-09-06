<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="dokumen.aspx.cs" Inherits="SuveriBidikmisi.dokumen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--Import Google Icon Font-->
    <link href='http://fonts.googleapis.com/css?family=Lato&subset=latin,latin-ext' rel='stylesheet'
        type='text/css'>
    <!--Import Multi Step Indicator css-->
    <link href="//stepform.cidcode.net/assets/css/gsi-step-indicator.min.css" rel="stylesheet" />
    <!--Import  Step Form Wizard css-->
    <link href="//stepform.cidcode.net/assets/css/tsf-step-form-wizard.min.css" rel="stylesheet" />
    <!--Import  demo css-->
    <link href="//stepform.cidcode.net/assets/css/demo.min.css" rel="stylesheet" />
    <%--<link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" /> --%>
    <!--Plugin for validation-->
    <link href="//stepform.cidcode.net/assets/plugin/parsley/css/parsley.css" rel="stylesheet" />
    <link href="../css/rapor.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/libs/jquery-1.9.1.min.js") %>"></script>
    <script type="text/javascript">
        $(".panel-heading").addClass("collapsed");
    </script>
    <style type="text/css">
        .accordion-toggle:after
        {
            /* symbol for "opening" panels */
            font-family: 'FontAwesome';
            content: "\f077";
            float: right;
            color: inherit;
        }
        .panel-heading.collapsed .accordion-toggle:after
        {
            /* symbol for "collapsed" panels */
            content: "\f078";
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Dokumen</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
<%--            <asp:Panel ID="PanelMsg" runat="server">
                <div class="col-sm-12">
                    <div class="alert alert-success">
                        <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                        <h4>
                            <asp:Label ID="LbMsgPerabot" runat="server" Text=""></asp:Label></h4>
                        <asp:Button ID="BtnUlangi" class="btn btn-info" runat="server" Text="Perbarui Data"
                            OnClick="BtnUlangi_Click" />
                        &nbsp;<asp:Label ID="LbMsgUpdate" runat="server" ForeColor="#FF3300" Style="font-size: large"></asp:Label>
                    </div>
                </div>
            </asp:Panel>--%>
            <div class="tsf-container ">
                <div class="col-md-12 col-sm-12">
                    <div class="alert alert-info" role="alert" id="success_message">
                        &nbsp;Ketentuan unggah :<br />
                        <ol>
                            <li>Format file dalam bentuk image dengan jenis gambar jpg, png atau jpeg.</li>
                            <li>Besar ukuran file antara 40 - 500 Kb.</li>
                            <li>File harus berwarna full color tidak diperkenankan berwarna hitam putih/grayscale.</li>
                            <li>Nama file maximal 30 karakter.</li>
                        </ol>
                    </div>
                    <div class="panel-group wrap" id="bs-collapse">
                        <!-- Semester 1 -->
                        <div class="panel">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#one">Foto Rumah</a>
                                </div>
                            </div>
                            <div id="one" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <%--<input type="file" id="exampleInputFile">--%>
                                                <asp:FileUpload ID="FpFotoRumah" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <%--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>--%>
                                                <asp:Button ID="BtnUpFotoRumah" CssClass="btn btn-warning" OnClick="BtnUpFotoRumah_Click"
                                                            runat="server" Text="Unggah" />
                                                <asp:Panel ID="PanelFotoRumah" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="accordion">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseOne">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseOne" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImgRumah" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.Collapse  -->
                        </div>
                        <!-- end of panel -->
                        <!-- Semester 2 -->
                        <div class="panel">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#two">Ruang Tamu </a>
                                </h4>
                            </div>
                            <div id="two" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <%--<input type="file" id="exampleInputFile">--%>
                                                <asp:FileUpload ID="FpRuangTamu" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <%--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>--%>
                                                <asp:Button ID="BtnUpRuangTamu" runat="server" OnClick="BtnUpRuangTamu_Click" CssClass="btn btn-warning"
                                                            Text="Unggah" />
                                                <asp:Panel ID="PanelRuangTamu" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="accordion">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseTwo">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseTwo" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImgRuangTamu" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end of panel -->
                        <!-- Semester 3 -->
                        <div class="panel">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#three">Ruang Tengah</a>
                                </h4>
                            </div>
                            <div id="three" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <%--<input type="file" id="exampleInputFile">--%>
                                                <asp:FileUpload ID="FpRuangTengah" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <%--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>--%>
                                                <asp:Button ID="BtnUpRuangTengah" runat="server" OnClick="BtnUpRuangTengah_Click" CssClass="btn btn-warning"
                                                            Text="Unggah" />
                                                <asp:Panel ID="PanelRuangTengah" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="accordion">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseThree">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseThree" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImgRuangTengah" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end of panel -->
                        <!-- Semester 4 -->
                        <div class="panel">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#four">Kamar Tidur</a>
                                </h4>
                            </div>
                            <div id="four" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <%--<input type="file" id="exampleInputFile">--%>
                                                <asp:FileUpload ID="FpKamarTidur" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <%--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>--%>
                                                <asp:Button ID="BtnUpKamarTidur" runat="server" OnClick="BtnUpKamarTidur_Click" CssClass="btn btn-warning"
                                                            Text="Unggah" />
                                                <asp:Panel ID="PanelKamarTidur" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="accordion">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseFour">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseFour" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImgKamarTidur" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end of panel -->
                        <!-- Semester 5 -->
                        <div class="panel">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#five">Dapur</a>
                                </h4>
                            </div>
                            <div id="five" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <%--<input type="file" id="exampleInputFile">--%>
                                                <asp:FileUpload ID="FpDapur" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <%--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>--%>
                                                <asp:Button ID="BtnUpDapur" runat="server" OnClick="BtnUpDapur_Click" CssClass="btn btn-warning"
                                                            Text="Unggah" />
                                                <asp:Panel ID="PanelDapur" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="Div2">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseFive">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseFive" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImageDapur" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end of panel -->
                        <!-- Semester 6 -->
                        <div class="panel">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#six">Kamar Mandi</a>
                                </h4>
                            </div>
                            <div id="six" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <%--<input type="file" id="exampleInputFile">--%>
                                                <asp:FileUpload ID="FpKamarMandi" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <%--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>--%>
                                                <asp:Button ID="BtnKamarMandi" runat="server" OnClick="BtnKamarMandi_Click" CssClass="btn btn-warning"
                                                            Text="Unggah" />
                                                <asp:Panel ID="PanelKamarMandi" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="Div5">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseSix">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseSix" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImageKamarMandi" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end of panel -->
                        <!-- Semester 7 -->
                        <%--<div class="panel">
                            <div class="panel-heading">
                                <h4 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#" href="#seven">Gaji/Penghasilan</a>
                                </h4>
                            </div>
                            <div id="seven" class="panel-collapse collapse">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <!-- Upload Rapot -->
                                                <!--<input type="file" id="exampleInputFile">-->
                                                <asp:FileUpload ID="FpGaji" runat="server" />
                                                <p class="help-block">
                                                </p>
                                                <!--<button type="submit" class="btn btn-warning">
                                            Upload <span class="glyphicon glyphicon-send"></span>
                                        </button>-->
                                                <asp:Button ID="BtnGaji" runat="server" OnClick="BtnGaji_Click" CssClass="btn btn-warning"
                                                            Text="Unggah" />
                                                <asp:Panel ID="PanelGaji" runat="server">
                                                    <hr>
                                                    <!-- Rapot Image -->
                                                    <div class="panel-group" id="Div8">
                                                        <div class="panel panel-info">
                                                            <div class="panel-heading" data-toggle="collapse" data-parent="#accordion" data-target="#collapseSeven">
                                                                <h4 class="panel-title accordion-toggle">
                                                                    Open Picture
                                                                </h4>
                                                            </div>
                                                            <div id="collapseSeven" class="panel-collapse collapse">
                                                                <p>
                                                                </p>
                                                                <asp:Image ID="ImageGaji" class="img-responsive" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <!-- end of panel -->
                    </div>
                    <!-- end of #bs-collapse  -->
                </div>
                <!-- END CONTENT-->
            </div>
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
