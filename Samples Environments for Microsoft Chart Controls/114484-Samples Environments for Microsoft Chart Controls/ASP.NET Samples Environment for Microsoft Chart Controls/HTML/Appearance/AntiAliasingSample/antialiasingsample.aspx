
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AntiAliasingSample" CodeFile="AntiAliasingSample.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set the anti 
aliasing mode for graphics and text.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" palette="Pastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" BorderColor="181, 64, 1">
<titles>
<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Anti Aliasing" Alignment="TopCenter" ForeColor="26, 59, 105">
<position y="4" height="8.738057" width="55" x="22">
</position>
</asp:Title>
</titles>

<legends>
<asp:Legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
<position y="85" height="5" width="40" x="5">
</position>
</asp:Legend>
<asp:Legend Enabled="False" Name="Legend2"></asp:Legend>
<asp:Legend LegendStyle="Row"  IsTextAutoFit="False" Name="Legend3" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold">
<customitems>
<asp:LegendItem Name="Previous Month Avg" Color="65, 140, 240"></asp:LegendItem>
<asp:LegendItem Name="Last Week" Color="252, 180, 65"></asp:LegendItem>
<asp:LegendItem Name="This Week" Color="224, 64, 10"></asp:LegendItem>
</customitems>

<position y="85" height="12" width="90" x="5">
</position>
</asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Legend="Legend2" YValueType="Double">
<points>
<asp:DataPoint XValue="1" YValues="70" />
<asp:DataPoint XValue="2" YValues="80" />
<asp:DataPoint XValue="3" YValues="70" />
<asp:DataPoint XValue="4" YValues="85" />
</points>
</asp:Series>
<asp:Series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="220, 252, 180, 65">
<points>
<asp:DataPoint XValue="1" YValues="65" />
<asp:DataPoint XValue="2" YValues="70" />
<asp:DataPoint XValue="3" YValues="60" />
<asp:DataPoint XValue="4" YValues="75" />
</points>
</asp:Series>
<asp:Series ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="220, 224, 64, 10">
<points>
<asp:DataPoint XValue="1" YValues="50" />
<asp:DataPoint XValue="2" YValues="55" />
<asp:DataPoint XValue="3" YValues="40" />
<asp:DataPoint XValue="4" YValues="70" />
</points>
</asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="8" height="75" width="100">
</position>

<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">

<labelstyle font="Trebuchet MS, 8.25pt, style=Bold">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

</axisy>

<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" interval="1">

<labelstyle font="Trebuchet MS, 8.25pt">
</labelstyle>

<majorgrid linecolor="64, 64, 64, 64">
</majorgrid>

<customlabels>
<asp:CustomLabel Text="John" ToPosition="1.5" FromPosition="0.5"></asp:CustomLabel>
<asp:CustomLabel Text="Mary" ToPosition="2.5" FromPosition="1.5"></asp:CustomLabel>
<asp:CustomLabel Text="Jeff" ToPosition="3.5" FromPosition="2.5"></asp:CustomLabel>
<asp:CustomLabel Text="Bob" ToPosition="4.5" FromPosition="3.5"></asp:CustomLabel>
</customlabels>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
							<asp:label id="Label4" runat="server" Width="142px" Height="21px">Graphics Anti Aliasing:</asp:label></td>
								<td>
							<asp:dropdownlist id="GraphicsAntiAliasing" runat="server" AutoPostBack="True" Width="142px" Height="22px">
<asp:ListItem Value="Text">Text</asp:ListItem>
<asp:ListItem Value="Graphics">Graphics</asp:ListItem>
<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
<asp:ListItem Value="None">None</asp:ListItem>
							</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
							<asp:label id="Label5" runat="server" Width="114px" Height="21px">Text Anti Aliasing:</asp:label></td>
								<td>
							<asp:dropdownlist id="TextAntiAliasing" runat="server" AutoPostBack="True" tabIndex="1" Width="141px">
<asp:ListItem Value="Normal">Normal</asp:ListItem>
<asp:ListItem Value="High" Selected="True">High</asp:ListItem>
<asp:ListItem Value="SystemDefault">SystemDefault</asp:ListItem>
							</asp:dropdownlist></td>
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
