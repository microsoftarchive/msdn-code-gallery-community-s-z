
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CustomizeEvent" CodeFile="Customize event.aspx.cs" %>
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
				This sample demonstrates how to modify the automatically calculated properties 
				using the Customize event.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" BorderWidth="2">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="7" BorderWidth="3" ChartArea="ChartArea1" XValueType="Double" Name="Series1" ChartType="Line" MarkerStyle="Square" BorderColor="180, 26, 59, 105" ShadowOffset="1" YValueType="Double">
									<points>
										<asp:DataPoint YValues="30" />
										<asp:DataPoint YValues="90" />
										<asp:DataPoint YValues="60" />
										<asp:DataPoint YValues="40" />
										<asp:DataPoint YValues="40" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<AxisY LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</AxisY>
									<AxisX LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</AxisX>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2">Increase the maximum axis value and decrease the 
									automatic mininum axis value by the specified amounts:</td>
							</tr>
							<tr>
								&nbsp;
							</tr>
							<tr>
								<td class="label">X Axis:</td>
								<td><asp:DropDownList id="XAxis" runat="server" AutoPostBack="True">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Y Axis:</td>
								<td><asp:DropDownList id="YAxis" runat="server" AutoPostBack="True">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="40" Selected="True">40</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				The Minimum and Maximum properties in the Axis objects, by default, are set to "Auto".&nbsp; 
                Just before the chart is painted, the Chart control automatically calculates the 
				values of Maximum and Minimum properties depending on the series data. When the Customize
				event is triggered, all properties are already calculated specified explicitly.</p>
		</form>
		<p/>
	</body>
</html>
