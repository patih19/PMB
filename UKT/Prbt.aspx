<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Prbt.aspx.cs" Inherits="UKT.WebForm5" %>
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
                    <h4>
                        PENGISIAN BORANG URUT DIMULAI DARI BORANG SATU SAMPAI DENGAN SEMBILAN</h4>
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
                                <strong></strong>Borang Perabot Rumah(5)</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli meja kursi ruang tamu</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLBeliMKTamu" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Almari,bifet dan sejenisnya (total harga belinya)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLAlmariBft" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Meja kursi ruang tengah/keluarga (harga belinya)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLMKRuangTengah" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli meja kursi ruang makan</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLMKRuangMakan" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli meja kursi ruang teras</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLMKRuangTeras" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli tempat tidur</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLTmpTidur" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli televisi</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLTV" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.500.000 </asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.500.000-Rp.1.500.000</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.1.500.000-Rp.3.000.000 </asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.3.000.000 </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli keseluruhan komputer,laptop & printer</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLKomp" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli keseluruhan gas,oven & perabot dapur</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLPerabotDapur" runat="server">
                                            <asp:ListItem Value="1">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="2">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.5 juta-Rp.10 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.10 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Harga beli meja rias</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLMejaRias" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">>Rp.1 juta-Rp.2,5 juta</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.2,5 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="5">>Rp.5 juta</asp:ListItem>
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
                            <asp:Button ID="BtnSubmit"
                                runat="server" class="btn btn-primary pull-right" Text="Preview" 
                                OnClick="BtnSubmit_Click" />
                                <span class="style4">PERIKSA 
                    KEMBALI ISIAN DATA SEBELUM DISIMPAN </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
