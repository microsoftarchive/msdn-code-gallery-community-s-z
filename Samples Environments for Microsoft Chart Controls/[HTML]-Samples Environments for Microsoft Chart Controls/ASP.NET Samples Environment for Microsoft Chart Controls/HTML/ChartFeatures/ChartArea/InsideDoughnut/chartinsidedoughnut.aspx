
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartInsideDoughnut" CodeFile="ChartInsideDoughnut.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ChartInsideDoughnut</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to overlay chart areas to create a 
				more complicated chart type.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:chart id="Chart1" runat="server" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" Palette="BrightPastel" IsSoftShadows="False" BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#F3DFC1" BorderColor="181, 64, 1" Height="296px">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series IsValueShownAsLabel="True" ChartArea="" Name="Series1" ChartType="Doughnut" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="2">
									<points>
										<asp:datapoint YValues="1" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="3" />
									</points>
								</asp:series>
								<asp:series IsValueShownAsLabel="True" ChartArea="" Name="Series2" ChartType="Doughnut" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" ShadowOffset="2" Enabled="False">
									<points>
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="5" />
										<asp:datapoint YValues="3" />
									</points>
								</asp:series>
								<asp:series IsValueShownAsLabel="True" ChartArea="" Name="Series3" ChartType="Doughnut" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" ShadowOffset="2" Enabled="False">
									<points>
										<asp:datapoint YValues="9" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="4" />
										<asp:datapoint YValues="5" />
									</points>
								</asp:series>
							</series>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 68px"></td>
								<td><asp:checkbox id="Series2CheckBox" runat="server" Text="Show Series 2" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 68px"></td>
								<td><asp:checkbox id="Series3CheckBox" runat="server" Text="Show Series 3" AutoPostBack="True"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The radius of the outer doughnut chart is set so that additional 
				doughnuts can be inserted into the ring. The chart area positions are explicity 
				set at design-time. Note that to create this effect, you must use transparent background colors.</p>
		</form>
	</body>
</html>
