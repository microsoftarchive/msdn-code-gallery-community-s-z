
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CovarianceAndCorrelation" CodeFile="CovarianceAndCorrelation.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>CustomSortingOrder</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="CustomSortingOrder" method="post" runat="server">
			<p class="dscr">This sample demonstrates the covariance and correlation formulas of a line and 
				point chart.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" Palette="BrightPastel" BorderColor="181, 64, 1" BorderWidth="2">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold">
									<position y="87" height="8.118644" width="22.2338" x="16"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series BorderWidth="2" LegendText="Line" ChartArea="ChartArea1" Name="Result" ChartType="Line" BorderColor="180, 26, 59, 105" Color="224, 64, 10" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:series>
								<asp:series MarkerSize="8" YValuesPerPoint="3" LegendText="Point" Name="FirstGroup" ChartType="Point" CustomProperties="LabelStyle=Bottom" BorderColor="180, 26, 59, 105" Color="168, 65, 140, 240" ShadowOffset="2" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy titlefont="Trebuchet MS, 8.25pt" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="Y Variable">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="X Variable">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:table id="TableResults" runat="server" BackColor="WhiteSmoke" BorderColor="White" BorderDashStyle="Solid" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="1" width="200px">
<asp:TableRow>
<asp:TableCell Width="120px" HorizontalAlign="Right" Text="Covariance:"></asp:TableCell>
<asp:TableCell HorizontalAlign="Left" Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="Correlation:"></asp:TableCell>
<asp:TableCell HorizontalAlign="Left" Text="0"></asp:TableCell>
</asp:TableRow>
										</asp:table></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:button id="Button1" runat="server" Width="125px" Text="Random Data" CommandArgument="6" onclick="Button1_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
