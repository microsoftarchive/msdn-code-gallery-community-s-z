using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for Templates.
	/// </summary>
	public partial class Templates : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label3;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if(Template.SelectedItem.Value == "None")
			{
				// Reset chart appearance
				Chart1.Serializer.Content = SerializationContents.Appearance;
				Chart1.Serializer.Reset();
			}
			else
			{
				// Load template	
                Chart1.Serializer.IsResetWhenLoading = false;
                Chart1.LoadTemplate(Template.SelectedItem.Value + ".xml");
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
