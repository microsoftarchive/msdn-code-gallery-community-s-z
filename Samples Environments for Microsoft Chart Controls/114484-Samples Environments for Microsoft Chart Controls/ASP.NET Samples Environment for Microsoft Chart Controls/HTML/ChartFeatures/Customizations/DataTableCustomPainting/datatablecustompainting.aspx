<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataTableCustomPainting" CodeFile="DataTableCustomPainting.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample shows how to use the PostPaint events to draw a data 
                table in the chart area.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:chart id="Chart1" runat="server" BorderColor="26, 59, 105" Palette="BrightPastel" BackColor="#D3DFF0" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" ImageType="Png">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" DockedToChartArea="ChartArea1" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series XValueType="Double" Name="Series1" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="2" />
										<asp:datapoint AxisLabel="Label" XValue="2" YValues="3" />
										<asp:datapoint XValue="3" YValues="5" />
										<asp:datapoint XValue="4" YValues="3" />
										<asp:datapoint XValue="5" YValues="6" />
									</points>
								</asp:series>
								<asp:series XValueType="Double" Name="Series2" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="6" />
										<asp:datapoint XValue="2" YValues="2" />
										<asp:datapoint XValue="3" YValues="3" />
										<asp:datapoint XValue="4" YValues="5" />
										<asp:datapoint XValue="5" YValues="4" />
									</points>
								</asp:series>
								<asp:series XValueType="Double" Name="Series3" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="3" />
										<asp:datapoint XValue="2" YValues="3" />
										<asp:datapoint XValue="3" YValues="2" />
										<asp:datapoint XValue="4" YValues="4" />
										<asp:datapoint XValue="5" YValues="1" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark enabled="False" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" title="This is Axis X">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible ="False" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<majortickmark enabled="False" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Show Data Table 1:</td>
								<td><asp:checkbox id="DataTable1" runat="server" Text="" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Show Table Totals:</td>
								<td><asp:checkbox id="ShowTotals" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Show Axis Title</td>
								<td><asp:checkbox id="ShowTitle" Text="" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Title Size:</td>
								<td><asp:dropdownlist id="FontSize" runat="server" Width="65px" AutoPostBack="True" CssClass="spaceright">
										<asp:listitem Value="8" Selected="True">8</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
										<asp:listitem Value="18">18</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Table Color:</td>
								<td><asp:dropdownlist id="TableColor" runat="server" Width="132px" AutoPostBack="True" CssClass="spaceright">
										<asp:listitem Value="White" Selected="True">White</asp:listitem>
										<asp:listitem Value="Tan">Tan</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="LightSteelBlue">LightSteelBlue</asp:listitem>
										<asp:listitem Value="RosyBrown">RosyBrown</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Border Color:</td>
								<td><asp:dropdownlist id="BorderColor" runat="server" Width="132px" AutoPostBack="True" CssClass="spaceright">
										<asp:listitem Value="Black" Selected="True">Black</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="LightSteelBlue">LightSteelBlue</asp:listitem>
										<asp:listitem Value="Silver">Silver</asp:listitem>
										<asp:listitem Value="White">White</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				For more information on this sample, click the Overview tab at the top of the 
                frame.</p>
		</form>
	</body>
</html>
