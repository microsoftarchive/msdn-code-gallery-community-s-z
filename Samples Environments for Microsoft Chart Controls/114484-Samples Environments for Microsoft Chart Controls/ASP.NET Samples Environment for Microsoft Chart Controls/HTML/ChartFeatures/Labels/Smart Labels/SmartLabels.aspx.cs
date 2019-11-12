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
	/// Summary description for LabelsOverlapping.
	/// </summary>
	public partial class SmartLabels : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected System.Web.UI.WebControls.DropDownList DropDownList5;
		protected System.Web.UI.WebControls.DropDownList DropDownList6;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Reduce labels overlapping
			/*if(PreventLabelsOverlapping.Checked)
			{
				Chart1.Series["Default"].SmartLabelStyle.Enabled = true;
			}*/
			FillData();

			SetSmartLabels();
		}

		/// <summary>
		/// Fill Data Points
		/// </summary>
		private void FillData()
		{
			// Remove all data points from collection.
			Chart1.Series[0].Points.Clear();

			// Set initial number of data points.
			int numOfPoints = 50;

			// Get out from this method if all combo boxes 
			// are not initialized.
			if( this.NumOfPoints.SelectedItem.Value != "" )
			{
				numOfPoints = int.Parse( this.NumOfPoints.SelectedItem.Value );
			}
			
			// Initialize random nubers.
			Random rand = new Random( 2 );

			// Data points loop
			for( int index = 0; index <= numOfPoints; index++ )
			{
				// Filling algorithm for not aligned data points
				if( !this.Aligned.Checked )
				{
					Chart1.Series[0].Points.Add( new DataPoint( 0, rand.NextDouble() * 50 ) );
				}
					// Filling algorithm for aligned data points
				else
				{
					if( index == 0 )
					{
						Chart1.Series[0].Points.Add( new DataPoint( 0, rand.NextDouble() * 50 ) );
					}
					else
					{
						Chart1.Series[0].Points.Add( new DataPoint( 0, Chart1.Series[0].Points[index-1].YValues[0] + rand.NextDouble() * 4 - 2 ) );
					}
				}
			}
		}

		/// <summary>
		/// Set values from combo boxes to the chart 
		/// smart labels properties.
		/// </summary>
		private void SetSmartLabels()
		{
			
			// Enable or disable Smart label combo boxes
			if( this.PreventLabelsOverlapping.Checked )
			{
				this.AllowOutsidePlotArea.Enabled = true;
				this.CalloutLineAnchorCap.Enabled = true;
				this.CalloutLineAnchorColor.Enabled = true;
				this.CalloutLineAnchorWidth.Enabled = true;
				this.CalloutStyle.Enabled = true;
			}
			else
			{
				this.AllowOutsidePlotArea.Enabled = false;
				this.CalloutLineAnchorCap.Enabled = false;
				this.CalloutLineAnchorColor.Enabled = false;
				this.CalloutLineAnchorWidth.Enabled = false;
				this.CalloutStyle.Enabled = false;
			}

			// Set values from combo boxes to the chart 
			// smart labels properties.
			Chart1.Series["Default"].SmartLabelStyle.Enabled = this.PreventLabelsOverlapping.Checked;
			Chart1.Series["Default"].SmartLabelStyle.AllowOutsidePlotArea = (LabelOutsidePlotAreaStyle) Enum.Parse( typeof(LabelOutsidePlotAreaStyle), this.AllowOutsidePlotArea.SelectedItem.Value, true );
			Chart1.Series["Default"].SmartLabelStyle.CalloutLineAnchorCapStyle = (LineAnchorCapStyle) Enum.Parse( typeof(LineAnchorCapStyle), this.CalloutLineAnchorCap.SelectedItem.Value, true );
			Chart1.Series["Default"].SmartLabelStyle.CalloutLineColor = Color.FromName( this.CalloutLineAnchorColor.SelectedItem.Value );
			Chart1.Series["Default"].SmartLabelStyle.CalloutLineWidth = int.Parse( this.CalloutLineAnchorWidth.SelectedItem.Value );
			Chart1.Series["Default"].SmartLabelStyle.CalloutStyle = (LabelCalloutStyle) Enum.Parse( typeof(LabelCalloutStyle), this.CalloutStyle.SelectedItem.Value, true );
		
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
