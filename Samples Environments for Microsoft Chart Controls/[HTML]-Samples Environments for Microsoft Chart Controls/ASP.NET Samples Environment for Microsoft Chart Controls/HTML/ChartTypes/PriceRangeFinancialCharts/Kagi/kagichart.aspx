<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.KagiChart" CodeFile="KagiChart.aspx.cs" %>

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
			<p class="dscr"> This sample demonstrates the Kagi chart type.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" BackColor="WhiteSmoke" Width="412px" Height="296px" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Kagi Chart" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series BorderWidth="3" XValueType="Date" Name="Default" ChartType="Kagi" CustomProperties="PriceUpColor=SkyBlue" ShadowColor="Black" BorderColor="180, 26, 59, 105" Color="Tomato" ShadowOffset="2" IsXValueIndexed="True" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Reversal Amount:</td>
								<td><asp:dropdownlist id="comboReversalAmount" runat="server" Width="110px" AutoPostBack="True">
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.8">0.8</asp:ListItem>
										<asp:ListItem Value="1.0" Selected="True">1.0</asp:ListItem>
										<asp:ListItem Value="1.2">1.2</asp:ListItem>
										<asp:ListItem Value="1%">1%</asp:ListItem>
										<asp:ListItem Value="2%">2%</asp:ListItem>
										<asp:ListItem Value="4%">4%</asp:ListItem>
										<asp:ListItem Value="Default">Default</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->The 
                reversal amount can be a percentage or a fixed amount.</p>
		</form>
	</body>
</html>
