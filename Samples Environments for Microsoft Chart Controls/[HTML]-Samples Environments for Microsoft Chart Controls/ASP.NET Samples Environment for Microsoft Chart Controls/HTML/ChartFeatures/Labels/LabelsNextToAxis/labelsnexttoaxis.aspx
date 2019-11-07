
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LabelsNextToAxis" CodeFile="LabelsNextToAxis.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LabelsNextToAxis</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set an axis crossing point. It also 
				demonstrates how to display labels and tick marks next to an axis or at the 
				plotting area border.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BackColor="#F3DFC1" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="10" ChartArea="ChartArea1" Name="Series1" ChartType="Point" MarkerStyle="Cross" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:Series>
								<asp:Series MarkerSize="7" ChartArea="ChartArea1" Name="Series2" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:Series>
								<asp:Series MarkerSize="8" ChartArea="ChartArea1" Name="Series3" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False"></axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="128, 64, 64, 64" IsLabelAutoFit="False" maximum="100" ArrowStyle="Triangle" minimum="-100" crossing="0">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="128, 64, 64, 64" IsLabelAutoFit="False" maximum="100" ArrowStyle="Triangle" minimum="-100" crossing="0">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label1" runat="server">X Axis Labels and Tick Marks:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="XLabelsList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Show Next to the Axis" Selected="True">Show Next to the Axis</asp:listitem>
										<asp:listitem Value="Show at Plot Area Border">Show at Plot Area Border</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label2" runat="server">Y Axis Labels and Tick Marks:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="YLabelsList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Show Next to the Axis" Selected="True">Show Next to the Axis</asp:listitem>
										<asp:listitem Value="Show at Plot Area Border">Show at Plot Area Border</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>
			</p>
		</form>
	</body>
</html>
