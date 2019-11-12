<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.TTest" CodeFile="TTest.aspx.cs" %>

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
		<form id="CustomSortingOrder" method="post" runat="server">
			<p class="dscr">This sample demonstrates the <i>t</i>-test using <i>t</i>-distribution (or 
                Student&#39;s <i>t</i>-distribution).</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" backcolor="WhiteSmoke" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
<position y="5" height="15" width="30" x="63">
</position>
</asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series Name="FirstGroup" CustomProperties="LabelStyle=&quot;down&quot;" BorderColor="180, 26, 59, 105"></asp:Series>
<asp:Series ChartArea="Chart Area 2" Name="SecondGroup" BorderColor="180, 26, 59, 105"></asp:Series>
<asp:Series ChartArea="ChartArea1" Name="Distribution" ChartType="Area" BorderColor="180, 26, 59, 105"></asp:Series>
<asp:Series ChartArea="" Name="Result" BorderColor="180, 26, 59, 105"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="Chart Area 2" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="16" minimum="0" interval="4">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisx>
</asp:ChartArea>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" AlignWithChartArea="Chart Area 2" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx titlefont="Trebuchet MS, 8.25pt, style=Bold" linecolor="64, 64, 64, 64" IsLabelAutoFit="False" title="Distribution">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
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
									<asp:label id="Label1" runat="server" Width="100px">Probability: </asp:label></td>
								<td>
									<asp:dropdownlist id="DropDownListProbability" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownListProbability_SelectedIndexChanged">
										<asp:listitem Value="20">20</asp:listitem>
										<asp:listitem Value="40">40</asp:listitem>
										<asp:listitem Value="60">60</asp:listitem>
										<asp:listitem Value="80">80</asp:listitem>
										<asp:listitem Value="90">90</asp:listitem>
										<asp:listitem Value="95" Selected="True">95</asp:listitem>
										<asp:listitem Value="99">99</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Width="100px">T Test Type: </asp:label></td>
								<td>
									<asp:dropdownlist id="DropDownList1" runat="server" Width="126px" AutoPostBack="True">
										<asp:listitem Value="Equal Variances">Equal Variances</asp:listitem>
										<asp:listitem Value="Unequal Variances">Unequal Variances</asp:listitem>
										<asp:listitem Value="Paired">Paired</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2" align="right">
									<asp:table id="TableResults" runat="server" BackColor="WhiteSmoke" BorderColor="White" BorderDashStyle="Solid" BorderWidth="1px" GridLines="Both" CellPadding="0" CellSpacing="1" Width="286px" Height="144px">
<asp:TableRow>
<asp:TableCell Width="152px" HorizontalAlign="Right" Text="First series mean:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="Second series mean:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="First series variance:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="Second series variance:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="T Value:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="Degree of freedom:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="P(T&lt;=t) - one-tail:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="t Critical one-tail:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="P(T&lt;=t) - two-tail:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" Text="t Critical two-tail:"></asp:TableCell>
<asp:TableCell Text="0"></asp:TableCell>
</asp:TableRow>
									</asp:table>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:button id="ButtonRandomData" runat="server" CommandArgument="5" Text="Random Data" onclick="ButtonRandomData_Click"></asp:button></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
<p class="dscr" style="LEFT: 10px; TOP: 358px">The top chart area displays two 
groups of data that are used as input, while the bottom chart area displays the 
distribution.</p>
		</form>
	</body>
</html>
