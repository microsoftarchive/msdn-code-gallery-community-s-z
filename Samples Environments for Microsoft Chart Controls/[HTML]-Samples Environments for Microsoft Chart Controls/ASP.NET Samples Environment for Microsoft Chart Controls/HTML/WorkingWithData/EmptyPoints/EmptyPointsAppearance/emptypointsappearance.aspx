
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.EmptyPointsAppearance" CodeFile="EmptyPointsAppearance.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>EmptyPointsAppearance</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates one method of&nbsp;setting empty points, 
				and also shows how&nbsp;to set the visual attributes of the empty points.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series BorderWidth="2" Name="Default" ChartType="Line" BorderColor="180, 26, 59, 105" ShadowOffset="1">
									<points>
										<asp:datapoint YValues="400" />
										<asp:datapoint YValues="600" />
										<asp:datapoint YValues="1700" />
										<asp:datapoint YValues="3000" />
										<asp:datapoint YValues="950" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False">
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2 enabled="False">
										<majorgrid enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Microsoft Sans Serif, 10pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" format="#" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server">Empty Points Value:</asp:label></td>
								<td>
									<asp:dropdownlist id="EmptyValueList" runat="server" AutoPostBack="True" width="126px" height="126px">
										<asp:listitem Value="Average" Selected="True">Average</asp:listitem>
										<asp:listitem Value="Zero">Zero</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server">Empty Point Appearance:</asp:label></td>
								<td>
									<asp:dropdownlist id="EmptyPointAppearanceList" runat="server" AutoPostBack="True" height="126px">
										<asp:listitem Value="Transparent">Transparent</asp:listitem>
										<asp:listitem Value="Line" Selected="True">Line</asp:listitem>
										<asp:listitem Value="Marker">Marker</asp:listitem>
										<asp:listitem Value="Line and Marker">Line and Marker</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" colspan="2"></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server">Line Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="LineDashStyle" runat="server" AutoPostBack="True" width="125px" height="126px"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server">Line Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="LineColor" runat="server" AutoPostBack="True" width="126px" height="126px">
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="DarkGray">DarkGray</asp:listitem>
										<asp:listitem Value="Navy" Selected="True">Navy</asp:listitem>
										<asp:listitem Value="White">White</asp:listitem>
										<asp:listitem Value="Black">Black</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server">Line Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="LineSize" runat="server" AutoPostBack="True" width="125px" height="126px">
										<asp:listitem Value="1" Selected="True">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" colspan="2"></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server">Marker Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="MarkerStyleList" runat="server" AutoPostBack="True" width="124px" height="126px"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label7" runat="server">Marker Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="MarkerColor" runat="server" AutoPostBack="True" width="124px" height="126px">
										<asp:listitem Value="Red" Selected="True">Red</asp:listitem>
										<asp:listitem Value="DarkGray">DarkGray</asp:listitem>
										<asp:listitem Value="Navy">Navy</asp:listitem>
										<asp:listitem Value="White">White</asp:listitem>
										<asp:listitem Value="Black">Black</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label8" runat="server">Marker Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="MarkerSize" runat="server" AutoPostBack="True" width="125px" height="126px">
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="9" Selected="True">9</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
										<asp:listitem Value="18">18</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">The custom attribute EmptyPointValue determines if&nbsp;empty 
				points are treated as zeros or as an average value between neighboring points.</p>
		</form>
	</body>
</html>
