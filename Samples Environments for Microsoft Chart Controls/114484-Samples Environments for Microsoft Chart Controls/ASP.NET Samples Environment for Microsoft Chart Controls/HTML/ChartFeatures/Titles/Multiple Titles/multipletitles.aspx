
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MultipleTitles" CodeFile="MultipleTitles.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ChartTitle</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="ChartTitle" method="post" runat="server">
			<p class="dscr">
				This sample shows how to add multiple titles and how to dock titles to the 
				chart area. Try changing the alignment and docking of the "SIDEBAR" title using 
				controls below.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="Pastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#F3DFC1" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart for .NET Framework" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:Title>
								<asp:Title Docking="Left" Font="Trebuchet MS, 14.25pt" ShadowOffset="-1" Text="SIDEBAR" ForeColor="26, 59, 105"></asp:Title>
								<asp:Title Docking="Bottom" Font="Trebuchet MS, 8.25pt" 
                                    Text="© Microsoft Corporation" Alignment="MiddleRight"></asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
								<asp:Legend Enabled="False" Docking="Bottom" Name="Legend2"></asp:Legend>
								<asp:Legend LegendStyle="Row" Enabled="False" IsTextAutoFit="False" Docking="Bottom" Name="Legend3" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
									<CustomItems>
										<asp:LegendItem Name="Previous Month Avg" Color="65, 140, 240"></asp:LegendItem>
										<asp:LegendItem Name="Last Week" Color="252, 180, 65"></asp:LegendItem>
										<asp:LegendItem Name="This Week" Color="224, 64, 10"></asp:LegendItem>
									</CustomItems>
								</asp:Legend>
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
								<asp:Series LegendText="Sales" ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65">
									<points>
										<asp:DataPoint XValue="1" YValues="65" />
										<asp:DataPoint XValue="2" YValues="70" />
										<asp:DataPoint XValue="3" YValues="60" />
										<asp:DataPoint XValue="4" YValues="75" />
									</points>
								</asp:Series>
								<asp:Series LegendText="Clients" ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10">
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
									<area3dstyle PointGapDepth="0" Rotation="5" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">Alignment:</td>
								<td><asp:dropdownlist id="Alignment" runat="server" Width="112px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Docking:</td>
								<td><asp:dropdownlist id="Docking" runat="server" Width="112px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Dock To Chart Area:</td>
								<td><asp:checkbox id="CheckboxDockToArea" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Dock Inside Chart Area:</td>
								<td><asp:checkbox id="IsDockedInsideChartArea" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
