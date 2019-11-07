
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.TechnicalPriceIndicators" CodeFile="TechnicalPriceIndicators.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>WebForm1</title>
		<%this.AfterLoad();%>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates&nbsp;the various technical price 
				indicators.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<legends>
<asp:Legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="Indicator" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series YValuesPerPoint="4" Name="Input" ChartType="Stock" BorderColor="180, 26, 59, 105" Color="26, 59, 105"></asp:Series>
<asp:Series ChartArea="Indicator" XValueType="DateTime" MarkerStep="10" Name="Indicators" ChartType="Line" BorderColor="180, 26, 59, 105" Color="224, 64, 10" ShadowOffset="1"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="White" ShadowColor="Transparent">
<innerplotposition height="96.45609" width="85.8878" x="8.242199">
</InnerPlotPosition>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="7" height="40" width="89.43796" x="4.824818">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" enabled="False">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark linecolor="64, 64, 64, 64">
</majortickmark>

</axisx>
</asp:ChartArea>
<asp:ChartArea Name="Indicator" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="White" ShadowColor="Transparent" AlignWithChartArea="ChartArea1">
<innerplotposition height="83.51225" width="85.8878" x="8.242199">
</InnerPlotPosition>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="46" height="40" width="89.43796" x="4.824818">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="MMM dd">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48" style="WIDTH: 111px">Formula:</td>
								<td>
									<asp:dropdownlist id="FormulaName" runat="server" AutoPostBack="True">
										<asp:listitem Value="AverageTrueRange" Selected="True">Average True Range</asp:listitem>
										<asp:listitem Value="CommodityChannelIndex">Commodity Channel Index</asp:listitem>
										<asp:listitem Value="DetrendedPriceOscillator">Detrended Price Oscillator</asp:listitem>
										<asp:listitem Value="MassIndex">Mass Index</asp:listitem>
										<asp:listitem Value="MovingAverageConvergenceDivergence">MACD</asp:listitem>
										<asp:listitem Value="Performance">Performance</asp:listitem>
										<asp:listitem Value="RateOfChange">Rate of Change</asp:listitem>
										<asp:listitem Value="RelativeStrengthIndex">Relative Strength Index</asp:listitem>
										<asp:listitem Value="StandardDeviation">Standard Deviation</asp:listitem>
										<asp:listitem Value="StochasticIndicator">Stochastic Indicator</asp:listitem>
										<asp:listitem Value="TripleExponentialMovingAverage">TRIX</asp:listitem>
										<asp:listitem Value="VolatilityChaikins">Volatility Chaikins</asp:listitem>
										<asp:listitem Value="WilliamsR">William's %R</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48" style="WIDTH: 111px">Period:</td>
								<td>
									<asp:dropdownlist id="NumberOfDays" runat="server" AutoPostBack="True">
										<asp:listitem Value="200" Selected="True">200 days</asp:listitem>
										<asp:listitem Value="150">150 days</asp:listitem>
										<asp:listitem Value="100">100 days</asp:listitem>
										<asp:listitem Value="75">75 days</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48" style="WIDTH: 111px"></td>
								<td>
									<p>
										<asp:button id="Random3" runat="server" Text="Random" CommandArgument="5" onclick="Random_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>&nbsp;</p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
