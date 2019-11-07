<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SeriesZOrder" CodeFile="SeriesZOrder.aspx.cs" %>

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
			<p class="dscr">This sample shows how to change the Z-order of each series.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x296 px)-->
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105">
							<legends>
								<asp:legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="7" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series2" ChartType="Spline" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65">
									<points>
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="2" />
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="1" />
										<asp:datapoint YValues="6" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series3" ChartType="SplineArea" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10">
									<points>
										<asp:datapoint YValues="1" />
										<asp:datapoint YValues="2" />
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="1" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="dd MMM" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Series Z Order:</td>
								<td>
									<asp:dropdownlist id="SeriesOrder" runat="server" AutoPostBack="True">
										<asp:listitem>Bar-Spline-Area</asp:listitem>
										<asp:listitem>Bar-Area-Spline</asp:listitem>
										<asp:listitem>Spline-Bar-Area</asp:listitem>
										<asp:listitem>Spline-Area-Bar</asp:listitem>
										<asp:listitem>Area-Bar-Spline</asp:listitem>
										<asp:listitem>Area-Spline-Bar</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Use Solid Colors:</td>
								<td>
									<asp:checkbox id="SolidColors" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
