
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendTitle" CodeFile="LegendTitle.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LegendFont</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LegendFont" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the font and color of the 
				legend's title text.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" Palette="BrightPastel" BackColor="#F3DFC1" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend TitleFont="Trebuchet MS, 14.25pt" BackColor="Transparent" TitleSeparatorColor="64, 64, 64" Alignment="Center" ForeColor="64, 64, 64" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" TitleSeparator="Line" Name="Default" Title="Microsoft \nChart"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="200" />
										<asp:DataPoint YValues="450" />
										<asp:DataPoint YValues="300" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="154" />
										<asp:DataPoint YValues="760" />
										<asp:DataPoint YValues="345" />
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="700" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3" BorderColor="200, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="357" />
										<asp:DataPoint YValues="200" />
										<asp:DataPoint YValues="300" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="342" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 Enabled="False">
										<LabelStyle Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" Enabled="False" IntervalOffsetType="Auto" />
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
									</axisy2>
									<axisx2 Enabled="False">
										<LabelStyle Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
									</axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" LineColor="64, 64, 64, 64" Enabled="False" IntervalOffsetType="Auto" />
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" LineColor="64, 64, 64, 64" Enabled="False" IntervalOffsetType="Auto" />
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 216px">
									<p>
										<asp:label id="Label1" runat="server" Width="76px"> Title Text:</asp:label></p>
								</td>
								<td>
									<p>
										<asp:TextBox id="TextBox1" runat="server" Width="136px" cssclass="spaceright" MaxLength="20" ToolTip="To apply changes to the legend title, add text into the Title Text textbox and press Enter.">Microsoft \nChart</asp:TextBox></p>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px">
									<asp:label id="Label2" runat="server" Width="84px"> Title Color:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="ForeColor" runat="server" AutoPostBack="True" cssclass="spaceright" Width="136px">
											<asp:ListItem Value="Black">Black</asp:ListItem>
											<asp:ListItem Value="Blue">Blue</asp:ListItem>
											<asp:ListItem Value="Gray">Gray</asp:ListItem>
											<asp:ListItem Value="Orange">Orange</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px">
									<asp:label id="Label3" runat="server" Width="102px"> Title Alignment:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="TextAlignment" runat="server" AutoPostBack="True" cssclass="spaceright" Width="136px"></asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px">Title Separator:</td>
								<td>
									<asp:dropdownlist id="TitleSeparator" runat="server" Width="136px" cssclass="spaceright" AutoPostBack="True"></asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px">Separator Color:</td>
								<td>
									<asp:dropdownlist id="SeparatorColor" runat="server" Width="136px" cssclass="spaceright" AutoPostBack="True">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Orange">Orange</asp:ListItem>
										<asp:ListItem Value="Gray">Gray</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px">Legend Docking:</td>
								<td>
									<asp:dropdownlist id="LegendDocking" runat="server" Width="136px" cssclass="spaceright" AutoPostBack="True">
										<asp:ListItem Value="Right">Right</asp:ListItem>
										<asp:ListItem Value="Top">Top</asp:ListItem>
										<asp:ListItem Value="Bottom">Bottom</asp:ListItem>
										<asp:ListItem Value="Left">Left</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px"></td>
								<td>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px"></td>
								<td>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px"></td>
								<td>
								</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 216px"></td>
								<td>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
