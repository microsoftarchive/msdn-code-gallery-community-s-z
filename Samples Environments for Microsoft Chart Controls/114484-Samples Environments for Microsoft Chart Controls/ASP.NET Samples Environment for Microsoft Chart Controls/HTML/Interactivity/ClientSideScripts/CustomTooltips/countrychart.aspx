<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.CountryChart" CodeFile="CountryChart.aspx.cs" %>
<asp:chart id="Chart1" runat="server" RenderType="BinaryStreaming" ImageType="Png" Height="100px" Width="110px" BackColor="LemonChiffon" >
	<titles>
		<asp:title Text="Statistics" Name="Default Title"></asp:title>
	</titles>
	<legends>
		<asp:legend Enabled="False" Name="Default"></asp:legend>
	</legends>
	<series>
		<asp:series Name="Default" ChartType="Pie" BorderColor="Gray" ShadowOffset="3"></asp:series>
	</series>
	<chartareas>
		<asp:chartarea Name="Default" BackColor="LemonChiffon" BorderWidth="0"></asp:chartarea>
	</chartareas>
</asp:chart>
