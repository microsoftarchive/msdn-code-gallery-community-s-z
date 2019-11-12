<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapAndPrompt.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Controlling the Document Map and Prompt Areas without Postbacks</h1>
        <p>In the Visual Studio 2010 ReportViewer control, you can use the documentMapCollapsed and promptAreaCollapsed client-side 
           properties to change the collapsed state of the document map and prompt areas without causing postbacks. To see the prompt
           area being toggled, specify the name of a report that contains parameter prompts, such as <b>Employee Sales Summary 2008</b>,
           in the Default.aspx.cs file.</p>
        <!-- Add a reference to MapAndPrompt.js in ScriptManager. -->
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Path="MapAndPrompt.js" />
            </Scripts>
        </asp:ScriptManager>
        <asp:Button ID="ToggleDocMap" runat="server" Text="Toggle the Document Map" OnClientClick="toggleDocMap(); return false;" />
        <asp:Button ID="TogglePromptArea" runat="server" Text="Toggle the Prompt Area" OnClientClick="togglePrompt(); return false;" />
        <!-- Disable the splitter buttons for the document map and the prompt area in the ReportViewer control. You can also enable them 
             to see their similar behaviors with the custom buttons. -->
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" 
            ShowPromptAreaButton="False" ShowDocumentMapButton="False" Height="600px" 
            Width="600px">
        </rsweb:ReportViewer>
    
    </div>
    </form>
</body>
</html>
