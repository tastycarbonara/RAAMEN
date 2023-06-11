<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master Site/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="RAAMEN.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="showUsername" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="showEmail" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="showGender" runat="server" Text="Label"></asp:Label><br />

    <h3>Update Profile</h3>
    
            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernm" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label4" runat="server" Text="Gender: "></asp:Label>
            <asp:DropDownList ID="gender" runat="server">
                <asp:ListItem Value="Male">Male </asp:ListItem>  
                <asp:ListItem Value="Female">Female</asp:ListItem> 
            </asp:DropDownList> <br />

            <asp:Label ID="Label3" runat="server" Text="Current Password: "></asp:Label>
            <asp:TextBox ID="pass" runat="server"></asp:TextBox><br />

            <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click"/><br />
            <asp:Label ID="status" runat="server" Text=""></asp:Label><br />
</asp:Content>
