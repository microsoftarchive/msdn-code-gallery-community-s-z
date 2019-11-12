using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for LegendCustomItems.
	/// </summary>
	public partial class LegendCustomItems : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{


			// Disable legend item for the first series
			Chart1.Series[0].IsVisibleInLegend = false;

			// Add simple custom legend item
			Chart1.Legends["Default"].CustomItems.Add(Color.FromArgb(32, 120,147,190), "Critical Values");

			// Add custom legend item with line style
			LegendItem legendItem = new LegendItem();
			legendItem.Name = "Line Style Item";
			legendItem.ImageStyle = LegendImageStyle.Line;
			legendItem.ShadowOffset = 1;
			legendItem.Color = Color.LightBlue;
			legendItem.MarkerStyle = MarkerStyle.Circle;
			Chart1.Legends["Default"].CustomItems.Add(legendItem);

			// Add custom legend item with marker style
			legendItem = new LegendItem();
			legendItem.Name = "Marker Style Item";
			legendItem.ImageStyle = LegendImageStyle.Marker;
			legendItem.ShadowOffset = 1;
			legendItem.Color = Color.Yellow;
			legendItem.MarkerStyle = MarkerStyle.Cross;
			legendItem.MarkerSize = 10;
			legendItem.MarkerBorderColor = Color.Black;
			Chart1.Legends["Default"].CustomItems.Add(legendItem);

			legendItem = new LegendItem();
			legendItem.Name = "Image Style Item";
			legendItem.Image = "Flag.gif";
			legendItem.BackImageTransparentColor = Color.White;
			Chart1.Legends["Default"].CustomItems.Add(legendItem);


			// Add a strip line
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Chart1.Legends["Default"].CustomItems[0].Color;
			stripLine.IntervalOffset = 500;
			stripLine.StripWidth = 300;
			Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
