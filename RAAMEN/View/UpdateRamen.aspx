<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateRamen.aspx.cs" Inherits="RAAMEN.View.UpdateRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="name" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="meat" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="broth" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="price" runat="server" Text="Label"></asp:Label><br />

    <h2>Update Ramen</h2>

    <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="name_inp" runat="server"></asp:TextBox><br />

    <asp:Label ID="Label2" runat="server" Text="Meat ID"></asp:Label>
    <asp:DropDownList ID="meat_inp" runat="server">
        <asp:ListItem Value="1">Chicken</asp:ListItem>  
        <asp:ListItem Value="2">Beef</asp:ListItem> 
        <asp:ListItem Value="3">Pork</asp:ListItem> 
    </asp:DropDownList><br />

    <asp:Label ID="Label3" runat="server" Text="Broth"></asp:Label>
    <asp:TextBox ID="broth_inp" runat="server"></asp:TextBox><br />

    <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="price_inp" runat="server"></asp:TextBox><br />

    <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click"/><br />
    <asp:Button ID="back" runat="server" Text="Back to Manage Ramen" OnClick="back_Click"/>
</asp:Content>
