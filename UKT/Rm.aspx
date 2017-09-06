<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Rm.aspx.cs" Inherits="UKT.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            font-size: medium;
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="Panel1" runat="server" CssClass="form-control" BackColor="#99CCFF">
                    <h4>PENGISIAN BORANG URUT DIMULAI DARI BORANG SATU SAMPAI DENGAN SEMBILAN</h4> 
                </asp:Panel>
            </div>
        </div>
    </div>
<div class="container top-atas">
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <strong></strong>Borang Rumah(3)</h3>
                </div>
                <div class="panel-body form-group-separated">
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Status kepemilikan rumah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLStatusRumah" runat="server">
                                    <asp:ListItem Value="1">menumpang orang lain</asp:ListItem>
                                    <asp:ListItem Value="2">menumpang keluarga</asp:ListItem>
                                    <asp:ListItem Value="3">kontrak</asp:ListItem>
                                    <asp:ListItem Value="4">milik keluarga</asp:ListItem>
                                    <asp:ListItem Value="5">milik sendiri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Sumber Listrik</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DlSmbrListrik" runat="server">
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">menyalur dari orang lain</asp:ListItem>
                                    <asp:ListItem Value="3">listrik rumah kontrakan</asp:ListItem>
                                    <asp:ListItem Value="4">listrik sendiri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Daya Listrik (KWH)</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLKwh" runat="server">
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">220</asp:ListItem>
                                    <asp:ListItem Value="3">450</asp:ListItem>
                                    <asp:ListItem Value="4">950</asp:ListItem>
                                    <asp:ListItem Value="5">>= 1300</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Rata-rata biaya listrik per bulan</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DlBiayaListrik" runat="server">
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">< Rp.50.000</asp:ListItem>
                                    <asp:ListItem Value="3">Rp.50.000 - Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="4">Rp.100.000 - Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="5">>= Rp.500.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Sumber Air</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLSmbrAir" runat="server">
                                    <asp:ListItem Value="1">sungai</asp:ListItem>
                                    <asp:ListItem Value="2">sumur bersama</asp:ListItem>
                                    <asp:ListItem Value="3">sumur sendiri</asp:ListItem>
                                    <asp:ListItem Value="4">PDAM</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Rata-rata biaya air per bulan</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLBiayaAir" runat="server">
                                    <asp:ListItem Value="1">Rp.0 - Rp.50.000</asp:ListItem>
                                    <asp:ListItem Value="2">>Rp.50.000 - Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.100.000 - Rp.200.000</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.200.000 - Rp.300.000</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.300.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Luas tanah M<sup>2</sup></label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLLsTanah" runat="server">
                                    <asp:ListItem Value="1">0-50</asp:ListItem>
                                    <asp:ListItem Value="2">51-100</asp:ListItem>
                                    <asp:ListItem Value="3">101-200</asp:ListItem>
                                    <asp:ListItem Value="4">200-500</asp:ListItem>
                                    <asp:ListItem Value="5">>500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Luas bangunan M<sup>2</sup></label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLLsBangunan" runat="server">
                                    <asp:ListItem Value="1">0-50</asp:ListItem>
                                    <asp:ListItem Value="2">51-100</asp:ListItem>
                                    <asp:ListItem Value="3">101-200</asp:ListItem>
                                    <asp:ListItem Value="4">200-500</asp:ListItem>
                                    <asp:ListItem Value="5">>500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            NJOP/M<sup>2</sup></label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLNJOP" runat="server">
                                    <asp:ListItem Value="1"><= Rp.50.000</asp:ListItem>
                                    <asp:ListItem Value="2">>Rp.50.000-Rp.100.000</asp:ListItem>
                                    <asp:ListItem Value="3">>Rp.100.000-Rp.500.000</asp:ListItem>
                                    <asp:ListItem Value="4">>Rp.500.000-Rp.1.000.000</asp:ListItem>
                                    <asp:ListItem Value="5">>Rp.1.000.000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Bahan atap rumah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLAtap" runat="server">
                                    <asp:ListItem Value="1">atap sirap</asp:ListItem>
                                    <asp:ListItem Value="2">seng</asp:ListItem>
                                    <asp:ListItem Value="3">genteng tanah liat</asp:ListItem>
                                    <asp:ListItem Value="4">genteng PVC</asp:ListItem>
                                    <asp:ListItem Value="5">genteng beton</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Bahan lantai rumah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLLantai" runat="server">
                                    <asp:ListItem Value="1">tanah</asp:ListItem>
                                    <asp:ListItem Value="2">kayu</asp:ListItem>
                                    <asp:ListItem Value="3">plester/tegel</asp:ListItem>
                                    <asp:ListItem Value="4">keramik</asp:ListItem>
                                    <asp:ListItem Value="5">marmer/granit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Ruang tengah keluarga</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLRgTengah" runat="server">
                                    <asp:ListItem Value="1">tanah</asp:ListItem>
                                    <asp:ListItem Value="2">kayu</asp:ListItem>
                                    <asp:ListItem Value="3">plester/tegel</asp:ListItem>
                                    <asp:ListItem Value="4">keramik</asp:ListItem>
                                    <asp:ListItem Value="5">marmer/granit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Dapur</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLDapur" runat="server">
                                    <asp:ListItem Value="1">tungku kayu bakar</asp:ListItem>
                                    <asp:ListItem Value="2">serbuk kayu/biogas</asp:ListItem>
                                    <asp:ListItem Value="3">kompor gas</asp:ListItem>
                                    <asp:ListItem Value="4">kompor listrik</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Cuci piring, gelas dan baju</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLCuci" runat="server">
                                    <asp:ListItem Value="1">di sungai</asp:ListItem>
                                    <asp:ListItem Value="2">di sumur</asp:ListItem>
                                    <asp:ListItem Value="3">di dapur</asp:ListItem>
                                    <asp:ListItem Value="4">di kamar mandi</asp:ListItem>
                                    <asp:ListItem Value="5">di wastafel/mesin cuci</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Keperluan mandi/kamar mandi</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLKmMandi" runat="server">
                                    <asp:ListItem Value="1">sungai/kamar mandi umum</asp:ListItem>
                                    <asp:ListItem Value="2">dinding bambu/seng & bak ember</asp:ListItem>
                                    <asp:ListItem Value="3">dinding & bak plester</asp:ListItem>
                                    <asp:ListItem Value="4">dinding & bak keramik</asp:ListItem>
                                    <asp:ListItem Value="5">dinding keramik & shower</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Teras</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLTeras" runat="server">
                                    <asp:ListItem Value="1">tanah</asp:ListItem>
                                    <asp:ListItem Value="2">plester/tegel</asp:ListItem>
                                    <asp:ListItem Value="3">keramik</asp:ListItem>
                                    <asp:ListItem Value="4">kayu</asp:ListItem>
                                    <asp:ListItem Value="5">marmer/granit</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Garasi</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLGarasi" runat="server">
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">bambu</asp:ListItem>
                                    <asp:ListItem Value="3">tembok/berbatasan dengan tetangga</asp:ListItem>
                                    <asp:ListItem Value="4">tembok keramik</asp:ListItem>
                                    <asp:ListItem Value="5">tralis/besi</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>


                    <!-- <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            File</label>
                        <div class="col-md-6 col-xs-12">
                            <input type="file" class="fileinput btn-primary" name="filename" id="filename" title="Browse file" />
                            <span class="help-block">Input type file</span>
                        </div>
                    </div> -->
                    
                </div>
                <div class="panel-footer">
                    <asp:Button ID="BtnSubmit" runat="server" 
                        class="btn btn-primary pull-right" Text="Preview" 
                        onclick="BtnSubmit_Click" /><span class="style4">PERIKSA 
                    KEMBALI ISIAN DATA SEBELUM DISIMPAN </span>
                </div>
            </div>
            </div>
        </div>
    </div> 
</div>
</asp:Content>
