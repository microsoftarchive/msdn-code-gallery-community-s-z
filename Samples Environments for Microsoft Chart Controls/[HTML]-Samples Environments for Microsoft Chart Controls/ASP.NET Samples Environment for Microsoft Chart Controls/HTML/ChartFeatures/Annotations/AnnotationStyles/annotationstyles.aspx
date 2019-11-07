<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.AnnotationStyles" CodeFile="AnnotationStyles.aspx.cs" %>

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
			<p class="dscr">This sample demonstrates how to set the different styles of each 
				annotation type. When using each type, you can further adjust the styles.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="Chart1" runat="server" Width="412px" Height="296px" BorderlineDashStyle="Solid" BorderColor="26, 59, 105" BackGradientStyle="TopBottom" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Palette="BrightPastel" BorderWidth="2" BackColor="#D3DFF0">
							<legends>
								<asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"></asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series Name="Default" ChartType="SplineArea" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
									<points>
										<asp:DataPoint YValues="700" />
										<asp:DataPoint YValues="400" />
										<asp:DataPoint YValues="200" />
										<asp:DataPoint YValues="450" />
										<asp:DataPoint YValues="300" />
									</points>
								</asp:Series>
							</series>
							<Annotations>
								<asp:PolylineAnnotation AnchorDataPointName="Default\r1" Name="Polyline1">
								    <GraphicsPathPoints>
								    	<asp:AnnotationPathPoint Y="10" X="10"></asp:AnnotationPathPoint>
										<asp:AnnotationPathPoint Y="20" X="20"></asp:AnnotationPathPoint>
										<asp:AnnotationPathPoint Y="30" X="30"></asp:AnnotationPathPoint>
										<asp:AnnotationPathPoint Y="10" X="40"></asp:AnnotationPathPoint>
										<asp:AnnotationPathPoint Y="10" X="10"></asp:AnnotationPathPoint>
								    </GraphicsPathPoints>
								</asp:PolylineAnnotation>
							</Annotations>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="Transparent" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<area3dstyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False" WallWidth="0" IsClustered="False" />
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
										<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
										<MajorGrid LineColor="64, 64, 64, 64" />
									</axisy>
									<axisx IsMarginVisible="False" LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
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
								<td class="label"><asp:Label id="Label1" runat="server">Annotation Type</asp:Label></td>
								<td><asp:DropDownList id="Annotation" runat="server" AutoPostBack="True">
										<asp:ListItem Value="Line">Line</asp:ListItem>
										<asp:ListItem Value="Vertical Line">Vertical Line</asp:ListItem>
										<asp:ListItem Value="Horizontal Line">Horizontal Line</asp:ListItem>
										<asp:ListItem Value="Text">Text</asp:ListItem>
										<asp:ListItem Value="Rectangle">Rectangle</asp:ListItem>
										<asp:ListItem Value="Ellipse">Ellipse</asp:ListItem>
										<asp:ListItem Value="Arrow" Selected="True">Arrow</asp:ListItem>
										<asp:ListItem Value="Border3D">Border3D</asp:ListItem>
										<asp:ListItem Value="Callout">Callout</asp:ListItem>
										<asp:ListItem Value="Polyline">Polyline</asp:ListItem>
										<asp:ListItem Value="Polygon">Polygon</asp:ListItem>
										<asp:ListItem Value="Image">Image</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label"><asp:Label id="StyleLabel" runat="server">Style</asp:Label></td>
								<td><asp:DropDownList id="AnnotationStyle" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label"><asp:Label id="StyleLabel1" runat="server">Label</asp:Label></td>
								<td><asp:DropDownList id="AnnotationStyle1" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label"><asp:Label id="StyleLabel2" runat="server">Label</asp:Label></td>
								<td><asp:DropDownList id="AnnotationStyle2" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td class="label"></td>
								<td><asp:Button id="UpdateButton" runat="server" Text="Update Chart"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
