<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RenderingAndPostBack.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Asynchronous Report Rendering and Postback</h1>
        <p>The Visual Studio 2010 ReportViewer control is an ASP.NET AJAX control that uses UpdatePanels to update the report area.
           Use the <strong>AsyncRendering</strong> property to specify whether the report should render asynchronously from page load; and use the 
            <strong>InteractivityPostBackMode</strong> property to specify the postback behavior. 
            When trying out different postback behaviors, perform a report action, such as a 
            refresh or drillthrough, and observe whether the timestamp changes. The 
            timestamp changes whenever a synchronous postback occurs, and remains unchanged 
            when an asynchronous postback occurs.</p>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="AsyncRendering"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListAsyncRendering" runat="server" 
                AutoPostBack="True" 
                onselectedindexchanged="RadioButtonListAsyncRendering_SelectedIndexChanged" 
                RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>True</asp:ListItem>
                <asp:ListItem>False</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                Text="InteractivityPostBackMode"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonListInteractivityPostBackMode" 
                runat="server" AutoPostBack="True" 
                onselectedindexchanged="RadioButtonListInteractivityPostBackMode_SelectedIndexChanged" 
                RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem>AlwaysAsynchronous</asp:ListItem>
                <asp:ListItem>AlwaysSynchronous</asp:ListItem>
                <asp:ListItem>SynchronousOnDrillthrough</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Full Page Load:"></asp:Label>
            <asp:Label ID="LabelTime" runat="server"></asp:Label>
        </p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" 
            Height="600px" Width="600px">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
