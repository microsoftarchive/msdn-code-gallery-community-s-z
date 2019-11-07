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
	/// Summary description for FilterYValuesRange.
	/// </summary>
	public partial class FilterYValuesRange : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random data
			Random random = new Random();
			for(int pointIndex = 0; pointIndex < 100; pointIndex++)
			{
				Chart1.Series["Series Input"].Points.AddXY(random.Next(50,950), random.Next(50,950));
			}

			// Get filtering criteria constant
			double criteriaValue = double.Parse(MoreValuesList.SelectedItem.Value);

			// Create strip line which covers the area with filtered values
			StripLine stripLine = new StripLine();
			
			stripLine.BackColor = Color.FromArgb(120, 241,185,168);
			stripLine.IntervalOffset = criteriaValue;
			stripLine.StripWidth = 1000;
			if(PointValueList.SelectedItem.Value == "Y")
			{
				Chart1.ChartAreas["ChartArea1"].AxisY.StripLines.Add(stripLine);
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine);
			}

			// Points that do not match the criteria will be removed
			if(MatchCriteriaList.SelectedItem.Value == "False")
			{
				Chart1.DataManipulator.FilterMatchedPoints = false;

				// Update the strip line which covers filtered area
				stripLine.IntervalOffset = 0;
				stripLine.StripWidth = criteriaValue;
			}

			// Filter series data by point's values
			Chart1.DataManipulator.Filter(CompareMethod.MoreThan, criteriaValue, "Series Input", "Series Output", PointValueList.SelectedItem.Value);
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
