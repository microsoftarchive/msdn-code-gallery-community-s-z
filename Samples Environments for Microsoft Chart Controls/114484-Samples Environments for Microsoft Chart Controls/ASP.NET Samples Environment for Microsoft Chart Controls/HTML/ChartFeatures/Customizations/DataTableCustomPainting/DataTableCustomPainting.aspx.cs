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
using System.Drawing.Drawing2D;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.DataVisualization.Charting.Utilities;


namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class DataTableCustomPainting : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label;
		protected System.Web.UI.DataVisualization.Charting.Utilities.ChartDataTableHelper TableHelper = null;

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

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// bind data but in this case the data is already
			// attached as it is static in aspx file

			if(this.IsPostBack)
			{
				if(ShowTitle.Checked)
					Chart1.ChartAreas["ChartArea1"].AxisX.Title = "This is the X Axis";
				else
					Chart1.ChartAreas["ChartArea1"].AxisX.Title = "";

				Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", float.Parse(FontSize.SelectedItem.ToString()));

			}
			else
			{
				Chart1.ChartAreas["ChartArea1"].AxisX.Title = "This is the X Axis";
				ShowTitle.Checked = true;
				Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8);
				Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = 0;
				DataTable1.Checked = true;
			}

			

			// call method to add data to where the data table will be
			if(DataTable1.Checked)
			{
				TableHelper = new ChartDataTableHelper();
				TableHelper.Initialize(Chart1, ShowTotals.Checked);
				TableHelper.TableColor = Color.FromName(this.TableColor.SelectedItem.Text);
				TableHelper.BorderColor = Color.FromName(this.BorderColor.SelectedItem.Text);
			}

			ShowTotals.Enabled = DataTable1.Checked;
		}




	}	
}
