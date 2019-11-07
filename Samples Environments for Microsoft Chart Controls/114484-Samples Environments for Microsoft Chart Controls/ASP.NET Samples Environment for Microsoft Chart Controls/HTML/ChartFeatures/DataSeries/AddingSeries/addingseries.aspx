<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AddingSeries" CodeFile="AddingSeries.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to add and remove a data series from 
				the Chart control.&nbsp; It also demonstrates how to use&nbsp;state management.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x296 px)--><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" BackColor="#F3DFC1" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
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
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:button id="AddButton" runat="server" Text="Add Series" onclick="AddButton_Click"></asp:button></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:button id="RemoveButton" runat="server" Text="  Remove  " DESIGNTIMEDRAGDROP="92" onclick="RemoveButton_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">When the Add button is clicked,&nbsp;a data&nbsp;series is added to 
				the chart.&nbsp;The data and appearance properties for the series are taken 
				from the ViewState property, which is cached in the browser.&nbsp;To&nbsp;view 
				the cached data, add a series and then view the source code in the window that 
				displays the chart.</p>
		</form>
	</body>
</html>
