
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LineCurves3D" CodeFile="LineCurves3D.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates Line, Spline and StepLine chart 
				types with 3D enabled. The label style and the display of data point marker lines can be set 
				using custom attributes.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Series1" ChartType="Line" BorderColor="180, 26, 59, 105" YValueType="Double"></asp:Series>
								<asp:Series XValueType="Double" Name="Series2" ChartType="Line" BorderColor="180, 26, 59, 105" YValueType="Double"></asp:Series>
								<asp:Series XValueType="Double" Name="Series3" ChartType="Line" BorderColor="180, 26, 59, 105" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="9" Perspective="10" Enable3D="True" LightStyle="Realistic" Inclination="38" PointDepth="200" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="2" Height="94" Width="94" X="2"></position>
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
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Chart Type:</td>
								<td><asp:DropDownList id="ChartTypeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Spline" Selected="True">Spline</asp:ListItem>
										<asp:ListItem Value="StepLine">StepLine</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Point Labels:</td>
								<td>
									<asp:dropdownlist id="PointLabelsList" runat="server" AutoPostBack="True" CssClass="spaceright">
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
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" Text="" AutoPostBack="True" Checked="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show Markers Lines:</td>
								<td><asp:CheckBox id="ShowMarkers" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
