<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Sorting" CodeFile="Sorting.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>Sorting</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample shows how to sort a series' data points using different 
				point values and sort orders.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<titles>
<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Company Perfomance" ForeColor="26, 59, 105"></asp:Title>
</titles>

<legends>
<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series YValuesPerPoint="2" Name="Series1" ChartType="Bubble" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" Color="180, 224, 64, 10" ShadowOffset="2" IsXValueIndexed="True"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="0">
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
									<asp:label id="Label1" runat="server">Value Used for Sorting:</asp:label></td>
								<td>
									<asp:dropdownlist id="SortList" runat="server" AutoPostBack="True">
										<asp:listitem Value="Unsorted" Selected="True">Unsorted</asp:listitem>
										<asp:listitem Value="Y Value">Y Value</asp:listitem>
										<asp:listitem Value="Y2 Value (Radius)">Y2 Value (Radius)</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server">Sort Order:</asp:label></td>
								<td>
									<asp:dropdownlist id="SortOrderList" runat="server" AutoPostBack="True" Enabled="False">
										<asp:listitem Value="Ascending" Selected="True">Ascending</asp:listitem>
										<asp:listitem Value="Descending">Descending</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
