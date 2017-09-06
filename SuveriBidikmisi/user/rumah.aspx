<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="rumah.aspx.cs" Inherits="SuveriBidikmisi.rumah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Rumah</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <asp:Panel ID="PanelMsg" runat="server">
                <div class="col-sm-12">
                    <div class="alert alert-success">
                        <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                        <h4>
                            <asp:Label ID="LbMsgRumah" runat="server" Text=""></asp:Label></h4>
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
                            <i class="fa fa-tasks"></i>Isian Borang Rumah
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="validate-enhanced" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Status kepemilikan rumah</label>
                                <asp:Label ID="LbStatusMilikRumah" CssClass=" form-control" runat="server" Text="Label" Enabled="False"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Sumber listrik</label>
                                <asp:Label ID="LbSumberListrik" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Daya listrik (KWH)</label>
                                <asp:Label ID="LbDayaListrik" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya listrik per bulan</label>
                                <asp:Label ID="LbBiayaListrikBulanan" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                   Sumber air</label>
                                <asp:Label ID="LbSumberAir" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya air per bulan</label>
                                <asp:Label ID="LbBiayaAirBulanan" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Luas tanah M<sup>2</sup></label>
                                <asp:Label ID="LbLuasTanah" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Luas bangunan M<sup>2</sup></label>
                                <asp:Label ID="LbLuasBangunan" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                   NJOP/M<sup>2</sup></label>
                                <asp:Label ID="LbNJOP" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Bahan atap rumah</label>
                                <asp:Label ID="LbAtap" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Bahan lantai rumah</label>
                                <asp:Label ID="LbLantaiRumah" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Ruang tengah keluarga</label>
                                <asp:Label ID="LbRuangTengah" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Dapur</label>
                                <asp:Label ID="LbDapur" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Cuci piring, gelas, baju</label>
                                <asp:Label ID="LbCuciPiringGelas" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Keperluan mandi/kamar mandi</label>
                                <asp:Label ID="LbKeperluanMandi" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Teras</label>
                                <asp:Label ID="LbTeras" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Garasi</label>
                                <asp:Label ID="LbGarasi" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
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
                            <i class="fa fa-tasks"></i>Basic Fields
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Status kepemilikan rumah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLStatusRumah" runat="server">
                                    <asp:ListItem Value="-1">Status kepemilikan rumah</asp:ListItem>
                                    <asp:ListItem Value="1">menumpang orang lain</asp:ListItem>
                                    <asp:ListItem Value="2">menumpang keluarga</asp:ListItem>
                                    <asp:ListItem Value="3">kontrak</asp:ListItem>
                                    <asp:ListItem Value="4">milik keluarga</asp:ListItem>
                                    <asp:ListItem Value="5">milik sendiri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Sumber listrik</label>
                                <asp:DropDownList CssClass="form-control" ID="DlSmbrListrik" runat="server">
                                    <asp:ListItem Value="-1">Sumber listrik</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">menyalur dari orang lain</asp:ListItem>
                                    <asp:ListItem Value="3">listrik rumah kontrakan</asp:ListItem>
                                    <asp:ListItem Value="4">listrik sendiri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Daya listrik (KWH)</label>
                                <asp:DropDownList CssClass="form-control" ID="DLKwh" runat="server">
                                    <asp:ListItem Value="-1">Daya listrik</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">220</asp:ListItem>
                                    <asp:ListItem Value="3">450</asp:ListItem>
                                    <asp:ListItem Value="4">900</asp:ListItem>
                                    <asp:ListItem Value="5">>= 1300</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya listrik per bulan</label>
                                <asp:DropDownList CssClass="form-control" ID="DlBiayaListrik" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata biaya listrik per bulan</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">< Rp.50.000</asp:ListItem>
                                    <asp:ListItem Value="3">Rp.50.000 - Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.100.000 - Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="5">>= Rp.500.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                   Sumber air</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSmbrAir" runat="server">
                                    <asp:ListItem Value="-1">Sumber air</asp:ListItem>
                                    <asp:ListItem Value="1">sungai</asp:ListItem>
                                    <asp:ListItem Value="2">sumur bersama</asp:ListItem>
                                    <asp:ListItem Value="3">sumur sendiri</asp:ListItem>
                                    <asp:ListItem Value="4">PDAM</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Rata-rata biaya air per bulan</label>
                                <asp:DropDownList CssClass="form-control" ID="DLBiayaAir" runat="server">
                                    <asp:ListItem Value="-1">Rata-rata biaya air per bulan</asp:ListItem>
                                    <asp:ListItem Value="1">Rp.0 - Rp.50.000</asp:ListItem>
                                    <asp:ListItem Value="2">>Rp.50.000 - Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.100.000 - Rp.200.000</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.200.000 - Rp.300.000</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.300.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Luas tanah M<sup>2</sup></label>
                                <asp:DropDownList CssClass="form-control" ID="DLLsTanah" runat="server">
                                    <asp:ListItem Value="-1">Luas Tanah</asp:ListItem>
                                    <asp:ListItem Value="1">0-50</asp:ListItem>
                                    <asp:ListItem Value="2">51-100</asp:ListItem>
                                    <asp:ListItem Value="3">101-200</asp:ListItem>
                                    <asp:ListItem Value="4">200-500</asp:ListItem>
                                    <asp:ListItem Value="5">>500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Luas bangunan M<sup>2</sup></label>
                                <asp:DropDownList CssClass="form-control" ID="DLLsBangunan" runat="server">
                                    <asp:ListItem Value="-1">Luas Bangunan</asp:ListItem>
                                    <asp:ListItem Value="1">0-50</asp:ListItem>
                                    <asp:ListItem Value="2">51-100</asp:ListItem>
                                    <asp:ListItem Value="3">101-200</asp:ListItem>
                                    <asp:ListItem Value="4">200-500</asp:ListItem>
                                    <asp:ListItem Value="5">>500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                   NJOP/M<sup>2</sup></label>
                                <asp:DropDownList ID="DLNJOP" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="-1">NJOP</asp:ListItem>
                                    <asp:ListItem Value="1"><= Rp.50.000</asp:ListItem>
                                    <asp:ListItem Value="2">>Rp.50.000-Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.100.000-Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.500.000-Rp.1.000.000</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.1.000.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Bahan atap rumah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLAtap" runat="server">
                                    <asp:ListItem Value="-1">Bahan atap rumah</asp:ListItem>
                                    <asp:ListItem Value="1">atap sirap</asp:ListItem>
                                    <asp:ListItem Value="2">seng</asp:ListItem>
                                    <asp:ListItem Value="3">genteng tanah liat</asp:ListItem>
                                    <asp:ListItem Value="4">genteng PVC</asp:ListItem>
                                    <asp:ListItem Value="5">genteng beton</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Bahan lantai rumah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLLantai" runat="server">
                                    <asp:ListItem Value="-1">Bahan lantai rumah</asp:ListItem>
                                    <asp:ListItem Value="1">tanah</asp:ListItem>
                                    <asp:ListItem Value="2">kayu</asp:ListItem>
                                    <asp:ListItem Value="3">plester/tegel</asp:ListItem>
                                    <asp:ListItem Value="4">keramik</asp:ListItem>
                                    <asp:ListItem Value="5">marmer/granit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Ruang tengah keluarga</label>
                                <asp:DropDownList CssClass="form-control" ID="DLRgTengah" runat="server">
                                    <asp:ListItem Value="-1">Ruang tengah keluarga</asp:ListItem>
                                    <asp:ListItem Value="1">tanah</asp:ListItem>
                                    <asp:ListItem Value="2">kayu</asp:ListItem>
                                    <asp:ListItem Value="3">plester/tegel</asp:ListItem>
                                    <asp:ListItem Value="4">keramik</asp:ListItem>
                                    <asp:ListItem Value="5">marmer/granit</asp:ListItem>
                                </asp:DropDownList>                                
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Dapur</label>
                                <asp:DropDownList CssClass="form-control" ID="DLDapur" runat="server">
                                    <asp:ListItem Value="-1">Dapur</asp:ListItem>
                                    <asp:ListItem Value="1">tungku kayu bakar</asp:ListItem>
                                    <asp:ListItem Value="2">serbuk kayu/biogas</asp:ListItem>
                                    <asp:ListItem Value="3">kompor gas</asp:ListItem>
                                    <asp:ListItem Value="4">kompor listrik</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Cuci piring, gelas, baju</label>
                                <asp:DropDownList CssClass="form-control" ID="DLCuci" runat="server">
                                    <asp:ListItem Value="-1">Cuci piring, gelas, baju</asp:ListItem>
                                    <asp:ListItem Value="1">di sungai</asp:ListItem>
                                    <asp:ListItem Value="2">di sumur</asp:ListItem>
                                    <asp:ListItem Value="3">di dapur</asp:ListItem>
                                    <asp:ListItem Value="4">di kamar mandi</asp:ListItem>
                                    <asp:ListItem Value="5">di wastafel/mesin cuci</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Keperluan mandi/kamar mandi</label>
                                <asp:DropDownList CssClass="form-control" ID="DLKmMandi" runat="server">
                                    <asp:ListItem Value="-1">Keperluan mandi/kamar mandi</asp:ListItem>
                                    <asp:ListItem Value="1">sungai/kamar mandi umum</asp:ListItem>
                                    <asp:ListItem Value="2">dinding bambu/seng & bak ember</asp:ListItem>
                                    <asp:ListItem Value="3">dinding & bak plester</asp:ListItem>
                                    <asp:ListItem Value="4">dinding & bak keramik</asp:ListItem>
                                    <asp:ListItem Value="5">dinding keramik & shower</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Teras</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTeras" runat="server">
                                    <asp:ListItem Value="-1">Teras</asp:ListItem>
                                    <asp:ListItem Value="1">tanah</asp:ListItem>
                                    <asp:ListItem Value="2">plester/tegel</asp:ListItem>
                                    <asp:ListItem Value="3">keramik</asp:ListItem>
                                    <asp:ListItem Value="4">kayu</asp:ListItem>
                                    <asp:ListItem Value="5">marmer/granit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Garasi</label>
                                <asp:DropDownList CssClass="form-control" ID="DLGarasi" runat="server">
                                    <asp:ListItem Value="-1">Garasi</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">bambu</asp:ListItem>
                                    <asp:ListItem Value="3">tembok/berbatasan dengan tetangga</asp:ListItem>
                                    <asp:ListItem Value="4">tembok keramik</asp:ListItem>
                                    <asp:ListItem Value="5">tralis/besi</asp:ListItem>
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
