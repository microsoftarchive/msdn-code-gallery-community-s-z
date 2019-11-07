<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendFont" CodeFile="LegendFont.aspx.cs" %>

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
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the font and color of the 
				legend's text.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BackColor="#D3DFF0" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" Name="Default" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" CustomProperties="PieDrawingStyle=SoftEdge">
									<points>
										<asp:DataPoint CustomProperties="Exploded=true" Label="Canada" YValues="400" />
										<asp:DataPoint Label="Other" YValues="200" />
										<asp:DataPoint Label="Ireland" YValues="700" />
										<asp:DataPoint Label="England" YValues="300" />
										<asp:DataPoint Label="Australia" YValues="450" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackColor="Transparent" ShadowColor="Transparent">
									<axisy2>
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2>
										<majorgrid enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Microsoft Sans Serif, 8.25pt, style=Bold" linecolor="64, 64, 64, 64">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<p>
										<asp:label id="Label1" runat="server" Width="50px"> Name:</asp:label></p>
								</td>
								<td>
									<p>
										<asp:dropdownlist id="FontNameList" runat="server" AutoPostBack="True" width="132px" cssclass="spaceright">
											<asp:ListItem Value="Trebuchet MS" Selected="True">Trebuchet MS</asp:ListItem>
											<asp:ListItem Value="Arial">Arial</asp:ListItem>
											<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
											<asp:ListItem Value="Verdana">Verdana</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="50px"> Size:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="FontSizeList" runat="server" AutoPostBack="True" cssclass="spaceright">
											<asp:ListItem Value="8">8</asp:ListItem>
											<asp:ListItem Value="10" Selected="True">10</asp:ListItem>
											<asp:ListItem Value="12">12</asp:ListItem>
											<asp:ListItem Value="14">14</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Width="50px"> Color:</asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="ForeColorList" runat="server" AutoPostBack="True" cssclass="spaceright">
											<asp:ListItem Value="Black" Selected="True">Black</asp:ListItem>
											<asp:ListItem Value="Blue">Blue</asp:ListItem>
											<asp:ListItem Value="Red">Red</asp:ListItem>
											<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
											<asp:ListItem Value="Magenta">Magenta</asp:ListItem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">Italic:</td>
								<td>
									<asp:checkbox id="Italic" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">Underline:</td>
								<td>
									<asp:checkbox id="Underline" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">Bold:</td>
								<td>
									<asp:checkbox id="Bold" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">Strikeout:</td>
								<td>
									<asp:checkbox id="Strikeout" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
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
