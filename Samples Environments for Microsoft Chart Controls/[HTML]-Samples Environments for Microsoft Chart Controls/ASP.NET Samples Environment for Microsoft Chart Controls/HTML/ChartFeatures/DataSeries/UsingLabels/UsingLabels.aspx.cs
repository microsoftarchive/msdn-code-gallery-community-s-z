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
	/// Summary description for LabelsTextStyle.
	/// </summary>
	public partial class UsingLabels : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            foreach (Series series in Chart1.Series)
            {
                series["LabelStyle"] = LabelPosition.SelectedItem.Text;

                // Set labels font
                series.Font = new Font(FontNameList.SelectedItem.Text, 8);

                // Set labels angle - smart ables must be disabled to set LabelAngel
                series.SmartLabelStyle.Enabled = false;
                series.LabelAngle = int.Parse(FontAngleList.SelectedItem.Text);

                // Set labels color
                series.LabelForeColor = Color.FromName(ForeColor.SelectedItem.Text); ;

                // Set labels background color
                series.LabelBackColor = Color.FromName(BackColorList.SelectedItem.Text);

                //labels border color
                series.LabelBorderColor = Color.FromName(BorderColorList.SelectedItem.Text);

                // Set labels border width
                series.LabelBorderWidth = int.Parse(BorderSizeList.SelectedItem.Text);
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
