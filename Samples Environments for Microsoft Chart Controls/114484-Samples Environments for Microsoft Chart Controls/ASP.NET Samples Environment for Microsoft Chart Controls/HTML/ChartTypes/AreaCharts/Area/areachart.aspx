<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AreaChart" CodeFile="AreaChart.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates Area and Spline Area charts.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BackColor="#D3DFF0" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Series1" ChartType="Area" BorderColor="180, 26, 59, 105" LabelFormat="C"></asp:Series>
								<asp:Series Name="Series2" ChartType="Area" BorderColor="180, 26, 59, 105" LabelFormat="C"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" LightStyle="Realistic" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
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
								<td class="label">Area:</td>
								<td><asp:radiobutton id="Area" runat="server" GroupName="ChartType" Text="" AutoPostBack="True" Checked="True" tabIndex="1"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Spline Area:</td>
								<td><asp:radiobutton id="SplineArea" runat="server" GroupName="ChartType" Text="" AutoPostBack="True" tabIndex="2"></asp:radiobutton></td>
							</tr>
							<tr>
								<td class="label">Show X Axis Margins:</td>
								<td><asp:CheckBox id="ShowMargins" runat="server" Text="" AutoPostBack="True" tabIndex="3"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Show Point Markers and Labels:</td>
								<td><asp:CheckBox id="ShowLabels" runat="server" AutoPostBack="True" Text="" tabIndex="4"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label">Spline Tension:</td>
								<td><asp:DropDownList id="LineTensionList" runat="server" Width="50px" AutoPostBack="True" tabIndex="5" CssClass="spaceright">
										<asp:ListItem Value="1.2">1.2</asp:ListItem>
										<asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
										<asp:ListItem Value="0.4">0.4</asp:ListItem>
										<asp:ListItem Value="0.2">0.2</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td class="label">Show as 3D:</td>
								<td><asp:CheckBox id="Show3D" runat="server" Text="" AutoPostBack="True" tabIndex="6"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
