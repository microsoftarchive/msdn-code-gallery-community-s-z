<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MergingValues" CodeFile="MergingValues.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>MergingValues</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to merge data points from multiple 
				series into one series.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series MarkerSize="3" Name="High" ChartType="Spline" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:series>
								<asp:series MarkerSize="3" Name="Low" ChartType="Spline" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:series>
								<asp:series MarkerSize="3" Name="Open" ChartType="Spline" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:series>
								<asp:series MarkerSize="3" Name="Close" ChartType="Spline" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									Show As Stock Chart:
								</td>
								<td>
									<asp:checkbox id="ShowAsStockChart" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">In this sample, the high, low, open, and close stock prices are 
                stored in four different series of the Line chart type at first. When you select 
                Show As Stock Chart, the four series are merged into one series of the Stock 
                chart type with four Y vlaues.</p>
			<p>
			</p>
		</form>
	</body>
</html>
