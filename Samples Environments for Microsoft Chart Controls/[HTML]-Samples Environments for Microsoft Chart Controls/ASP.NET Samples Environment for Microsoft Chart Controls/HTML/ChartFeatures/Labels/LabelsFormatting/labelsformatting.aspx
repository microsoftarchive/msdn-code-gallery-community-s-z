<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LabelsFormatting" CodeFile="LabelsFormatting.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LabelsFormatting</title>
	    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to format axes and data point labels. 
				Data point labels can be set for an entire series or for an individual data 
				point.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke" BorderColor="26, 59, 105">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series IsValueShownAsLabel="True" MarkerSize="9" BorderWidth="2" ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" ChartType="Line" MarkerStyle="Circle" MarkerColor="190, 224, 64, 10" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False"></axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" arrowstyle="Triangle">
										<labelstyle font="Tahoma, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" arrowstyle="Triangle">
										<labelstyle font="Tahoma, 8.25pt" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label1" runat="server">X Axis Labels Format:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="XAxisFormat" runat="server" AutoPostBack="True">
										<asp:listitem Value="d" Selected="True">Short Date</asp:listitem>
										<asp:listitem Value="M">Month Day</asp:listitem>
										<asp:listitem Value="Y">Month Year</asp:listitem>
										<asp:listitem Value="ddd, d">Week Day</asp:listitem>
										<asp:listitem Value="D">Long Date</asp:listitem>
										<asp:listitem Value="G">General Date/Time</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label2" runat="server">Y Axis Labels Format:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="YAxisFormat" runat="server" AutoPostBack="True">
										<asp:listitem Value="C" Selected="True">Currency</asp:listitem>
										<asp:listitem Value="C0">Currency Rounded</asp:listitem>
										<asp:listitem Value="E">Scientific</asp:listitem>
										<asp:listitem Value="E0">Scientific  Rounded</asp:listitem>
										<asp:listitem Value="P">Percent</asp:listitem>
										<asp:listitem Value="P0">Percent Rounded</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label3" runat="server">Series Points Labels Format:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="SeriesPointFormat" runat="server" AutoPostBack="True">
										<asp:listitem Value="C">Currency</asp:listitem>
										<asp:listitem Value="C0">Currency Rounded</asp:listitem>
										<asp:listitem Value="E">Scientific</asp:listitem>
										<asp:listitem Value="E0">Scientific  Rounded</asp:listitem>
										<asp:listitem Value="P" Selected="True">Percent</asp:listitem>
										<asp:listitem Value="P0">Percent Rounded</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:checkbox id="IsEndLabelVisible" runat="server" AutoPostBack="True" Text="Show X Axis End Labels" Checked="True"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
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
