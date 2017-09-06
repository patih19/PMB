<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.Master" AutoEventWireup="true" CodeBehind="upload_biodata.aspx.cs" Inherits="PinSemuntidar.user.WebForm10" %>
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
        <div class="row">
            <div class="col-md-12">
                <strong><span class="style3">Upload Biodata</span></strong><br />
                <br />
                <br />
                Scan dan upload biodata yang telah di download (setelah ditempel materai yang ditandatangani,pas foto
                ukuran 3X4 berwarna dan dicap jempol tangan kiri). <br />
                Kemudian pastikan hasil scan dalam bentuk image dengan format jpg/jpeg, lalu upload pada fasilitas di bawah ini <br /><br /> <br />
                <table class="table-condensed table-bordered" align="center">
                    <tr>
                        <td>
                            Ukuran maximal file biodata scan : 300 Kb
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUploadFoto" runat="server" Height="20px" Width="221px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BtnUpload" runat="server" Text="Upload" />
                            &nbsp;<asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    </table>
                <br />
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
        </div>
    </div>
</asp:Content>

