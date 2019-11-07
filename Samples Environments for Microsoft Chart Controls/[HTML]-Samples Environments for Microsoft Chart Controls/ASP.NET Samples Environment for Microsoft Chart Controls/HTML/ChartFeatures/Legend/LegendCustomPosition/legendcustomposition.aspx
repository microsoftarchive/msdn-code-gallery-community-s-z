<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendCustomPosition" CodeFile="LegendCustomPosition.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendCustomPosition</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
        <script type="text/javascript">
		    function getCoordinates(event) { if (typeof(event.x) == 'undefined') { return event.layerX + "," + event.layerY; } return event.x + "," + event.y; }
		</script>		
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to position the legend by setting the coordinates 
				of its width and height, relative to the top left corner.
			</p>
			<table class="sampleTable" border="1">
				<tr>
					<td class="tdchart">
					    <asp:chart id="Chart1" runat="server" Height="296px" Width="412px" Palette="BrightPastel" BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" ToolTip="Click on the chart to set the legend's box top left corner position." BorderlineDashStyle="Solid" BorderWidth="2" BorderColor="26, 59, 105" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" rendertype="ImageTag" style="position:relative;">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Legend Positioning" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" BorderColor="5, 100, 146" Name="Default" LegendStyle="Row">
									<position Y="80" Height="10" Width="60" X="8"></position>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Default" YValueType="Double">
									<points>
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="200" />
										<asp:DataPoint YValues="560" />
										<asp:DataPoint YValues="300" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2">
									<points>
										<asp:DataPoint YValues="550" />
										<asp:DataPoint YValues="580" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="425" />
										<asp:DataPoint YValues="400" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3">
									<points>
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="350" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="520" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="18.3307" Height="62.58395" Width="88.77716" X="5.089137"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart>
						</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="50px">X:</asp:label></td>
								<td>
									<p>
										<asp:textbox id="TextBoxX" runat="server" Width="100px">8.0</asp:textbox></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="50px">Y:</asp:label></td>
								<td>
									<p>
										<asp:textbox id="TextBoxY" runat="server" Width="100px">80.0</asp:textbox></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="50px">Width:</asp:label></td>
								<td>
									<p>
										<asp:textbox id="TextBoxWidth" runat="server" Width="100px">60.0</asp:textbox></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Width="50px">Height:</asp:label></td>
								<td>
									<asp:textbox id="TextBoxHeight" runat="server" Width="100px">10.0</asp:textbox>
								</td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 68px">
									<asp:button id="Button1" runat="server" Text="Set Legend Position" width="177px"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">All coordinates are relative to the entire chart image and must 
				range from 0 to 100. This example also uses the MouseDown event to make the chart 
				interactive. You can set the top-left position of the legend by clicking on the chart.</p>
		</form>
	</body>
</html>
