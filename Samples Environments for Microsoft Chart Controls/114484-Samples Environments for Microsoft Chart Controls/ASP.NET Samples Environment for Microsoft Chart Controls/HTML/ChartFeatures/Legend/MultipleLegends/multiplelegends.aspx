
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.MultipleLegends" CodeFile="MultipleLegends.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>Multiple Legends</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<p>
&nbsp;&nbsp;&nbsp;
        </p>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates the use of multiple legends and how to 
				associate different series to them.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Width="412px" BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="BrightPastel" BorderColor="26, 59, 105" BackColor="#D3DFF0" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineDashStyle="Solid" BorderWidth="2" imagetype="Png">
<legends>
<asp:Legend IsTextAutoFit="False" BorderColor="80, 99, 129" DockedToChartArea="ChartArea1" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
<asp:Legend LegendStyle="Table" IsTextAutoFit="False" BorderColor="80, 99, 129" Docking="Bottom" Name="Second" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Center"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series BorderWidth="2" Name="Series 1" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1">
<points>
<asp:DataPoint YValues="36,84" />
<asp:DataPoint YValues="29,86" />
<asp:DataPoint YValues="8,76" />
<asp:DataPoint YValues="15,97" />
<asp:DataPoint YValues="24,76" />
<asp:DataPoint YValues="15,73" />
</points>
</asp:Series>
<asp:Series BorderWidth="2" Name="Series 2" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1">
<points>
<asp:DataPoint YValues="32,78" />
<asp:DataPoint YValues="33,73" />
<asp:DataPoint YValues="35,63" />
<asp:DataPoint YValues="25,90" />
<asp:DataPoint YValues="44,70" />
<asp:DataPoint YValues="30,70" />
</points>
</asp:Series>
<asp:Series BorderWidth="2" Name="Series 3" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1" Legend="Second">
<points>
<asp:DataPoint YValues="47" />
<asp:DataPoint YValues="44" />
<asp:DataPoint YValues="37" />
<asp:DataPoint YValues="47" />
<asp:DataPoint YValues="53" />
<asp:DataPoint YValues="42" />
</points>
</asp:Series>
<asp:Series BorderWidth="2" Name="Series 4" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1" Legend="Second">
<points>
<asp:DataPoint YValues="66" />
<asp:DataPoint YValues="65" />
<asp:DataPoint YValues="67" />
<asp:DataPoint YValues="66" />
<asp:DataPoint YValues="66" />
<asp:DataPoint YValues="57" />
</points>
</asp:Series>
<asp:Series BorderWidth="2" Name="Series 5" ChartType="Spline" BorderColor="180, 26, 59, 105" ShadowOffset="1" Legend="Second">
<points>
<asp:DataPoint YValues="55" />
<asp:DataPoint YValues="60" />
<asp:DataPoint YValues="53" />
<asp:DataPoint YValues="27" />
<asp:DataPoint YValues="29" />
<asp:DataPoint YValues="25" />
</points>
</asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<axisy2>

<labelstyle interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</labelstyle>

<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</majorgrid>

<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</majortickmark>

</axisy2>

<axisx2>

<labelstyle interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</labelstyle>

<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</majorgrid>

<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</majortickmark>

</axisx2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</labelstyle>

<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" linecolor="64, 64, 64, 64" intervaloffsettype="Auto">
</majorgrid>

<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</majortickmark>

</axisy>

<axisx IsMarginVisible="False" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</labelstyle>

<majorgrid interval="Auto" intervaltype="Auto" intervaloffset="Auto" linecolor="64, 64, 64, 64" intervaloffsettype="Auto">
</majorgrid>

<majortickmark interval="Auto" intervaltype="Auto" intervaloffset="Auto" intervaloffsettype="Auto">
</majortickmark>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Series 1 legend:</td>
								<td>
									<asp:dropdownlist id="DropDownList1" runat="server" Width="88px" AutoPostBack="True">
										<asp:listitem Value="Default" Selected="True">Default</asp:listitem>
										<asp:listitem Value="Second">Second</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Series 2 legend:</td>
								<td>
									<asp:dropdownlist id="DropDownList2" runat="server" Width="88px" AutoPostBack="True">
										<asp:listitem Value="Default" Selected="True">Default</asp:listitem>
										<asp:listitem Value="Second">Second</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Series&nbsp;3 legend:</td>
								<td>
									<asp:dropdownlist id="DropDownList3" runat="server" Width="88px" AutoPostBack="True">
										<asp:listitem Value="Default">Default</asp:listitem>
										<asp:listitem Value="Second" Selected="True">Second</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Series&nbsp;4 legend:</td>
								<td>
									<asp:dropdownlist id="DropDownList4" runat="server" Width="88px" AutoPostBack="True">
										<asp:listitem Value="Default">Default</asp:listitem>
										<asp:listitem Value="Second" Selected="True">Second</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Series&nbsp;5 legend:</td>
								<td>
									<asp:dropdownlist id="DropDownList5" runat="server" Width="88px" AutoPostBack="True">
										<asp:listitem Value="Default">Default</asp:listitem>
										<asp:listitem Value="Second" Selected="True">Second</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			
		</form>
	</body>
</html>
