<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomToolBar.Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Define a set of CSS classes for convenience. For each image button, we can just change between ToolBarImageVisible and ToolBarImageHidden to toggle the visibility. -->
    <style type="text/css">
        .ToolBarImageVisible
        {
            width:16px;
            height:16px;
            display:inline;
            vertical-align: middle;
        }
        .ToolBarImageHidden
        {
            width:16px;
            height:16px;
            display:none;
            vertical-align: middle;
        }
        .ToolBarText
        {
            font-size:small; 
            height:16px; 
            vertical-align:middle;
        }
        .ToolBarList
        {
            vertical-align:middle;
        }
        .ToolBarLink
        {
            border-style:none;
            font-size:small; 
            color:blue;
            vertical-align:middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Custom Toolbar Using JavaScript APIs</h1>
        <p>In Visual Studio 2010, the ASP.NET ReportViewer control has added both server-side and client-side APIs that enable you to create custom toolbars.</p>

        <!-- Add a reference to CustomToolBar.js in ScriptManager. ScriptManager ensures that the referenced scripts are run after the Microsoft AJAX Library is 
             already loaded. -->
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Path="CustomToolBar.js" />
            </Scripts>
        </asp:ScriptManager>

        <!-- Use an UpdatePanel to contain the custom toolbar items. While the page only contains the custom toolbar and the ReportViewer control, a trigger 
             is defined here so that in case there are other UpdatePanel controls, the custom toolbar is only updated by changes in the ReportViewer control. 
             Also, both the enabled and disabled buttons are defined. At run time the client-side code will toggle the visibility of the buttons accordingly.
             NOTE: If there are other controls on your page that cause changes in the ReportViewer on asynchronous postbacks, you should add them here as 
             triggers, or call UpdatePanel.Update() in the code behind to force the toolbar to be updated. -->
        <asp:UpdatePanel ID="ToolBarPanel" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ReportViewer1" />
            </Triggers>
            <ContentTemplate>
        <!-- This hidden field is used to pass a JSON object to the client-side for updating the toolbar state. -->
        <asp:HiddenField 
            id="ToolBarSerializedState" 
            runat="server" />

                <asp:ImageButton 
                    ID="ButtonFirstPage" 
                    runat="server" 
                    onclick="ButtonFirstPage_Click" 
                    CssClass="ToolBarImageHidden" 
                    ImageUrl="~/Icons/FirstPage.gif" />
                <asp:ImageButton 
                    ID="ButtonFirstPageDisabled" 
                    runat="server" 
                    Enabled="False" 
                    CssClass="ToolBarImageVisible"
                    ImageUrl="~/Icons/FirstPageDisabled.gif" />
                <asp:ImageButton 
                    ID="ButtonPreviousPage" 
                    runat="server" 
                    onclick="ButtonPreviousPage_Click" 
                    CssClass="ToolBarImageHidden"
                    ImageUrl="~/Icons/PrevPage.gif" />
                <asp:ImageButton 
                    ID="ButtonPreviousPageDisabled" 
                    runat="server" 
                    Enabled="False" 
                    CssClass="ToolBarImageVisible"
                    ImageUrl="~/Icons/PrevPageDisabled.gif" />
                <asp:TextBox 
                    ID="TextBoxPageNumber" 
                    runat="server"
                    OnTextChanged="TextBoxPageNumber_TextChanged"
                    Text="" 
                    Enabled="False"
                    CssClass="ToolBarText"
                    Columns="5" />
                <asp:Label 
                    ID="LabelTotalPages" 
                    runat="server" 
                    CssClass="ToolBarText"
                    Text="of 0" 
                    Width="40px" />
                <asp:ImageButton 
                    ID="ButtonNextPage" 
                    runat="server" 
                    onclick="ButtonNextPage_Click" 
                    CssClass="ToolBarImageHidden"
                    ImageUrl="~/Icons/NextPage.gif" />
                <asp:ImageButton 
                    ID="ButtonNextPageDisabled" 
                    runat="server" 
                    Enabled="False"
                    CssClass="ToolBarImageVisible"
                    ImageUrl="~/Icons/NextPageDisabled.gif" />
                <asp:ImageButton 
                    ID="ButtonLastPage" 
                    runat="server" 
                    onclick="ButtonLastPage_Click" 
                    CssClass="ToolBarImageHidden"
                    ImageUrl="~/Icons/LastPage.gif" />
                <asp:ImageButton 
                    ID="ButtonLastPageDisabled" 
                    runat="server" 
                    Enabled="False" 
                    CssClass="ToolBarImageVisible"
                    ImageUrl="~/Icons/LastPageDisabled.gif" />
                &nbsp;&nbsp;
                <asp:ImageButton ID="ButtonBackToParent" 
                    runat="server" 
                    onclick="ButtonBackToParent_Click" 
                    CssClass="ToolBarImageHidden" 
                    ImageUrl="~/Icons/BackEnabled.gif" />
                <asp:ImageButton ID="ButtonBackToParentDisabled" 
                    runat="server" 
                    Enabled="False" 
                    CssClass="ToolBarImageVisible"
                    ImageUrl="~/Icons/BackDisabled.gif" />
                <asp:DropDownList 
                    ID="DropDownListZoom" 
                    runat="server" 
                    CausesValidation="True" 
                    EnableViewState="True" 
                    Enabled="False"
                    CssClass="ToolBarList" >
                    <asp:ListItem Value="PageWidth">Page Width</asp:ListItem>
                    <asp:ListItem Value="FullPage">Full Page</asp:ListItem>
                    <asp:ListItem Value="500">500%</asp:ListItem>
                    <asp:ListItem Value="200">200%</asp:ListItem>
                    <asp:ListItem Value="150">150%</asp:ListItem>
                    <asp:ListItem Selected="True" Value="100">100%</asp:ListItem>
                    <asp:ListItem Value="75">75%</asp:ListItem>
                    <asp:ListItem Value="50">50%</asp:ListItem>
                    <asp:ListItem Value="25">25%</asp:ListItem>
                    <asp:ListItem Value="10">10%</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox 
                    ID="TextBoxFindString" 
                    runat="server" 
                    Enabled="False"
                    CssClass="ToolBarText"
                    Columns="10" />
                <asp:Button 
                    ID="ButtonFind" 
                    runat="server" 
                    Text="Find" 
                    Enabled="False" 
                    CssClass="ToolBarLink" />
                <asp:Literal 
                    ID="LiteralBar" 
                    runat="server" 
                    Text="|" />
                <asp:Button 
                    ID="ButtonNext" 
                    runat="server" 
                    Text="Next" 
                    Enabled="False" 
                    CssClass="ToolBarLink" />
                <asp:DropDownList 
                    ID="DropDownListExport" 
                    runat="server" 
                    Enabled="False"
                    CssClass="ToolBarList" />
                <asp:ImageButton 
                    ID="ButtonRefresh" 
                    runat="server" 
                    CssClass="ToolBarImageHidden" 
                    ImageUrl="~/Icons/Refresh.gif" />
                <asp:ImageButton 
                    ID="ButtonRefreshDisabled" 
                    runat="server" 
                    Enabled="False" 
                    CssClass="ToolBarImageVisible"
                    ImageUrl="~/Icons/RefreshDisabled.gif" />
                <asp:ImageButton 
                    ID="ButtonPrint" 
                    runat="server" 
                    CssClass="ToolBarImageHidden"
                    ImageUrl="~/Icons/Print.gif" />
                <asp:ImageButton 
                    ID="ButtonPrintDisabled" 
                    runat="server" 
                    Enabled="False" 
                    CssClass="ToolBarImageVisible" 
                    ImageUrl="~/Icons/PrintDisabled.gif" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Hide the default toolbar in the ReportViewer control. -->
        <rsweb:reportviewer 
            ID="ReportViewer1" 
            runat="server" 
            Height="600px"
            Width="600px"
            ShowToolBar="False" />
    </div>
    </form>
</body>
</html>
