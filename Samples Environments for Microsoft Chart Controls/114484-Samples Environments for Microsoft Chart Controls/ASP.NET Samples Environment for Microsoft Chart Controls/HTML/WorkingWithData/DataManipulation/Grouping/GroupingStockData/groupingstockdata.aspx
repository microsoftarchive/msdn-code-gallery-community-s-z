<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.GroupingDates" CodeFile="GroupingStockData.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>GroupingDates</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to group&nbsp;stock Hi-Low-Open-Close 
				prices using date intervals.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Palette="BrightPastel" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="WhiteSmoke" Width="500px" Height="296px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series YValuesPerPoint="4" XValueType="DateTime" Name="StockPrice" ChartType="Stock" BorderColor="180, 26, 59, 105" Color="26, 59, 105"></asp:Series>
<asp:Series BorderWidth="2" YValuesPerPoint="4" ChartArea="GroupedData" XValueType="DateTime" Name="GroupedStockPrice" ChartType="Stock" BorderColor="180, 26, 59, 105" Color="224, 64, 10"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="MMM\'yy">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark size="2">
</majortickmark>

</axisx>
</asp:ChartArea>
<asp:ChartArea Name="GroupedData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="MMM\'yy">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark size="2">
</majortickmark>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td align="right">
									<asp:label id="Label2" runat="server">Stock Symbol:</asp:label></td>
								<td>
									<asp:dropdownlist id="StockSymbolList" runat="server" AutoPostBack="True" width="74px" onselectedindexchanged="StockSymbolList_SelectedIndexChanged">
										<asp:listitem Value="ABC" Selected="True">ABC</asp:listitem>
										<asp:listitem Value="JIGY">JIGY</asp:listitem>
										<asp:listitem Value="EJIT">EJIT</asp:listitem>
										<asp:listitem Value="LUKY">LUKY</asp:listitem>
										<asp:listitem Value="OLDG">OLDG</asp:listitem>
										<asp:listitem Value="BLL">BLL</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right">
									<asp:label id="Label1" runat="server">Grouping Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="GroupingTypeList" runat="server" AutoPostBack="True" onselectedindexchanged="GroupingTypeList_SelectedIndexChanged">
										<asp:listitem Value="Week" Selected="True">Week</asp:listitem>
										<asp:listitem Value="Month">Month</asp:listitem>
										<asp:listitem Value="Quarter">Quarter</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The upper&nbsp;chart area displays the original data. The lower chart area displays the 
				same data that is grouped&nbsp;by week, month or quarter.&nbsp;Note that 
				different formulas are used for grouping Y, Y2, Y3, and Y4 values of the data 
				points.&nbsp;</p>
            <p class="dscr">This sample also uses data binding.</p>
			<p>
			</p>
		</form>
	</body>
</html>
