<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.SerStateManagement" CodeFile="SerStateManagement.aspx.cs" %>

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
		<form id="SM" method="post" runat="server">
			<p class="dscr">
				This sample demonstrates advanced features of the chart state managment.
			</p>
			<table class="sampleTable">
				<tr>
					<TD width="460" class="tdchart">
						<asp:CHART width="460px" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderlineDashStyle="Solid" EnableViewState="True" BackColor="#D3DFF0" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" id="Chart1" runat="server" BorderColor="26, 59, 105" Height="330px" BorderWidth="2">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Advanced State Management" ForeColor="26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend IsTextAutoFit="False" DockedToChartArea="ChartArea1" Docking="Bottom" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" Alignment="Far"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series XValueType="Double" Name="Input" ChartType="Line" BorderColor="180, 26, 59, 105" YValueType="Double"></asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsStartedFromZero="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<MajorTickMark Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
										<MajorTickMark Enabled="False" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td width="37" style="WIDTH: 37px">&nbsp;</td>
								<td><asp:button id="LoadData" runat="server" Text="Load Data" CommandArgument="5" CssClass="spaceright" onclick="LoadData_Click"></asp:button></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 37px"></td>
								<td><asp:checkbox id="EnableStateManagement" runat="server" Checked="True" Text="Enable State Management" AutoPostBack="True"></asp:checkbox>&nbsp;for:</td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 37px"></td>
								<td>&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList id="Persist" runat="server" AutoPostBack="True" CssClass="spaceright" Width="211px">
										<asp:ListItem Value="Default" Selected="True">Data and Appearance</asp:ListItem>
										<asp:ListItem Value="Data">Data</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 37px"></td>
								<td><asp:checkbox id="SeriesAbove" runat="server" AutoPostBack="True" Text="Add Series Above"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 37px"></td>
								<td><asp:checkbox id="SeriesBelow" runat="server" AutoPostBack="True" Text="Add Series Below"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 37px"></td>
								<td></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 37px"></td>
								<td>
									Right Click and Select "View Source" to see persisted data. Notice the dynamic 
									series are not persisted.
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				This sample uses the <strong>Control.ViewState</strong> property and the <strong>
                Chart</strong> 
                control&#39;s serialization feature to perform advanced state management. You can specify what is 
				persisted (data or appearance settings, or both). Note that by using this technique 
                you can also control when the specified chart data is persisted. This is especially useful if 
				you dynamically create data series that you do not want to persist.<BR>
				<BR>
				In this example there is a delay in the routine for adding data to the chart 
				(to simulate a real-world situation with a large data retrieval 
				time). This delay is eliminated when chart data is saved in the view state.<BR>
				<BR>
				For a more simplistic method of managing state see the Basic State Management 
				sample.
			</p>
		</form>
	</body>
</html>
