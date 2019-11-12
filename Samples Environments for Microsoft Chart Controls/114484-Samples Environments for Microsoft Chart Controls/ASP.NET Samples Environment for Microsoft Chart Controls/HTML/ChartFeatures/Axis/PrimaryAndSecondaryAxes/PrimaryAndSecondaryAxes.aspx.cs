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
	public partial class PrimaryAndSecondaryAxes : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Enable secondary Y axis
			if( SecondaryY.Checked )
				Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
			else
				Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.False;

			// Set a characteristic of a plane.
			switch( Characteristics.SelectedItem.Value )
			{

					// Aircraft range
				case "Range":
					// Set Y values
					Chart1.Series["Default"].Points[2].YValues[0] = 5955;
					Chart1.Series["Default"].Points[1].YValues[0] = 7260;
					Chart1.Series["Default"].Points[0].YValues[0] = 8000;

					// Set maximum values for Y axes.
					Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 12000;
					Chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 22224;

					// Set titles for Y axes
					Chart1.ChartAreas["ChartArea1"].AxisY.Title = "In Nautical Miles";
					Chart1.ChartAreas["ChartArea1"].AxisY2.Title = "In Kilometers";

					break;
					// The number of passengers.
				case "Passengers":
					// Set Y values
					Chart1.Series["Default"].Points[2].YValues[0] = 368;
					Chart1.Series["Default"].Points[1].YValues[0] = 416;
					Chart1.Series["Default"].Points[0].YValues[0] = 555;

					// Set maximum values for Y axes.
					Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 800;
					Chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 800;

					// Set titles for Y axes
					Chart1.ChartAreas["ChartArea1"].AxisY.Title = "";
					Chart1.ChartAreas["ChartArea1"].AxisY2.Title = "";

					break;
					// The maximum take of weight.
				case "MaxW":
					// Set Y values
					Chart1.Series["Default"].Points[2].YValues[0] = 660;
					Chart1.Series["Default"].Points[1].YValues[0] = 875;
					Chart1.Series["Default"].Points[0].YValues[0] = 1235;

					// Set maximum values for Y axes.
					Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 1500;
					Chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 680;

					// Set titles for Y axes
					Chart1.ChartAreas["ChartArea1"].AxisY.Title = "In lb x 1000";
					Chart1.ChartAreas["ChartArea1"].AxisY2.Title = "In Tons";

					break;
					// The wing span
				case "WingSpan":
					// Set Y values
					Chart1.Series["Default"].Points[2].YValues[0] = 199;
					Chart1.Series["Default"].Points[1].YValues[0] = 211;
					Chart1.Series["Default"].Points[0].YValues[0] = 261;

					// Set maximum values for Y axes.
					Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 400;
					Chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 121.8;

					// Set titles for Y axes
					Chart1.ChartAreas["ChartArea1"].AxisY.Title = "In Feet";
					Chart1.ChartAreas["ChartArea1"].AxisY2.Title = "In Meters";

					break;
			}
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
