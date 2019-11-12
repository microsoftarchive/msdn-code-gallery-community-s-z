<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RangeColumnChart" CodeFile="RangeColumnChart.aspx.cs" %>

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
			<p class="dscr">A Range Column chart is similar to the Column&nbsp;chart, 
				except&nbsp;the Range Column chart&nbsp;uses two Y values to define the start 
				and end position of each column.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderColor="181, 64, 1" BackColor="#F3DFC1" Palette="BrightPastel" BackGradientStyle="TopBottom" BorderlineDashStyle="Solid" BorderWidth="2">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Range Column Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default" LegendStyle="Row"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="2" Name="Series1" ChartType="RangeColumn" CustomProperties="DrawSideBySide=True" BorderColor="180, 26, 59, 105" Color="65, 140, 240">
									<points>
										<asp:DataPoint YValues="30,80" />
										<asp:DataPoint YValues="40,70" />
										<asp:DataPoint YValues="75,90" />
										<asp:DataPoint YValues="60,80" />
										<asp:DataPoint YValues="50,90" />
										<asp:DataPoint YValues="70,80" />
									</points>
								</asp:Series>
								<asp:Series YValuesPerPoint="2" Name="Series2" ChartType="RangeColumn" CustomProperties="DrawSideBySide=True" BorderColor="180, 26, 59, 105" Color="252, 180, 65">
									<points>
										<asp:DataPoint YValues="10,20" />
										<asp:DataPoint YValues="15,40" />
										<asp:DataPoint YValues="20,60" />
										<asp:DataPoint YValues="10,30" />
										<asp:DataPoint YValues="30,40" />
										<asp:DataPoint YValues="10,70" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<axisy2 Enabled="True">
										<LabelStyle Enabled="False" />
										<MajorGrid Enabled="False" />
										<MajorTickMark Enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" PointDepth="200" IsRightAngleAxes="False" WallWidth="0" />
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
					<td valign="top" style="WIDTH: 310px">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									Show Side-by-Side:</td>
								<td><asp:CheckBox id="CheckboxShowSideBySide" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="checkBoxShow3D" tabIndex="6" runat="server" AutoPostBack="True" Text="" Checked="True"></asp:checkbox></td>
							</tr>
							<tr>
								<TD class="label">Drawing Style:</td>
								<td>
									<asp:DropDownList id="DrawingStyleList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
										<asp:ListItem Value="Default">Default</asp:ListItem>
										<asp:ListItem Value="Emboss">Emboss</asp:ListItem>
										<asp:ListItem Value="Cylinder">Cylinder</asp:ListItem>
										<asp:ListItem Value="Wedge">Wedge</asp:ListItem>
										<asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
