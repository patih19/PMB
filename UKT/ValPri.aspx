<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="ValPri.aspx.cs" Inherits="UKT.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style22
        {
            font-size: 14px;
            background-color: #FFFFCC;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-atas" style="min-height: 450px; background-color: White;
        box-shadow: 0px 0px 200px rgba(82, 124, 159, 0.25), 0px 1px 2px rgba(0, 0, 0, 0.19);">
    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal" style="font-size:13px">
            <p></p>
            <table class=" table table-condensed table-hover">
                <tr>
                    <td class="style22">
                        <strong>BORANG PRIBADI (1)</strong></td>
                    <td class="style22">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Nama
                    </td>
                    <td>
                        <asp:Label ID="LbNama" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jenis Kelamin
                    </td>
                    <td>
                        <asp:Label ID="LbGender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tempat Lahir
                    </td>
                    <td>
                        <asp:Label ID="LbTempatLahir" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tanggal Lahir
                    </td>
                    <td>
                        <asp:Label ID="LbTanggalLahir" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Alamat Lengkap</td>
                    <td>
                        <asp:Label ID="LbAlamat" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        No. Handphone
                    </td>
                    <td>
                        <asp:Label ID="LbHp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        No. Telpon Rumah</td>
                    <td>
                        <asp:Label ID="LbTelpRumah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nama Ayah</td>
                    <td>
                        <asp:Label ID="LbNamaAyah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status Ayah</td>
                    <td>
                        <asp:Label ID="LbStatusAyah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Pendidikan Terakhir Ayah</td>
                    <td>
                        <asp:Label ID="LbPendidikanAyah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Data Pekerjaan Ayah</td>
                    <td>
                        <asp:Label ID="LbPekerjaanAyah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah Modal Usaha</td>
                    <td>
                        <asp:Label ID="LbModalUsahaAyah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah Laba</td>
                    <td>
                        <asp:Label ID="LbLabaAyah" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nama Ibu/Wali</td>
                    <td>
                        <asp:Label ID="LbNamaIbu" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status Ibu/Wali</td>
                    <td>
                        <asp:Label ID="LbStatusIbu" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Pendidikan Terakhir Ibu/Wali</td>
                    <td>
                        <asp:Label ID="LbPendidikanIbu" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Data Pekerjaan Ibu</td>
                    <td>
                        <asp:Label ID="LbPekerjaanIbu" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah Modal Usaha</td>
                    <td>
                        <asp:Label ID="LbModalUsahaIbu" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Jumlah Laba</td>
                    <td>
                        <asp:Label ID="LbLabaIbu" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <hr />
                <strong>Sebelum data disimpan pastikan pengisian Borang Pribadi Sudah Benar !</strong> <br />
                <p></p>
                <asp:Button CssClass="btn btn-danger" ID="Button2" runat="server" 
                    Text="Ulangi" onclick="Button2_Click" />
                &nbsp;<asp:Button CssClass="btn btn-success" ID="Button1" runat="server" onclientclick="return confirm('Anda Yakin Data Tersebut Benar ?');" 
                    Text="SIMPAN" onclick="Button1_Click" />
            </div>
            <p></p>
            <p></p>
        </div>
    </div> 
</div>


</asp:Content>
