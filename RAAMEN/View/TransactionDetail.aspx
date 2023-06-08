<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="RAAMEN.View.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Detail</h1>
    <asp:Label ID="orderid" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="ramenid" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="customerid" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="ramenname" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="ramenmeat" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="ramenbroth" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="quantity" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="username" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="totalprice" runat="server" Text=""></asp:Label><br />
</asp:Content>
