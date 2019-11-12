<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AxisVariableIntervals" CodeFile="AxisVariableIntervals.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>AxisLabelsInterval</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates how to set variable label intervals.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" Palette="BrightPastel" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
                        <legends>
                            <asp:Legend IsTextAutoFit="False" BackColor="Transparent" Enabled="False" Font="Trebuchet MS, 8.25pt, style=Bold"
                                Name="Default" TitleFont="Microsoft Sans Serif, 8pt, style=Bold">
                            </asp:Legend>
                        </legends>
                        <borderskin SkinStyle="Emboss" />
                        <series>
                            <asp:Series BorderColor="180, 26, 59, 105" ChartArea="ChartArea1" ChartType="Point"
                                Color="220, 65, 140, 240" CustomProperties="DrawingStyle=Emboss, PointWidth=0.9"
                                Name="Series1" XValueType="DateTime" YValueType="Double">
                                <points>
                                    <asp:DataPoint XValue="38859" YValues="1627.00024414063" />
                                    <asp:DataPoint XValue="38872" YValues="1597.52465820313" />
                                    <asp:DataPoint XValue="38885" YValues="1573.08374023438" />
                                    <asp:DataPoint XValue="38900" YValues="1565.83776855469" />
                                    <asp:DataPoint XValue="38914" YValues="1602.314453125" />
                                    <asp:DataPoint XValue="38937" YValues="1642.54650878906" />
                                    <asp:DataPoint XValue="38952" YValues="1672.42822265625" />
                                    <asp:DataPoint XValue="38955" YValues="1648.54187011719" />
                                    <asp:DataPoint XValue="38972" YValues="1621.2138671875" />
                                    <asp:DataPoint XValue="38999" YValues="1572.03967285156" />
                                    <asp:DataPoint XValue="39013" YValues="1578.50500488281" />
                                    <asp:DataPoint XValue="39023" YValues="1558.21801757813" />
                                    <asp:DataPoint XValue="39028" YValues="1573.98608398438" />
                                    <asp:DataPoint XValue="39040" YValues="1576.89086914063" />
                                    <asp:DataPoint XValue="39066" YValues="1529.22045898438" />
                                    <asp:DataPoint XValue="39086" YValues="1564.6845703125" />
                                    <asp:DataPoint XValue="39107" YValues="1578.42370605469" />
                                    <asp:DataPoint XValue="39126" YValues="1576.83520507813" />
                                    <asp:DataPoint XValue="39148" YValues="1596.83947753906" />
                                    <asp:DataPoint XValue="39164" YValues="1597.82250976563" />
                                    <asp:DataPoint XValue="39189" YValues="1609.91809082031" />
                                    <asp:DataPoint XValue="39210" YValues="1621.64306640625" />
                                    <asp:DataPoint XValue="39225" YValues="1652.37719726563" />
                                    <asp:DataPoint XValue="39239" YValues="1642.64147949219" />
                                    <asp:DataPoint XValue="39265" YValues="1657.52587890625" />
                                    <asp:DataPoint XValue="39280" YValues="1696.0537109375" />
                                    <asp:DataPoint XValue="39295" YValues="1738.09729003906" />
                                    <asp:DataPoint XValue="39301" YValues="1702.70324707031" />
                                    <asp:DataPoint XValue="39302" YValues="1667.04479980469" />
                                    <asp:DataPoint XValue="39304" YValues="1694.87805175781" />
                                    <asp:DataPoint XValue="39330" YValues="1740.76208496094" />
                                    <asp:DataPoint XValue="39346" YValues="1734.49072265625" />
                                    <asp:DataPoint XValue="39352" YValues="1778.28210449219" />
                                    <asp:DataPoint XValue="39359" YValues="1815.65502929688" />
                                    <asp:DataPoint XValue="39364" YValues="1824.57739257813" />
                                    <asp:DataPoint XValue="39380" YValues="1860.81774902344" />
                                    <asp:DataPoint XValue="39400" YValues="1852.85168457031" />
                                    <asp:DataPoint XValue="39406" YValues="1888.85827636719" />
                                    <asp:DataPoint XValue="39432" YValues="1908.67980957031" />
                                    <asp:DataPoint XValue="39456" YValues="1891.78784179688" />
                                    <asp:DataPoint XValue="39463" YValues="1940.28552246094" />
                                    <asp:DataPoint XValue="39483" YValues="1913.66760253906" />
                                    <asp:DataPoint XValue="39498" YValues="1943.04370117188" />
                                    <asp:DataPoint XValue="39509" YValues="1970.13403320313" />
                                    <asp:DataPoint XValue="39522" YValues="1970.98876953125" />
                                    <asp:DataPoint XValue="39536" YValues="1979.93005371094" />
                                    <asp:DataPoint XValue="39555" YValues="2006.00573730469" />
                                    <asp:DataPoint XValue="39574" YValues="2043.12377929688" />
                                </points>
                            </asp:Series>
                        </series>
                        <chartareas>
                            <asp:ChartArea BackColor="Gainsboro" BackSecondaryColor="White" BackGradientStyle="TopBottom"
                                BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="Transparent">
                                <axisx IntervalAutoMode="VariableCount" LineColor="64, 64, 64, 64">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt" Format="ddd,d" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </axisx>
                                <area3dstyle IsClustered="False" Perspective="10" IsRightAngleAxes="False" WallWidth="0"
                                    Inclination="15" Rotation="10" />
                                <axisy IsLabelAutoFit="False" LineColor="64, 64, 64, 64" IsStartedFromZero="False">
                                    <LabelStyle Font="Trebuchet MS, 8.25pt" />
                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                </axisy>
                                <axisx2 Enabled="False">
                                </axisx2>
                                <axisy2 Enabled="False">
                                    <MajorGrid Enabled="False" />
                                </axisy2>
                            </asp:ChartArea>
                        </chartareas>
   
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
                                    <asp:CheckBox ID="chk_VarLabelIntervals" runat="server" Text="Variable Label Intervals" AutoPostBack="True" Checked="True" /></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
                                    <asp:Label ID="Label4" runat="server">X Axis Labels Format:</asp:Label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
                                    <asp:DropDownList ID="XAxisFormat" runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="d">Short Date</asp:ListItem>
                                        <asp:ListItem Value="M">Long Date</asp:ListItem>
                                        <asp:ListItem Value="Y">Week Day</asp:ListItem>
                                    </asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label48" style="height: 28px"></td>
								<td style="height: 28px">
									</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
                The Variable Label Interval check box above toggles the IntervalAutoMode 
                property between FixedCount and VariableCount. When selected, the Chart control 
                automatically adjust the number of labels on the x-axis based on the formatting 
                of the x-axis labels. </p>
		</form>
	</body>
</html>
