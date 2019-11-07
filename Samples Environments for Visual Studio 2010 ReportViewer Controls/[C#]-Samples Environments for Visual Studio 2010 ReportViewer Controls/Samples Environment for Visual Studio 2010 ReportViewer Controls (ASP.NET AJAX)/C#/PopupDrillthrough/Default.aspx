<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PopupDrillthrough.Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Displaying Drillthrough Reports in an AJAX Popup</h1>
        <p>This sample demonstrates how to redirect a drillthrough report to an AJAX popup. It uses the ModalPopupExtender control
           in the AJAX Toolkit.</p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- ReportViewer1 serves as the main viewer -->
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Width="800px" Height="600px">
        </rsweb:ReportViewer>
        <!-- Add a hidden button to attach a ModalPopupExtender to. We won't use this button since we will show and hide the 
             modal popup programmatically. -->
        <asp:Button ID="ButtonHidden" runat="server" style="display:none" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender_Drillthrough" runat="server" 
            TargetControlID="ButtonHidden" PopupControlID="PanelPopup" 
            OkControlID="ButtonClose" Drag="True" DropShadow="True">
        </cc1:ModalPopupExtender>
        <!-- PanelPopup is used to display drillthrough reports. -->
        <asp:Panel ID="PanelPopup" runat="server" style="background-color:#fff;border:3px solid #496077;text-align:center">
            <rsweb:ReportViewer ID="ReportViewerDrillthrough" runat="server" ProcessingMode="Remote">
            </rsweb:ReportViewer>
            <asp:Button ID="ButtonClose" runat="server" Text="Close" />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
