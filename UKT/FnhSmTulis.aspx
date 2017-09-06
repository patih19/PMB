<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="FnhSmTulis.aspx.cs" Inherits="UKT.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style4
    {
        background-color: #FFFF66;
    }
        .style5
        {
            background-color: #B7DBFF;
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
                <div class="form-horizontal">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                Finish</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class=" col-lg-12 col-md-10 col-xs-8">
                                <div class="form-group">
                                    <%--<label class="col-md-3 col-xs-12 control-label">
                                   Terimakasih</label>--%>
                                    <div class="col-lg-12 col-md-10 col-xs-12">
                                        <div class="input-group">
                                        <br />
                                            <table class="table-condensed">
                                                <tr>
                                                    <td>
                                                        <h4>
                                                            Terimakasih Anda telah selesai mengisi borang sosial ekonomi, </h4>
                                                        <h4>
                                                            informasi terkait penerimaan
                                                            mahasiswa baru akan kami umumkan melalui laman <a href="http://untidar.ac.id" target="_blank">
                                                                untidar.ac.id</a></h4>
                                                                <hr />
                                                        <h4>
                                                            <span class="style4">Biodata sosial ekonomi dapat diunduh pada link berikut&nbsp;
                                                            </span>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="style4" 
                                                                OnClick="LinkButton1_Click" Font-Overline="False" Font-Strikeout="False" 
                                                                Font-Underline="False">download</asp:LinkButton>
                                                        </h4>
                                                        <h4>
                                                            Biaya UKT Anda :
                                                            <asp:Label ID="LbUktMandiri" runat="server" Font-Bold="True"></asp:Label>
                                                        </h4>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="PanelMandiri" runat="server">
                                            <hr />
                                                <h4><span class="style6">Pengumuman Mahasiswa Baru Jalur SM-UNTIDAR, Wajib Dicatat</span></h4>
                                                <div style="font-size:medium">
                                                <table class="table table-bordered">
                                                    <tr>
                                                        <td><b>No.</b></td>
                                                         <td><b>Kegiatan</b></td>
                                                          <td><b>Tanggal </b></td>
                                                        <td>
                                                            <b>Keterangan</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            1.</td>
                                                        <td>
                                                            Pembayaran Uang Kuliah Tunggal</td>
                                                        <td>
                                                            31 Juli-7 Agustus 2017</td>
                                                        <td>
                                                            Melalui Bank BPD Jateng untuk wilayah jawa tengah dan sekiranya, Bank BNI untuk 
                                                            Luar Jawa, simpan baik-baik slip pembayaran.</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            2.</td>
                                                        <td>
                                                            Registrasi Online </td>
                                                        <td>
                                                            31 Juli-7 Agustus 2017</td>
                                                        <td>
                                                            Mengisi biodata online, keterangan lebih janjut pada laman <a target="_blank" href="http://registrasi.untidar.ac.id">
                                                            registrasi.untidar.ac.id</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            3.</td>
                                                        <td>
                                                            Melengkapai dokumen registrasi &amp; pemotretan untuk pembuatan KTM</td>
                                                        <td>
                                                            8-10 Agustus 2017</td>
                                                        <td>
                                                            -</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            4.</td>
                                                        <td>
                                                            Mekanisme registrasi (daftar ulang)</td>
                                                        <td>
                                                            31 Juli 2017</td>
                                                        <td>
                                                             <a target="_blank" href="http://untidar.ac.id/penerimaan">
                                                            www.untidar.ac.id</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            5.</td>
                                                        <td>
                                                            Pembayaran Sumbangan Pengembangan Institusi</td>
                                                        <td>
                                                            14 Agustus 2017 - sebelum pelaksanaan ujian akhir semester (UAS)</td>
                                                        <td>
                                                            Dibayarkan melalui <strong>Bank BPD Jateng</strong> dengan menunjukkan Nama dan 
                                                            Nomor Mahasiswa (NPM).</td>
                                                    </tr>
                                                </table>
                                                </div>
                                            </asp:Panel>
                                            <br />
                                            <asp:Panel ID="PanelPanduan" runat="server">
                                            <h4> <span class="style4"><strong>PANDUAN PEMBAYARAN UKT</strong></span> </h4>
                                                <h4>
                                                    <strong>A. UNTUK WILAYAH JAWA TENGHAH :</strong></h4>
                                                <h4>
                                                    Pembayaran UKT melalui bank BDP Jawa Tengah dengan menunjukkan Nama dan Nomor 
                                                    Pendaftaran SM-UNTIDAR kepada Teller Bank. Sebelum membayar tanyakan kepada 
                                                    Teller apakah pemabayarannya Online, jika tidak silahkan pindah ke kantor Bank 
                                                    BDP Jateng yang lain, karena PIN Registrasi tidak didapat jika pembayarannya 
                                                    secara Manual/Offline</h4>
                                                <hr />
                                            <h4><strong>B. UNTUK WILAYAH DI LUAR JAWA TENGAH / TIDAK DAPAT MENJANGKAU BANK BPD 
                                                JATENG :</strong></h4> 
                                            <h4>
                                                Pembayaran UKT melalui bank BNI dengan jenis pembayaran SKN(Kliring) dari Bank 
                                                BNI ke Bank BPD Jateng, berikut contoh formulir setoran dari Bank BNI yang 
                                                ditujukan kepada Bendahara Penerimaan Untidar Bank BPD Jawa Tengah melalui nomor 
                                                rekening 1005004353, isilah formulir setoran sesuai petunjuk di bawah ini.</h4>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/img/Kliring Jateng_.png" />
                                            <br />
                                            <br />
                                            <h4>Tahap berikutnya scan bukti pembayaran dengan mesin pindai (scanner) kemudian 
                                                unggah bukti tersebut sesuai dengan ketentuan.</h4>
                                            <table class="table-condensed table-bordered">
                                                <tr>
                                                    <td class="style5">
                                                        <h5><strong>Upload Slip/Kwitansi/Bukti Pembayaran</strong></h5>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top">
                                                    <div style="font-size:medium">
                                                        Ketentuan Upload :<br />
                                                        <ol>
                                                            <li>File dalam bentuk image dengan format<span class="m"> jpg, png atau jpeg</span></li>
                                                            <li>Besar ukuran file antara <span class="style6">300 - 500 Kb</span></li>
                                                            <li>File harus berwarna full color tidak diperkenankan berwarna hitam putih/grayscale</li>
                                                            <li>Upload Hanya dapat dilakukan satu kali saja</li>
                                                        </ol>
                                                        </div>
                                                                                                                <table class="table-condensed" style="background-color: #C5E5C5">
                                                            <tr>
                                                                <td style="background-color: #FFFF99" colspan="2">
                                                                    <h5><strong>Form Upload</strong></h5> 
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                   <h5>Bukti pembayaran</h5> </td>
                                                                <td>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="None" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h5>Email</h5> </td>
                                                                <td>
                                                                    <asp:TextBox ID="TbEmail" runat="server" CssClass="form-control" 
                                                                        TextMode="Email" Placeholder="Hati-hati menulis email"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="BtnUpload" CssClass="btn btn-primary" runat="server" Text="Upload (KHUSUS BANK BNI)"
                                                                        OnClick="BtnUpload_Click" 
                                                                        onclientclick="return confirm('Anda Yakin Alamat Email Sudah Benar ?');" /> &nbsp;<h5><span 
                                                                        class="style6">Periksa kembali alamat email sebelum unggah berkas </span></h5>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="LbSuccess" runat="server" ForeColor="#339933"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                </table>
                                            <br />
                                            </asp:Panel>
                                            <asp:Label ID="Lberr" runat="server" ForeColor="Red"></asp:Label>
                                            <br />

                                            <%-- <h3 class="style4">WAJIB DICATAT !!</h3>
                                        <ol>
                                            <li>Pembayaran UKT untuk memperoleh PIN Registrasi melalui Bank <strong>
                                                <span class="style5">BPD JAWA TENGAH</span></strong> dengan menunjukkan <strong>No 
                                                Pendaftaran SMM-UNTIDAR</strong> pada tanggal 11 s.d 13 Agustus 2015</li>
                                            <li>PIN registrasi ada pada bukti pembayaran dari Bank Jateng yang terdiri dari 6 
                                                huruf</li>
                                            <li>Bagi calon Mahasiswa yang <strong><span class="style6">tidak dapat </span>
                                                </strong>menjangkau Bank Jateng biaya UKT dibayarkan melalui <strong>
                                                <span class="style6">Bank BNI</span></strong> ke nomor rekening <strong>
                                                <span class="style6">1005004353</span></strong> atas nama 
                                                Bendahara Penerimaan Untidar dengan sistem SKN atau setoran manual melalui 
                                                kliring antar bank beserta beban biaya transaksinya,&nbsp; kemudian bukti 
                                                pembayaran dikirim melalui email ke alamat <a href="mailto:pmb@untidar.ac.id">pmb@untidar.ac.id</a> 
                                                dengan subject UKT SMM-UNTIDAR Tahun 2015</li>
                                            <li>Pembayaran melalui <strong>Bank BNI </strong>PIN registrasinya akan diberikan 
                                                setelah bukti pembayaran sudah kami terima</li>
                                            <li>Universitas Tidar <strong><span class="style6">tidak menerima</span></strong> 
                                                transaksi pembayaran melalui <span class="style5"><strong>ATM , transfer dan 
                                                transaksi online</strong></span></li>
                                            <li>Proses akan lebih <span class="style5"><strong>cepat dan mudah </strong></span>&nbsp;jika calon mahasiswa memilih membayar biaya UKT melalui Bank Jateng</li>
                                        </ol> --%>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
