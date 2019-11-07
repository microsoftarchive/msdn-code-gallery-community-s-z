<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SeriesAlignment" CodeFile="SeriesAlignment.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>SeriesAlignment</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample shows how to align several series using grouping and 
				empty points.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Palette="BrightPastel" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="DateTime" Name="Series1" CustomProperties="PointWidth=1" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series XValueType="DateTime" Name="Series2" CustomProperties="PointWidth=1" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series ChartArea="AlignedSeries" XValueType="DateTime" Name="Series3" CustomProperties="EmptyPointValue=Zero" BorderColor="180, 26, 59, 105">
									<emptypointstyle markerstyle="Diamond" markercolor="224, 64, 10"></emptypointstyle>
								</asp:Series>
								<asp:Series ChartArea="AlignedSeries" XValueType="DateTime" Name="Series4" CustomProperties="EmptyPointValue=Zero" BorderColor="180, 26, 59, 105">
									<emptypointstyle markerstyle="Diamond" markercolor="5, 100, 146"></emptypointstyle>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Non Aligned">
										<labelstyle enabled="False" />
										<majorgrid enabled="False" />
										<majortickmark enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="5.542373" height="42.32203" width="94" x="2"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="MMM d" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
								<asp:ChartArea Name="AlignedSeries" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Aligned">
										<labelstyle enabled="False" />
										<majorgrid enabled="False" />
										<majortickmark enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="50.86441" height="42.32203" width="89.43796" x="4.824818"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="2" intervaltype="Days">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="MMM d" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				The bottom chart area shows the aligned data. It displays empty points for 
                missing data points in the second series.&nbsp;For more information, click the 
                Overview tab at the top of this frame.</p>
		</form>
	</body>
</html>
