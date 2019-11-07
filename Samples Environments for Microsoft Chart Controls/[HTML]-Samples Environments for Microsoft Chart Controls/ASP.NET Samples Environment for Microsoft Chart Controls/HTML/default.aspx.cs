using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
    public partial class IndexPage : System.Web.UI.Page
	{
		private	int		headerHeight = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(this.Session["ANSEController"] == null)
			{				
				ANSEController controller = new ANSEController();

				controller.Init(this.Server.MapPath("."));
				
				this.Session["ANSEController"] = controller;
			}
		}

		private void Page_Init(object sender, System.EventArgs e)
		{
			// Get information about image sizes
			string rootDirectory = this.Server.MapPath(".");
			using( System.Drawing.Image image = System.Drawing.Image.FromFile(rootDirectory + "\\Images\\HeaderLeft.bmp") )
			{
				this.headerHeight = image.Height;
			}

			// Create dynamic images
			if(	!File.Exists(rootDirectory + "\\Images\\HeaderRight2.bmp") ||
				!File.Exists(rootDirectory + "\\Images\\HeaderRight3.bmp"))
			{
				// Load right header image
				System.Drawing.Image imageHeader = System.Drawing.Image.FromFile(rootDirectory + "\\Images\\HeaderRight.bmp");

				// Create new image
				if(	!File.Exists(rootDirectory + "\\Images\\HeaderRight2.bmp") )
				{
					Size	newImageSize = new Size(imageHeader.Width, imageHeader.Height - this.headerHeight);
					using(Bitmap bitmap = new Bitmap(imageHeader, newImageSize.Width, newImageSize.Height))
					{
						using(Graphics graphics = Graphics.FromImage(bitmap))
						{
							graphics.DrawImage(
								imageHeader,
								new Rectangle(0, 0, newImageSize.Width, newImageSize.Height),
								0, imageHeader.Height - newImageSize.Height, newImageSize.Width, newImageSize.Height,
								GraphicsUnit.Pixel,
								new ImageAttributes());

							// Save image into the file
							bitmap.Save(rootDirectory + "\\Images\\HeaderRight2.bmp", ImageFormat.Bmp);
						}
					}
				}

				// Create new image
				if(	!File.Exists(rootDirectory + "\\Images\\HeaderRight3.bmp") )
				{
					Size	newImageSize = new Size(imageHeader.Width, 22);
					using(Bitmap bitmap = new Bitmap(imageHeader, newImageSize.Width, newImageSize.Height))
					{
						using(Graphics graphics = Graphics.FromImage(bitmap))
						{
							graphics.DrawImage(
								imageHeader,
								new Rectangle(0, 0, newImageSize.Width, newImageSize.Height),
								0, imageHeader.Height - (imageHeader.Height - this.headerHeight) + 30, newImageSize.Width, newImageSize.Height,
								GraphicsUnit.Pixel,
								new ImageAttributes());

							// Save image into the file
							bitmap.Save(rootDirectory + "\\Images\\HeaderRight3.bmp", ImageFormat.Bmp);
						}
					}
				}
			}
			
			// Adjust frames height
			if(this.Page.Controls.Count > 0 &&
				this.Page.Controls[0] is LiteralControl)
			{
				// Set height of the header frame
				LiteralControl  literal  = this.Page.Controls[0] as LiteralControl;
				literal.Text = literal.Text.Replace("400,*", this.headerHeight.ToString() + ",*");
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
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);
		}
		#endregion
	}
}
