
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Appearance" CodeFile="Appearance.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to set the appearance of axis lines.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE--><asp:chart id="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="306px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke" BorderColor="26, 59, 105">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart Control for .NET Framework" Alignment="MiddleLeft" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<axisy2 linecolor="64, 64, 64, 64" IsLabelAutoFit="False" enabled="True">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2 linecolor="64, 64, 64, 64" IsLabelAutoFit="False" enabled="False"></axisx2>
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
								<td class="label"><!-- LABELS HERE--> Visible:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:dropdownlist id="Enabled" runat="server" AutoPostBack="True" onselectedindexchanged="Enabled_SelectedIndexChanged">
										<asp:listitem Value="True">True</asp:listitem>
										<asp:listitem Value="False">False</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"><!-- LABELS HERE--> Color:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:dropdownlist id="Color1" runat="server" AutoPostBack="True">
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Blue" Selected="True">Blue</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"><!-- LABELS HERE--> Line Width:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:dropdownlist id="Width1" runat="server" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2" Selected="True">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"><!-- LABELS HERE--> Line Style:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:dropdownlist id="LineStyle1" runat="server" AutoPostBack="True">
										<asp:listitem Value="Solid">Solid</asp:listitem>
										<asp:listitem Value="Dot">Dot</asp:listitem>
										<asp:listitem Value="DashDotDot">DashDotDot</asp:listitem>
										<asp:listitem Value="DashDot">DashDot</asp:listitem>
										<asp:listitem Value="Dash">Dash</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"><!-- LABELS HERE--> Arrow:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:dropdownlist id="Arrow1" runat="server" AutoPostBack="True">
										<asp:listitem Value="None" Selected="True">None</asp:listitem>
										<asp:listitem Value="Triangle">Triangle</asp:listitem>
										<asp:listitem Value="Lines">Lines</asp:listitem>
										<asp:listitem Value="SharpTriangle">Sharp Triangle</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Note that each axis can have 
				different visual attributes, including visibility. In this sample, changes are 
                applied to the secondary Y axis.</p>
		</form>
	</body>
</html>
