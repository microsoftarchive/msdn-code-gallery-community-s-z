
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.BubbleChart" CodeFile="BubbleChart.aspx.cs" %>
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
		<form id="Form1" method="post" runat="server">
			<p class="dscr"> This sample displays a Bubble chart that 
				uses different shapes, including an image, for the bubble.
			<!-- SECOND DESCRIPTION HERE-->It demonstrates how to control the maximum bubble size and scale as well as 
                how to enable 3D.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" BackColor="#F3DFC1" Width="412px" Height="296px" BorderlineDashStyle="Solid" Palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Bubble Chart" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" YValuesPerPoint="2" Name="Series1" ChartType="Bubble" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Font="Trebuchet MS, 9pt">
									<points>
										<asp:DataPoint YValues="15,8" />
										<asp:DataPoint YValues="18,14" />
										<asp:DataPoint YValues="15,8" />
										<asp:DataPoint YValues="16,13" />
										<asp:DataPoint YValues="14,11" />
									</points>
								</asp:Series>
								<asp:Series IsValueShownAsLabel="True" YValuesPerPoint="2" Name="Series2" ChartType="Bubble" BorderColor="180, 26, 59, 105" Color="220, 255, 64, 10" Font="Trebuchet MS, 9pt">
									<points>
										<asp:DataPoint YValues="9,15" />
										<asp:DataPoint YValues="8,14" />
										<asp:DataPoint YValues="12,10" />
										<asp:DataPoint YValues="9,14" />
										<asp:DataPoint YValues="7,12" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">Bubble Shape:</td>
								<td><asp:DropDownList id="Shape" runat="server" Width="100px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Circle" Selected="True">Circle</asp:ListItem>
										<asp:ListItem Value="Square">Square</asp:ListItem>
										<asp:ListItem Value="Diamond">Diamond</asp:ListItem>
										<asp:ListItem Value="Triangle">Triangle</asp:ListItem>
										<asp:ListItem Value="Cross">Cross</asp:ListItem>
										<asp:ListItem Value="Image">Image</asp:ListItem>
										<asp:ListItem Value="Star4">Star4</asp:ListItem>
										<asp:ListItem Value="Star5">Star5</asp:ListItem>
										<asp:ListItem Value="Star6">Star6</asp:ListItem>
										<asp:ListItem Value="Star10">Star10</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Max. Bubble Size:</td>
								<td><asp:DropDownList id="MaxSize" runat="server" Width="100px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="15" Selected="True">15</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="25">25</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Bubble Size Max. Scale:</td>
								<td><asp:DropDownList id="ScaleMax" runat="server" Width="100px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Auto" Selected="True">Auto</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="25">25</asp:ListItem>
										<asp:ListItem Value="30">30</asp:ListItem>
										<asp:ListItem Value="40">40</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Bubble Size Min. Scale:</td>
								<td><asp:DropDownList id="ScaleMin" runat="server" Width="100px" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="Auto" Selected="True">Auto</asp:ListItem>
										<asp:ListItem Value="-4">-4</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label">Show Bubble Size in Labels:</td>
								<td><asp:CheckBox id="BubbleSizeSizeForLabel" Text="" Checked="True" runat="server" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:CheckBox id="Show3D" tabIndex="6" runat="server" AutoPostBack="True" Text=""></asp:CheckBox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">&nbsp;</p>
		</form>
	</body>
</html>
