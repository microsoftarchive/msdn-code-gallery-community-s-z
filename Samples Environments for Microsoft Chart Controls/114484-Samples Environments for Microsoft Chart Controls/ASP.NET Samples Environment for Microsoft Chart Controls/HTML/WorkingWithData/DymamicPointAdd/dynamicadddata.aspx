<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DynamicAddData" CodeFile="DynamicAddData.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>ImageMapCustom</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
  </head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample shows how to assign data to&nbsp;a 
data&nbsp;series at run-time.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackColor="WhiteSmoke" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<titles>
<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Dynamic Data" Alignment="MiddleLeft" ForeColor="26, 59, 105"></asp:Title>
</titles>

<legends>
<asp:Legend IsTextAutoFit="False" DockedToChartArea="ChartArea1" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series BorderWidth="2" ChartArea="ChartArea1" Name="Channel 1" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:Series>
<asp:Series BorderWidth="2" ChartArea="ChartArea1" Name="Channel 2" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<axisy2 enabled="False">
</axisy2>

<axisx2 enabled="False">
</axisx2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx IsMarginVisible="False" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

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
			<p class="dscr">Each Y value is calculated using the Sin 
function, and&nbsp;new data points&nbsp;with the specified&nbsp; X and Y values 
are added to the series&nbsp;using the AddXY method of the Series.Points 
collection property.</p>
		</form>
	</body>
</html>
