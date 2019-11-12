
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PrimaryAndSecondaryAxes" CodeFile="PrimaryAndSecondaryAxes.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to use two different scales for the 
				primary and secondary Y axes.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x306 px)--><asp:chart id="Chart1" runat="server" Height="360px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="BrightPastel" BorderColor="26, 59, 105" BackColor="#D3DFF0" BorderWidth="2">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Aircraft" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series Name="Default" ChartType="Bar" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint BorderWidth="2" AxisLabel="Model 1" YValues="5400" />
										<asp:datapoint BorderWidth="2" AxisLabel="Model 2" YValues="3200" />
										<asp:datapoint BorderWidth="2" AxisLabel="Model 3" YValues="2700" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 titlefont="Trebuchet MS, 8.25pt, style=Bold" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2 titlefont="Trebuchet MS, 8.25pt, style=Bold" IsLabelAutoFit="False">
										<majorgrid enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Aircraft Data:</td>
								<td>
									<asp:dropdownlist id="Characteristics" runat="server" AutoPostBack="True">
										<asp:listitem Value="Range">Range</asp:listitem>
										<asp:listitem Value="MaxW">Max. Weight</asp:listitem>
										<asp:listitem Value="WingSpan">Wing Span</asp:listitem>
										<asp:listitem Value="Passengers">Passengers</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Secondary Y Axis:</td>
								<td>
									<p>
										<asp:checkbox id="SecondaryY" runat="server" Width="151px" Height="17px" AutoPostBack="True" Checked="True" DESIGNTIMEDRAGDROP="103"></asp:checkbox></p>
								</td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR -->
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
