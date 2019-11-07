<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FilterYValuesRange" CodeFile="FilterYValuesRange.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>FilterYValuesRange</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to filter data points&nbsp;by 
				their&nbsp;X or Y values.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="WhiteSmoke" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series BorderWidth="0" Name="Series Input" ChartType="Point" BorderColor="Transparent" Color="220, 65, 140, 240" ShadowOffset="2"></asp:Series>
<asp:Series BorderWidth="0" ChartArea="FilteredData" Name="Series Output" ChartType="Point" BorderColor="Transparent" Color="220, 224, 64, 10" ShadowOffset="2"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Original Data">

<labelstyle enabled="False">
</labelstyle>

<majorgrid enabled="False">
</majorgrid>

<majortickmark enabled="False">
</majortickmark>

</axisy2>

<area3dstyle pointgapdepth="0" Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="7" height="43" width="90" x="3">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1000" minimum="0" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200">
</labelstyle>

<majorgrid interval="200" linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark interval="200">
</majortickmark>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1000" minimum="0">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200">
</labelstyle>

<majorgrid interval="200" linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark interval="200">
</majortickmark>

</axisx>
</asp:ChartArea>
<asp:ChartArea Name="FilteredData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent" AlignWithChartArea="ChartArea1">
<axisy2 titlefont="Trebuchet MS, 8.25pt" enabled="True" title="Filtered Data">

<labelstyle enabled="False">
</labelstyle>

<majorgrid enabled="False">
</majorgrid>

<majortickmark enabled="False">
</majortickmark>

</axisy2>

<area3dstyle pointgapdepth="0" Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="48" height="43" width="90" x="3">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1000" minimum="0" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200">
</labelstyle>

<majorgrid interval="200" linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark interval="200">
</majortickmark>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="1000" minimum="0">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="200">
</labelstyle>

<majorgrid interval="200" linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark interval="200">
</majortickmark>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Point value used:</asp:label></td>
								<td>
									<asp:dropdownlist id="PointValueList" runat="server" Width="50px" AutoPostBack="True">
										<asp:listitem Value="Y" Selected="True">Y</asp:listitem>
										<asp:listitem Value="X">X</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2" height="5"><hr />
								</td>
							</tr>
							<tr>
								<td colspan="2">Filtering criteria:</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label8" runat="server">Value is more than: </asp:label></td>
								<td>
									<p>
										<asp:dropdownlist id="MoreValuesList" runat="server" AutoPostBack="True">
											<asp:listitem Value="800">800</asp:listitem>
											<asp:listitem Value="600" Selected="True">600</asp:listitem>
											<asp:listitem Value="400">400</asp:listitem>
											<asp:listitem Value="200">200</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server">Filtering criteria usage:</asp:label></td>
								<td></td>
							</tr>
							<tr>
								<td colspan="2" style="PADDING-LEFT: 24px">
									<asp:dropdownlist id="MatchCriteriaList" runat="server" AutoPostBack="True" width="200px">
										<asp:listitem Value="True" Selected="True">Remove matching points</asp:listitem>
										<asp:listitem Value="False">Remove non-matching points</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Filtering criteria is defined by comparing the selected X or Y value against a specified constant value.&nbsp;Points&nbsp;can be 
				removed if they match or do not match the filtering criteria.&nbsp;</p>
			<p>
			</p>
		</form>
	</body>
</html>
