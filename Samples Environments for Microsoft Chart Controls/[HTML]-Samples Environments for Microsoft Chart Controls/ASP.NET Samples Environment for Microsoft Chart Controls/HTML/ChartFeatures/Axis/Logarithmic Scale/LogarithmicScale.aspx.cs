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
	public partial class LogarithmicScale : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set Logarithmic scale
			Chart1.ChartAreas["ChartArea1"].AxisY.IsLogarithmic = Logarithmic.Checked;

			SetData();


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

		protected void Logarithmic_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void SetData()
		{
			// If the Major Interval is not set get out
			if( this.MajorInterval.SelectedItem.Value == "" )
			{
				return;
			}
			
			// The logarithmic scale is enabled
			if( this.Logarithmic.Checked == true )
			{

				// Enable combo boxes
				this.Base.Enabled = true;
				this.MajorInterval.Enabled = true;
				this.MinorInterval.Enabled = true;

				// Enable logarithmic scale
				Chart1.ChartAreas["ChartArea1"].AxisY.IsLogarithmic = true;

				// Set logarithmic base
				if( this.Base.SelectedItem.Value == "10" || this.Base.SelectedItem.Value == "2" )
				{
					Chart1.ChartAreas["ChartArea1"].AxisY.LogarithmBase = double.Parse( this.Base.SelectedItem.Value );
				}
				else
				{
					Chart1.ChartAreas["ChartArea1"].AxisY.LogarithmBase = Math.E;
				}	

				// Set the interval for the axis and minor intervals 
				// for gridlines and tick marks.
				if( this.Base.SelectedItem.Value == "10" && this.Logarithmic.Checked == true )
				{
					this.MinorInterval.Enabled = true;
					Chart1.ChartAreas["ChartArea1"].AxisY.Interval = double.Parse( this.MajorInterval.SelectedItem.Value );
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Interval = double.Parse( this.MinorInterval.SelectedItem.Value );
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = double.Parse( this.MinorInterval.SelectedItem.Value );
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Enabled = true;
				}
				else
				{
					this.MinorInterval.Enabled = false;
					Chart1.ChartAreas["ChartArea1"].AxisY.Interval = double.Parse( this.MajorInterval.SelectedItem.Value );
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Interval = 0;
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = 0;
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = false;
					Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Enabled = false;
				}
			}
			else
			{
				// Logarithmic axis are disabled
				Chart1.ChartAreas["ChartArea1"].AxisY.IsLogarithmic = false;
				this.Base.Enabled = false;
				this.MajorInterval.Enabled = false;
				this.MinorInterval.Enabled = false;				
				Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = 0;
				Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Interval = 0;
				Chart1.ChartAreas["ChartArea1"].AxisY.LogarithmBase = 10;
				Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 0;
				Chart1.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = true;
				Chart1.ChartAreas["ChartArea1"].AxisY.MinorTickMark.Enabled = true;
			}
		}
		
	}	
}
