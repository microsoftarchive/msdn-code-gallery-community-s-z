
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AnnotationPositioning" CodeFile="AnnotationPositioning.aspx.cs" %>
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
			<p class="dscr">
				This sample demonstrates how to position an annotation by setting the 
				coordinates of the top left corner, width, and height. All coordinates are 
				relative and must range from 0 to 100.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:chart id="Chart1" runat="server" ToolTip="Click on the chart to set the Annotation's top left position." BackSecondaryColor="White" BackColor="#D3DFF0" Palette="BrightPastel" Width="412px" Height="296px" BorderlineDashStyle="Solid" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BackGradientStyle="TopBottom" BorderWidth="2" ImageType="Png">
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series Name="Series1" BorderColor="180, 26, 59, 105"></asp:series>
							</series>
							<annotations>
								<asp:calloutannotation Font="Microsoft Sans Serif, 10pt" BackColor="220, 255, 255, 240" CalloutStyle="RoundedRectangle" Text="Position Me By Mouse\nor UI Controls" Name="Callout1"></asp:calloutannotation>
							</annotations>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 IsLabelAutoFit="False"></axisy2>
									<axisx2 IsLabelAutoFit="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label" style="WIDTH: 127px">X:</td>
								<td><asp:textbox id="TextBoxX" runat="server" Width="100px">35.0</asp:textbox>
									<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="* Required" Display="Dynamic" ControlToValidate="TextBoxX"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 127px">Y:</td>
								<td><asp:textbox id="TextBoxY" runat="server" Width="100px">40.0</asp:textbox>
									<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="* Required" Display="Dynamic" ControlToValidate="TextBoxY"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 127px">Width:</td>
								<td><asp:textbox id="TextBoxWidth" runat="server" Width="100px">40.0</asp:textbox>
									<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ErrorMessage="* Required" Display="Dynamic" ControlToValidate="TextBoxWidth"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 127px">Height:</td>
								<td><asp:textbox id="TextBoxHeight" runat="server" Width="100px">15.0</asp:textbox>
									<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="* Required" Display="Dynamic" ControlToValidate="TextBoxHeight"></asp:requiredfieldvalidator></td>
							</tr>
							<tr>
								<td class="label" style="WIDTH: 127px"></td>
								<td><asp:button id="Button2" runat="server" Text="Set Position"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">
				Set the Chart.RenderType property to InputTag and use the Chart control's server-side Click event to 
				make the chart interactive. This enables you to click on the chart and set the 
                top-left corner coordinates of the annotation.
			</p>
		</form>
	</body>
</html>
