<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataBindCSVFile" CodeFile="DataBindCSVFile.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapCustom</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample shows how to bind to a CSV file as the data source.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Width="412px" Height="296px" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BackSecondaryColor="White" palette="BrightPastel" BorderWidth="2" backcolor="WhiteSmoke" imagetype="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Legend1" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series XValueType="Time" Name="Series1" ChartType="Line" BorderColor="180, 26, 59, 105" Color="26, 59, 105"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle pointgapdepth="0" Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
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
			<p class="dscr">Binding to this data source is slightly different than binding 
				to an Access database. Note that the&nbsp;the columns in the CSV file are referenced by their ordinals 
                in the DataBindXY method.</p>
		</form>
	</body>
</html>
