<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.IndexedX" CodeFile="IndexedX.aspx.cs" %>

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
			<p class="dscr">This sample&nbsp;demonstrates how to draw the data points of a 
				series using their indexes instead of their X values.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" Name="Series1" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Font="Trebuchet MS, 8.25pt, style=Bold">
									<points>
										<asp:datapoint XValue="1" Label="1" YValues="5" />
										<asp:datapoint XValue="2" Label="2" YValues="8" />
										<asp:datapoint XValue="7" Label="5" YValues="4" />
										<asp:datapoint XValue="8" Label="6" YValues="7" />
										<asp:datapoint XValue="9" Label="7" YValues="2" />
										<asp:datapoint XValue="4" Label="3" YValues="3" />
										<asp:datapoint XValue="5" Label="4" YValues="6" />
									</points>
								</asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
									<area3dstyle Rotation="10" perspective="10" enable3d="True" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
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
									<p>
										<asp:checkbox id="XIndexed" runat="server" Text="X Values Indexed" AutoPostBack="True" Checked="True"></asp:checkbox></p>
								</td>
							</tr>
							<tr>
								<td class="label48">&nbsp;</td>
								<td>
									Series&nbsp;data points:
									<br/>
									<br/>
									<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" width="192px">
										<alternatingitemstyle backcolor="WhiteSmoke"></alternatingitemstyle>
										<headerstyle backcolor="#FFE0C0"></headerstyle>
										<columns>
											<asp:templatecolumn HeaderText="Index">
												<itemtemplate>
													<%=this.Index++%>
												</itemtemplate>
											</asp:templatecolumn>
											<asp:boundcolumn DataField="X" HeaderText="X Value"></asp:boundcolumn>
											<asp:boundcolumn DataField="Y" HeaderText="Y Value"></asp:boundcolumn>
										</columns>
									</asp:datagrid>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				The series above does not have data points for the X values of 3 and 6, and the 
				data points are not sorted by the X value. Selecting the X Value Indexed check 
                box causes the Chart control to ignore the X 
				values and plot the series' data points using their natural 
				indexed order.</p>
		</form>
	</body>
</html>
