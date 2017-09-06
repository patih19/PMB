<%@ Page Title="" Language="C#" MasterPageFile="~/Daftar.Master" AutoEventWireup="true" CodeBehind="Statistik.aspx.cs" Inherits="smuntidar.WebForm1" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            font-size: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-atas"  style="min-height: 450px; background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-12">
                <strong><span class="style2">Rekapitulasi&nbsp; Pendaftaran Sementara
                :</span></strong><br />
                <br />
                <table class="table-condensed">
                    <tr>
                        <td>
                            Program Studi:
                        </td>
                        <td>
                            <asp:DropDownList ID="DLProdi" runat="server" CssClass="form-control" 
                                onselectedindexchanged="DLProdi_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem>Program Studi</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK ELEKTRO</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>D3 TEKNIK MESIN</asp:ListItem>
                                <asp:ListItem>S1 TEKNIK SIPIL</asp:ListItem>
                                <asp:ListItem>S1 AGROTEKNOLOGI</asp:ListItem>
                                <asp:ListItem>S1 EKONOMI PEMBANGUNAN</asp:ListItem>
                                <asp:ListItem>D3 AKUNTANSI</asp:ListItem>
                                <asp:ListItem>S1 ILMU ADMINISTRASI NEGARA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA DAN SASTRA INDONESIA</asp:ListItem>
                                <asp:ListItem>S1 PENDIDIKAN BAHASA INGGRIS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
&nbsp;<br />
                <asp:Panel ID="PanelDetailPendaftar" runat="server">
                    Data Pendaftar Pada Pilihan Pertama :<br />
                <asp:GridView ID="GVPendaftar" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" CssClass="table-condensed table-bordered" PageSize="25">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <br />
                <asp:Repeater ID="Repeater1" runat="server" EnableTheming="True">
                    <ItemTemplate>
                        <asp:LinkButton ID="PageButton" runat="server" Text='<%#Eval("Text")%>' CommandArgument='<%#Eval("Value")%>'
                            Enabled='<%#Eval("Enabled")%>' OnClick="PageButton_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
                </asp:Panel>
                <br />
            </div>
            <!-- End Content -->
        </div>
        <!-- End Row -->
    </div>
</asp:Content>
