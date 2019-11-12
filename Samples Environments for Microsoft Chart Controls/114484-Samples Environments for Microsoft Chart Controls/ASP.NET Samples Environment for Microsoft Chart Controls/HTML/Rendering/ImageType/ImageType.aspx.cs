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
	/// Summary description for ImageType.
	/// </summary>
	public partial class ImageType : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Disable compression control
			CompressionList.Enabled = false;

			if(ImageTypeList.SelectedItem.Text == "Bmp")
			{
				Chart1.ImageType = ChartImageType.Bmp;
			}
			else if(ImageTypeList.SelectedItem.Text == "Jpeg")
			{
				Chart1.ImageType = ChartImageType.Jpeg;

				// Set Jpeg image compression
				Chart1.Compression = int.Parse(CompressionList.SelectedItem.Text);

				// Enable compression control
				CompressionList.Enabled = true;
			}
			else if(ImageTypeList.SelectedItem.Text == "Png")
			{
				Chart1.ImageType = ChartImageType.Png;
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
