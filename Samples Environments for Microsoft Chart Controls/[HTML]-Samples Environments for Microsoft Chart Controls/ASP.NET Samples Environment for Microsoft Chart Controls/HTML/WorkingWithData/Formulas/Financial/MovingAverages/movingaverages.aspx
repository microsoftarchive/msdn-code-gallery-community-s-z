
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MovingAverages" CodeFile="MovingAverages.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<p>
		</p>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample displays four different types of moving averages.&nbsp;The main difference between these&nbsp;averages is how weights are applied 
                to different portions of the data.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" 
                            Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" 
                            ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" EnableViewState="True" 
                            onclick="Chart1_Click" onload="Chart1_Load">
							<legends>
                                <asp:Legend IsTextAutoFit="False" BackColor="Transparent" BorderColor="64, 64, 64, 64"
                                    Font="Trebuchet MS, 8pt, style=Bold" HeaderSeparator="Line" HeaderSeparatorColor="64, 64, 64, 64"
                                    ItemColumnSeparator="Line" ItemColumnSeparatorColor="64, 64, 64, 64" Name="Default"
                                    TitleFont="Trebuchet MS, 12pt, style=Bold" TitleSeparatorColor="64, 64, 64, 64">
                                    <CustomItems>
                                        <asp:LegendItem BorderWidth="2" Color="65, 140, 240" MarkerSize="10" MarkerStyle="Circle"
                                            Name="Input">
                                            <Cells>
                                                <asp:LegendCell CellType="Image" Name="Cell1" >
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell CellType="SeriesSymbol" Name="Cell2">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell Alignment="MiddleLeft" Name="Cell3" Text="Input">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                            </Cells>
                                        </asp:LegendItem>
                                        <asp:LegendItem BorderWidth="2" Color="252, 180, 65" MarkerSize="10" MarkerStyle="Circle"
                                            Name="Simple">
                                            <Cells>
                                                <asp:LegendCell CellType="Image" Name="Cell1">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell CellType="SeriesSymbol" Name="Cell2">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell Alignment="MiddleLeft" Name="Cell3" Text="Simple">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                            </Cells>
                                        </asp:LegendItem>
                                        <asp:LegendItem BorderWidth="2" Color="224, 64, 10" MarkerSize="10" MarkerStyle="Circle"
                                            Name="Exponential">
                                            <Cells>
                                                <asp:LegendCell CellType="Image" Name="Cell1">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell CellType="SeriesSymbol" Name="Cell2">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell Alignment="MiddleLeft" Name="Cell3" Text="Exponential">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                            </Cells>
                                        </asp:LegendItem>
                                        <asp:LegendItem BorderWidth="2" Color="5, 100, 146" MarkerSize="10" MarkerStyle="Circle"
                                            Name="Triangular">
                                            <Cells>
                                                <asp:LegendCell CellType="Image" Name="Cell1">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell CellType="SeriesSymbol" Name="Cell2">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell Alignment="MiddleLeft" Name="Cell3" Text="Triangular">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                            </Cells>
                                        </asp:LegendItem>
                                        <asp:LegendItem BorderWidth="2" Color="191, 191, 191" MarkerSize="10" MarkerStyle="Circle"
                                            Name="Weighted">
                                            <Cells>
                                                <asp:LegendCell CellType="Image" Name="Cell1">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell CellType="SeriesSymbol" Name="Cell2">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                                <asp:LegendCell Alignment="MiddleLeft" Name="Cell3" Text="Weighted">
                                                    <Margins Left="15" Right="15" />
                                                </asp:LegendCell>
                                            </Cells>
                                        </asp:LegendItem>
                                    </CustomItems>
                                </asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
                                <asp:Series BorderColor="180, 26, 59, 105" BorderWidth="2" ChartType="Line" Name="Input"
                                    ShadowColor="254, 64, 64, 64" ShadowOffset="1" IsVisibleInLegend="False" XValueType="Double"
                                    YValueType="Double">
                                </asp:Series>
							</series>
							<chartareas>
                                <asp:ChartArea BackColor="OldLace" BackSecondaryColor="White" BackGradientStyle="TopBottom"
                                    BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" Name="Default" ShadowColor="Transparent">
                                    <axisx LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </axisx>
                                    <area3dstyle IsClustered="False" Perspective="10" IsRightAngleAxes="False" WallWidth="0"
                                        Inclination="15" Rotation="10" />
                                    <axisy LineColor="64, 64, 64, 64" IsStartedFromZero="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </axisy>
                                </asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									Period:
									<asp:dropdownlist id="Period" runat="server" AutoPostBack="True">
										<asp:listitem Value="5" Selected="True">5 days</asp:listitem>
										<asp:listitem Value="10">10 days</asp:listitem>
										<asp:listitem Value="15">15 days</asp:listitem>
										<asp:listitem Value="20">20 days</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p><asp:checkbox id="IsStartedFromFirst" runat="server" Text="Start From First" AutoPostBack="True"></asp:checkbox>&nbsp;</p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:checkbox id="HistoricalData" runat="server" Text="Filter Historical Data" AutoPostBack="True"></asp:checkbox>&nbsp;</p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:button id="Random3" runat="server" Text="Random" CommandArgument="5" onclick="Random3_Click"></asp:button>&nbsp;</p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td nowrap="nowrap">
									</td>
							</tr>
							<tr>
								<td class="label48" style="height: 22px"></td>
								<td style="height: 22px">
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
                                        &nbsp;</p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
                                        &nbsp;</p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
                Select or clear the appropriate legend item to enable or disable a moving average.</p>
			<p>&nbsp;</p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
