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
	/// Summary description for MultipleLegends.
	/// </summary>
	public partial class MultipleLegends : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Associate each series to the legend specified in the combo box
			Chart1.Series["Series 1"].Legend = DropDownList1.SelectedItem.Text;
			Chart1.Series["Series 2"].Legend = DropDownList2.SelectedItem.Text;
			Chart1.Series["Series 3"].Legend = DropDownList3.SelectedItem.Text;
			Chart1.Series["Series 4"].Legend = DropDownList4.SelectedItem.Text;
			Chart1.Series["Series 5"].Legend = DropDownList5.SelectedItem.Text;
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
