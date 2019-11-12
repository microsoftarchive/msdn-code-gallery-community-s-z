<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartAppearance" CodeFile="ChartAppearance.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set a chart's&nbsp;background 
				appearance.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BorderColor="26, 59, 105" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="Pastel" BorderlineDashStyle="Solid" BackColor="WhiteSmoke" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px">
							<titles>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent">
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="13" height="75" width="90" x="2"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label2" runat="server" Width="100px" Height="19px">Back Color:</asp:label></td>
								<td><asp:dropdownlist id="BackColor" runat="server" Width="134px" Height="219px" AutoPostBack="True">
										<asp:ListItem Value="White" Selected="True">White</asp:ListItem>
										<asp:ListItem Value="AliceBlue">AliceBlue</asp:ListItem>
										<asp:ListItem Value="Linen">Linen</asp:ListItem>
										<asp:ListItem Value="Pink">Pink</asp:ListItem>
										<asp:ListItem Value="Lime">Lime</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server" Width="100px" Height="19px">Gradient:</asp:label></td>
								<td><asp:dropdownlist id="Gradient" runat="server" Width="134px" Height="45px" AutoPostBack="True" onselectedindexchanged="Gradient_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label4" runat="server" Width="100px" Height="19px">Hatch Style:</asp:label></td>
								<td><asp:dropdownlist id="HatchStyle" runat="server" Width="134px" Height="45px" AutoPostBack="True" onselectedindexchanged="HatchStyle_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server" Width="100px" Height="19px">Secondary Back Color:</asp:label></td>
								<td><asp:dropdownlist id="ForeColor" runat="server" Width="134px" Height="22px" AutoPostBack="True">
										<asp:ListItem Value="SkyBlue">SkyBlue</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Coral" Selected="True">Coral</asp:ListItem>
										<asp:ListItem Value="Teal">Teal</asp:ListItem>
										<asp:ListItem Value="Gainsboro">Gainsboro</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label5" runat="server" Width="100px" Height="19px">Border Color:</asp:label></td>
								<td><asp:dropdownlist id="BorderColor" runat="server" Width="134px" Height="45px" AutoPostBack="True">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Brown">Brown</asp:ListItem>
										<asp:ListItem Value="MidnightBlue" Selected="True">MidnightBlue</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label6" runat="server" Width="100px" Height="19px">Border Size:</asp:label></td>
								<td><asp:dropdownlist id="BorderSize" runat="server" Width="134px" Height="22" AutoPostBack="True">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2" Selected="True">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label7" runat="server" Width="100px" Height="19px">Border Style:</asp:label></td>
								<td><asp:dropdownlist id="BorderDashStyle" runat="server" Width="134px" Height="22" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="label">Image:</td>
								<td><asp:checkbox id="Image1" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label8" runat="server" Width="100px" Height="19px">Image Mode:</asp:label></td>
								<td><asp:dropdownlist id="ImageMode" runat="server" Width="134px" Height="45px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label9" runat="server" Width="100px" Height="19px">Image Align:</asp:label></td>
								<td><asp:dropdownlist id="ImageAlign1" runat="server" Width="134px" Height="45px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
