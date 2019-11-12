<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FilterWithCustomCriteria" CodeFile="FilterWithCustomCriteria.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>FilterWithCustomCriteria</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to filter data points using custom 
				filtering criteria.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BackGradientStyle="TopBottom" Palette="BrightPastel" BorderlineDashStyle="Solid" BorderColor="181, 64, 1" BorderWidth="2">
<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series Name="Series Input" BorderColor="180, 26, 59, 105">
<points>
<asp:DataPoint YValues="1" />
</points>
</asp:Series>
<asp:Series ChartArea="FilteredData" Name="Series Output" BorderColor="180, 26, 59, 105">
<points>
<asp:DataPoint YValues="1" />
</points>
</asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<axisy2 titlefont="Trebuchet MS, 8pt" IsLabelAutoFit="False" enabled="True" title="Original Data">

<labelstyle enabled="False">
</labelstyle>

<majorgrid enabled="False">
</majorgrid>

<majortickmark enabled="False">
</majortickmark>

</axisy2>

<axisx2 IsLabelAutoFit="False">
</axisx2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="7" height="43" width="90" x="3">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="50" minimum="0" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="100" minimum="0">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="20">
</labelstyle>

<majorgrid interval="20" linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark interval="20">
</majortickmark>

</axisx>
</asp:ChartArea>
<asp:ChartArea Name="FilteredData" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" AlignWithChartArea="ChartArea1" BackGradientStyle="TopBottom">
<axisy2 titlefont="Trebuchet MS, 8pt" enabled="True" title="Filtered Data">

<labelstyle enabled="False">
</labelstyle>

<majorgrid enabled="False">
</majorgrid>

<majortickmark enabled="False">
</majortickmark>

</axisy2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="48" height="43" width="90" x="3">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="50" minimum="0" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="100" minimum="0" enabled="True">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="20">
</labelstyle>

<majorgrid interval="20" linecolor="64, 64, 64, 64">
</majorgrid>

<majortickmark interval="20">
</majortickmark>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label3" runat="server">Interval Width:</asp:label></td>
								<td>
									<asp:dropdownlist id="StripWidthList" runat="server" Width="119px" AutoPostBack="True">
										<asp:listitem Value="5">5</asp:listitem>
										<asp:listitem Value="10" Selected="True">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Interval Offset:</asp:label></td>
								<td>
									<asp:dropdownlist id="IntervalOffsetList" runat="server" Width="121px" AutoPostBack="True">
										<asp:listitem Value="0" Selected="True">0</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server">Show as Indexed:</asp:label></td>
								<td>
									<asp:dropdownlist id="ShowAsIndexedList" runat="server" Width="119px" AutoPostBack="True">
										<asp:listitem Value="False" Selected="True">False</asp:listitem>
										<asp:listitem Value="True">True</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">In this sample, several regions are defined along the X axis using the Interval 
				Width and Interval Offset values, and all other&nbsp;regions are highlighted with 
				a&nbsp;red strip line.&nbsp;Data points in these defined&nbsp;regions are 
				removed after filtering.</p>
			<p>
				&nbsp;</p>
		</form>
	</body>
</html>
