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
	public partial class BubbleChart : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;

		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Set bubble series shape to image
			if(Shape.SelectedItem.Value == "Image")
			{
				Chart1.Series["Series1"].MarkerImage = "Face.bmp";
				Chart1.Series["Series1"].MarkerImageTransparentColor = Color.White;
			}

			// Set "bubble" series shape
			else
			{
				Chart1.Series["Series1"].MarkerStyle = (MarkerStyle)MarkerStyle.Parse(typeof(MarkerStyle), Shape.SelectedItem.Value);
			}

			// Set max bubble size
			Chart1.Series["Series1"]["BubbleMaxSize"] = MaxSize.SelectedItem.Text;
			Chart1.Series["Series2"]["BubbleMaxSize"] = MaxSize.SelectedItem.Text;

			// Show Y value or bubble sise as point labels
			Chart1.Series["Series1"].IsValueShownAsLabel = true;
			Chart1.Series["Series2"].IsValueShownAsLabel = true;
			if(BubbleSizeSizeForLabel.Checked)
			{
				Chart1.Series["Series1"]["BubbleUseSizeForLabel"] = "true";
				Chart1.Series["Series2"]["BubbleUseSizeForLabel"] = "true";
			}

			// Set scale for the bubble size
			if(ScaleMin.SelectedItem.Text != "Auto")
			{
				Chart1.Series["Series1"]["BubbleScaleMin"] = ScaleMin.SelectedItem.Text;
				Chart1.Series["Series2"]["BubbleScaleMin"] = ScaleMin.SelectedItem.Text;
			}
			if(ScaleMax.SelectedItem.Text != "Auto")
			{
				Chart1.Series["Series1"]["BubbleScaleMax"] = ScaleMax.SelectedItem.Text;
				Chart1.Series["Series2"]["BubbleScaleMax"] = ScaleMax.SelectedItem.Text;
			}

			// Show as 2D or 3D
			if(Show3D.Checked)
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
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
