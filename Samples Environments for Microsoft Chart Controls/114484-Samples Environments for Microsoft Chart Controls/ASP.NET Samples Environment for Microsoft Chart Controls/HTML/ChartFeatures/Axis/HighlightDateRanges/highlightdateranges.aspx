
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.HighlightDateRanges" CodeFile="HighlightDateRanges.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>FilterDateRange</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="FilterDateRange" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to highlight a range of data using 
				StripLine objects.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ToolTip="This is a #VALX{dddd}" XValueType="DateTime" Name="Default" CustomProperties="DrawingStyle=LightToDark" BorderColor="180, 26, 59, 105" Color="252, 180, 65"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 TitleForeColor="" Enabled="False">
										<LabelStyle Enabled="False" />
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy2>
									<axisx2 Enabled="True">
										<LabelStyle Enabled="False" />
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Maximum="1000" Minimum="0" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="200" />
										<MajorGrid Interval="200" LineColor="64, 64, 64, 64" />
										<MajorTickMark Interval="200" Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IntervalAutoMode="VariableCount">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="MMM d" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label3" runat="server"> Points to highlight:</asp:label></td>
								<td>
									<asp:dropdownlist id="HighlightValuesList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Weekends" Selected="True">Weekends</asp:listitem>
										<asp:listitem Value="Weekdays">Weekdays</asp:listitem>
										<asp:listitem Value="Mondays">Mondays</asp:listitem>
										<asp:listitem Value="Wednesdays">Wednesdays</asp:listitem>
										<asp:listitem Value="Fridays">Fridays</asp:listitem>
										<asp:listitem Value="Mondays and Fridays">Mondays and Fridays</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				StripLine objects, unlike interlaced strip lines, have interval-related 
				properties that determine how often and where strip lines are displayed.</p>
		</form>
	</body>
</html>
