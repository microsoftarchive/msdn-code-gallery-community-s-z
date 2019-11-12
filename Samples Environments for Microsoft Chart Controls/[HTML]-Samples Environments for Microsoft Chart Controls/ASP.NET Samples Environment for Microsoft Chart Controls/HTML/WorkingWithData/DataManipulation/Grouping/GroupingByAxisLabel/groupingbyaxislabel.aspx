<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.GroupingByAxisLabel" CodeFile="GroupingByAxisLabel.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>GroupingByAxisLabel</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates grouping series data by the axis label (by salesperson name). Different grouping&nbsp;formulas can be 
				specified for different results.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" Palette="BrightPastel" BorderColor="181, 64, 1" BorderWidth="2">
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Top" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold" Alignment="Far">
									<position Y="4" Height="7.653602" Width="49.60493" X="48.65784"></position>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="4" Name="Sales" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
								<asp:Series YValuesPerPoint="4" ChartArea="GroupedData" Name="Total by Person" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="9" Height="49" Width="89.43796" X="4.824818"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="1" IsStaggered="True" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
								<asp:ChartArea Name="GroupedData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" AlignWithChartArea="ChartArea1">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="55" Height="39" Width="89.43796" X="4.824818"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="1" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Grouping Formula:</asp:label></td>
								<td>
									<asp:dropdownlist id="GroupingFormulaList" runat="server" AutoPostBack="True" onselectedindexchanged="GroupingFormulaList_SelectedIndexChanged">
										<asp:listitem Value="SUM" Selected="True">Sum</asp:listitem>
										<asp:listitem Value="Max">Maximum</asp:listitem>
										<asp:listitem Value="Min">Minimum</asp:listitem>
										<asp:listitem Value="Ave">Average</asp:listitem>
										<asp:listitem Value="Count">Count</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
