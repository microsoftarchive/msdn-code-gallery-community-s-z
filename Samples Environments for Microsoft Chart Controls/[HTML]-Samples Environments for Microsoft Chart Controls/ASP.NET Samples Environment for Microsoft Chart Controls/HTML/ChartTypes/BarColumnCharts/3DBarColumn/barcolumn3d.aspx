<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BarColumn3D" CodeFile="BarColumn3D.aspx.cs" %>

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
			<p class="dscr"> This sample demonstrates 3D Column and Bar charts. It also shows 
				chart area rotation and isometric projection,&nbsp;as well as clustering of&nbsp;series.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="3D Bar and Column charts." ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" Name="Series1" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="9" />
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="7.5" />
										<asp:DataPoint YValues="5.69999980926514" />
										<asp:DataPoint YValues="3.20000004768372" />
										<asp:DataPoint YValues="8.5" />
										<asp:DataPoint YValues="7.5" />
										<asp:DataPoint YValues="6.5" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series2" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65">
									<points>
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="9" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="6" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series3" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10">
									<points>
										<asp:DataPoint YValues="4" />
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="1" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="1" />
										<asp:DataPoint YValues="2" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">Column:</td>
								<td><asp:radiobutton id="Column" runat="server" Checked="True" AutoPostBack="True" Text="" GroupName="ChartType"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Bar:</td>
								<td><asp:radiobutton id="Bar" runat="server" AutoPostBack="True" Text="" GroupName="ChartType"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Point Width:</td>
								<td><asp:dropdownlist id="BarWidthList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Show X Axis End Labels:</td>
								<td><asp:checkbox id="IsEndLabelVisible" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Right Angle Axis:</td>
								<td><asp:checkbox id="RightAngledAxis" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Clustered:</td>
								<td><asp:checkbox id="Clustered" runat="server" Checked="True" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Rotate X:</td>
								<td><asp:dropdownlist id="RotateX" runat="server" AutoPostBack="True" CssClass="spaceright">
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
							<tr>
								<td class="label">Rotate Y:</td>
								<td><asp:dropdownlist id="RotateY" runat="server" AutoPostBack="True" CssClass="spaceright">
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
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
