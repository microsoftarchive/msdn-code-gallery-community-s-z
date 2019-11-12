<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Perspectives3D" CodeFile="3DPerspectives.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates perspective and rotation&nbsp;for 
				a&nbsp;3D chart area.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" palette="Pastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="3D Rotation and Perspective" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position Y="85" Height="5" Width="40" X="5"></position>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="Double" Name="Series2" ChartType="Area" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="70" />
										<asp:DataPoint XValue="2" YValues="80" />
										<asp:DataPoint XValue="3" YValues="70" />
										<asp:DataPoint XValue="4" YValues="85" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series3" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65">
									<points>
										<asp:DataPoint XValue="1" YValues="65" />
										<asp:DataPoint XValue="2" YValues="70" />
										<asp:DataPoint XValue="3" YValues="60" />
										<asp:DataPoint XValue="4" YValues="75" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series4" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10">
									<points>
										<asp:DataPoint XValue="1" YValues="50" />
										<asp:DataPoint XValue="2" YValues="55" />
										<asp:DataPoint XValue="3" YValues="40" />
										<asp:DataPoint XValue="4" YValues="70" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle PointGapDepth="0" Perspective="30" Enable3D="True" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Interval="1">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label3" runat="server">Perspective:</asp:label></td>
								<td>
									<p dir="ltr" style="MARGIN-RIGHT: 0px"><asp:dropdownlist id="Perspective" runat="server" Width="60px" AutoPostBack="True" onselectedindexchanged="Perspective_SelectedIndexChanged">
											<asp:ListItem Value="0">0</asp:ListItem>
											<asp:ListItem Value="10">10</asp:ListItem>
											<asp:ListItem Value="20">20</asp:ListItem>
											<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
											<asp:ListItem Value="40">40</asp:ListItem>
											<asp:ListItem Value="60">60</asp:ListItem>
											<asp:ListItem Value="80">80</asp:ListItem>
											<asp:ListItem Value="100">100</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Rotate X:</asp:label></td>
								<td>
									<p dir="ltr" style="MARGIN-RIGHT: 0px"><asp:dropdownlist id="Inclination" runat="server" Width="60px" AutoPostBack="True" onselectedindexchanged="XAngle_SelectedIndexChanged">
											<asp:ListItem Value="-90">-90</asp:ListItem>
											<asp:ListItem Value="-70">-70</asp:ListItem>
											<asp:ListItem Value="-50">-50</asp:ListItem>
											<asp:ListItem Value="-30">-30</asp:ListItem>
											<asp:ListItem Value="-10">-10</asp:ListItem>
											<asp:ListItem Value="0">0</asp:ListItem>
											<asp:ListItem Value="10">10</asp:ListItem>
											<asp:ListItem Value="15">15</asp:ListItem>
											<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
											<asp:ListItem Value="50">50</asp:ListItem>
											<asp:ListItem Value="70">70</asp:ListItem>
											<asp:ListItem Value="90">90</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server">Rotate Y:</asp:label></td>
								<td>
									<p dir="ltr" style="MARGIN-RIGHT: 0px"><asp:dropdownlist id="Rotation" runat="server" Width="60px" AutoPostBack="True" onselectedindexchanged="YAngle_SelectedIndexChanged">
											<asp:ListItem Value="-110">-110</asp:ListItem>
											<asp:ListItem Value="-90">-90</asp:ListItem>
											<asp:ListItem Value="-70">-70</asp:ListItem>
											<asp:ListItem Value="-50">-50</asp:ListItem>
											<asp:ListItem Value="-30">-30</asp:ListItem>
											<asp:ListItem Value="-10">-10</asp:ListItem>
											<asp:ListItem Value="0">0</asp:ListItem>
											<asp:ListItem Value="5">5</asp:ListItem>
											<asp:ListItem Value="10">10</asp:ListItem>
											<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
											<asp:ListItem Value="50">50</asp:ListItem>
											<asp:ListItem Value="70">70</asp:ListItem>
											<asp:ListItem Value="90">90</asp:ListItem>
											<asp:ListItem Value="110">110</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
