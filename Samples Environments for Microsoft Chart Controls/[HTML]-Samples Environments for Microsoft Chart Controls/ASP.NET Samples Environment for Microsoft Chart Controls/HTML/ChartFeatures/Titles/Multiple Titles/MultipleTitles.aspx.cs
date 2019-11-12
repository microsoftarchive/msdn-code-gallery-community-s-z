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
	/// Summary description for ChartTitle.
	/// </summary>
	public partial class MultipleTitles : System.Web.UI.Page
	{
		protected bool initialized = false;
		protected bool callFromRead = false;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!this.IsPostBack)
			{
				this.Alignment.Items.Add( "Near" );
				this.Alignment.Items.Add( "Center" );
				this.Alignment.Items.Add( "Far" );
				

				this.Alignment.SelectedIndex = 1;

				foreach( string docking in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.Docking)))
				{
					this.Docking.Items.Add( docking );
				}

				this.Docking.SelectedIndex = 3;
			}

			TitleChanged();
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

		
		private void TitleChanged()
		{
			if( this.Alignment.Items[this.Alignment.SelectedIndex].Text == "Near" )
			{
				Chart1.Titles[1].Alignment = ContentAlignment.MiddleLeft;
			}
			else if( this.Alignment.Items[this.Alignment.SelectedIndex].Text == "Far" )
			{
				Chart1.Titles[1].Alignment = ContentAlignment.MiddleRight;
			}
			else
			{
				Chart1.Titles[1].Alignment = ContentAlignment.MiddleCenter;
			}

			// Change Docking
			string docking = (string)(this.Docking.Items[this.Docking.SelectedIndex].Text);
			Chart1.Titles[1].Docking = (System.Web.UI.DataVisualization.Charting.Docking)Enum.Parse( typeof(System.Web.UI.DataVisualization.Charting.Docking), docking );

			// Change Dock inside chart area 
			Chart1.Titles[1].IsDockedInsideChartArea = this.IsDockedInsideChartArea.Checked;

			// Change Dock to chart area
			Chart1.Titles[1].DockedToChartArea = (CheckboxDockToArea.Checked) ? "ChartArea1" : "";
			
			// Enable or disable Dock Inside chart area.
			this.IsDockedInsideChartArea.Enabled = CheckboxDockToArea.Checked;
		}

	}
}
