<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LogarithmicScale" CodeFile="LogarithmicScale.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to use a logarithmic scale and a logarithmic base.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x306 px)--><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Series1" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="2600" />
										<asp:DataPoint YValues="1700" />
										<asp:DataPoint YValues="3000" />
										<asp:DataPoint YValues="200" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2">
									<points>
										<asp:DataPoint YValues="1600" />
										<asp:DataPoint YValues="2400" />
										<asp:DataPoint YValues="2500" />
										<asp:DataPoint YValues="2800" />
										<asp:DataPoint YValues="1000" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3">
									<points>
										<asp:DataPoint YValues="2100" />
										<asp:DataPoint YValues="2100" />
										<asp:DataPoint YValues="3200" />
										<asp:DataPoint YValues="2500" />
										<asp:DataPoint YValues="1500" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False">
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2 enabled="False">
										<majorgrid enabled="False" />
									</axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" arrowstyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="N0" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<minorgrid enabled="true" linecolor="64, 64, 64, 64" />
										<minortickmark linecolor="64, 64, 64, 64" />
										<majortickmark linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx titlefont="Microsoft Sans Serif, 10pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" arrowstyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="N0" />
										<majorgrid linecolor="64, 64, 64, 64" />
										<minorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Logarithmic:</td>
								<td>
									<asp:checkbox id="Logarithmic" runat="server" AutoPostBack="True" oncheckedchanged="Logarithmic_CheckedChanged"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" Height="22px" Width="115px">Logarithmic Base:</asp:label>
								</td>
								<td><asp:dropdownlist id="Base" runat="server" Height="22" Width="90" AutoPostBack="True" cssclass="spaceright">
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="e">e</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server" Height="22px" Width="115px">Major Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="MajorInterval" runat="server" Height="22" Width="90" AutoPostBack="True" cssclass="spaceright">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server" Height="22px" Width="114px">Minor Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="MinorInterval" runat="server" Height="22" Width="90" AutoPostBack="True" cssclass="spaceright">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
