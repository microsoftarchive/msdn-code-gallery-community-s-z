<%@ Page Language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ZOrder"
    CodeFile="ZOrder.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>WebForm1</title>
    <link media="all" href="../../../samples.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <p class="dscr">
        This sample shows how to change the Z order for chart areas and series. Click on
        the chart to set the top chart area.</p>
    <table class="sampleTable">
        <tr>
            <td width="412" class="tdchart">
                <asp:Chart ID="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                    ImageType="Png" BorderlineDashStyle="Solid" Palette="Pastel" BackGradientStyle="TopBottom"
                    BorderWidth="2" BackColor="#F3DFC1" BorderColor="181, 64, 1" 
                    onpostpaint="Chart1_PostPaint">
                    <Titles>
                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                            ForeColor="26, 59, 105">
                        </asp:Title>
                    </Titles>
                    <Legends>
                        <asp:Legend Enabled="False" Name="Default" BackColor="Transparent">
                        </asp:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                    <Series>
                        <asp:Series ChartArea="Chart Area 1" Name="Series1" ChartType="Area" BorderColor="180, 26, 59, 105"
                            Color="220, 65, 140, 240">
                            <Points>
                                <asp:DataPoint YValues="3" />
                                <asp:DataPoint YValues="7" />
                                <asp:DataPoint YValues="8" />
                                <asp:DataPoint YValues="6" />
                                <asp:DataPoint YValues="7" />
                            </Points>
                        </asp:Series>
                        <asp:Series ChartArea="Chart Area 1" Name="Series2" ShadowColor="Transparent" BorderColor="180, 26, 59, 105"
                            Color="220, 5, 100, 146" >
                            <Points>
                                <asp:DataPoint YValues="4" />
                                <asp:DataPoint YValues="7" />
                                <asp:DataPoint YValues="6" />
                                <asp:DataPoint YValues="5" />
                                <asp:DataPoint YValues="5" />
                            </Points>
                        </asp:Series>
                        <asp:Series ChartArea="Chart Area 2" Name="Series3" ChartType="Area" BorderColor="64, 0, 0, 0"
                            Color="220, 252, 180, 65">
                            <Points>
                                <asp:DataPoint YValues="6" />
                                <asp:DataPoint YValues="7" />
                                <asp:DataPoint YValues="5" />
                                <asp:DataPoint YValues="7" />
                                <asp:DataPoint YValues="6" />
                            </Points>
                        </asp:Series>
                        <asp:Series ChartArea="Chart Area 2" Name="Series4" BorderColor="64, 0, 0, 0" Color="220, 224, 64, 10">
                            <Points>
                                <asp:DataPoint YValues="6" />
                                <asp:DataPoint YValues="4" />
                                <asp:DataPoint YValues="6" />
                                <asp:DataPoint YValues="5" />
                                <asp:DataPoint YValues="7" />
                            </Points>
                        </asp:Series>
                        <asp:Series ChartArea="Chart Area 3" Name="Series5" ChartType="Area" BorderColor="180, 26, 59, 105"
                            Color="220, 241, 185, 168">
                            <Points>
                                <asp:DataPoint YValues="4" />
                                <asp:DataPoint YValues="3" />
                                <asp:DataPoint YValues="7" />
                                <asp:DataPoint YValues="5" />
                                <asp:DataPoint YValues="6" />
                            </Points>
                        </asp:Series>
                        <asp:Series ChartArea="Chart Area 3" Name="Series6" BorderColor="180, 26, 59, 105"
                            Color="220, 120, 147, 190">
                            <Points>
                                <asp:DataPoint YValues="8" />
                                <asp:DataPoint YValues="4" />
                                <asp:DataPoint YValues="6" />
                                <asp:DataPoint YValues="5" />
                                <asp:DataPoint YValues="6" />
                            </Points>
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="Chart Area 1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                            ShadowOffset="2" BackColor="OldLace" >
                            <Position Y="5" Height="50" Width="50" X="5"></Position>
                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisX>
                        </asp:ChartArea>
                        <asp:ChartArea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                            ShadowOffset="2" BackColor="OldLace">
                            <Position Y="25" Height="50" Width="50" X="25"></Position>
                            <AxisY LineColor="64, 64, 64, 64">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisX>
                        </asp:ChartArea>
                        <asp:ChartArea Name="Chart Area 3" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                            ShadowOffset="2" BackColor="OldLace">
                            <Position Y="45" Height="50" Width="50" X="45"></Position>
                            <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <td valign="top">
                <table class="controls" cellpadding="4">
                    <tr>
                        <td class="label">
                            Chart Areas Z Order:
                        </td>
                        <td>
                            <asp:DropDownList ID="AreaOrder" runat="server" AutoPostBack="True" Width="104px">
                                <asp:ListItem Value="1-2-3">1-2-3</asp:ListItem>
                                <asp:ListItem Value="1-3-2">1-3-2</asp:ListItem>
                                <asp:ListItem Value="2-1-3">2-1-3</asp:ListItem>
                                <asp:ListItem Value="2-3-1">2-3-1</asp:ListItem>
                                <asp:ListItem Value="3-1-2">3-1-2</asp:ListItem>
                                <asp:ListItem Value="3-2-1">3-2-1</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            Series Z Order:
                        </td>
                        <td>
                            <asp:DropDownList ID="SeriesOrder" runat="server" AutoPostBack="True" Width="104px">
                                <asp:ListItem Value="1-2">Bar - Area</asp:ListItem>
                                <asp:ListItem Value="2-1">Area - Bar</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <p class="dscr">
        <!-- SECOND DESCRIPTION HERE-->
    </p>
    </form>
</body>
</html>
