<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataBindThenAlignAxisLabel" CodeFile="DataBindThenAlignAxisLabel.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>ImageMapCustom</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to bind multiple data series' X 
				values to a string.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Width="412px" Height="296px" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="BrightPastel" BorderWidth="2" backcolor="WhiteSmoke" imagetype="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
									<position Y="8" Height="12" Width="16" X="78"></position>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="25" LabelAngle="-90" XValueType="String" Name="Series1" CustomProperties="DrawingStyle=Cylinder, LabelStyle=Bottom" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double"></asp:Series>
								<asp:Series MarkerSize="25" LabelAngle="-90" XValueType="String" Name="Series2" CustomProperties="DrawingStyle=Cylinder, LabelStyle=Bottom" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="Double"></asp:Series>
								<asp:Series MarkerSize="25" LabelAngle="-90" XValueType="String" Name="Series3" CustomProperties="DrawingStyle=Cylinder, LabelStyle=Bottom" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<axisy2>
										<MinorGrid Enabled="False"></MinorGrid>
										<MinorTickMark Enabled="False"></MinorTickMark>
									</axisy2>
									<axisx2>
										<MinorGrid Enabled="False"></MinorGrid>
										<MinorTickMark Enabled="False"></MinorTickMark>
									</axisx2>
									<area3dstyle Rotation="7" Perspective="6" Enable3D="True" Inclination="18" PointDepth="200" IsRightAngleAxes="False" WallWidth="0" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<MinorGrid Enabled="False"></MinorGrid>
										<MinorTickMark Enabled="False"></MinorTickMark>
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="1" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<MinorGrid Enabled="False"></MinorGrid>
										<MinorTickMark Enabled="False"></MinorTickMark>
										<MajorTickMark Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Align Data By Axis Label:</td>
								<td>
									<p>
										<asp:checkbox id="AlignSeries" runat="server" AutoPostBack="True"></asp:checkbox></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"> Notice that the X axis uses the X values of the first series (in 
                the Chart.Series collection) as axis labels. The series are plotted in the order 
                of their data point indexes, but the X values of the three series at the same 
                index are different. </p>
            <p class="dscr"> Select the Align Data By Axis Label check box to align the data 
                points with the same axis labels. The AlignDataPointsByAxisLabel method is used 
                to do this.</p>
		</form>
	</body>
</html>
