<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageType" CodeFile="ImageType.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageType</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to render a&nbsp;chart as&nbsp;an 
				Image tag using different image formats.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Palette="BrightPastel" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart As Image Tag" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Left" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series XValueType="Double" Name="Series1" ChartType="Doughnut" BorderColor="180, 26, 59, 105" Font="Trebuchet MS, 8.25pt, style=Bold" YValueType="Double">
									<points>
										<asp:datapoint AxisLabel="John" YValues="45" />
										<asp:datapoint AxisLabel="Alex" YValues="75" />
										<asp:datapoint AxisLabel="Richard" YValues="39" />
										<asp:datapoint AxisLabel="Antony" YValues="34" />
										<asp:datapoint AxisLabel="Doug" YValues="67" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="-54" perspective="10" enable3d="True" Inclination="41" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server">Image Type:</asp:label></td>
								<td>
									<asp:dropdownlist id="ImageTypeList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Bmp">Bmp</asp:listitem>
										<asp:listitem Value="Jpeg">Jpeg</asp:listitem>
										<asp:listitem Value="Png" Selected="True">Png</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server">Jpeg Compression:</asp:label></td>
								<td>
									<asp:dropdownlist id="CompressionList" runat="server" AutoPostBack="True">
										<asp:listitem Value="0" Selected="True">0</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
										<asp:listitem Value="60">60</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The Image quality and size are different for each of the formats, 
                and&nbsp;you can check the image size in the <b>Properties window </b>in Visual 
                Studio.</p>
			<p>
			</p>
		</form>
	</body>
</html>
