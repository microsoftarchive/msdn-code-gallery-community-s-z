
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LineCurvesChart" CodeFile="LineCurvesChart.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates the Line, Spline and, 
				StepLine chart types.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" width="412"><asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="#F3DFC1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="8" BorderWidth="3" XValueType="Double" Name="Series1" ChartType="Line" MarkerStyle="Circle" ShadowColor="Black" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="2" YValueType="Double"></asp:Series>
								<asp:Series MarkerSize="9" BorderWidth="3" XValueType="Double" Name="Series2" ChartType="Line" MarkerStyle="Diamond" ShadowColor="Black" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" ShadowOffset="2" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="25" Perspective="9" LightStyle="Realistic" Inclination="40" IsRightAngleAxes="False" WallWidth="3" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Chart Type:</td>
								<td><asp:dropdownlist id="ChartTypeList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="Line" Selected="True">Line</asp:ListItem>
										<asp:ListItem Value="Spline">Spline</asp:ListItem>
										<asp:ListItem Value="StepLine">StepLine</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Point Labels:</td>
								<td><asp:dropdownlist id="PointLabelsList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
										<asp:ListItem Value="Auto">Auto</asp:ListItem>
										<asp:ListItem Value="TopLeft">TopLeft</asp:ListItem>
										<asp:ListItem Value="Top">Top</asp:ListItem>
										<asp:ListItem Value="TopRight">TopRight</asp:ListItem>
										<asp:ListItem Value="Right">Right</asp:ListItem>
										<asp:ListItem Value="BottomRight">BottomRight</asp:ListItem>
										<asp:ListItem Value="Bottom">Bottom</asp:ListItem>
										<asp:ListItem Value="BottomLeft">BottomLeft</asp:ListItem>
										<asp:ListItem Value="Left">Left</asp:ListItem>
										<asp:ListItem Value="Center">Center</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" Text="" AutoPostBack="True" Checked="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="checkBoxShow3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->The 
label style can be set using the LabelStyle custom attribute, and the ShowMarkers 
custom attribute is used to display data point markers when the chart area is 
set to 3D.</p>
		</form>
	</body>
</html>
