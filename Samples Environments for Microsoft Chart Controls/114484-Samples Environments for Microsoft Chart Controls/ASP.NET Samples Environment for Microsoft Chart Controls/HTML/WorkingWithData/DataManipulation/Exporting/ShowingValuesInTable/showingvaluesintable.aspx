<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ShowinfValuesInTable" CodeFile="ShowingValuesInTable.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ShowinfValuesInTable</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates&nbsp;how a series' values can be exported 
				into a DataSet object and then displayed in a Table control. Table cells are 
				automatically aligned with data points.</p>
			<table id="Table1" cellspacing="7" cellpadding="1" border="0">
				<tr>
					<td valign="top" align="left">
						<asp:chart id="Chart1" runat="server" Palette="BrightPastel" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="600px" Height="200px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke" BorderColor="26, 59, 105">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series Name="Series1" BorderColor="180, 26, 59, 105"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top" align="left" width="160">
					</td>
				</tr>
			</table>
			<asp:table id="ValuesTable" runat="server" GridLines="Both" CellSpacing="0" CellPadding="0" Font-Names="Microsoft Sans Serif" Font-Size="Smaller" BorderWidth="1px"></asp:table>
		</form>
	</body>
</html>
