<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Pribadi.aspx.cs" Inherits="BandingUKT.Pribadi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet"  href="<%= Page.ResolveUrl("~/js/plugins/icheck/skins/minimal/blue.css")%>" type="text/css" />
	<link rel="stylesheet"  href="<%= Page.ResolveUrl("~/js/plugins/datepicker/datepicker.css")%>" type="text/css" /> 
	<link rel="stylesheet"  href="<%= Page.ResolveUrl("~/js/plugins/select2/select2.css")%>" type="text/css" /> 
	<link rel="stylesheet"  href="<%= Page.ResolveUrl("~/js/plugins/simplecolorpicker/jquery.simplecolorpicker.css")%>" type="text/css" />
	<link rel="stylesheet"  href="<%= Page.ResolveUrl("~/js/plugins/timepicker/bootstrap-timepicker.css") %> " type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Pribadi</h1>
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
                                <asp:Label ID="LbMsgPribadi1" runat="server" Text=""></asp:Label>
                            <%--<asp:Button ID="BtnUlangi" class="btn btn-info" runat="server" Text="Perbarui Data"
                                OnClick="BtnUlangi_Click" />--%>
                            <%--&nbsp;<asp:Label ID="LbMsgUpdate1" runat="server" ForeColor="#FF3300" Style="font-size: large"></asp:Label>--%>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Survei Borang Pribadi (Data Borang)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Satus Ayah</label>
                                <asp:DropDownList CssClass="form-control" ID="DlStAyah1" runat="server">
                                    <asp:ListItem Value="-1">Status Ayah</asp:ListItem>
                                    <asp:ListItem>Hidup</asp:ListItem>
                                    <asp:ListItem>Meninggal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pendidikan Terakhir Ayah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendidikanAyah1" runat="server">
                                    <asp:ListItem Value="-1">Pendidikan Ayah</asp:ListItem>
                                    <asp:ListItem Value="1">SD</asp:ListItem>
                                    <asp:ListItem Value="2">SMP</asp:ListItem>
                                    <asp:ListItem Value="4">SMA</asp:ListItem>
                                    <asp:ListItem Value="6">Diploma</asp:ListItem>
                                    <asp:ListItem Value="8">Sarjana (S1)</asp:ListItem>
                                    <asp:ListItem Value="10">Magister (S2)</asp:ListItem>
                                    <asp:ListItem Value="15">Doktor (S3)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pekerjaan Ayah</label>
                                <asp:DropDownList ID="DLKerjaanAyah1" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Pekerjaan Ayah</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Bekerja</asp:ListItem>
                                    <asp:ListItem Value="1">Buruh</asp:ListItem>
                                    <asp:ListItem Value="2">Petani/Nelayan</asp:ListItem>
                                    <asp:ListItem Value="3">Guru Swasta</asp:ListItem>
                                    <asp:ListItem Value="4">Pegawai Swasta Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="5">Karyawan/Wiraswasta/Pedagang</asp:ListItem>
                                    <asp:ListItem Value="6">Pensiunan Swasta</asp:ListItem>
                                    <asp:ListItem Value="7">Purnawirawan/Veteran</asp:ListItem>
                                    <asp:ListItem Value="8">Dosen Swasta</asp:ListItem>
                                    <asp:ListItem Value="9">Pensiunan PNS/ABRI</asp:ListItem>
                                    <asp:ListItem Value="10">PNS Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="11">Guru/Dosen PNS</asp:ListItem>
                                    <asp:ListItem Value="12">Pegawai BUMN/BUMD</asp:ListItem>
                                    <asp:ListItem Value="13">TNI/Polri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Modal Usaha Ayah</label>
                                <asp:DropDownList ID="DLModalAyah1" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Modal Ayah</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Laba Ayah</label>
                                <asp:DropDownList ID="DLLabaAyah1" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Laba Ayah</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Satus Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLStatausIbu1" runat="server">
                                    <asp:ListItem Value="-1">Status Ibu</asp:ListItem>
                                    <asp:ListItem>Hidup</asp:ListItem>
                                    <asp:ListItem>Meninggal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pendidikan Terakhir Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendidikanIbu1" runat="server">
                                    <asp:ListItem Value="-1">Pendidikan Ibu</asp:ListItem>
                                    <asp:ListItem Value="1">SD</asp:ListItem>
                                    <asp:ListItem Value="2">SMP</asp:ListItem>
                                    <asp:ListItem Value="4">SMA</asp:ListItem>
                                    <asp:ListItem Value="6">Diploma</asp:ListItem>
                                    <asp:ListItem Value="8">Sarjana (S1)</asp:ListItem>
                                    <asp:ListItem Value="10">Magister (S2)</asp:ListItem>
                                    <asp:ListItem Value="12">Doktor (S3)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pekerjaan Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLKerjaanIbu1" runat="server">
                                    <asp:ListItem Value="-1">Pekerjaan Ibu</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Bekerja</asp:ListItem>
                                    <asp:ListItem Value="1">Buruh</asp:ListItem>
                                    <asp:ListItem Value="2">Petani/Nelayan</asp:ListItem>
                                    <asp:ListItem Value="3">Guru Swasta</asp:ListItem>
                                    <asp:ListItem Value="4">Pegawai Swasta Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="5">Karyawan/Wiraswasta/Pedagang</asp:ListItem>
                                    <asp:ListItem Value="6">Pensiunan Swasta</asp:ListItem>
                                    <asp:ListItem Value="7">Purnawirawan/Veteran</asp:ListItem>
                                    <asp:ListItem Value="8">Dosen Swasta</asp:ListItem>
                                    <asp:ListItem Value="9">Pensiunan PNS/ABRI</asp:ListItem>
                                    <asp:ListItem Value="10">PNS Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="11">Guru/Dosen PNS</asp:ListItem>
                                    <asp:ListItem Value="12">Pegawai BUMN/BUMD</asp:ListItem>
                                    <asp:ListItem Value="13">TNI/Polri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Modal Usaha Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLModalIbu1" runat="server">
                                    <asp:ListItem Value="-1">Modal Ibu</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Laba Ibu</label>
                                <asp:DropDownList ID="DLLabaIbu1" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Laba Ibu</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
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
                            <asp:Label ID="LbMsgPribadi" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Survei Borang Pribadi (Data Survey)
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Satus Ayah</label>
                                <asp:DropDownList CssClass="form-control" ID="DlStAyah" runat="server">
                                    <asp:ListItem Value="-1">Status Ayah</asp:ListItem>
                                    <asp:ListItem>Hidup</asp:ListItem>
                                    <asp:ListItem>Meninggal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pendidikan Terakhir Ayah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendidikanAyah" runat="server">
                                    <asp:ListItem Value="-1">Pendidikan Ayah</asp:ListItem>
                                    <asp:ListItem Value="1">SD</asp:ListItem>
                                    <asp:ListItem Value="2">SMP</asp:ListItem>
                                    <asp:ListItem Value="4">SMA</asp:ListItem>
                                    <asp:ListItem Value="6">Diploma</asp:ListItem>
                                    <asp:ListItem Value="8">Sarjana (S1)</asp:ListItem>
                                    <asp:ListItem Value="10">Magister (S2)</asp:ListItem>
                                    <asp:ListItem Value="15">Doktor (S3)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pekerjaan Ayah</label>
                                <asp:DropDownList ID="DLKerjaanAyah" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Pekerjaan Ayah</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Bekerja</asp:ListItem>
                                    <asp:ListItem Value="1">Buruh</asp:ListItem>
                                    <asp:ListItem Value="2">Petani/Nelayan</asp:ListItem>
                                    <asp:ListItem Value="3">Guru Swasta</asp:ListItem>
                                    <asp:ListItem Value="4">Pegawai Swasta Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="5">Karyawan/Wiraswasta/Pedagang</asp:ListItem>
                                    <asp:ListItem Value="6">Pensiunan Swasta</asp:ListItem>
                                    <asp:ListItem Value="7">Purnawirawan/Veteran</asp:ListItem>
                                    <asp:ListItem Value="8">Dosen Swasta</asp:ListItem>
                                    <asp:ListItem Value="9">Pensiunan PNS/ABRI</asp:ListItem>
                                    <asp:ListItem Value="10">PNS Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="11">Guru/Dosen PNS</asp:ListItem>
                                    <asp:ListItem Value="12">Pegawai BUMN/BUMD</asp:ListItem>
                                    <asp:ListItem Value="13">TNI/Polri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Modal Usaha Ayah</label>
                                <asp:DropDownList ID="DLModalAyah" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Modal Ayah</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Laba Ayah</label>
                                <asp:DropDownList ID="DLLabaAyah" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Laba Ayah</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Satus Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLStatausIbu" runat="server">
                                    <asp:ListItem Value="-1">Status Ibu</asp:ListItem>
                                    <asp:ListItem>Hidup</asp:ListItem>
                                    <asp:ListItem>Meninggal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pendidikan Terakhir Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPendidikanIbu" runat="server">
                                    <asp:ListItem Value="-1">Pendidikan Ibu</asp:ListItem>
                                    <asp:ListItem Value="1">SD</asp:ListItem>
                                    <asp:ListItem Value="2">SMP</asp:ListItem>
                                    <asp:ListItem Value="4">SMA</asp:ListItem>
                                    <asp:ListItem Value="6">Diploma</asp:ListItem>
                                    <asp:ListItem Value="8">Sarjana (S1)</asp:ListItem>
                                    <asp:ListItem Value="10">Magister (S2)</asp:ListItem>
                                    <asp:ListItem Value="12">Doktor (S3)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Pekerjaan Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLKerjaanIbu" runat="server">
                                    <asp:ListItem Value="-1">Pekerjaan Ibu</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Bekerja</asp:ListItem>
                                    <asp:ListItem Value="1">Buruh</asp:ListItem>
                                    <asp:ListItem Value="2">Petani/Nelayan</asp:ListItem>
                                    <asp:ListItem Value="3">Guru Swasta</asp:ListItem>
                                    <asp:ListItem Value="4">Pegawai Swasta Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="5">Karyawan/Wiraswasta/Pedagang</asp:ListItem>
                                    <asp:ListItem Value="6">Pensiunan Swasta</asp:ListItem>
                                    <asp:ListItem Value="7">Purnawirawan/Veteran</asp:ListItem>
                                    <asp:ListItem Value="8">Dosen Swasta</asp:ListItem>
                                    <asp:ListItem Value="9">Pensiunan PNS/ABRI</asp:ListItem>
                                    <asp:ListItem Value="10">PNS Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="11">Guru/Dosen PNS</asp:ListItem>
                                    <asp:ListItem Value="12">Pegawai BUMN/BUMD</asp:ListItem>
                                    <asp:ListItem Value="13">TNI/Polri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Modal Usaha Ibu</label>
                                <asp:DropDownList CssClass="form-control" ID="DLModalIbu" runat="server">
                                    <asp:ListItem Value="-1">Modal Ibu</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Laba Ibu</label>
                                <asp:DropDownList ID="DLLabaIbu" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">Laba Ibu</asp:ListItem>
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
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
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/plugins/parsley/parsley.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/plugins/icheck/jquery.icheck.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/plugins/datepicker/bootstrap-datepicker.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/plugins/timepicker/bootstrap-timepicker.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/plugins/simplecolorpicker/jquery.simplecolorpicker.js")%>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/plugins/select2/select2.js")%>"></script>
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
