<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendCustomizeDefault" CodeFile="LegendCustomizeDefault.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendCustomizeDefault</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to customize default legend items 
				that&nbsp;are automatically generated for all plotted data series.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" 
                            Width="412px" Palette="Pastel" BackColor="WhiteSmoke"  BorderlineDashStyle="Solid"
                            BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" 
                            BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" 
                            imagetype="Png" oncustomizelegend="Chart1_CustomizeLegend">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Legend" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8pt, style=Bold" Alignment="Far"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series1" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series2" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="252, 180, 65">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="224, 64, 10">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
										<labelstyle font="Trebuchet MS, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<customlabels>
											<asp:customlabel Text="John" ToPosition="1.5" FromPosition="0.5"></asp:customlabel>
											<asp:customlabel Text="Mary" ToPosition="2.5" FromPosition="1.5"></asp:customlabel>
											<asp:customlabel Text="Jeff" ToPosition="3.5" FromPosition="2.5"></asp:customlabel>
											<asp:customlabel Text="Bob" ToPosition="4.5" FromPosition="3.5"></asp:customlabel>
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
									<asp:label id="Label1" runat="server"> Customize Legend Item for:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="SeriesNameList" runat="server" Width="168px" AutoPostBack="True">
										<asp:listitem Value="Series1" Selected="True">Series1</asp:listitem>
										<asp:listitem Value="Series2">Series2</asp:listitem>
										<asp:listitem Value="Series3">Series3</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label2" runat="server">Legend Item Customization:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="CustomizationList" runat="server" Width="168px" AutoPostBack="True">
										<asp:listitem Value="None" Selected="True">None</asp:listitem>
										<asp:listitem Value="Set Shadow">Set Shadow</asp:listitem>
										<asp:listitem Value="Set Line Style">Set Line Style</asp:listitem>
										<asp:listitem Value="Change Text">Change Text</asp:listitem>
										<asp:listitem Value="Change Color">Change Color</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Select the series name, and then&nbsp;select the desired 
				customization from the list. The legend item text or visual appearance is changed 
                accordingly.</p>
		</form>
	</body>
</html>
