<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.PreAndPostPaintEvent" CodeFile="PreAndPostPaintEvent.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<%this.AfterLoad();%>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample shows how to use the PrePaint and PostPaint events for 
				custom drawing.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
                        <asp:Chart ID="Chart1" runat="server" Width="412px" Height="296px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                            ImageType="Png" BackColor="#D3DFF0" BackSecondaryColor="White" BackGradientStyle="TopBottom"
                            Palette="BrightPastel" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BorderWidth="2">
                            <Titles>
                                <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                                    Text="PrePaint and PostPaint Events" ForeColor="26, 59, 105">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend LegendStyle="Table" Enabled="False" IsTextAutoFit="False" Docking="Bottom"
                                    Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                                    Alignment="Center">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series MarkerSize="8" BorderWidth="3" Name="Default" ChartType="Spline" MarkerStyle="Diamond"
                                    MarkerColor="AliceBlue" ShadowColor="Black" BorderColor="180, 26, 59, 105" ShadowOffset="2">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                    BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                    BackGradientStyle="TopBottom">
                                    <AxisY LineColor="64, 64, 64, 64" IsStartedFromZero="True">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Click for random data:</td>
								<td><asp:Button id="Random1" runat="server" Text="Random Data" CommandArgument="5" CssClass="spaceright" onclick="Random1_Click"></asp:Button></td>
							</tr>
							<tr>
								<td class="label">Number of data points:</td>
								<td><asp:DropDownList id="Num" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="40">40</asp:ListItem>
										<asp:ListItem Value="60">60</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Connection Line:</td>
								<td><asp:CheckBox id="ConnectionLine" runat="server" Text="" AutoPostBack="True" Checked="True"></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">This sample uses the PrePaint and PostPaint events and GDI+ to draw horizontal lines across the 
				chart area that intersect the maximum and minimum points, highlights the maximum and minimum points custom drawn triangles, 
                and then draws a line that links the maximum and minimum points.</p>
		</form>
	</body>
</html>
