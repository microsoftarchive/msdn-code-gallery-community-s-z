<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReportFromStream.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Loading a Report from a Stream</h1>
        <p>You can create reports dynamically and load it into the ReportViewer control for processing. This enables you to 
           generate dynamic reports using XML. This sample demonstrates how to load a local report using a stream. The report
           contains a subreport and uses a data source, both of which are loaded into the ReportViewer control at run time.</p>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="600px">
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
