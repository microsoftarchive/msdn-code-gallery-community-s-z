<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.TitleCustomPosition" CodeFile="TitleCustomPosition.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendCustomPosition</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LegendCustomPosition" method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to position the chart by setting the coordinates 
				of its top left corner, width, and height.
			</p>
			<table class="sampleTable">
				<tr>
					<td height="296" width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" Palette="Pastel" BackColor="#D3DFF0" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart" Alignment="TopLeft" ForeColor="26, 59, 105">
									<position Y="4" Height="8.738057" Width="55" X="4"></position>
								</asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" BorderWidth="0" BorderColor="Black" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series LegendText="Total" ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="70" />
										<asp:DataPoint XValue="2" YValues="80" />
										<asp:DataPoint XValue="3" YValues="70" />
										<asp:DataPoint XValue="4" YValues="85" />
									</points>
								</asp:Series>
								<asp:Series LegendText="Sales" ChartArea="ChartArea1" XValueType="Double" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="252, 180, 65" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="65" />
										<asp:DataPoint XValue="2" YValues="70" />
										<asp:DataPoint XValue="3" YValues="60" />
										<asp:DataPoint XValue="4" YValues="75" />
									</points>
								</asp:Series>
								<asp:Series LegendText="Clients" ChartArea="ChartArea1" XValueType="Double" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="224, 64, 10" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="50" />
										<asp:DataPoint XValue="2" YValues="55" />
										<asp:DataPoint XValue="3" YValues="40" />
										<asp:DataPoint XValue="4" YValues="70" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle PointGapDepth="0" Rotation="5" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="13" Height="75" Width="90" X="2"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Interval="1">
										<LabelStyle Font="Trebuchet MS, 8.25pt" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<CustomLabels>
											<asp:CustomLabel Text="John" ToPosition="1.5" FromPosition="0.5"></asp:CustomLabel>
											<asp:CustomLabel Text="Mary" ToPosition="2.5" FromPosition="1.5"></asp:CustomLabel>
											<asp:CustomLabel Text="Jeff" ToPosition="3.5" FromPosition="2.5"></asp:CustomLabel>
											<asp:CustomLabel Text="Bob" ToPosition="4.5" FromPosition="3.5"></asp:CustomLabel>
										</CustomLabels>
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">X:</td>
								<td><asp:TextBox id="TextBoxX" runat="server" Width="100px">10.0</asp:TextBox></td>
							</tr>
							<tr>
								<td class="label">Y:</td>
								<td><asp:TextBox id="TextBoxY" runat="server" Width="100px">10.0</asp:TextBox></td>
							</tr>
							<tr>
								<td class="label">Width:</td>
								<td><asp:TextBox id="TextBoxWidth" runat="server" Width="100px" ontextchanged="TextBoxWidth_TextChanged">50.0</asp:TextBox></td>
							</tr>
							<tr>
								<td class="label">Height:</td>
								<td><asp:TextBox id="TextBoxHeight" runat="server" Width="100px">15.0</asp:TextBox></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td><asp:Button id="Button1" runat="server" Text="Set Title Position"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				All coordinates are relative and must range from 0 to 100. The Chart control uses the 
                InputTag rendering type and the server-side Click event to make the 
				chart interactive, allowing you to set the top-left corner coordinates of the 
				title by clicking on the chart.</p>
		</form>
	</body>
</html>
