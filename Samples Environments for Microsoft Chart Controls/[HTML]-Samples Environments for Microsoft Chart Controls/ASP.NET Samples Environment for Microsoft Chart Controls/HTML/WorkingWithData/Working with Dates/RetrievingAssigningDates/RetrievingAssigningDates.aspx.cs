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
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class RetrievingAssigningDates : System.Web.UI.Page
	{
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		/// <summary>
		/// Create random data
		/// </summary>
		private void RandomData()
		{
			Random rand;
			// Use a number to calculate a starting value for 
			// the pseudo-random number sequence
			rand = new Random(int.Parse(Random1.CommandArgument));

			int pointIndx = 1;
			DateTime startDate = DateTime.Parse(Mon1.SelectedItem.Value+"/"+Day1.SelectedItem.Value+"/"+Year1.SelectedItem.Value);
			DateTime endDate = DateTime.Parse(Mon2.SelectedItem.Value+"/"+Day2.SelectedItem.Value+"/"+Year2.SelectedItem.Value);

			Chart1.Series["Series1"].Points.AddXY(startDate.ToOADate(), rand.Next(100) );
			for( int point = 1; startDate.ToOADate() + point <= endDate.ToOADate(); point++ )
			{
				Chart1.Series["Series1"].Points.AddXY(startDate.ToOADate() + point, Chart1.Series["Series1"].Points[pointIndx-1].YValues[0] + rand.NextDouble()*6 - 3 );
				pointIndx++;
			}
		}

		/// <summary>
		/// Find maximum Y value
		/// </summary>
		/// <param name="point">index of a data point which have maximum Y value</param>
		private void FindMaximum( out int point )
		{
			double maxY = double.MinValue;

			point = 0;
			int pointIndex = -1;
			foreach( DataPoint dataPoint in Chart1.Series["Series1"].Points )
			{
				pointIndex++;

				if( dataPoint.XValue < Chart1.ChartAreas["ChartArea1"].AxisX.Minimum )
					continue;

                if (dataPoint.XValue > Chart1.ChartAreas["ChartArea1"].AxisX.Maximum)
					continue;

				if( maxY < dataPoint.YValues[0] )
				{
					maxY = dataPoint.YValues[0];
					point = pointIndex;
				}
			}
		}

		public void AfterLoad()
		{
			// Create random data
			RandomData();

			int year;
			int month;
			int day;

			// Parse string values from a drop down list to an integer value.
			year = int.Parse( Year1.SelectedItem.Value );
			month = int.Parse( Mon1.SelectedItem.Value );
			day = int.Parse( Day1.SelectedItem.Value );

			// Set Minimum value for X axis
			try
			{
                Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = new DateTime(year, month, day).ToOADate();
			}
			catch
			{
                Chart1.ChartAreas["ChartArea1"].AxisX.Minimum = new DateTime(1998, 1, 1).ToOADate();
				Year1.SelectedIndex = 0;
				Mon1.SelectedIndex = 0;
				Day1.SelectedIndex = 0;
			}


			// Parse string values from a drop down list to an integer value.
			year = int.Parse( Year2.SelectedItem.Value );
			month = int.Parse( Mon2.SelectedItem.Value );
			day = int.Parse( Day2.SelectedItem.Value );

			// Set Maximum value for X axis
			try
			{
                Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = new DateTime(year, month, day).ToOADate();
			}
			catch
			{
                Chart1.ChartAreas["ChartArea1"].AxisX.Maximum = new DateTime(2002, 1, 1).ToOADate();
				Year2.SelectedIndex = 0;
				Mon2.SelectedIndex = 0;
				Day2.SelectedIndex = 0;
			}

			int point;

			// X value of the maximum Y value.
			FindMaximum( out point );

			// Convert Double to DateTime.
			DateTime dateTime = DateTime.FromOADate( Chart1.Series["Series1"].Points[point].XValue );

			// Convert DateTime to string.
			Label1.Text = dateTime.ToLongDateString();
									
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
			Random rand = new Random();
			Random1.CommandArgument = rand.Next().ToString();
		}

	
		
		
	
	}	
}
