<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AligningPlotAreas" CodeFile="aligningplotareas.aspx.cs" %>

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
			<p class="dscr">This sample shows how to align chart areas.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" width="412"><asp:chart id="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="BrightPastel" BorderlineDashStyle="Solid" BackColor="#D3DFF0" Width="412px" Height="296px">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="7" />
									</points>
								</asp:series>
								<asp:series BorderWidth="2" ChartArea="Chart Area 2" XValueType="DateTime" Name="Series2" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1">
									<points>
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="6" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" linewidth="2">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="dd MMM" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
									<axisy2 linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" linewidth="2">
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
								<td class="label">Alignment type:</td>
								<td><asp:dropdownlist id="Alignment" runat="server" AutoPostBack="True">
										<asp:listitem Value="Horizontal Alignment">Horizontal Alignment</asp:listitem>
										<asp:listitem Value="Vertical Alignment">Vertical Alignment</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
