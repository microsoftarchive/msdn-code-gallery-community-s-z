<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MultipleYAxis" CodeFile="MultipleYAxis.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"  />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"  />
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to display a data series using 
				multiple Y axes.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x306 px)-->
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" BorderColor="181, 64, 1">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series BorderWidth="2" Name="Series1" ChartType="Line" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" ShadowOffset="2"></asp:series>
								<asp:series BorderWidth="2" Name="Series2" ChartType="Line" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" ShadowOffset="2"></asp:series>
								<asp:series BorderWidth="2" Name="Series3" ChartType="Line" ShadowColor="64, 0, 0, 0" BorderColor="180, 26, 59, 105" ShadowOffset="2"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="N0" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="Auto" format="MM/dd" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark size="2" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48">&nbsp;</td>
								<td>
									<asp:checkbox id="UseMultipleYAxis" runat="server" Checked="True" AutoPostBack="True" Text="Use Multiple Y Axes"></asp:checkbox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
