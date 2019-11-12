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
	/// Summary description for LegendCells.
	/// </summary>
	public partial class LegendCells : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.DataVisualization.Charting.Chart Chart1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			UpdateChart();            		
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
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
		

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Random random = new Random();
			ButtonRandom.CommandArgument = random.Next().ToString();
		}	
		
		public void UpdateChart()
			{
				// Generate chart data
				this.GenerateData();

				// Set Y-axis minimum
				DataPoint minPoint = this.chart2.Series["Central"].Points.FindMinByValue();
				double min = minPoint.YValues[0];
				this.chart2.ChartAreas["ChartArea1"].AxisY.Minimum = min +1;

				// Set Y-axis maximum
				DataPoint maxPoint = this.chart2.Series["Central"].Points.FindMaxByValue();
				double max = maxPoint.YValues[0];
				this.chart2.ChartAreas["ChartArea1"].AxisY.Maximum = max +1;

				// Set crossing value
				double crossingValue = (max + min) / 2;
				this.chart2.ChartAreas["ChartArea1"].AxisY.Crossing = crossingValue;

				// Format axes
				this.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "F0";
				this.chart2.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "t";

				// Set axis marks to be on bottom
				this.chart2.ChartAreas["ChartArea1"].AxisX.IsMarksNextToAxis = false;

				// Show end labels for Y axis
				this.chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.IsEndLabelVisible = true;

				// Add custom legend item
				this.AddLegendItem();

				// Set custom legend item cell values
				this.SetLegendItemValues();
			}		
		
		// Generate data
		private void GenerateData()
		{
			this.chart2.Series["Central"].Points.Clear();

			Random random = new Random();
			double pointValue = random.Next(2389, 2451);

			DateTime date = DateTime.Parse("9:00AM");

			for (int pointIndex = 0; pointIndex < 481; pointIndex++)
			{
				pointValue = pointValue + random.NextDouble() * 8.0 - 4.0;
				chart2.Series["Central"].Points.AddXY(date.AddMinutes(pointIndex), pointValue);
			}
		}

		// Adds one custom legend item and its cells to the legend
		private void AddLegendItem()
		{
			chart2.Legends["Default"].CustomItems.Clear();

			// Add new custom legend item
			chart2.Legends["Default"].CustomItems.Add(new LegendItem("LegendItem", Color.Red, ""));
			
			// Add five new cells to the custom legend item
			chart2.Legends["Default"].CustomItems[0].Cells.Add(new LegendCell(LegendCellType.Text, "Central",ContentAlignment.MiddleLeft));
			chart2.Legends["Default"].CustomItems[0].Cells.Add(new LegendCell(LegendCellType.Text, "", ContentAlignment.MiddleRight));
			chart2.Legends["Default"].CustomItems[0].Cells.Add(new LegendCell(LegendCellType.Text, "", ContentAlignment.MiddleRight));
			chart2.Legends["Default"].CustomItems[0].Cells.Add(new LegendCell(LegendCellType.Image, "", ContentAlignment.MiddleLeft));
			chart2.Legends["Default"].CustomItems[0].Cells.Add(new LegendCell(LegendCellType.Text, "", ContentAlignment.MiddleLeft));
		}

		private void SetLegendItemValues()
		{
			int pointCount = this.chart2.Series["Central"].Points.Count;

			decimal firstPoint = (decimal)this.chart2.Series["Central"].Points[0].YValues[0];
			decimal lastPoint = decimal.Round((decimal)this.chart2.Series["Central"].Points[pointCount - 1].YValues[0], 2);
			decimal diff = decimal.Round((lastPoint - firstPoint), 2);
			decimal percentChange = decimal.Round(((diff / firstPoint) * (decimal)100.00), 2);

			// Set appearance of cells based on percent change
			if (percentChange < 0)
			{
				chart2.Legends["Default"].CustomItems[0].Cells[2].ForeColor = Color.Red;
				chart2.Legends["Default"].CustomItems[0].Cells[3].Image = @"redsmallarrow.png";
				chart2.Legends["Default"].CustomItems[0].Cells[4].ForeColor = Color.Red;
			}

			else
			{
				chart2.Legends["Default"].CustomItems[0].Cells[2].ForeColor = Color.LimeGreen;
				chart2.Legends["Default"].CustomItems[0].Cells[3].Image = @"greensmallarrow.png";
				chart2.Legends["Default"].CustomItems[0].Cells[4].ForeColor = Color.LimeGreen;
			}
			
			chart2.Legends["Default"].CustomItems[0].Cells[0].Text = "Central";
			chart2.Legends["Default"].CustomItems[0].Cells[1].Text = lastPoint.ToString();
			chart2.Legends["Default"].CustomItems[0].Cells[2].Text = diff.ToString();
			chart2.Legends["Default"].CustomItems[0].Cells[4].Text = percentChange.ToString() + "%";
		}
	}
}
