<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="UKT.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            background-color: #B1D4F8
        }
        .style5
        {
            font-size:large;
            background-color: #FFFF66;
        }
        .style6
        {
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
                                Unggah File Pendukung Pengisian Borang</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class=" col-lg-12 col-md-10 col-xs-8">
                                <br />
                                <div style="font-size:14px">
                                    <strong>KETENTUAN : </strong>
                                    <ol>
                                        <li>Berkas diunggah <span class="style5">urut mulai nomor satu sampai dengan tujuh !</span></li>
                                        <li>Ukuran file unggah <span class="style6"><strong>100-300 Kb</strong></span></li>
                                        <li>File unggah harus dalam format jpg, jpeg, png atau bmp</li>
                                        <li>contoh surat pernyataan penghasilan
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.document.forms[0].target='_blank';"
                                                OnClick="LinkButton1_Click">download</asp:LinkButton>
                                            <br />
                                        </li>
                                    </ol>
                                    <br />
                                </div>

                                <table class=" table table-condensed table-hover">
                                    <tr>
                                        <td class="style4">
                                            <strong>No.</strong></td>
                                        <td class="style4">
                                            <strong>JENIS</strong></td>
                                        <td class="style4">
                                            <strong>BERKAS UNGGAH</strong></td>
                                        <td class="style4">
                                            <strong>PROSES</strong></td>
                                        <td class="style4">
                                            <strong>KETERANGAN</strong></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            1.</td>
                                        <td>
                                            Kartu Keluarga
                                        <strong>(wajib)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadKK" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnUpKK" runat="server" CssClass="btn btn-success" 
                                                Text="unggah" onclick="BtnUpKK_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbKK" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            2.</td>
                                        <td>
                                            Foto Rumah (tampak depan) <strong>(wajib)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadRumah" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnRumah" runat="server" CssClass="btn btn-success" 
                                                onclick="BtnRumah_Click" Text="unggah" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbRumah" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            3.</td>
                                        <td>
                                            Surat Pernyataan Penghasilan <strong>
                                            / </strong>Slip Gaji <strong>(wajib)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadPenghasilan" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnPenghasilan" runat="server" Text="Unggah" 
                                                CssClass="btn btn-success" onclick="BtnPenghasilan_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbPenghasilan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            4.</td>
                                        <td>
                                            STNK/PKB (Pajak Kendaraan Bermotor)
                                        <strong>(jika ada)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadSTNK" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnUpSTNK" runat="server" CssClass="btn btn-success" 
                                                Text="unggah" onclick="BtnUpSTNK_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbSTNK" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            5.</td>
                                        <td>
                                            Rekening Listrik
                                        <strong>(jika ada)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadListrik" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnUpListrik" runat="server" CssClass="btn btn-success" 
                                                Text="unggah" onclick="BtnUpListrik_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbListrik" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            6.</td>
                                        <td>
                                            Rekening Air
                                        <strong>(jika ada)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadAir" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnUpAir" runat="server" CssClass="btn btn-success" 
                                                Text="unggah" onclick="BtnUpAir_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbAir" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            7.</td>
                                        <td>
                                            Rekening Telepon
                                        <strong>(jika ada)</strong></td>
                                        <td>
                                            <asp:FileUpload ID="FileUploadTelp" runat="server" />
                                        </td>
                                        <td>
                                            <asp:Button ID="BtnUpTelp" runat="server" CssClass="btn btn-success" 
                                                Text="unggah" onclick="BtnUpTelp_Click" />
                                        </td>
                                        <td>
                                            <asp:Label ID="LbTelp" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label ID="LbErr" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <br />
                            </div>
                            <div class="panel-footer">
                                <asp:Button ID="BtnSubmit" runat="server" class="btn btn-primary pull-right" Text="LANJUT"
                                    OnClientClick="return confirm('Yakin Data Yang Anda Unggah Sudah Lengkap?');" 
                                    OnClick="BtnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
