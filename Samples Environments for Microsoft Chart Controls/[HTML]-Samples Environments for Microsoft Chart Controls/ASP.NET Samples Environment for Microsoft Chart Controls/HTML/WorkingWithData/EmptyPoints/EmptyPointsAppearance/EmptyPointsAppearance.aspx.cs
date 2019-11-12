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
	/// Summary description for EmptyPointsAppearance.
	/// </summary>
	public partial class EmptyPointsAppearance : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if ( !this.IsPostBack)
			{
				foreach( string name in Enum.GetNames(typeof(ChartDashStyle)))
				{
					this.LineDashStyle.Items.Add(name);
				}

				foreach( string name in Enum.GetNames(typeof(MarkerStyle)))
				{
					this.MarkerStyleList.Items.Add(name);
				}

				this.LineDashStyle.Items.FindByValue("Dash").Selected = true;
				this.MarkerStyleList.Items.FindByValue("Diamond").Selected = true;

			}
			
			// Bind Series1 to the array. Points with double.NaN values will be marked as empty
			double[]	yValues = {12, 67, 45, double.NaN, 67, 89, 35, 12, 78, 54};
			double[]	xValues = {1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999};

			Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
			

			string appeanceType = EmptyPointAppearanceList.SelectedItem.Text;

			this.LineColor.Enabled = appeanceType.IndexOf("Line") != -1;
			this.LineSize.Enabled = this.LineColor.Enabled;
			this.LineDashStyle.Enabled = this.LineColor.Enabled;

			this.MarkerColor.Enabled = appeanceType.IndexOf("Marker") != -1;
			this.MarkerSize.Enabled = this.MarkerColor.Enabled;
			this.MarkerStyleList.Enabled = this.MarkerColor.Enabled;

			// Loop through all series
			foreach(Series series in Chart1.Series)
			{
				// Set empty points visual appearance attributes
				series.EmptyPointStyle.Color = Color.Gray;
				series.EmptyPointStyle.BorderWidth = 2;
				series.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash;
				series.EmptyPointStyle.MarkerSize = 7;
				series.EmptyPointStyle.MarkerStyle = MarkerStyle.Cross;
				series.EmptyPointStyle.MarkerBorderColor = Color.Black;
				series.EmptyPointStyle.MarkerColor = Color.LightGray;

				// Adjust visual appearance attributes depending on the user selection
				if(EmptyPointAppearanceList.SelectedItem.Text == "Transparent")
				{
					series.EmptyPointStyle.BorderWidth = 0;
					series.EmptyPointStyle.MarkerStyle = MarkerStyle.None;
				}
				else if(EmptyPointAppearanceList.SelectedItem.Text == "Line")
				{
					series.EmptyPointStyle.BorderDashStyle = (ChartDashStyle) Enum.Parse( typeof(ChartDashStyle), LineDashStyle.SelectedItem.Text, true);
					series.EmptyPointStyle.BorderWidth = int.Parse( LineSize.SelectedItem.Text);
					series.EmptyPointStyle.Color = Color.FromName( LineColor.SelectedItem.Text);
					series.EmptyPointStyle.MarkerStyle = MarkerStyle.None;
				}
				else if(EmptyPointAppearanceList.SelectedItem.Text == "Marker")
				{
					series.EmptyPointStyle.BorderWidth = 0;
					series.EmptyPointStyle.MarkerSize = int.Parse(MarkerSize.SelectedItem.Text);
					series.EmptyPointStyle.MarkerStyle = (MarkerStyle) Enum.Parse( typeof(MarkerStyle), MarkerStyleList.SelectedItem.Text, true);
					series.EmptyPointStyle.MarkerColor = Color.FromName(MarkerColor.SelectedItem.Text);
				}
				else if(EmptyPointAppearanceList.SelectedItem.Text == "Line and Marker")
				{
					series.EmptyPointStyle.BorderDashStyle = (ChartDashStyle) Enum.Parse( typeof(ChartDashStyle), LineDashStyle.SelectedItem.Text, true);
					series.EmptyPointStyle.BorderWidth = int.Parse( LineSize.SelectedItem.Text);
					series.EmptyPointStyle.Color = Color.FromName( LineColor.SelectedItem.Text);
					series.EmptyPointStyle.MarkerSize = int.Parse(MarkerSize.SelectedItem.Text);
					series.EmptyPointStyle.MarkerStyle = (MarkerStyle) Enum.Parse( typeof(MarkerStyle), MarkerStyleList.SelectedItem.Text, true);
					series.EmptyPointStyle.MarkerColor = Color.FromName(MarkerColor.SelectedItem.Text);
				}


				// Set empty points values to zero or average value of the neighbor points
				series["EmptyPointValue"] = EmptyValueList.SelectedItem.Value;
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
