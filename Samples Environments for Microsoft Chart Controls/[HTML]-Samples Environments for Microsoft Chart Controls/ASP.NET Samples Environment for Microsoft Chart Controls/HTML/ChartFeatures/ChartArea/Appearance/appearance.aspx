
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartAreaAppearance" CodeFile="Appearance.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to set the appearance of chart&#39;s plot 
                area.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="#D3DFF0" Palette="Pastel" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart Control for .NET Framework" Alignment="TopLeft" ForeColor="26, 59, 105" Name="Title1">
									<position Y="4" Height="8.738057" Width="80" X="4"></position>
								</asp:Title>
							</titles>
							<legends>
								<asp:Legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position Y="85" Height="5" Width="40" X="5"></position>
								</asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:DataPoint XValue="1" YValues="70" BorderColor="180, 26, 59, 105" Color="65, 140, 240" />
										<asp:DataPoint XValue="2" YValues="80" BorderColor="180, 26, 59, 105" Color="65, 140, 240" />
										<asp:DataPoint XValue="3" YValues="70" BorderColor="180, 26, 59, 105" Color="65, 140, 240" />
										<asp:DataPoint XValue="4" YValues="85" BorderColor="180, 26, 59, 105" Color="65, 140, 240" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65">
									<points>
										<asp:DataPoint XValue="1" YValues="65" BorderColor="64, 0, 0, 0" Color="252, 180, 65" />
										<asp:DataPoint XValue="2" YValues="70" BorderColor="64, 0, 0, 0" Color="252, 180, 65" />
										<asp:DataPoint XValue="3" YValues="60" BorderColor="64, 0, 0, 0" Color="252, 180, 65" />
										<asp:DataPoint XValue="4" YValues="75" BorderColor="64, 0, 0, 0" Color="252, 180, 65" />
									</points>
								</asp:Series>
								<asp:Series ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10">
									<points>
										<asp:DataPoint XValue="1" YValues="50" BorderColor="64, 0, 0, 0" Color="224, 64, 10" />
										<asp:DataPoint XValue="2" YValues="55" BorderColor="64, 0, 0, 0" Color="224, 64, 10" />
										<asp:DataPoint XValue="3" YValues="40" BorderColor="64, 0, 0, 0" Color="224, 64, 10" />
										<asp:DataPoint XValue="4" YValues="70" BorderColor="64, 0, 0, 0" Color="224, 64, 10" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom" ShadowOffset="9">
									<area3dstyle PointGapDepth="0" Rotation="5" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="13" Height="75" Width="90" X="2"></position>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
										<MajorGrid LineColor="64, 64, 64, 64" Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                        <MajorTickMark Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Interval="1">
										<LabelStyle Font="Trebuchet MS, 8.25pt" Interval="1" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
										<MajorGrid LineColor="64, 64, 64, 64" Interval="1" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
										<CustomLabels>
                                            <asp:CustomLabel FromPosition="0.5" Text="John" ToPosition="1.5" />
                                            <asp:CustomLabel FromPosition="1.5" Text="Mary" ToPosition="2.5" />
                                            <asp:CustomLabel FromPosition="2.5" Text="Jeff" ToPosition="3.5" />
                                            <asp:CustomLabel FromPosition="3.5" Text="Bob" ToPosition="4.5" />
										</CustomLabels>
                                        <MajorTickMark Interval="1" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
									</axisx>
                                    <InnerPlotPosition Height="86.60734" Width="90.64261" X="9.35739" Y="3.5" />
                                    <axisx2>
                                        <LabelStyle Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                        <MajorTickMark Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                        <MajorGrid Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                    </axisx2>
                                    <axisy2>
                                        <LabelStyle Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                        <MajorTickMark Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                        <MajorGrid Interval="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IntervalType="Auto" />
                                    </axisy2>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Primary BackColor:</td>
								<td><asp:dropdownlist id="BackColor" runat="server" Height="22px" Width="120px" AutoPostBack="True">
										<asp:ListItem Value="White">White</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Brown">Brown</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Gradient:</td>
								<td><asp:dropdownlist id="Gradient" runat="server" Height="22" Width="120px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Hatch Style:</td>
								<td><asp:dropdownlist id="HatchStyle" runat="server" Height="22" Width="120px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Secondary BackColor:</td>
								<td><asp:dropdownlist id="ForeColor" runat="server" Height="22px" Width="120px" AutoPostBack="True">
										<asp:ListItem Value="White">White</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Green" Selected="True">Green</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Brown">Brown</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Border Color:</td>
								<td><asp:dropdownlist id="BorderColor" runat="server" Height="22px" Width="120px" AutoPostBack="True">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										<asp:ListItem Value="Brown">Brown</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Border Size:</td>
								<td><asp:dropdownlist id="BorderSize" runat="server" Height="22" Width="61px" AutoPostBack="True">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Border Style:</td>
								<td><asp:dropdownlist id="BorderDashStyle" runat="server" Height="22" Width="120px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
