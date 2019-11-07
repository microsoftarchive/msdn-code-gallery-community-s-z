<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Palettes" CodeFile="Palettes.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>Palettes</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how a chart palette can be specified.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
                        <asp:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" Width="412px" Height="296px"
                             BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom"
                            BorderWidth="2" BorderColor="Navy" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                            <Titles>
                                <asp:Title Font="Trebuchet MS, 14.25pt, style=Bold" Name="Title1" Text="Chart for .NET Framework">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend IsTextAutoFit="False" BackColor="Transparent" Enabled="False" Font="Trebuchet MS, 8pt, style=Bold"
                                    Name="Default" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series BorderWidth="3" ChartArea="ChartArea1" CustomProperties="DrawingStyle=LightToDark"
                                    Name="Series1">
                                    <Points>
                                        <asp:DataPoint XValue="1" YValues="23" />
                                        <asp:DataPoint XValue="2" YValues="45" />
                                        <asp:DataPoint XValue="3" YValues="62" />
                                        <asp:DataPoint XValue="4" YValues="49" />
                                        <asp:DataPoint YValues="45" />
                                    </Points>
                                </asp:Series>
                                <asp:Series BorderWidth="3" ChartArea="ChartArea1" CustomProperties="DrawingStyle=LightToDark"
                                    Name="Series2" YValuesPerPoint="2">
                                    <Points>
                                        <asp:DataPoint XValue="1" YValues="23,0" />
                                        <asp:DataPoint XValue="2" YValues="32" />
                                        <asp:DataPoint XValue="3" YValues="43" />
                                        <asp:DataPoint XValue="4" YValues="58" />
                                        <asp:DataPoint YValues="33" />
                                    </Points>
                                </asp:Series>
                                <asp:Series BorderWidth="3" ChartArea="ChartArea1" CustomProperties="DrawingStyle=LightToDark"
                                    Name="Series3" YValuesPerPoint="2">
                                    <Points>
                                        <asp:DataPoint XValue="1" YValues="34,0" />
                                        <asp:DataPoint XValue="2" YValues="32" />
                                        <asp:DataPoint XValue="3" YValues="42" />
                                        <asp:DataPoint XValue="4" YValues="65" />
                                        <asp:DataPoint YValues="0,0" />
                                        <asp:DataPoint YValues="74" />
                                    </Points>
                                </asp:Series>
                                <asp:Series BorderWidth="3" ChartArea="ChartArea1" CustomProperties="DrawingStyle=LightToDark"
                                    Name="Series4" YValuesPerPoint="2">
                                    <Points>
                                        <asp:DataPoint XValue="1" YValues="12,0" />
                                        <asp:DataPoint XValue="2" YValues="32" />
                                        <asp:DataPoint XValue="2" YValues="39" />
                                        <asp:DataPoint XValue="3" YValues="43" />
                                        <asp:DataPoint XValue="4" YValues="73" />
                                        <asp:DataPoint YValues="67" />
                                    </Points>
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea BackColor="Transparent" BackSecondaryColor="Transparent" BorderColor="64, 64, 64, 64"
                                    Name="ChartArea1" ShadowColor="Transparent">
                                    <AxisX LabelAutoFitMaxFontSize="8" LabelAutoFitMinFontSize="8" LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </AxisX>
                                    <AxisY LabelAutoFitMaxFontSize="8" LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </AxisY>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="height: 32px">
                                    <asp:Label ID="Label1" runat="server" Text="Standard Palette:"></asp:Label>
                                </td>
								<td style="height: 32px">
									<asp:dropdownlist id="FontNameList" runat="server" AutoPostBack="True" cssclass="spaceright" Width="141px">
                                        <asp:ListItem>SeaGreen</asp:ListItem>
                                        <asp:ListItem>EarthTones</asp:ListItem>
                                        <asp:ListItem>Pastel</asp:ListItem>
                                        <asp:ListItem>Excel</asp:ListItem>
                                        <asp:ListItem Selected="True">BrightPastel</asp:ListItem>
                                        <asp:ListItem>Pastel</asp:ListItem>
                                        <asp:ListItem>Custom</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
                                    <asp:Label ID="Label2" runat="server" Text="Custom Palette:"></asp:Label></td>
								<td><asp:dropdownlist id="Dropdownlist1" runat="server" AutoPostBack="True" cssclass="spaceright" Width="141px">
                                    <asp:ListItem>CorporateGold</asp:ListItem>
                                    <asp:ListItem>CorporateBlue</asp:ListItem>
                                    <asp:ListItem>Pastel</asp:ListItem>
                                </asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label" style="height: 22px">
									</td>
								<td style="height: 22px">
									</td>
							</tr>
							<tr>
								<td class="label" style="height: 22px"></td>
								<td style="height: 22px">
            <p>
                &nbsp;</p></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
            <p>
                &nbsp;</p></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
            <p>
                &nbsp;</p></td>
							</tr>
							<tr>
								<td class="label" style="height: 22px"></td>
								<td style="height: 22px"></td>
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
