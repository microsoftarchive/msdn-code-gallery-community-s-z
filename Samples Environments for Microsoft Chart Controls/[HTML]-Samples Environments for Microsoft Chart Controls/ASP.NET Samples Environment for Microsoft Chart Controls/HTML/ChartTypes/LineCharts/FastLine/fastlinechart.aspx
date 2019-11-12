<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FastLineChart" CodeFile="FastLineChart.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>PieChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="PieChart" method="post" runat="server">
			<p class="dscr">
				The Fast Line and Fast Point chart types significantly reduce the drawing time 
				of a series that has many data points.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<p>
							<asp:chart id="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" imagetype="Png" BackColor="WhiteSmoke" BorderWidth="2" BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="BrightPastel" BorderlineDashStyle="Solid" BorderColor="26, 59, 105" Height="296px" Width="412px">
								<titles>
									<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 12pt, style=Bold" ShadowOffset="3" Text="Two series with 20000 points each." ForeColor="26, 59, 105"></asp:title>
								</titles>
								<legends>
									<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
								</legends>
								<borderskin skinstyle="Emboss"></borderskin>
								<series>
									<asp:series Name="Series1" ChartType="FastLine" ShadowColor="Black" BorderColor="180, 26, 59, 105"></asp:series>
									<asp:series Name="Series2" ChartType="FastLine" ShadowColor="Black" BorderColor="180, 26, 59, 105" Color="224, 64, 10"></asp:series>
								</series>
								<chartareas>
									<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
										<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
										<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
											<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
											<majorgrid linecolor="64, 64, 64, 64" />
										</axisy>
										<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
											<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
											<majorgrid linecolor="64, 64, 64, 64" />
										</axisx>
									</asp:chartarea>
								</chartareas>
							</asp:chart></p>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Chart Type:</td>
								<td><asp:DropDownList id="ChartTypeList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
										<asp:ListItem Value="FastLine" Selected="True">Fast Line</asp:ListItem>
										<asp:ListItem Value="FastPoint">Fast Point</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->To optimize performance, these two 
                chart types do not use appearance properties for individual points. They do not display data point 
		markers, data point labels, or line shadows. Use the regular Line or Point chart type if 
                you wish to use these features.</p>
            <p class="dscr">To further enhance performance,&nbsp;exclude the following features from 
		a Fast chart:</p>
	<ul>
		<li>Tooltips</li>
		
		<li>
		Anti-aliasing</li>
		<li>
			Border skins</li></ul>
		</form>
	</body>
</html>
