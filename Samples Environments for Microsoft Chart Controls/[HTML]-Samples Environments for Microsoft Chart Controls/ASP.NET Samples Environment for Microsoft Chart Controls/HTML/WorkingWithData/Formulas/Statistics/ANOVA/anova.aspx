<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ANOVA" CodeFile="ANOVA.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to use the Analysis of Variance (ANOVA) 
                test.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" backcolor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="ANOVA Test" Name="Title1" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Center" DockedToChartArea="Chart Area 2" Docking="Left" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" IsDockedInsideChartArea="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="2" XValueType="Double" Name="Group1" CustomProperties="LabelStyle=&quot;down&quot;" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double"></asp:Series>
								<asp:Series YValuesPerPoint="2" ChartArea="Chart Area 2" XValueType="Double" Name="Group2" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="Double"></asp:Series>
								<asp:Series ChartArea="Chart Area 2" XValueType="Double" Name="Group3" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" YValueType="Double"></asp:Series>
								<asp:Series ChartArea="" XValueType="Double" Name="Result" BorderColor="180, 26, 59, 105" Color="220, 5, 100, 146" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<axisy2 IsLabelAutoFit="False"></axisy2>
									<axisx2 IsLabelAutoFit="False"></axisx2>
									<area3dstyle Rotation="40" Perspective="4" Enable3D="True" Inclination="41" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Maximum="20" Minimum="0" Interval="5">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Interval="1">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="1" IsEndLabelVisible="False" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									Probability:</td>
								<td>
									<asp:dropdownlist id="DropDownListProbability" runat="server" AutoPostBack="True" width="71px" onselectedindexchanged="DropDownListProbability_SelectedIndexChanged">
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="40">40</asp:listitem>
										<asp:listitem Value="60">60</asp:listitem>
										<asp:listitem Value="80">80</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
										<asp:listitem Value="95" Selected="True">95</asp:listitem>
										<asp:listitem Value="99">99</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:table id="TableResults" runat="server" CellSpacing="1" CellPadding="0" GridLines="Both" BorderWidth="1px" BorderDashStyle="Solid" BorderColor="White" BackColor="WhiteSmoke" font-names="Tahoma" font-size="8pt">
										<asp:tablerow>
											<asp:tablecell HorizontalAlign="Center" Wrap="False" Text="Source of Variation"></asp:tablecell>
											<asp:tablecell Width="56px" HorizontalAlign="Center" Text="Sum. of Squares"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="Degree of Freedom"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="Mean Square Variance"></asp:tablecell>
										</asp:tablerow>
										<asp:tablerow>
											<asp:tablecell Text="Between Means:"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
										</asp:tablerow>
										<asp:tablerow>
											<asp:tablecell Text="Within Samples:"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
										</asp:tablerow>
										<asp:tablerow>
											<asp:tablecell Text="Total:"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center"></asp:tablecell>
										</asp:tablerow>
									</asp:table>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:table id="TableFValues" runat="server" BackColor="WhiteSmoke" BorderColor="White" BorderDashStyle="Solid" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="1" font-names="Tahoma" font-size="8pt">
										<asp:tablerow Font-Size="XX-Small" Font-Names="Microsoft Sans Serif">
											<asp:tablecell Width="104px" Text="F Value:"></asp:tablecell>
											<asp:tablecell Width="56px" HorizontalAlign="Center" Text="0"></asp:tablecell>
										</asp:tablerow>
										<asp:tablerow Font-Size="XX-Small" Font-Names="Microsoft Sans Serif">
											<asp:tablecell Text="F Critical:"></asp:tablecell>
											<asp:tablecell HorizontalAlign="Center" Text="0"></asp:tablecell>
										</asp:tablerow>
									</asp:table>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:button id="ButtonRandomData" runat="server" Text="Random Data" CommandArgument="5" width="168px" onclick="ButtonRandomData_Click"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
