<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CallbackEvent" CodeFile="ClickSample.aspx.cs"  EnableEventValidation="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>Click sample</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">
				This sample demonstrates how to use the Chart control&#39;s Click event with AJAX UpdatePanel.<asp:ScriptManager 
                    ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" style="width:412px">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server" style="position:relative; width:412px; height:296px">
                                <asp:Chart ID="Chart1" runat="server" BackColor="#F3DFC1" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                                    Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom"
                                    BorderlineWidth="2" BorderlineColor="181, 64, 1" 
                                        style="position:absolute; top:0px; left: 0px;" onclick="Chart1_Click" 
                                        EnableViewState="True">
                                    <Legends>
                                        <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                                            Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                                        </asp:Legend>
                                    </Legends>
                                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                                    <Series>
                                        <asp:Series MarkerSize="8" XValueType="Double" Name="Series1" ChartType="Bar" ShadowColor="120, 0, 0, 0"
                                            BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" ShadowOffset="1" YValueType="Double"
                                            CustomProperties="DrawingStyle=Cylinder">
                                            <Points>
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" MarkerSize="8"
                                                    YValues="56" XValue="1" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" MarkerSize="8"
                                                    YValues="23" XValue="2" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" MarkerSize="8"
                                                    YValues="87" XValue="3" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" MarkerSize="8"
                                                    YValues="65" XValue="4" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" MarkerSize="8"
                                                    YValues="34" XValue="5" />
                                            </Points>
                                        </asp:Series>
                                        <asp:Series MarkerSize="9" XValueType="Double" Name="Series2" ChartType="Bar" ShadowColor="120, 0, 0, 0"
                                            BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" ShadowOffset="1" YValueType="Double"
                                            CustomProperties="DrawingStyle=Cylinder">
                                            <Points>
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" MarkerSize="9"
                                                    YValues="25" XValue="1" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" MarkerSize="9"
                                                    YValues="78" XValue="2" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" MarkerSize="9"
                                                    YValues="45" XValue="3" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" MarkerSize="9"
                                                    YValues="87" XValue="4" />
                                                <asp:DataPoint BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" MarkerSize="9"
                                                    YValues="22" XValue="5" />
                                            </Points>
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="Default" BorderColor="0, 0, 0, 0" BorderDashStyle="Solid" BackSecondaryColor="0, 0, 0, 0"
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
                                    <Titles>
                                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 12pt, style=Bold" ShadowOffset="3"
                                            Text="Click on the Bar to change the Y value." ForeColor="26, 59, 105" Name="Title1">
                                        </asp:Title>
                                    </Titles>
                                </asp:Chart>
                                <asp:Panel ID="InputPanel" runat="server" Visible="false" style="position: absolute; top: 40px; left:100px; border: black 1px ridge; background-color: white; padding: 3px; white-space:nowrap; ">
                                    <asp:HiddenField ID="PointData" runat="server" />
                                    <asp:TextBox ID="PointValue" runat="server"  Rows="15"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text=" Update " 
                                        onclick="Button1_Click" UseSubmitBehavior="true" />
                                </asp:Panel>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
					<td valign="top">
                        </td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE-->
                </p>
		</form>
	</body>
</html>
