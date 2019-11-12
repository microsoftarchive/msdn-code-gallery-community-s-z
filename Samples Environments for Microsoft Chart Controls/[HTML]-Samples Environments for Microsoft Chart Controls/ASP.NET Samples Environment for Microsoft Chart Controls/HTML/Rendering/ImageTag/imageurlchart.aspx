
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageURLChart" CodeFile="ImageURLChart.aspx.cs" %>
<html>
	<head>
		<title>Flash</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<p class="dscr" id="L">This sample demonstrates how to render the chart as an&nbsp;image 
			URL.&nbsp;
		</p>
		<table class="sampleTable">
			<tr>
				<td class="tdchart">
					<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105">
						<titles>
							<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Image URL" ForeColor="26, 59, 105"></asp:title>
						</titles>
						<legends>
							<asp:legend IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
						</legends>
						<borderskin skinstyle="Emboss"></borderskin>
						<series>
							<asp:series Name="Bar Chart" ChartType="Bar" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10">
								<points>
									<asp:datapoint YValues="45" />
									<asp:datapoint YValues="34" />
									<asp:datapoint YValues="67" />
									<asp:datapoint YValues="31" />
									<asp:datapoint YValues="27" />
									<asp:datapoint YValues="87" />
									<asp:datapoint YValues="45" />
									<asp:datapoint YValues="32" />
								</points>
							</asp:series>
						</series>
						<chartareas>
							<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
								<axisx2 IsReversed="True"></axisx2>
								<area3dstyle Rotation="10" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
								<axisy linecolor="64, 64, 64, 64">
									<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									<majorgrid linecolor="64, 64, 64, 64" />
								</axisy>
								<axisx linecolor="64, 64, 64, 64" IsReversed="True">
									<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
									<majorgrid linecolor="64, 64, 64, 64" enabled="False" />
								</axisx>
							</asp:chartarea>
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
		<p class="dscr">This rendering method stores the 
			image on the server. It&nbsp;allows for caching of rendered charts for a specified duration.</p>
		<p>
		</p>
	</body>
</html>
