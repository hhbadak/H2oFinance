<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="KriptoDuzenle.aspx.cs" Inherits="H2oFinance.AdminPanel.KriptoDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ekleTitle">
        <h2>KRİPTO DÜZENLE</h2>
    </div>
    <div class="ekleContent">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
            Kripto Düzenleme Başarılı
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div style="float: left; width: 50%">
            <div class="row">
                <label>Coin Adı</label><br />
                <asp:TextBox ID="tb_coinAdi" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <div>
                <div class="row">
                    <label>Coin Kısaltma Adı</label><br />
                    <asp:TextBox ID="tb_coinKisaltma" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Maksimum Arz</label><br />
                    <asp:TextBox ID="tb_mArz" runat="server" CssClass="inputBox"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Image ID="img_resim" runat="server" Width="100" />
                    <br />
                    <label>Coin Resim</label><br />
                    <asp:FileUpload ID="fu_resim" runat="server"></asp:FileUpload>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_duzenle" runat="server" Text="Kripto Düzenle" CssClass="formbutton" OnClick="lbtn_duzenle_Click"></asp:LinkButton>
                </div>
            </div>
            <div style="clear: both"></div>


        </div>
    </div>
    </div>
</asp:Content>
