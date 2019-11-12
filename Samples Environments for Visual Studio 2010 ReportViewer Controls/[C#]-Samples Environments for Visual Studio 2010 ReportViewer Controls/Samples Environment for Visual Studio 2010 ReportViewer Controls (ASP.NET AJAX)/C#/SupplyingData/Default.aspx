<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SupplyingData.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Supplying Data for Local Reports, Subreports, and Drillthrough Reports</h1>
        <p>This sample demonstrates how to add report data to your ReportViewer control. You 
            can select to view two different reports, one of which contains a subreport and 
            the other contains a link to a drillthrough report. Both reports and the 
            corresponding subreport and drillthrough report use data that the ReportViewer 
            control needs at run time.</p>
        <p>After you create an RDLC report using a named dataset that from an XSD schema, 
            the ReportViewer control searches in the <strong>
            ReportViewer.LocalReport.DataSources</strong> collection for for the dataset 
            whose name is specified in the RDLC report. Your application must retrieve the 
            data and add them to this collection at run time. If the report is a subreport, 
            you must add the report data in the <strong>LocalReport.SubreportProcessing</strong> 
            event using the <strong>e.DataSources</strong> argument property. Similarly, if 
            the report is a drillthrough report, you must add the report data in the <strong>
            ReportViewer.Drillthrough</strong> event using the <strong>
            ((LocalReport)e.Report).DataSources</strong> argument property.</p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label1" runat="server" Font-Bold="True">Select Report </asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True" Value="OrdersWithSubreport">Report With Subreport</asp:ListItem>
            <asp:ListItem Value="OrdersWithDrillthrough">Report With Drillthrough</asp:ListItem>
        </asp:DropDownList>    
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="600px" Width="600px">
        </rsweb:ReportViewer>    
    </div>
    </form>
</body>
</html>
