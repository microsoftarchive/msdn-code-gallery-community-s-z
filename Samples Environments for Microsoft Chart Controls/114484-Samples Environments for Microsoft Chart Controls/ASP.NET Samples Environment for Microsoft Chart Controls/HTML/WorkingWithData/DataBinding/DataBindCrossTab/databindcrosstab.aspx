
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataBindCrossTable" CodeFile="DataBindCrossTab.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to bind to a data source by grouping values in 
				a series, using unique values from a specified field.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Width="412px" Height="296px" BorderColor="181, 64, 1" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" imagetype="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
							<legends>
								<asp:legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="10" height="73" width="89.43796" x="4.824818"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid interval="Auto" linecolor="64, 64, 64, 64" />
										<majortickmark interval="1" enabled="False" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="1" />
										<majorgrid interval="Auto" linecolor="64, 64, 64, 64" />
										<majortickmark interval="1" enabled="False" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Group series By:</td>
								<td>
									<asp:dropdownlist id="DropDownListGroupBy" runat="server" AutoPostBack="True">
										<asp:listitem Value="Name" Selected="True">Name</asp:listitem>
										<asp:listitem Value="Year">Year</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 60px">
									<asp:datagrid id="DataGrid" runat="server">
										<headerstyle backcolor="Snow" bordercolor="LightSalmon" borderstyle="Solid" borderwidth="1"></headerstyle>
									</asp:datagrid>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Series are created automatically, based on the number of unique 
				values in the grouping field.</p>
		</form>
	</body>
</html>
