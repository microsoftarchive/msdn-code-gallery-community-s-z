
<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AnnotationSmartLabels" CodeFile="AnnotationSmartLabels.aspx.cs" %>
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
				This sample demonstrates how to use smart labels in the Annotation object to avoid overlapping 
				other chart elements that use smart labels.
			</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" BackSecondaryColor="White" BackColor="WhiteSmoke" Palette="BrightPastel" Width="412px" Height="296px" BorderlineDashStyle="Solid" BorderColor="26, 59, 105" BackGradientStyle="TopBottom" BorderWidth="2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" ImageType="Png">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series IsValueShownAsLabel="True" MarkerSize="9" Name="Default" ChartType="Point" ShadowColor="Black" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold" LabelFormat="P0">
									<SmartLabelStyle Enabled="True" CalloutStyle="Box" />
									<points>
										<asp:DataPoint YValues="21" />
										<asp:DataPoint YValues="14" />
										<asp:DataPoint YValues="33" />
										<asp:DataPoint YValues="57" />
										<asp:DataPoint YValues="35" />
									</points>
								</asp:Series>
								<asp:Series IsValueShownAsLabel="True" MarkerSize="11" Name="Series2" ChartType="Point" ShadowColor="Black" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold" LabelFormat="P0">
									<SmartLabelStyle Enabled="True" />
									<points>
										<asp:DataPoint YValues="74" />
										<asp:DataPoint YValues="25" />
										<asp:DataPoint YValues="82" />
										<asp:DataPoint YValues="21" />
										<asp:DataPoint YValues="56" />
									</points>
								</asp:Series>
								<asp:Series IsValueShownAsLabel="True" MarkerSize="12" Name="Series3" ChartType="Point" ShadowColor="Black" BorderColor="180, 26, 59, 105" ShadowOffset="1" Font="Trebuchet MS, 8.25pt, style=Bold" LabelFormat="P0">
									<SmartLabelStyle Enabled="True" />
									<points>
										<asp:DataPoint YValues="29" />
										<asp:DataPoint YValues="77" />
										<asp:DataPoint YValues="89" />
										<asp:DataPoint YValues="44" />
										<asp:DataPoint YValues="12" />
									</points>
								</asp:Series>
							</series> 
							<Annotations>
								<asp:CalloutAnnotation Font="Trebuchet MS, 9pt" AnchorDataPointName="Default\r2" BackColor="200, 255, 255, 192" CalloutStyle="Cloud" Text="Cloud Annotation" Name="Callout2">
									<SmartLabelStyle IsOverlappedHidden="False" />
								</asp:CalloutAnnotation>
							</Annotations>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
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
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label">Enable Smart Labels:</td>
								<td><asp:checkbox id="EnableSmartLabels" runat="server" Text="" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td class="label">Hide Overlapped:</td>
								<td><asp:CheckBox id="IsOverlappedHidden" runat="server" Text="" AutoPostBack="True"></asp:CheckBox></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td><asp:Button id="Button1" runat="server" Text="Random Data" onclick="Button1_Click"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
