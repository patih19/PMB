<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="pmb.sm.WebForm2" %>
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
            <div class="col-xs-6 col-md-8 col-lg-9">
                <strong><span class="style5">Cari pendaftar :<br />
                </span></strong>
                <br />
                <table class="table-condensed table-bordered">
                    <tr>
                        <td>Masukkan No Tagihan/ Jurnal atau sebagian nama Pendaftar :</td>
                        <td>
                            <asp:TextBox ID="TbCari" runat="server" CssClass="form-control" Width="150px" 
                                MaxLength="12"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="BtnCariNo" runat="server" Text="Cari" onclick="Button1_Click" />
                        </td>
                    </tr>
                    </table>
                <br />
                <asp:GridView ID="GVDaftar" CssClass="table-condensed table-bordered" 
                    runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" AutoGenerateSelectButton="True"
                    OnSelectedIndexChanged="GVDaftar_SelectedIndexChanged" >
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
                <asp:Label ID="Label11" runat="server"></asp:Label>
                <br />
                <asp:Panel ID="PanelDetailPendaftar" runat="server">
                    <table class="table-condensed table-bordered">
                        <tr>
                            <td class="text-left" colspan="2" style="background-color: #D9EDF7">
                                <strong>Identitas</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Nama
                            </td>
                            <td>
                                <asp:Label ID="LbNama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Tempat / Tanggal Lahir
                            </td>
                            <td>
                                <asp:Label ID="LbTmpLahir" runat="server"></asp:Label>
                                &nbsp;/
                                <asp:Label ID="LbTglLhair" runat="server"></asp:Label>
                                &nbsp;(dd-MM-yyyy)
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Jenis Kelamin
                            </td>
                            <td>
                                <asp:Label ID="LbGender" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Warga Negara
                            </td>
                            <td>
                                <asp:Label ID="LbWarga" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Agama
                            </td>
                            <td>
                                <asp:Label ID="LbAgama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Alamat Rumah
                            </td>
                            <td>
                                <asp:Label ID="LbAlamat" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                No Handphone
                            </td>
                            <td>
                                <asp:Label ID="LbHp" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color: #D9EDF7">
                                <strong>Pendidikan Menengah</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Nama Sekolah
                            </td>
                            <td>
                                <asp:Label ID="LbSekolah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Jurusan
                            </td>
                            <td>
                                <asp:Label ID="LbJurusan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Tahun Lulus
                            </td>
                            <td>
                                <asp:Label ID="LbThnLulus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color: #D9EDF7">
                                <strong>Keluarga</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Jumlah Adik
                            </td>
                            <td>
                                <asp:Label ID="LbAdik" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Jumlah Kakak
                            </td>
                            <td>
                                <asp:Label ID="LbKakak" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Nama Ayah
                            </td>
                            <td>
                                <asp:Label ID="LbNamaAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Nama Ibu
                            </td>
                            <td>
                                <asp:Label ID="LbNamaIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pendidikan Ayah
                            </td>
                            <td>
                                <asp:Label ID="LbPendidikanAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pendidikan Ibu
                            </td>
                            <td>
                                <asp:Label ID="LbPendidikanIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pekerjaan Ayah
                            </td>
                            <td>
                                <asp:Label ID="LbPekerjaanAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pekerjaan Ibu
                            </td>
                            <td>
                                <asp:Label ID="LbPekerjaanIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Penghasilan Orang Tua
                            </td>
                            <td>
                                <asp:Label ID="LbPenghasilan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color: #D9EDF7">
                                <strong>Pilihan</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pilihan I
                            </td>
                            <td>
                                <asp:Label ID="LbPilihanI" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Pilihan II
                            </td>
                            <td>
                                <asp:Label ID="LbPilihanII" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color: #D9EDF7">
                                <strong>Nilai Akhir</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                Nilai
                            </td>
                            <td>
                                <asp:Label ID="LbNilai" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color: #D9EDF7">
                                <strong>Foto</strong>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="175px" Width="146px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
            </div>
            <br />
            <div class="col-xs-6 col-md-4 col-lg-3  highlight">
                Welcome :
                <asp:Label ID="LbUser" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Pelaporan Harian
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/home.aspx") %>">Beranda</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/today.aspx") %>">Pendaftar Hari Ini</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/info_prodi.aspx") %>">Rekapitulasi Sementara</a><br />
                        </span>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Pelaporan Akhir
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/hasil.aspx") %>">Pendaftar
                            Diterima</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/gagal.aspx") %>">Pendaftar Tidak Diterima</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/cabut.aspx") %>">Pendaftar Cabut</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/LsBerkasGagal.aspx") %>">Pendaftar Berkas Gagal</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/statistik.aspx") %>">Statistik Akhir</a>
                        </span>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Berkas Pendaftaran
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/berkas.aspx") %>">Cek Kelengkapan Berkas</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/BerkasInvalid.aspx") %>">Validasi Cabut Pendaftaran</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/BerkasGagal.aspx") %>">Validasi Berkas Gagal</a>
                        </span>
                    </div>
                </div>
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Fasilitas
                    </div>
                    <div class="panel-body">
                        <span class="style3"><a href="<%= Page.ResolveUrl("~/sm/admin/search.aspx") %>">Cari Pendaftar</a><br />
                            <a href="<%= Page.ResolveUrl("~/sm/admin/ViewPin.aspx") %>">Lihat PIN</a></span></div>
                </div>
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
        </div>
    </div>
</asp:Content>


