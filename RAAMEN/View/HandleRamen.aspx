<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="HandleRamen.aspx.cs" Inherits="RAAMEN.View.HandleRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Queue</h1>
    <p>Press Select to Handle the order</p>
    <asp:GridView ID="orders" runat="server" AutoGenerateSelectButton="true" 
        OnSelectedIndexChanging="orders_SelectedIndexChanging"></asp:GridView>
</asp:Content>
