<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="HowToSsrsRdlcReport.Rdls.Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <asp:Button ID="btnMainReport" runat="server" Text="&lt;- MainReport" Width="233px" OnClick="btnMainReport_Click" />
        <br />
        <br />
    <br />
        <rsweb:reportviewer runat="server" ID="rv" Height="100%" Width="100%" OnDrillthrough="rv_Drillthrough"></rsweb:reportviewer>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
