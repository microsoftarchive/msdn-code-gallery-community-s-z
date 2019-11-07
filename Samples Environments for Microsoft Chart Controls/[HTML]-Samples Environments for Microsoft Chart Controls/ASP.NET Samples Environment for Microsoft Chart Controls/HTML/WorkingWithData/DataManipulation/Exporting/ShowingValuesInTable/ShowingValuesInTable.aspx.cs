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
	/// Summary description for ShowinfValuesInTable.
	/// </summary>
	public partial class ShowinfValuesInTable : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data using random data
			double[]	yValues = {23.67, 75.45, 60.45, 34.54, 85.62, 32.43, 55.98, 34.89};
			for(int pointIndex = 0; pointIndex < yValues.Length; pointIndex++)
			{
				Chart1.Series["Series1"].Points.AddXY(2000 + pointIndex, yValues[pointIndex]);
			}

		}

		/// <summary>
		/// Initialize table from the DataSet object.
		/// </summary>
		/// <param name="table">Table object to initialize.</param>
		/// <param name="dataSet">Series data.</param>
		/// <param name="tableName">Series name to be used.</param>
		/// <param name="firstColumnWidth">First column width.</param>
		/// <param name="otherColumnWidth">Others columns width.</param>
		public void InitializeTable(Table table, DataSet dataSet, string tableName, int firstColumnWidth, int otherColumnWidth)
		{
			foreach(DataColumn column in dataSet.Tables[tableName].Columns)
			{
				// Create new table row for each column
				TableRow row = new TableRow();

				// Add title cell
				TableCell cell = new TableCell();
				cell.Controls.Add(new LiteralControl(dataSet.Tables[tableName].TableName + 
					" - " + column.ColumnName));
				cell.Width = new Unit(firstColumnWidth, UnitType.Pixel);
				row.Cells.Add(cell);

				// Add data cells
				int pointIndex = 0;
				foreach(DataRow dataRow in dataSet.Tables[tableName].Rows)
				{
					TableCell dataCell = new TableCell();
					dataCell.Controls.Add(new LiteralControl(dataRow[column].ToString()));
					dataCell.Width = new Unit(otherColumnWidth, UnitType.Pixel);
					dataCell.HorizontalAlign = HorizontalAlign.Center;
					row.Cells.Add(dataCell);
					++pointIndex;
				}

				// Add row into the table
				table.Rows.Add(row);
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
			this.Chart1.PostPaint +=new EventHandler<ChartPaintEventArgs>(this.Chart1_PostPaint);
		}
		#endregion

		private void Chart1_PostPaint(object sender, EventArgs e1)
		{
            ChartPaintEventArgs e = e1 as ChartPaintEventArgs;
			if(sender is Chart)
			{
				// Calculate data cell width
				int	cellWidth = (int)Chart1.ChartAreas["ChartArea1"].AxisX.GetPosition(Chart1.Series["Series1"].Points[1].XValue);
				cellWidth -= (int)Chart1.ChartAreas["ChartArea1"].AxisX.GetPosition(Chart1.Series["Series1"].Points[0].XValue);
				cellWidth = (int)e.ChartGraphics.GetAbsolutePoint(new PointF(cellWidth, 0)).X;

				// Calculate first column width
				int	firstCellWidth = (int)Chart1.ChartAreas["ChartArea1"].AxisX.GetPosition(Chart1.Series["Series1"].Points[0].XValue - 0.5);
				firstCellWidth = (int)e.ChartGraphics.GetAbsolutePoint(new PointF(firstCellWidth, 0)).X;

				// Show exported series values in the table
				InitializeTable(ValuesTable, Chart1.DataManipulator.ExportSeriesValues(), "Series1", firstCellWidth + 6, cellWidth-3);
			}
		}
	}
}
