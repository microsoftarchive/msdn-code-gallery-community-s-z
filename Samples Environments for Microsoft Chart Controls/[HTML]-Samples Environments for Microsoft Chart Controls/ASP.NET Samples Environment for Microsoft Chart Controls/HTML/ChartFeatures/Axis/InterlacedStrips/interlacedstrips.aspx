<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.InterlacedStrips" CodeFile="InterlacedStrips.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to add interlaced strip lines to an 
				axis, and how to set the appearance of strip lines.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" Palette="BrightPastel" BackColor="#F3DFC1" BackGradientStyle="TopBottom" BorderColor="181, 64, 1" BorderlineDashStyle="Solid" BorderWidth="2">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Interlaced Strips" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series MarkerSize="8" YValuesPerPoint="2" Name="Series1" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="2">
									<points>
										<asp:datapoint YValues="340,0" />
										<asp:datapoint YValues="760,0" />
										<asp:datapoint YValues="230,0" />
										<asp:datapoint YValues="470,0" />
										<asp:datapoint YValues="350,0" />
										<asp:datapoint YValues="840,0" />
										<asp:datapoint YValues="220,0" />
										<asp:datapoint YValues="750,0" />
									</points>
								</asp:series>
								<asp:series MarkerSize="8" YValuesPerPoint="2" Name="Series2" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="2">
									<points>
										<asp:datapoint YValues="780,0" />
										<asp:datapoint YValues="670,0" />
										<asp:datapoint YValues="100,0" />
										<asp:datapoint YValues="560,0" />
										<asp:datapoint YValues="640,0" />
										<asp:datapoint YValues="230,0" />
										<asp:datapoint YValues="560,0" />
										<asp:datapoint YValues="440,0" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy interlacedcolor="128, 255, 227, 130" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsInterlaced="True">
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
								<td class="label">Show Interlaced Strips:</td>
								<td>
									<p><asp:checkbox id="enableInterlaced" runat="server" AutoPostBack="True" Checked="True" width="127px"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label4" runat="server" Width="100px">Strip Color:</asp:label></td>
								<td><asp:dropdownlist id="KnownColors" runat="server" Width="109" Height="22" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="Wheat" Selected="True">Wheat</asp:listitem>
										<asp:listitem Value="Goldenrod">Goldenrod</asp:listitem>
										<asp:listitem Value="Gold">Gold</asp:listitem>
										<asp:listitem Value="DarkKhaki">DarkKhaki</asp:listitem>
										<asp:listitem Value="SandyBrown">SandyBrown</asp:listitem>
										<asp:listitem Value="DarkSeaGreen">DarkSeaGreen</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
