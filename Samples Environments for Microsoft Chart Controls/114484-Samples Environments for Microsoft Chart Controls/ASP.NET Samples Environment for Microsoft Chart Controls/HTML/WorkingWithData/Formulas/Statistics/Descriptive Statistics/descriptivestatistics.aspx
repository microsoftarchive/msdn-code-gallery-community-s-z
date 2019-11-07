
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DescriptiveStatistics" CodeFile="DescriptiveStatistics.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates the&nbsp;mean, 
				standard deviation, and median formulas.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" backcolor="#F3DFC1" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
									<position y="5" height="15" width="30" x="63"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series BorderWidth="2" Name="Series1" ChartType="Line" CustomProperties="LabelStyle=&quot;down&quot;" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Ivory" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 IsLabelAutoFit="False">
										<labelstyle interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
										<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
										<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
									</axisy2>
									<axisx2 IsLabelAutoFit="False">
										<labelstyle interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
										<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
										<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
										<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" linecolor="64, 64, 64, 64" enabled="False" intervaloffsettype="Auto" />
										<striplines>
											<asp:stripline TextLineAlignment="Far" Font="Trebuchet MS, 8.25pt" StripWidth="50" Text="Standard Deviation" IntervalOffset="20" BackColor="64, 241, 185, 168"></asp:stripline>
											<asp:stripline TextLineAlignment="Far" Font="Trebuchet MS, 8.25pt" BorderWidth="2" BorderColor="252, 180, 65" Text="Mean" IntervalOffset="40"></asp:stripline>
											<asp:stripline TextLineAlignment="Far" Font="Trebuchet MS, 8.25pt" BorderWidth="2" BorderColor="224, 64, 10" Text="Median" IntervalOffset="50" TextAlignment="Near"></asp:stripline>
										</striplines>
										<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
										<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" linecolor="64, 64, 64, 64" intervaloffsettype="Auto" />
										<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:table id="TableResults" runat="server" BackColor="WhiteSmoke" BorderColor="White" BorderDashStyle="Solid" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="1" Width="207px">
											<asp:tablerow>
												<asp:tablecell Width="130px" HorizontalAlign="Right" Text="Mean:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell Width="130px" HorizontalAlign="Right" Text="Standard Deviation:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
											<asp:tablerow>
												<asp:tablecell Width="130px" HorizontalAlign="Right" Text="Median:"></asp:tablecell>
												<asp:tablecell HorizontalAlign="Left" Text="0"></asp:tablecell>
											</asp:tablerow>
										</asp:table></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:button id="Button1" runat="server" Width="137px" Text="Random Data" CommandArgument="6" onclick="Button1_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
<p class="dscr">Standard deviation is represented by the light blue strip 
line.</p>
		</form>
	</body>
</html>
