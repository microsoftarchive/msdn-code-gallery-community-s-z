<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LabelsTextStyle" CodeFile="LabelsTextStyle.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>LabelsTextStyle</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set&nbsp;an axis labels' 
				font,&nbsp;angle, and&nbsp;offset style. It also shows how to enable and disable 
				axis labels.&nbsp;&nbsp;</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#D3DFF0" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="Pastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
<titles>
<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Chart for .NET Framework" Alignment="TopLeft" ForeColor="26, 59, 105">
<position y="4" height="8.738057" width="65" x="4">
</position>
</asp:Title>
</titles>

<legends>
<asp:Legend LegendStyle="Row" Enabled="False" Name="Default" BackColor="Transparent">
<position y="85" height="5" width="40" x="5">
</position>
</asp:Legend>
</legends>

<borderskin skinstyle="Emboss">
</borderskin>

<series>
<asp:Series ChartArea="ChartArea1" XValueType="Double" Name="Series2" CustomProperties="DrawingStyle=Cylinder" ShadowColor="Transparent" BorderColor="180, 26, 59, 105" Color="65, 140, 240" YValueType="Double">
<points>
<asp:DataPoint XValue="1" YValues="70" />
<asp:DataPoint XValue="2" YValues="80" />
<asp:DataPoint XValue="3" YValues="70" />
<asp:DataPoint XValue="4" YValues="85" />
</points>
</asp:Series>
<asp:Series ChartArea="ChartArea1" Name="Series3" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="252, 180, 65">
<points>
<asp:DataPoint XValue="1" YValues="65" />
<asp:DataPoint XValue="2" YValues="70" />
<asp:DataPoint XValue="3" YValues="60" />
<asp:DataPoint XValue="4" YValues="75" />
</points>
</asp:Series>
<asp:Series ChartArea="ChartArea1" Name="Series4" CustomProperties="DrawingStyle=Cylinder" BorderColor="64, 0, 0, 0" Color="224, 64, 10">
<points>
<asp:DataPoint XValue="1" YValues="50" />
<asp:DataPoint XValue="2" YValues="55" />
<asp:DataPoint XValue="3" YValues="40" />
<asp:DataPoint XValue="4" YValues="70" />
</points>
</asp:Series>
</series>

<chartareas>
<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
<area3dstyle pointgapdepth="0" Rotation="5" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False">
</area3dstyle>

<position y="13" height="75" width="90" x="2">
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

<CustomLabels>
<asp:CustomLabel Text="John" ToPosition="1.5" FromPosition="0.5"></asp:CustomLabel>
<asp:CustomLabel Text="Mary" ToPosition="2.5" FromPosition="1.5"></asp:CustomLabel>
<asp:CustomLabel Text="Jeff" ToPosition="3.5" FromPosition="2.5"></asp:CustomLabel>
<asp:CustomLabel Text="Bob" ToPosition="4.5" FromPosition="3.5"></asp:CustomLabel>
</CustomLabels>

</axisx>
</asp:ChartArea>
</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">
									<asp:label id="Label1" runat="server" width="159px">X Axis Labels Font Name:</asp:label></td>
								<td>
									<asp:dropdownlist id="FontNameList" runat="server" AutoPostBack="True" cssclass="spaceright">
<asp:ListItem Value="Trebuchet MS" Selected="True">Trebuchet MS</asp:ListItem>
<asp:ListItem Value="Arial">Arial</asp:ListItem>
<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
<asp:ListItem Value="Microsoft Sans Serif">Microsoft Sans Serif</asp:ListItem>
<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
<asp:ListItem Value="Verdana">Verdana</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server">X Axis Labels Font Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="FontSizeList" runat="server" AutoPostBack="True" cssclass="spaceright">
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="8" Selected="True">8</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label3" runat="server">X Axis Labels Angle:</asp:label></td>
								<td>
									<asp:dropdownlist id="FontAngleList" runat="server" AutoPostBack="True" cssclass="spaceright">
<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
<asp:ListItem Value="30">30</asp:ListItem>
<asp:ListItem Value="45">45</asp:ListItem>
<asp:ListItem Value="60">60</asp:ListItem>
<asp:ListItem Value="90">90</asp:ListItem>
<asp:ListItem Value="-30">-30</asp:ListItem>
<asp:ListItem Value="-45">-45</asp:ListItem>
<asp:ListItem Value="-60">-60</asp:ListItem>
<asp:ListItem Value="-90">-90</asp:ListItem>
<asp:ListItem></asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Offset X Axis Labels:</td>
								<td>
            <p>
							<asp:checkbox id="OffsetLabels" runat="server" AutoPostBack="True"></asp:checkbox></p></td>
							</tr>
							<tr>
								<td class="label">Enable X Axis Labels:</td>
								<td>
            <p>
							<asp:checkbox id="EnableLabels" runat="server" AutoPostBack="True" Checked="True"></asp:checkbox></p></td>
							</tr>
							<tr>
								<td class="label">AntiAlias For Text:</td>
								<td>
            <p>
<asp:checkbox id="TextAntiAlias" runat="server" AutoPostBack="True" Checked="True" DESIGNTIMEDRAGDROP="293"></asp:checkbox></p></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
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
