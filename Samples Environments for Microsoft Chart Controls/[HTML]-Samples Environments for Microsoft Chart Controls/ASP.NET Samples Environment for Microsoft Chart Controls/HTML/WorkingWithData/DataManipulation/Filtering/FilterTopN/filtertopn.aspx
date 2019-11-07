<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FilterTopN" CodeFile="FilterTopN.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>FilterTopN</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to filter all points from a series 
				except for&nbsp;a specified number of data points with the largest or smallest 
				first Y values.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series MarkerSize="14" Name="Sales" ChartType="Point" MarkerStyle="Square" BorderColor="180, 26, 59, 105" Color="194, 224, 64, 10" ShadowOffset="2"></asp:series>
								<asp:series MarkerSize="18" ChartArea="FilteredData" Name="TopSales" ChartType="Point" MarkerStyle="Cross" BorderColor="180, 26, 59, 105" Color="194, 252, 180, 65" ShadowOffset="2"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt" IsLabelAutoFit="False" enabled="True" title="Original Data">
										<labelstyle font="Trebuchet MS, 8.25pt" enabled="False" />
										<majorgrid enabled="False" />
										<majortickmark enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="5" height="42" width="90" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1600" minimum="400" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200" />
										<majorgrid interval="200" linecolor="64, 64, 64, 64" />
										<majortickmark interval="200" />
									</axisy>
									<axisx titlefont="Microsoft Sans Serif, 8.25pt" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="2002" minimum="1989">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="2" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark interval="2" />
									</axisx>
								</asp:chartarea>
								<asp:chartarea Name="FilteredData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Filtered Data">
										<labelstyle enabled="False" />
										<majorgrid enabled="False" />
										<majortickmark enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="47" height="42" width="90" x="3"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1600" minimum="400" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200" />
										<majorgrid interval="200" linecolor="64, 64, 64, 64" />
										<majortickmark interval="200" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="2002" minimum="1989">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="2" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark interval="2" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label2" runat="server" width="144px">No. of Points to Leave:</asp:label></td>
								<td>
									<asp:dropdownlist id="PointNumberList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="5" Selected="True">5</asp:listitem>
										<asp:listitem Value="7">7</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server" width="140px">Points to Leave:</asp:label></td>
								<td>
									<asp:dropdownlist id="PointsToLeaveList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="Top" Selected="True">Largest</asp:listitem>
										<asp:listitem Value="Bottom">Smallest</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server">Show as Indexed:</asp:label></td>
								<td>
									<asp:dropdownlist id="ShowAsIndexedList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="False" Selected="True">False</asp:listitem>
										<asp:listitem Value="True">True</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
