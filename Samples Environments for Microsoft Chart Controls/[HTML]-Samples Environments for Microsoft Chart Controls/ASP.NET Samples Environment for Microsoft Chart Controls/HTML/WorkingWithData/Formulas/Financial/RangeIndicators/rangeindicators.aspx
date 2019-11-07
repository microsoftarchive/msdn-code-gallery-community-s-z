<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RangeIndicators" CodeFile="RangeIndicators.aspx.cs" %>

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
		<p>
		</p>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample shows how to use the Bollinger Band and Envelopes 
                formulas, 
				which can be displayed using the Range Line chart type. It also displays the 
                moving average of the data using a&nbsp;line chart.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#F3DFC1" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
<legends>
<asp:Legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series YValuesPerPoint="2" XValueType="DateTime" MarkerStep="10" Name="Indicators" ChartType="Range" BorderColor="180, 26, 59, 105" Color="128, 65, 140, 240"></asp:Series>
<asp:Series MarkerSize="4" BorderWidth="0" YValuesPerPoint="4" XValueType="DateTime" Name="Input" ChartType="Point" BorderColor="128, 26, 59, 105" Color="196, 224, 64, 10" ShadowOffset="1"></asp:Series>
<asp:Series BorderWidth="2" XValueType="DateTime" Name="Moving Average" ChartType="Line" BorderColor="180, 26, 59, 105" Color="252, 180, 65" ShadowOffset="1"></asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
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

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" minimum="37266">

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
								<td class="label">Formula Name:<br/>
								</td>
								<td>
									<p>
										<asp:dropdownlist id="FormulaName" runat="server" AutoPostBack="True">
											<asp:listitem Value="Envelopes" Selected="True">Envelopes</asp:listitem>
											<asp:listitem Value="BollingerBands">Bollinger Bands</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">Period:</td>
								<td>
									<asp:dropdownlist id="NumberOfDays" runat="server" AutoPostBack="True">
										<asp:listitem Value="200">200 days</asp:listitem>
										<asp:listitem Value="150" Selected="True">150 days</asp:listitem>
										<asp:listitem Value="100">100 days</asp:listitem>
										<asp:listitem Value="75">75 days</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
									<p>
										<asp:button id="Random3" runat="server" Text="Random" CommandArgument="5" onclick="Random3_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
		</form>
	</body>
</html>
