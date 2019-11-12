<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ChartArea3D" CodeFile="ChartArea3D.aspx.cs" %>

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
			<p class="dscr" style="WIDTH: 704px; HEIGHT: 48px">
				This sample demonstrates chart rotation, isometric projection, and how to set 
				the width of 3D walls.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#F3DFC1" BorderlineDashStyle="Solid" Palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="2D Chart" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Series1" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:DataPoint YValues="23" />
										<asp:DataPoint YValues="56" />
										<asp:DataPoint YValues="35" />
										<asp:DataPoint YValues="68" />
										<asp:DataPoint YValues="35" />
										<asp:DataPoint YValues="-6" />
										<asp:DataPoint YValues="23" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
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
								<td class="label">Display chart as 3D:</td>
								<td><asp:CheckBox id="ShowIn3D" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Right Angle Axes:</td>
								<td><asp:CheckBox id="RightAngleAxis" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Wall Width:</td>
								<td><asp:dropdownlist id="WallWidth" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="5" Selected="True">5</asp:ListItem>
										<asp:ListItem Value="10">10</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Rotate X:</td>
								<td><asp:dropdownlist id="RotateX" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="-80">-80</asp:ListItem>
										<asp:ListItem Value="-60">-60</asp:ListItem>
										<asp:ListItem Value="-40">-40</asp:ListItem>
										<asp:ListItem Value="-20">-20</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="40" Selected="True">40</asp:ListItem>
										<asp:ListItem Value="60">60</asp:ListItem>
										<asp:ListItem Value="80">80</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">Rotate Y:</td>
								<td><asp:dropdownlist id="RotateY" runat="server" AutoPostBack="True" CssClass="spaceright">
										<asp:ListItem Value="-80">-80</asp:ListItem>
										<asp:ListItem Value="-60">-60</asp:ListItem>
										<asp:ListItem Value="-40">-40</asp:ListItem>
										<asp:ListItem Value="-20">-20</asp:ListItem>
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="20">20</asp:ListItem>
										<asp:ListItem Value="40" Selected="True">40</asp:ListItem>
										<asp:ListItem Value="60">60</asp:ListItem>
										<asp:ListItem Value="80">80</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
