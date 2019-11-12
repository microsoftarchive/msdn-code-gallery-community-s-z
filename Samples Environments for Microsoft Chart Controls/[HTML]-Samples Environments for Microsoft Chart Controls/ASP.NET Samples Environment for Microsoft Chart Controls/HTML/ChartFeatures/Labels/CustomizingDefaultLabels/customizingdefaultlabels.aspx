
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CustomizingDefaultLabels" CodeFile="CustomizingDefaultLabels.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>CustomizingDefaultLabels</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to customize automatically generated 
				axis labels using&nbsp;the Customize&nbsp;event.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" BorderColor="181, 64, 1">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Series1" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series Name="Series2"></asp:Series>
								<asp:Series Name="Series3"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="True">
										<labelstyle font="Trebuchet MS, 8.25pt" />
									</axisy2>
									<axisx2 enabled="True">
										<labelstyle font="Trebuchet MS, 8.25pt" format="M" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt" interval="Auto" intervaloffsettype="Auto" format="M" />
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
			<p class="dscr">You can see the original labels on&nbsp;each&nbsp;secondary axes of 
				the chart (axis at top and right) and the result of the customization on the 
				labels of the primary axis (axis at bottom and left). The primary Y axis has 
				been modified for the insertion of a degree symbol.&nbsp; The primary X axis 
				has been modified to remove every second label.</p>
			<p>
			</p>
		</form>
	</body>
</html>
