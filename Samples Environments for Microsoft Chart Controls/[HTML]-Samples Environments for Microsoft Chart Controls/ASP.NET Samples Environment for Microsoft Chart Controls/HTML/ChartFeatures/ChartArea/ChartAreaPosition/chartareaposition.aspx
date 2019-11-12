<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartAreaPosition" CodeFile="ChartAreaPosition.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendCustomPosition</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LegendCustomPosition" method="post" runat="server">
			<p class="dscr">
				This sample shows how to manually set the positions of the chart area and plot area.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart" valign="top">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" Palette="Pastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart Control for .NET Framework" Alignment="TopLeft" ForeColor="26, 59, 105">
									<position y="4" height="8.738057" width="80" x="4"></position>
								</asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="13" height="75" width="90" x="2"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
										<labelstyle font="Trebuchet MS, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<customlabels>
											<asp:customlabel Text="John" ToPosition="1.5" FromPosition="0.5"></asp:customlabel>
											<asp:customlabel Text="Mary" ToPosition="2.5" FromPosition="1.5"></asp:customlabel>
											<asp:customlabel Text="Jeff" ToPosition="3.5" FromPosition="2.5"></asp:customlabel>
											<asp:customlabel Text="Bob" ToPosition="4.5" FromPosition="3.5"></asp:customlabel>
										</customlabels>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2" class="label">Chart Area Position:</td>
								<td></td>
							</tr>
							<tr>
								<td class="label">X:</td>
								<td><asp:textbox id="X1" runat="server" Width="100px">10</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Y:</td>
								<td><asp:textbox id="Y1" runat="server" Width="100px">10</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Width:</td>
								<td><asp:textbox id="Width1" runat="server" Width="100px">80</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Height:</td>
								<td><asp:textbox id="Height1" runat="server" Width="100px">80</asp:textbox></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="Button1" runat="server" Text="Set Chart Area Position" Width="190px"></asp:button></td>
							</tr>
							<tr>
								<td colspan="2" class="label">Plot Area Position:</td>
								<td></td>
							</tr>
							<tr>
								<td class="label">X:</td>
								<td><asp:textbox id="X2" runat="server" Width="100px">10</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Y:</td>
								<td><asp:textbox id="Y2" runat="server" Width="100px">10</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Width:</td>
								<td><asp:textbox id="Width2" runat="server" Width="100px">80</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Height:</td>
								<td><asp:textbox id="Height2" runat="server" Width="100px">80</asp:textbox></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button 
                                        id="Button2" runat="server" Text="Set Plot Area Position" Width="210px"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The plot area is the portion within a chart area that is used for 
                plotting data, and does not include tick marks and axis labels.</p>
		</form>
	</body>
</html>
