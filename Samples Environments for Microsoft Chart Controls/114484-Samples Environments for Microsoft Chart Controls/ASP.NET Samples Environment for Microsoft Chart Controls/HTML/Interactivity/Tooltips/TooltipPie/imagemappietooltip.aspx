<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageMapPieToolTip" CodeFile="ImageMapPieToolTip.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapPieToolTip</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to&nbsp;use selection&nbsp;in 
				conjunction with&nbsp;tooltips.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Palette="BrightPastel" 
                            ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" 
                            BackColor="#F3DFC1" Width="412px" Height="296px" borderlinestyle="Solid" 
                            backgradienttype="TopBottom" borderlinewidth="2" borderlinecolor="181, 64, 1" 
                            onclick="Chart1_Click">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Title" Alignment="TopLeft" ForeColor="26, 59, 105" Name="Title1"></asp:title>
							</titles>
							<legends>
								<asp:legend Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series Name="Series1" ChartType="Pie" BorderColor="180, 26, 59, 105" ShadowOffset="4" ></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR -->
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				Move the mouse cursor over the pie slices or legend items to see the tooltip, 
				and&nbsp;click on a pie slice or legend item to explode the 
				selected&nbsp;slice.</p>
		</form>
		<p></p>
		<script type="text/javascript">
			function onSliceClicked(pointIndex) { 
				var objSeries = document.Form1.elements["SeriesTooltip"];
				var objLegend = document.Form1.elements["LegendTooltip"];
				
				var parameters = "seriesTooltip=" + objSeries.options[objSeries.selectedIndex].value; 
				parameters = parameters + "&legendTooltip=" + objLegend.options[objLegend.selectedIndex].value; 

				document.Form1.elements["Chart1"].ImageUrl = "ImageMapToolTipsChart.aspx?" + parameters;
				
				document.images["Chart1"].src = document.Form1.elements["Chart1"].ImageUrl;
			} 
			 
		</script>
	</body>
</html>
