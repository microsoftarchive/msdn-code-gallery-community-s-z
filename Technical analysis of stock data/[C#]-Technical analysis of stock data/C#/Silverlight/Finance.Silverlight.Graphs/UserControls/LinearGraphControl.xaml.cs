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
	public partial class LinearGraphControl : UserControl
	{
		public LinearGraphControl()
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

		private LineSeries linearSeries;

		internal LineSeries LinearSeries
		{
			get
			{
				if (null == linearSeries)
				{
					linearSeries = (LineSeries)chartMain.Series[0];
				}

				return linearSeries;
			}
		}
	}
}
