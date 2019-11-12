<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Forecasting" CodeFile="forecasting.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>WebForm1</title>
		<%this.AfterLoad();%>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This chart&nbsp;demonstrates the&nbsp;Forecasting formula and also 
				displays&nbsp;upper and lower errors as a Range chart.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<legends>
<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series YValuesPerPoint="2" XValueType="DateTime" Name="Range" ChartType="Range" BorderColor="180, 26, 59, 105" Color="128, 65, 140, 240"></asp:Series>
<asp:Series BorderWidth="2" XValueType="DateTime" Name="Forecasting" ChartType="Line" ShadowColor="64, 0, 0, 0" Color="252, 180, 65" ShadowOffset="1"></asp:Series>
<asp:Series BorderWidth="2" YValuesPerPoint="4" XValueType="DateTime" Name="Input" ChartType="Line" ShadowColor="64, 0, 0, 0" Color="224, 64, 10" ShadowOffset="1"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<axisy2 IsLabelAutoFit="False">
</axisy2>

<axisx2 IsLabelAutoFit="False">
</axisx2>

<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="dd MMM">
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
								<td class="label">Regression Type:</td>
								<td>
									<asp:dropdownlist id="Type" runat="server" AutoPostBack="True" onselectedindexchanged="Type_SelectedIndexChanged">
										<asp:listitem Value="Linear">Linear</asp:listitem>
										<asp:listitem Value="Polynomial">Polynomial</asp:listitem>
										<asp:listitem Value="Exponential">Exponential</asp:listitem>
										<asp:listitem Value="Logarithmic">Logarithmic</asp:listitem>
										<asp:listitem Value="Power">Power</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Order:</td>
								<td>
									<asp:dropdownlist id="Order" runat="server" AutoPostBack="True">
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Period:</td>
								<td>
									<asp:dropdownlist id="NumberOfDays" runat="server" AutoPostBack="True">
										<asp:listitem Value="75">75 days</asp:listitem>
										<asp:listitem Value="100">100 days</asp:listitem>
										<asp:listitem Value="150">150 days</asp:listitem>
										<asp:listitem Value="200">200 days</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Forecasting:</td>
								<td>
									<asp:dropdownlist id="ForecastPeriod" runat="server" AutoPostBack="True">
										<asp:listitem Value="10">10 Days</asp:listitem>
										<asp:listitem Value="20">20 Days</asp:listitem>
										<asp:listitem Value="30">30 Days</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Error:</td>
								<td>
										<asp:checkbox id="Error1" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label">Forecasting Error:</td>
								<td>
										<asp:checkbox id="ForecastingError" runat="server" AutoPostBack="True"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
										<asp:button id="Random3" runat="server" Text="Random" CommandArgument="5" onclick="Random3_Click"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>&nbsp;</p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
