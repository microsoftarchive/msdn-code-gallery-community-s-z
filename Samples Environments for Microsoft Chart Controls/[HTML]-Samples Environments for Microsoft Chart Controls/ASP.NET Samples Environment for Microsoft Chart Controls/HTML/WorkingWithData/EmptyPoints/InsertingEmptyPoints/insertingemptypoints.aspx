
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.InsertingEmptyPoints" CodeFile="InsertingEmptyPoints.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>InsertingEmptyPoints</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample uses the InsertEmptyPoints method to repeatedly check 
				for missing data points for a given time interval and inserts empty points.&nbsp;</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" palette="BrightPastel" BorderlineDashStyle="Solid" BackColor="#D3DFF0" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Far" Docking="Top" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row">
									<CustomItems>
										<asp:LegendItem ImageStyle="Marker" Name="Empty Point" Color="224, 64, 10" MarkerStyle="Diamond"></asp:LegendItem>
									</CustomItems>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series LegendText="Data" ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" CustomProperties="DrawingStyle=Emboss, EmptyPointValue=Zero" BorderColor="180, 26, 59, 105" Color="252, 180, 65" LabelFormat="M">
									<EmptyPointStyle MarkerColor="224, 64, 10"></EmptyPointStyle>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 Enabled="False"></axisy2>
									<axisx2 Enabled="False"></axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="16.89354" Height="76.2929" Width="89.43796" X="4.82481766"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" Format="M" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label1" runat="server">Check for Empty Points:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:dropdownlist id="EmptyPointIntervalList" runat="server" width="146px" AutoPostBack="True">
										<asp:listitem Value="No Empty Points">No Empty Points</asp:listitem>
										<asp:listitem Value="Every Day" Selected="True">Every Day</asp:listitem>
										<asp:listitem Value="Every Week Day">Every Week Day</asp:listitem>
										<asp:listitem Value="Every Monday">Every Monday</asp:listitem>
										<asp:listitem Value="Every 12 Hours">Every 12 Hours</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label2" runat="server">Empty Points Value:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:dropdownlist id="EmptyValueList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Average" Selected="True">Average of Neighbors</asp:listitem>
										<asp:listitem Value="Zero">Zero</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label3" runat="server">Show as Indexed:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:dropdownlist id="ShowAsIndexedList" runat="server" Width="150px" AutoPostBack="True">
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
