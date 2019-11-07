
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PieCollectedData" CodeFile="PieCollectedData.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>PieChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="PieChart" method="post" runat="server">
			<p class="dscr"> This sample demonstrates how to improve the 
				readability of small segments in the Pie or Doughnut chart types by&nbsp;displaying them in a supplemental 
				pie chart series.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:chart id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend LegendStyle="Row" Enabled="False" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Default" ChartType="Pie" BorderColor="180, 26, 59, 105" ShadowOffset="5" Font="Trebuchet MS, 8.25pt, style=Bold" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="" BorderWidth="0">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Hide Supplemental Chart:</td>
								<td><asp:checkbox id="HideSupp" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Chart Type:</td>
								<td><asp:dropdownlist id="ChartTypeList" runat="server" AutoPostBack="True" Width="120px">
										<asp:ListItem Value="Pie">Pie</asp:ListItem>
										<asp:ListItem Value="Doughnut" Selected="True">Doughnut</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Collected Percentage:</td>
								<td><asp:dropdownlist id="CollectedPercentage" runat="server" AutoPostBack="True" Width="50px">
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3" Selected="True">3</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Supplemental Chart Size:</td>
								<td><asp:dropdownlist id="SupplementalChartSize" runat="server" AutoPostBack="True" Width="120px">
										<asp:listitem Value="Smaller" Selected="True">Smaller</asp:listitem>
										<asp:listitem Value="Same">Same</asp:listitem>
										<asp:listitem Value="Larger">Larger</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Collect Small Segments:</td>
								<td><asp:checkbox id="checkBoxCollect" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
