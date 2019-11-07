using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Finance.Silverlight.Graphs.ViewModels;
using Microsoft.Windows.Controls.DataVisualization.Charting;

namespace Finance.Silverlight.Graphs.UserControls
{
	public partial class BarGraphControl : UserControl
	{
		public BarGraphControl()
		{
			InitializeComponent();
		}

		private ColumnRangedSeries columnRangedSeries;

		internal ColumnRangedSeries ColumnRangedSeries
		{
			get
			{
				if (null == columnRangedSeries)
				{
					columnRangedSeries = (ColumnRangedSeries)chartVolume.Series[0];
				}

				return columnRangedSeries;
			}
		}

		private StockBarSeries stockBarSeries;

		internal StockBarSeries StockBarSeries
		{
			get
			{
				if (null == stockBarSeries)
				{
					stockBarSeries = (StockBarSeries)chartMain.Series[0];
				}

				return stockBarSeries;
			}
		}
	}
}
