
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendCellSpan" CodeFile="LegendCellSpan.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates the cell span feature of the legend.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="chart2" runat="server" Height="296px" Width="412px" BackColor="#D3DFF0" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Center" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default">
									<CustomItems>
										<asp:LegendItem Name="North America">
											<Cells>
												<asp:LegendCell Text="North America" CellSpan="2" Alignment="MiddleLeft" Name="Cell1">
													<Margins Bottom="15" Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
										<asp:LegendItem BorderColor="200, 26, 59, 105" Name="LightBlue" Color="200, 65, 140, 240">
											<Cells>
												<asp:LegendCell SeriesSymbolSize="200, 50" CellType="SeriesSymbol" Alignment="MiddleLeft" Name="Cell1">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="Country 1" SeriesSymbolSize="200, 100" Alignment="MiddleLeft" Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
										<asp:LegendItem BorderColor="200, 26, 59, 105" Name="Gold" Color="200, 252, 180, 65">
											<Cells>
												<asp:LegendCell SeriesSymbolSize="200, 50" CellType="SeriesSymbol" Alignment="MiddleLeft" Name="Cell1">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="Country 2" Alignment="MiddleLeft" Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
										<asp:LegendItem Name="South America">
											<Cells>
												<asp:LegendCell Text="South America" CellSpan="2" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="MiddleLeft" Name="Cell1">
													<Margins Bottom="15" Left="15" Top="200" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
										<asp:LegendItem BorderColor="200, 26, 59, 105" Name="Red" Color="224, 64, 10">
											<Cells>
												<asp:LegendCell SeriesSymbolSize="200, 50" CellType="SeriesSymbol" Alignment="MiddleLeft" Name="Cell1">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="Country 3" Alignment="MiddleLeft" Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
										<asp:LegendItem BorderColor="200, 26, 59, 105" Name="DarkBlue" Color="26, 59, 105">
											<Cells>
												<asp:LegendCell SeriesSymbolSize="200, 50" CellType="SeriesSymbol" Alignment="MiddleLeft" Name="Cell1">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="Country 4" Alignment="MiddleLeft" Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
									</CustomItems>
								</asp:Legend>
							</legends>							
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" IsVisibleInLegend="False" Name="B-1" ChartType="StackedBar" CustomProperties="DrawingStyle=Cylinder" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="14" />
										<asp:DataPoint YValues="10" />
										<asp:DataPoint YValues="16" />
										<asp:DataPoint YValues="13" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" IsVisibleInLegend="False" Name="A-1" ChartType="StackedBar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="11" />
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="7" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" IsVisibleInLegend="False" Name="A-2" ChartType="StackedBar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="4" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="3" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" IsVisibleInLegend="False" Name="B-2" ChartType="StackedBar" CustomProperties="DrawingStyle=Cylinder" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" Color="26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="14" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="9" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="7">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" Format="MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2" style="PADDING-LEFT: 68px">
									<p>&nbsp;</p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
