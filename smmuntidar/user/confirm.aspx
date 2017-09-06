<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="confirm.aspx.cs" Inherits="smmuntidar.user.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container top-buffer"  style="background-color: #F2F2FF;">
<p></p>
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="PanelBdk" runat="server" CssClass="form-control" BackColor="#FFFF99">
                        Pengisian formulir pendaftaran urut mulai<strong> tahap 1 (satu) sampai 8 
                        (delapan)
                        </strong>
                </asp:Panel>
            </div>
        </div>
        <p></p>
    <div class="row">
        <div class="col-md-12">
        <strong><span class="style3">Tahap Ke-1 : Form Persetujuan</span></strong><br /><br />
            <em>Bacalah persetujuan yang ditampilkan :</em>
            <ol>
                <li>Kode PIN yang anda dapatkan merupakan kode pengaman yang hanya dapat dipergunakan
                    untuk pengisian Biodata SM-UNTIDAR secara online.</li>
                <li>Kode PIN hanya diizinkan untuk pemakaian tunggal bagi calon yang membeli secara resmi
                    pada bank yang ditunjuk dan tidak diizinkan untuk pemakaian secara bersama-sama.</li>
                <li>Penggunaan dan atau pemanfaatan Kode PIN untuk pengisian Biodata SM-UNTIDAR tanpa
                    seizin anda sebagai pemegang resmi kode PIN sama sekali TIDAK DIPERKENANKAN.</li>
                <li>DILARANG KERAS menggunakan atau memanfaatkan Kode PIN yang Anda miliki ini untuk
                    kepentingan yang dapat melanggar peraturan dan ketentuan yang sudah dikeluarkan
                    oleh Panitia SM-UNTIDAR.</li>
                <li>Pihak panitia SM-UNTIDAR tidak bertanggung jawab terhadap segala resiko yang timbul
                    akibat dari pemakaian secara bersama-sama maupun pemakaian yang melanggar
                    ketentuan.</li>
                <li>Seluruh proses pengolahan data akan dilakukan dengan komputer. Ikuti dengan seksama
                    petunjuk pengisian dan jangan melakukan kesalahan-kesalahan yang dapat merugikan
                    Anda sendiri.</li>
                <li>Bila diketahui tidak jujur dalam memberikan keterangan yang diminta dan atau yang
                    tidak benar/palsu dalam mengisi Biodata SM-UNTIDAR online ini, maka Anda akan dikenai
                    sanksi dikeluarkan walaupun sudah dinyatakan diterima menjadi mahasiswa.</li>
                <li>Dengan memanfaatkan Kode PIN untuk pengisian Biodata SM-UNTIDAR ini berarti Anda
                    mengerti dan setuju dengan seluruh ketentuan ini.</li>
            </ol>
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:RadioButton ID="RBSetuju" runat="server" 
                Text="Setuju dan Mengikuti perjanjian diatas" />
        &nbsp;
            <asp:RadioButton ID="RBBack" runat="server" Text="tidak setuju" />
            <br />
            <asp:Button ID="BtLanjut" runat="server" Text="Lanjut &gt;&gt;" 
                onclick="BtLanjut_Click" />
            <br />
        </div>
    </div>
    </div>
</asp:Content>
