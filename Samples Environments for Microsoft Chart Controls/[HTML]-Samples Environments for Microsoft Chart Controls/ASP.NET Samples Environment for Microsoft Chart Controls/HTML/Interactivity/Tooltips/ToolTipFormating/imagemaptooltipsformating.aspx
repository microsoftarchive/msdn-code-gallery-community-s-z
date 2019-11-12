<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ImageMapToolTipsFormating" CodeFile="ImageMapToolTipsFormating.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>ImageMapToolTipsFormating</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how formatting can be applied to tooltips.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" BackColor="WhiteSmoke" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" Palette="BrightPastel" BorderlineDashStyle="Solid" backgradientendcolor="White" backgradienttype="TopBottom" borderlinewidth="2" borderlinecolor="26, 59, 105">
							<legends>
								<asp:legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series YValuesPerPoint="2" Name="Default" ChartType="Bubble" 
                                    BorderColor="180, 26, 59, 105" Color="196, 65, 140, 240" ShadowOffset="3" 
                                    MarkerStyle="Circle"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"  BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy linecolor="64, 64, 64, 64"  IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" IntervalAutoMode="VariableCount">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="dd MMM"></labelstyle>
										<majorgrid linecolor="64, 64, 64, 64"></majorgrid>
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2"><asp:label id="Label1" runat="server">Format of the X value in tooltip:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="FormatXList" runat="server" AutoPostBack="True" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="d" Selected="True">Short Date</asp:listitem>
										<asp:listitem Value="D">Long Date</asp:listitem>
										<asp:listitem Value="f">Full Date/Time</asp:listitem>
										<asp:listitem Value="g">General Date/Time</asp:listitem>
										<asp:listitem Value="M">Month Day</asp:listitem>
										<asp:listitem Value="Y">Month Year</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2"><asp:label id="Label2" runat="server">Format and precision of the tooltip Y value:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="FormatYList" runat="server" AutoPostBack="True" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="C" Selected="True">Currency</asp:listitem>
										<asp:listitem Value="E">Scientific</asp:listitem>
										<asp:listitem Value="F">Fixed Point</asp:listitem>
										<asp:listitem Value="P">Percent</asp:listitem>
									</asp:dropdownlist>
									<asp:dropdownlist id="FormatPrecisionYList" runat="server" AutoPostBack="True" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="" Selected="True">Default</asp:listitem>
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td colspan="2"><asp:label id="Label3" runat="server" width="295px"> Format and precision of the tooltip radius (Y2):</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="FormatY2List" runat="server" AutoPostBack="True" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="C">Currency</asp:listitem>
										<asp:listitem Value="E">Scientific</asp:listitem>
										<asp:listitem Value="F">Fixed Point</asp:listitem>
										<asp:listitem Value="P" Selected="True">Percent</asp:listitem>
									</asp:dropdownlist>
									<asp:dropdownlist id="FormatPrecisionY2List" runat="server" AutoPostBack="True" onselectedindexchanged="List_SelectedIndexChanged">
										<asp:listitem Value="" Selected="True">Default</asp:listitem>
										<asp:listitem Value="0">0</asp:listitem>
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Move the mouse cursor over the&nbsp;bubbles to see the multi-line 
				tooltips.&nbsp;To modify&nbsp;the&nbsp;format of the displayed data point 
				values, use the controls to the right.&nbsp;Note that hyperlinks can be 
				formatted in the same manner as tooltips.</p>
		</form>
	</body>
</html>
