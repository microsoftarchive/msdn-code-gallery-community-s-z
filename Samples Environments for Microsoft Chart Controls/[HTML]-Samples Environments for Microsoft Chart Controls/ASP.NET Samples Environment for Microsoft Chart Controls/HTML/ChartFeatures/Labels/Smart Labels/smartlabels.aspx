
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SmartLabels" CodeFile="SmartLabels.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>MultilineLabels</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="MultilineLabels" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to use smart labels to avoid overlaps by repositioning or hiding point labels.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="260px" Width="360px" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="WhiteSmoke" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" MarkerSize="6" Name="Default" ChartType="Point" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold" LabelFormat="P0">
									<smartlabelstyle enabled="True" calloutstyle="Box" />
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Smart Labels:</td>
								<td>
									<asp:checkbox id="PreventLabelsOverlapping" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Similar Point Values:</td>
								<td>
									<asp:checkbox id="Aligned" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server">Number of points:</asp:label></td>
								<td>
									<asp:dropdownlist id="NumOfPoints" runat="server" Width="126px" AutoPostBack="True">
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="40" Selected="True">40</asp:ListItem>
										<asp:ListItem Value="50">50</asp:ListItem>
										<asp:ListItem Value="60">60</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server">Allow Outside Plot Area:</asp:label></td>
								<td>
									<asp:dropdownlist id="AllowOutsidePlotArea" runat="server" Width="126px" AutoPostBack="True">
										<asp:listitem Value="Yes">Yes</asp:listitem>
										<asp:listitem Value="No">No</asp:listitem>
										<asp:listitem Value="Partial">Partial</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server">Callout Line Anchor Cap:</asp:label></td>
								<td>
									<asp:dropdownlist id="CalloutLineAnchorCap" runat="server" Width="126px" AutoPostBack="True">
										<asp:listitem Value="None">None</asp:listitem>
										<asp:listitem Value="Arrow">Arrow</asp:listitem>
										<asp:listitem Value="Diamond">Diamond</asp:listitem>
										<asp:listitem Value="Square">Square</asp:listitem>
										<asp:listitem Value="Round">Round</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server">Callout Line Anchor Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="CalloutLineAnchorColor" runat="server" Width="126px" AutoPostBack="True">
										<asp:listitem Value="Red">Red</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label5" runat="server" width="168px">Callout Line Anchor Width:</asp:label></td>
								<td>
									<asp:dropdownlist id="CalloutLineAnchorWidth" runat="server" Width="126px" AutoPostBack="True">
										<asp:listitem Value="1">1</asp:listitem>
										<asp:listitem Value="2">2</asp:listitem>
										<asp:listitem Value="3">3</asp:listitem>
										<asp:listitem Value="4">4</asp:listitem>
										<asp:listitem Value="5">5</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label6" runat="server">Callout Style:</asp:label></td>
								<td>
									<asp:dropdownlist id="CalloutStyle" runat="server" Width="126px" AutoPostBack="True">
										<asp:listitem Value="None">None</asp:listitem>
										<asp:listitem Value="Box">Box</asp:listitem>
										<asp:listitem Value="Underlined">Underlined</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"></p>
			<p>
			</p>
		</form>
	</body>
</html>
