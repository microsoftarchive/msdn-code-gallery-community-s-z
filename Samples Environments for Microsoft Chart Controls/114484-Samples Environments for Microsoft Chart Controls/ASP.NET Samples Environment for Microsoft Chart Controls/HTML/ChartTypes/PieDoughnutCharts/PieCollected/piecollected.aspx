
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PieCollected" CodeFile="PieCollected.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to group many small segments of a pie 
				or doughnut chart into one collected slice to improve chart readability.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Height="296px" Width="412px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" IsSoftShadows="False" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" IsEquallySpacedItems="True" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="Area1" XValueType="Double" Name="Series1" ChartType="Pie" Font="Trebuchet MS, 8.25pt, style=Bold" CustomProperties="DoughnutRadius=25, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelativePieSize=20" MarkerStyle="Circle" BorderColor="64, 64, 64, 64" Color="180, 65, 140, 240" YValueType="Double" Label="#PERCENT{P1}">
									<points>
										<asp:DataPoint LegendText="RUS" CustomProperties="OriginalPointIndex=0" YValues="39" />
										<asp:DataPoint LegendText="CAN" CustomProperties="OriginalPointIndex=1" YValues="18" />
										<asp:DataPoint LegendText="USA" CustomProperties="OriginalPointIndex=2" YValues="15" />
										<asp:DataPoint LegendText="PRC" CustomProperties="OriginalPointIndex=3" YValues="12" />
										<asp:DataPoint LegendText="DEN" CustomProperties="OriginalPointIndex=5" YValues="8" />
										<asp:DataPoint LegendText="AUS" YValues="4.5" />
										<asp:DataPoint LegendText="IND" CustomProperties="OriginalPointIndex=4" YValues="3.20000004768372" />
										<asp:DataPoint LegendText="ARG" YValues="2" />
										<asp:DataPoint LegendText="FRA" YValues="1" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Area1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy2>
									<axisx2>
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx2>
									<area3dstyle PointGapDepth="900" Rotation="162" IsRightAngleAxes="False" WallWidth="25" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 181px">
									<p>Collect Pie Slices:</p>
								</td>
								<td>
									<asp:checkbox id="chk_Pie" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 29px">Collected Threshold (in %):</td>
								<td>
									<asp:dropdownlist id="comboBoxCollectedThreshold" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
										<asp:ListItem Value="15">15</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">Collected Color:</td>
								<td><asp:dropdownlist id="comboBoxCollectedColor" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Gray">Gray</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Gold">Gold</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px">Collected Label:</td>
								<td>
									<asp:TextBox id="textBoxCollectedLabel" runat="server" Width="120px" CssClass="spaceright" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 16px">Collected Legend Text:</td>
								<td style="HEIGHT: 16px">
									<asp:TextBox id="textBoxCollectedLegend" runat="server" CssClass="spaceright" Width="120px" AutoPostBack="True" MaxLength="10"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 181px; HEIGHT: 20px">Show Exploded:</td>
								<td style="HEIGHT: 20px"><asp:checkbox id="ShowExplode" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<TD class="label" style="WIDTH: 181px">Chart Type:</td>
								<td>
									<asp:dropdownlist id="comboBoxChartType" runat="server" CssClass="spaceright" AutoPostBack="True" Width="120px">
										<asp:ListItem Value="Pie" Selected="True">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
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
