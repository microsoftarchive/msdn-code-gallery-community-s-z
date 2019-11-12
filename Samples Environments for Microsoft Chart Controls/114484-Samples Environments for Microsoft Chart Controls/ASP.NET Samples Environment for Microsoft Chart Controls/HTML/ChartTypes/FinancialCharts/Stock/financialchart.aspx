<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FinancialChart" CodeFile="FinancialChart.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>FinancialChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates the Stock and CandleStick chart types.</p>
			<table class="sampleTable">
				<tr>
					<td width="460" class="tdchart">
						<asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" Width="460px" Height="330px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" enableviewstate="True" viewstatecontent="All">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="Price" Docking="Top" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
									<position y="5" height="7.127659" width="38.19123" x="55"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series YValuesPerPoint="4" ChartArea="Price" XValueType="DateTime" IsVisibleInLegend="False" Name="Price" ChartType="Stock" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series ChartArea="Volume" XValueType="DateTime" IsVisibleInLegend="False" Name="Volume" Color="224, 64, 10" BorderColor="180, 26, 59, 105"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Price" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="10" height="42" width="88" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="Volume" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" AlignWithChartArea="Price" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="51.84195" height="42" width="88" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Chart Type:</td>
								<td><asp:dropdownlist id="ChartTypeList" runat="server" AutoPostBack="True" Width="101px" CssClass="spaceright">
										<asp:listitem Value="Stock" Selected="True">Stock</asp:listitem>
										<asp:listitem Value="CandleStick">CandleStick</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Open Close Marks:</td>
								<td><asp:dropdownlist id="OpenCloseMarks" runat="server" AutoPostBack="True" Width="100px" CssClass="spaceright">
										<asp:listitem Value="Line" Selected="True">Line</asp:listitem>
										<asp:listitem Value="Triangle">Triangle</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show Close Price Only:</td>
								<td><asp:checkbox id="ShowCloseOnly" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
