<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.GridLinesAndTickMarks" CodeFile="GridLinesAndTickMarks.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to set the appearance of grid lines 
				and tick marks.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><!-- CHART HERE (412x306 px)--><asp:chart id="Chart1" runat="server" Width="412px" Height="306px" BackColor="WhiteSmoke" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderColor="26, 59, 105" Palette="BrightPastel" BorderlineDashStyle="Solid" BorderWidth="2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Grid Lines and Tick Marks" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="450" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="550" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3" BorderColor="180, 26, 59, 105">
									<points>
										<asp:DataPoint YValues="500" />
										<asp:DataPoint YValues="600" />
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="600" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="White" ShadowColor="Transparent">
									<axisy2>
										<MajorGrid Enabled="False" />
									</axisy2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<MajorTickMark Size="2" Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Major:
								</td>
								<td>
									<asp:dropdownlist id="MType" runat="server" AutoPostBack="True" width="104px">
										<asp:listitem Value="Grid">Grid</asp:listitem>
										<asp:listitem Value="Tickmark">Tickmark</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Height="20px" Width="101px">Line Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="MColor1" runat="server" AutoPostBack="True" Height="22px" Width="104px">
										<asp:ListItem Value="DimGray" Selected="True">DimGray</asp:ListItem>
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server" Height="20px" Width="101px">Line Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="MStyle" runat="server" AutoPostBack="True" Height="22" Width="104px" onselectedindexchanged="MStyle_SelectedIndexChanged"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Height="20px" Width="101px">Line Width:</asp:label></td>
								<td>
									<asp:dropdownlist id="MWidth" runat="server" AutoPostBack="True" Height="22px" Width="104px">
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2" Selected="True">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server" Height="20px" Width="101px">Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="MInterval" runat="server" AutoPostBack="True" Width="104px">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr height="4">
								<td colspan="2">
								</td>
							</tr>
							<tr>
								<td class="label">Minor:
								</td>
								<td>
									<asp:dropdownlist id="NType" runat="server" AutoPostBack="True" width="104px">
										<asp:listitem Value="Grid">Grid</asp:listitem>
										<asp:listitem Value="Tickmark">Tickmark</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label14" runat="server" Height="20px" Width="101px">Line Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="NColor1" runat="server" Height="22px" Width="103px" AutoPostBack="True">
										<asp:ListItem Value="LightGray" Selected="True">LightGray</asp:ListItem>
										<asp:ListItem Value="Silver">Silver</asp:ListItem>
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Yellow">Yellow</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label13" runat="server" Height="20px" Width="101px">Line Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="NStyle" runat="server" Height="22" Width="103px" AutoPostBack="True"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label12" runat="server" Height="20px" Width="101px">Line Width:</asp:label></td>
								<td>
									<asp:dropdownlist id="NWidth" runat="server" Height="22px" Width="103px" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label11" runat="server" Height="20px" Width="101px">Interval:</asp:label></td>
								<td>
									<asp:dropdownlist id="NInterval" runat="server" Height="22px" Width="103px" AutoPostBack="True">
										<asp:ListItem Value="0.1" Selected="True">0.1</asp:ListItem>
										<asp:ListItem Value="0.2">0.2</asp:ListItem>
										<asp:ListItem Value="0.25">0.25</asp:ListItem>
										<asp:ListItem Value="0.5">0.5</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<!-- REPEAT THE ROW ABOVE FOR EACH LABEL - CONTROL PAIR -->
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
