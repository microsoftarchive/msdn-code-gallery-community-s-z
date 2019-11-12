using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using Cinch;
using MEFedMVVM.ViewModelLocator;
using Finance.Silverlight.Common;
using Finance.Silverlight.Graphs.FinanceDataService;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Windows.Controls.DataVisualization.Charting;
using Finance.Silverlight.Graphs.Resources;
using Finance.Silverlight.Graphs.UserControls;
using Microsoft.Windows.Controls.DataVisualization;
using Finance.Silverlight.Graphs.Models;
using System.Collections.Generic;
using Finance.Silverlight.Common.Converters;

namespace Finance.Silverlight.Graphs.ViewModels
{
	[ExportViewModel("CandleStickGraphViewModel")]
    [PartCreationPolicy(CreationPolicy.Shared)]
	public class CandleStickGraphViewModel : GraphBaseViewModel
	{
		#region ChartMain property

		public static readonly DependencyProperty ChartMainProperty = DependencyProperty.RegisterAttached("ChartMain", typeof(Chart), typeof(CandleStickGraphControl), new PropertyMetadata(new PropertyChangedCallback(OnChartMainPropertyChangedCallback)));

		public static void SetChartMain(DependencyObject element, Chart value)  
		{  
			element.SetValue(ChartMainProperty, value);  
		}

		public static Chart GetChartMain(DependencyObject element)  
		{
			return (Chart)element.GetValue(ChartMainProperty);  
		}

		private static Chart _chartMain = null;

		public static void OnChartMainPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			_chartMain = (Chart)e.NewValue;
		}

		#endregion //ChartMain property

		#region ChartCCI property

		public static readonly DependencyProperty ChartCCIProperty = DependencyProperty.RegisterAttached("ChartCCI", typeof(Chart), typeof(BarGraphControl), new PropertyMetadata(new PropertyChangedCallback(OnChartCCIPropertyChangedCallback)));

		public static void SetChartCCI(DependencyObject element, Chart value)
		{
			element.SetValue(ChartCCIProperty, value);
		}

		public static Chart GetChartCCI(DependencyObject element)
		{
			return (Chart)element.GetValue(ChartCCIProperty);
		}

		private static Chart _chartCCI = null;

		public static void OnChartCCIPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			_chartCCI = (Chart)e.NewValue;
		}

		#endregion //ChartCCI property

		#region ChartOscillator property

		public static readonly DependencyProperty ChartOscillatorProperty = DependencyProperty.RegisterAttached("ChartOscillator", typeof(Chart), typeof(BarGraphControl), new PropertyMetadata(new PropertyChangedCallback(OnChartOscillatorPropertyChangedCallback)));

		public static void SetChartOscillator(DependencyObject element, Chart value)
		{
			element.SetValue(ChartOscillatorProperty, value);
		}

		public static Chart GetChartOscillator(DependencyObject element)
		{
			return (Chart)element.GetValue(ChartOscillatorProperty);
		}

		private static Chart _chartOscillator = null;

		public static void OnChartOscillatorPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			_chartOscillator = (Chart)e.NewValue;
		}

		#endregion //ChartOscillator property

		#region LayoutRootGrid property

		public static readonly DependencyProperty LayoutRootGridProperty = DependencyProperty.RegisterAttached("LayoutRootGrid", typeof(Grid), typeof(CandleStickGraphControl), new PropertyMetadata(new PropertyChangedCallback(OnLayoutRootGridPropertyChangedCallback)));

		public static void SetLayoutRootGrid(DependencyObject element, Grid value)
		{
			element.SetValue(LayoutRootGridProperty, value);
		}

		public static Grid GetLayoutRootGrid(DependencyObject element)
		{
			return (Grid)element.GetValue(LayoutRootGridProperty);
		}

		private static Grid _layoutRootGrid = null;

		public static void OnLayoutRootGridPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			_layoutRootGrid = (Grid)e.NewValue;
		}

		#endregion //LayoutRootGrid property

		#region ChartVolume property

		public static readonly DependencyProperty ChartVolumeProperty = DependencyProperty.RegisterAttached("ChartVolume", typeof(Chart), typeof(CandleStickGraphControl), new PropertyMetadata(new PropertyChangedCallback(OnChartVolumePropertyChangedCallback)));

		public static void SetChartVolume(DependencyObject element, Chart value)
		{
			element.SetValue(ChartVolumeProperty, value);
		}

		public static Chart GetChartVolume(DependencyObject element)
		{
			return (Chart)element.GetValue(ChartVolumeProperty);
		}

		private static Chart _chartVolume = null;

		public static void OnChartVolumePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			_chartVolume = (Chart)e.NewValue;
		}

		#endregion //ChartVolume property

		# region UI Properties

		public string CandleStickChartTitle { get; set; }
		public string VolumeChartTitle { get; set; }

		# endregion //UI Properties

		# region Constructor

		[ImportingConstructor]
		public CandleStickGraphViewModel(MainPageViewModel mainPageViewModel)
			: base()
		{
			MainPageViewModel = mainPageViewModel;

			CandleStickChartTitle = Resources.Resources.CandlestickTitle;
			VolumeChartTitle = Resources.Resources.VolumeChartTitle;
		}

		# endregion //Constructor

		# region Private Methods And Properties

		private ColumnRangedSeries _columnRangedSeries;
		public override ColumnRangedSeries ColumnRangedSeries
		{
			get
			{
				if (null == _columnRangedSeries)
				{
					_columnRangedSeries = (ColumnRangedSeries)_chartVolume.Series[0];
				}

				return _columnRangedSeries;
			}
		}

		public override LineSeries OscillatorFirstSeries
		{
			get
			{
				if (_chartOscillator.Series.Count > 0)
				{
					return _chartOscillator.Series[0] as LineSeries;
				}

				return null;
			}
		}

		private CandlestickSeries _candlestickSeries;
		internal CandlestickSeries CandlestickSeries
		{
			get
			{
				if (null == _chartMain)
				{
					return null;
				}

				if (_chartMain.Series.Count <= 0)
				{
					return null;
				}

				if (null == _candlestickSeries)
				{
					_candlestickSeries = (CandlestickSeries)_chartMain.Series[0];
				}

				return _candlestickSeries;
			}
		}

		public override LineSeries CCIFirstSeries
		{
			get
			{
				if (_chartCCI.Series.Count > 0)
				{
					return _chartCCI.Series[0] as LineSeries;
				}

				return null;
			}
		}

		public override Chart ChartMain
		{
			get
			{
				return _chartMain;
			}
		}

		public override Chart ChartVolume
		{
			get
			{
				return _chartVolume;
			}
		}

		public override Chart ChartOscillator
		{
			get
			{
				return _chartOscillator;
			}
		}

		public override Chart ChartCCI
		{
			get
			{
				return _chartCCI;
			}
		}

		protected override ISeriesWithRangeAxis MainSeriesWithRangeAxis
		{
			get
			{
				return CandlestickSeries;
			}
		}

		public override DataPointSingleSeriesWithAxes ChartMainSeries
		{
			get
			{
				return CandlestickSeries;
			}
		}

		public override Grid LayoutRootGrid
		{
			get
			{
				return _layoutRootGrid;
			}
		}

		#endregion //Private Methods And Properties

	}
}
