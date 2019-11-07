
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendCellColumns" CodeFile="LegendCellColumns.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<%this.AfterLoad();%>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to work with cell columns to create 
				multi-column legends.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" BackColor="WhiteSmoke" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" TextAntiAliasingQuality="Normal" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Center" Docking="Bottom" TableStyle="Tall" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>							
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Bob" ChartType="StackedArea" CustomProperties="DrawingStyle=Cylinder, StackGroupName=Group1" BorderColor="180, 26, 59, 105" Color="5, 100, 146" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="3" />
										<asp:DataPoint XValue="2" YValues="5" />
										<asp:DataPoint XValue="3" YValues="6" />
										<asp:DataPoint XValue="4" YValues="7" />
										<asp:DataPoint XValue="5" YValues="8" />
									</points>
								</asp:Series>
								<asp:Series XValueType="Double" Name="John" ChartType="StackedArea" CustomProperties="DrawingStyle=Cylinder, StackGroupName=Group2" BorderColor="180, 26, 59, 105" Color="252, 180, 65" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="8" />
										<asp:DataPoint XValue="2" YValues="7" />
										<asp:DataPoint XValue="3" YValues="2" />
										<asp:DataPoint XValue="4" YValues="6" />
										<asp:DataPoint XValue="5" YValues="3" />
									</points>
								</asp:Series>
								<asp:Series XValueType="Double" Name="Nehra" ChartType="StackedArea" CustomProperties="DrawingStyle=Cylinder, StackGroupName=Group2" BorderColor="180, 26, 59, 105" Color="224, 64, 10" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="4" />
										<asp:DataPoint XValue="2" YValues="7" />
										<asp:DataPoint XValue="3" YValues="9" />
										<asp:DataPoint XValue="4" YValues="12" />
										<asp:DataPoint XValue="5" YValues="3" />
									</points>
								</asp:Series>
								<asp:Series XValueType="Double" Name="Mike" ChartType="StackedArea" CustomProperties="DrawingStyle=Cylinder, StackGroupName=Group1" BorderColor="180, 26, 59, 105" Color="65, 140, 240" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="7.19999980926514" />
										<asp:DataPoint XValue="2" YValues="8" />
										<asp:DataPoint XValue="3" YValues="8" />
										<asp:DataPoint XValue="4" YValues="9" />
										<asp:DataPoint XValue="5" YValues="9" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle PointGapDepth="0" Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="1" />
										<MajorGrid Interval="1" LineColor="64, 64, 64, 64" />
										<MajorTickMark Interval="1" Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"></td>
								<td>
									<asp:checkbox id="chk_ShowAvg" runat="server" Width="237px" AutoPostBack="True" Text="Show Average" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
									<asp:checkbox id="chk_ShowTotal" runat="server" Width="237px" AutoPostBack="True" Text="Show Total" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
									<asp:checkbox id="chk_ShowMin" runat="server" Width="237px" AutoPostBack="True" Text="Show Minimum" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 68px">
									<p>
										<asp:button id="ButtonRandom" runat="server" Text="Generate Random Data" width="177px" CommandArgument="5" onclick="Button1_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
