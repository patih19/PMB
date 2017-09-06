<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="PendaftaranPMDK.aspx.cs" Inherits="pmb.sm.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
        .style4
        {
            padding: 15px;
            font-size: medium;
        }
        .style5
        {
            font-size: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
                    <div class="col-xs-12 col-md-4 col-lg-3  highlight">
                Welcome :
                <asp:Label ID="LbUser" runat="server" Text=""></asp:Label>
                <br />
                <div class="panel panel-danger">
                    <div class="panel-heading">
                        Bukti Pembayaran</div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/req.aspx") %>">Cek Berkas</a></span></div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        System</div>
                    <div class="style4">
                        <a href='#'>Ganti Password</a><br />
                        <a href='#' id='keluar' runat='server'>Logout </a>
                    </div>
                </div>
            </div>
            <br />
            <div class="col-xs-12 col-md-8 col-lg-9">
                <strong><span class="style5">Validasi Bukti Pendaftaran PMDK:
                </span></strong>
                <br /><br />
                    <asp:GridView ID="GVListDaftarPmdk" CssClass="table-bordered table-condensed" 
                        runat="server" CellPadding="4" ForeColor="#333333" 
                        GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Images
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="BtnLihat" runat="server" onclick="BtnLihat_Click" Text="Open" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                <br />
                <asp:Panel ID="PanelDetailPendaftar" runat="server">
                    <table class="table-condensed table-bordered" align="center">
                        <tr>
                            <td>
                                <asp:Label ID="LbNoPendaftaran" runat="server" 
                                Style="font-size: small; font-weight: 700"></asp:Label>-
                                <asp:Label ID="LbBill" runat="server" 
                                Style="font-size: small; font-weight: 700"></asp:Label>-
                                <asp:Label ID="LbNama" runat="server" 
                                Style="font-size: small; font-weight: 700"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" CssClass="img-responsive" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="BtnSah" runat="server" CssClass="btn btn-success" Text="Sah" OnClientClick="return confirm('Anda Yakin Data Tersebut Sah');" 
                                    onclick="BtnSah_Click" />
                                &nbsp;Berkas Meyakinkan</td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
