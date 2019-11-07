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
	public partial class ChartAreaPosition : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			// Set Chart Area position
			try
			{
				Chart1.ChartAreas["ChartArea1"].Position.Auto = false;
				Chart1.ChartAreas["ChartArea1"].Position.X = float.Parse(X1.Text);
				Chart1.ChartAreas["ChartArea1"].Position.Y = float.Parse(Y1.Text);
				Chart1.ChartAreas["ChartArea1"].Position.Width = float.Parse(Width1.Text);
				Chart1.ChartAreas["ChartArea1"].Position.Height= float.Parse(Height1.Text);

				if(Chart1.ChartAreas["ChartArea1"].Position.Width <= 10)
				{
					Chart1.ChartAreas["ChartArea1"].Position.Width = 10;
				}
				if(Chart1.ChartAreas["ChartArea1"].Position.Height <= 10)
				{
					Chart1.ChartAreas["ChartArea1"].Position.Height = 10;
				}

				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Auto = false;
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.X = float.Parse(X2.Text);
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Y = float.Parse(Y2.Text);
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Width = float.Parse(Width2.Text);
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Height= float.Parse(Height2.Text);

				if(Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Width <= 10)
				{
					Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Width = 10;
				}
				if(Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Height <= 10)
				{
					Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Height = 10;
				}

			}
			catch(Exception exception)
			{
				// Display exception message in chart title
				Chart1.Titles[0].Text = "ERROR: " + exception.Message;

				// Re-set Chart Area coordinates
				Chart1.ChartAreas["ChartArea1"].Position.X = 10;
				Chart1.ChartAreas["ChartArea1"].Position.Y = 10;
				Chart1.ChartAreas["ChartArea1"].Position.Width = 75;
				Chart1.ChartAreas["ChartArea1"].Position.Height= 75;

				// Re-set Plotting Area coordinates
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.X = 10;
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Y = 10;
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Width = 75;
				Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Height= 75;
			}

			// Set text fields values
			X1.Text = Chart1.ChartAreas["ChartArea1"].Position.X.ToString();
			Y1.Text = Chart1.ChartAreas["ChartArea1"].Position.Y.ToString();
			Width1.Text = Chart1.ChartAreas["ChartArea1"].Position.Width.ToString();
			Height1.Text = Chart1.ChartAreas["ChartArea1"].Position.Height.ToString();

			X2.Text = Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.X.ToString();
			Y2.Text = Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Y.ToString();
			Width2.Text = Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Width.ToString();
			Height2.Text = Chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Height.ToString();
			
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
