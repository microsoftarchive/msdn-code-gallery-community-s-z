<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BindXMLData" CodeFile="BindXMLData.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>ImageMapCustom</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
  </head>
	<body>
		<form id="ImageMapCustom" method="post" runat="server">
			<p class="dscr">This sample&nbsp;demonstrates how to bind XML data to a Chart control.&nbsp;</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
                        <asp:Chart ID="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                            BackColor="#F3DFC1" Width="412px" Height="296px" BorderColor="181, 64, 1" Palette="BrightPastel" 
                             BorderlineDashStyle="Solid" BackGradientStyle="TopBottom" BorderWidth="2">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="XML Binding" Alignment="TopLeft" ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend LegendStyle="Table" Enabled="False" IsTextAutoFit="False" IsDockedInsideChartArea="False"
                                    Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                                    Alignment="Far">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series BorderWidth="0" ChartArea="ChartArea1" XValueType="Double" Name="Default"
                                    ChartType="Bar" BorderColor="SteelBlue" Color="220, 65, 140, 240" YValueType="Double">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
                                    <AxisY2 Enabled="False">
                                    </AxisY2>
                                    <AxisX2 Enabled="False">
                                    </AxisX2>
                                    <Area3DStyle Rotation="6" Perspective="10" Enable3D="True" Inclination="-29" IsRightAngleAxes="False"
                                        WallWidth="0" IsClustered="False" />
                                    <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="0,k"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Interval="1">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                        <MajorTickMark Enabled="False"></MajorTickMark>
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
