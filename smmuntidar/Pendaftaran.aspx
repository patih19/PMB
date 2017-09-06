<%@ Page Title="" Language="C#" MasterPageFile="~/SMM.Master" AutoEventWireup="true" CodeBehind="Pendaftaran.aspx.cs" Inherits="smmuntidar.WebForm1" EnableEventValidation="false" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
<div class="container top-atas" style="background-color: #F2F2FF;">
        <!-- #FCFCFC -->
        <!-- <div class="row">
            <div class=" col-xs-12 col-md-12 col-lg-12 ">
                <span class="style3">
                <br />
                </span><br />
                    </div>
SM-UNTIDAR (Seleksi Masuk Universitas Tidar), merupakan seleksi penerimaan mahasiswa baru yang diselenggarakan secara mandiri oleh Untidar. Seleksi ini didasarkan pada tes nilai rapor semester 1 s.d 5. Biaya pendaftaran seleksi ini sebesar Rp. 200.000,-. Pembayaran biaya pendaftaran hanya bisa dibayarkan melalui Bank Jateng.
                <br />
            </div> -->

    <div class="container top-atas" style="background-color: #F2F2FF;">
        <!-- #FCFCFC -->
        <div class="row">
            <div class=" col-xs-8 col-md-9 col-lg-9">
                SM-UNTIDAR (Seleksi Mandiri Universitas Tidar), merupakan seleksi 
                penerimaan mahasiswa baru yang diselenggarakan secara mandiri oleh Untidar. 
                Seleksi ini didasarkan pada nilai hasil tes tertulis setiap peserta. Biaya 
                pendaftaran seleksi sebesar Rp. 200.000,-. Pembayaran biaya pendaftaran dapat dibayarkan melalui Bank BPD Jateng dan Bank BNI.
                <br />
                <hr />
                <div class=" col-xs-12 col-md-12 col-lg-12 ">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <marquee direction="left">PENGUMUMAN PESERTA DITERIMA</marquee>
                        </div>
                        <div class="panel-body">
                            <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" Font-Overline="False"
                                Font-Strikeout="False" NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4bbDh3eE10ZmktTW8/view">Download Pengumuman</asp:HyperLink>
                            <br />
                        </div>
                    </div>
                </div>
                <div class=" col-xs-12 col-md-12 col-lg-12 ">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            Pilihan Program Studi</div>
                        <div class="panel-body">
                            <asp:GridView ID="GVPilihanProdi" CssClass="table table-striped" runat="server" CellPadding="4"
                                ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#6fb574" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#E2E2E2" Font-Bold="True" ForeColor="Black" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F9F9F9" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <%--<div class=" col-xs-12 col-md-12 col-lg-12 ">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            Statistik 
                            Pendaftar Tiap Program Studi</div>
                        <div class="panel-body">
                            <asp:GridView ID="GVProdi" CssClass="table table-striped" runat="server" CellPadding="4"
                                ForeColor="#333333" GridLines="None" onrowdatabound="GVProdi_RowDataBound" 
                                ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#6fb574" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#E2E2E2" Font-Bold="True" ForeColor="Black" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F9F9F9" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                </div>--%>
                <div class=" col-xs-12 col-md-12 col-lg-12 ">
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                        Peserta yang tercantum dalam daftar berikut untuk segera mengunggah foto dan mencetak kartu ujian</div>
                        <div class="panel-body">
                            <asp:GridView ID="GVNoFoto" CssClass="table table-striped" runat="server" CellPadding="4"
                                ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#6fb574" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#E2E2E2" Font-Bold="True" ForeColor="Black" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F9F9F9" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Content Information -->
            <div class="col-xs-4 col-md-3 col-lg-3  highlight">
                <!-- col-md-3 col-lg-3 -->
                <!-- ======= Info Lokasi & Ruang Ujian ======= -->
                <%--<div class="panel panel-success">
                    <div class="panel-heading">
                   <marquee direction="left">PENGUMUMAN PESERTA DITERIMA</marquee></div>
                    <div class="panel-body">
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            Target="_blank" Font-Overline="False" Font-Strikeout="False" 
                            NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4bbDh3eE10ZmktTW8/view">Download Pengumuman</asp:HyperLink> <br />
                    </div>
                </div>--%>

                <!-- ======= Info Lokasi & Ruang Ujian ======= -->
                <%--<div class="panel panel-danger">
                    <div class="panel-heading">
                   <marquee direction="left">PENGUMUMAN RUANG UJIAN</marquee></div>
                    <div class="panel-body">
                        <asp:HyperLink ID="HyperLink3" runat="server" 
                            Font-Overline="False" Font-Strikeout="False" 
                            NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4ba0hkblQzbkxha2M/view" Target="_blank" >1. SOSHUM</asp:HyperLink> <br />
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            Font-Overline="False" Font-Strikeout="False" 
                            NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4bLUtwVmttUS0zeUE/view" Target="_blank">2. SAINTEK</asp:HyperLink> <br />
                    </div>
                </div>--%>

                <!-- ====== HOTLINE ==== -->
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <h4>HOTLINE KANTOR PMB</h4>
                        <h4>085 103 590 555</h4>
                    </div>
                </div>
                <!-- ====== PMDK ==== -->
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <a class="btn btn-success" href="http://pmdk.untidar.ac.id" target="_blank"><h5>Jalur Pmdk Diploma</h5></a> 
                    </div>
                </div>
                <!-- ========= Pendaftaran ========= -->
                <div class="panel panel-warning">
                    <div class="panel-heading">
                            <a class="btn btn-danger" href="<%= Page.ResolveUrl("~/tagihan.aspx") %>"><h5>Daftar Sekarang</h5></a> 
                    </div>
                </div>
                <!-- ========= Download Panduan ========= -->
                <div class="panel panel-info">
                    <div class="panel-heading">
                    Download Panduan 
                        Pembayaran</div>
                    <div class="panel-body">
                    <%-- <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4bd29tT2FEbUxDVHM/view?usp=sharing" 
                            Target="_blank" Font-Overline="False" Font-Strikeout="True">Panduan Pendaftaran</asp:HyperLink> --%>
                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" 
                            Font-Overline="False" Font-Strikeout="False" 
                            NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4bWnctdmJFTWNFaFk/view">JAWA TENGAH (Bank BPD Jateng)</asp:HyperLink><br /> 
                            <asp:HyperLink ID="HyperLink5" runat="server" Target="_blank" 
                            Font-Overline="False" Font-Strikeout="False" 
                            NavigateUrl="https://drive.google.com/file/d/0B9QhYV69qy4bM21qR2RydkN2M2s/view">LUAR JATENG (Bank BNI)</asp:HyperLink> 
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
                                    <asp:TextBox CssClass="form-control" ID="TBNoDaftar" placeholder="Input No Pendaftaran" runat="server" 
                                        Width="170px" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqTagihan" runat="server" ErrorMessage="Input No Pendaftaran"
                                        ControlToValidate="TBNoDaftar" Display="None" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValUsername" runat="server" TargetControlID="ReqTagihan">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TBPin" placeholder="Input PIN" runat="server" Width="170px" 
                                        TextMode="Password" MaxLength="12"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqPIN" runat="server" ErrorMessage="Input PIN"
                                        ControlToValidate="TBPin" Display="None" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="ReqPIN">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <cc1:captchacontrol ID="Captcha" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                        CaptchaHeight="60" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                        CaptchaMaxTimeout="240" FontColor="#529E00" BackColor="White" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <em>Ketik ulang kode yang tampak pada gambar diatas : </em>
                                    <asp:TextBox CssClass="form-control" ID="TBReCaptcha" runat="server" Width="130px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqKode" runat="server" ErrorMessage="Input Kode Keamanan"
                                        ControlToValidate="TBReCaptcha" Display="None" SetFocusOnError="true"> </asp:RequiredFieldValidator>
                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="ReqKode">
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<asp:Button ID="BtLogin" runat="server" Text="Login" onclick="BtLogin_Click" />
                                    &nbsp;--%>
                            </tr>
                        </table>
                        <hr />
                        Untuk melakukan login, isi nomor Jurnal dan PIN (case sensitive) yang tertera pada
                        bukti pembayaran dari Bank</div>
                </div>
                <!-- ======== Upload Slip Pembayaran ======== -->
                <div class="panel panel-danger">
                    <div class="panel-heading">
                   Upload Bukti Pembayaran</div>
                    <div class="panel-body">
                        Kirim bukti pembayaran / slip pembayaran
                    bagi peserta yang membayar di Bank BNI. 
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/ValUpload.aspx" 
                            Target="_blank">Upload</asp:HyperLink>
                    </div>
                </div>
            </div>
            <!--  End Menu -->
        </div>
    </div>
    <!-- End COntainer -->

        </div>
</asp:Content>
