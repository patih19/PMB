﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Survei.Master" AutoEventWireup="true" CodeBehind="aset.aspx.cs" Inherits="SuveriBidikmisi.aset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-header">
        <h1>
            Borang Aset Keluarga</h1>
    </div>
    <!-- #content-header -->
    <div id="content-container">
        <div class="row">
            <asp:Panel ID="PanelMsg" runat="server">
                <div class="col-sm-12">
                    <div class="alert alert-success">
                        <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                        <h4>
                            <asp:Label ID="LbMsgAset" runat="server" Text=""></asp:Label></h4>
                        <asp:Button ID="BtnUlangi" class="btn btn-info" runat="server" Text="Perbarui Data"
                            OnClick="BtnUlangi_Click" />
                        &nbsp;<asp:Label ID="LbMsgUpdate" runat="server" ForeColor="#FF3300" Style="font-size: large"></asp:Label>
                    </div>
                </div>
            </asp:Panel>

            <div class="col-sm-6">
                <div class="portlet">
                    <div class="portlet-header">
                        <h3>
                            <i class="fa fa-tasks"></i>Isian Borang Aset Keluarga
                        </h3>
                    </div>
                    <!-- /.portlet-header -->
                    <div class="portlet-content">
                        <div id="validate-enhanced" class="form parsley-form">
                        <div class="form-group">
                            <label for="validateSelect">
                                Sawah (perkiraan harga jual sekarang)</label> 
                            <asp:Label ID="LbSawah" CssClass=" form-control" runat="server" Text="Label" 
                                Enabled="False"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Tanah,ladang dan kebun (perkiraan harga jual sekarang)</label>
                            <asp:Label ID="LbLadangKebun" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                                Ternak (perkiraan harga jual sekarang)</label>
                            <asp:Label ID="LbTernak" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Mobil (perkiraan harga jual sekarang)</label>
                            <asp:Label ID="LbMobil" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                        <div class="form-group">
                            <label for="validateSelect">  
                               Tabungan,giro,deposito</label>
                            <asp:Label ID="LbTabungan" CssClass=" form-control" runat="server" Text="Label" Enabled="false" ></asp:Label>
                        </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Perhiasan</label>
                                <asp:Label ID="LbPerhiasan" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Sepeda, sepeda motor (perkiraan harga jual sekarang)</label>
                                <asp:Label ID="LbSepedaMotor" CssClass=" form-control" runat="server" Text="Label" Enabled="false"></asp:Label>
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
                                    Sawah (perkiraan harga jual sekarang)</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSawah" runat="server">
                                    <asp:ListItem Value="-1">Sawah (perkiraan harga jual sekarang)</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0-Rp.15 juta</asp:ListItem>
                                    <asp:ListItem Value="10">>Rp.15 juta-Rp.40 juta</asp:ListItem>
                                    <asp:ListItem Value="15">>Rp.40 juta-Rp.75 juta</asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.75 juta-Rp.100 juta </asp:ListItem>
                                    <asp:ListItem Value="50">>Rp.100 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Tanah,ladang dan kebun (perkiraan harga jual sekarang)</label>
                                <asp:DropDownList CssClass="form-control" ID="DLTanah" runat="server">
                                    <asp:ListItem Value="-1">Tanah,ladang dan kebun (perkiraan harga jual sekarang)</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0-Rp.15 juta</asp:ListItem>
                                    <asp:ListItem Value="10">>Rp.15 juta-Rp.40 juta</asp:ListItem>
                                    <asp:ListItem Value="15">>Rp.40 juta-Rp.75 juta</asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.75 juta-Rp.100 juta </asp:ListItem>
                                    <asp:ListItem Value="50">>Rp.100 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Ternak (perkiraan harga jual sekarang)</label>
                                <asp:DropDownList CssClass="form-control" ID="DLternak" runat="server">
                                    <asp:ListItem Value="-1">Ternak (perkiraan harga jual sekarang)</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="5">Rp.0-Rp.7,5 juta</asp:ListItem>
                                    <asp:ListItem Value="7">>Rp.7,5 juta-Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="10">>Rp.10 juta-Rp.15 juta</asp:ListItem>
                                    <asp:ListItem Value="20">>Rp.15 juta-Rp.25 juta </asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.25 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Mobil (perkiraan harga jual sekarang)</label>
                                <asp:DropDownList CssClass="form-control" ID="DLmobil" runat="server">
                                    <asp:ListItem Value="-1">Mobil (perkiraan harga jual sekarang)</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="10">Rp.0-Rp.25 juta</asp:ListItem>
                                    <asp:ListItem Value="20">>Rp.25 juta-Rp.75 juta</asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.75 juta-Rp.125 juta</asp:ListItem>
                                    <asp:ListItem Value="40">>Rp.125 juta-Rp.200 juta </asp:ListItem>
                                    <asp:ListItem Value="50">>Rp.200 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Perhiasan</label>
                                <asp:DropDownList CssClass="form-control" ID="DLPerhiasan" runat="server">
                                    <asp:ListItem Value="-1">Perhiasan</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="7">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="10">>Rp.5 juta-Rp.7,5 juta </asp:ListItem>
                                    <asp:ListItem Value="14">>Rp.7,5 juta-Rp.10 juta </asp:ListItem>
                                    <asp:ListItem Value="20">>Rp.10 juta-Rp.20 juta </asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.20 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Sepeda, sepeda motor (perkiraan harga jual sekarang)</label>
                                <asp:DropDownList CssClass="form-control" ID="DLSepeda" runat="server">
                                    <asp:ListItem Value="-1">Sepeda, sepeda motor (perkiraan harga jual sekarang)</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">Rp.0-Rp.2 juta</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.2 juta-Rp.2,5 juta</asp:ListItem>
                                    <asp:ListItem Value="8">Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="12">Rp.5 juta-Rp.7,5 juta </asp:ListItem>
                                    <asp:ListItem Value="16">Rp.7,5 juta-Rp.10 juta </asp:ListItem>
                                    <asp:ListItem Value="20">Rp.10 juta-Rp.15 juta </asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.15 juta </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="validateSelect">
                                    Tabungan,giro,deposito</label>
                                <asp:DropDownList CssClass="form-control" ID="DLGiro" runat="server">
                                    <asp:ListItem Value="-1">Tabungan,giro,deposito</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.0-Rp.1 juta</asp:ListItem>
                                    <asp:ListItem Value="7">>Rp.1 juta-Rp.5 juta</asp:ListItem>
                                    <asp:ListItem Value="10">>Rp.5 juta-Rp.10 juta</asp:ListItem>
                                    <asp:ListItem Value="13">>Rp.10 juta-Rp.20 juta </asp:ListItem>
                                    <asp:ListItem Value="16">>Rp.20 juta-Rp.30 juta </asp:ListItem>
                                    <asp:ListItem Value="20">>Rp.30 juta-Rp.50 juta </asp:ListItem>
                                    <asp:ListItem Value="25">>Rp.50 juta-Rp.75 juta </asp:ListItem>
                                    <asp:ListItem Value="30">>Rp.75 juta-Rp.100 juta </asp:ListItem>
                                    <asp:ListItem Value="40">>Rp.100 juta </asp:ListItem>
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
