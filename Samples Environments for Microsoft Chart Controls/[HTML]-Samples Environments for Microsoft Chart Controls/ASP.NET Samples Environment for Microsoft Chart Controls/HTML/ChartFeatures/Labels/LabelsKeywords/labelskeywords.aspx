
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LabelsKeywords" CodeFile="LabelsKeywords.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>LabelsKeywords</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to use keywords within axis and data 
				point labels.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" Palette="BrightPastel" BorderColor="181, 64, 1" BorderWidth="2">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series MarkerSize="7" BorderWidth="2" ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" ChartType="Spline" MarkerStyle="Square" MarkerColor="224, 64, 10" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold">
									<points>
										<asp:DataPoint YValues="1.29999995231628" />
										<asp:DataPoint YValues="1.79999995231628" />
										<asp:DataPoint YValues="2.29999995231628" />
										<asp:DataPoint YValues="1.5" />
										<asp:DataPoint YValues="1.20000004768372" />
										<asp:DataPoint YValues="1.79999995231628" />
										<asp:DataPoint YValues="1.20000004768372" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False"></axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" maximum="2.7999999523162842" minimum="0.800000011920929" IsStartedFromZero="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="N2" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64">
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
									<asp:label id="Label1" runat="server">Data Point Label with Keywords:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="PointLabelsList" runat="server" AutoPostBack="True">
										<asp:listitem Value="#PERCENT" Selected="True">#PERCENT</asp:listitem>
										<asp:listitem Value="Y = #VALY\nX = #VALX">Y = #VALY\nX = #VALX</asp:listitem>
										<asp:listitem Value="#VALX{ddd}">#VALX{ddd}</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label2" runat="server">X Axis Label with Keywords:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="AxisLabelsList" runat="server" AutoPostBack="True" width="253px">
										<asp:listitem Value="Month: #VALX{MMM}\nDay: #VALX{dd}" Selected="True">Month: #VALX{MMM}\nDay: #VALX{dd}</asp:listitem>
										<asp:listitem Value="#VALX{dd}\n#VALX{MMM}\n#VALX{yyy}">#VALX{dd}\n#VALX{MMM}\n#VALX{yyy}</asp:listitem>
										<asp:listitem Value="#INDEX">#INDEX</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Each keyword starts with the '#' character and&nbsp;can be followed 
				by the format string in brackets "{format}". At run time, the Chart control 
                replaces keywords in the labels with the values that they represent. Note that keywords can also be applied to tooltips.&nbsp;</p>
			<p>
			</p>
		</form>
	</body>
</html>
