<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MultipleLegendsWithCheckBox" CodeFile="MultipleLegendsWithCheckBox.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Multiple Legends</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to seperate one legend into two 
				seperate legends.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Width="412px" BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="BrightPastel" BorderColor="26, 59, 105" BackColor="WhiteSmoke" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineDashStyle="Solid" BorderWidth="2" imagetype="Png">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Docking="Left" Font="Trebuchet MS, 14.25pt, style=Bold" DockedToChartArea="ChartArea1" ShadowOffset="-3" Text="Series 1" ForeColor="26, 59, 105"></asp:Title>
								<asp:Title ShadowColor="32, 0, 0, 0" Docking="Left" Font="Trebuchet MS, 14.25pt, style=Bold" DockedToChartArea="Chart Area 2" ShadowOffset="-3" Text="Series 2" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend IsTextAutoFit="False" BorderColor="Gray" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" Name="Series 1" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:DataPoint YValues="12" />
										<asp:DataPoint YValues="12" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="15" />
										<asp:DataPoint YValues="24" />
										<asp:DataPoint YValues="15" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="Chart Area 2" Name="Series 2" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65">
									<points>
										<asp:DataPoint YValues="20" />
										<asp:DataPoint YValues="33" />
										<asp:DataPoint YValues="96" />
										<asp:DataPoint YValues="66" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="30" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent">
									<area3dstyle pointgapdepth="0" Rotation="10" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="5.542373" height="42.32203" width="86" x="4.824818"></position>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
								<asp:ChartArea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent" AlignWithChartArea="ChartArea1">
									<area3dstyle pointgapdepth="0" Rotation="10" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="50.86441" height="42.32203" width="80" x="4.824818"></position>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48">
								</td>
								<td>
									<asp:checkbox id="CheckBox1" runat="server" Width="237px" AutoPostBack="True" Text="Use two separate legends"></asp:checkbox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
