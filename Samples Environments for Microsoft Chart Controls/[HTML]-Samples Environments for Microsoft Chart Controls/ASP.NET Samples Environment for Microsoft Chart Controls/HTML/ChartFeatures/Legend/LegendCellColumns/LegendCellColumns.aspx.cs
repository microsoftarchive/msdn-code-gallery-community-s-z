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
	/// Summary description for LegendCellColumns.
	/// </summary>
	public partial class LegendCellColumns : System.Web.UI.Page
	{
		# region Fields
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button Button1;
		Random random;

		#endregion		

		# region Page Load
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
            // Update all legend cell columns
			UpdateLegendCellColumns();			
		}

		#endregion

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

		# region Methods

		private void UpdateLegendCellColumns() 
		{
			// Add first cell column
			LegendCellColumn firstColumn = new LegendCellColumn();
			firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
			firstColumn.HeaderText = "Color";
			firstColumn.HeaderBackColor = Color.WhiteSmoke;
			this.Chart1.Legends["Default"].CellColumns.Add(firstColumn);

			// Add second cell column
			LegendCellColumn secondColumn = new LegendCellColumn();
			secondColumn.ColumnType = LegendCellColumnType.Text;
			secondColumn.HeaderText = "Name";
			secondColumn.Text = "#LEGENDTEXT";
			secondColumn.HeaderBackColor = Color.WhiteSmoke;
			this.Chart1.Legends["Default"].CellColumns.Add(secondColumn);

			// Add header separator of type line
			this.Chart1.Legends["Default"].HeaderSeparator = LegendSeparatorStyle.Line;
			this.Chart1.Legends["Default"].HeaderSeparatorColor = Color.FromArgb(64,64,64,64);
		
			// Add item column separator of type line
			this.Chart1.Legends["Default"].ItemColumnSeparator = LegendSeparatorStyle.Line;
			this.Chart1.Legends["Default"].ItemColumnSeparatorColor = Color.FromArgb(64,64,64,64);

			// Set AVG cell column attributes
			LegendCellColumn avgColumn = new LegendCellColumn();
			avgColumn.Text = "#AVG{N2}";
			avgColumn.HeaderText = "Avg";
			avgColumn.Name = "AvgColumn";
			avgColumn.HeaderBackColor = Color.WhiteSmoke;
		
			// Set Total cell column attributes			
			LegendCellColumn totalColumn = new LegendCellColumn();	
			totalColumn.Text = "#TOTAL{N1}";
			totalColumn.HeaderText = "Total";
			totalColumn.Name = "TotalColumn";
			totalColumn.HeaderBackColor = Color.WhiteSmoke;

			// Set Min cell column attributes			
			LegendCellColumn minColumn = new LegendCellColumn();	
			minColumn.Text = "#MIN{N1}";
			minColumn.HeaderText = "Min";
			minColumn.Name = "MinColumn";
			minColumn.HeaderBackColor = Color.WhiteSmoke;

			if (this.chk_ShowAvg.Checked) 
			{
				this.Chart1.Legends["Default"].CellColumns.Add(avgColumn);		
			}

			else 
			{
				LegendCellColumn cellColumn = this.Chart1.Legends["Default"].CellColumns.FindByName("AvgColumn");
				this.Chart1.Legends["Default"].CellColumns.Remove(cellColumn);
			}

			if (this.chk_ShowTotal.Checked) 
			{
				this.Chart1.Legends["Default"].CellColumns.Add(totalColumn);		
			}

			else 
			{
				LegendCellColumn cellColumn = this.Chart1.Legends["Default"].CellColumns.FindByName("TotalColumn");
				this.Chart1.Legends["Default"].CellColumns.Remove(cellColumn);
			}	

			if (this.chk_ShowMin.Checked) 
			{
				this.Chart1.Legends["Default"].CellColumns.Add(minColumn);		
			}

			else 
			{
				LegendCellColumn columnToRemove = this.Chart1.Legends["Default"].CellColumns.FindByName("MinColumn");
				this.Chart1.Legends["Default"].CellColumns.Remove(columnToRemove);
			}	
		}

				

		public void FillData(Chart chart, string seriesName) 
		{
			foreach(Series series in Chart1.Series) 
			{
				series.Points.Clear();	
				string sName = series.Name;

				double yValue = 10;
				for(int pointIndex = 0; pointIndex < 5; pointIndex++)
				{
					yValue = Math.Abs(yValue + ( random.NextDouble() * 10.0 - 5.0 )); 
					chart.Series[sName].Points.AddY(yValue);
				}
			}			
		}

		public void AfterLoad() 
		{

			foreach(Series series in Chart1.Series) 
			{				
				random = new Random(int.Parse(ButtonRandom.CommandArgument));
				series.Points.Clear();	
				string seriesName = series.Name;
				FillData(Chart1,seriesName);
			}
		}

		#endregion

		#region Button Handler

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Random random = new Random();
			ButtonRandom.CommandArgument = random.Next().ToString();
		}

		#endregion
	}
}
