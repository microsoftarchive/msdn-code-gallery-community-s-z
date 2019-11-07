<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BarColumnChart" CodeFile="BarColumnChart.aspx.cs" %>

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
			<p class="dscr">
				This sample demonstrates the Column and Bar chart types.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="#F3DFC1" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Column Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="DateTime" Name="Series1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint XValue="36890" YValues="32" />
										<asp:DataPoint XValue="36891" YValues="56" />
										<asp:DataPoint XValue="36892" YValues="35" />
										<asp:DataPoint XValue="36893" YValues="12" />
										<asp:DataPoint XValue="36894" YValues="35" />
										<asp:DataPoint XValue="36895" YValues="6" />
										<asp:DataPoint XValue="36896" YValues="23" />
									</points>
								</asp:Series>
								<asp:Series XValueType="DateTime" Name="Series2" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint XValue="36890" YValues="67" />
										<asp:DataPoint XValue="36891" YValues="24" />
										<asp:DataPoint XValue="36892" YValues="12" />
										<asp:DataPoint XValue="36893" YValues="8" />
										<asp:DataPoint XValue="36894" YValues="46" />
										<asp:DataPoint XValue="36895" YValues="14" />
										<asp:DataPoint XValue="36896" YValues="76" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="C0" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" Format="MM-dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Chart Type:</td>
								<td>
									<asp:dropdownlist id="ChartType" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Column">Column</asp:ListItem>
										<asp:ListItem Value="Bar">Bar</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Point Width:</td>
								<td><asp:dropdownlist id="BarWidthList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="120px">
										<asp:ListItem Value="1.0">1.0</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.6">0.6</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label">Drawing Style:</td>
								<td>
									<asp:dropdownlist id="DrawingStyle" runat="server" Width="120px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="Emboss">Emboss</asp:ListItem>
										<asp:ListItem Value="Cylinder">Cylinder</asp:ListItem>
										<asp:ListItem Value="Wedge">Wedge</asp:ListItem>
										<asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td>
									<asp:CheckBox id="Show3D" tabIndex="6" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
