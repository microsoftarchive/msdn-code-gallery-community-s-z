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
using Finance.Silverlight.Graphs.Models;
using Finance.Silverlight.Common.Converters;
using Microsoft.Windows.Controls.DataVisualization;
using System.Collections.Generic;

namespace Finance.Silverlight.Graphs.ViewModels
{
	[ExportViewModel("GraphBaseViewModel")]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public class GraphBaseViewModel : ViewModelBase
	{
		# region UI Properties

		private ElementDailyDataRangeWrapper _elementDailyDataRangeWrapper;

		static PropertyChangedEventArgs elementDailyDataRangeChangeArgs =
			ObservableHelper.CreateArgs<GraphBaseViewModel>(x => x.ElementDailyDataRangeWrapper);


		public ElementDailyDataRangeWrapper ElementDailyDataRangeWrapper
		{
			get { return _elementDailyDataRangeWrapper; }
			set
			{
				_elementDailyDataRangeWrapper = value;

				_mainOffset = null;

				_mouseCursorOffset = null;

				NotifyPropertyChanged(elementDailyDataRangeChangeArgs);

				if (null != _elementDailyDataRangeWrapper)
				{
					DailyData = _elementDailyDataRangeWrapper.ElementDailyDataRange.DailyData;
				}
				else
				{
					DailyData = null;
				}


			}
		}

		private Nullable<Double> _mouseCursorOffset = null;

		private ObservableCollection<FinanceDataService.DailyDataWrapper> _dailyData;
		static PropertyChangedEventArgs dailyDataRangeChangeArgs =
			ObservableHelper.CreateArgs<GraphBaseViewModel>(x => x.DailyData);
		public ObservableCollection<FinanceDataService.DailyDataWrapper> DailyData
		{
			get
			{
				return _dailyData;
			}
			set
			{
				_dailyData = value;
				NotifyPropertyChanged(dailyDataRangeChangeArgs);
			}
		}

		# endregion //UI Properties

		# region Constructor

		[ImportingConstructor]
		public GraphBaseViewModel()
		{
			PrepareCommands();
		}

		# endregion //Constructor

		# region Mouse Movement Handlers

		private void PrepareCommands()
		{
			ChartMainMouseMoveCommand = new SimpleCommand<Object, Object>(ChartMainMouseMoveCallback);
			ChartVolumeMouseMoveCommand = new SimpleCommand<Object, Object>(ChartVolumeMouseMoveCallback);
			ChartOscillatorMouseMoveCommand = new SimpleCommand<Object, Object>(ChartOscillatorMouseMoveCallback);
			ChartCCIMouseMoveCommand = new SimpleCommand<Object, Object>(ChartCCIMouseMoveCallback);
		}

		public SimpleCommand<Object, Object> ChartMainMouseMoveCommand { get; private set; }
		public SimpleCommand<Object, Object> ChartVolumeMouseMoveCommand { get; private set; }
		public SimpleCommand<Object, Object> ChartOscillatorMouseMoveCommand { get; private set; }
		public SimpleCommand<Object, Object> ChartCCIMouseMoveCommand { get; private set; }

		internal Double MouseCursorOffset
		{
			get
			{
				if (!_mouseCursorOffset.HasValue)
				{
					if (null != ChartMain && ChartMain.Series.Count > 0)
					{
						if (null != ElementDailyDataRangeWrapper && null != ElementDailyDataRangeWrapper.ElementDailyDataRange && ElementDailyDataRangeWrapper.ElementDailyDataRange.DailyData.Count > 0)
						{
							Double seriesWidth = ((DataPointSingleSeriesWithAxes)ChartMain.Series[0]).ActualWidth;

							_mouseCursorOffset = seriesWidth / ElementDailyDataRangeWrapper.ElementDailyDataRange.DailyData.Count / 2;
						}
						else
						{
							_mouseCursorOffset = 0.0;
						}
					}
					else
					{
						_mouseCursorOffset = 0.0;
					}
				}

				return _mouseCursorOffset.Value;
			}
		}

		public void ChartMainMouseMoveHandler(Double mousePosX, Double mousePosY)
		{
			if (null != MainSeriesWithRangeAxis)
			{
				if (null != MainSeriesWithRangeAxis.ActualIndependentRangeAxis)
				{
					Range<IComparable> temp = MainSeriesWithRangeAxis.ActualIndependentRangeAxis.GetPlotAreaCoordinateValueRange(mousePosX - MouseCursorOffset);

					if (temp.HasData)
					{
						int index = (int)Math.Ceiling(System.Convert.ToDouble(temp.Minimum));
						if (index > -1 && index < DoubleToStringConverter.DatesArray.Count)
						{
							DateTime selectedDay = DoubleToStringConverter.DatesArray[index];
							UpdateData(selectedDay, mousePosX);
						}
					}
				}
			}
		}

		private void ChartMainMouseMoveCallback(Object args)
		{
			if (args != null)
			{
				MouseEventArgs mve = args as MouseEventArgs;
				Point mousePos = mve.GetPosition(this.ChartMainSeries);
				ChartMainMouseMoveHandler(mousePos.X, mousePos.Y);
			}
		}

		private void ChartOscillatorMouseMoveCallback(Object args)
		{
			if (args != null)
			{
				MouseEventArgs mve = args as MouseEventArgs;
				Point mousePos = mve.GetPosition(this.ChartMainSeries);
				OscillatorMouseMoveHandler(mousePos.X, mousePos.Y);
			}
		}

		private void ChartCCIMouseMoveCallback(Object args)
		{
			if (args != null)
			{
				MouseEventArgs mve = args as MouseEventArgs;
				Point mousePos = mve.GetPosition(this.ChartMainSeries);
				CCIMouseMoveHandler(mousePos.X, mousePos.Y);
			}
		}

		private void ChartVolumeMouseMoveCallback(Object args)
		{
			if (args != null)
			{
				MouseEventArgs mve = args as MouseEventArgs;
				Point mousePos = mve.GetPosition(this.ChartMainSeries);
				VolumeMouseMoveHandler(mousePos.X, mousePos.Y);
			}
		}

		# endregion Mouse Movement Handlers

		# region Pointer To MainPageViewModel

		private MainPageViewModel _mainPageViewModel;
		public MainPageViewModel MainPageViewModel
		{
			get
			{
				return _mainPageViewModel;
			}
			set
			{
				_mainPageViewModel = value;
			}
		}

		# endregion //Pointer To MainPageViewModel	

		private CalculatedAggregationsContainer calculatedAggregationsContainer;

		public CalculatedAggregationsContainer CalculatedAggregationsContainer
		{
			get
			{
				return calculatedAggregationsContainer;
			}

			set
			{
				calculatedAggregationsContainer = value;

				UpdateAggregationGraphs();
			}
		}

		public virtual Chart ChartMain
		{
			get
			{
				return null;
			}
		}

		public virtual Chart ChartOscillator
		{
			get
			{
				return null;
			}
		}

		public virtual Chart ChartCCI
		{
			get
			{
				return null;
			}
		}

		private List<List<SingleValueDayPair>> PrepareTresholdsForOscillator(CalculatedAggregationInfo oscillatorInfo)
		{
			if (oscillatorInfo.PreparedDataForGraph.Count <= 0)
			{
				return null;
			}

			if (oscillatorInfo.PreparedDataForGraph[0].Count <= 0)
			{
				return null;
			}

			SingleValueDayPair firstSampleRecord = oscillatorInfo.PreparedDataForGraph[0][0];

			SingleValueDayPair lastSampleRecord = oscillatorInfo.PreparedDataForGraph[0][oscillatorInfo.PreparedDataForGraph[0].Count - 1];

			List<List<SingleValueDayPair>> result = new List<List<SingleValueDayPair>>();

			List<SingleValueDayPair> resultLow = new List<SingleValueDayPair>();

			resultLow.Add(new SingleValueDayPair(firstSampleRecord.Day, ((IOscillator)oscillatorInfo.Aggregation).HighMarker, firstSampleRecord.DayAsDouble));

			resultLow.Add(new SingleValueDayPair(lastSampleRecord.Day, ((IOscillator)oscillatorInfo.Aggregation).HighMarker, lastSampleRecord.DayAsDouble));

			result.Add(resultLow);

			List<SingleValueDayPair> resultHigh = new List<SingleValueDayPair>();

			resultHigh.Add(new SingleValueDayPair(firstSampleRecord.Day, ((IOscillator)oscillatorInfo.Aggregation).LowMarker, firstSampleRecord.DayAsDouble));

			resultHigh.Add(new SingleValueDayPair(lastSampleRecord.Day, ((IOscillator)oscillatorInfo.Aggregation).LowMarker, lastSampleRecord.DayAsDouble));

			result.Add(resultHigh);

			return result;
		}

		private void UpdateAggregationGraphs()
		{
			Boolean isAnyOscillator = false;

			Boolean isAnyCCI = false;

			Decimal oscillatorMinimumValue = 0.0M;

			Decimal oscillatorMaximumValue = 0.0M;

			//////////////////////////////////////////////////////////////////////////
			/// remove all series accept the first one (the main graph)
			/// 

			for (Int32 q = ChartMain.Series.Count - 1; q >= 1; q--)
			{
				ChartMain.Series.RemoveAt(q);
			}

			////////////////////////////////////////////////////////////////////
			/// remove all oscillator series
			/// 

			if (null != ChartOscillator)
			{
				ChartOscillator.Series.Clear();
			}

			if (null != ChartCCI)
			{
				ChartCCI.Series.Clear();
			}


			if (null != calculatedAggregationsContainer && null != calculatedAggregationsContainer.Aggregations)
			{
				CalculatedAggregationInfo firstOscillator = null; /// stores of single oscillator if and only if there is a 1 oscillator

				Decimal oscillatorLowMarker = 0.0M;

				Boolean canSetFirstOscillator = true;

				Decimal oscillatorHighMarker = 0.0M;

				foreach (KeyValuePair<String, CalculatedAggregationInfo> pair in calculatedAggregationsContainer.Aggregations)
				{
					CalculatedAggregationInfo cai = pair.Value;

					if (null != cai  && null != cai.Aggregation && cai.Aggregation.AggregationOutputType == AggregationOutputType.Oscillator)
					{
						#region oscillators

						IOscillator oscillator = (IOscillator)cai.Aggregation;

						if (null == firstOscillator)
						{
							if (canSetFirstOscillator)
							{
								firstOscillator = cai;

								oscillatorLowMarker = oscillator.LowMarker;

								oscillatorHighMarker = oscillator.HighMarker;
							}
						}
						else
						{
							//////////////////////////////////////////////////////////////////////////////////////////////
							/// cleanup oscillator if there is more oscillators (no treshold lines will be drawn) and if
							/// they have different tresholds
							/// 

							if (oscillator.LowMarker != oscillatorLowMarker || oscillator.HighMarker != oscillatorHighMarker)
							{
								firstOscillator = null;

								canSetFirstOscillator = false;
							}
						}

						if (oscillator.HighValueBound > oscillatorMaximumValue)
						{
							oscillatorMaximumValue = oscillator.HighValueBound;
						}

						if (oscillator.LowValueBound < oscillatorMinimumValue)
						{
							oscillatorMinimumValue = oscillator.LowValueBound;
						}

						if (null != ChartOscillator)
						{
							for (Int32 q = 0, qMax = cai.PreparedDataForGraph.Count; q < qMax; q++)
							{
								isAnyOscillator = true;

								List<SingleValueDayPair> valuesList = cai.PreparedDataForGraph[q];

								LineSeries lineSeries = new LineSeries();

								Style style = null;

								if (Application.Current.Resources.MergedDictionaries.Count > 0)
								{
									style = Application.Current.Resources.MergedDictionaries[0]["LegendItemStyle"] as Style;
								}

								if (null != style)
								{
									lineSeries.LegendItemStyle = style;
								}

								lineSeries.Title = cai.Name;

								lineSeries.ItemsSource = valuesList;

								lineSeries.IndependentValueBinding = new System.Windows.Data.Binding("DayAsDouble");

								lineSeries.DependentValueBinding = new System.Windows.Data.Binding("Value");

								lineSeries.HorizontalContentAlignment = HorizontalAlignment.Left;

								Canvas.SetZIndex(lineSeries, -1);

								lineSeries.Background = new SolidColorBrush(cai.AggregationColor);

								ChartOscillator.Series.Add(lineSeries);
							}
						}

						#endregion oscillators
					}
					else if (cai.Aggregation.AggregationOutputType == AggregationOutputType.Plain)
					{
						#region plain aggregations

						for (Int32 q = 0, qMax = cai.PreparedDataForGraph.Count; q < qMax; q++)
						{
							List<SingleValueDayPair> valuesList = cai.PreparedDataForGraph[q];

							LineSeries lineSeries = new LineSeries();

							lineSeries.Title = cai.Name;

							lineSeries.ItemsSource = valuesList;

							lineSeries.IndependentValueBinding = new System.Windows.Data.Binding("DayAsDouble");

							lineSeries.DependentValueBinding = new System.Windows.Data.Binding("Value");

							lineSeries.HorizontalContentAlignment = HorizontalAlignment.Left;

							Canvas.SetZIndex(lineSeries, -1);

							lineSeries.Foreground = new SolidColorBrush(cai.AggregationColor);

							ChartMain.Series.Add(lineSeries);
						}

						#endregion plain aggregations
					}
					else if (cai.Aggregation.AggregationOutputType == AggregationOutputType.CCI)
					{
						#region CCI

						if (null != ChartCCI)
						{
							for (Int32 q = 0, qMax = cai.PreparedDataForGraph.Count; q < qMax; q++)
							{
								isAnyCCI = true;

								List<SingleValueDayPair> valuesList = cai.PreparedDataForGraph[q];

								LineSeries lineSeries = new LineSeries();

								Style style = null;

								if (Application.Current.Resources.MergedDictionaries.Count > 0)
								{
									style = Application.Current.Resources.MergedDictionaries[0]["LegendItemStyle"] as Style;
								}

								if (null != style)
								{
									lineSeries.LegendItemStyle = style;
								}

								lineSeries.Title = cai.Name;

								lineSeries.ItemsSource = valuesList;

								lineSeries.IndependentValueBinding = new System.Windows.Data.Binding("DayAsDouble");

								lineSeries.DependentValueBinding = new System.Windows.Data.Binding("Value");

								lineSeries.HorizontalContentAlignment = HorizontalAlignment.Left;

								Canvas.SetZIndex(lineSeries, -1);

								lineSeries.Background = new SolidColorBrush(cai.AggregationColor);

								ChartCCI.Series.Add(lineSeries);
							}
						}

						#endregion CCI
					}
				}

				if (null != firstOscillator)
				{
					if (null != ChartOscillator)
					{
						List<List<SingleValueDayPair>> tresholdDataForSeries = PrepareTresholdsForOscillator(firstOscillator);

						for (Int32 q = 0, qMax = tresholdDataForSeries.Count; q < qMax; q++)
						{
							List<SingleValueDayPair> valuesList = tresholdDataForSeries[q];

							LineSeries lineSeries = new LineSeries();

							Style style = null;

							if (Application.Current.Resources.MergedDictionaries.Count > 0)
							{
								style = Application.Current.Resources.MergedDictionaries[0]["LegendItemStyle"] as Style;
							}

							if (null != style)
							{
								lineSeries.LegendItemStyle = style;
							}

							lineSeries.Title = valuesList[0].Value.ToString();

							lineSeries.ItemsSource = valuesList;

							lineSeries.IndependentValueBinding = new System.Windows.Data.Binding("DayAsDouble");

							lineSeries.DependentValueBinding = new System.Windows.Data.Binding("Value");

							lineSeries.HorizontalContentAlignment = HorizontalAlignment.Left;

							Canvas.SetZIndex(lineSeries, -1);

							ChartOscillator.Series.Add(lineSeries);
						}
					}
				}
			}

			////////////////////////////////////////////////////////////////
			/// show oscillator graph if required
			/// 

			IsOscillatorChartVisibile = isAnyOscillator;

			if (isAnyOscillator)
			{
				OscillatorMaximum = (Double)oscillatorMaximumValue;

				OscillatorMinimum = (Double)oscillatorMinimumValue;
			}

			IsCCIChartVisibile = isAnyCCI;
		}

		#region UI Properties

		private Boolean _isVolumeChartVisibile;
		public Boolean IsVolumeChartVisibile
		{
			get
			{
				return _isVolumeChartVisibile;
			}
			set
			{
				Boolean fireEvent = (_isVolumeChartVisibile != value);
				_isVolumeChartVisibile = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("IsVolumeChartVisibile");

					_volumeOffset = null;

					_mainOffset = null;

					_oscillatorOffset = null;

					_cciOffset = null;
				}
			}
		}

		private Boolean _isOscillatorChartVisibile = false;
		public Boolean IsOscillatorChartVisibile
		{
			get
			{
				return _isOscillatorChartVisibile;
			}
			set
			{
				Boolean fireEvent = (_isOscillatorChartVisibile != value);
				_isOscillatorChartVisibile = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("IsOscillatorChartVisibile");

					_volumeOffset = null;

					_mainOffset = null;

					_oscillatorOffset = null;

					_cciOffset = null;
				}
			}
		}

		private Boolean _isCCIChartVisibile = false;
		public Boolean IsCCIChartVisibile
		{
			get
			{
				return _isCCIChartVisibile;
			}
			set
			{
				Boolean fireEvent = (_isCCIChartVisibile != value);
				_isCCIChartVisibile = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("IsCCIChartVisibile");

					_volumeOffset = null;

					_mainOffset = null;

					_oscillatorOffset = null;

					_cciOffset = null;
				}
			}
		}

		#endregion UI Properties

		# region Mouse Move Calculations

		private Double _dayMarkerY2;
		public Double DayMarkerY2
		{
			get
			{
				return _dayMarkerY2;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY2 != value);
				_dayMarkerY2 = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY2");
				}
			}
		}

		private Double _dayMarkerY2V;
		public Double DayMarkerY2V
		{
			get
			{
				return _dayMarkerY2V;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY2V != value);
				_dayMarkerY2V = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY2V");
				}
			}
		}


		private Double _dayMarkerX;
		public Double DayMarkerX
		{
			get
			{
				return _dayMarkerX;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerX != value);
				_dayMarkerX = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerX");
				}
			}
		}

		private Double _dayMarkerY1C;
		public Double DayMarkerY1C
		{
			get
			{
				return _dayMarkerY1C;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY1C != value);

				_dayMarkerY1C = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY1C");
				}
			}
		}

		private Double _dayMarkerY2C;
		public Double DayMarkerY2C
		{
			get
			{
				return _dayMarkerY2C;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY2C != value);
				_dayMarkerY2C = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY2C");
				}
			}
		}

		private Double _dayMarkerY1O;
		public Double DayMarkerY1O
		{
			get
			{
				return _dayMarkerY1O;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY1O != value);

				_dayMarkerY1O = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY1O");
				}
			}
		}

		private Double _dayMarkerY2O;
		public Double DayMarkerY2O
		{
			get
			{
				return _dayMarkerY2O;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY2O != value);
				_dayMarkerY2O = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY2O");
				}
			}
		}

		private Double _dayMarkerY1V;
		public Double DayMarkerY1V
		{
			get
			{
				return _dayMarkerY1V;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY1V != value);

				_dayMarkerY1V = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY1V");
				}
			}
		}

		private Double _dayMarkerY1;
		public Double DayMarkerY1
		{
			get
			{
				return _dayMarkerY1;
			}
			set
			{
				Boolean fireEvent = (_dayMarkerY1 != value);
				_dayMarkerY1 = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DayMarkerY1");
				}
			}
		}

		public void CCIMouseMoveHandler(Double mousePosX, Double mousePosY)
		{
			if (null != CCIFirstSeries)
			{
				if (null != CCIFirstSeries.ActualIndependentRangeAxis)
				{
					Range<IComparable> temp = CCIFirstSeries.ActualIndependentRangeAxis.GetPlotAreaCoordinateValueRange(mousePosX - MouseCursorOffset);

					if (temp.HasData)
					{
						if (temp.Minimum is DateTime)
						{
							DateTime selectedDay = ((DateTime)temp.Minimum).Date;

							UpdateData(selectedDay, mousePosX);
						}
						else
						{
							int index = (int)Math.Ceiling(System.Convert.ToDouble(temp.Minimum));
							if (index > -1 && index < DoubleToStringConverter.DatesArray.Count)
							{
								DateTime selectedDay = DoubleToStringConverter.DatesArray[index];
								UpdateData(selectedDay, mousePosX);
							}
						}
					}
				}
			}
		}

		public void OscillatorMouseMoveHandler(Double mousePosX, Double mousePosY)
		{
			if (null != OscillatorFirstSeries)
			{
				if (null != OscillatorFirstSeries.ActualIndependentRangeAxis)
				{
					Range<IComparable> temp = OscillatorFirstSeries.ActualIndependentRangeAxis.GetPlotAreaCoordinateValueRange(mousePosX - MouseCursorOffset);

					if (temp.HasData)
					{
						if (temp.Minimum is DateTime)
						{
							DateTime selectedDay = ((DateTime)temp.Minimum).Date;

							UpdateData(selectedDay, mousePosX);
						}
						else
						{
							int index = (int)Math.Ceiling(System.Convert.ToDouble(temp.Minimum));
							if (index > -1 && index < DoubleToStringConverter.DatesArray.Count)
							{
								DateTime selectedDay = DoubleToStringConverter.DatesArray[index];
								UpdateData(selectedDay, mousePosX);
							}
						}
					}
				}
			}
		}

		public void VolumeMouseMoveHandler(Double mousePosX, Double mousePosY)
		{
			if (null != ColumnRangedSeries)
			{
				if (null != ColumnRangedSeries.ActualIndependentRangeAxis)
				{
					Range<IComparable> temp = ColumnRangedSeries.ActualIndependentRangeAxis.GetPlotAreaCoordinateValueRange(mousePosX - MouseCursorOffset);

					int index = (int)Math.Ceiling(System.Convert.ToDouble(temp.Minimum));
					if (index > -1 && index < DoubleToStringConverter.DatesArray.Count)
					{
						DateTime selectedDay = DoubleToStringConverter.DatesArray[index];
						UpdateData(selectedDay, mousePosX);
					}
				}
			}
		}

		protected Nullable<Point> _mainOffset;

		protected Nullable<Point> _volumeOffset;

		protected Nullable<Point> _oscillatorOffset;

		protected Nullable<Point> _cciOffset;

		protected virtual ISeriesWithRangeAxis MainSeriesWithRangeAxis
		{
			get
			{
				return null;
			}
		}

		# endregion //Mouse Move Calculations

		public virtual ColumnRangedSeries ColumnRangedSeries
		{
			get
			{
				return null;
			}
		}

		public virtual LineSeries OscillatorFirstSeries
		{
			get
			{
				return null;
			}
		}

		public virtual Chart ChartVolume
		{
			get
			{
				return null;
			}
		}

		public virtual LineSeries CCIFirstSeries
		{
			get
			{
				return null;
			}
		}

		public virtual Grid LayoutRootGrid
		{
			get
			{
				return null;
			}
		}

		public virtual DataPointSingleSeriesWithAxes ChartMainSeries
		{
			get
			{
				return null;
			}
		}

		private Double oscillatorMaximum = 100.0;

		public Double OscillatorMaximum
		{
			get
			{
				return oscillatorMaximum;
			}

			set
			{
				Boolean fireEvent = (oscillatorMaximum != value);

				oscillatorMaximum = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("OscillatorMaximum");
				}
			}
		}

		private Double oscillatorMinimum = 0.0;

		public Double OscillatorMinimum
		{
			get
			{
				return oscillatorMinimum;
			}

			set
			{
				Boolean fireEvent = (oscillatorMinimum != value);

				oscillatorMinimum = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("OscillatorMinimum");
				}
			}
		}

		protected virtual void UpdateData(DateTime selectedDay, Double mousePosX)
		{
			if (MainSeriesWithRangeAxis == null)
			{
				return;
			}

			MainPageViewModel.SelectedDayValue = selectedDay.ToShortDateString();

			DailyDataWrapper item = MainPageViewModel.GetDataForDay(selectedDay);

			if (null != item)
			{
				MainPageViewModel.SelectedMaxValue = item.MaxValue.ToString();

				MainPageViewModel.SelectedOpenValue = item.OpenValue.ToString();

				MainPageViewModel.SelectedCloseValue = item.CloseValue.ToString();

				MainPageViewModel.SelectedMinValue = item.MinValue.ToString();

				MainPageViewModel.SelectedVolume = item.Volume.ToString();
			}
			else
			{
				MainPageViewModel.SelectedMaxValue = String.Empty;

				MainPageViewModel.SelectedOpenValue = String.Empty;

				MainPageViewModel.SelectedCloseValue = String.Empty;

				MainPageViewModel.SelectedMinValue = String.Empty;

				MainPageViewModel.SelectedVolume = String.Empty;
			}


			if (MainSeriesWithRangeAxis.ActualHeight == 0.0)
			{
				MainSeriesWithRangeAxis.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
			}

			if (IsVolumeChartVisibile)
			{
				if (ColumnRangedSeries.ActualHeight == 0.0)
				{
					ColumnRangedSeries.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
				}
			}

			// translated datetime back to numeric offset on axis
			Double distance = 0;

			if (DoubleToStringConverter.DatesArray != null)
			{
				distance = DoubleToStringConverter.DatesArray.IndexOf(selectedDay);
			}

			Double linePosX = MainSeriesWithRangeAxis.ActualIndependentRangeAxis.GetPlotAreaCoordinate(distance);

			Double minValue = MainSeriesWithRangeAxis.ActualIndependentRangeAxis.GetPlotAreaCoordinate(MainSeriesWithRangeAxis.ActualIndependentRangeAxis.Range.Minimum);

			if (linePosX < minValue)
			{
				linePosX = minValue;
			}

			Double maxValue = MainSeriesWithRangeAxis.ActualIndependentRangeAxis.GetPlotAreaCoordinate(MainSeriesWithRangeAxis.ActualIndependentRangeAxis.Range.Maximum);

			if (linePosX > maxValue)
			{
				linePosX = maxValue;
			}

			if (!_mainOffset.HasValue)
			{
				try
				{
					GeneralTransform gt = MainSeriesWithRangeAxis.TransformToVisual(LayoutRootGrid);

					_mainOffset = gt.Transform(new Point(0, 0));
				}
				catch (ArgumentException)
				{
					///WTF ?
				}					
			}

			if (!_volumeOffset.HasValue)
			{
				if (IsVolumeChartVisibile)
				{
					try
					{
						GeneralTransform gt = ColumnRangedSeries.TransformToVisual(LayoutRootGrid);

						_volumeOffset = gt.Transform(new Point(0, 0));
					}
					catch (ArgumentException)
					{
						///WTF ?
					}
				}
			}

			if (!_oscillatorOffset.HasValue)
			{
				if (IsOscillatorChartVisibile)
				{
					if (null != OscillatorFirstSeries)
					{
						try
						{
							GeneralTransform gt = OscillatorFirstSeries.TransformToVisual(LayoutRootGrid);

							_oscillatorOffset = gt.Transform(new Point(0, 0));
						}
						catch (ArgumentException)
						{
							///WTF ?
						}
					}
				}
			}

			if (!_cciOffset.HasValue)
			{
				if (IsCCIChartVisibile)
				{
					if (null != CCIFirstSeries)
					{
						try
						{
							GeneralTransform gt = CCIFirstSeries.TransformToVisual(LayoutRootGrid);

							_cciOffset = gt.Transform(new Point(0, 0));
						}
						catch (ArgumentException)
						{
							///WTF ?
						}
					}
				}
			}

			if (_mainOffset.HasValue)
			{
				DayMarkerX = _mainOffset.Value.X + linePosX;

				DayMarkerY1 = _mainOffset.Value.Y;

				DayMarkerY2 = _mainOffset.Value.Y + MainSeriesWithRangeAxis.ActualHeight - 1;
			}

			if (_volumeOffset.HasValue)
			{
				DayMarkerY1V = _volumeOffset.Value.Y;

				DayMarkerY2V = _volumeOffset.Value.Y + ColumnRangedSeries.ActualHeight - 1;
			}

			if (_oscillatorOffset.HasValue && null != OscillatorFirstSeries)
			{
				DayMarkerY1O = _oscillatorOffset.Value.Y;

				DayMarkerY2O = _oscillatorOffset.Value.Y + OscillatorFirstSeries.ActualHeight - 1;
			}

			if (_cciOffset.HasValue && null != CCIFirstSeries)
			{
				DayMarkerY1C = _cciOffset.Value.Y;

				DayMarkerY2C = _cciOffset.Value.Y + CCIFirstSeries.ActualHeight - 1;
			}
		}
	}
}
