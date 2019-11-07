
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Borders" CodeFile="Borders.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to&nbsp;set the appearance properties 
				of a chart's&nbsp;border skin.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" Palette="Pastel" BorderColor="26, 59, 105" backcolor="#D3DFF0" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2">
							<titles>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series2" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series3" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="220, 252, 180, 65" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series4" ChartType="Bar" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="220, 224, 64, 10" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle pointgapdepth="0" Rotation="17" perspective="6" enable3d="True" Inclination="14" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
										<labelstyle font="Trebuchet MS, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label8" runat="server" Width="125px">Skin Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="SkinStyle" runat="server" Height="22px" Width="121px" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" colspan="2">
									&nbsp;</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="125px"> Back Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="BackColor" runat="server" AutoPostBack="True" Height="22px" Width="121px"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="125px"> Secondary Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="ForeColor" runat="server" Height="22px" Width="121px" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="125px">Gradient:</asp:label></td>
								<td>
									<asp:dropdownlist id="Gradient" runat="server" Height="22px" Width="121px" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Width="125px">Hatch Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="HatchStyle" runat="server" Height="22px" Width="121px" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" colspan="2">
									&nbsp;</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" Width="125px">Border Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderColor" runat="server" Height="22px" Width="121px" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server" Width="125px">Border Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderSize" runat="server" Height="22px" Width="121px" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label7" runat="server" Width="125">Border Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderDashStyle" runat="server" Height="22" Width="121px" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
