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
	/// Summary description for AxisLabelsInterval.
	/// </summary>
	public partial class AxisLabelsInterval : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if ( !this.IsPostBack )
			{
				this.PopulateData();
			}

			// Set interval and interval type for the Y axis
			if(YAxisIntervalList.SelectedItem.Text != "Auto")
			{
				SetAxisInterval(Chart1.ChartAreas["ChartArea1"].AxisY, double.Parse(YAxisIntervalList.SelectedItem.Text), DateTimeIntervalType.Number);
			}

			int pointCount = int.Parse(PointsNumberList.SelectedItem.Text);
			
			Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = false;	
			
			// Set interval and interval type for the X axis
			if(XAxisIntervalList.SelectedItem.Text == "Every Week (Starting Sunday)")
			{
				SetAxisInterval(Chart1.ChartAreas["ChartArea1"].AxisX, 1, DateTimeIntervalType.Weeks);
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = pointCount > 60;
			}
			else if(XAxisIntervalList.SelectedItem.Text == "Every Week (Starting Monday)")
			{
				SetAxisInterval(Chart1.ChartAreas["ChartArea1"].AxisX, 1, DateTimeIntervalType.Weeks, 1, DateTimeIntervalType.Days);
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = pointCount > 60;
			}
			else if(XAxisIntervalList.SelectedItem.Text == "Every 2 Weeks")
			{
				SetAxisInterval(Chart1.ChartAreas["ChartArea1"].AxisX, 2, DateTimeIntervalType.Weeks);
			}
			else if(XAxisIntervalList.SelectedItem.Text == "Every Month (Starting on 1st)")
			{
				SetAxisInterval(Chart1.ChartAreas["ChartArea1"].AxisX, 1, DateTimeIntervalType.Months);
			}
			else if(XAxisIntervalList.SelectedItem.Text == "Every Month (Starting on 15th)")
			{
				SetAxisInterval(Chart1.ChartAreas["ChartArea1"].AxisX, 1, DateTimeIntervalType.Months, 14, DateTimeIntervalType.Days);
			}

		}

		/// <summary>
		/// Sets interval properties for the axis. 
		/// Note that we use the Axis object's interval properties, and not the properties of its label,
		/// and major tick mark and grid line objects
		/// </summary>
		public void SetAxisInterval(System.Web.UI.DataVisualization.Charting.Axis axis, double interval, DateTimeIntervalType intervalType)
		{
			SetAxisInterval(axis, interval, intervalType, 0, DateTimeIntervalType.Auto);
		}

		/// <summary>
		/// Sets interval properties for the axis. 
		/// Note that we use the Axis object's interval properties, and not the properties of its label,
		/// and major tick mark and grid line objects
		/// </summary>
		public void SetAxisInterval(System.Web.UI.DataVisualization.Charting.Axis axis, double interval, DateTimeIntervalType intervalType, double intervalOffset, DateTimeIntervalType intervalOffsetType )
		{
			// Set interval-related properties
			axis.Interval = interval;
			axis.IntervalType = intervalType;
			axis.IntervalOffset = intervalOffset;
			axis.IntervalOffsetType = intervalOffsetType;
			
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

		protected void PointsNumberList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			PopulateData();
		}

		private void PopulateData()
		{
			// Populate series data
			Random		random = new Random();
			DateTime	dateCurrent = DateTime.Now.Date;
			Chart1.Series["Series1"].Points.Clear();
			int pointCount = int.Parse(PointsNumberList.SelectedItem.Text);
			for(int pointIndex = 0; pointIndex < pointCount; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(dateCurrent.AddDays(pointIndex), random.Next(100, 1000));
			}
		}
	}
}
