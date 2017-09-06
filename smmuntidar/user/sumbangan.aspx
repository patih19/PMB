<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="sumbangan.aspx.cs" Inherits="smmuntidar.user.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container top-buffer" style="background-color: #F2F2FF;">
    <p></p>
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="PanelBdk" runat="server" CssClass="form-control" BackColor="#FFFF99">
                    Pengisian formulir pendaftaran urut mulai<strong> tahap 1 (satu) sampai 8 (delapan)
                    </strong>
                </asp:Panel>
            </div>
        </div>
        <p></p>
        <div class="row">
            <div class="col-md-9">
                <strong><span class="style3">Tahap Ke-7: SUMBANGAN PENGEMBANGAN INSTITUSI</span></strong><br />
                <br />
                Pilihan besaran sumbangan pengembangan institusi (SPI) akan disesuaikan dengan jumlah penghasilan 
                orang tua/wali.<br />
                <hr />
                <asp:Panel ID="PanelPenghasilan" runat="server">
                    Pilih Jumlah Penghasilan Orang Tua/Wali :
                    <asp:DropDownList CssClass="form-control " ID="DLPenghasilanOrtu" runat="server">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="BtnPenghasilan" CssClass="btn btn-success" runat="server" Text="Simpan"
                        OnClick="BtnPenghasilan_Click"  onclientclick="return confirm('Anda Yakin Jumlah Penghasilan Sudah Benar ?');" />
                        <p><em>konsultasikan penghasilan orang tua/wali sebelum data dipilih, proses ini 
                            hanya dapat dilakukan satu kali saja !</em></p>
                </asp:Panel>
                <p><asp:Label ID="LbPenghasilan" runat="server" Text=""></asp:Label></p>                
                <asp:Panel ID="PanelSPI" runat="server">
                    Pilih salah satu :
                    <asp:DropDownList CssClass="form-control " ID="DLSPI" runat="server">
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="BtnSaveSPI" CssClass="btn btn-danger"  runat="server" 
                        Text="Simpan" 
                        onclientclick="return confirm('Anda Yakin Jumlah Sumbnagan Sudah Benar ?');" 
                        onclick="BtnSaveSPI_Click" />
                    <p><em>periksa jumlah sumbangan sebelum disimpan !</em></p>
                </asp:Panel>                

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
