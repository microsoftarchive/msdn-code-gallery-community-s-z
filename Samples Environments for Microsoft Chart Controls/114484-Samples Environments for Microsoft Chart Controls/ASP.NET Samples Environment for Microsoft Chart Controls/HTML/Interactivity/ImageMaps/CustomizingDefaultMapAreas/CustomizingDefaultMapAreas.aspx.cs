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
	/// Summary description for CustomizingDefaultMapAreas.
	/// </summary>
	public partial class CustomizingDefaultMapAreas : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if ( !this.IsPostBack )
			{
				// Populate series data
				Random random = new Random();
				for(int pointIndex=0; pointIndex < 10; pointIndex++)
				{
					Chart1.Series["Series1"].Points.AddY(random.Next(-100, 100)/10.0);
				}

				// Set series points tooltips
				Chart1.Series["Series1"].ToolTip = "#VALY";
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
			this.Chart1.CustomizeMapAreas += new EventHandler<CustomizeMapAreasEventArgs>(Chart1_CustomizeMapAreas);

		}
		#endregion

		private void Chart1_CustomizeMapAreas(object sender, CustomizeMapAreasEventArgs e)
		{
			// Remove all tooltips of the data points with negative Y values
			if(ShowCustomized.Checked)
			{
				foreach(MapArea item in e.MapAreaItems)
				{
					if(item.ToolTip.StartsWith("-"))
					{
						item.ToolTip = "(" + item.ToolTip.Substring(1) + ")";
					}
				}
			}
		}
	}
}
