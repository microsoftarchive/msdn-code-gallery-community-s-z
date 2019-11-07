<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.UsingMarkers" CodeFile="UsingMarkers.aspx.cs" %>

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
			<p class="dscr">This sample shows how to set marker appearance properties. Note 
				that these properties can be applied to all data points in a series&nbsp;or to 
				a single data point.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
						<asp:chart id="Chart1" runat="server" BackColor="#F3DFC1" Width="412px" Height="296px" BorderlineDashStyle="Solid" palette="BrightPastel" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="181, 64, 1" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Using Markers" ForeColor="26, 59, 105" Name="Title1"></asp:Title>
							</titles>
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" BorderWidth="3" ChartArea="ChartArea1" Name="Default" ChartType="Line" MarkerStyle="Circle" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold">
									<points>
										<asp:DataPoint YValues="3" />
										<asp:DataPoint YValues="7" />
										<asp:DataPoint YValues="8" />
										<asp:DataPoint YValues="6" />
										<asp:DataPoint YValues="7" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
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
						</asp:chart></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label"><asp:label id="Label1" runat="server">Marker Shape:</asp:label></td>
								<td>
									<asp:dropdownlist id="Shape" runat="server" AutoPostBack="True" width="103px">
										<asp:listitem Value="Circle" Selected="True">Circle</asp:listitem>
										<asp:listitem Value="Square">Square</asp:listitem>
										<asp:listitem Value="Diamond">Diamond</asp:listitem>
										<asp:listitem Value="Triangle">Triangle</asp:listitem>
										<asp:listitem Value="Cross">Cross</asp:listitem>
										<asp:listitem Value="Image">Image</asp:listitem>
										<asp:listitem Value="Star4">Star4</asp:listitem>
										<asp:listitem Value="Star5">Star5</asp:listitem>
										<asp:listitem Value="Star6">Star6</asp:listitem>
										<asp:listitem Value="Star10">Star10</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server">Marker Size:</asp:label></td>
								<td>
									<asp:dropdownlist id="MarkerSize" runat="server" AutoPostBack="True">
										<asp:listitem Value="5" Selected="True">5</asp:listitem>
										<asp:listitem Value="10">10</asp:listitem>
										<asp:listitem Value="15">15</asp:listitem>
										<asp:listitem Value="20">20</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label3" runat="server" Height="19px" Width="111px">Marker Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="MarkerColor" runat="server" AutoPostBack="True" Height="22px" Width="109px">
										<asp:listitem Value="White" Selected="True">White</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Magenta">Magenta</asp:listitem>
										<asp:listitem Value="Brown">Brown</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td class="label">
									<asp:label id="Label4" runat="server" Height="19px">Marker Border Color:</asp:label></td>
								<td>
									<asp:dropdownlist id="MarkerBorderColor" runat="server" Height="22px" Width="109px" AutoPostBack="True">
										<asp:listitem Value="White">White</asp:listitem>
										<asp:listitem Value="Blue">Blue</asp:listitem>
										<asp:listitem Value="Green">Green</asp:listitem>
										<asp:listitem Value="Yellow">Yellow</asp:listitem>
										<asp:listitem Value="Magenta">Magenta</asp:listitem>
										<asp:listitem Value="Black" Selected="True">Black</asp:listitem>
										<asp:listitem Value="Brown">Brown</asp:listitem>
									</asp:dropdownlist></td>
							</tr>
                            <tr>
                                <td class="label">
                                    <asp:Label ID="Label5" runat="server" Height="19px">Marker Border Width:</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList id="Dropdownlist1" runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
							<tr>
								<td class="label" colspan="2" style="PADDING-LEFT: 26px">
									<asp:checkbox id="ApplyToPoint" runat="server" AutoPostBack="True" Text="Apply to the Third Point Only" width="208px"></asp:checkbox></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
			</p>
		</form>
	</body>
</html>
