
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RadarChart" CodeFile="RadarChart.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>PieChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="PieChart" method="post" runat="server">
			<p class="dscr">This sample displays&nbsp;a Radar chart, which&nbsp;is a circular graph used 
				primarily as a comparison tool. A 3D effect can also be added to the area 
				background.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BackColor="#F3DFC1" BorderColor="181, 64, 1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Radar Chart" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
									<position y="74.08253" height="14.23021" width="19.34047" x="74.73474"></position>
								</asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="9" Name="Series1" ChartType="Radar" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="1"></asp:Series>
								<asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="9" Name="Series2" ChartType="Radar" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" ShadowOffset="1"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False" />
									<position y="15" height="78" width="88" x="5"></position>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark size="0.6" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Radar Style:</td>
								<td><asp:DropDownList id="RadarStyleList" runat="server" AutoPostBack="True" Width="100px" CssClass="spaceright">
										<asp:ListItem Value="Area" Selected="True">Area</asp:ListItem>
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Marker">Marker</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Area Drawing Style:</td>
								<td><asp:DropDownList id="AreaDrawingStyleList" runat="server" AutoPostBack="True" Width="100px" CssClass="spaceright">
										<asp:ListItem Value="Circle" Selected="True">Circle</asp:ListItem>
										<asp:ListItem Value="Polygon">Polygon</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Labels Style:</td>
								<td><asp:DropDownList id="LabelStyleList" runat="server" AutoPostBack="True" Width="100px" CssClass="spaceright">
										<asp:ListItem Value="Circular">Circular</asp:ListItem>
										<asp:ListItem Value="Radial">Radial</asp:ListItem>
										<asp:ListItem Value="Horizontal" Selected="True">Horizontal</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->Try 
different styles for the radar,&nbsp;plot area, and labels.</p>
		</form>
	</body>
</html>
