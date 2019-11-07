<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AxisLabelsInterval" CodeFile="AxisLabelsInterval.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to set axis interval properties, which 
				are applied to the axis' labels, major grid lines, and tick marks.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" Palette="BrightPastel" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" enableviewstate="True" viewstatecontent="All">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:Series ChartArea="ChartArea1" Name="Series1" CustomProperties="DrawingStyle=Emboss, PointWidth=0.9" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<innerplotposition y="2.99507" height="82" width="84.7138" x="8.2422"></innerplotposition>
									<axisy2 enabled="False">
										<majorgrid enabled="False" />
									</axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<position y="5.5423727" height="87.6440659" width="89.43796" x="4.82481766"></position>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" format="dd MMM" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td><asp:label id="Label1" runat="server">Number of Days in Series:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:dropdownlist id="PointsNumberList" runat="server" Width="88px" AutoPostBack="True" onselectedindexchanged="PointsNumberList_SelectedIndexChanged">
										<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
										<asp:ListItem Value="50">50</asp:ListItem>
										<asp:ListItem Value="70">70</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label2" runat="server">X Axis Labels Interval:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="XAxisIntervalList" runat="server" AutoPostBack="True">
										<asp:ListItem Value="Auto" Selected="True">Auto</asp:ListItem>
										<asp:ListItem Value="Every Week (Starting Sunday)">Every Week (Starting Sunday)</asp:ListItem>
										<asp:ListItem Value="Every Week (Starting Monday)">Every Week (Starting Monday)</asp:ListItem>
										<asp:ListItem Value="Every 2 Weeks">Every 2 Weeks</asp:ListItem>
										<asp:ListItem Value="Every Month (Starting at 1st)">Every Month (Starting on 1st)</asp:ListItem>
										<asp:ListItem Value="Every Month (Starting at 15th)">Every Month (Starting on 15th)</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:label id="Label3" runat="server">Y Axis Labels Interval:</asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:dropdownlist id="YAxisIntervalList" runat="server" AutoPostBack="True" Width="203px">
										<asp:listitem Value="Auto" Selected="True">Auto</asp:listitem>
										<asp:listitem>50</asp:listitem>
										<asp:listitem>100</asp:listitem>
										<asp:listitem>200</asp:listitem>
										<asp:listitem>250</asp:listitem>
										<asp:listitem>500</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				Major and minor grid lines, tick marks, and label objects of an axis also have 
				their own interval related properties, which take precedence over the axis 
                properties.</p>
		</form>
	</body>
</html>
