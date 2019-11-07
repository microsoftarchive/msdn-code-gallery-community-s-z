
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AnnotationAnchoring" CodeFile="AnnotationAnchoring.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>Annotation</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="LegendCustomPosition" method="post" runat="server">
			<p class="dscr">This sample demonstrates the behavior of the Annotation object with 
				anchoring.
			</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart"><asp:chart id="Chart1" runat="server" BackColor="WhiteSmoke" Width="412px" Height="306px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderlineDashStyle="Solid" palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageType="Png">
							<titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Anchoring Annotations" ForeColor="26, 59, 105"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:series Name="Default" BorderColor="180, 26, 59, 105">
									<points>
										<asp:datapoint XValue="1" YValues="700" />
										<asp:datapoint XValue="2" YValues="400" />
										<asp:datapoint XValue="3" YValues="200" />
										<asp:datapoint XValue="4" YValues="450" />
										<asp:datapoint XValue="5" YValues="300" />
									</points>
								</asp:series>
							</series>
							<annotations>
								<asp:calloutannotation AnchorDataPointName="Default\r0" Text="Set the Anchor of this\nAnnotation Object" Name="Callout1" ToolTip="Don't forget to move the anchor point"></asp:calloutannotation>
							</annotations>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<innerplotposition Y="22" Height="70" Width="77.6568" X="11.42104"></innerplotposition>
									<axisy2 Enabled="True">
										<majorgrid Enabled="False" />
									</axisy2>
									<axisx2 Enabled="False"></axisx2>
									<area3dstyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False"></area3dstyle>
									<position Y="2" Height="93" Width="88.77716" X="5.089137"></position>
									<axisy LineColor="64, 64, 64, 64">
										<labelstyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid LineColor="64, 64, 64, 64" Enabled="False" />
									</axisy>
									<axisx LineColor="64, 64, 64, 64">
										<labelstyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
										<majorgrid LineColor="64, 64, 64, 64" Enabled="False" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart><!-- CHART HERE--></td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Anchor Type:</td>
								<td>
									<p><asp:dropdownlist id="AnchorTo" runat="server" AutoPostBack="True">
											<asp:listitem Value="DataPoint">Anchor To DataPoint</asp:listitem>
											<asp:listitem Value="XY">Anchor To X,Y</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label">Data Point:</td>
								<td>
									<p><asp:dropdownlist id="DataPointList" runat="server" Width="96px" AutoPostBack="True">
											<asp:listitem Value="0">Point 1</asp:listitem>
											<asp:listitem Value="1">Point 2</asp:listitem>
											<asp:listitem Value="2">Point 3</asp:listitem>
											<asp:listitem Value="3">Point 4</asp:listitem>
											<asp:listitem Value="4">Point 5</asp:listitem>
										</asp:dropdownlist></p>
								</td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label1" runat="server" Width="50px">X:</asp:label></td>
								<td><asp:textbox id="TextBoxX" runat="server" Width="40px" Enabled="False">3</asp:textbox></td>
							</tr>
							<tr>
								<td class="label"><asp:label id="Label2" runat="server" Width="50px">Y:</asp:label></td>
								<td><asp:textbox id="TextBoxY" runat="server" Width="40px" Enabled="False">500</asp:textbox></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td>
									<p><asp:button id="UpdateButton" runat="server" Text="Update" width="100px" height="24px"></asp:button></p>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxX" ErrorMessage="X Value Cannot be Empty" cssclass="validator"></asp:requiredfieldvalidator><br/>
									<asp:rangevalidator id="RangeValidator2" runat="server" Type="Double" MinimumValue="0" MaximumValue="6" ControlToValidate="TextBoxX" ErrorMessage="X Value must be between 0 and 6" cssclass="validator"></asp:rangevalidator><br/>
									<asp:rangevalidator id="RangeValidator1" runat="server" Type="Double" MinimumValue="0" MaximumValue="800" ControlToValidate="TextBoxY" ErrorMessage="Y Value Must be between 0 and 800" cssclass="validator"></asp:rangevalidator><br/>
									<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxY" ErrorMessage="Y Value Cannot be Empty" cssclass="validator"></asp:requiredfieldvalidator>
                                    </td>
                                    </tr></table></td>
				</tr>
			</table>
			<p class="dscr">Set the anchor of the Annotation object&nbsp;to a data point or set 
                the anchor to (<i>X</i>,<i>Y</i>) coordinates in the plot area.</p>
		</form>
	</body>
</html>
