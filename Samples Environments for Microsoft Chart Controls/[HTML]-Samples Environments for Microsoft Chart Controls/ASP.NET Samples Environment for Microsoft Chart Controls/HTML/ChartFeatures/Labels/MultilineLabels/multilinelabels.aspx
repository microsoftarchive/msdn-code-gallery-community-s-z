
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MultilineLabels" CodeFile="MultilineLabels.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>MultilineLabels</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to set labels for point values. It also shows how 
				to set labels for individual data points.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="Pastel" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart for .NET Framework" Alignment="TopLeft" ForeColor="26, 59, 105">
									<position y="4" height="8.738057" width="65" x="4"></position>
								</asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Font="Trebuchet MS, 8.25pt, style=Bold" Legend="Legend2" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="70" />
										<asp:DataPoint XValue="2" YValues="80" />
										<asp:DataPoint XValue="3" YValues="70" />
										<asp:DataPoint XValue="4" YValues="85" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series1" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65" Font="Trebuchet MS, 8.25pt, style=Bold">
									<points>
										<asp:DataPoint BorderColor="64, 0, 0, 0" XValue="1" YValues="65" />
										<asp:DataPoint XValue="2" YValues="70" />
										<asp:DataPoint BorderWidth="2" BorderColor="220, 26, 59, 105" XValue="3" YValues="82" />
										<asp:DataPoint XValue="4" YValues="75" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10" Font="Trebuchet MS, 8.25pt, style=Bold">
									<points>
										<asp:DataPoint XValue="1" YValues="50" />
										<asp:DataPoint XValue="2" YValues="55" />
										<asp:DataPoint XValue="3" YValues="40" />
										<asp:DataPoint XValue="4" YValues="70" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="13" height="75" width="90" x="2"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Show Point Values:</td>
								<td>
									<asp:checkbox id="ShowValueLabels" runat="server" Checked="True" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="90px">Axis Label:</asp:label></td>
								<td>
									<asp:textbox id="AxisLabel" runat="server" cssclass="spaceright">Axis Label #3</asp:textbox>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="90px"> Point Label:</asp:label></td>
								<td>
									<asp:textbox id="PointLabel" runat="server" cssclass="spaceright">Point Label #3</asp:textbox>
								</td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 48px">
									<asp:button id="SetLabels" runat="server" Text="Set Labels for Point # 3"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Set your own labels for the third data point by entering 
				the desired text and clicking the Set Labels for Point # 3 button above. Multiple text lines in 
				the label can be separated with the &quot;\n&quot; string.</p>
			<p>
			</p>
		</form>
	</body>
</html>
