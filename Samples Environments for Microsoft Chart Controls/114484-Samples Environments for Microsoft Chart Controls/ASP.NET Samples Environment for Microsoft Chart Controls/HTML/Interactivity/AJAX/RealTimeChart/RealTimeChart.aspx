<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RealTimeChart" CodeFile="RealTimeChart.aspx.cs"  EnableEventValidation="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>ChartTitle</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
				This sample demonstrates how to create a real time chart using a timer and AJAX Update Panel and callbacks.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" style="width:412px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:Chart ID="Chart1" runat="server" Height="296px" Width="412px" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)"
                            BackColor="#D3DFF0" BorderLineStyle="Solid" BackGradientEndColor="White"
                            BackGradientType="TopBottom" BorderlineWidth="2" BorderlineColor="26, 59, 105"
                             EnableViewState="true">
                            <Series>
                                <asp:Series XValueType="Double" Name="Series1" ChartType="Spline" BorderColor="180, 26, 59, 105"
                                    YValueType="Double" BorderWidth="2" ShadowColor="254, 0, 0, 0" ShadowOffset="1">
                                    <Points>
                                        <asp:DataPoint XValue="0" YValues="32"/>
                                    </Points>
                                </asp:Series>
                                <asp:Series XValueType="Double" Name="Series2" ChartType="Spline" BorderColor="180, 26, 59, 105"
                                    YValueType="Double" BorderWidth="2" ShadowColor="254, 0, 0, 0" ShadowOffset="1">
                                    <Points>
                                        <asp:DataPoint XValue="0" YValues="72"/>
                                    </Points>
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White"
                                    BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                    <Position Y="2" Height="94" Width="94" X="2"></Position>
                                    <AxisY LineColor="64, 64, 64, 64" Maximum="100">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                                    </AxisY>
                                    <AxisX LineColor="64, 64, 64, 64" IsMarginVisible="False" Maximum="100" Minimum="0" IsStartedFromZero="False">
                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold"></LabelStyle>
                                        <MajorGrid LineColor="64, 64, 64, 64" ></MajorGrid>
                                    </AxisX>
                                </asp:ChartArea>
                            </ChartAreas>
                            <BorderSkin SkinStyle="Emboss" />
                        </asp:Chart>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                        </asp:Timer>
                        </ContentTemplate>
                      </asp:UpdatePanel>
                    </td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
