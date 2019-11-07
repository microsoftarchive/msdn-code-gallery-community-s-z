
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AxisTitle" CodeFile="AxisTitle.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to set the appearance of the axis 
                title.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE--><asp:chart id="Chart1" runat="server" Height="306px" Width="412px" BorderlineDashStyle="Solid" palette="Pastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:title Visible="False" ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart for .NET" Alignment="TopLeft" ForeColor="26, 59, 105">
									<position y="4" height="8.738057" width="55" x="4"></position>
								</asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10">
									<points>
										<asp:datapoint XValue="1" YValues="50" />
										<asp:datapoint XValue="2" YValues="55" />
										<asp:datapoint XValue="3" YValues="40" />
										<asp:datapoint XValue="4" YValues="70" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 IsLabelAutoFit="False" enabled="True">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									</axisy2>
									<axisx2 IsLabelAutoFit="False" enabled="True">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									</axisx2>
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="13" height="75" width="90" x="2"></position>
									<axisy titlefont="Microsoft Sans Serif, 8.25pt" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Microsoft Sans Serif, 8.25pt" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
										<labelstyle font="Trebuchet MS, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<customlabels>
											<asp:customlabel Text="John" ToPosition="1.5" FromPosition="0.5"></asp:customlabel>
											<asp:customlabel Text="Mary" ToPosition="2.5" FromPosition="1.5"></asp:customlabel>
											<asp:customlabel Text="Jeff" ToPosition="3.5" FromPosition="2.5"></asp:customlabel>
											<asp:customlabel Text="Bob" ToPosition="4.5" FromPosition="3.5"></asp:customlabel>
										</customlabels>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><!-- LABELS HERE--> Axis Title:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:textbox id="TitleText" runat="server" Height="24" autopostback="True" cssclass="spaceright">Axis Title</asp:textbox></td>
							</tr>
							<tr>
								<td class="label">Position:
								</td>
								<td><!-- CONTROLS HERE--><asp:dropdownlist id="Position" runat="server" Height="22" Width="109" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="0">Axis X</asp:listitem>
										<asp:listitem Value="1">Axis Y</asp:listitem>
										<asp:listitem Value="2">Axis X2</asp:listitem>
										<asp:listitem Value="3">Axis Y2</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Title Font Size:
								</td>
								<td><!-- CONTROLS HERE--><asp:dropdownlist id="TitleSize" runat="server" Height="22" Width="109" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="8">8</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="12" Selected="True">12</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="HEIGHT: 24px">
									Title Font:
								</td>
								<td style="HEIGHT: 24px"><!-- CONTROLS HERE--><asp:dropdownlist id="Font1" runat="server" Height="22" Width="109" AutoPostBack="True" cssclass="spaceright"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="HEIGHT: 9px">
									Title Color:
								</td>
								<td style="HEIGHT: 9px"><!-- CONTROLS HERE-->
									<asp:dropdownlist id="Color1" runat="server" Height="22" Width="109" AutoPostBack="True" cssclass="spaceright">
										<asp:listitem Value="Black">Black</asp:listitem>
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="HEIGHT: 18px">
									Italic:
								</td>
								<td style="HEIGHT: 18px"><!-- CONTROLS HERE-->
									<asp:checkbox id="Italic" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">
									Bold:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:checkbox id="Bold" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">
									Underline:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:checkbox id="Underline" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">
									Strikeout:
								</td>
								<td><!-- CONTROLS HERE-->
									<asp:checkbox id="Strikeout" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
