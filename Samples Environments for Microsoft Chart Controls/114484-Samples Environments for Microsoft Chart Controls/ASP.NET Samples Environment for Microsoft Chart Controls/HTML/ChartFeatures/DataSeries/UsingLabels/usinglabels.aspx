<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.UsingLabels" CodeFile="UsingLabels.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LabelsTextStyle</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LabelsTextStyle" method="post" runat="server">
			<p class="dscr">This sample shows how to set&nbsp;the font,&nbsp;angle, and color 
				of data point&nbsp;labels.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="Pastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" imagetype="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart Control for .NET Framework" Alignment="TopLeft" ForeColor="26, 59, 105">
									<position y="4" height="8.738057" width="80" x="4"></position>
								</asp:title>
							</titles>
							<legends>
								<asp:legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
									<position y="85" height="5" width="40" x="5"></position>
								</asp:legend>
								<asp:legend Enabled="False" Name="Legend2"></asp:legend>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" Name="Legend3" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
									<customitems>
										<asp:legenditem Name="Previous Month Avg" Color="65, 140, 240"></asp:legenditem>
										<asp:legenditem Name="Last Week" Color="252, 180, 65"></asp:legenditem>
										<asp:legenditem Name="This Week" Color="224, 64, 10"></asp:legenditem>
									</customitems>
									<position y="85" height="12" width="90" x="5"></position>
								</asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series IsValueShownAsLabel="True" ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" Font="Trebuchet MS, 8.25pt, style=Bold" Legend="Legend2" YValueType="Double">
									<points>
										<asp:datapoint XValue="1" YValues="70" />
										<asp:datapoint XValue="2" YValues="80" />
										<asp:datapoint XValue="3" YValues="70" />
										<asp:datapoint XValue="4" YValues="85" />
									</points>
								</asp:series>
								<asp:series IsValueShownAsLabel="True" ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65" Font="Trebuchet MS, 8.25pt, style=Bold">
									<points>
										<asp:datapoint XValue="1" YValues="65" />
										<asp:datapoint XValue="2" YValues="70" />
										<asp:datapoint XValue="3" YValues="60" />
										<asp:datapoint XValue="4" YValues="75" />
									</points>
								</asp:series>
								<asp:series IsValueShownAsLabel="True" ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10" Font="Trebuchet MS, 8.25pt, style=Bold">
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
									<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="13" height="75" width="90" x="2"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">
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
								<td class="label">
									<asp:label id="Label4" runat="server" Width="90px"> Position:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="LabelPosition" runat="server" AutoPostBack="True">
											<asp:listitem Value="Top" Selected="True">Top</asp:listitem>
											<asp:listitem Value="Bottom">Bottom</asp:listitem>
											<asp:listitem Value="Center">Center</asp:listitem>
											<asp:listitem Value="Left">Left</asp:listitem>
											<asp:listitem Value="Right">Right</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Width="90px"> Font Name:</asp:label></td>
								<td>
									<asp:dropdownlist id="FontNameList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Trebuchet MS" Selected="True">Trebuchet MS</asp:listitem>
										<asp:listitem Value="Courier New">Courier New</asp:listitem>
										<asp:listitem Value="Microsoft Sans Serif">Microsoft Sans Serif</asp:listitem>
										<asp:listitem Value="Times New Roman">Times New Roman</asp:listitem>
										<asp:listitem Value="Verdana">Verdana</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="90px"> Font Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="FontSizeList" runat="server" AutoPostBack="True" Width="40px">
										<asp:listitem Value="6">6</asp:listitem>
										<asp:listitem Value="8" Selected="True">8</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="12">12</asp:listitem>
										<asp:listitem Value="14">14</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" Height="19px" Width="90px">Font Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="ForeColor" runat="server" AutoPostBack="True" Height="22px" Width="95px">
										<asp:listitem Value="Black" Selected="True">Black</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Magenta">Magenta</asp:listitem>
										<asp:listitem Value="Brown">Brown</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="90px">Label Angle:</asp:label></td>
								<td>
									<asp:dropdownlist id="FontAngleList" runat="server" AutoPostBack="True">
										<asp:listitem Value="0" Selected="True">0</asp:listitem>
										<asp:listitem Value="30">30</asp:listitem>
										<asp:listitem Value="45">45</asp:listitem>
										<asp:listitem Value="60">60</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
										<asp:listitem Value="-30">-30</asp:listitem>
										<asp:listitem Value="-45">-45</asp:listitem>
										<asp:listitem Value="-60">-60</asp:listitem>
										<asp:listitem Value="-90">-90</asp:listitem>
										<asp:listitem></asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label10" runat="server" Height="19px" Width="90px">Back Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="BackColorList" runat="server" AutoPostBack="True" Height="22px" Width="146px">
										<asp:listitem Value="Transparent" Selected="True">Transparent</asp:listitem>
										<asp:listitem Value="Beige">Beige</asp:listitem>
										<asp:listitem Value="White">White</asp:listitem>
										<asp:listitem Value="AliceBlue">AliceBlue</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label11" runat="server" Height="19px" Width="90px">Border Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderColorList" runat="server" AutoPostBack="True" Height="22px" Width="146px">
										<asp:listitem Value="Transparent" Selected="True">Transparent</asp:listitem>
										<asp:listitem Value="Black">Black</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="Gray">Gray</asp:listitem>
										<asp:listitem Value="Red">Red</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label12" runat="server" Height="19px" Width="90px">Border Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="BorderSizeList" runat="server" AutoPostBack="True" Height="22px" Width="40px">
										<asp:listitem Value="1" Selected="True">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				Note that&nbsp;these properties can be applied to all&nbsp;data points in a 
				series&nbsp;or&nbsp;to a single data point.</p>
		</form>
	</body>
</html>
