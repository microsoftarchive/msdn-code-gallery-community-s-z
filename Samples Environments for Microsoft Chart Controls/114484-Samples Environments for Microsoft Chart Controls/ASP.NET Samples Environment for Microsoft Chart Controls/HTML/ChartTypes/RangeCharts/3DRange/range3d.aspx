<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Range3D" CodeFile="Range3D.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>RangeChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="RangeChart" method="post" runat="server">
			<p class="dscr">This sample demonstrates Range and Spline Range chart types. The 
                Spline Range chart supports line tension adjustment.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BackColor="WhiteSmoke" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="2" XValueType="Double" Name="Series1" ChartType="SplineRange" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double"></asp:Series>
								<asp:Series YValuesPerPoint="2" XValueType="Double" Name="Series2" ChartType="SplineRange" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle Rotation="29" Enable3D="True" LightStyle="Realistic" Inclination="32" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="2" Height="96" Width="99"></position>
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx IsMarginVisible="False" LineColor="64, 64, 64, 64">
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
										<asp:ListItem Value="SplineRange" Selected="True">Spline Range</asp:ListItem>
										<asp:ListItem Value="Range">Range</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td class="label">Spline Tension:</td>
								<td><asp:DropDownList id="LineTensionList" runat="server" Width="50px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="1.2">1.2</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
										<asp:ListItem Value="0.2">0.2</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show Markers Lines:</td>
								<td><asp:CheckBox id="ShowMarkers" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">&nbsp;</p>
		</form>
	</body>
</html>
