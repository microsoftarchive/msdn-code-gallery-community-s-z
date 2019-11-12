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
	public partial class CustomizeEvent : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			
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
			this.Chart1.Customize +=new EventHandler(this.OnCustomize); 
		}
		#endregion

        private void OnCustomize(Object sender, EventArgs args)
		{
			// Set new Maximum value for X axis
			Chart1.ChartAreas["ChartArea1"].AxisX.Maximum += double.Parse( XAxis.SelectedItem.Value );

			// Set new Minimum value for X axis
			Chart1.ChartAreas["ChartArea1"].AxisX.Minimum -= double.Parse( XAxis.SelectedItem.Value );

			// Set new Maximum value for Y axis
			Chart1.ChartAreas["ChartArea1"].AxisY.Maximum += double.Parse( YAxis.SelectedItem.Value );

			// Set new Minimum value for Y axis
			Chart1.ChartAreas["ChartArea1"].AxisY.Minimum -= double.Parse( YAxis.SelectedItem.Value );

			// This method will fill labels using 
			// new Minimum and Maximum values. 
			Chart1.ChartAreas["ChartArea1"].RecalculateAxesScale();
		}

		
		
	
	}	
}
