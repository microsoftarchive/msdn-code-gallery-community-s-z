
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SeriesAndChartAreas" CodeFile="SeriesAndChartAreas.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to&nbsp;attach a series to a chart 
				area.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:chart id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BackColor="WhiteSmoke" BorderColor="26, 59, 105">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
									<position y="87" height="8.351166" width="45.19481" x="49.0679665"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series LegendText="Blue" Name="Series1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="7" />
									</points>
								</asp:series>
								<asp:series LegendText="Gold" ChartArea="ChartArea1" Name="Series2" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="5" />
									</points>
								</asp:series>
								<asp:series LegendText="Red" ChartArea="ChartArea1" Name="Series3" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="5" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="5.5423727" height="42" width="89.43796" x="4.82481766"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="47" height="42" width="89.43796" x="4.82481766"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Blue Series #1:</td>
								<td><asp:dropdownlist id="Series1" runat="server" AutoPostBack="True">
										<asp:listitem Value="None">None</asp:listitem>
										<asp:listitem Value="ChartArea1" Selected="True">Chart Area 1</asp:listitem>
										<asp:listitem Value="Chart Area 2">Chart Area 2</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Gold Series #2:</td>
								<td><asp:dropdownlist id="Series2" runat="server" AutoPostBack="True">
										<asp:listitem Value="None">None</asp:listitem>
										<asp:listitem Value="ChartArea1">Chart Area 1</asp:listitem>
										<asp:listitem Value="Chart Area 2" Selected="True">Chart Area 2</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Red Series #3:</td>
								<td><asp:dropdownlist id="Series3" runat="server" AutoPostBack="True">
										<asp:listitem Value="None">None</asp:listitem>
										<asp:listitem Value="ChartArea1">Chart Area 1</asp:listitem>
										<asp:listitem Value="Chart Area 2" Selected="True">Chart Area 2</asp:listitem>
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
