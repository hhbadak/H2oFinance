<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="KriptoEkle.aspx.cs" Inherits="H2oFinance.AdminPanel.KriptoEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ekleContainer">
        <div class="ekleTitle">
            <h2>KRİPTO EKLE</h2>
        </div>
        <div class="ekleContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kripto Ekleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:TextBox CssClass="textbox" ID="tb_isim" runat="server" placeholder="İsim Giriniz"></asp:TextBox>
            <asp:TextBox CssClass="textbox" ID="tb_nick" runat="server" placeholder="Kısaltmasını Giriniz"></asp:TextBox>
            <asp:TextBox CssClass="textbox" ID="tb_arz" runat="server" placeholder="Max Arz Değerini Giriniz"></asp:TextBox>
            <label>Resim Ekle</label><br />
            <asp:FileUpload CssClass="resimEkle" ID="fu_resim" runat="server"></asp:FileUpload>
            <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click">EKLE</asp:LinkButton>
        </div>
    </div>
</asp:Content>
