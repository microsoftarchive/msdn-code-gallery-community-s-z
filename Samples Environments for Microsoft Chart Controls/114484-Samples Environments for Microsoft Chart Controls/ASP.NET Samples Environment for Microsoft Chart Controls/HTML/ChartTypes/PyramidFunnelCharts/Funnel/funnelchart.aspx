<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.FunnelChart" CodeFile="FunnelChart.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>PieChart</title>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form id="PieChart" method="post" runat="server">
			<p class="dscr">A Funnel chart is used to display data that adds up to 100%.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" Palette="BrightPastel" BackColor="#D3DFF0" BorderColor="26, 59, 105" BorderWidth="2" BorderlineDashStyle="Solid" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackSecondaryColor="White" BackGradientStyle="TopBottom" ImageType="Png">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Funnel chart" ForeColor="26, 59, 105">
									<position Y="3" Height="6.470197" Width="90"></position>
								</asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" XValueType="Double" Name="Default" ChartType="Funnel" CustomProperties="FunnelMinPointHeight=1" BorderColor="180, 26, 59, 105" LabelFormat="F1" YValueType="Double">
									<points>
										<asp:DataPoint YValues="216.199996948242" />
										<asp:DataPoint YValues="125.800003051758" />
										<asp:DataPoint YValues="90" />
										<asp:DataPoint YValues="2.59999990463257" />
										<asp:DataPoint YValues="55.7000007629395" />
										<asp:DataPoint YValues="25.2999992370605" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<position Y="12" Height="81" Width="89.43796" X="5"></position>
									<axisy LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Funnel Style:</td>
								<td><asp:DropDownList id="FunnelStyleList" runat="server" AutoPostBack="True" Width="130px" CssClass="spaceright">
										<asp:ListItem Value="YIsHeight" Selected="True">YIsHeight</asp:ListItem>
										<asp:ListItem Value="YIsWidth">YIsWidth</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Label Style:</td>
								<td><asp:DropDownList id="LabelStyleList" runat="server" AutoPostBack="True" Width="130px" CssClass="spaceright" onselectedindexchanged="LabelStyleList_SelectedIndexChanged">
										<asp:ListItem Value="OutsideInColumn" Selected="True">OutsideInColumn</asp:ListItem>
										<asp:ListItem Value="Outside">Outside</asp:ListItem>
										<asp:ListItem Value="Inside">Inside</asp:ListItem>
										<asp:ListItem Value="Disabled">Disabled</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Labels Pacement:</td>
								<td><asp:DropDownList id="LabelPlacementList" runat="server" AutoPostBack="True" Width="130px" CssClass="spaceright">
										<asp:ListItem Value="Right" Selected="True">Right</asp:ListItem>
										<asp:ListItem Value="Left">Left</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Points Gap:</td>
								<td><asp:DropDownList id="PointGapList" runat="server" Width="130px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Min. Point Height:</td>
								<td><asp:DropDownList id="MinPointHeight" runat="server" Width="130px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:checkbox id="checkBoxShow3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Rotation Angle:</td>
								<td><asp:DropDownList id="RotationAngleList" runat="server" Width="130px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="-10">-10</asp:ListItem>
										<asp:ListItem Value="-5">-5</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="5" Selected="True">5</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Drawing Style:</td>
								<td><asp:DropDownList id="DrawingstyleList" runat="server" Width="130px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="CircularBase" Selected="True">CircularBase</asp:ListItem>
										<asp:ListItem Value="SquareBase">SquareBase</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
