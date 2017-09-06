<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="spi--tidak_dipakai.aspx.cs" Inherits="smmuntidar.user.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <div class="row">
            <div class="col-md-9">
                <strong><span class="style3">Proses Ke-7: SUMBANGAN PENGEMBANGAN INSTITUSI</span></strong><br />
                <br />
                Sumbangan pengembangan institusi (SPI) jumlahnya tidak ditentukan 
                oleh Universitas Tidar, setiap 
                Peserta diberikan kesempatan untuk mengisi
                sendiri besarannya biaya sesuai dengan kemampaun ekonomi dan besarnya sumbangan 
                bukan bagian dari kriteria kelulusan.<br />
                <hr />
                <asp:panel ID="PanelSPI" runat="server" >
                    <asp:UpdatePanel ID="UpPnlSPI" runat="server">
                    <ContentTemplate>
                        <table class="table-condensed">
                            <tr>
                                <td class="style4">
                                    Rp.
                                </td>
                                <td class="style4">
                                    <asp:TextBox ID="TbSumbangan" runat="server" CssClass="form-control" 
                                        MaxLength="8" AutoPostBack="True" Placeholer="Isi biaya SPI kemudian enter" ontextchanged="TbSumbangan_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    &nbsp;</td>
                                <td class="style4">
                                    <strong>Isi besaran SPI tanpa tanda koma atau titik, kemudian tekan Enter</strong></td>
                            </tr>
                        </table>
                        <hr />
                        <asp:Panel ID="PanelBiaya" runat="server">
                            <table class="table-condensed">
                                <tr>
                                    <td>
                                        Besarnya Sumbangan :
                                    </td>
                                    <td>
                                        <asp:Label ID="LbSumbangan" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnSpi" runat="server" CssClass="btn btn-success" OnClick="BtnSpi_Click"
                                            Text="Simpan" 
                                            onclientclick="return confirm('Anda Yakin Biaya SPI Sudah Benar ?');" />
                                    </td>
                                </tr>
                            </table>
                                            <asp:Label ID="LbError" runat="server"></asp:Label>
                        </asp:Panel>
                        <hr />
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:panel>
                <asp:UpdateProgress ID="UpProgSPI" runat="server">
                    <ProgressTemplate>
                        <div class="mdl">
                            <div class="center">
                                <img alt="" src="../images/loading135.gif" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                



                <br />

                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;<br />
            </div>
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                      </div>
                    <div class="panel-body">
                        No. Pendaftaran :
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3">
                            <a href='#' id='keluar' runat='server'>Logout </a>
                        </span>
                    </div>
                </div>              
            </div>
        </div>
    </div>
</asp:Content>
