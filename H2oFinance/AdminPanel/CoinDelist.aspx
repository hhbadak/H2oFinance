<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="CoinDelist.aspx.cs" Inherits="H2oFinance.AdminPanel.CoinDelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h6 class="talepBaslik">Delist Edilecek Coini Seçiniz</h6>
    <asp:ListView ID="lv_coin" runat="server" OnItemCommand="lv_coin_ItemCommand">
        <LayoutTemplate>
            <table class="talepTable" border="1" cellspacing="0">
                <tr>
                    <td>Coin No</td>
                    <td>Coin Adı</td>
                    <td>Kısaltma</td>
                    <td>Fiyat</td>
                    <td></td>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("ID") %></td>
                <td><%#Eval("Isim") %></td>
                <td><%#Eval("CoinNick") %></td>
                <td><%#Eval("Fiyat") %></td>
                <td>
                    <asp:LinkButton CssClass="btn_sil" ID="lb_sil" runat="server" CommandArgument='<%#Eval("ID") %>' CommandName="sil">DELİST</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
