<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.RegionChart" CodeFile="RegionChart.aspx.cs" %>
<asp:chart id="Chart1" runat="server" RenderType="BinaryStreaming" ImageType="Png" Height="152px" Width="160px" Palette="BrightPastel" BackColor="#F3DFC1" borderlinestyle="Solid" backgradienttype="TopBottom" borderlinewidth="2" borderlinecolor="181, 64, 1">
	<Titles>
		<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 8pt, style=Bold" ShadowOffset="2" Text="Statistics" Alignment="TopCenter" ForeColor="26, 59, 105"></asp:Title>
	</Titles>
	<Legends>
		<asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
	</Legends>
	<Series>
		<asp:Series Name="Sales" BorderColor="180, 26, 59, 105"></asp:Series>
	</Series>
	<ChartAreas>
		<asp:ChartArea Name="Default" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
			<AxisY LineColor="64, 64, 64, 64">
				<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Format="$#0,k"></LabelStyle>
				<MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
			</AxisY>
			<AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
				<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" Enabled="False"></LabelStyle>
				<MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
			</AxisX>
		</asp:ChartArea>
	</ChartAreas>
</asp:chart>
