<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.VolumeIndicators" CodeFile="VolumeIndicators.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates&nbsp;various&nbsp;volume indicators.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="364px" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Top" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold" Alignment="Far">
									<position Y="2" Height="8.351166" Width="60" X="35"></position>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="4" Name="Input" ChartType="Stock" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
								<asp:Series ChartArea="Volume Area" XValueType="DateTime" Name="Volume" ChartType="Area" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65"></asp:Series>
								<asp:Series ChartArea="Indicator" XValueType="DateTime" Name="Indicators" ChartType="Line" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="10.5228" Height="24" Width="90" X="3"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Enabled="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
								<asp:ChartArea Name="Volume Area" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" AlignWithChartArea="ChartArea1">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="38.0689" Height="24" Width="90" X="3"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Enabled="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
								<asp:ChartArea Name="Indicator" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" AlignWithChartArea="ChartArea1">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="65.615" Height="29" Width="90" X="3"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Period:</td>
								<td>
									<asp:dropdownlist id="NumberOfDays" runat="server" AutoPostBack="True">
										<asp:listitem Value="75">75 days</asp:listitem>
										<asp:listitem Value="100">100 days</asp:listitem>
										<asp:listitem Value="150">150 days</asp:listitem>
										<asp:listitem Value="200">200 days</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Formula Name:</td>
								<td></td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 72px">
									<asp:dropdownlist id="FormulaName" runat="server" AutoPostBack="True">
										<asp:listitem Value="AccumulationDistribution" Selected="True">Accumulation Distribution</asp:listitem>
										<asp:listitem Value="ChaikinOscillator">Chaikin Oscillator </asp:listitem>
										<asp:listitem Value="EaseOfMovement">Ease of Movement </asp:listitem>
										<asp:listitem Value="MoneyFlow">Money Flow </asp:listitem>
										<asp:listitem Value="NegativeVolumeIndex">Negative Volume Index </asp:listitem>
										<asp:listitem Value="OnBalanceVolume">On Balance Volume </asp:listitem>
										<asp:listitem Value="PositiveVolumeIndex">Positive Volume Index</asp:listitem>
										<asp:listitem Value="PriceVolumeTrend">Price Volume Trend </asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 72px">
									<asp:button id="Random3" runat="server" Text="Random" CommandArgument="5" width="182px" onclick="Random3_Click"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
