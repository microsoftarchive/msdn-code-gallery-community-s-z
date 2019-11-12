
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MultiYBubble" CodeFile="MultiYBubble.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>ImageMapCustom</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
  </head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample demonstrates how a Stock chart type uses 4 Y values 
				(high, low, open, and close) per data point.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
                        <asp:Chart ID="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                            BackColor="#F3DFC1" Width="412px" Height="296px" BorderColor="181, 64, 1" BorderlineDashStyle="Solid"
                            Palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="Using Multiple Y Values" ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend Enabled="False" IsTextAutoFit="False" DockedToChartArea="ChartArea1"
                                    Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series BorderWidth="3" YValuesPerPoint="4" ChartArea="ChartArea1" Name="Series 1"
                                    ChartType="Stock" ShadowColor="254, 0, 0, 0" BorderColor="180, 26, 59, 105"
                                    Color="220, 65, 140, 240" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
                                    <AxisY2 Enabled="False">
                                    </AxisY2>
                                    <AxisX2 Enabled="False">
                                    </AxisX2>
                                    <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                        WallWidth="0" IsClustered="False"></Area3DStyle>
                                    <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<p>Most of the chart types use just one Y value, but some chart types like Bubble, 
										Stock, Range and others require more than one value.</p>
									<p>For example, the Stock chart shown in this sample requires 4 Y values to 
										represent the High, Low, Open and Close values for each data point.</p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
<p class=dscr style="LEFT: 10px; TOP: 375px">Each data point has:</p>
            <ul>
                <li>
                    <p class=dscr style="LEFT: 10px; TOP: 375px">
                        An X value: Determines where a data point is plotted along the X axis. This 
                        corresponds to 
the DataPoint.XValue property.</p>
                </li>
                <li>
                    <p class=dscr style="LEFT: 10px; TOP: 375px">
                        One or more Y values: Correspond to the 
DataPoint.YValues array property.</p>
                </li>
            </ul>
		</form>
	</body>
</html>
