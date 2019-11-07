<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SeriesAppearance" CodeFile="SeriesAppearance.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendAppearance</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LegendAppearance" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the visual appearance of&nbsp;a 
				series.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x296 px)-->
						<asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" Palette="BrightPastel" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart Control for .NET Framework" Alignment="MiddleLeft" ForeColor="26, 59, 105" Name="Title1"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" Name="Default" BorderColor="180, 26, 59, 105" CustomProperties="DrawingStyle=Cylinder">
									<points>
										<asp:datapoint YValues="3" />
										<asp:datapoint YValues="7" />
										<asp:datapoint YValues="8" />
										<asp:datapoint YValues="6" />
										<asp:datapoint YValues="7" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
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
									<asp:label id="Label1" runat="server" Width="90px">Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="ColorList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="CornflowerBlue" Selected="True">CornflowerBlue</asp:listitem>
										<asp:listitem Value="RoyalBlue">RoyalBlue</asp:listitem>
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Brown">Brown</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="90px">End Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="EndColorList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="SkyBlue" Selected="True">SkyBlue</asp:listitem>
										<asp:listitem Value="Tomato">Tomato</asp:listitem>
										<asp:listitem Value="Navy">Navy</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="90px">Gradient:</asp:label></td>
								<td>
									<asp:dropdownlist id="GradientList" runat="server" Width="150px" AutoPostBack="True" onselectedindexchanged="GradientList_SelectedIndexChanged">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="LeftRight">LeftRight</asp:ListItem>
										<asp:ListItem Value="TopBottom">TopBottom</asp:ListItem>
										<asp:ListItem Value="Center">Center</asp:ListItem>
										<asp:ListItem Value="DiagonalLeft">DiagonalLeft</asp:ListItem>
										<asp:ListItem Value="DiagonalRight">DiagonalRight</asp:ListItem>
										<asp:ListItem Value="HorizontalCenter">HorizontalCenter</asp:ListItem>
										<asp:ListItem Value="VerticalCenter" Selected="True">VerticalCenter</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Width="90px">Hatching:</asp:label></td>
								<td>
									<asp:dropdownlist id="HatchingList" runat="server" Width="150px" AutoPostBack="True" onselectedindexchanged="HatchingList_SelectedIndexChanged">
										<asp:listitem Value="None" Selected="True">None</asp:listitem>
										<asp:listitem Value="Cross">Cross</asp:listitem>
										<asp:listitem Value="DashedVertical">DashedVertical</asp:listitem>
										<asp:listitem Value="LargeConfetti">LargeConfetti</asp:listitem>
										<asp:listitem Value="Plaid">Plaid</asp:listitem>
										<asp:listitem Value="Shingle">Shingle</asp:listitem>
										<asp:listitem Value="Sphere">Sphere</asp:listitem>
										<asp:listitem Value="Vertical">Vertical</asp:listitem>
										<asp:listitem Value="Wave">Wave</asp:listitem>
										<asp:listitem Value="ZigZag">ZigZag</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr height="4">
								<td colspan="2" style="HEIGHT: 8px">&nbsp;</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" Width="90px">BorderColor:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderColorList" runat="server" Width="150px" AutoPostBack="True">
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="White">White</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Gray" Selected="True">Gray</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server" Width="90px">BorderSize:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderSizeList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="1" Selected="True">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label7" runat="server" Width="90px">BorderDashStyle:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderDashStyleList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="Dash">Dash</asp:listitem>
										<asp:listitem Value="DashDot">DashDot</asp:listitem>
										<asp:listitem Value="DashDotDot">DashDotDot</asp:listitem>
										<asp:listitem Value="Dot">Dot</asp:listitem>
										<asp:listitem Value="Solid" Selected="True">Solid</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label8" runat="server" Width="90px">ShadowOffset:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="ShadowOffsetList" runat="server" Width="150px" AutoPostBack="True">
											<asp:listitem Value="0">0</asp:listitem>
											<asp:listitem Value="1">1</asp:listitem>
											<asp:listitem Value="2" Selected="True">2</asp:listitem>
											<asp:listitem Value="3">3</asp:listitem>
											<asp:listitem Value="4">4</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 52px"><asp:checkbox id="ApplyToPoint" runat="server" AutoPostBack="True" Text="Apply to the Third  Point Only"></asp:checkbox></td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR -->
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Note that all data points have the same visual attributes as their 
                owning Series objects, and data point attributes take precedence over their 
                related series 
				attributes. To apply the visual properties to a single point, select the Apply to Third Point Only check box.</p>
		</form>
	</body>
</html>
