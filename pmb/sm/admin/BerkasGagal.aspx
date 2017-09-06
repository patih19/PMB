<%@ Page Title="" Language="C#" MasterPageFile="~/sm/sm.Master" AutoEventWireup="true" CodeBehind="BerkasGagal.aspx.cs" Inherits="pmb.sm.WebForm13" %>

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
                <strong><span class="style5">Input peserta yang berkasnya tidak lolos / tidak 
                sah:<br />
                </span></strong>
                <br />
                proses ini dilakukan setelah 
                penutupan pendaftaran
                <table class="table-condensed table-bordered">
                    <tr>
                        <td>Masukkan No Tagihan/ Jurnal  </td>
                        <td>
                            <asp:TextBox ID="TbCari" runat="server" CssClass="form-control" Width="150px" 
                                MaxLength="25"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="BtnCari" runat="server" onclick="BtnCari_Click" Text="Cari" />
                        </td>
                        <td>
                            <asp:Label ID="LbKeterangan" runat="server"></asp:Label>
                        </td>
                    </tr>
                    </table>
                <br />
                <br />
                <asp:Panel ID="PanelDetailPendaftar" runat="server">
                <asp:Label ID="LbNoTagihan" runat="server"></asp:Label>
                    <table class="table-condensed table-bordered">
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#D9EDF7"><strong>Identitas</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama</td>
                            <td>
                                <asp:Label ID="LbNama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Tempat / Tanggal Lahir</td>
                            <td>
                                <asp:Label ID="LbTmpLahir" runat="server"></asp:Label>
&nbsp;/
                                <asp:Label ID="LbTglLhair" runat="server"></asp:Label>
                            &nbsp;(dd-MM-yyyy)</td>
                        </tr>
                        <tr>
                            <td class="text-right">Jenis Kelamin</td>
                            <td>
                                <asp:Label ID="LbGender" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Warga Negara</td>
                            <td>
                                <asp:Label ID="LbWarga" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Agama</td>
                            <td>
                                <asp:Label ID="LbAgama" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Alamat Rumah</td>
                            <td>
                                <asp:Label ID="LbAlamat" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">No Handphone</td>
                            <td>
                                <asp:Label ID="LbHp" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#D9EDF7"><strong>Pendidikan Menengah</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama Sekolah</td>
                            <td>
                                <asp:Label ID="LbSekolah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Jurusan</td>
                            <td>
                                <asp:Label ID="LbJurusan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Tahun Lulus</td>
                            <td>
                                <asp:Label ID="LbThnLulus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#D9EDF7"><strong>Keluarga</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Jumlah Adik</td>
                            <td>
                                <asp:Label ID="LbAdik" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Jumlah Kakak</td>
                            <td>
                                <asp:Label ID="LbKakak" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama Ayah</td>
                            <td>
                                <asp:Label ID="LbNamaAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Nama Ibu</td>
                            <td>
                                <asp:Label ID="LbNamaIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pendidikan Ayah</td>
                            <td>
                                <asp:Label ID="LbPendidikanAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pendidikan Ibu</td>
                            <td>
                                <asp:Label ID="LbPendidikanIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pekerjaan Ayah</td>
                            <td>
                                <asp:Label ID="LbPekerjaanAyah" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pekerjaan Ibu</td>
                            <td>
                                <asp:Label ID="LbPekerjaanIbu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Penghasilan Orang Tua</td>
                            <td>
                                <asp:Label ID="LbPenghasilan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#D9EDF7"><strong>Pilihan</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">Pilihan I</td>
                            <td>
                                <asp:Label ID="LbPilihanI" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-right">Pilihan II</td>
                            <td>
                                <asp:Label ID="LbPilihanII" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-left" colspan="2" style="background-color:#FFE8A6"><strong>Pastikan 
                                data yang akan diproses tidak salah</strong></td>
                        </tr>
                        <tr>
                            <td class="text-right">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="BtnProses" runat="server" CssClass="btn btn-danger" OnClientClick="return confirm('Proses Tidak Dapat Diulang Kembali, Anda Yakin ?');"  onclick="BtnProses_Click" 
                                    Text="Proses" />
                                &nbsp;</td>
                        </tr>
                    </table >
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
