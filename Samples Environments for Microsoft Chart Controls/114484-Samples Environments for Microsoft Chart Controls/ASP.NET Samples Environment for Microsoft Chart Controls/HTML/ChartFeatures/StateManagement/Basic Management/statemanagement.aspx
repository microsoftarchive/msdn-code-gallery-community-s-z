
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.StateManagement" CodeFile="StateManagement.aspx.cs" %>
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
		<form id="SM" method="post" runat="server">
<p class="dscr">This sample demonstrates how to work with state management.</p>
			<table class="sampleTable" id="Table1">
				<tr>
					<td width="460" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="330px" Width="460px" 
                            ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" 
                            BackColor="#D3DFF0" BorderDashStyle="Solid" Palette="BrightPastel" 
                            BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" EnableViewState="true">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Basic State Management" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Top" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Input" ChartType="Line" BorderColor="180, 26, 59, 105" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4" id="Table2">
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp;<asp:button id="LoadData" runat="server" Text="Load Data" CommandArgument="5" onclick="LoadData_Click"></asp:button></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="EnableStateManagement" runat="server" Checked="True" Text="Enable State Management" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="SeriesAbove" runat="server" AutoPostBack="True" Text="Add Series Above"></asp:checkbox></td>
							</tr>
							<tr>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="SeriesBelow" runat="server" AutoPostBack="True" Text="Add Series Below"></asp:checkbox></td>
							</tr>
							<tr>
								<td>Right Click and Select "View Source" to<br/>
									see the persisted data. Notice that the<br/>
									dynamically created series are also<br/>
									persisted.</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
