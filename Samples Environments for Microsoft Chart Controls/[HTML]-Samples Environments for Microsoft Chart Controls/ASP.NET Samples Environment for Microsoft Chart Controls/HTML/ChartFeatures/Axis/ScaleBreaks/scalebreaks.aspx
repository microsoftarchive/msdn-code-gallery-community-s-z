<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ScaleBreaks" CodeFile="ScaleBreaks.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to work with scale breaks.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#D3DFF0" BorderColor="26, 59, 105" BackSecondaryColor="White" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<legends>
								<asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False" Name="Default"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" CustomProperties="DrawingStyle=LightToDark" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint XValue="38801.6328125" YValues="32" />
										<asp:DataPoint XValue="38802.6328125" YValues="30" />
										<asp:DataPoint XValue="38803.6328125" YValues="38" />
										<asp:DataPoint XValue="38804.6328125" YValues="23" />
										<asp:DataPoint XValue="38805.6328125" YValues="28" />
										<asp:DataPoint XValue="38806.6328125" YValues="24" />
										<asp:DataPoint XValue="38807.6328125" YValues="21" />
										<asp:DataPoint XValue="38808.6328125" YValues="30" />
										<asp:DataPoint XValue="38809.6328125" YValues="24" />
										<asp:DataPoint XValue="38810.6328125" YValues="29" />
										<asp:DataPoint XValue="38811.6328125" YValues="2953" />
										<asp:DataPoint XValue="38812.6328125" YValues="3367" />
										<asp:DataPoint XValue="38813.6328125" YValues="3124" />
										<asp:DataPoint XValue="38814.6328125" YValues="3224" />
										<asp:DataPoint XValue="38815.6328125" YValues="25" />
										<asp:DataPoint XValue="38816.6328125" YValues="18" />
										<asp:DataPoint XValue="38817.6328125" YValues="14" />
										<asp:DataPoint XValue="38818.6328125" YValues="28" />
										<asp:DataPoint XValue="38819.6328125" YValues="19" />
										<asp:DataPoint XValue="38820.6328125" YValues="30" />
										<asp:DataPoint XValue="38821.6328125" YValues="21" />
										<asp:DataPoint XValue="38822.6328125" YValues="32" />
										<asp:DataPoint XValue="38823.6328125" YValues="23" />
										<asp:DataPoint XValue="38824.6328125" YValues="10" />
										<asp:DataPoint XValue="38825.6328125" YValues="27" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64"  LabelAutoFitMinFontSize="8" LineWidth="2"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64"  LabelAutoFitMinFontSize="8" LabelAutoFitStyle="None"  LabelAutoFitMaxFontSize="8">
										<LabelStyle Font="Trebuchet MS, 6.75pt, style=Bold" Format="MMM dd" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="HEIGHT: 17px">
									<asp:label id="Label1" runat="server" Height="8px" Width="142px">Enable Scale Breaks:</asp:label></td>
								<td style="HEIGHT: 17px">
									<asp:CheckBox id="chk_Enable" runat="server" AutoPostBack="True" oncheckedchanged="chk_Enable_CheckedChanged"></asp:CheckBox>
								</td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label2" runat="server" Height="9px" Width="125px"> Type:</asp:label>
								</td>
								<td>
									<asp:dropdownlist id="BreakType" runat="server" AutoPostBack="True" Width="112px"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label" style="HEIGHT: 24px">
									<asp:label id="Label3" runat="server" Height="19px" Width="125px"> Spacing:</asp:label></td>
								<td style="HEIGHT: 24px">
									<asp:dropdownlist id="Spacing" runat="server" AutoPostBack="True" width="112px">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2" Selected="True">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label" style="HEIGHT: 17px">
									<asp:label id="Label4" runat="server" Height="19" Width="155px"> Color:</asp:label></td>
								<td style="HEIGHT: 17px">
									<asp:dropdownlist id="ScaleBreakColor" runat="server" AutoPostBack="True" Height="124px" Width="112px">
										<asp:ListItem Value="Black">Black</asp:ListItem>
										<asp:ListItem Value="Red">Red</asp:ListItem>
										<asp:ListItem Value="Green">Green</asp:ListItem>
										<asp:ListItem Value="Blue">Blue</asp:ListItem>
									</asp:dropdownlist>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
								</td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
			</p>
		</form>
	</body>
</html>
