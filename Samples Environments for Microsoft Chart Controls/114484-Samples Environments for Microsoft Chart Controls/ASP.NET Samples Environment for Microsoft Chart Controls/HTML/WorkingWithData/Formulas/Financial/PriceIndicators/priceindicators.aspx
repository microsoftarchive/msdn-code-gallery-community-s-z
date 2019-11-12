<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PriceIndicators" CodeFile="PriceIndicators.aspx.cs" %>

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
			<p class="dscr">This sample&nbsp;displays&nbsp;various price indicators, which 
				provide technical analysis on daily market prices that have open and close values.&nbsp;&nbsp;</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Center" Docking="Top" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="4" Name="Input" ChartType="Stock" ShadowColor="94, 0, 0, 0" BorderColor="180, 26, 59, 105" ShadowOffset="1"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 IsLabelAutoFit="False"></axisy2>
									<axisx2 IsLabelAutoFit="False"></axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IntervalAutoMode="VariableCount"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Typical Price:</td>
								<td>
									<p><asp:checkbox id="TypicalPrice" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="TypicalPrice_CheckedChanged"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label">Median Price:</td>
								<td>
									<p><asp:checkbox id="MedianPrice" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="MedianPrice_CheckedChanged"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label">Weighted Close:</td>
								<td>
									<p><asp:checkbox id="WeightedClose" runat="server" Checked="True" AutoPostBack="True" oncheckedchanged="WeightedClose_CheckedChanged"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label">Number of days:</td>
								<td>
									<asp:dropdownlist id="NumberOfDays" runat="server" AutoPostBack="True" onselectedindexchanged="NumberOfDays_SelectedIndexChanged">
										<asp:listitem Value="10">10 days</asp:listitem>
										<asp:listitem Value="20" Selected="True">20 days</asp:listitem>
										<asp:listitem Value="30">30 days</asp:listitem>
										<asp:listitem Value="40">40 days</asp:listitem>
										<asp:listitem Value="50">50 days</asp:listitem>
									</asp:dropdownlist></td>
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
			<p></p>
			<p>&nbsp;</p>
			<p>&nbsp;</p>
		</form>
	</body>
</html>
