
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ErrorBarChart" CodeFile="ErrorBarChart.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>PieChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="PieChart" method="post" runat="server">
			<p class="dscr"> This sample shows how to use the Error Bar chart to display error bars 
				for data series using different error calculation methods.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" Palette="BrightPastel" BorderColor="26, 59, 105" BackColor="#D3DFF0" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="DataSeries" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series MarkerBorderColor="64, 64, 64" MarkerSize="6" YValuesPerPoint="3" Name="ErrorBar" ChartType="ErrorBar" BorderColor="180, 26, 59, 105" Color="252, 180, 65" ShadowOffset="1"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
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
								<td class="label">Error Calculation:</td>
								<td><asp:DropDownList id="ErrorCalculationList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="StandardError" Selected="True">StandardError</asp:ListItem>
										<asp:ListItem Value="StandardDeviation">StandardDeviation</asp:ListItem>
										<asp:ListItem Value="Percentage(15)">Percentage - 15%</asp:ListItem>
										<asp:ListItem Value="FixedValue(10)">FixedValue - 10</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Error Style:</td>
								<td><asp:DropDownList id="ErrorStyleList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="Both" Selected="True">Upper&Lower Errors</asp:ListItem>
										<asp:ListItem Value="UpperError">UpperError</asp:ListItem>
										<asp:ListItem Value="LowerError">LowerError</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Markers Style:</td>
								<td><asp:DropDownList id="MarkersStyleList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Line" Selected="True">Line</asp:ListItem>
										<asp:ListItem Value="Square">Square</asp:ListItem>
										<asp:ListItem Value="Circle">Circle</asp:ListItem>
										<asp:ListItem Value="Diamond">Diamond</asp:ListItem>
										<asp:ListItem Value="Triangle">Triangle</asp:ListItem>
										<asp:ListItem Value="Cross">Cross</asp:ListItem>
										<asp:ListItem Value="Star4">Star4</asp:ListItem>
										<asp:ListItem Value="Star5">Star5</asp:ListItem>
										<asp:ListItem Value="Star6">Star6</asp:ListItem>
										<asp:ListItem Value="Star10">Star10</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Center Marker Style:</td>
								<td><asp:DropDownList id="CenterMarkerStyleList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Square">Square</asp:ListItem>
										<asp:ListItem Value="Circle">Circle</asp:ListItem>
										<asp:ListItem Value="Diamond">Diamond</asp:ListItem>
										<asp:ListItem Value="Triangle">Triangle</asp:ListItem>
										<asp:ListItem Value="Cross">Cross</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->Error 
                bars are used to display statistical information about the chart 
data.</p>
		</form>
	</body>
</html>
