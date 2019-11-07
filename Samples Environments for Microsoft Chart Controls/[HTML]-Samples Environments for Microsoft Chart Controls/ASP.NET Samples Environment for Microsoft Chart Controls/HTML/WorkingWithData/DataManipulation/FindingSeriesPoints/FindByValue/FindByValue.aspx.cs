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
	/// Summary description for FindByValue.
	/// </summary>
	public partial class FindByValue : System.Web.UI.Page
	{
	
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

		protected void RandomData_Click(object sender, System.EventArgs e)
		{
			Random rand = new Random();
			RandomData.CommandArgument = rand.Next().ToString();
		}

		public void AfterLoad()
		{
			// Populate series data
			Random random = new Random(int.Parse(RandomData.CommandArgument));
			for(int pointIndex = 0; pointIndex < 100; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(random.Next(1, 19), random.Next(1, 19), random.Next(1, 19));
			}

			// Get which point value to use
			string	pointValueName = "Y";
			if(ValiesList.SelectedItem.Text == "Second Y Value (Bubble Size)")
			{
				pointValueName = "Y2";
			}
			else if(ValiesList.SelectedItem.Text == "X value")
			{
				pointValueName = "X";
			}

			// Find all point with specified value and change their color
            Series      series = Chart1.Series["Series1"];
            double      valueToFind = 0;

			if(ValueList.SelectedIndex == 0)
			{
				// Find minimum
                DataPoint minPoint = series.Points.FindMinByValue(pointValueName);
                valueToFind = minPoint.GetValueByName(pointValueName);
			}
			else if(ValueList.SelectedIndex == 1)
			{
				// Find maximum
                DataPoint maxPoint = series.Points.FindMaxByValue(pointValueName);
                valueToFind = maxPoint.GetValueByName(pointValueName);
			}
			else									
			{
				// Find by value
				valueToFind = (ValueList.SelectedIndex - 1) * 4;
			}
            //Color all the DataPoints with the specified value            
            foreach(DataPoint dataPoint in series.Points.FindAllByValue(valueToFind, pointValueName))
            {
                dataPoint.Color = Color.FromArgb(255, 128, 128);
            }
        }

	}
}
