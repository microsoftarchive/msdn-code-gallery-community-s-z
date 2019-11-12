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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class LineCurves3D : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data
			Random	random = new Random();
			for(int pointIndex = 0; pointIndex < 10; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddY(random.Next(45, 95));
				Chart1.Series["Series2"].Points.AddY(random.Next(5, 75));
				Chart1.Series["Series3"].Points.AddY(random.Next(5, 75));
			}

			// Set series chart type
			Chart1.Series["Series1"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Text, true );
			Chart1.Series["Series2"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Text, true );
			Chart1.Series["Series3"].ChartType = (SeriesChartType) Enum.Parse( typeof(SeriesChartType), ChartTypeList.SelectedItem.Text, true );

			// Set point labels
			if(PointLabelsList.SelectedItem.Text != "None")
			{
				Chart1.Series["Series1"].IsValueShownAsLabel = true;
				Chart1.Series["Series2"].IsValueShownAsLabel = true;
				Chart1.Series["Series3"].IsValueShownAsLabel = true;
				if(PointLabelsList.SelectedItem.Text != "Auto")
				{
					Chart1.Series["Series1"]["LabelStyle"] = PointLabelsList.SelectedItem.Text;
					Chart1.Series["Series2"]["LabelStyle"] = PointLabelsList.SelectedItem.Text;
					Chart1.Series["Series3"]["LabelStyle"] = PointLabelsList.SelectedItem.Text;
				}
			}

			// Set X axis margin
			Chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = ShowMargins.Checked;

			// Set Show of marker Lines
			Chart1.Series["Series1"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();
			Chart1.Series["Series2"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();
			Chart1.Series["Series3"]["ShowMarkerLines"] = ShowMarkers.Checked.ToString();
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

	}
}
