
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.GroupingFormulas" CodeFile="GroupingFormulas.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>GroupingFormulas</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates data grouping using different intervals 
				and formulas.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Far" Docking="Top" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" IsDockedInsideChartArea="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series BorderWidth="0" YValuesPerPoint="4" Name="Sales" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series YValuesPerPoint="4" ChartArea="GroupedData" Name="Grouped Sales" BorderColor="180, 26, 59, 105"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="Auto" Format="MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
								<asp:ChartArea Name="GroupedData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="Auto" IntervalType="Months" Format="MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label1" runat="server">Grouping Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="GroupingTypeList" runat="server" AutoPostBack="True" width="123px" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="Week" Selected="True">Week</asp:listitem>
										<asp:listitem Value="2 Weeks">2 Weeks</asp:listitem>
										<asp:listitem Value="Month">Month</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server">Grouping Formula (X):</asp:label></td>
								<td>
									<asp:dropdownlist id="GroupingXFormulaList" runat="server" AutoPostBack="True" width="122px" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="Center" Selected="True">Center</asp:listitem>
										<asp:listitem Value="First">First</asp:listitem>
										<asp:listitem Value="Last">Last</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Grouping Formula (Y):</asp:label></td>
								<td>
									<asp:dropdownlist id="GroupingFormulaList" runat="server" AutoPostBack="True" width="121px" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="AVE" Selected="True">Average</asp:listitem>
										<asp:listitem Value="Max">Maximum</asp:listitem>
										<asp:listitem Value="Min">Minimum</asp:listitem>
										<asp:listitem Value="Sum">Sum</asp:listitem>
										<asp:listitem Value="Count">Count</asp:listitem>
										<asp:listitem Value="DistinctCount">DistinctCount</asp:listitem>
										<asp:listitem Value="Variance">Variance</asp:listitem>
										<asp:listitem Value="Deviation">Deviation</asp:listitem>
										<asp:listitem Value="HiLoOpCl">HiLoOpCl</asp:listitem>
										<asp:listitem Value="HiLo">HiLo</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2" align="right"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Note that data binding is used in 
				this sample.</p>
		</form>
	</body>
</html>
