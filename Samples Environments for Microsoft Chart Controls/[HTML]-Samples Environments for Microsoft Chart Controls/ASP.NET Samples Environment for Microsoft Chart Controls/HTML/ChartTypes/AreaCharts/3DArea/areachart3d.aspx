<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AreaChart3D" CodeFile="AreaChart3D.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates 3D Area and Spline Area charts. The X axis 
				margin and data point marker lines can be toggled on and off, and the lighting can 
				also be modified.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="2" ChartArea="ChartArea1" XValueType="Double" Name="Series1" ChartType="Area" CustomProperties="ShowMarkerLines=true" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double">
									<points>
										<asp:DataPoint YValues="5,0" />
										<asp:DataPoint YValues="8.10000038146973,0" />
										<asp:DataPoint YValues="9,0" />
										<asp:DataPoint YValues="7,0" />
										<asp:DataPoint YValues="5,0" />
										<asp:DataPoint YValues="5.5,0" />
										<asp:DataPoint YValues="7.80000019073486,0" />
										<asp:DataPoint YValues="7,0" />
										<asp:DataPoint YValues="8.5,0" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" XValueType="Double" Name="Series2" ChartType="Area" CustomProperties="ShowMarkerLines=true" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="Double">
									<points>
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="4" />
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="3.5" />
										<asp:DataPoint YValues="4" />
										<asp:DataPoint YValues="5.5" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="2" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle Rotation="20" Perspective="10" Enable3D="True" Inclination="28" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">Area:</td>
								<td><asp:radiobutton id="Area" runat="server" GroupName="ChartType" Text="" AutoPostBack="True"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Spline Area:</td>
								<td><asp:radiobutton id="SplineArea" runat="server" GroupName="ChartType" Text="" AutoPostBack="True" Checked="True"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Spline Tension:</td>
								<td><asp:DropDownList id="LineTensionList" runat="server" Width="50px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="1.2">1.2</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
										<asp:ListItem Value="0.2">0.2</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show Markers Lines:</td>
								<td><asp:CheckBox id="ShowMarkers" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Lighting:</td>
								<td><asp:DropDownList id="LightingType" runat="server" Width="93px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Simplistic">Simplistic</asp:ListItem>
										<asp:ListItem Value="Realistic" Selected="True">Realistic</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
