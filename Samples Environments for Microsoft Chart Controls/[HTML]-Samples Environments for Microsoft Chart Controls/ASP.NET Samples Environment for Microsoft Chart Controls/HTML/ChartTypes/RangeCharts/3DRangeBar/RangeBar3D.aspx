
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RangeBar3D" CodeFile="RangeBar3D.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Range Bar Chart</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates a 3D Range Bar chart.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="3D Range Bar Chart" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center">
									<CustomItems>
										<asp:LegendItem Name="Completed" Color="Red"></asp:LegendItem>
										<asp:LegendItem Name="Late" Color="Gray"></asp:LegendItem>
									</CustomItems>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="2" ChartArea="ChartArea1" Name="Estimated" ChartType="RangeBar" CustomProperties="DrawSideBySide=True" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="DateTime"></asp:Series>
								<asp:Series YValuesPerPoint="2" ChartArea="ChartArea1" Name="Actual" ChartType="RangeBar" CustomProperties="PointWidth=0.3, DrawSideBySide=True" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="DateTime"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle Rotation="10" Enable3D="True" Inclination="15" PointDepth="200" IsRightAngleAxes="False" WallWidth="0" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="dd MMM" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Rotate X:</td>
								<td><asp:dropdownlist id="RotateX" runat="server" AutoPostBack="True">
										<asp:ListItem Value="-30">-30</asp:ListItem>
										<asp:ListItem Value="-20">-20</asp:ListItem>
										<asp:ListItem Value="-10">-10</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
										<asp:ListItem Value="40">40</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Rotate Y:</td>
								<td><asp:dropdownlist id="RotateY" runat="server" AutoPostBack="True">
										<asp:ListItem Value="-30">-30</asp:ListItem>
										<asp:ListItem Value="-20">-20</asp:ListItem>
										<asp:ListItem Value="-10">-10</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
										<asp:ListItem Value="40">40</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
