<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="NftEkle.aspx.cs" Inherits="H2oFinance.AdminPanel.NftEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ekleContainer">
        <div class="ekleTitle">
            <h2>NFT EKLE</h2>
        </div>
        <div class="ekleContent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                NFT Ekleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:TextBox CssClass="textbox" ID="tb_isim" runat="server" placeholder="NFT Adı Giriniz"></asp:TextBox>
            <asp:TextBox CssClass="textbox" ID="tb_fiyat" runat="server" placeholder="Fiyat Giriniz"></asp:TextBox>
            <label>Resim Ekle</label><br />
            <asp:FileUpload CssClass="resimEkle" ID="fu_resim" runat="server"></asp:FileUpload>
            <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click">EKLE</asp:LinkButton>
        </div>
    </div>
</asp:Content>
