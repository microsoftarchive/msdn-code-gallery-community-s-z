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
	/// Summary description for LegendCustomPosition.
	/// </summary>
	public partial class AnnotationAnchoring : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			CreateChart();
		}
		
		private void CreateChart()
		{
			// to attach the annotation to the X and Y axis
			Chart1.Annotations[0].AxisX = Chart1.ChartAreas["ChartArea1"].AxisX;
			Chart1.Annotations[0].AxisY = Chart1.ChartAreas["ChartArea1"].AxisY;

			// set the height and width to be automatically
			Chart1.Annotations[0].Width = double.NaN;
			Chart1.Annotations[0].Height= double.NaN;
			Chart1.Annotations[0].X = double.NaN;
			Chart1.Annotations[0].Y = double.NaN;

			string anchorTo = AnchorTo.SelectedItem.Value;
			if(anchorTo == "DataPoint")
			{
				DataPointList.Enabled = true;
				TextBoxX.Enabled = false;
				TextBoxY.Enabled = false;

				// Set the point to anchor
				Chart1.Annotations[0].AnchorDataPoint = Chart1.Series[0].Points[DataPointList.SelectedIndex];

				// Set annotation anchor
				Chart1.Annotations[0].AnchorX = double.NaN;
				Chart1.Annotations[0].AnchorY = double.NaN;

				TextBoxX.Text = Chart1.Annotations[0].AnchorDataPoint.XValue.ToString();
				TextBoxY.Text = Chart1.Annotations[0].AnchorDataPoint.YValues[0].ToString();
			}
			else
			{
				DataPointList.Enabled = false;
				TextBoxX.Enabled = true;
				TextBoxY.Enabled = true;

				Chart1.Annotations[0].AnchorDataPoint = null;

				// Set annotation anchor
				Chart1.Annotations[0].AnchorX = double.Parse(TextBoxX.Text);
				Chart1.Annotations[0].AnchorY = double.Parse(TextBoxY.Text);

				if(Chart1.Annotations[0].AnchorX == Chart1.Annotations[0].AnchorY &&
					Chart1.Annotations[0].AnchorX == 0)
				{
					// 0,0 is not a visible point and will not allow the annotation
					// to be drawn.  Therefore, assign a small by visible point to 
					// the annotation object.  There is no need to update the UI
					Chart1.Annotations[0].AnchorX = 0.0001;
					Chart1.Annotations[0].AnchorY = 0.0001;

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

		




	}
}
