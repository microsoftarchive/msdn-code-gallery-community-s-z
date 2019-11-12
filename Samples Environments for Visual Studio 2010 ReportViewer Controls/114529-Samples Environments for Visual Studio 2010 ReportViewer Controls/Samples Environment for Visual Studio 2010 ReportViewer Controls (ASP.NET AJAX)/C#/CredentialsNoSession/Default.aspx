<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CredentialsNoSession.Default" EnableSessionState="False" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Report Server Credentials without ASP.NET Sessions</h1>
        <p>This sample demonstrates how to supply credentials to the report server without keeping the credentials in the ASP.NET session.
           The Web application has the following settings:
           </p>
        <ul>
            <li>Session state is disabled in the ASPX page (EnableSessionState=&quot;False&quot;).</li>
            <li>The <strong>ReportServerConnection2</strong> interface is implemented in the 
                code-behind file, and the class is registered in the <strong>&lt;appSettings&gt;</strong> element in the 
                Web.config file. This is necessary when session state is disabled, but you can 
                also do likewise when session state is enabled in order to keep credentials from 
                being stored in the session.</li>
            <li>Server and credential information is kept in the Web.config file and retrieved 
                by the <strong>ReportServerConnection2</strong> implementation at run time. This 
                is not a required step, but limiting sensitive information to the Web.config 
                file does reduce the attack surface of your application to the Web.config file.</li>
        </ul>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Height="600px" Width="600px">
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
