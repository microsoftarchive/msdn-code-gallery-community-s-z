<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.StackedChart" CodeFile="StackedChart.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates Stacked Area, Stacked Bar, Stacked Column, 100% Stacked Area, 
                100% Stacked Bar, and 100% Stacked Column chart types.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" BackColor="#D3DFF0" Palette="BrightPastel" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>							
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Series1" ChartType="StackedArea100" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
								<asp:Series Name="Series2" ChartType="StackedArea100" BorderColor="180, 26, 59, 105" Color="220, 252, 180, 65"></asp:Series>
								<asp:Series Name="Series3" ChartType="StackedArea100" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10"></asp:Series>
								<asp:Series Name="Series4" ChartType="StackedArea100" BorderColor="180, 26, 59, 105" Color="220, 5, 100, 146"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Inclination="15" WallWidth="0" />
									<position Y="3" Height="92" Width="92" X="2"></position>
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
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
								<td><asp:DropDownList id="ChartTypeList" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="StackedBar" Selected="True">StackedBar</asp:ListItem>
										<asp:ListItem Value="StackedColumn">StackedColumn</asp:ListItem>
										<asp:ListItem Value="StackedArea">StackedArea</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">100% Stacked:</td>
								<td><asp:CheckBox id="HundredPercentStacked" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show Point Labels:</td>
								<td><asp:CheckBox id="ShowLabels" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" Text="" AutoPostBack="True" Checked="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="checkBoxShow3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Grouped:</td>
								<td>
									<asp:checkbox id="checkBoxGrouped" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--> When using the Stacked bar or 
				Stacked column types, you can group different series into separate groups by 
				setting the StackedGroupName custom attribute.</p>
		</form>
	</body>
</html>
