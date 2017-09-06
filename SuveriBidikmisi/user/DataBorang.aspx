<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBorang.aspx.cs" Inherits="SuveriBidikmisi.user.DataBorang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class=" table table-condensed table-hover">
            <tr>
                <td>
                    <strong>BORANG PRIBADI (1)</strong>
                </td>
                <td>
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
                    Alamat Lengkap
                </td>
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
                    No. Telpon Rumah
                </td>
                <td>
                    <asp:Label ID="LbTelpRumah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Nama Ayah
                </td>
                <td>
                    <asp:Label ID="LbNamaAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Status Ayah
                </td>
                <td>
                    <asp:Label ID="LbStatusAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Pendidikan Terakhir Ayah
                </td>
                <td>
                    <asp:Label ID="LbPendidikanAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Data Pekerjaan Ayah
                </td>
                <td>
                    <asp:Label ID="LbPekerjaanAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah Modal Usaha
                </td>
                <td>
                    <asp:Label ID="LbModalUsahaAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah Laba
                </td>
                <td>
                    <asp:Label ID="LbLabaAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Nama Ibu/Wali
                </td>
                <td>
                    <asp:Label ID="LbNamaIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Status Ibu/Wali
                </td>
                <td>
                    <asp:Label ID="LbStatusIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Pendidikan Terakhir Ibu/Wali
                </td>
                <td>
                    <asp:Label ID="LbPendidikanIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Data Pekerjaan Ibu
                </td>
                <td>
                    <asp:Label ID="LbPekerjaanIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah Modal Usaha
                </td>
                <td>
                    <asp:Label ID="LbModalUsahaIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah Laba
                </td>
                <td>
                    <asp:Label ID="LbLabaIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG KELUARGA (2)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah orang serumah
                </td>
                <td>
                    <asp:Label ID="LbJumlahOrangSerumah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah saudara kandung
                </td>
                <td>
                    <asp:Label ID="LbJumlahSaudara" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah saudara kandung sedang kuliah
                </td>
                <td>
                    <asp:Label ID="LbJumlahSdrKuliah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jumlah saudara kandung sekolah
                </td>
                <td>
                    <asp:Label ID="LbJumSdrSekolah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG RUMAH (3)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Status kepemilikan rumah
                </td>
                <td>
                    <asp:Label ID="LbStatusMilikRumah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Sumber Listrik
                </td>
                <td>
                    <asp:Label ID="LbSumberListrik" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Daya Listrik (KWH)
                </td>
                <td>
                    <asp:Label ID="LbDayaListrik" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rata-rata biaya listrik per bulan
                </td>
                <td>
                    <asp:Label ID="LbBiayaListrikBulanan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Sumber Air
                </td>
                <td>
                    <asp:Label ID="LbSumberAir" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rata-rata biaya air per bulan
                </td>
                <td>
                    <asp:Label ID="LbBiayaAirBulanan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Luas tanah M<sup>2</sup>
                </td>
                <td>
                    <asp:Label ID="LbLuasTanah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Luas bangunan M<sup>2</sup>
                </td>
                <td>
                    <asp:Label ID="LbLuasBangunan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    NJOP/M<sup>2</sup>
                </td>
                <td>
                    <asp:Label ID="LbNJOP" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Bahan atap rumah
                </td>
                <td>
                    <asp:Label ID="LbAtap" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Bahan lantai rumah
                </td>
                <td>
                    <asp:Label ID="LbLantaiRumah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Ruang tengah keluarga
                </td>
                <td>
                    <asp:Label ID="LbRuangTengah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Dapur
                </td>
                <td>
                    <asp:Label ID="LbDapur" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Cuci piring, gelas dan baju
                </td>
                <td>
                    <asp:Label ID="LbCuciPiringGelas" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Keperluan mandi/kamar mandi
                </td>
                <td>
                    <asp:Label ID="LbKeperluanMandi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Teras
                </td>
                <td>
                    <asp:Label ID="LbTeras" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Garasi
                </td>
                <td>
                    <asp:Label ID="LbGarasi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG LINGKUNGAN RUMAH (4)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Luas taman M<sup>2</sup>
                </td>
                <td>
                    <asp:Label ID="LbLuasTaman" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Pagar
                </td>
                <td>
                    <asp:Label ID="LbPagar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jalan masuk dari jalan raya
                </td>
                <td>
                    <asp:Label ID="LbJalanMasuk" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Selokan air
                </td>
                <td>
                    <asp:Label ID="LbSelokan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG PERABOT RUMAH (5)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli meja kursi ruang tamu
                </td>
                <td>
                    <asp:Label ID="LbHargaMejaKursiRuangTamu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli almari,bifet dan sejenisnya (total harga belinya)
                </td>
                <td>
                    <asp:Label ID="LbHargaAlmarBifet" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli meja kursi ruang tengah/keluarga (harga belinya)
                </td>
                <td>
                    <asp:Label ID="LbHargaMejaKursiRuangTengah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli meja kursi ruang makan
                </td>
                <td>
                    <asp:Label ID="LbHargaMejaKursiRuangMakan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli meja kursi ruang teras
                </td>
                <td>
                    <asp:Label ID="LbHargaMejaKursiTeras" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli tempat tidur
                </td>
                <td>
                    <asp:Label ID="LbHargaTempatTidur" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli televisi
                </td>
                <td>
                    <asp:Label ID="LbHargaTV" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli keseluruhan komputer,laptop & printer
                </td>
                <td>
                    <asp:Label ID="LbHargaKomputerLaptop" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli keseluruhan gas,oven & perabot dapur
                </td>
                <td>
                    <asp:Label ID="LbHargaPeralatanDapur" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Harga beli meja rias
                </td>
                <td>
                    <asp:Label ID="LbHargaMejaRias" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG FASILITAS (6)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Rata-rata biaya telepon dan pulsa handphone per bulan sekeluarga
                </td>
                <td>
                    <asp:Label ID="LbBiayaTelpDanHp" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rata-rata biaya internet per bulan sekeluarga
                </td>
                <td>
                    <asp:Label ID="LbBiayaInternet" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG SOSIAL EKONOMI (7)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Rata-rata pendapatan total ayah/wali
                </td>
                <td>
                    <asp:Label ID="LbPendapatanAyah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Rata-rata pendapatan total ibu/wali
                </td>
                <td>
                    <asp:Label ID="LbPendapatanIbu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total hutang kelurga
                </td>
                <td>
                    <asp:Label ID="LbHutangKeluarga" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Cicilan hutang per bulan
                </td>
                <td>
                    <asp:Label ID="LbCicilanHutang" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <strong>BORANG KEPEMILIKAN HARTA/ASET KELUARGA (8)</strong>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Sawah (perkiraan harga jual sekarang)
                </td>
                <td>
                    <asp:Label ID="LbSawah" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Tanah,ladang,kebun (perkiraan harga jual sekarang)
                </td>
                <td>
                    <asp:Label ID="LbLadangKebun" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Ternak (perkiraan harga jual sekarang)
                </td>
                <td>
                    <asp:Label ID="LbTernak" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Mobil (perkiraan harga jual sekarang)
                </td>
                <td>
                    <asp:Label ID="LbMobil" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Tabungan,giro,deposito
                </td>
                <td>
                    <asp:Label ID="LbTabungan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Perhiasan (perkiraan harga jual sekarang)
                </td>
                <td>
                    <asp:Label ID="LbPerhiasan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Sepeda, speda motor dan sejenisnya (perkiraan harga jual sekarang)
                </td>
                <td>
                    <asp:Label ID="LbSepedaMotor" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <p>
        </p>
        <table class=" table table-condensed table-hover">
            <tr>
                <td>
                    <strong>BORANG DOKUMEN (9)</strong>
                </td>
            </tr>
            <tr>
                <td>
                    Rumah<br />
                    <asp:Image ID="ImgRumah" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Ruang Tamu<br />
                    <asp:Image ID="ImgRuangTamu" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Ruang Tengah<br />
                    <asp:Image ID="ImgRuangTengah" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Kamar Tidur<br />
                    <asp:Image ID="ImgKamarTidur" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Dapur<br />
                    <asp:Image ID="ImageDapur" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Kamar Mandi<br />
                    <asp:Image ID="ImageKamarMandi" runat="server" />
                </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
