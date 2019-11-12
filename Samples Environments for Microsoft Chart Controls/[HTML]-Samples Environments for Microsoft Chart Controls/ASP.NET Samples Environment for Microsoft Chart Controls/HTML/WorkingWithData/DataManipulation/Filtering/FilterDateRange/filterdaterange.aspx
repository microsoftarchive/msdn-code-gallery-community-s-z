
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FilterDateRange" CodeFile="FilterDateRange.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>FilterDateRange</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to filter data points using date/time 
				ranges.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" BackColor="WhiteSmoke" BackSecondaryColor="White" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series BorderWidth="0" XValueType="DateTime" Name="Series Input" CustomProperties="PointWidth=0.7, MinPixelPointWidth=3" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series BorderWidth="0" ChartArea="FilteredData" XValueType="DateTime" Name="Series Output" CustomProperties="PointWidth=0.7, MinPixelPointWidth=3" BorderColor="180, 26, 59, 105"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Original Data">
										<labelstyle enabled="False" />
										<majorgrid enabled="False" />
										<majortickmark enabled="False" />
									</axisy2>
									<axisx2 IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="5" height="43" width="90" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1000" minimum="0" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200" />
										<majorgrid interval="200" linecolor="64, 64, 64, 64" />
										<majortickmark interval="200" enabled="False" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="ddd, MMM d" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="FilteredData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Filtered Data">
										<labelstyle enabled="False" />
										<majorgrid enabled="False" />
										<majortickmark enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="48" height="43" width="90" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1000" minimum="0" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200" />
										<majorgrid interval="200" linecolor="64, 64, 64, 64" />
										<majortickmark interval="200" enabled="False" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="ddd, MMM d" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Number of days in series:</asp:label></td>
								<td>
									<asp:dropdownlist id="DayNumberLst" runat="server" Width="50px" AutoPostBack="True">
										<asp:listitem Value="30" Selected="True">30</asp:listitem>
										<asp:listitem Value="50">50</asp:listitem>
										<asp:listitem Value="70">70</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server">Points to be filtered:</asp:label></td>
								<td>
									<asp:dropdownlist id="FilterValuesList" runat="server" AutoPostBack="True" width="133px">
										<asp:listitem Value="Weekends" Selected="True">Weekends</asp:listitem>
										<asp:listitem Value="Weekdays">Weekdays</asp:listitem>
										<asp:listitem Value="Except 15">Except 15th</asp:listitem>
										<asp:listitem Value="Except 1-15">Except 1-15th</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server">Show as indexed:</asp:label></td>
								<td>
									<asp:dropdownlist id="ShowAsIndexedList" runat="server" Width="80px" AutoPostBack="True">
										<asp:listitem Value="False" Selected="True">False</asp:listitem>
										<asp:listitem Value="True">True</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p>
				&nbsp;</p>
		</form>
	</body>
</html>
