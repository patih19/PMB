<%@ Page Title="" Language="C#" MasterPageFile="~/pmb.Master" AutoEventWireup="true" CodeBehind="smuntidar.aspx.cs" Inherits="pmb.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>

    <style type="text/css">
    .style4
    {
        font-size: small;
    }
    .style5
    {
        color: #0066FF;
    }
    .style6
    {
        color: #0066FF;
        font-size: medium;
    }
        .style7
        {
            font-size: small;
            color: #808080;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <table class="table-condensed mainbox col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
            <tr>
                <td>
                    <div class="row">
                        <div id="Div3" style="margin-top: 50px;" class="mainbox">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <div class="panel-title">
                                        User Login</div>
                                    <div style="float: right; font-size: 80%; position: relative; top: -10px">
                                        <a href="#">Forgot password?</a></div>
                                </div>
                                <div style="padding-top: 30px" class="panel-body">
                                    <div style="display: none" id="Div4" class="alert alert-danger col-sm-12">
                                    </div>
                                    <form id="Form2" class="form-horizontal" role="form">
                                    <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                        <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div style="margin-bottom: 25px" class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                        <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" 
                                            TextMode="Password"></asp:TextBox>
                                    </div>
                                    <asp:DropDownList ID="DLSystem" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="sim">Pilih Sistem Informasi</asp:ListItem>
                                        <asp:ListItem Value="smuntidar">SM-UNTIDAR</asp:ListItem>
                                        <asp:ListItem Value="umuntidar">UM-UNTIDAR</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="Login" 
                                        onclick="Button3_Click" />
                                    <hr />
                                    <div class="text-left">
                                        <span class="style6">SIPENMARU</span><span class="style4"> </span>
                                        <br />
                                        <span class="style7">Sistem Informasi Penerimaan Mahasiswa Baru</span><span class="style5">
                                        </span>
                                        <br />
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <br />
</asp:Content>
