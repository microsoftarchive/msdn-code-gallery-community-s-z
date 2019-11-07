<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.ExportForBinding" CodeFile="ExportForBinding.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
  <head>
		<title>ExportForBinding</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../../samples.css" type="text/css" rel="stylesheet"/>
  </head>
	<body>
		<form method="post" runat="server">
			<p class="dscr"> This sample demonstrates exporting series values&nbsp;and data 
				binding.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" Palette="BrightPastel" BackColor="#D3DFF0" Width="412px" Height="296px" BackGradientStyle="TopBottom" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" BorderWidth="2" imagetype="Png" ImageLocation="~\TempImages\ChartPic_#SEQ(300,3)">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Databind to Dataset" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series XValueType="Double" Name="Series1" ChartType="Area" BorderColor="180, 26, 59, 105" Color="220, 224, 64, 10" YValueType="Double"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" perspective="10" enable3d="True" Inclination="15" pointdepth="300" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx IsMarginVisible="False" linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
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
									<asp:label id="ChartData" runat="server" Visible="False"></asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td><asp:label id="ChartDataSchema" runat="server" Visible="False"></asp:label></td>
							</tr>
							<tr>
								<td class="label48"></td>
								<td>
									<asp:datagrid id="SeriesValuesDataGrid" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" HorizontalAlign="Center" PageSize="5" AutoGenerateColumns="False" AllowPaging="True">
										<selecteditemstyle font-bold="True" forecolor="#663399" backcolor="#FFCC66"></selecteditemstyle>
										<itemstyle forecolor="#330099" backcolor="White"></itemstyle>
										<headerstyle font-bold="True" horizontalalign="Center" backcolor="Ivory"></headerstyle>
										<columns>
											<asp:editcommandcolumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Edit Command" CancelText="Cancel" EditText="Edit">
												<headerstyle wrap="False"></headerstyle>
												<itemstyle wrap="False"></itemstyle>
											</asp:editcommandcolumn>
											<asp:boundcolumn DataField="X" ReadOnly="True" HeaderText="X"></asp:boundcolumn>
											<asp:boundcolumn DataField="Y" HeaderText="Y"></asp:boundcolumn>
										</columns>
										<pagerstyle horizontalalign="Center" forecolor="#330099" backcolor="Ivory"></pagerstyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">Click on the Edit links in the DataGrid to 
                edit chart values, and then click on the Update or Cancel link to save or ignore the 
				changes. Data is displayed in multiple pages,&nbsp;and the current page can be 
				changed at the bottom of the DataGrid control.</p>
			<p>
			</p>
		</form>
	</body>
</html>
