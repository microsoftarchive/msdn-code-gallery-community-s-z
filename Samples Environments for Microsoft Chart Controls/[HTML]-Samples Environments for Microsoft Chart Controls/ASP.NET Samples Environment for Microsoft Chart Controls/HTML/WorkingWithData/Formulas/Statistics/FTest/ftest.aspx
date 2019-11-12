
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FTest" CodeFile="FTest.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates the F-test and F-distribution formulas.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" backcolor="#D3DFF0" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
									<position y="5" height="15" width="30" x="63"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series Name="FirstGroup" CustomProperties="LabelStyle=&quot;down&quot;" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series ChartArea="Chart Area 2" Name="SecondGroup" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series ChartArea="ChartArea1" Name="Distribution" ChartType="Area" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series ChartArea="" Name="Result" BorderColor="180, 26, 59, 105"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" AlignWithChartArea="Chart Area 2" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="Distribution">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="100px">Probability: </asp:label></td>
								<td>
									<asp:dropdownlist id="DropDownListProbability" runat="server" AutoPostBack="True" width="80px" onselectedindexchanged="DropDownListProbability_SelectedIndexChanged">
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="40">40</asp:listitem>
										<asp:listitem Value="60">60</asp:listitem>
										<asp:listitem Value="80">80</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
										<asp:listitem Value="95" Selected="True">95</asp:listitem>
										<asp:listitem Value="99">99</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2">
									<p>
										<asp:table id="TableResults" runat="server" BackColor="WhiteSmoke" BorderColor="White" BorderDashStyle="Solid" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="1" width="246px">
											<asp:tablerow>
												<asp:tablecell Width="164px" HorizontalAlign="Right" Text="First series mean:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell HorizontalAlign="Right" Text="Second series mean:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell HorizontalAlign="Right" Text="First series variance:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell HorizontalAlign="Right" Text="Second series variance:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell HorizontalAlign="Right" Text="F Value:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell HorizontalAlign="Right" Text="P (F&lt;=f) one-tail:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell HorizontalAlign="Right" Text="F Critical value - one-tail:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
										</asp:table></p>
								</td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;
									<asp:button id="ButtonRandomData" runat="server" CommandArgument="5" Text="Random Data" width="159px" onclick="ButtonRandomData_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The appearance of a red region in the Distribution chart area means 
				that a hypothesis is rejected, while the appearance of a green region indicates 
				that a hypothesis is accepted.</p>
		</form>
	</body>
</html>
