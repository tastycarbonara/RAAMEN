<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="RAAMEN.View.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Ramen</h1>
    <asp:GridView ID="order" runat="server" AutoGenerateSelectButton="true" 
        OnSelectedIndexChanging="order_SelectedIndexChanging"></asp:GridView><br />

    <h1>Your Cart</h1>
    <asp:GridView ID="cart" runat="server"></asp:GridView><br />
    <asp:Button ID="clear" runat="server" Text="Clear Cart" OnClick="clear_Click" /><br />
    <asp:Button ID="buy" runat="server" Text="Buy Cart" OnClick="buy_Click"/>

</asp:Content>
