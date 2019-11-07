<%@ Page language="c#" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<link media="all" href="../../samples.css" type="text/css" rel="stylesheet" />
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to&nbsp;use&nbsp;the Chart control without 
				code-behind pages.</p>
			<table class="sampleTable">
				<tr>
					<td class="tdchart">
					
                    <%
						System.Web.UI.DataVisualization.Charting.Chart Chart1 = new System.Web.UI.DataVisualization.Charting.Chart();
						Chart1.Width = 412;
						Chart1.Height = 296;
						Chart1.RenderType = RenderType.ImageTag;
						Chart1.ImageLocation = "..\\..\\TempImages\\ChartPic_#SEQ(200,30)";
						
						Chart1.Palette = ChartColorPalette.BrightPastel;
                        Title t = new Title("No Code Behind Page", Docking.Top, new System.Drawing.Font("Trebuchet MS", 14, System.Drawing.FontStyle.Bold), System.Drawing.Color.FromArgb(26, 59, 105));
                        Chart1.Titles.Add(t);
                        Chart1.ChartAreas.Add("Series 1");

						// create a couple of series
						Chart1.Series.Add("Series 1");
						Chart1.Series.Add("Series 2");
						
						
						// add points to series 1
						Chart1.Series["Series 1"].Points.AddY(5);
						Chart1.Series["Series 1"].Points.AddY(8);
						Chart1.Series["Series 1"].Points.AddY(12);
						Chart1.Series["Series 1"].Points.AddY(6);
						Chart1.Series["Series 1"].Points.AddY(9);
						Chart1.Series["Series 1"].Points.AddY(4);
						 
						// add points to series 2
						Chart1.Series["Series 2"].Points.AddY(2);
						Chart1.Series["Series 2"].Points.AddY(6);
						Chart1.Series["Series 2"].Points.AddY(18);
						Chart1.Series["Series 2"].Points.AddY(16);
						Chart1.Series["Series 2"].Points.AddY(21);
						Chart1.Series["Series 2"].Points.AddY(14);
						  
						Chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
						Chart1.BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
                        Chart1.BorderlineDashStyle = ChartDashStyle.Solid;
						Chart1.BorderWidth = 2;
						
                        Chart1.Legends.Add("Legend1");
						
						    // show legend based on check box value
                        Chart1.Legends["Legend1"].Enabled = ShowLegend.Checked;

						// Render chart control
						Chart1.Page = this;
						HtmlTextWriter writer = new HtmlTextWriter(Page.Response.Output);
						Chart1.RenderControl(writer);
					
                     %>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td class="label48"></td>
								<td>
									<p><asp:checkbox id="ShowLegend" runat="server" Text="Show Legend" AutoPostBack="True"></asp:checkbox></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr">It is recommended that you use code-behind for your ASP.NET pages 
            when using the Chart control. This separates the user interface and its logic.</p>
			<p>
			</p>
			<p>&nbsp;</p>
			<table id="Table1" cellspacing="7" cellpadding="1" border="0">
				<tr>
					<td valign="top" align="left" width="360">
					</td>
					<td valign="top" align="left">
						<p>&nbsp;</p>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
