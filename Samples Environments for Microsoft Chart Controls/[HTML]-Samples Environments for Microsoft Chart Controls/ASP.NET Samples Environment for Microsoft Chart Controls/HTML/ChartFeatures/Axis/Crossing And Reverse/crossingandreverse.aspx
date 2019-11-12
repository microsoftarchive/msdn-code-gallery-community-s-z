<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CrossingAndReverse" CodeFile="CrossingAndReverse.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to use the&nbsp;Crossing and Reverse 
				properties of an axis.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="306px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#F3DFC1" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Far" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default" LegendStyle="Row"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Default" CustomProperties="DrawingStyle=Emboss" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="550" />
										<asp:DataPoint YValues="900" />
										<asp:DataPoint YValues="1800" />
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="1500" />
									</points>
								</asp:Series>
								<asp:Series XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Emboss" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="900" />
										<asp:DataPoint YValues="1800" />
										<asp:DataPoint YValues="1400" />
										<asp:DataPoint YValues="1600" />
										<asp:DataPoint YValues="2000" />
									</points>
								</asp:Series>
								<asp:Series XValueType="Double" Name="Series3" CustomProperties="DrawingStyle=Emboss" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint YValues="1800" />
										<asp:DataPoint YValues="2400" />
										<asp:DataPoint YValues="800" />
										<asp:DataPoint YValues="2200" />
										<asp:DataPoint YValues="550" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 Enabled="False">
										<MajorGrid Enabled="False" />
									</axisy2>
									<axisx2 Enabled="False">
										<MajorGrid Enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx TitleFont="Microsoft Sans Serif, 10pt, style=Bold" LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="N0" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Crossing X Axis:
								</td>
								<td>
									<asp:dropdownlist id="CrossingX" runat="server" AutoPostBack="True" width="92px" cssclass="spaceright">
										<asp:ListItem Value="Auto">Auto</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="Maximum">Maximum</asp:ListItem>
										<asp:ListItem Value="Minimum">Minimum</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Crossing Y Axis:
								</td>
								<td>
									<asp:dropdownlist id="CrossingY" runat="server" AutoPostBack="True" width="92px" cssclass="spaceright">
										<asp:ListItem Value="Auto">Auto</asp:ListItem>
										<asp:ListItem Value="1000">1000</asp:ListItem>
										<asp:ListItem Value="1500">1500</asp:ListItem>
										<asp:ListItem Value="2000">2000</asp:ListItem>
										<asp:ListItem Value="Maximum">Maximum</asp:ListItem>
										<asp:ListItem Value="Minimum">Minimum</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Reverse X Axis:</td>
								<td>
									<asp:checkbox id="ReverseXAxis" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">Reverse Y Axis:</td>
								<td>
									<asp:checkbox id="ReverseYAxis" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">Chart type:
								</td>
								<td>
									<asp:dropdownlist id="ChartType" runat="server" AutoPostBack="True" width="90px" cssclass="spaceright">
										<asp:listitem Value="Column">Column</asp:listitem>
										<asp:listitem Value="Bar">Bar</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
