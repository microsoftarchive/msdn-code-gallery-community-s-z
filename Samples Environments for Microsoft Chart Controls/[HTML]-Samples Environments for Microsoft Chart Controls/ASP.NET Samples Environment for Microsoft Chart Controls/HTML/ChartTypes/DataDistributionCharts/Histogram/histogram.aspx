
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Histogram" CodeFile="Histogram.aspx.cs" %>
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
			<p class="dscr">
				This sample 
				demonstrates how to create a histogram chart that uses a given number 
				of intervals.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:chart id="Chart1" runat="server" Width="412px" Height="296px" BackColor="#F3DFC1" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series MarkerSize="9" XValueType="Double" Name="RawData" ChartType="Point" BorderColor="180, 26, 59, 105" Color="120, 252, 180, 65" Font="Trebuchet MS, 8.25pt" Enabled="False" YValueType="Double"></asp:series>
								<asp:series MarkerSize="8" XValueType="Double" Name="DataDistribution" ChartType="Point" BorderColor="110, 26, 59, 105" Color="120, 252, 180, 65" Font="Trebuchet MS, 8.25pt" YValueType="Double"></asp:series>
								<asp:series IsValueShownAsLabel="True" ChartArea="HistogramArea" XValueType="Double" Name="Histogram" BorderColor="180, 26, 59, 105" Color="224, 64, 10" Font="Trebuchet MS, 8.25pt" YValueType="Double"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" AlignWithChartArea="HistogramArea" BackGradientStyle="TopBottom">
									<axisy2 IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="4" height="15" width="96" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsReversed="True" maximum="2" minimum="0">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" enabled="False" />
										<majorgrid linecolor="64, 64, 64, 64" enabled="False" />
										<majortickmark enabled="False" />
									</axisy>
									<axisx titlefont="Trebuchet MS, 8pt" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" enabled="True" title="One axis data distribution chart">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" enabled="False" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark size="1.5" linecolor="Transparent" enabled="False" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="HistogramArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="18" height="77" width="93" x="3"></position>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Trebuchet MS, 8pt" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="Histogram (Frequency Diagram)">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Number of Intervals:</td>
								<td><asp:dropdownlist id="CollectedPercentage" runat="server" AutoPostBack="True" Width="50px" CssClass="spaceright">
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="10" Selected="True">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show Percent Axis:</td>
								<td><asp:checkbox id="checkBoxPercent" tabIndex="6" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
