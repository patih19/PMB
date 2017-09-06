<%@ Page Title="" Language="C#" MasterPageFile="~/Pin.Master" AutoEventWireup="true" CodeBehind="Pendaftaran.aspx.cs" Inherits="PinSemuntidar.WebForm1" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         .style1
         {
             color: #FFFFFF;
         }
         .style3
         {
             font-size: 16px;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
        <!-- #FCFCFC -->
        <div class="row">
            <div class=" col-xs-6 col-md-8 col-lg-9 ">
                <span class="style3">Calon peserta yang akan mengisi Biodata online harus memperhatikan
                    beberapa hal sebagai berikut :</span><br />
                &nbsp;<ol>
                    <li>Memiliki Nomor Jurnal/ No Tagihan dan PIN. Untuk memperolehnya klik tombol "Pembuatan
                        nomor tagihan Biaya Seleksi SMUNTIDAR&quot; atau klik sini</li>
                    <li>No Peserta SMUNTIDAR didapat setelah login menggunakan NO JURNAL dan PIN dan kemudian
                        mengisi biodata secara online </li>
                    <li>Simpan baik-baik No. Peserta ,No. Jurnal/ No. Tagihan dan PIN yang anda dapatkan.
                        Kegita hal tersebut merupakan identitas peserta SMUNTIDAR untuk digunakan pada seluruh
                        proses seleksi SMUNTIDAR seperti Pengisian Biodata Online, Pencetakan Kartu Peserta
                        Ujian dan Sebagai bukti tanda peserta ketika melakukan registrasi mahasiswa baru
                        apabila Anda diterima </li>
                    <li>Pengisian Biodata hanya dilakukan satu kali saja dan tidak diberikan fasilitas untuk
                        melakukan perubahan/perbaikan isian Biodata terhadap data yang sudah diisikan secara
                        online</li>
                    <li>Terkait poin 4 di atas, sebelum melakukan pengisian Biodata online sebaiknya calon
                        peserta sudah mempersiapkan dokuemn sebagai berikut :
                        <br />
                        <ol style="list-style-type: lower-alpha">
                            <li>Biodata Pribadi Lengkap</li>
                            <li>Data asal pendidikan (Ijazah, Nilai UN/Transkrip)</li>
                            <li>Data Pribadi orang tua/wali</li>
                            <li>Hasil scan atau file foto berwarna ukuran 3x4 dengan ukuran maksimal 100 kbyte dan
                                format JPG. Pas foto harus menggunakan dan pose formal untuk kebutuhan akademik.</li>
                            <li>Hasil Biodata yang telah dicetak yang didownload bersamaan dengan kartu peserta
                                (setelah ditempel materai yang ditandatangani, pas foto ukuran 3X4 berwarna dan
                                dicap jempol tangan kiri). Kemudian pastikan hasil scan dalam bentuk image dengan
                                format jpg/jpeg dengan ukuran 300kb.</li>
                        </ol>
                    </li>
                    <li>Untuk dapat mengikuti ujian peserta harus dapat menunjukkan KARTU PESERTA SMUNTIDAR
                        tercetak sebagai persyaratan. Kartu peserta bisa didapat dengan cara di download
                        kemudian dicetak</li>
                    <li>Bagi calon peserta seleksi wajib mencetak KARTU BUKTI PENDAFTARAN. KARTU BUKTI PENDAFTARAN
                        dapat didownload dan dicetak</li>
                </ol>
            </div>
            <!-- End Content Information -->
            <div class="col-xs-6 col-md-4 col-lg-3  highlight">
                <!-- col-md-3 col-lg-3 -->
                <!-- ========= Pendaftaran ========= -->
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <a href="<%= Page.ResolveUrl("~/tagihan.aspx") %>">NO. TAGIHAN
                        <br />
                        BIAYA SELEKSI SMUNTIDAR
                    </a>
                    </div>
                </div>
                <!-- ========= Login Form ========= -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                        Login
                    </div>
                    <div class="panel-body">
                        <table class="table-condensed">
                            <tr>
                                <td>
                                    No.Tagihan
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TBNoTagihan" runat="server" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    PIN
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TBPin" runat="server" Width="130px" 
                                        TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc2:captchacontrol ID="Captcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="6"
                                        CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="White" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <em>Ketik Ulang tulisan yang tampil pada gambar diatas : </em>
                                    <asp:TextBox CssClass="form-control" ID="TBReCaptcha" runat="server" Width="130px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtLogin" runat="server" Text="Login" onclick="BtLogin_Click" />
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <hr />
                        Untuk melakukan login, isi nomor Jurnal dan PIN (case sensitive) yang tertera pada
                        bukti pembayaran dari Bank</div>
                </div>
                <!-- End Login -->
            </div>
            <!--  End Menu -->
        </div>
    </div>
    <!-- End COntainer -->
</asp:Content>
