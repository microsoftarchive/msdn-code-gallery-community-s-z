
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataBindSeriesByRows" CodeFile="DataBindSeriesByRows.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>DataBindSeriesByRows</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to add a series to the chart for each row 
				in a data set.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderlineDashStyle="Solid" Palette="BrightPastel" BorderColor="26, 59, 105" Height="296px" Width="412px" BorderWidth="2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IntervalType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" LineColor="64, 64, 64, 64" />
										<MajorTickMark IntervalType="Auto" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td><asp:datagrid id="DataGrid" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
										<alternatingitemstyle backcolor="WhiteSmoke"></alternatingitemstyle>
										<headerstyle font-bold="True" horizontalalign="Center" forecolor="White" backcolor="Gainsboro"></headerstyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">A new Series is created for each&nbsp;row, and&nbsp;each column in&nbsp;a row becomes 
				a data point Y value for that corresponding series.</p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
