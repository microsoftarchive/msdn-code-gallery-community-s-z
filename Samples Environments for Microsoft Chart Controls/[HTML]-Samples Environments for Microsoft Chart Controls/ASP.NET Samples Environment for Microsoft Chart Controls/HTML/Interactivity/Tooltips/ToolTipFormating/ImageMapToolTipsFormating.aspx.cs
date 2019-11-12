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


namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ImageMapToolTipsFormating.
	/// </summary>
	public partial class ImageMapToolTipsFormating : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Add series to the chart
			Series series = Chart1.Series["Default"];

			// Set series tool tips
			series.ToolTip = "X value \t= #VALX{d}\nY value \t= #VALY{C}\nRadius \t= #VALY2{P}";


			// Populate series data
			double[]	yValues = {23.67894, 75.4561, 60.4530, 34.54204, 85.62427, 32.4397, 55.9812734, 67.2345, 56.345234, 23.1452435, 45.24098, 67.41023, 13.452, 56.36356, 45.29654};
			double[]	yRadius = {2.56, 6.1, 7.89, 2.56, 1.23, 5.78, 3.67, 9.7, 4.61, 8.45, 3.67, 7.84, 1.98, 6.56, 3.54};
			DateTime	currentDate = DateTime.Now.Date;

			for(int valueIndex = 0;  valueIndex < yValues.Length; valueIndex++)
			{
				series.Points.AddXY(currentDate.AddDays(valueIndex), yValues[valueIndex], yRadius[valueIndex]);
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

		protected void List_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Chart1.Series["Default"].ToolTip = "X value \t= #VALX{" + FormatXList.SelectedItem.Value;
			Chart1.Series["Default"].ToolTip += "}\nY value \t= #VALY{" + FormatYList.SelectedItem.Value + FormatPrecisionYList.SelectedItem.Value;
			Chart1.Series["Default"].ToolTip += "}\nRadius \t= #VALY2{" + FormatY2List.SelectedItem.Value + FormatPrecisionY2List.SelectedItem.Value + "}";
		}
	}
}
