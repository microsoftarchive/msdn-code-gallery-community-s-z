<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CustomizingDefaultMapAreas" CodeFile="CustomizingDefaultMapAreas.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>CustomizingDefaultMapAreas</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to customize default image map areas.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" borderlinestyle="Solid" backgradienttype="TopBottom" borderlinewidth="2" backcolor="#D3DFF0" borderlinecolor="26, 59, 105" enableviewstate="True" viewstatecontent="All">
							<legends>
								<asp:legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series MarkerSize="20" XValueType="Double" Name="Series1" ChartType="Point" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" YValueType="Double"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy linecolor="64, 64, 64, 64" islabelautofit="False" maximum="15" minimum="-15" interval="5">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisy>
									<axisx linecolor="64, 64, 64, 64" islabelautofit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<asp:radiobutton id="ShowDefault" runat="server" Text="Show Default Tooltips" AutoPostBack="True" Checked="True" GroupName="Tooltips"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:radiobutton id="ShowCustomized" runat="server" Height="21px" Text="Show Customized Tooltips" AutoPostBack="True" GroupName="Tooltips"></asp:radiobutton></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The sample uses the&nbsp;CustomizeMapAreas event to change the tooltip text 
				of the data points that have negative Y values. For example, the tooltip shows 
                &quot;(5.7)&quot; instead of &quot;-5.7&quot;.</p>
		</form>
	</body>
</html>
