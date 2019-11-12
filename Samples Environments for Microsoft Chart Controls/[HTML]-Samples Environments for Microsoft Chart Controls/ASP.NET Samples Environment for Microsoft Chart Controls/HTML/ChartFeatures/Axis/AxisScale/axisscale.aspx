<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Axis" CodeFile="AxisScale.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to use a logarithmic scale, as well as 
				how to set the minimum and maximum axis values.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x306 px)--><asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" BorderColor="26, 59, 105" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderlineDashStyle="Solid" Height="306px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderWidth="2">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Far" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default" LegendStyle="Row"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" CustomProperties="DrawingStyle=Wedge" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="550" />
										<asp:DataPoint YValues="900" />
										<asp:DataPoint YValues="1800" />
										<asp:DataPoint YValues="1500" />
										<asp:DataPoint YValues="700" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2" CustomProperties="DrawingStyle=Wedge">
									<points>
										<asp:DataPoint YValues="900" />
										<asp:DataPoint YValues="1800" />
										<asp:DataPoint YValues="1400" />
										<asp:DataPoint YValues="2000" />
										<asp:DataPoint YValues="2000" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3" CustomProperties="DrawingStyle=Wedge">
									<points>
										<asp:DataPoint YValues="1800" />
										<asp:DataPoint YValues="2400" />
										<asp:DataPoint YValues="800" />
										<asp:DataPoint YValues="550" />
										<asp:DataPoint YValues="2200" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
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
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="#" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><!-- LABEL HERE--> Logarithmic:</td>
								<td><!-- CONTROL HERE--><asp:checkbox id="Logarithmic" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label"><!-- LABEL HERE--> Auto Scale:</td>
								<td><!-- CONTROL HERE-->
									<p><asp:checkbox id="AutoScale" runat="server" AutoPostBack="True" Checked="True"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label"><!-- LABEL HERE--> Maximum:</td>
								<td><!-- CONTROL HERE-->
									<asp:dropdownlist id="Maximum" runat="server" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="3000">3000</asp:listitem>
										<asp:listitem Value="5000" Selected="True">5000</asp:listitem>
										<asp:listitem Value="10000">10000</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><!-- LABEL HERE--> Minimum:</td>
								<td><!-- CONTROL HERE-->
									<asp:dropdownlist id="Minimum" runat="server" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="250">250</asp:listitem>
										<asp:listitem Value="500">500</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><!-- LABEL HERE--></td>
								<td><!-- CONTROL HERE--></td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR --></table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
