<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="BakiyeOnay.aspx.cs" Inherits="H2oFinance.AdminPanel.BakiyeOnay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="talepBaslik">TALEPLER</h2>
    <div class="butonlar">
        <asp:LinkButton ID="lbtn_onayBekleyen" runat="server" OnClick="lbtn_onayBekleyen_Click" CssClass="btn btn_bekleyen">ONAY BEKLEYENLER</asp:LinkButton>
        <asp:LinkButton ID="lbtn_onaylanan" runat="server" OnClick="lbtn_onaylanan_Click" CssClass="btn btn_onaylanan">ONAYLANANLAR</asp:LinkButton>
        <asp:LinkButton ID="lbtn_reddedilen" runat="server" OnClick="lbtn_reddedilen_Click" CssClass="btn btn_reddedilen">REDDEDİLENLER</asp:LinkButton>
    </div>
    <div class="liste">
        <asp:ListView ID="lv_talep" runat="server" OnItemCommand="lv_talep_ItemCommand" Visible="false">
            <LayoutTemplate>
                <table class="talepTable" border="1" cellspacing="0">
                    <tr>
                        <th>Talep No</th>
                        <th>Üye Adı</th>
                        <th>Talep Edilen Miktar</th>
                        <th>Talep Tarihi</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Uye_Adi")%></td>
                    <td><%#Eval("Miktar") %></td>
                    <td><%#Eval("Talep_Tarihi")%></td>
                    <td>
                        <asp:LinkButton CssClass="btn_onayla" ID="lbtn_onay" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="onayla">ONAYLA</asp:LinkButton>
                        <asp:LinkButton CssClass="btn_reddet" ID="lbtn_reddet" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="reddet">REDDET</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="lv_onaylanmis" runat="server" Visible="false">
            <LayoutTemplate>
                <table class="talepTable" border="1" cellspacing="0">
                    <tr>
                        <th>Talep No</th>
                        <th>Üye Adı</th>
                        <th>Talep Edilen Miktar</th>
                        <th>Talep Tarihi</th>
                        <th>Onay Tarihi</th>
                        <th>Onaylayan Yönetici</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Uye_Adi") %></td>
                    <td><%#Eval("Miktar") %></td>
                    <td><%#Eval("Talep_Tarihi") %></td>
                    <td><%#Eval("Onay_Tarihi") %></td>
                    <td><%#Eval("Yonetici_Adi") %></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="lv_reddedilmis" runat="server">
            <LayoutTemplate>
                <table class="talepTable" border="1" cellspacing="0">
                    <tr>
                        <th>Talep No</th>
                        <th>Üye Adı</th>
                        <th>Talep Edilen Miktar</th>
                        <th>Talep Tarihi</th>
                        <th>Red Tarihi</th>
                        <th>Reddeden Yönetici</th>
                    </tr>
                    <placeholder id="itemPlaceHolder" runat="server"></placeholder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Uye_Adi") %></td>
                    <td><%#Eval("Miktar") %></td>
                    <td><%#Eval("Talep_Tarihi") %></td>
                    <td><%#Eval("Onay_Tarihi") %></td>
                    <td><%#Eval("Yonetici_Adi") %></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
