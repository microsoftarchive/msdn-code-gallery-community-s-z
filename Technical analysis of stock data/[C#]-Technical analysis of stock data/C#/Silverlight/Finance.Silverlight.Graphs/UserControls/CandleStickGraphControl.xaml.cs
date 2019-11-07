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
using Microsoft.Windows.Controls.DataVisualization;
using Finance.Silverlight.Graphs.FinanceDataService;

namespace Finance.Silverlight.Graphs.UserControls
{
	public partial class CandleStickGraphControl : UserControl
	{
		public CandleStickGraphControl()
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

		private CandlestickSeries candlestickSeries;

		internal CandlestickSeries CandlestickSeries
		{
			get
			{
				if (null == candlestickSeries)
				{
					candlestickSeries = (CandlestickSeries)chartMain.Series[0];
				}

				return candlestickSeries;
			}
		}
	}
}
