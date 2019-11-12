<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SelectingChartTypes" CodeFile="SelectingChartTypes.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<p>
		</p>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how the end user can update the chart using AJAX Update Panel by selecting
                a chart type.&nbsp;
            </p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Chart ID="Chart1" runat="server" Width="506px" onclick="Chart1_Click" EnableViewState="true">
                                <Legends>
                                    <asp:Legend Alignment="Center" Docking="Bottom" Name="Legend1">
                                        <CustomItems>
                                            <asp:LegendItem Name="Legend Item" >
                                                <Cells>
                                                    <asp:LegendCell CellType="Image" Image="radio_button_checked.gif" 
                                                        Name="Cell1">
                                                        <Margins Left="15" Right="15" />
                                                    </asp:LegendCell>
                                                    <asp:LegendCell Name="Cell2" Text="Stock">
                                                        <Margins Left="15" Right="15" />
                                                    </asp:LegendCell>
                                                </Cells>
                                            </asp:LegendItem>
                                            <asp:LegendItem Name="Legend Item" >
                                                <Cells>
                                                    <asp:LegendCell CellType="Image" Image="radio_button_unchecked.gif" 
                                                        Name="Cell1" ImageTransparentColor="Black">
                                                        <Margins Left="15" Right="15" />
                                                    </asp:LegendCell>
                                                    <asp:LegendCell Name="Cell2" Text="Candlestick">
                                                        <Margins Left="15" Right="15" />
                                                    </asp:LegendCell>
                                                </Cells>
                                            </asp:LegendItem>
                                            <asp:LegendItem Name="Legend Item" >
                                                <Cells>
                                                    <asp:LegendCell CellType="Image" Image="radio_button_unchecked.gif" 
                                                        Name="Cell1" ImageTransparentColor="Black">
                                                        <Margins Left="15" Right="15" />
                                                    </asp:LegendCell>
                                                    <asp:LegendCell Name="Cell2" Text="Line">
                                                        <Margins Left="15" Right="15" />
                                                    </asp:LegendCell>
                                                </Cells>
                                            </asp:LegendItem>
                                        </CustomItems>
                                    </asp:Legend>
                                </Legends>
                                <series>
                                    <asp:Series BorderWidth="2" Name="Central"
                                                    ShadowColor="Black" IsVisibleInLegend="False" 
                                                    XValueType="DateTime" YValuesPerPoint="4"
                                                    YValueType="Double" ChartType="Stock">
                                    </asp:Series>
                                </series>
                                <BorderSkin SkinStyle="Emboss" />
                                <chartareas>
                                    <asp:ChartArea Name="Default">
                                        <AxisY IsStartedFromZero="false"></AxisY>
                                    </asp:ChartArea>
                                </chartareas>
                            </asp:Chart>
                        </ContentTemplate>
                    </asp:UpdatePanel>
					</td>
				</tr>
			</table>
			<p class="dscr">
                Click on the appropriate radio button to select the chart type desired.</p>
		</form>
	</body>
</html>
