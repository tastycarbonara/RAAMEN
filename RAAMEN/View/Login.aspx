<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAAMEN.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>

            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernm" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="passw" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click"/><br />

            <asp:Label ID="status" runat="server" Text=""></asp:Label><br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Register.aspx">Don't have an account? Register Here!</asp:HyperLink>
        </div>
    </form>
</body>
</html>
