﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="RAAMEN.View.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Ramen</h1>
    <asp:GridView ID="gridramen" runat="server" OnRowDeleting="gridramen_RowDeleting"
        OnRowEditing="gridramen_RowEditing" AutoGenerateEditButton="true" 
        AutoGenerateDeleteButton="true"></asp:GridView><br />
    <asp:Button ID="newramen" runat="server" Text="Insert New Ramen" Onclick="newramen_Click"/><br />
    
</asp:Content>
