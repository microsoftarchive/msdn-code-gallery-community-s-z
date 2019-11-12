using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
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
	/// Summary description for ExportForBinding.
	/// </summary>
	public partial class ExportForBinding : System.Web.UI.Page
	{
		protected System.Data.DataSet seriesDataSet;
		protected System.Data.DataTable SeriesValuesDataTable;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate series data using random data
			if(ChartData.Text == String.Empty)
			{
				double[]	yValues = {23.67, 75.45, 60.45, 34.54, 85.62, 32.43, 55.98, 67.23, 56.34, 23.14, 45.24, 67.41, 13.45, 56.36, 45.29};
				for(int pointIndex = 0; pointIndex < yValues.Length; pointIndex++)
				{
					Chart1.Series["Series1"].Points.AddXY(1990 + pointIndex, yValues[pointIndex]);
				}
			}

			// Populate series data from the hidden text fields
			else
			{
				DataSet	dataSet = new DataSet();
				dataSet.ReadXmlSchema(new StringReader(ChartDataSchema.Text));
				dataSet.ReadXml(new StringReader(ChartData.Text));
				DataView dataView = new DataView(dataSet.Tables[0]);
				Chart1.Series["Series1"].Points.DataBindXY(dataView, "X", dataView, "Y");
			}

			// Data bind grid control to the series data
			if (!IsPostBack)
			{
				DataBindGrid();
			}
		}

		private void DataBindGrid()
		{
			// Export series values into DataSet object
			seriesDataSet = Chart1.DataManipulator.ExportSeriesValues("Series1");

			// Data bind DataGrid control. 
			SeriesValuesDataGrid.DataSource = seriesDataSet;
			SeriesValuesDataGrid.DataBind();
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
			this.seriesDataSet = new System.Data.DataSet();
			this.SeriesValuesDataTable = new System.Data.DataTable();
			((System.ComponentModel.ISupportInitialize)(this.seriesDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SeriesValuesDataTable)).BeginInit();
			// 
			// seriesDataSet
			// 
			this.seriesDataSet.DataSetName = "NewDataSet";
			this.seriesDataSet.Locale = new System.Globalization.CultureInfo("en-US");
			this.seriesDataSet.Tables.AddRange(new System.Data.DataTable[] {
																			   this.SeriesValuesDataTable});
			// 
			// SeriesValuesDataTable
			// 
			this.SeriesValuesDataTable.TableName = "Table1";
			this.SeriesValuesDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.SeriesValuesDataGrid_PageIndexChanged);
			this.SeriesValuesDataGrid.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.SeriesValuesDataGrid_CancelCommand);
			this.SeriesValuesDataGrid.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.SeriesValuesDataGrid_EditCommand);
			this.SeriesValuesDataGrid.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.SeriesValuesDataGrid_UpdateCommand);
			((System.ComponentModel.ISupportInitialize)(this.seriesDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SeriesValuesDataTable)).EndInit();

		}
		#endregion

		private void SeriesValuesDataGrid_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				// Get X and Y values
				double xValue = double.Parse(e.Item.Cells[1].Text);
				TextBox textBox = (TextBox)e.Item.Cells[2].Controls[0];
				double yValue = double.Parse(textBox.Text);

				// Find edited point by X value
				DataPoint dataPoint = Chart1.Series["Series1"].Points.FindByValue(xValue, "X");
				if(dataPoint != null)
				{
					// Update Y value of the point
					dataPoint.YValues[0] = yValue;
				}

				// Export series values data and schema into hidden text fields
				ChartDataSchema.Text = Chart1.DataManipulator.ExportSeriesValues().GetXmlSchema();
				ChartData.Text = Chart1.DataManipulator.ExportSeriesValues().GetXml();

				// Data bind the grid
				SeriesValuesDataGrid.EditItemIndex = -1;
				DataBindGrid();
			}
			catch
			{
			}
		}

		private void SeriesValuesDataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			SeriesValuesDataGrid.CurrentPageIndex = e.NewPageIndex;
			DataBindGrid();
		}

		private void SeriesValuesDataGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SeriesValuesDataGrid.EditItemIndex = e.Item.ItemIndex;
			DataBindGrid();
		}

		private void SeriesValuesDataGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SeriesValuesDataGrid.EditItemIndex = -1;
			DataBindGrid();
		}

	}
}
