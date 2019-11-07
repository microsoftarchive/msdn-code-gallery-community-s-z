<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendCustomItems" CodeFile="LegendCustomItems.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendCustomItems</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to add custom items to the 
				legend. These legend items can be a strip line, custom image, or any custom drawn item.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Custom Legend Items" ForeColor="26, 59, 105" Name="Title1"></asp:Title>
							</titles>
							<legends>
								<asp:Legend IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" IsVisibleInLegend="False" Name="Default" BorderColor="180, 26, 59, 105" YValueType="Double" CustomProperties="DrawingStyle=Wedge">
									<points>
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="200" />
										<asp:DataPoint YValues="560" />
										<asp:DataPoint YValues="300" />
									</points>
								</asp:Series>
								<asp:Series IsVisibleInLegend="False" Name="Series2" CustomProperties="DrawingStyle=Wedge">
									<points>
										<asp:DataPoint YValues="550" />
										<asp:DataPoint YValues="580" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="425" />
										<asp:DataPoint YValues="400" />
									</points>
								</asp:Series>
								<asp:Series IsVisibleInLegend="False" Name="Series3" CustomProperties="DrawingStyle=Wedge">
									<points>
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="350" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="520" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
