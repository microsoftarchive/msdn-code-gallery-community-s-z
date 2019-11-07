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
	public partial class UsingMarkers : System.Web.UI.Page
	{

	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Set Marker shape to image
			if(Shape.SelectedItem.Value == "Image")
			{
                if(!ApplyToPoint.Checked)
                {
                    Chart1.Series["Default"].MarkerImage = "Face.bmp";
                    Chart1.Series["Default"].MarkerImageTransparentColor = Color.White;
                }
                else
                {
                    Chart1.Series["Default"].Points[2].MarkerImage = "Face.bmp";
                    Chart1.Series["Default"].Points[2].MarkerImageTransparentColor = Color.White;
                }

				// Disable color and size controls
				MarkerSize.Enabled = false;
				MarkerColor.Enabled = false;
				MarkerBorderColor.Enabled = false;
                Dropdownlist1.Enabled = false;
            }

			// Set "bubble" series shape
			else
			{
                if(!ApplyToPoint.Checked)
                {
                    Chart1.Series["Default"].MarkerStyle = (MarkerStyle)MarkerStyle.Parse(typeof(MarkerStyle), Shape.SelectedItem.Value);
                }
                else
                {
                    Chart1.Series["Default"].Points[2].MarkerStyle = (MarkerStyle)MarkerStyle.Parse(typeof(MarkerStyle), Shape.SelectedItem.Value);
                }
            
				// Enable color and size controls
				MarkerSize.Enabled = true;
				MarkerColor.Enabled = true;
				MarkerBorderColor.Enabled = true;
                Dropdownlist1.Enabled = true;

			}

            
            if(!ApplyToPoint.Checked)
            {
                Chart1.Series["Default"].MarkerSize = Int32.Parse(MarkerSize.SelectedItem.Text);
                Chart1.Series["Default"].MarkerColor = Color.FromName(MarkerColor.SelectedItem.Value);
				Chart1.Series["Default"].MarkerBorderColor = Color.FromName(MarkerBorderColor.SelectedItem.Value);
                Chart1.Series["Default"].MarkerBorderWidth = Int32.Parse(Dropdownlist1.SelectedItem.ToString());
            }
            else
            {
                Chart1.Series["Default"].Points[2].MarkerSize = Int32.Parse(MarkerSize.SelectedItem.Text);
                Chart1.Series["Default"].Points[2].MarkerColor = Color.FromName(MarkerColor.SelectedItem.Value);
				Chart1.Series["Default"].Points[2].MarkerBorderColor = Color.FromName(MarkerBorderColor.SelectedItem.Value);
                Chart1.Series["Default"].Points[2].MarkerBorderWidth = Int32.Parse(Dropdownlist1.SelectedItem.ToString());
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
