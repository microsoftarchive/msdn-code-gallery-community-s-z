<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE HTML>
<html>
<head>
    <title>LDAP Sample Test</title>
</head>
<body>
    <form runat="server">
    <table>
        <tr>
            <td>
                <label>
                    Username</label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    Password</label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnValidate" runat="server" Text="Validate" OnClick="btnValidate_OnClick" />
                <asp:Button ID="btnUsers" runat="server" Text="Get All Users" OnClick="btnUsers_OnClick" />
            </td>
            <td>
                <asp:Label ID="lblValidity" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td colspan="2">
                 <asp:ListBox ID="lbUsers" runat="server" Width="200px" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
