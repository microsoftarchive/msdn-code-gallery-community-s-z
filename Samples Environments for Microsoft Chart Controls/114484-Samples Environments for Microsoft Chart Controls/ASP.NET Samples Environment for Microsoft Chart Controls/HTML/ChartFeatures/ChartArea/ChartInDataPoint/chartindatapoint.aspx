
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartInDataPoint" CodeFile="ChartInDataPoint.aspx.cs" %>
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
				This sample demonstrates how to create a mini-chart for every point on the 
				original chart.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BackColor="WhiteSmoke" BorderColor="26, 59, 105">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Mini-Charts" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="22" YValuesPerPoint="2" Name="Default" ChartType="Point" CustomProperties="BubbleScaleMin=-60" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="2">
									<points>
										<asp:DataPoint YValues="9,20" />
										<asp:DataPoint YValues="2,30" />
										<asp:DataPoint YValues="5,50" />
										<asp:DataPoint YValues="7,5" />
										<asp:DataPoint YValues="4,60" />
										<asp:DataPoint YValues="2,25" />
										<asp:DataPoint YValues="6,50" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
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
								<td class="label">In Point Chart Type:</td>
								<td><asp:dropdownlist id="Series2" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Column" Selected="True">Column</asp:ListItem>
										<asp:ListItem Value="Pie">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut">Doughnut</asp:ListItem>
										<asp:ListItem Value="Area">Area</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Original Chart Type:</td>
								<td><asp:dropdownlist id="Series1" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Bubble">Bubble</asp:ListItem>
										<asp:ListItem Value="Point" Selected="True">Point</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Hide Original Series:</td>
								<td><asp:checkbox id="CheckBoxHideOriginal" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="Show3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">In this example, a separate chart area is created for each data point and then 
				positioned on top of the original data point.</p>
		</form>
	</body>
</html>
