<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CustomSortingOrder" CodeFile="CustomSortingOrder.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>CustomSortingOrder</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample shows how to sort a series' data points using a custom 
				sort order.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series Name="Original" BorderColor="180, 26, 59, 105"></asp:Series>
<asp:Series ChartArea="Sorted" Name="Sorted" BorderColor="180, 26, 59, 105"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<axisy2 title="Original Data">
</axisy2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="Unsorted">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="1">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisx>
</asp:ChartArea>
<asp:ChartArea Name="Sorted" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="Sorted">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="1">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server">Sort Series Data:</asp:label></td>
								<td>
									<asp:dropdownlist id="SortList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Using Y values" Selected="True">Using Y values</asp:listitem>
										<asp:listitem Value="Using X values">Using X values</asp:listitem>
										<asp:listitem Value="Using X and Y values">Using X and Y values</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Data can be sorted by the first Y value,&nbsp;by axis label, or 
                first by axis name and then by the first Y value.</p>
			<table id="Table1" cellspacing="7" cellpadding="1" border="0">
				<tr>
					<td valign="top" align="left" width="360"></td>
					<td valign="top" align="left"><br/>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
