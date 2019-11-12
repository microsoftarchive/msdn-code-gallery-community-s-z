<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendAppearance" CodeFile="LegendAppearance.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendAppearance</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the appearance of the legend.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" Palette="Pastel" BackColor="WhiteSmoke" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart for .NET Framework" Alignment="TopCenter" ForeColor="26, 59, 105">
									<position y="4" height="8.738057" width="65" x="22"></position>
								</asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Total" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Last Week" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="220, 252, 180, 65">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="This Week" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="220, 224, 64, 10">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="8" height="75" width="100"></position>
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
								<td class="label">
									<asp:label id="Label1" runat="server" Width="140px">Primary BackColor:</asp:label></td>
								<td>
									<asp:dropdownlist id="BackColorList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="Transparent" Selected="True">Transparent</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="White">White</asp:listitem>
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Gray">Gray</asp:listitem>
										<asp:listitem Value="MediumSeaGreen">MediumSeaGreen</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="140px">Secondary BackColor:</asp:label></td>
								<td>
									<asp:dropdownlist id="EndColorList" runat="server" Width="150px" AutoPostBack="True" Height="8px">
										<asp:listitem>Blue</asp:listitem>
										<asp:listitem>White</asp:listitem>
										<asp:listitem>Red</asp:listitem>
										<asp:listitem>Yellow</asp:listitem>
										<asp:listitem Selected="True">Green</asp:listitem>
										<asp:listitem>Gray</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="90px">Gradient:</asp:label></td>
								<td>
									<asp:dropdownlist id="GradientList" runat="server" Width="150px" AutoPostBack="True" onselectedindexchanged="GradientList_SelectedIndexChanged">
										<asp:listitem Value="None" Selected="True">None</asp:listitem>
										<asp:listitem Value="LeftRight">LeftRight</asp:listitem>
										<asp:listitem Value="TopBottom">TopBottom</asp:listitem>
										<asp:listitem Value="Center">Center</asp:listitem>
										<asp:listitem Value="DiagonalLeft">DiagonalLeft</asp:listitem>
										<asp:listitem Value="DiagonalRight">DiagonalRight</asp:listitem>
										<asp:listitem Value="HorizontalCenter">HorizontalCenter</asp:listitem>
										<asp:listitem Value="VerticalCenter">VerticalCenter</asp:listitem>
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
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" Width="90px">BorderColor:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderColorList" runat="server" Width="150px" AutoPostBack="True">
										<asp:listitem Value="Gray" Selected="True">Gray</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="White">White</asp:listitem>
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Black">Black</asp:listitem>
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
										<asp:ListItem>NotSet</asp:ListItem>
										<asp:ListItem Value="Dash">Dash</asp:ListItem>
										<asp:ListItem Value="DashDot">DashDot</asp:ListItem>
										<asp:ListItem Value="DashDotDot">DashDotDot</asp:ListItem>
										<asp:ListItem Value="Dot">Dot</asp:ListItem>
										<asp:ListItem Value="Solid" Selected="True">Solid</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label8" runat="server" Width="90px">ShadowOffset:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="ShadowOffsetList" runat="server" Width="150px" AutoPostBack="True">
											<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
											<asp:ListItem Value="1">1</asp:ListItem>
											<asp:ListItem Value="2">2</asp:ListItem>
											<asp:ListItem Value="3">3</asp:ListItem>
											<asp:ListItem Value="4">4</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
