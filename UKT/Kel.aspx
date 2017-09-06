<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Kel.aspx.cs" Inherits="UKT.WebForm2" %>
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
                                <strong></strong>Borang Keluarga (2)</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Jumlah orang serumah</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLOrgRumah" runat="server">
                                            <asp:ListItem Value="1">> 5 orang</asp:ListItem>
                                            <asp:ListItem Value="2">5 orang</asp:ListItem>
                                            <asp:ListItem Value="3">4 orang</asp:ListItem>
                                            <asp:ListItem Value="5">3 orang</asp:ListItem>
                                            <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Jumlah saudara kandung</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLSdrKandung" runat="server">
                                            <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                            <asp:ListItem Value="2">5 orang</asp:ListItem>
                                            <asp:ListItem Value="3">4 orang</asp:ListItem>
                                            <asp:ListItem Value="5">3 orang</asp:ListItem>
                                            <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Jumlah saudara kandung sedang kuliah</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLSdrKandungKuliah" runat="server">
                                            <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                            <asp:ListItem Value="3">5 orang</asp:ListItem>
                                            <asp:ListItem Value="5">4 orang</asp:ListItem>
                                            <asp:ListItem Value="7">3 orang</asp:ListItem>
                                            <asp:ListItem Value="10"><= 2 orang</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <span class="help-block">Password field sample</span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Jumlah saudara kandung sekolah</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                        <asp:DropDownList ID="DLSdrKandungSekolah" runat="server">
                                            <asp:ListItem Value="1">>5 orang</asp:ListItem>
                                            <asp:ListItem Value="2">5 orang</asp:ListItem>
                                            <asp:ListItem Value="3">4 orang</asp:ListItem>
                                            <asp:ListItem Value="5">3 orang</asp:ListItem>
                                            <asp:ListItem Value="7"><= 2 orang</asp:ListItem>
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
                                Text="Preview" onclick="BtnSubmit_Click" /> <span class="style4">PERIKSA 
                    KEMBALI ISIAN DATA SEBELUM DISIMPAN </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
