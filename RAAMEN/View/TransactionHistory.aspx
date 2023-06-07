<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="RAAMEN.View.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction History</h1>
    <p>Click Select to see the Transaction Details</p>
    <asp:GridView ID="transactions" runat="server" AutoGenerateSelectButton="true"
        OnSelectedIndexChanging="transactions_SelectedIndexChanging"></asp:GridView>
</asp:Content>
