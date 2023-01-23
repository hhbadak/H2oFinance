<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="H2oFinance.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Giriş</title>
    <link href="https://fonts.googleapis.com/css2?family=Unbounded&display=swap" rel="stylesheet" />
    <link href="Style/AdminGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height: 100%">
        <div class="giris">
            <div class="Container silver">
                <div class="content">
                    <img src="Images/H2oDamlaLogo.png" />
                    <asp:TextBox ID="tb_mail" runat="server" placeholder="Mail Adresi Giriniz">
                    </asp:TextBox>
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" placeholder="Şifre Giriniz"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_giris" Text="GİRİŞ" runat="server" OnClick="lbtn_giris_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
