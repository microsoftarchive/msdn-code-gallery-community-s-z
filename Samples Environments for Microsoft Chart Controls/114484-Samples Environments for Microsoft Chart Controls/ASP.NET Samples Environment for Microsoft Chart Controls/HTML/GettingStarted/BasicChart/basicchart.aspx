<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BasicChart" CodeFile="BasicChart.aspx.cs" %>

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
		<p class="dscr">This sample demonstrates how to create a basic chart that uses a 
			code-behind page.&nbsp;</p>
		<table class="sampleTable">
			<tr>
				<td class="tdchart">
					<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Palette="BrightPastel" imagetype="Png" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105">
						<legends>
							<asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
						</legends>
						<borderskin skinstyle="Emboss"></borderskin>
						<series>
							<asp:Series Name="Column" BorderColor="180, 26, 59, 105">
								<points>
									<asp:DataPoint YValues="45" />
									<asp:DataPoint YValues="34" />
									<asp:DataPoint YValues="67" />
									<asp:DataPoint YValues="31" />
									<asp:DataPoint YValues="27" />
									<asp:DataPoint YValues="87" />
									<asp:DataPoint YValues="45" />
									<asp:DataPoint YValues="32" />
								</points>
							</asp:Series>
						</series>
						<chartareas>
							<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
								<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
								<axisy linecolor="64, 64, 64, 64">
									<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									<majorgrid linecolor="64, 64, 64, 64" />
								</axisy>
								<axisx linecolor="64, 64, 64, 64">
									<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
									<majorgrid linecolor="64, 64, 64, 64" />
								</axisx>
							</asp:ChartArea>
						</chartareas>
					</asp:chart></td>
				<td valign="top">
					<table class="controls" cellpadding="4">
						<tr>
							<td class="label"></td>
							<td></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<p class="dscr">A column chart is&nbsp;added at design-time (see the &quot;Html&quot; tab folder 
            for ASP.NET code) and the spline chart is added to the Chart control at run-time 
            (see the &quot;C# Source&quot; or &quot;Visual Basic Source&quot; tab folders for the code-behind.)</p>
        <p class="dscr">It is recommended that you use code-behind for your ASP.NET pages 
            when using the Chart control. This separates the user interface and its logic.</p>
	</body>
</html>
