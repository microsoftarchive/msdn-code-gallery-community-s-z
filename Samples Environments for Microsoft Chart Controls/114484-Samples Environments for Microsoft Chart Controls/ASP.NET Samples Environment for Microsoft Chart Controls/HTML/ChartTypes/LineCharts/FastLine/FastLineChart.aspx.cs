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
	/// Summary description for FastLineChart.
	/// </summary>
	public partial class FastLineChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ExplodedPointList;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList HoleSizeList;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
				FillData();

			Chart1.Series["Series1"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), this.ChartTypeList.SelectedItem.Value );
			Chart1.Series["Series2"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), this.ChartTypeList.SelectedItem.Value );
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

		private void FillData() 
		{
			// Fill series data
			double yValue = 50.0;
			double yValue2 = 200.0;
			if(Chart1.Series["Series1"].Points.Count > 0)
			{
				yValue = Chart1.Series["Series1"].Points[Chart1.Series["Series1"].Points.Count - 1].YValues[0];
				yValue2 = Chart1.Series["Series2"].Points[Chart1.Series["Series1"].Points.Count - 1].YValues[0];
			}
			Random random = new Random();
			for(int pointIndex = 0; pointIndex < 20000; pointIndex ++)
			{
				yValue = yValue + (float)( random.NextDouble( ) * 10.0 - 5.0  );
				Chart1.Series["Series1"].Points.AddY(yValue);

				yValue2 = yValue2 + (float)( random.NextDouble( ) * 10.0 - 5.0  );
				Chart1.Series["Series2"].Points.AddY(yValue2);
			}
		}

	}
}
