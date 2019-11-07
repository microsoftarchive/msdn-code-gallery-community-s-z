<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ResizingViewer.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Recalculate Viewer Layout According to Its Container</h1>
        <p>When placing the Visual Studio 2010 ReportViewer control in a container, such as an HTML table element, client-side changes in the 
           container may cause layout issues in the client-side ReportViewer control. In such cases, use the recalculateLayout client-side 
           method to adjust the layout of the client-side control. This sample uses a table as a container for the ReportViewer control. Click 
           the <b>Randomize Table Size</b> button to see how it affects the ReportViewer control. You may observe the following:</p>
        <ul>
            <li>The viewer displays correctly</li>
            <li>The viewer takes up too much room, causing the table to be bigger than the 
                specified dimensions</li>
            <li>The viewer overflows the table</li>
            <li>The viewer toolbar contains gaps</li>
        </ul>
        <p>
            Click the <strong>Recalculate Now!</strong> button to recalculate the viewer 
            layout.</p>
        <!-- Add a reference to ResizingViewer.js in ScriptManager. -->
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Path="ResizingViewer.js" />
            </Scripts>
        </asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Randomize Table Size" OnClientClick="resizeTable(); return false;" />
        <asp:RadioButton ID="RadioRecalculate" runat="server" GroupName="Recalc" Text="Auto-recalculate" />
        <asp:RadioButton ID="RadioNoRecalculate" runat="server" Checked="True" GroupName="Recalc" Text="No Auto-recalulate" />
        <asp:Button ID="Button2" runat="server" Text="Recalculate Now!" OnClientClick="$find('ReportViewer1').recalculateLayout(); return false;" />
        <br/>
        <asp:Label ID="Label1" runat="server" Text="Table Width:" Font-Bold="True"></asp:Label>
        <asp:Label ID="Width" runat="server" Text="Auto" Width="40px"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Table Height:" Font-Bold="True"></asp:Label>
        <asp:Label ID="Height" runat="server" Text="Auto"></asp:Label>
        <!-- Put the ReportViewer control within a simple table. The table size is changed by clicking the Change Table Size button. -->
        <table id="ViewerTable" style="border-style: ridge; border-color: #CC9900;">
            <tr>
                <td>
                    <!-- Set the Height and Width properties to 100% so the ReportViewer control always fills its container. -->
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Height="100%" Width="100%">
                    </rsweb:ReportViewer>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
