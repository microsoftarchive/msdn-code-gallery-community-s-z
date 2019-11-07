<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxControls.Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /* AJAX Controls sample styles  
        ----------------------------------------------------------*/

        .accordionHeader
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #2E4d7B;
        	font-family: Arial, Sans-Serif;
        	font-size: 12px;
        	font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        .accordionHeader a
        {
        	color: #FFFFFF;
        	background: none;
        	text-decoration: none;
        }

        .accordionHeader a:hover
        {
        	background: none;
        	text-decoration: underline;
        }

        .accordionHeaderSelected
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
        	font-family: Arial, Sans-Serif;
        	font-size: 12px;
        	font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
        }

        .accordionHeaderSelected a
        {
        	color: #FFFFFF;
        	background: none;
        	text-decoration: none;
        }

        .accordionHeaderSelected a:hover
        {
        	background: none;
        	text-decoration: underline;
        }

        .accordionContent
        {
            background-color: #D3DEEF;
            border: 1px dashed #2F4F4F;
            border-top: none;
            padding: 5px;
            padding-top: 10px;
        }

        .table
        {
            border: 1px dashed #2F4F4F;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Using ReportViewer with AJAX Controls</h1>
        <p>This sample demonstrates how you can use the Visual Studio 2010 ReportViewer control in an AJAX application. It uses the Accordion control
           in the AJAX Toolkit to display multiple reports.</p>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- Set AsyncRendering to False for the ReportViewer control in each AccordionPane, so that after the page loads you see
             a smoother behavior when switching between panes. Note each viewer still performs partial page rendering when you perform
             report actions after the page loads. -->
        <cc1:Accordion ID="Accordion1" runat="server" SelectedIndex="0"
                HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
                ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" 
                TransitionDuration="250" RequireOpenedPane="false" 
            SuppressHeaderPostbacks="true">
            <Panes>
                <cc1:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>Company Sales 2008</Header>
                    <Content>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" AsyncRendering="False" Width="600px">
                        </rsweb:ReportViewer>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>Employee Sales Summary 2008</Header>
                    <Content>
                        <rsweb:ReportViewer ID="ReportViewer2" runat="server" ProcessingMode="Remote" 
                            AsyncRendering="False" Width="600px">
                        </rsweb:ReportViewer>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>Product Catalog 2008</Header>
                    <Content>
                        <rsweb:ReportViewer ID="ReportViewer3" runat="server" ProcessingMode="Remote" 
                            AsyncRendering="False" Width="600px">
                        </rsweb:ReportViewer>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>Sales Trend 2008</Header>
                    <Content>
                        <rsweb:ReportViewer ID="ReportViewer4" runat="server" ProcessingMode="Remote" 
                            AsyncRendering="False" Width="600px">
                        </rsweb:ReportViewer>
                    </Content>
                </cc1:AccordionPane>
                <cc1:AccordionPane ID="AccordionPane5" runat="server">
                    <Header>Territory Sales Drilldown 2008</Header>
                    <Content>
                        <rsweb:ReportViewer ID="ReportViewer5" runat="server" ProcessingMode="Remote" 
                            AsyncRendering="False" Width="600px">
                        </rsweb:ReportViewer>
                    </Content>
                </cc1:AccordionPane>
            </Panes>
        </cc1:Accordion>
    
    </div>
    </form>
</body>
</html>
