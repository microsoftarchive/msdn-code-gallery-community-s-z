
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BoxPlotChart" CodeFile="BoxPlotChart.aspx.cs" %>
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
			<p class="dscr"> This sample demonstrates how to use a Box Plot chart.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="460" class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="460px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" BorderWidth="2">
							<titles>
								<asp:title Font="Trebuchet MS, 10pt, style=Bold" DockedToChartArea="Data Chart Area" Text="Data Series" DockingOffset="-8">
									<position y="6" height="5.813029" width="48.49561" x="10"></position>
								</asp:title>
								<asp:title Font="Trebuchet MS, 10pt, style=Bold" DockedToChartArea="Box Chart Area" Text="Data Distribution" DockingOffset="-7" Alignment="MiddleLeft">
									<position y="6" height="5.813029" width="29.7426" x="69.30817"></position>
								</asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" Name="Default"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series MarkerSize="8" ChartArea="Data Chart Area" Name="DataSeries" ChartType="Point" ShadowColor="64, 64, 64" BorderColor="64, 64, 64" ShadowOffset="1"></asp:series>
								<asp:series YValuesPerPoint="6" BackSecondaryColor="130, 224, 64, 10" ChartArea="Box Chart Area" BackGradientStyle="VerticalCenter" Name="BoxPlotSeries" ChartType="BoxPlot" CustomProperties="PointWidth=1.2, BoxPlotSeries=DataSeries" Color="224, 64, 10" BorderColor="64, 64, 64" ></asp:series>
								<asp:series ChartArea="Box Chart Area" Name="BoxPlotLabels" ChartType="Point" CustomProperties="LabelStyle=Right" Font="Microsoft Sans Serif, 7pt" >
									<SmartLabelStyle Enabled="false" />
									<points>
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
										<asp:datapoint Color="Transparent" XValue="2" YValues="0" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Data Chart Area" BorderColor="64, 64, 64" BackColor="WhiteSmoke">
									<position y="12" height="82" width="60" x="2"></position>
									<axisy linecolor="64, 64, 64" maximum="100" minimum="0">
										<majorgrid LineDashStyle="Dash" linecolor="Gray" />
									</axisy>
									<axisx linecolor="64, 64, 64">
										<majorgrid LineDashStyle="Dash" linecolor="Gray" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="Box Chart Area" BorderColor="" BackColor="Transparent" AlignWithChartArea="Data Chart Area" AlignmentOrientation="Horizontal">
									<position y="12" height="82" width="39" x="61"></position>
									<axisy linecolor="64, 64, 64" maximum="100" minimum="0">
										<majorgrid enabled="False" />
									</axisy>
									<axisx linecolor="64, 64, 64" enabled="False" Minimum="0" Maximum="8">
										<majorgrid enabled="False" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top" style="WIDTH: 294px">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2">
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Whiskers Percentiles:</td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="WhiskerPercentileList" runat="server" AutoPostBack="True" Width="194px">
										<asp:listitem Value="15">15/85th Percentile</asp:listitem>
										<asp:listitem Value="10" Selected="True">10/90th Percentile</asp:listitem>
										<asp:listitem Value="5">5/95th Percentile</asp:listitem>
										<asp:listitem Value="0">0/100th Percentile (Min/Max)</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckBoxShowAverage" runat="server" AutoPostBack="True" Text="Show Average Line" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckboxShowMedian" runat="server" AutoPostBack="True" Text="Show Median Line" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="CheckboxShowUnusual" runat="server" AutoPostBack="True" Text="Show Unusual Points" Checked="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->The box 
and its whiskers can use different percentiles of the data series. 
Unusual data points, median and average lines can also be shown or hidden.</p>
		</form>
	</body>
</html>
