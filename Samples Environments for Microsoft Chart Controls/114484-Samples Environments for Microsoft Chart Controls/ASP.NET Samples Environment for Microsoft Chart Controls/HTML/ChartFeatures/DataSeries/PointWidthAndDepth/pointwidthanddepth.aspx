<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PointWidthAndDepth" CodeFile="PointWidthAndDepth.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to set data point width to a specified 
				number of pixels. It also shows how to set series point depth in pixels.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series 2" CustomProperties="PixelPointGapDepth=10, PixelPointDepth=70, PixelPointWidth=45" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="Double">
									<points>
										<asp:datapoint YValues="14" />
										<asp:datapoint YValues="18" />
										<asp:datapoint YValues="14" />
										<asp:datapoint YValues="18" />
										<asp:datapoint YValues="16" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series 1" CustomProperties="PixelPointGapDepth=10, PixelPointDepth=70, PixelPointWidth=45" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double">
									<points>
										<asp:datapoint YValues="10" />
										<asp:datapoint YValues="19" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="12" />
										<asp:datapoint YValues="18" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="160px">Point Width in Pixels:</asp:label></td>
								<td>
									<asp:dropdownlist id="DropDownListWidth" runat="server" AutoPostBack="True" cssclass="spaceright" onselectedindexchanged="DropDownListWidth_SelectedIndexChanged">
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
										<asp:listitem Value="40">40</asp:listitem>
										<asp:listitem Value="45" Selected="True">45</asp:listitem>
										<asp:listitem Value="50">50</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">3D:</td>
								<td>
									<asp:checkbox id="CheckBox3D" runat="server" AutoPostBack="True" checked="True" oncheckedchanged="CheckBox3D_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Clustered:</td>
								<td>
									<asp:checkbox id="CheckBoxClustered" runat="server" AutoPostBack="True" Enabled="False" oncheckedchanged="CheckBoxClustered_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="160px">Point Depth in Pixels:</asp:label></td>
								<td>
									<asp:dropdownlist id="DropDownListDepth" runat="server" AutoPostBack="True" Enabled="False" cssclass="spaceright" onselectedindexchanged="DropDownListDepth_SelectedIndexChanged">
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="50">50</asp:listitem>
										<asp:listitem Value="70" Selected="True">70</asp:listitem>
										<asp:listitem Value="100">100</asp:listitem>
										<asp:listitem Value="200">200</asp:listitem>
										<asp:listitem Value="300">300</asp:listitem>
										<asp:listitem Value="500">500</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="166px">Point Gap Depth in Pixels:</asp:label></td>
								<td>
									<asp:dropdownlist id="DropDownListGap" runat="server" AutoPostBack="True" Enabled="False" cssclass="spaceright" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="10" Selected="True">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="50">50</asp:listitem>
										<asp:listitem Value="100">100</asp:listitem>
										<asp:listitem Value="200">200</asp:listitem>
										<asp:listitem Value="300">300</asp:listitem>
										<asp:listitem Value="500">500</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR -->
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The point width and depth are set to absolute values and do not 
				depend on the number of points in the series.</p>
		</form>
	</body>
</html>
