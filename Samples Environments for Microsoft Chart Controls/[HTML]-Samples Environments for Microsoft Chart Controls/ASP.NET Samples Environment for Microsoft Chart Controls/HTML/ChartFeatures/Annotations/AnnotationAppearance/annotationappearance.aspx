    
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AnnotationAppearance" CodeFile="AnnotationAppearance.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Annotation</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LegendCustomPosition" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the appearance properties of an 
                Annotation object.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" width="412"><asp:CHART id="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="#D3DFF0" Palette="BrightPastel" BackGradientStyle="TopBottom" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" Height="296px" Width="412px" BorderWidth="2" ImageType="Png">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="800" />
										<asp:DataPoint YValues="450" />
										<asp:DataPoint YValues="700" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65">
									<points>
										<asp:DataPoint YValues="450" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="600" />
									</points>
								</asp:Series>
							</series>
							<Annotations>
								<asp:CalloutAnnotation AnchorDataPointName="Default\r0" AnchorOffsetY="7" CalloutStyle="Cloud" Text="Set my Appearance" Name="CloudAnnotation" AnchorOffsetX="5"></asp:CalloutAnnotation>
							</Annotations>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 Enabled="False">
										<MajorGrid Enabled="False" />
									</axisy2>
									<axisx2 Enabled="False"></axisx2>
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Font Face:</td>
								<td><asp:dropdownlist id="FontNameList" runat="server" Height="24px" Width="134px" AutoPostBack="True">
										<asp:ListItem Value="Arial">Arial</asp:ListItem>
										<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
										<asp:ListItem Value="Microsoft Sans Serif" Selected="True">Microsoft Sans Serif</asp:ListItem>
										<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
										<asp:ListItem Value="Verdana">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Font Size:</td>
								<td><asp:dropdownlist id="FontSizeList" runat="server" Height="24px" Width="134px" AutoPostBack="True">
										<asp:ListItem Value="8" Selected="True">8</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="12">12</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Font Color:</td>
								<td><asp:dropdownlist id="ForeColorList" runat="server" Height="24px" Width="134px" AutoPostBack="True">
										<asp:ListItem Value="Black" Selected="True">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Border Color:</td>
								<td><asp:dropdownlist id="BorderColor" runat="server" Height="24px" Width="134px" AutoPostBack="True">
										<asp:ListItem Value="Black" Selected="True">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Transparent">Transparent</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Back Color:</td>
								<td><asp:dropdownlist id="BackColor" runat="server" Height="24px" Width="134px" AutoPostBack="True">
										<asp:ListItem Value="Lime">Lime</asp:ListItem>
										<asp:ListItem Value="Beige">Beige</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Gainsboro" Selected="True">White</asp:ListItem>
										<asp:ListItem Value="Gainsboro" >Gainsboro</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Shadow:</td>
								<td><asp:dropdownlist id="ShadowOffset" runat="server" Height="22" Width="63px" AutoPostBack="True">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4" Selected="True">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Tooltip:</td>
								<td><asp:textbox id="Tooltip" runat="server" Height="24" Width="132px" AutoPostBack="True">Chart Annotations!</asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
