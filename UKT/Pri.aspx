<%@ Page Title="" Language="C#" MasterPageFile="~/UKT.Master" AutoEventWireup="true" CodeBehind="Pri.aspx.cs" Inherits="UKT.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            font-size: medium;
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Panel ID="PanelBdk" runat="server" CssClass="form-control" BackColor="#FFFF99">
                    <h4>Bagi Peserta BIDIKMISI wajib mengisi seluruh form sebelum <strong>menunduh dan 
                        mencetak </strong>  borang sosial ekonomi</h4> 
                </asp:Panel>
            </div>
        </div>
    </div>
    <div class="container top-atas">
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
                        <strong></strong>Borang Pribadi (1)</h3>
                </div>
                <div class="panel-body form-group-separated">
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Nama</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                <asp:TextBox ID="TbNama" runat="server" Width="220px"></asp:TextBox>
                            </div>
                            <span class="help-block">This is sample of text field</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Jenis Kelamin</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DlGender" runat="server">
                                    <asp:ListItem>Laki-laki</asp:ListItem>
                                    <asp:ListItem>Perempuan</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Tempat lahir</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">     
                                <span class="input-group-addon"><span class="fa fa-pencil"></span></span>                          
                                <asp:TextBox ID="TempatLahir" runat="server" Width="150px"></asp:TextBox>
                            </div>
                            <span class="help-block">This is sample of text field</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Tanggal lahir</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                <asp:TextBox ID="TbTgLahir" CssClass="datepicker" runat="server"></asp:TextBox> 
                            </div>
                            <span class="help-block">Tahun-bulan-tanggal (yyyy-mm-dd) </span>&nbsp;</div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                           Alamat Lengkap</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                               <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                                <asp:TextBox ID="TbAlamat" runat="server" Width="400px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <span class="help-block">This is sample of text field</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Email</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:TextBox ID="TbEmail" runat="server"></asp:TextBox>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            No Handphone</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:TextBox ID="TbHp" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            No Telp Rumah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:TextBox ID="TbTelpRmh" runat="server"></asp:TextBox>
                            </div>
                            <span class="help-block">Diisi tanda - jika tidak ada</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Nama Ayah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:TextBox ID="TbAyah" runat="server"></asp:TextBox>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Satus Ayah/wali</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DlStAyah" runat="server">
                                    <asp:ListItem>Hidup</asp:ListItem>
                                    <asp:ListItem>Meninggal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Pendidikan Terakhir Ayah/wali</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLPendidikanAyah" runat="server">
                                    <asp:ListItem Value="1">SD</asp:ListItem>
                                    <asp:ListItem Value="2">SMP</asp:ListItem>
                                    <asp:ListItem Value="4">SMA</asp:ListItem>
                                    <asp:ListItem Value="6">Diploma</asp:ListItem>
                                    <asp:ListItem Value="8">Sarjana (S1)</asp:ListItem>
                                    <asp:ListItem Value="10">Magister (S2)</asp:ListItem>
                                    <asp:ListItem Value="15">Doktor (S3)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Data Pekerjaan Ayah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLKerjaanAyah" runat="server">
                                    <asp:ListItem Value="0">Tidak Bekerja</asp:ListItem>
                                    <asp:ListItem Value="1">Buruh</asp:ListItem>
                                    <asp:ListItem Value="2">Petani/Nelayan</asp:ListItem>
                                    <asp:ListItem Value="3">Guru Swasta</asp:ListItem>
                                    <asp:ListItem Value="4">Pegawai Swasta Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="5">Karyawan/Wiraswasta/Pedagang</asp:ListItem>
                                    <asp:ListItem Value="6">Pensiunan Swasta</asp:ListItem>
                                    <asp:ListItem Value="7">Purnawirawan/Veteran</asp:ListItem>
                                    <asp:ListItem Value="8">Dosen Swasta</asp:ListItem>
                                    <asp:ListItem Value="9">Pensiunan PNS/ABRI</asp:ListItem>
                                    <asp:ListItem Value="10">PNS Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="11">Guru/Dosen PNS</asp:ListItem>
                                    <asp:ListItem Value="12">Pegawai BUMN/BUMD</asp:ListItem>
                                    <asp:ListItem Value="13">TNI/Polri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Jumlah Modal Usaha 
                        Ayah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLModalAyah" runat="server">
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Jumlah Laba 
                        Ayah</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLLabaAyah" runat="server">
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Nama Ibu/Wali</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:TextBox ID="TbIbu" runat="server"></asp:TextBox>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Satus Ibu/wali</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLStatausIbu" runat="server">
                                    <asp:ListItem>Hidup</asp:ListItem>
                                    <asp:ListItem>Meninggal</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Pendidikan Terakhir Ibu/wali</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLPendidikanIbu" runat="server">
                                    <asp:ListItem Value="1">SD</asp:ListItem>
                                    <asp:ListItem Value="2">SMP</asp:ListItem>
                                    <asp:ListItem Value="4">SMA</asp:ListItem>
                                    <asp:ListItem Value="6">Diploma</asp:ListItem>
                                    <asp:ListItem Value="8">Sarjana (S1)</asp:ListItem>
                                    <asp:ListItem Value="10">Magister (S2)</asp:ListItem>
                                    <asp:ListItem Value="12">Doktor (S3)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Data Pekerjaan Ibu</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLKerjaanIbu" runat="server">
                                    <asp:ListItem Value="0">Tidak Bekerja</asp:ListItem>
                                    <asp:ListItem Value="1">Buruh</asp:ListItem>
                                    <asp:ListItem Value="2">Petani/Nelayan</asp:ListItem>
                                    <asp:ListItem Value="3">Guru Swasta</asp:ListItem>
                                    <asp:ListItem Value="4">Pegawai Swasta Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="5">Karyawan/Wiraswasta/Pedagang</asp:ListItem>
                                    <asp:ListItem Value="6">Pensiunan Swasta</asp:ListItem>
                                    <asp:ListItem Value="7">Purnawirawan/Veteran</asp:ListItem>
                                    <asp:ListItem Value="8">Dosen Swasta</asp:ListItem>
                                    <asp:ListItem Value="9">Pensiunan PNS/ABRI</asp:ListItem>
                                    <asp:ListItem Value="10">PNS Bukan Guru/Dosen</asp:ListItem>
                                    <asp:ListItem Value="11">Guru/Dosen PNS</asp:ListItem>
                                    <asp:ListItem Value="12">Pegawai BUMN/BUMD</asp:ListItem>
                                    <asp:ListItem Value="13">TNI/Polri</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Jumlah Modal Usaha 
                        Ibu</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLModalIbu" runat="server">
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-3 col-xs-12 control-label">
                            Jumlah Laba 
                        Ibu</label>
                        <div class="col-md-6 col-xs-12">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="fa fa-unlock-alt"></span></span>
                                <asp:DropDownList ID="DLLabaIbu" runat="server">
                                    <asp:ListItem Value="0">Tidak Ada</asp:ListItem>
                                    <asp:ListItem Value="1"><= 5 Juta</asp:ListItem>
                                    <asp:ListItem Value="3">>5-10 Juta</asp:ListItem>
                                    <asp:ListItem Value="6">>10-50 Juta</asp:ListItem>
                                    <asp:ListItem Value="10">>50-100 Juta</asp:ListItem>
                                    <asp:ListItem Value="15">>100 Juta</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <span class="help-block">Password field sample</span>
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
                    <asp:Button ID="BtnSubmit" runat="server" class="btn btn-primary pull-right"
                        Text="Preview" onclick="BtnSubmit_Click" /> <span class="style4">PERIKSA 
                    KEMBALI ISIAN DATA SEBELUM DISIMPAN </span>
                </div>
            </div>
            </div>
        </div>
    </div> 
</div>
</asp:Content>
