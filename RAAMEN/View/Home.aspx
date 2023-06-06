<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAAMEN.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="welcome" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="role" runat="server" Text=""></asp:Label><br />

    <h2>User list:</h2>
    <asp:GridView ID="gv" runat="server"></asp:GridView>
</asp:Content>
