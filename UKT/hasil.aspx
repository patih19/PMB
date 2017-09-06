<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="hasil.aspx.cs" Inherits="UKT.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            color: #FF3300;
        }
        .style5
        {
            font-size: medium;
        }
        .style6
        {
            font-size: small;
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
                                <strong></strong>Hasil Penilaian UKT(9)</h3>
                        </div>
                        <div class="panel-body form-group-separated">
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    Kategori UKT</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <asp:Label ID="LbUKT" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                   Biaya Registrasi</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <asp:Label ID="LBBiaya" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                   Pembayaran</label>
                                <div class="col-md-6 col-xs-12">
                                    <div class="input-group">
                                        <h3 class="style4">WAJIB DICATAT !!</h3>
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
                                            <li>Proses akan lebih <span class="style5"><strong>cepat &amp; sederhana </strong></span>&nbsp;jika calon mahasiswa memilih membayar biaya UKT melalui Bank Jateng</li>
                                        </ol>
                                    </div>
                                </div>
                            </div>


                            <!-- <div class="form-group">
                                <label class="col-md-3 col-xs-12 control-label">
                                    File</label>
                                <div class="col-md-6 col-xs-12">
                                    <input type="file" class="fileinput btn-primary" name="filename" id="filename" title="Browse file" />
                                    <span class="help-block">Input type file</span>
                                </div>
                            </div> -->
                        </div>
                        <div class="panel-footer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
