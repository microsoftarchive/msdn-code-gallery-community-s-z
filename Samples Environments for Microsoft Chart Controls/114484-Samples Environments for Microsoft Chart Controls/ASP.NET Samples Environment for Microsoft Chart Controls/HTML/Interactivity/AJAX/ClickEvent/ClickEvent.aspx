<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ClickEvent" CodeFile="ClickEvent.aspx.cs"  EnableEventValidation="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>ChartTitle</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to use the Click event in the Chart control.<asp:ScriptManager 
                    ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" style="height: 302px; width: 412px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:Chart ID="Chart1" runat="server" BackColor="#D3DFF0" ImageType="Png"
                            ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderLineStyle="Solid"
                            BackGradientStyle="TopBottom" BorderlineWidth="2" 
                            BorderlineColor="26, 59, 105" onclick="Chart1_Click" 
                            style="position:relative; top: 4px; left: 0px;">
                            <Titles>
                                <asp:Title Font="Trebuchet MS, 12pt, style=Bold" Name="Default Title" Text="   Click on the Chart!">
                                </asp:Title>
                                <asp:Title DockingOffset="-8" DockedToChartArea="Default" Font="Trebuchet MS, 8pt" Name="ClickedElement"
                                    Text="Last Clicked Element: Nothing">
                                </asp:Title>
                            </Titles>
                            <Legends>
                                <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                                    Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                                </asp:Legend>
                            </Legends>
                            <BorderSkin SkinStyle="Emboss"></BorderSkin>
                            <Series>
                                <asp:Series CustomProperties="DrawingStyle=Emboss" Name="Series1" BorderColor="180, 26, 59, 105"
                                    Color="220, 65, 140, 240">
                                    <Points>
                                        <asp:DataPoint YValues="6"></asp:DataPoint>
                                        <asp:DataPoint YValues="9"></asp:DataPoint>
                                        <asp:DataPoint YValues="5"></asp:DataPoint>
                                        <asp:DataPoint YValues="7.5"></asp:DataPoint>
                                        <asp:DataPoint YValues="5.69999980926514"></asp:DataPoint>
                                        <asp:DataPoint YValues="3.20000004768372"></asp:DataPoint>
                                        <asp:DataPoint YValues="8.5"></asp:DataPoint>
                                        <asp:DataPoint YValues="7.5"></asp:DataPoint>
                                        <asp:DataPoint YValues="6.5"></asp:DataPoint>
                                    </Points>
                                </asp:Series>
                                <asp:Series CustomProperties="DrawingStyle=Emboss" Name="Series2" BorderColor="180, 26, 59, 105"
                                    Color="220, 252, 180, 65">
                                    <Points>
                                        <asp:DataPoint YValues="6"></asp:DataPoint>
                                        <asp:DataPoint YValues="9"></asp:DataPoint>
                                        <asp:DataPoint YValues="2"></asp:DataPoint>
                                        <asp:DataPoint YValues="7"></asp:DataPoint>
                                        <asp:DataPoint YValues="3"></asp:DataPoint>
                                        <asp:DataPoint YValues="5"></asp:DataPoint>
                                        <asp:DataPoint YValues="8"></asp:DataPoint>
                                        <asp:DataPoint YValues="2"></asp:DataPoint>
                                        <asp:DataPoint YValues="6"></asp:DataPoint>
                                    </Points>
                                </asp:Series>
                                <asp:Series CustomProperties="DrawingStyle=Emboss" Name="Series3" BorderColor="180, 26, 59, 105"
                                    Color="220, 224, 64, 10">
                                    <Points>
                                        <asp:DataPoint YValues="4"></asp:DataPoint>
                                        <asp:DataPoint YValues="5"></asp:DataPoint>
                                        <asp:DataPoint YValues="2"></asp:DataPoint>
                                        <asp:DataPoint YValues="6"></asp:DataPoint>
                                        <asp:DataPoint YValues="1"></asp:DataPoint>
                                        <asp:DataPoint YValues="2"></asp:DataPoint>
                                        <asp:DataPoint YValues="3"></asp:DataPoint>
                                        <asp:DataPoint YValues="1"></asp:DataPoint>
                                        <asp:DataPoint YValues="2"></asp:DataPoint>
                                    </Points>
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="Default" BorderColor="0, 0, 0, 0" BackSecondaryColor="0, 0, 0, 0"
                                    BackColor="0, 0, 0, 0" ShadowColor="0, 0, 0, 0" BackGradientStyle="TopBottom">
                                    <AxisY LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
					<td valign="top" style="height: 302px">
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->
                Note that the Chart picture is updated using AJAX UpdatePanel without updating the rest of the page.</p>
            
		</form>
	</body>
</html>
