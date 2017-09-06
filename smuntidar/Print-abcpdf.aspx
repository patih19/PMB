<%@ Page Title="" Language="C#" MasterPageFile="~/Daftar.Master" AutoEventWireup="true" CodeBehind="Print-abcpdf.aspx.cs" Inherits="smuntidar.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type = "text/javascript">
    function SetTarget() {
        document.forms[0].target = "_blank";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- <input id="Button1" type="button" value="button" onclick = "SetTarget();" /><br />
    <asp:Button ID="Button2" runat="server" Text="Button" 
        OnClientClick="SetTarget();" onclick="Button2_Click" />  -->
        <asp:Button ID="Button1" runat="server" Text="Button" 
        onclick="Button2_Click" />
    &nbsp;<asp:Button ID="Button3" runat="server" OnClientClick="aspnetForm.target ='_blank';" onclick="Button3_Click" 
        Text="Button" />
&nbsp;
</asp:Content>