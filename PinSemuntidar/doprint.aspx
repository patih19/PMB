<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doprint.aspx.cs" Inherits="PinSemuntidar.doprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        window.print();
    </script>
    <style>
        table, th, td
        {
            border: 1px solid black;
            border-collapse : collapse;
            
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table align="center">
            <tr>
                <td colspan="2">
                    NO TAGIHAN & BIAYA
                    <br />
                    SELEKSI MASUK UNIVERSITAS TIDAR
                </td>
            </tr>
            <tr>
                <td>
                    No. Jurnal / No. Tagihan
                </td>
                <td>
                    <asp:Label ID="LbBill" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Jalur
                </td>
                <td>
                    SMUNTIDAR</td>
            </tr>
            <tr>
                <td>
                    Biaya Seleksi
                </td>
                <td>
                    Rp. 200.000
                </td>
            </tr>
            </table>
        <br />
        Silakan Bayar No. Tagihan di atas dengan memilih salah satu cara di bawah ini :<br />
        <ol>
            <li>TELLER, tunjukkan kertas ini ke Bank BNI, untuk kemudian dibayar secara cash atau
                transfer. Teller bank, akan menukarnya dengan No. Jurnal / No. Tagihan dan PIN
            </li>
            <li>ATM, masukkan No Tagihan di atas melalui ATM Bank </li>
            <li>INTERNET BANKING / IB, masukkan No tagihan di atas melalui <em>https://ibank.bni.co.id
            </em></li>
        </ol>
        Silakan pergunakan No Jurnal/Bill Reff dan PIN untuk melakukan 
        pendaftaran online SMUNTIDAR 2015</div>
    <p>
        <asp:Button ID="BtnMakasih" runat="server" onclick="BtnMakasih_Click" 
            Text="terima kasih" />
    </p>
    </form>
</body>
</html>
