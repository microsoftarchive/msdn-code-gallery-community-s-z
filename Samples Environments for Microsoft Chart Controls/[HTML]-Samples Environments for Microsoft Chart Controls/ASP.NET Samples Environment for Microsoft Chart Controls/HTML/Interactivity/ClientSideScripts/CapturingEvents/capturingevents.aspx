<%@ Page language="c#" Inherits=" System.Web.UI.DataVisualization.Charting.Samples.ImageMapCapturingEvents" CodeFile="CapturingEvents.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapPieToolTip</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="ImageMapPieToolTip" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to capture different mouse 
				events&nbsp;for series and legend items.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
					    <asp:chart id="Chart1" runat="server" ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="#F3DFC1" Width="412px" Height="296px" borderlinestyle="Solid" backgradientstyle="TopBottom" borderlinewidth="2" borderlinecolor="181, 64, 1">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Mouse Events" Alignment="TopLeft" ForeColor="26, 59, 105">
									<position y="5.5423727" height="8.283567" width="89.43796" x="4.82481766"></position>
								</asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Docking="Top" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series Name="Brand1" ChartType="Bar" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series Name="Brand2" ChartType="Bar" BorderColor="180, 26, 59, 105"></asp:series>
								<asp:series Name="Brand3" ChartType="Bar" BorderColor="180, 26, 59, 105"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy linecolor="64, 64, 64, 64" islabelautofit="False" maximum="1000">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="C0"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisy>
									<axisx linecolor="64, 64, 64, 64" islabelautofit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
										<customlabels>
											<asp:customlabel Text="Qtr 1" ToPosition="1.5" FromPosition="0.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 2" ToPosition="2.5" FromPosition="1.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 3" ToPosition="3.5" FromPosition="2.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 4" ToPosition="4.5" FromPosition="3.5"></asp:customlabel>
											<asp:customlabel Text="2001" LabelMark="LineSideMark" RowIndex="1"  ToPosition="4.4" FromPosition="0.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 1" ToPosition="5.5" FromPosition="4.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 2" ToPosition="6.5" FromPosition="5.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 3" ToPosition="7.5" FromPosition="6.5"></asp:customlabel>
											<asp:customlabel Text="Qtr 4" ToPosition="8.5" FromPosition="7.5"></asp:customlabel>
											<asp:customlabel Text="2002" LabelMark="LineSideMark" RowIndex="1" ToPosition="8.5" FromPosition="4.5"></asp:customlabel>
											<asp:customlabel></asp:customlabel>
										</customlabels>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label1" runat="server">Mouse event to capture:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="EventList" runat="server" Width="149px" AutoPostBack="True" onselectedindexchanged="EventList_SelectedIndexChanged">
										<asp:listitem Selected="True">onclick</asp:listitem>
										<asp:listitem>ondblclick</asp:listitem>
										<asp:listitem>onmouseover</asp:listitem>
										<asp:listitem>onmouseout</asp:listitem>
										<asp:listitem>onmousewheel</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	    <p class="dscr">
            Change the type of the mouse event using the drop-down list at the right. After 
            making your selection, click on a legend item or a bar in the plot area to see 
            what happens.</p>
	</body>
</html>
