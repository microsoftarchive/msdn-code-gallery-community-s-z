<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendStyleAndPosition" CodeFile="LegendStyleAndPosition.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendStyleAndPosition</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set legend style and position 
				within the chart.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series LegendText="Projected" Name="Series 1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="300" />
										<asp:datapoint YValues="400" />
										<asp:datapoint YValues="200" />
										<asp:datapoint YValues="450" />
										<asp:datapoint YValues="700" />
									</points>
								</asp:series>
								<asp:series LegendText="Actual" Name="Series 2" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint YValues="100" />
										<asp:datapoint YValues="340" />
										<asp:datapoint YValues="420" />
										<asp:datapoint YValues="770" />
										<asp:datapoint YValues="790" />
									</points>
								</asp:series>
								<asp:series BorderWidth="2" LegendText="Historical" Name="Series 3" ChartType="Line" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1">
									<points>
										<asp:datapoint YValues="75" />
										<asp:datapoint YValues="300" />
										<asp:datapoint YValues="400" />
										<asp:datapoint YValues="550" />
										<asp:datapoint YValues="590" />
									</points>
								</asp:series>
								<asp:series BorderWidth="2" LegendText="Target" Name="Series 4" ChartType="Line" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1">
									<points>
										<asp:datapoint YValues="120" />
										<asp:datapoint YValues="360" />
										<asp:datapoint YValues="410" />
										<asp:datapoint YValues="520" />
										<asp:datapoint YValues="560" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2>
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2>
										<majorgrid enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Microsoft Sans Serif, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 169px">
									<asp:label id="Label1" runat="server"> Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="LegendStyleList" runat="server" Width="103px" AutoPostBack="True" cssclass="spaceright" onselectedindexchanged="LegendStyleList_SelectedIndexChanged">
										<asp:ListItem Value="Table" Selected="True">Table</asp:ListItem>
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Row">Row</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 169px">Table Style:</td>
								<td>
									<asp:dropdownlist id="TheTableStyle" runat="server" Width="103px" cssclass="spaceright" AutoPostBack="True">
										<asp:ListItem Value="Auto" Selected="True">Auto</asp:ListItem>
										<asp:ListItem Value="Wide">Wide</asp:ListItem>
										<asp:ListItem Value="Tall">Tall</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 169px">
									<asp:label id="Label2" runat="server">Docking:</asp:label></td>
								<td>
									<asp:dropdownlist id="LegendDockingList" runat="server" Width="103px" AutoPostBack="True" cssclass="spaceright" onselectedindexchanged="LegendDockingList_SelectedIndexChanged">
										<asp:listitem Value="Right" Selected="True">Right</asp:listitem>
										<asp:listitem Value="Bottom">Bottom</asp:listitem>
										<asp:listitem Value="Left">Left</asp:listitem>
										<asp:listitem Value="Top">Top</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 169px">
									<asp:label id="Label3" runat="server">Alignment:</asp:label></td>
								<td>
									<asp:dropdownlist id="LegendAlinmentList" runat="server" Width="103px" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="Near" Selected="True">Near</asp:listitem>
										<asp:listitem Value="Center">Center</asp:listitem>
										<asp:listitem Value="Far">Far</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 169px">Inside Chart Area:</td>
								<td>
									<p>
										<asp:checkbox id="InsideChartArea" runat="server" AutoPostBack="True" oncheckedchanged="InsideChartArea_CheckedChanged"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 169px">Disabled:</td>
								<td>
									<p>
										<asp:checkbox id="LegendDisabled" runat="server" AutoPostBack="True" oncheckedchanged="LegendDisabled_CheckedChanged"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<TD class="label">Reversed:</td>
								<td>
									<asp:checkbox id="Reversed" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>
			</p>
		</form>
	</body>
</html>
