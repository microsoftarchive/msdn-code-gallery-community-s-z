<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SamlIdPInitiated.ServiceProvider.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IdPInitiated:Service Provider - UltimateSaml for SAML v2.0 Web Demonstration</title>
    <link rel="Stylesheet" href="Css/Styles.css" />
</head>
<body>
    <form id="myform" runat="server">
        <div class="templatecontent">
            <div class="header">
                <a href="http://www.componentpro.com">
                    <img src="Css/Logo.gif" /></a>
            </div>
            <h4>
                <b>IdpInitiated - ServiceProvider</b></h4>
            <br />
            <br />
            This web application will illustrate how to use UltimateSaml for SAML 2.0 in a Web
            Application.<br />
            <br />
            <div class="content">
                <table border="0" cellspacing="0" cellpadding="3">
                    <tr>
                        <td style="white-space: nowrap">
                            <b>Logged in as:</b></td>
                        <td width="100%">
                            <%=Context.User.Identity.Name%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button runat="server" CssClass="button" ID="btnLogout" Text="Logout" OnClick="btnLogout_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
