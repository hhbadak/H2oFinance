<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="KriptoListele.aspx.cs" Inherits="H2oFinance.AdminPanel.KriptoListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ListView ID="lv_coinList" runat="server" OnItemCommand="lv_coinList_ItemCommand">
            <LayoutTemplate>
                <table class="coinList" border="1" cellspacing="0">
                    <thead>
                        <td>Coin No</td>
                        <td>Coin Adı</td>
                        <td>Coin Kısaltma Adı</td>
                        <td>Max Arz</td>
                        <td style="font-size: 10pt;">Kripto Simgesi</td>
                        <td>Fiyat</td>
                        <td>Seçenek</td>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Isim") %></td>
                    <td><%#Eval("CoinNick") %></td>
                    <td><%#Eval("Max_Arz") %></td>
                    <td>
                        <img style="text-align: center;" src="../AdminPanel/Images/NftCoinImage/<%# Eval("Resim") %>" width="50" /></td>
                    <td><%#Eval("Fiyat") %></td>
                    <td class="btn_duzenle">
                        <a href='KriptoDuzenle.aspx?mid=<%# Eval("ID") %>' class="duzenle">Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
