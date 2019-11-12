<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageMapCustom" CodeFile="ImageMapCustom.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapCustom</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to draw an image on the chart using 
				events. Click on the money sign to go to the hyperlink that is used in the 
				image map.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
					<asp:chart id="Chart1" runat="server" BackGradientStyle="TopBottom" Palette="BrightPastel" BackColor="#F3DFC1" Width="412px" Height="296px" BorderlineDashStyle="Solid" borderlinewidth="2" borderlinecolor="181, 64, 1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<Titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Draw an Image" Alignment="TopLeft" ForeColor="26, 59, 105">
									<Position Y="4" Height="8.738057" Width="55" X="4"></Position>
								</asp:Title>
							</Titles>
							<Legends>
								<asp:Legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<Position Y="85" Height="5" Width="40" X="5"></Position>
								</asp:Legend>
							</Legends>
							<BorderSkin SkinStyle="Emboss"></BorderSkin>
							<Series>
								<asp:Series ChartArea="Chart Area 1" XValueType="Double" Name="Series1" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" YValueType="Double">
									<Points>
										<asp:DataPoint XValue="1" YValues="70"></asp:DataPoint>
										<asp:DataPoint XValue="2" YValues="80"></asp:DataPoint>
										<asp:DataPoint XValue="3" YValues="70"></asp:DataPoint>
										<asp:DataPoint XValue="4" YValues="79"></asp:DataPoint>
									</Points>
								</asp:Series>
								<asp:Series ChartArea="Chart Area 1" Name="Series2" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="252, 180, 65">
									<Points>
										<asp:DataPoint XValue="1" YValues="65"></asp:DataPoint>
										<asp:DataPoint XValue="2" YValues="70"></asp:DataPoint>
										<asp:DataPoint XValue="3" YValues="60"></asp:DataPoint>
										<asp:DataPoint XValue="4" YValues="81"></asp:DataPoint>
									</Points>
								</asp:Series>
								<asp:Series ChartArea="Chart Area 1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="224, 64, 10">
									<Points>
										<asp:DataPoint XValue="1" YValues="50"></asp:DataPoint>
										<asp:DataPoint XValue="2" YValues="55"></asp:DataPoint>
										<asp:DataPoint XValue="3" YValues="40"></asp:DataPoint>
										<asp:DataPoint XValue="4" YValues="70"></asp:DataPoint>
									</Points>
								</asp:Series>
							</Series>
							<ChartAreas>
								<asp:ChartArea Name="Chart Area 1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<Position Y="13" Height="75" Width="90" X="2"></Position>
									<AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
										<MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
									</AxisY>
									<AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Interval="1">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
										<MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
									</AxisX>
								</asp:ChartArea>
							</ChartAreas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><!-- LABEL HERE--></td>
								<td><!-- CONTROL HERE--></td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR -->
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				The PostPaint event is used to draw the image on top of the&nbsp;data points. 
				If desired, the image can be drawn behind data points by&nbsp;handling the 
				PrePaint event.&nbsp; A custom map area is used to make the image interactive.</p>
		</form>
	</body>
</html>
