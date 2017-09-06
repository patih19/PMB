<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Eko.aspx.cs" Inherits="UKT.WebForm7" %>
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
                                <strong></strong>Borang Sosial Ekonomi(7)</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Rata-rata pendapatan total ayah/wali</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLPendapatanAyah" runat="server">
                                            <asp:ListItem Value="0">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2"><= Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="4">&gt;Rp.500.000 - Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="7">&gt;Rp.1 juta - Rp.1,5 juta</asp:ListItem>
                                            <asp:ListItem Value="10">&gt;Rp.1,5 juta - Rp.2juta </asp:ListItem>
                                            <asp:ListItem Value="15">&gt;Rp.2 juta - Rp.2,5 juta </asp:ListItem>
                                            <asp:ListItem Value="20">&gt;Rp.2,5 juta - Rp.3 Juta</asp:ListItem>
                                            <asp:ListItem Value="25">&gt;Rp.3 juta - Rp.4 juta</asp:ListItem>
                                            <asp:ListItem Value="30">&gt;Rp.4 juta - Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="35">&gt;Rp.5 juta - 7,5 juta</asp:ListItem>
                                            <asp:ListItem Value="50">&gt;Rp.7,5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Rata-rata pendapatan total ibu/wali</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLPendapatanIbu" runat="server">
                                            <asp:ListItem Value="0">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2"><= Rp.Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="4">&gt;Rp.500.000 - Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="7">&gt;Rp.1 juta - Rp.1,5 juta</asp:ListItem>
                                            <asp:ListItem Value="10">&gt;Rp.1,5 juta - Rp.2juta </asp:ListItem>
                                            <asp:ListItem Value="15">&gt;Rp.2 juta - Rp.2,5 juta </asp:ListItem>
                                            <asp:ListItem Value="20">&gt;Rp.2,5 juta - Rp.3 Juta</asp:ListItem>
                                            <asp:ListItem Value="25">&gt;Rp.3 juta - Rp.4 juta</asp:ListItem>
                                            <asp:ListItem Value="30">&gt;Rp.4 juta - Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="35">&gt;Rp.5 juta - 7,5 juta</asp:ListItem>
                                            <asp:ListItem Value="50">&gt;Rp.7,5 juta</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Total hutang kelurga</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLHutang" runat="server">
                                            <asp:ListItem Value="6">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="5">Rp.0 - Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="4">Rp.1 juta - Rp.10 juta</asp:ListItem>
                                            <asp:ListItem Value="3">Rp.10 juta-Rp.50 juta</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.50 juta-Rp.100 juta </asp:ListItem>
                                            <asp:ListItem Value="1">>Rp.100 juta </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Cicilan hutang per bulan</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DlCicilan" runat="server">
                                            <asp:ListItem Value="6">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="5">Rp.0-Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="4">Rp.500.000-Rp.1 juta</asp:ListItem>
                                            <asp:ListItem Value="3">Rp.1 juta-Rp.5 juta</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.5 juta-Rp.10 juta </asp:ListItem>
                                            <asp:ListItem Value="1">>Rp.10 juta </asp:ListItem>
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
                            <asp:Button ID="BtnSubmit" runat="server" class="btn btn-primary pull-right" 
                                Text="Preview" onclick="BtnSubmit_Click" />
                                <span class="style4">PERIKSA 
                    KEMBALI ISIAN DATA SEBELUM DISIMPAN </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
