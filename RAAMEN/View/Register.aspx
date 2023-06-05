<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RAAMEN.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: Bahnschrift;">
    <form id="form1" runat="server">
        <div>
            <h1>Register</h1>

            <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="usernm" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label4" runat="server" Text="Gender: "></asp:Label>
            <asp:DropDownList ID="gender" runat="server">
                <asp:ListItem Value="Male">Male </asp:ListItem>  
                <asp:ListItem Value="Female">Female</asp:ListItem> 
            </asp:DropDownList> <br />

            <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="pass" runat="server"></asp:TextBox><br />

            <asp:Label ID="Label5" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="confpass" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="regis" runat="server" Text="Register" OnClick="regis_Click"/><br />
            <asp:Label ID="status" runat="server" Text=""></asp:Label><br />

            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Login.aspx">Already have an account? Login here!</asp:HyperLink>
        </div>
    </form>
</body>
</html>
