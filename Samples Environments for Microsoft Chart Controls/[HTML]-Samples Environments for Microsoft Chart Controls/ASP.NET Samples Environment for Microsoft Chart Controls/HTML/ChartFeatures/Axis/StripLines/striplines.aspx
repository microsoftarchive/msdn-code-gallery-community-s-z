
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.StripLines" CodeFile="StripLines.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to set the appearance properties of 
				the StripLine object.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x306 px)--><asp:chart id="Chart1" runat="server" Palette="BrightPastel" BorderColor="26, 59, 105" BackColor="WhiteSmoke" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderlineDashStyle="Solid">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Strip Lines" Alignment="MiddleLeft" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerBorderColor="224, 64, 10" MarkerSize="8" BorderWidth="2" Name="Default" ChartType="Line" MarkerStyle="Circle" MarkerColor="252, 180, 65" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="200" />
										<asp:DataPoint YValues="450" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="467" />
										<asp:DataPoint YValues="123" />
										<asp:DataPoint YValues="743" />
										<asp:DataPoint YValues="867" />
										<asp:DataPoint YValues="234" />
										<asp:DataPoint YValues="567" />
										<asp:DataPoint YValues="789" />
										<asp:DataPoint YValues="678" />
										<asp:DataPoint YValues="547" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<StripLines>
											<asp:StripLine StripWidth="1" Interval="5" BorderColor="MidnightBlue" BackSecondaryColor="DarkRed" IntervalOffset="0.5" BackColor="Red" BackGradientStyle="LeftRight"></asp:StripLine>
										</StripLines>
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label6" runat="server" Height="20px" Width="101px">Interval:</asp:label></td>
								<td><asp:dropdownlist id="Interval" runat="server" Width="78px" AutoPostBack="True">
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5" Selected="True">5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server" Height="20px" Width="101px">Strip Width:</asp:label></td>
								<td><asp:dropdownlist id="StripWidth" runat="server" Height="22px" Width="78px" AutoPostBack="True">
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="0.2">0.2</asp:listitem>
										<asp:listitem Value="0.5">0.5</asp:listitem>
										<asp:listitem Value="1" Selected="True">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label5" runat="server" Height="20px" Width="101px">Back Color:</asp:label></td>
								<td><asp:dropdownlist id="StripColor" runat="server" Height="22px" Width="122px" AutoPostBack="True">
										<asp:ListItem Value="Red" Selected="True">Red</asp:ListItem>
										<asp:ListItem Value="Gainsboro">Gainsboro</asp:ListItem>
										<asp:ListItem Value="Khaki">Khaki</asp:ListItem>
										<asp:ListItem Value="LightSteelBlue">LightSteelBlue</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label8" runat="server" Height="20px" Width="101px">Gradient Style:</asp:label></td>
								<td><asp:dropdownlist id="Gradient" runat="server" Height="22" Width="122px" AutoPostBack="True" onselectedindexchanged="Gradient_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label9" runat="server" Height="20px" Width="101px">Hatch Style:</asp:label></td>
								<td><asp:dropdownlist id="Hatching" runat="server" Height="22" Width="122px" AutoPostBack="True" onselectedindexchanged="Hatching_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label7" runat="server" Height="20px" Width="101px">Secondary Back Color:</asp:label></td>
								<td><asp:dropdownlist id="StripEndColor" runat="server" Height="22px" Width="122px" AutoPostBack="True">
										<asp:ListItem Value="DarkRed" Selected="True">DarkRed</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="SlateGray">SlateGray</asp:ListItem>
										<asp:ListItem Value="Gold">Gold</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server" Height="20px" Width="101px">Border Style:</asp:label></td>
								<td><asp:dropdownlist id="StripLinesStyle" runat="server" Height="22" Width="122px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label4" runat="server" Height="20px" Width="101px">Border Width:</asp:label></td>
								<td><asp:dropdownlist id="LineWidth" runat="server" Height="22px" Width="49px" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server" Height="20px" Width="101px">Border Color:</asp:label></td>
								<td>
									<p><asp:dropdownlist id="LineColor" runat="server" Height="22px" Width="122px" AutoPostBack="True">
											<asp:ListItem Value="MidnightBlue" Selected="True">MidnightBlue</asp:ListItem>
											<asp:ListItem Value="Red">Red</asp:ListItem>
											<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
											<asp:ListItem Value="Blue">Blue</asp:ListItem>
											<asp:ListItem Value="Green">Green</asp:ListItem>
											<asp:ListItem Value="Black">Black</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
