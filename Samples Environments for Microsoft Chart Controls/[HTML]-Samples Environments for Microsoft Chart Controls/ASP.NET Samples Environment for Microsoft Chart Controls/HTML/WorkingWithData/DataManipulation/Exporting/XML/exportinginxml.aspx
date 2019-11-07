<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ExportingInXML" CodeFile="ExportingInXML.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ExportingInXML</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to export series data in XML 
				format.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Palette="BrightPastel" BackColor="#F3DFC1" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Exporting Series" Alignment="MiddleLeft" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Series1" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" IsEndLabelVisible="False" Format="dd MMM" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48">&nbsp;</td>
								<td>
									XML Schema:</td>
							</tr>
							<tr>
								<td class="label48">&nbsp;</td>
								<td>
									<asp:textbox id="SchemaTextBox" runat="server" Height="100px" Width="253px" ReadOnly="True" Wrap="False" TextMode="MultiLine"></asp:textbox></td>
							</tr>
							<tr>
								<td class="label48">&nbsp;</td>
								<td>
									XML Data:
								</td>
							</tr>
							<tr>
								<td class="label48">&nbsp;</td>
								<td>
									<asp:textbox id="XMLTextBox" runat="server" Height="100px" Width="255px" ReadOnly="True" Wrap="False" TextMode="MultiLine"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
