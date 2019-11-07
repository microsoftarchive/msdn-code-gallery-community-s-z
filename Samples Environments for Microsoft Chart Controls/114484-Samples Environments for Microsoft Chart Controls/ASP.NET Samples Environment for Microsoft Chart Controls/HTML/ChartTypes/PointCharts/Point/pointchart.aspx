
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PointChart" CodeFile="PointChart.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>PointChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample displays a Point chart. Try setting different 
				marker sizes, shapes and point label positions.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" Palette="BrightPastel" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="10" Name="Series1" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 9pt"></asp:Series>
								<asp:Series MarkerSize="10" Name="Series2" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 9pt"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
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
								<td class="label">Point Label Position:</td>
								<td><asp:dropdownlist id="PointLabelsList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
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
								<td class="label">Marker Shape:</td>
								<td><asp:DropDownList id="MarkerShapeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Circle &amp; Square" Selected="True">Circle &amp; Square</asp:ListItem>
										<asp:ListItem Value="Diamond &amp; Triangal">Diamond &amp; Triangle</asp:ListItem>
										<asp:ListItem Value="Cross &amp; Picture">Cross &amp; Picture</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Point Marker Size:</td>
								<td><asp:DropDownList id="MarkerSizeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="7" Selected="True">7</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="18">18</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="checkBoxShow3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
