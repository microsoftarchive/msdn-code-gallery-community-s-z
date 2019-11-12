<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CombinatorialChart" CodeFile="CombinatorialChart.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>CombinatorialChart</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to combine different chart types in one plot 
				area and how to display a chart area in 3D.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BackColor="#D3DFF0" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Combination Charts" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="10" Name="Series1" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
								<asp:Series MarkerSize="10" Name="Series2" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65"></asp:Series>
								<asp:Series MarkerSize="10" Name="Series3" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">Series 1 Type:</td>
								<td><asp:dropdownlist id="Series1TypeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="&quot;Column&quot;&quot;">Column</asp:ListItem>
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Spline">Spline</asp:ListItem>
										<asp:ListItem Value="StepLine">StepLine</asp:ListItem>
										<asp:ListItem Value="Area">Area</asp:ListItem>
										<asp:ListItem Value="SplineArea">SplineArea</asp:ListItem>
										<asp:ListItem Value="Point">Point</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Series 2 Type:</td>
								<td>
									<asp:DropDownList id="Series2TypeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="&quot;Column&quot;&quot;">Column</asp:ListItem>
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Spline" Selected="True">Spline</asp:ListItem>
										<asp:ListItem Value="StepLine">StepLine</asp:ListItem>
										<asp:ListItem Value="Area">Area</asp:ListItem>
										<asp:ListItem Value="SplineArea">SplineArea</asp:ListItem>
										<asp:ListItem Value="Point">Point</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Series 3 Type:</td>
								<td><asp:dropdownlist id="Series3TypeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Spline">Spline</asp:ListItem>
										<asp:ListItem Value="StepLine">StepLine</asp:ListItem>
										<asp:ListItem Value="Area">Area</asp:ListItem>
										<asp:ListItem Value="SplineArea">SplineArea</asp:ListItem>
										<asp:ListItem Value="Point">Point</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:CheckBox id="Show3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
