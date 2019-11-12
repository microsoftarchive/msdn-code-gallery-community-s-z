
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PointAndFigureChart" CodeFile="PointAndFigureChart.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates 
				the Point and Figure chart type.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" BackColor="#D3DFF0" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Palette="BrightPastel" BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderDashStyle="Solid" BorderWidth="2" BorderColor="26, 59, 105">
<titles>
<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Point and Figure Chart" ForeColor="26, 59, 105"></asp:Title>
</titles>

<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin SkinStyle="Emboss">
</borderskin>

<series>
<asp:Series YValuesPerPoint="2" XValueType="Date" Name="Default" ChartType="PointAndFigure" CustomProperties="PriceUpColor=Black" BorderColor="180, 26, 59, 105" IsXValueIndexed="True" YValueType="Double"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False">
</area3dstyle>
<axisy LineColor="64, 64, 64, 64" IsStartedFromZero="False">
<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold">
</LabelStyle>
<MajorGrid LineColor="64, 64, 64, 64">
</MajorGrid>
</axisy>
<axisx LineColor="64, 64, 64, 64">
<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="MMM dd">
</LabelStyle>
<MajorGrid LineColor="64, 64, 64, 64">
</MajorGrid>
</axisx>
</asp:ChartArea>
</chartareas>
</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Box Size:</td>
								<td><asp:dropdownlist id="comboBoxSize" runat="server" Width="110px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="1.2">1.2</asp:ListItem>
										<asp:ListItem Value="7%">7%</asp:ListItem>
										<asp:ListItem Value="8%" Selected="True">8%</asp:ListItem>
										<asp:ListItem Value="9%">9%</asp:ListItem>
										<asp:ListItem Value="Default">Default</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Reversal Amount:</td>
								<td><asp:dropdownlist id="comboReversalAmount" runat="server" Width="110px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Proportional Symbols:</td>
								<td><asp:CheckBox id="checkPropSymbols" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->The 
ProportionalSymbols custom attribute indicates that the chart should try to draw 
‘X’ and ‘O’ symbols proportionally.</p>
		</form>
	</body>
</html>
