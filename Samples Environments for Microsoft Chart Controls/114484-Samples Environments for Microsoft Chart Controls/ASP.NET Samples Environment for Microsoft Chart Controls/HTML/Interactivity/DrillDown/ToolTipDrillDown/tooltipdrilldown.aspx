<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.TooltipDrillDown" CodeFile="TooltipDrillDown.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapCustomTooltip</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="ImageMapCustomTooltip" method="post" runat="server">
			<p class="dscr">
                <br />
                This sample demonstrates chart drilldown with a preview.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
					<asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" Palette="BrightPastel" ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" borderlinestyle="Solid" backgradientendcolor="White" backgradienttype="TopBottom" borderlinewidth="2" borderlinecolor="26, 59, 105">
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
								<asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisy>
									<axisx linecolor="64, 64, 64, 64" isLabelAutofit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
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
			<p class="dscr">
				Hold the mouse cursor over a&nbsp;column to&nbsp;preview a regional sales 
				chart, and&nbsp;click on a data&nbsp;point to&nbsp;retrieve a&nbsp;detailed 
				chart of sales in that region.</p>
			<style type="text/css">.fadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; MARGIN: 3px 3px 3px 3px; padding: 3px 3px 3px 3px; borderBottomWidth: 3px 3px 3px 3px }
			</style>
			<div class="fadingTooltip" id="fadingTooltip" style="Z-INDEX: 999; VISIBILITY: hidden; POSITION: absolute"></div>
			<script type="text/javascript">
			var fadingTooltip;
			var wnd_height, wnd_width;
			var tooltip_height, tooltip_width;
			var tooltip_shown=false;
			var	transparency = 100;
			var timer_id = 1;
			var tooltiptext;
			
			// override events
			window.onload = WindowLoading;
			window.onresize = UpdateWindowSize;
			document.onmousemove = AdjustToolTipPosition;

			function DisplayTooltip(tooltip_text)
			{
				fadingTooltip.innerHTML = tooltip_text;
				tooltip_shown = (tooltip_text != "")? true : false;
				if(tooltip_text != "")
				{
					// Get tooltip window height
					tooltip_height=(fadingTooltip.style.pixelHeight)? fadingTooltip.style.pixelHeight : fadingTooltip.offsetHeight;
					transparency=0;
					ToolTipFading();
				} 
				else 
				{
					clearTimeout(timer_id);
					fadingTooltip.style.visibility="hidden";
				}
			}

			function AdjustToolTipPosition(e)
			{
				if(tooltip_shown)
				{
				    // Depending on IE/Firefox, find out what object to use to find mouse position
				    var ev;
				    if(e)
				        ev = e;
				    else
				        ev = event;

					fadingTooltip.style.visibility = "visible";
					offset_y = (ev.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? - 15 - tooltip_height: 20;
					fadingTooltip.style.left = Math.min(wnd_width - tooltip_width - 10 , Math.max(3, ev.clientX + 6)) + document.body.scrollLeft + 'px';
					fadingTooltip.style.top = ev.clientY + offset_y + document.body.scrollTop + 'px';
				}
			}

			function WindowLoading()
			{
				fadingTooltip=document.getElementById('fadingTooltip');
	
				// Get tooltip  window width				
				tooltip_width = (fadingTooltip.style.pixelWidth) ? fadingTooltip.style.pixelWidth : fadingTooltip.offsetWidth;
				
				// Get tooltip window height
				tooltip_height=(fadingTooltip.style.pixelHeight)? fadingTooltip.style.pixelHeight : fadingTooltip.offsetHeight;

				UpdateWindowSize();
			}
			
			function ToolTipFading()
			{
				if(transparency <= 100)
				{
					fadingTooltip.style.filter="alpha(opacity="+transparency+")";
					fadingTooltip.style.opacity=transparency/100;
					transparency += 5;
					timer_id = setTimeout('ToolTipFading()', 35);
				}
			}

			function UpdateWindowSize() 
			{
				wnd_height=document.body.clientHeight;
				wnd_width=document.body.clientWidth;
			}
			</script>
		</form>
	</body>
</html>
