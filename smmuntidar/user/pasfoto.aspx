<%@ Page Title="" Language="C#" MasterPageFile="~/user/SMM.Master" AutoEventWireup="true" CodeBehind="pasfoto.aspx.cs" Inherits="smmuntidar.user.WebForm18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: medium;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container top-buffer" style="background-color: #F2F2FF;">
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
            <div class="col-md-9">
                <strong><span class="style3">Tahap Ke-8: UPLOAD FOTO</span></strong><br />
                <br />
                Ketentuan upload foto :
                <ol>
                
                <li>File yang diupload dalam format png, jpg atau jpeg</li>
                    <li>Ukuran file sebesar 50-150 Kb.</li>
                </ol>
                <hr />
                <asp:FileUpload ID="FileUploadFoto" runat="server" Height="20px" Width="221px" />
                <asp:Panel ID="PanelUpload" runat="server">
                <p></p>
                    <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" 
                        Text="Upload" />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </asp:Panel>                
                <br />
                <asp:Image ID="ImageFoto" runat="server" Height="150px" />
                <br />
                <asp:Panel runat="server" ID="PanelSelesai">
                <hr />
                    <asp:Button ID="Button1" runat="server" Text="Selesai" CssClass=" btn btn-danger"
                        OnClick="Button1_Click" />
                    <p></p>
                    <p style="background-color: #FFFF99;">
                        Setelah upload foto, klik &quot;<strong>Selesai</strong>&quot; kemudian download
                        &quot;<strong>Kartu Ujian</strong>&quot;.</p>
                </asp:Panel>


                <br />
                
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                &nbsp;<br />
            </div>
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        SM-UNTIDAR
                    </div>
                    <div class="panel-body">
                        No. Pendaftaran :
                        <asp:Label ID="LbTrans" runat="server"></asp:Label>
                        <hr />
                        <span class="style3">
                            <a href='#' id='keluar' runat='server'>Logout </a>
                        </span>
                    </div>
                </div>              
            </div>
        </div>
    </div>
</asp:Content>
