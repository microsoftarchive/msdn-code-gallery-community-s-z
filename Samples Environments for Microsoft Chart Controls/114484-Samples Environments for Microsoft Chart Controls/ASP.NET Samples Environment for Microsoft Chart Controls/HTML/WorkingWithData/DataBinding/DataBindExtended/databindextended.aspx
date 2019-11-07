
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataBindExtended" CodeFile="DataBindExtended.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>ImageMapCustom</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample demonstrates extended data binding of the Chart control.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Width="412px" Height="296px" BorderColor="26, 59, 105" TextAntiAliasingQuality="Normal" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="BrightPastel" BorderWidth="2" backcolor="WhiteSmoke" imagetype="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt" ShadowOffset="3" Text="Extended Data Binding" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
									<position y="8" height="12" width="16" x="78"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series XValueType="Double" Name="Series1" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="7.19999980926514" />
										<asp:datapoint XValue="2" YValues="5" />
										<asp:datapoint XValue="3" YValues="8" />
										<asp:datapoint XValue="4" YValues="3.79999995231628" />
										<asp:datapoint XValue="5" YValues="4" />
										<asp:datapoint XValue="6" YValues="0" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle pointgapdepth="0" Rotation="18" perspective="10" enable3d="True" Inclination="21" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid interval="Auto" linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="1" IsEndLabelVisible="False" />
										<majorgrid linecolor="64, 64, 64, 64" enabled="False" />
										<majortickmark interval="1" enabled="False" />
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
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"> Extended chart properties, such as tooltips and labels, can be bound to a data source using the Points.DataBind method.</p>
		</form>
	</body>
</html>
