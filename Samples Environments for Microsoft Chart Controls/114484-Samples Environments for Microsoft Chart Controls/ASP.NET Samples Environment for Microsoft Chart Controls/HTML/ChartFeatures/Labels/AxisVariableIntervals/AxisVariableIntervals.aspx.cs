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
    /// Summary description for AxisVariableIntervals.
	/// </summary>
    public partial class AxisVariableIntervals : System.Web.UI.Page
	{

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, System.EventArgs e)
		{            
            SetVariableIntervalLabels();

            Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = GetDateItem(XAxisFormat.SelectedIndex);			
		}

        /// <summary>
        /// Sets the variable interval labels.
        /// </summary>
        private void SetVariableIntervalLabels()
        {
            // variable intervals
            if (this.chk_VarLabelIntervals.Checked)
                this.Chart1.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            else
                this.Chart1.ChartAreas["ChartArea1"].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
        }

        /// <summary>
        /// Gets the date item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        private string GetDateItem(int item)
        {
            string format;
            switch (item)
            {
                case 0:
                    format = "d";
                    break;
                case 1:
                    format = "D";
                    break;
                case 2:
                    format = "ddd,d";
                    break;
                default:
                    format = "";
                    break;
            }

            return format;
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
