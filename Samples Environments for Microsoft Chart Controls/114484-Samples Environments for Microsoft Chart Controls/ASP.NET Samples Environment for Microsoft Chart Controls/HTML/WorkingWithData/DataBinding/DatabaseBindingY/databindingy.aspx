<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.DataBindingY" CodeFile="DataBindingY.aspx.cs" %>

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
			<p class="dscr">This sample shows how to bind data to&nbsp;a chart series using the DataBindY 
				method.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" Width="412px" Height="296px" BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Databinding Y Yalues" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" ChartArea="ChartArea1" Name="Default" ChartType="Bar" BorderColor="180, 26, 59, 105" Font="Trebuchet MS, 8.25pt, style=Bold" LabelFormat="0,k"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="64, 0, 0, 0" BackGradientStyle="TopBottom">
									<axisy2 Enabled="False"></axisy2>
									<axisx2 Enabled="False"></axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="0,k" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
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
			<p class="dscr">The Y data&nbsp;value&nbsp;is bound to the chart using OleDb 
				and&nbsp;an Access database, and&nbsp;the data is selected using a simple SQL 
				query.&nbsp;</p>
		</form>
	</body>
</html>
