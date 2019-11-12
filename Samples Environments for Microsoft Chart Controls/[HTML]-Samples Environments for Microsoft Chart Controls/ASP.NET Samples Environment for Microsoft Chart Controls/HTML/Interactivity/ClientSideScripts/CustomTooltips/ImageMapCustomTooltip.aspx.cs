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
	/// Summary description for ImageMapCustomTooltip.
	/// </summary>
	public partial class ImageMapCustomTooltip : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			UpdateAttrib();
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

		protected void ContentList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAttrib();
		}

		public void UpdateAttrib()
		{
			string strToolTip = ContentList.SelectedItem.Value;

			// Set series tooltips
			if(strToolTip == "flag" || strToolTip == "chart")
			{
				foreach(Series series in Chart1.Series)
				{
					for(int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
					{
						string toolTip = "";
						if(strToolTip == "chart")
						{
							string medalParams = "&gold=" + Chart1.Series["Gold"].Points[pointIndex].YValues[0];
							medalParams += "&silver=" + Chart1.Series["Silver"].Points[pointIndex].YValues[0];
							medalParams += "&bronze=" + Chart1.Series["Bronze"].Points[pointIndex].YValues[0];

							toolTip = "<IMG SRC=CountryChart.aspx?country=" + series.Points[pointIndex].AxisLabel + medalParams + ">";
						}
						else
						{
							toolTip = "<IMG SRC=" + series.Points[pointIndex].AxisLabel + ".gif>";
						}
						series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
					}
				}			
			}
			else
			{
				foreach(Series series in Chart1.Series)
				{
					series.MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + strToolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
					series.LegendMapAreaAttributes = "onmouseover=\"DisplayTooltip('Total of #TOTAL #SER medals');\" onmouseout=\"DisplayTooltip('');\"";
				}
			}

			// Set legend tooltips
			foreach(Series series in Chart1.Series)
			{
				series.LegendMapAreaAttributes = "onmouseover=\"DisplayTooltip('Total of #TOTAL #SER medals');\" onmouseout=\"DisplayTooltip('');\"";
			}

		}
	}
}
