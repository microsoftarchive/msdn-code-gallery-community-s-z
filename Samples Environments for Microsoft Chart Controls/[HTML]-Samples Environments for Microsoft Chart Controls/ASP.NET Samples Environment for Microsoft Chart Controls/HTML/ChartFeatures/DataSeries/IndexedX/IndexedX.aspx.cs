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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class IndexedX : System.Web.UI.Page
	{

		protected int Index = 0;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Chart1.Series["Series1"].IsXValueIndexed = XIndexed.Checked;
			DataGrid1.DataSource = this.GetSeriesValues();
			DataGrid1.DataBind();
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
		
		/// <summary>
		/// Generates a DataSet from series
		/// </summary>
		/// <returns>Generated DataSet</returns>
		private DataSet GetSeriesValues()
		{

			Series ser = this.Chart1.Series["Series1"];

			DataSet	dataSet = new DataSet();
			DataTable seriesTable = new DataTable(ser.Name);
			
			seriesTable.Columns.Add( new DataColumn("X", typeof(double)));
			seriesTable.Columns.Add( new DataColumn("Y", typeof(double)));
			
			foreach( DataPoint p in ser.Points)
			{
				seriesTable.Rows.Add( new object[] { p.XValue, p.YValues[0] });
			}
			
			dataSet.Tables.Add( seriesTable );
			return dataSet;
		}

	}
}
