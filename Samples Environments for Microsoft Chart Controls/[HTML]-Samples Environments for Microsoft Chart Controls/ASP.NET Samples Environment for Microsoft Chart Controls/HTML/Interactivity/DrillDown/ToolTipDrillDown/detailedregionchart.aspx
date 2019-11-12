<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DetailedRegionChart" CodeFile="DetailedRegionChart.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapCustomTooltip</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="ImageMapCustomTooltip" method="post" runat="server">
			<p class="dscr" style="height:48px;">This page demonstrates the detailed view of the selected Sales 
				by Regional Sales Representatives.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
					<asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" Palette="BrightPastel" ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" borderlinestyle="Solid" backgradienttype="TopBottom" borderlinewidth="2" borderlinecolor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Regional Sales" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
									<position y="21" height="22" width="18" x="73"></position>
								</asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Sales" BorderColor="180, 26, 59, 105"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy linecolor="64, 64, 64, 64" islabelautofit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisy>
									<axisx linecolor="64, 64, 64, 64" islabelautofit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>&nbsp;-&nbsp;<a href="javascript:window.history.back(1);">Back</a> -</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</HTML>
