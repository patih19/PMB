<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="Pribadi.aspx.cs" Inherits="SuveriBidikmisi.Pribadi" %>
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
            <asp:Panel ID="PanelMsg" runat="server">
                <div class="col-sm-12">
                    <div class="alert alert-success">
                        <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                        <h4>
                            <asp:Label ID="LbMsgPribadi" runat="server" Text=""></asp:Label></h4>
                        <asp:Button ID="BtnUlangi" class="btn btn-info" runat="server" Text="Perbarui Data"
                            OnClick="BtnUlangi_Click" />        
                        &nbsp;<asp:Label ID="LbMsgUpdate" runat="server" ForeColor="#FF3300" 
                            style="font-size: large"></asp:Label>
                    </div>
                </div>
            </asp:Panel>

            <div class="col-sm-6">
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Isian Borang Pribadi
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="validate-enhanced" class="form parsley-form">
                        <div class="form-group">
                            <label for="validateSelect">
                                Nama</label> 
                            <asp:Label ID="LbNama" CssClass=" form-control" runat="server" Text="Label" 
                                Enabled="False"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Jenis Kelamin</label>
                            <asp:Label ID="LbGender" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Tempat Lahir</label>
                            <asp:Label ID="LbTempatLahir" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Tanggal Lahir</label>
                            <asp:Label ID="LbTanggalLahir" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Alamat Lengkap</label>                            
                            <asp:TextBox ID="TbAlamat" CssClass=" form-control" TextMode="MultiLine" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                No. Hp</label>
                            <asp:Label ID="LbHp" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Telp. Rumah</label>
                            <asp:Label ID="LbTelpRumah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Email</label>
                            <asp:Textbox ID="LbEmail" CssClass=" form-control" runat="server" Enabled="false"></asp:Textbox>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Nama Ayah</label>
                            <asp:Label ID="LbNamaAyah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Satus Ayah</label>
                            <asp:Label ID="LbStatusAyah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Pendidikan Terakhir Ayah</label>
                            <asp:Label ID="LbPendidikanAyah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Pekerjaan Ayah</label>
                            <asp:Label ID="LbPekerjaanAyah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Modal Usaha Ayah</label>
                            <asp:Label ID="LbModalUsahaAyah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Laba Ayah</label>
                            <asp:Label ID="LbLabaAyah" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Nama Ibu</label>
                            <asp:Label ID="LbNamaIbu" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Satus Ibu</label>
                            <asp:Label ID="LbStatusIbu" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Pendidikan Terakhir Ibu</label>
                            <asp:Label ID="LbPendidikanIbu" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Pekerjaan Ibu</label>
                            <asp:Label ID="LbPekerjaanIbu" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Modal Usaha Ibu</label>
                            <asp:Label ID="LbModalUsahaIbu" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Laba Ibu</label>
                            <asp:Label ID="LbLabaIbu" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                            <%-- <div class="form-group">
                            <label for="validateSelect"> 
                                Pekerjaan Ayah</label>
                            <select name="select-2" class="form-control select2-input" data-required="true">
                                <option value="">Please Select</option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="select-multi-input">
                                Select2 Multiple Field</label>
                            <select name="select-multi-2" multiple class="form-control select2-input" data-required="true">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                                <option>6</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="date-2">
                                Date Picker</label>
                            <div class="input-group date ui-datepicker">
                                <input id="date-2" name="date-2" class="form-control" type="text" data-required="true">
                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="time-2">
                                Time Picker</label>
                            <div class="input-group bootstrap-timepicker">
                                <input id="time-2" name="time-2" class="form-control ui-timepicker" data-value=""
                                    type="text" data-required="true">
                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="color-2">
                                Color Picker</label>
                            <select id="color-2" name="colorpicker" class="form-control ui-colorpicker" data-required="true">
                                <!-- Colors from Google Calendar -->
                                <option value="">Select</option>
                                <option value="#e5412d">Red</option>
                                <option value="#f0ad4e">Yellow</option>
                                <option value="#428bca">Blue</option>
                                <option value="#5cb85c">Green</option>
                                <option value="#5bc0de">Teal</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>
                                iCheck Checkbox Field</label>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" name="checkbox-2" class="icheck-input" data-mincheck="2">
                                    Option 1
                                </label>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" name="checkbox-2" class="icheck-input" data-mincheck="2">
                                    Option 2
                                </label>
                            </div>
                        </div>
                        <!-- /.form-group -->
                        <div class="form-group">
                            <label>
                                iCheck Radio Field</label>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="radio-2" class="icheck-input" data-required="true">
                                    Option 1
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="radio-2" class="icheck-input" data-required="true">
                                    Option 2
                                </label>
                            </div>
                        </div>--%>

                        </div>
                    </div>
                    <!-- /.portlet-content -->
                </div>
                <!-- /.portlet -->
            </div>
            <!-- /.col -->
            <div class="col-sm-6">
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Survei Borang Pribadi                             
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                        <div class="form-group">
                            <label for="validateSelect">
                                Nama</label> 
                            <asp:Label ID="LbNama2" CssClass=" form-control" runat="server" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Jenis Kelamin</label>
                            <asp:Label ID="LbGender2" CssClass=" form-control" runat="server" Enabled="false"  ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Tempat Lahir</label>
                            <asp:Label ID="LbTempatLahir2" CssClass=" form-control" runat="server" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Tanggal Lahir</label>
                            <asp:Label ID="LbTanggalLahir2" CssClass=" form-control" runat="server" Enabled = "false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Alamat Lengkap</label>                            
                            <asp:TextBox ID="TbAlamat2" CssClass=" form-control" TextMode="MultiLine" Enabled = "false" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                No. Hp</label>
                            <asp:Textbox ID="TbHp2" CssClass=" form-control" runat="server" ></asp:Textbox>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Telp. Rumah</label>
                            <asp:Textbox ID="TbTelpRumah2" CssClass=" form-control" runat="server"   ></asp:Textbox>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Email</label>
                            <asp:Textbox ID="TbEmail2" CssClass=" form-control" runat="server"   ></asp:Textbox>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Nama Ayah</label>
                            <asp:Label ID="LbNamaAyah2" CssClass=" form-control" Enabled="false" runat="server"  ></asp:Label>
                        </div>
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
                                Nama Ibu</label>
                            <asp:Label ID="LbNamaIbu2" CssClass=" form-control" Enabled="false" runat="server" ></asp:Label>
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
                       <%-- <div class="form-group">
                            <label for="validateSelect"> 
                                Pekerjaan Ayah</label>
                            <select name="select-2" class="form-control select2-input" data-required="true">
                                <option value="">Please Select</option>
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="select-multi-input">
                                Select2 Multiple Field</label>
                            <select name="select-multi-2" multiple class="form-control select2-input" data-required="true">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                                <option>6</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="date-2">
                                Date Picker</label>
                            <div class="input-group date ui-datepicker">
                                <input id="date-2" name="date-2" class="form-control" type="text" data-required="true">
                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="time-2">
                                Time Picker</label>
                            <div class="input-group bootstrap-timepicker">
                                <input id="time-2" name="time-2" class="form-control ui-timepicker" data-value=""
                                    type="text" data-required="true">
                                <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="color-2">
                                Color Picker</label>
                            <select id="color-2" name="colorpicker" class="form-control ui-colorpicker" data-required="true">
                                <!-- Colors from Google Calendar -->
                                <option value="">Select</option>
                                <option value="#e5412d">Red</option>
                                <option value="#f0ad4e">Yellow</option>
                                <option value="#428bca">Blue</option>
                                <option value="#5cb85c">Green</option>
                                <option value="#5bc0de">Teal</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>
                                iCheck Checkbox Field</label>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" name="checkbox-2" class="icheck-input" data-mincheck="2">
                                    Option 1
                                </label>
                            </div>
                            <div class="checkbox">
                                <label>
                                    <input type="checkbox" name="checkbox-2" class="icheck-input" data-mincheck="2">
                                    Option 2
                                </label>
                            </div>
                        </div>
                        <!-- /.form-group -->
                        <div class="form-group">
                            <label>
                                iCheck Radio Field</label>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="radio-2" class="icheck-input" data-required="true">
                                    Option 1
                                </label>
                            </div>
                            <div class="radio">
                                <label>
                                    <input type="radio" name="radio-2" class="icheck-input" data-required="true">
                                    Option 2
                                </label>
                            </div>
                        </div>--%>

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
