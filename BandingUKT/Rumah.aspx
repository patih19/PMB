<%@ Page Title="" Language="C#" MasterPageFile="~/Banding.Master" AutoEventWireup="true" CodeBehind="Rumah.aspx.cs" Inherits="BandingUKT.Rumah" %>
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
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg1" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgRumah1" runat="server" Text=""></asp:Label>
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
                        <div id="Div1" class="form parsley-form">
                            <div class="form-group">
                                <label for="validateSelect">
                                    Status kepemilikan rumah</label>
                                <asp:DropDownList CssClass="form-control" ID="DLStatusRumah1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DlSmbrListrik1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLKwh1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DlBiayaListrik1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLSmbrAir1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLBiayaAir1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLLsTanah1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLLsBangunan1" runat="server">
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
                                <asp:DropDownList ID="DLNJOP1" CssClass="form-control" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLAtap1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLLantai1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLRgTengah1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLDapur1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLCuci1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLKmMandi1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLTeras1" runat="server">
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
                                <asp:DropDownList CssClass="form-control" ID="DLGarasi1" runat="server">
                                    <asp:ListItem Value="-1">Garasi</asp:ListItem>
                                    <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                    <asp:ListItem Value="2">bambu</asp:ListItem>
                                    <asp:ListItem Value="3">tembok/berbatasan dengan tetangga</asp:ListItem>
                                    <asp:ListItem Value="4">tembok keramik</asp:ListItem>
                                    <asp:ListItem Value="5">tralis/besi</asp:ListItem>
                                </asp:DropDownList>
                            </div> 
                            <!-- /.form-group -->
                            <div class="form-group">
                            <asp:Button ID="BtnSave1" class="btn btn-success" runat="server" Text="Simpan" 
                                onclick="BtnSave1_Click" />
                            <asp:Button ID="BtnUpdate1"  class="btn btn-success"  runat="server" 
                                Text="Update" onclick="BtnUpdate1_Click" />
                            </div>
                        </div>
                    </div>
                    <!-- /.portlet-content -->
                </div>
            </div>
            <!-- /.col -->
            <div class="col-sm-6">
                <asp:Panel ID="PanelMsg" runat="server">
                    <div class="col-sm-12">
                        <div class="alert alert-success">
                            <a class="close" data-dismiss="alert" href="#" aria-hidden="true">×</a>
                            <asp:Label ID="LbMsgRumah" runat="server" Text=""></asp:Label>
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
