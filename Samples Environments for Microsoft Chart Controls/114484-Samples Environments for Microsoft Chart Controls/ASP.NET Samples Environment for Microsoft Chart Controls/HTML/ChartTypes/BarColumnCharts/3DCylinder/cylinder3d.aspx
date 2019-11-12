
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Cylinder3D" CodeFile="Cylinder3D.aspx.cs" %>
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
			<p class="dscr">
				This sample demonstrates how to display 3D Bar and Column charts as cylinders. 
				Cylinders may be applied to an entire data series or to specific points within 
				a series.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderWidth="2" Palette="BrightPastel" BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderColor="26, 59, 105" BorderlineDashStyle="Solid">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="3D Cylinder" ForeColor="26, 59, 105"></asp:Title>
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
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="8.5" />
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
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series3" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10">
									<points>
										<asp:DataPoint YValues="4" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="1" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="5" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle PointGapDepth="0" Rotation="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">3D Column Cylinder:</td>
								<td><asp:radiobutton id="Column" runat="server" Checked="True" AutoPostBack="True" Text="" GroupName="ChartType"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">3D Bar Cylinder:</td>
								<td><asp:radiobutton id="Bar" runat="server" AutoPostBack="True" Text="" GroupName="ChartType"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Clustered:</td>
								<td><asp:checkbox id="Clustered" runat="server" Checked="True" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Point Depth:</td>
								<td><asp:dropdownlist id="pointDepth" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="50">50</asp:ListItem>
										<asp:ListItem Value="100" Selected="True">100</asp:ListItem>
										<asp:ListItem Value="200">200</asp:ListItem>
										<asp:ListItem Value="300">300</asp:ListItem>
										<asp:ListItem Value="500">500</asp:ListItem>
										<asp:ListItem Value="700">700</asp:ListItem>
										<asp:ListItem Value="1000">1000</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Gap Depth:</td>
								<td><asp:dropdownlist id="gapDepth" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="50">50</asp:ListItem>
										<asp:ListItem Value="100" Selected="True">100</asp:ListItem>
										<asp:ListItem Value="200">200</asp:ListItem>
										<asp:ListItem Value="300">300</asp:ListItem>
										<asp:ListItem Value="500">500</asp:ListItem>
										<asp:ListItem Value="700">700</asp:ListItem>
										<asp:ListItem Value="1000">1000</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
