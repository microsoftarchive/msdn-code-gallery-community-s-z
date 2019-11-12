
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Pie3D" CodeFile="Pie3D.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>PieChart</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="PieChart" method="post" runat="server">
			<p class="dscr">This sample demonstrates the Pie and Doughnut chart types in both 2D and 
                3D.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="WhiteSmoke" Height="296px" Width="412px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Pie Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
									<area3dstyle Rotation="0" />
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
								<td><asp:dropdownlist id="ChartTypeList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
										<asp:ListItem Value="Pie">Pie</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Label Style:</td>
								<td><asp:dropdownlist id="LabelStyleList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
										<asp:ListItem Value="Inside" Selected="True">Inside</asp:ListItem>
										<asp:ListItem Value="Outside">Outside</asp:ListItem>
										<asp:ListItem Value="Disabled">Disabled</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Exploded Point:</td>
								<td><asp:dropdownlist id="ExplodedPointList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
										<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
										<asp:ListItem Value="France">France</asp:ListItem>
										<asp:ListItem Value="Canada">Canada</asp:ListItem>
										<asp:ListItem Value="UK">UK</asp:ListItem>
										<asp:ListItem Value="USA">USA</asp:ListItem>
										<asp:ListItem Value="Italy">Italy</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Doughnut Radius (%):</td>
								<td><asp:dropdownlist id="HoleSizeList" runat="server" AutoPostBack="True" Enabled="False" CssClass="spaceright" Width="112px">
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="40">40</asp:ListItem>
										<asp:ListItem Value="50">50</asp:ListItem>
										<asp:ListItem Value="60" Selected="True">60</asp:ListItem>
										<asp:ListItem Value="70">70</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Show Legend:</td>
								<td><asp:checkbox id="ShowLegend" runat="server" AutoPostBack="True" Checked="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<TD class="label">Drawing Style:</td>
								<td>
									<asp:dropdownlist id="Dropdownlist1" runat="server" Width="112px" CssClass="spaceright" AutoPostBack="True">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="SoftEdge" Selected="True">SoftEdge</asp:ListItem>
										<asp:ListItem Value="Concave">Concave</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="CheckboxShow3D" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">&nbsp;</p>
		</form>
	</body>
</html>
