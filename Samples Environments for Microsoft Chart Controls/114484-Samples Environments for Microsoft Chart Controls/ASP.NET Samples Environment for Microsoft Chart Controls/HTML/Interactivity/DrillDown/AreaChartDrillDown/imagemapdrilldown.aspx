<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageMapDrillDown" CodeFile="ImageMapDrillDown.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapDrillDown</title>
		<meta name="GENERATOR" contet="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet">
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to&nbsp;use selection for an image 
				map&nbsp;on the chart.&nbsp;Click on a chart series or&nbsp;a legend item to 
				visit&nbsp;the corresponding&nbsp;manufacturer website.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
					<asp:chart id="Chart1" runat="server" Palette="BrightPastel" ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="#D3DFF0" Width="412px" Height="296px" borderlinestyle="Solid" backgradientendcolor="White" backgradienttype="TopBottom" borderlinewidth="2" borderlinecolor="26, 59, 105">
							<Titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Percentage of Cars Sold" ForeColor="26, 59, 105"></asp:Title>
							</Titles>
							<Legends>
								<asp:Legend Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</Legends>
							<BorderSkin SkinStyle="Emboss"></BorderSkin>
							<Series>
								<asp:Series Name="Brand4" ChartType="StackedArea100" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series Name="Brand3" ChartType="StackedArea100" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series Name="Brand2" ChartType="StackedArea100" BorderColor="180, 26, 59, 105"></asp:Series>
								<asp:Series Name="Brand1" ChartType="StackedArea100" BorderColor="180, 26, 59, 105"></asp:Series>
							</Series>
							<ChartAreas>
								<asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<AxisY LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="P0"></LabelStyle>
										<MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
									</AxisY>
									<AxisX IsMarginVisible="False" LineColor="64, 64, 64, 64" LabelAutoFitStyle="LabelsAngleStep90" Interval="2">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
										<MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
									</AxisX>
								</asp:ChartArea>
							</ChartAreas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server">Brand1 web site:</asp:label></td>
								<td>
									<asp:textbox id="TextBoxFord" runat="server" Width="160"  >brand1.htm</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server">Brand2 web site:</asp:label></td>
								<td>
									<asp:textbox id="TextBoxToyota" runat="server" Width="160">brand2.htm</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server">Brand3 web site:</asp:label></td>
								<td>
									<asp:textbox id="TextBoxMazda" runat="server" Width="160">brand3.htm</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server">Brand4 web site:</asp:label></td>
								<td>
									<asp:textbox id="TextBoxPontiac" runat="server" Width="160">brand4.htm</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Open in new window:</td>
								<td>
									<asp:checkbox id="CheckBoxNewWindow" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="CheckBoxNewWindow_CheckedChanged"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 100px">
									<asp:button id="UpdateChartButton" runat="server" Text="Update Chart" onclick="UpdateChartButton_Click"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">To update a website link, type the new URL (starting with <b>http://</b>) and click on the 
				"Update Chart" button.</p>
			<p>
			</p>
		</form>
	</body>
</html>
