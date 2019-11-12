using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for CustomSortingOrder.
	/// </summary>
	public partial class CustomSortingOrder : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			double[]	valueY = {120, 530, 670, 430, 860, 240, 350, 890, 540, 180 };
			string[]	valueX = {"D", "A", "B", "A", "C", "C", "B", "A", "C", "B"};
			Chart1.Series["Original"].Points.DataBindXY(valueX, valueY);
			Chart1.Series["Sorted"].Points.DataBindXY(valueX, valueY);

			// Sort series data points
			if(SortList.SelectedIndex == 0)
			{
				Chart1.DataManipulator.Sort(PointSortOrder.Ascending, "Y", "Sorted");
			}
			else if(SortList.SelectedIndex == 1)
			{
				Chart1.DataManipulator.Sort(PointSortOrder.Ascending, "AxisLabel", "Sorted");
			}
			else
			{
				Chart1.DataManipulator.Sort(new MyComparer(), "Sorted");
			}

			// Use point index for drawing the chart
			Chart1.Series["Sorted"].IsXValueIndexed = true;

			// Mark points in different groups with colors
			foreach(Series series in Chart1.Series)
			{
				foreach(DataPoint point in series.Points)
				{
					if(point.AxisLabel == "A")
					{
						point.Color = Color.FromArgb(220, 65,140,240); //SkyBlue;
					}
					if(point.AxisLabel == "B")
					{
						point.Color = Color.FromArgb(220, 252,180,65); //.LightYellow;
					}
					if(point.AxisLabel == "C")
					{
						point.Color = Color.FromArgb(220, 80,99,129); // Gray
					}
					if(point.AxisLabel == "D")
					{
						point.Color = Color.FromArgb(220,224,64,10); //.Red;
					}
				}
			}
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

		/// <summary>
		/// User defined sorting order logic
		/// </summary>
        private class MyComparer : IComparer<DataPoint>
		{
            public int Compare(DataPoint pointA, DataPoint pointB)
			{
				// Compare axis labels first
				int result = pointA.AxisLabel.CompareTo(pointB.AxisLabel);

				// If axis labels are equal - compare Y values
				if(result == 0)
				{
					result = pointA.YValues[0].CompareTo(pointB.YValues[0]);
				}

				return result;
			}
		}

	}


}
