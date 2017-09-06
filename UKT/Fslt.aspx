<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Fslt.aspx.cs" Inherits="UKT.WebForm6" %>
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
                                <strong></strong>Borang Fasilitas(6)</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Rata-rata biaya telepon& pulsa Hp per bulan sekeluarga</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLTelepon" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.100.000</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.100.000-Rp.200.000</asp:ListItem>
                                            <asp:ListItem Value="6">>Rp.200.000-Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="8">>Rp.500.000</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                                                        <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Rata-rata biaya internet per bulan sekeluarga</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLInternet" runat="server">
                                            <asp:ListItem Value="1">tidak ada</asp:ListItem>
                                            <asp:ListItem Value="2">Rp.0-Rp.200.000</asp:ListItem>
                                            <asp:ListItem Value="4">>Rp.200.000-Rp.500.000</asp:ListItem>
                                            <asp:ListItem Value="6">>Rp.500.000-Rp.750.000</asp:ListItem>
                                            <asp:ListItem Value="8">>Rp.750.000</asp:ListItem>
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
