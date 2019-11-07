
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.UsingGaps3D" CodeFile="UsingGaps3D.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to adjust the PointDepth and the 
				PointGapDepth properties, which are used&nbsp;to control the&nbsp;depth of each 
				plotted series in a 3D chart area.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#F3DFC1" BorderlineDashStyle="Solid" palette="Pastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="3D Z Space Control" Alignment="TopLeft" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series2" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series3" ChartType="Area" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="40" perspective="8" enable3d="True" Inclination="18" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
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
								<td class="label">
									<asp:label id="Label7" runat="server" Width="120px">Point Depth:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="PointDepth" runat="server" AutoPostBack="True">
											<asp:listitem Value="25">25</asp:listitem>
											<asp:listitem Value="50">50</asp:listitem>
											<asp:listitem Value="100" Selected="True">100</asp:listitem>
											<asp:listitem Value="200">200</asp:listitem>
											<asp:listitem Value="500">500</asp:listitem>
											<asp:listitem Value="1000">1000</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="120px">Point Gap Depth:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="PointGapDepth" runat="server" AutoPostBack="True">
											<asp:listitem Value="20">20</asp:listitem>
											<asp:listitem Value="100" Selected="True">100</asp:listitem>
											<asp:listitem Value="200">200</asp:listitem>
											<asp:listitem Value="500">500</asp:listitem>
											<asp:listitem Value="1000">1000</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="120px">Rotate Y:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="RotateY" runat="server" AutoPostBack="True">
											<asp:listitem Value="-80">-80</asp:listitem>
											<asp:listitem Value="-60">-60</asp:listitem>
											<asp:listitem Value="-40">-40</asp:listitem>
											<asp:listitem Value="-20">-20</asp:listitem>
											<asp:listitem Value="0">0</asp:listitem>
											<asp:listitem Value="20">20</asp:listitem>
											<asp:listitem Value="30">30</asp:listitem>
											<asp:listitem Value="40" Selected="True">40</asp:listitem>
											<asp:listitem Value="60">60</asp:listitem>
											<asp:listitem Value="80">80</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
