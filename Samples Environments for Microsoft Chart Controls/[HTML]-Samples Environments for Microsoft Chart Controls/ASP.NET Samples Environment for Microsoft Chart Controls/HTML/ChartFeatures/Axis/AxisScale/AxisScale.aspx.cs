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
	public partial class Axis : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set Logarithmic scale
			Chart1.ChartAreas["ChartArea1"].AxisY.IsLogarithmic = Logarithmic.Checked;
			
			if ( Logarithmic.Checked )
			{
				AutoScale.Enabled = false;
				AutoScale.Checked = true;
			}
			else
			{
				AutoScale.Enabled = true;
			}
			// Set Auto scale.
			if( AutoScale.Checked )
			{
				// Set auto minimum and maximum values.
				Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Double.NaN;
				Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Double.NaN;
				Maximum.Enabled = false;
				Minimum.Enabled = false;
			}
			else
			{
				// Set manual minimum and maximum values.
				Chart1.ChartAreas["ChartArea1"].AxisY.Minimum = Double.Parse( Minimum.SelectedItem.Value );
				Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Double.Parse( Maximum.SelectedItem.Value );
				Maximum.Enabled = true;
				Minimum.Enabled = true;
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
