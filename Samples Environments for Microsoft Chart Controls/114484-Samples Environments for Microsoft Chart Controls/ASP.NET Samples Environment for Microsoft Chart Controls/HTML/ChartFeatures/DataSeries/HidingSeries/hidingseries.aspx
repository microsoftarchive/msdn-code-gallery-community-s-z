<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.HidingSeries" CodeFile="HidingSeries.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to hide a data series.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="416px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:legend LegendStyle="Table" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Left" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series 1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="7" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series 4" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="8" />
									</points>
								</asp:series>
								<asp:series BorderWidth="2" ChartArea="ChartArea1" XValueType="DateTime" Name="Series 2" ChartType="Spline" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" ShadowOffset="2">
									<points>
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="6" />
									</points>
								</asp:series>
								<asp:series BorderWidth="2" ChartArea="ChartArea1" XValueType="DateTime" Name="Series 3" ChartType="StepLine" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" Color="26, 59, 105" ShadowOffset="2">
									<points>
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="2" />
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="9" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="dd MMM" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:checkbox id="HideSeries1" runat="server" AutoPostBack="True" Text="Hide Series 1"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:checkbox id="HideSeries2" runat="server" AutoPostBack="True" Text="Hide Series 2"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:checkbox id="HideSeries3" runat="server" AutoPostBack="True" Text="Hide Series 3"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:checkbox id="HideSeries4" runat="server" AutoPostBack="True" Text="Hide Series 4"></asp:checkbox></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
