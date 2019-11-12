<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.TimeScale" CodeFile="TimeScale.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>TimeScale</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0" />
		<meta name="CODE_LANGUAGE" content="C#" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr">This sample demonstrates a real time scale, where&nbsp;data point 
				positions depend on X values of the DateTime type.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" Height="296px" Width="412px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" backcolor="#F3DFC1" BorderColor="181, 64, 1" enableviewstate="True" viewstatecontent="All">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" CustomProperties="LabelsRadialLineSize=1, LabelStyle=outside" BorderColor="180, 26, 59, 105" Color="194, 65, 140, 240"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False"></axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<asp:checkbox id="UseIndex" runat="server" AutoPostBack="True" Text="X Values Indexed"></asp:checkbox>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:button id="RandomData" runat="server" Text="Random Data" CommandArgument="5" width="153px" onclick="RandomData_Click"></asp:button>
								</td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									Series Data: <br/>
									<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
										<alternatingitemstyle backcolor="FloralWhite"></alternatingitemstyle>
										<headerstyle backcolor="#E0E0E0"></headerstyle>
										<columns>
											<asp:boundcolumn DataField="No" HeaderText="#">
												<headerstyle width="20px"></headerstyle>
											</asp:boundcolumn>
											<asp:boundcolumn DataField="X" HeaderText="X" DataFormatString="{0:MM/dd/yyyy}">
												<headerstyle width="80px"></headerstyle>
											</asp:boundcolumn>
											<asp:boundcolumn DataField="Y" HeaderText="Y">
												<headerstyle width="40px"></headerstyle>
												<itemstyle horizontalalign="Right"></itemstyle>
											</asp:boundcolumn>
										</columns>
									</asp:datagrid>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">When X Values Indexed is checked, the index of the data points (instead of the 
				DateTime X values)&nbsp;determine the their positions along the 
				x-axis.</p>
		</form>
	</body>
</html>
