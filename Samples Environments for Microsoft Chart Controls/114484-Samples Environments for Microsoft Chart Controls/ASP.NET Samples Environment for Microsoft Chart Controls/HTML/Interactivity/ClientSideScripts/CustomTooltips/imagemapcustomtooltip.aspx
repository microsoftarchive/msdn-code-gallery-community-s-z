<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageMapCustomTooltip" CodeFile="ImageMapCustomTooltip.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapCustomTooltip</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
		<style type="text/css">
			.FadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; margin: "3,3,3,3"; padding: "3,3,3,3"; borderbottomwidths: "3,3,3,3" }
		</style>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates fading tooltips, which are created by 
				handling the MouseOver and MouseOut events.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
                        <asp:Chart ID="Chart1" runat="server" Height="296px" Width="500px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                            ImageType="Png" BackColor="#F3DFC1" borderlinestyle="Solid" BackGradientStyle="TopBottom"
                            BorderlineWidth="2" BorderlineColor="181, 64, 1">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="Olympic Medals" ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
                                    <Position Y="21" Height="22" Width="20" X="73"></Position>
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series Name="Gold" BorderColor="180, 26, 59, 105">
                                    <Points>
                                        <asp:DataPoint AxisLabel="CountryA" YValues="12"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryB" YValues="10"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryC" YValues="11"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryD" YValues="6"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryE" YValues="6"></asp:DataPoint>
                                    </Points>
                                </asp:Series>
                                <asp:Series Name="Silver" BorderColor="180, 26, 59, 105">
                                    <Points>
                                        <asp:DataPoint AxisLabel="CountryA" YValues="16"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryB" YValues="13"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryC" YValues="7"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryD" YValues="3"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryE" YValues="6"></asp:DataPoint>
                                    </Points>
                                </asp:Series>
                                <asp:Series Name="Bronze" BorderColor="180, 26, 59, 105">
                                    <Points>
                                        <asp:DataPoint AxisLabel="CountryA" YValues="7"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryB" YValues="11"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryC" YValues="6"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryD" YValues="8"></asp:DataPoint>
                                        <asp:DataPoint AxisLabel="CountryE" YValues="4"></asp:DataPoint>
                                    </Points>
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                    <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server">Tooltip content:</asp:label></td>
								<td>
									<asp:dropdownlist id="ContentList" runat="server" Width="130px" AutoPostBack="True" onselectedindexchanged="ContentList_SelectedIndexChanged">
										<asp:listitem Value="flag" Selected="True">Country Flag</asp:listitem>
										<asp:listitem Value="chart">Statistics Chart</asp:listitem>
										<asp:listitem Value="#VAL #SER medals">Medals</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">A country flag image, binary streamed chart or text can be shown in 
				the tooltip.&nbsp; Move the mouse pointer over the series bars or legend items 
				to see the tooltips.</p>
		    <style type="text/css">.FadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; MARGIN: 3px 3px 3px 3px; padding: 3px 3px 3px 3px; borderBottomWidth: 3px 3px 3px 3px }
			</style>
			
			<div class="FadingTooltip" id="FADINGTOOLTIP" style="Z-INDEX: 999; VISIBILITY: hidden; POSITION: absolute"></div>
			<script type="text/javascript" language="javascript">
			var FADINGTOOLTIP
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
				FADINGTOOLTIP.innerHTML = tooltip_text;
				tooltip_shown = (tooltip_text != "")? true : false;
				if(tooltip_text != "")
				{
					// Get tooltip window height
					tooltip_height=(FADINGTOOLTIP.style.pixelHeight)? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;
					transparency=0;
					ToolTipFading();
				} 
				else 
				{
					clearTimeout(timer_id);
					FADINGTOOLTIP.style.visibility="hidden";
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

					FADINGTOOLTIP.style.visibility = "visible";
				
					offset_y = (ev.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? - 15 - tooltip_height: 20;
					FADINGTOOLTIP.style.left = Math.min(wnd_width - tooltip_width - 10 , Math.max(3, ev.clientX + 6)) + document.body.scrollLeft + 'px';
					FADINGTOOLTIP.style.top = ev.clientY + offset_y + document.body.scrollTop + 'px';
				}
			}

			function WindowLoading()
			{
				FADINGTOOLTIP=document.getElementById('FADINGTOOLTIP');
	
				// Get tooltip  window width				
				tooltip_width = (FADINGTOOLTIP.style.pixelWidth) ? FADINGTOOLTIP.style.pixelWidth : FADINGTOOLTIP.offsetWidth;
				
				// Get tooltip window height
				tooltip_height=(FADINGTOOLTIP.style.pixelHeight)? FADINGTOOLTIP.style.pixelHeight : FADINGTOOLTIP.offsetHeight;

				UpdateWindowSize();
			}
			
			function ToolTipFading()
			{
				if(transparency <= 100)
				{
					FADINGTOOLTIP.style.filter="alpha(opacity="+transparency+")";
				    //FADINGTOOLTIP.style.opacity=transparency/100;
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
