<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FindByValue" CodeFile="FindByValue.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>FindByValue</title>
		<%this.AfterLoad();%>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to find data points in a series that 
				have maximum, minimum, or specific values. It also shows how to iterate through 
                located points, as well as&nbsp;how to&nbsp;specify a data point value to search.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Palette="BrightPastel" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend LegendStyle="Row" IsTextAutoFit="False" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far">
									<customitems>
										<asp:LegendItem ImageStyle="Marker" Name="Found Points" Color="194, 224, 64, 10" MarkerStyle="Square"></asp:LegendItem>
									</customitems>
								</asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series YValuesPerPoint="2" Name="Series1" ChartType="Bubble" CustomProperties="BubbleMaxSize=10" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="2"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="WhiteSmoke" ShadowColor="Transparent">
									<area3dstyle pointgapdepth="0" Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="20" minimum="0">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" maximum="20" minimum="0">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" interval="2" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label1" runat="server"> Value to Find Points By:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="ValiesList" runat="server" AutoPostBack="True">
										<asp:listitem Value="First Y Value" Selected="True">First Y Value</asp:listitem>
										<asp:listitem Value="Second Y Value (Bubble Size)">Second Y Value (Bubble Size)</asp:listitem>
										<asp:listitem Value="X value">X value</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label2" runat="server">Value to Find:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p>
										<asp:dropdownlist id="ValueList" runat="server" Width="210px" AutoPostBack="True">
											<asp:listitem Value="Min" Selected="True">Min</asp:listitem>
											<asp:listitem Value="Max">Max</asp:listitem>
											<asp:listitem Value="4">4</asp:listitem>
											<asp:listitem Value="8">8</asp:listitem>
											<asp:listitem Value="12">12</asp:listitem>
											<asp:listitem Value="16">16</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<p><asp:button id="RandomData" runat="server" Text="Random Data" CommandArgument="5" onclick="RandomData_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p>
			</p>
		</form>
	</body>
</html>
