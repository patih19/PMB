<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Ast.aspx.cs" Inherits="UKT.WebForm8" %>
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
                                <strong></strong>Borang kepemilikan harta/aset keluarga(8)</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Sawah (perkiraan harga jual sekarang)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLSawah" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="5">Rp.0-Rp.15 juta</asp:ListItem>
                                            <asp:ListItem Value="10">>Rp.15 juta-Rp.40 juta</asp:ListItem>
                                            <asp:ListItem Value="15">>Rp.40 juta-Rp.75 juta</asp:ListItem>
                                            <asp:ListItem Value="30">>Rp.75 juta-Rp.100 juta </asp:ListItem>
                                            <asp:ListItem Value="50">>Rp.100 juta </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Tanah,ladang,kebun (perkiraan harga jual sekarang)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLTanah" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="5">Rp.0-Rp.15 juta</asp:ListItem>
                                            <asp:ListItem Value="10">>Rp.15 juta-Rp.40 juta</asp:ListItem>
                                            <asp:ListItem Value="15">>Rp.40 juta-Rp.75 juta</asp:ListItem>
                                            <asp:ListItem Value="30">>Rp.75 juta-Rp.100 juta </asp:ListItem>
                                            <asp:ListItem Value="50">>Rp.100 juta </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Ternak (perkiraan harga jual sekarang)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLternak" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="5">Rp.0-Rp.7,5 juta</asp:ListItem>
                                            <asp:ListItem Value="7">>Rp.7,5 juta-Rp.10 juta</asp:ListItem>
                                            <asp:ListItem Value="10">>Rp.10 juta-Rp.15 juta</asp:ListItem>
                                            <asp:ListItem Value="20">>Rp.15 juta-Rp.25 juta </asp:ListItem>
                                            <asp:ListItem Value="30">>Rp.25 juta </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Mobil (perkiraan harga jual sekarang)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLmobil" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="10">Rp.0-Rp.25 juta</asp:ListItem>
                                            <asp:ListItem Value="20">>Rp.25 juta-Rp.75 juta</asp:ListItem>
                                            <asp:ListItem Value="30">>Rp.75 juta-Rp.125 juta</asp:ListItem>
                                            <asp:ListItem Value="40">>Rp.125 juta-Rp.200 juta </asp:ListItem>
                                            <asp:ListItem Value="50">>Rp.200 juta </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Tabungan,giro,deposito</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLGiro" runat="server">
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
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Perhiasan (perkiraan harga jual sekarang)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLPerhiasan" runat="server">
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
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Sepeda, speda motor dan sejenisnya (perkiraan harga jual sekarang)</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLSepeda" runat="server">
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
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>

                            <!-- <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Upload File Penghasilan</label>
                                <div class="col-md-6 col-xs-12">
                                    <input type="file" class="fileinput btn-primary" name="filename" id="filename" title="Browse file" />
                                    <span class="help-block">Input type file</span>
                                </div>
                            </div> -->
                        </div>
                        <div class="panel-footer">
                            <asp:Button ID="BtnSubmit" runat="server" class="btn btn-primary pull-right" 
                                Text="Preview"                                 
                                onclick="BtnSubmit_Click" /><span class="style4">PERIKSA 
                    KEMBALI ISIAN DATA SEBELUM DISIMPAN </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
