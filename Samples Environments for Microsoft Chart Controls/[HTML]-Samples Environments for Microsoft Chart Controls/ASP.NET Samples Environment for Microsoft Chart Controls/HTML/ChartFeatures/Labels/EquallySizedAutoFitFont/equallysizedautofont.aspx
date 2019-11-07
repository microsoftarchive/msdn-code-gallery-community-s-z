<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.EquallySizedAutoFont" CodeFile="EquallySizedAutoFont.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>MultilineLabels</title>
	    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="MultilineLabels" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to use the same font size for all axes 
				labels in a chart area. By default, the font size for axis labels is calculated 
				on an axis-by-axis basis.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="148px" Width="656px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" ChartType="SplineArea" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:DataPoint YValues="12" />
										<asp:DataPoint YValues="45" />
										<asp:DataPoint YValues="44" />
										<asp:DataPoint YValues="76" />
										<asp:DataPoint YValues="38" />
										<asp:DataPoint YValues="81" />
										<asp:DataPoint YValues="43" />
										<asp:DataPoint YValues="27" />
										<asp:DataPoint YValues="28" />
										<asp:DataPoint YValues="67" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx IsMarginVisible="False" linecolor="64, 64, 64, 64">
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
			<p style="PADDING-LEFT: 140px">
				<asp:checkbox id="checkBoxAutoFont" runat="server" Text="Same Font Size for All Axes Labels" AutoPostBack="True"></asp:checkbox>
			</p>
		</form>
	</body>
</html>
