
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.Templates" CodeFile="Templates.aspx.cs" %>
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
			<p class="dscr">This sample demonstrates how to load appearance templates. Template 
                files are in an XML format, and can be created using any text editor or by using 
                the Save method of the ChartSerializer class.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart" width="412"><asp:CHART id="Chart1" runat="server" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="412px" Height="260px">
							<legends>
								<asp:Legend LegendStyle="Row" Docking="Bottom" Name="Default" Alignment="Center"></asp:Legend>
							</legends>
							<series>
								<asp:Series Name="Series1">
									<points>
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="4" />
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="9" />
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="2" />
									</points>
								</asp:Series>
								<asp:Series Name="Series2">
									<points>
										<asp:DataPoint YValues="9" />
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="5" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="2" />
										<asp:DataPoint YValues="1" />
										<asp:DataPoint YValues="5" />
									</points>
								</asp:Series>
								<asp:Series Name="Series3" ChartType="Spline">
									<points>
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="1" />
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="9" />
										<asp:DataPoint YValues="2" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1"></asp:ChartArea>
							</chartareas>
						</asp:CHART></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Template:</td>
								<td><asp:dropdownlist id="Template" runat="server" Width="131px" AutoPostBack="True">
										<asp:ListItem Value="SkyBlue" Selected="True">SkyBlue</asp:ListItem>
										<asp:ListItem Value="WarmTones">WarmTones</asp:ListItem>
										<asp:ListItem Value="WhiteSmoke">WhiteSmoke</asp:ListItem>
										<asp:ListItem Value="None">None</asp:ListItem>
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
