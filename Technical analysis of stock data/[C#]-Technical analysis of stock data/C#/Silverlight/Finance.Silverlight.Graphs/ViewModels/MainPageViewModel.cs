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
using System.Linq;
using System.ComponentModel.Composition;
using System.Windows.Navigation;
using Cinch;
using MEFedMVVM.ViewModelLocator;
using System.Collections.ObjectModel;
using Finance.Silverlight.Graphs.Models;
using Finance.Silverlight.Graphs.ChildWindows;
using System.ComponentModel;
using Finance.Silverlight.Common;
using System.Collections.Generic;
using Finance.Silverlight.Graphs.Resources;
using Finance.Silverlight.Graphs.FinanceDataService;
using Finance.Silverlight.Calculations;
using Finance.Silverlight.Common.Converters;

namespace Finance.Silverlight.Graphs.ViewModels
{
	[ExportViewModel("MainPageViewModel")]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
	{
		# region Instance Level Variables

		FinanceDataService.FinanceDataServiceClient _financeServiceClient;

		private FinanceDataService.ElementDailyDataRange _elementDailyDataRangeBase = null;

		private ElementDailyDataRangeWrapper _elementDailyDataRangeWrapper = null;

		private Dictionary<DateTime, DailyDataWrapper> _dataDictionary;

		public DailyDataWrapper GetDataForDay(DateTime day)
		{
			DailyDataWrapper result = null;

			if (null != _dataDictionary)
			{
				_dataDictionary.TryGetValue(day, out result);
			}

			return result;
		}

		public ElementDailyDataRangeWrapper ElementDailyDataRangeWrapper
		{
			get
			{
				return _elementDailyDataRangeWrapper;
			}
			set
			{
				Boolean fireEvent = (_elementDailyDataRangeWrapper != value);

				_elementDailyDataRangeWrapper = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("ElementDailyDataRangeWrapper");

					RefreshAllGraphs();
				}
			}
		}
		
		private Boolean _firstTimeSoUseParameters = true;

		private static SimpleRule AggregationParamRule;

		public IEnumerable<DataWrapperBase> CachedListOfDataWrappers { get; protected set; }

		# endregion //Instance Level Variables

		# region UI Properties

		public CandleStickGraphViewModel CandleStickGraphViewModel { get; private set; }

		public LinearGraphViewModel LinearGraphViewModel { get; private set; }
		public BarGraphViewModel BarGraphViewModel { get; private set; }

		public SimpleCommand<Object, Object> UpdateSettingsCommand { get; private set; }

		public SimpleCommand<Object, Object> AddAggregationCommand { get; private set; }

		public SimpleCommand<Object, Object> DeleteAggregationCommand { get; private set; }

		private DataWrapper<String> _aggregationParamText;
		static PropertyChangedEventArgs aggregationParamChangeArgs =
			ObservableHelper.CreateArgs<MainPageViewModel>(x => x.AggregationParam);
		public DataWrapper<String> AggregationParam
		{
			get
			{
				return _aggregationParamText;
			}
			set
			{
				Boolean fireEvent = (_aggregationParamText != value);
				_aggregationParamText = value;

				if (fireEvent)
				{
					NotifyPropertyChanged(aggregationParamChangeArgs);
				}
			}
		}

		public AggregationInfo[] DefinedAggregations
		{
			get
			{
				return AggregationInfo.DefinedAggregations;
			}
		}

		private Dictionary<String, AggregationParameters> _selectedAggregationsMap = new Dictionary<String, AggregationParameters>();

		private ObservableCollection<AggregationParameters> _selectedAggregations = new ObservableCollection<AggregationParameters>();

		private AggregationParameters _selectedDefinedAggregation;

		public AggregationParameters SelectedDefinedAggregation
		{
			get
			{
				return _selectedDefinedAggregation;
			}

			set
			{
				_selectedDefinedAggregation = value;

				NotifyPropertyChanged("SelectedDefinedAggregation");
			}
		}

		public ObservableCollection<AggregationParameters> SelectedAggregations
		{
			get
			{
				return _selectedAggregations;
			}
			set
			{
				_selectedAggregations = value;

				NotifyPropertyChanged("SelectedAggregations");
			}
		}

		private DateTime _dateTimeFrom;

		public DateTime DateTimeFrom
		{
			get
			{
				return _dateTimeFrom;
			}
			set
			{
				Boolean fireEvent = (_dateTimeFrom != value);
				_dateTimeFrom = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DateTimeFrom");
				}
			}
		}

		private DateTime _dateTimeTo;
		public DateTime DateTimeTo
		{
			get
			{
				return _dateTimeTo;
			}
			set
			{
				Boolean fireEvent = (_dateTimeTo != value);
				_dateTimeTo = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("DateTimeTo");
				}
			}
		}

		public List<string> _graphTypesList;
		public List<string> GraphTypesList
		{
			get
			{
				return _graphTypesList;
			}
			set
			{
				Boolean fireEvent = (_graphTypesList != value);
				_graphTypesList = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("GraphTypesList");
				}
			}
		}

		public DataWrapper<string> _graphTypeChosen;
		static PropertyChangedEventArgs graphTypeChoseChangeArgs = ObservableHelper.CreateArgs<MainPageViewModel>(x => x.GraphTypeChosen);

		public DataWrapper<string> GraphTypeChosen
		{
			get
			{
				return _graphTypeChosen;
			}
			set
			{
				Boolean fireEvent = (_graphTypeChosen != value);
				_graphTypeChosen = value;

				if (fireEvent)
				{
					NotifyPropertyChanged(graphTypeChoseChangeArgs);
				}
			}
		}

		#region SelectedOpenValue

		private String _selectedOpenValue;
		public String SelectedOpenValue
		{
			get
			{
				return _selectedOpenValue;
			}
			set
			{
				Boolean fireEvent = (_selectedOpenValue != value);
				_selectedOpenValue = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedOpenValue");
				}
			}
		}

		public String SelectedOpenValueLabel { get; private set; }

		#endregion SelectedOpenValue

		#region SelectedCloseValue

		private String _selectedCloseValue;

		public String SelectedCloseValue
		{
			get
			{
				return _selectedCloseValue;
			}
			set
			{
				Boolean fireEvent = (_selectedCloseValue != value);
				_selectedCloseValue = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedCloseValue");
				}
			}
		}

		public String SelectedCloseValueLabel { get; private set; }

		#endregion SelectedCloseValue

		#region SelectedMaxValue

		private String _selectedMaxValue;

		public String SelectedMaxValue
		{
			get
			{
				return _selectedMaxValue;
			}
			set
			{
				Boolean fireEvent = (_selectedMaxValue != value);
				_selectedMaxValue = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedMaxValue");
				}
			}
		}

		public string SelectedMaxValueLabel { get; private set; }

		#endregion SelectedMaxValue

		#region SelectedVolume

		private String _selectedVolume;

		public String SelectedVolume
		{
			get
			{
				return _selectedVolume;
			}
			set
			{
				Boolean fireEvent = (_selectedVolume != value);
				_selectedVolume = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedVolume");
				}
			}
		}

		public string SelectedVolumeLabel { get; private set; }

		#endregion SelectedVolume

		#region SelectedMinValue

		private String _selectedMinValue;

		public String SelectedMinValue
		{
			get
			{
				return _selectedMinValue;
			}
			set
			{
				Boolean fireEvent = (_selectedMinValue != value);
				_selectedMinValue = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedMinValue");
				}
			}
		}

		public String SelectedMinValueLabel { get; private set; }

		#endregion SelectedMinValue

		#region SelectedDayValue

		private String _selectedDayValue;
		public String SelectedDayValue
		{
			get
			{
				return _selectedDayValue;
			}
			set
			{
				Boolean fireEvent = (_selectedDayValue != value);
				_selectedDayValue = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedDayValue");
				}
			}
		}

		public String SelectedDayValueLabel { get; private set; }

		#endregion SelectedDayValue

		public string DefinedAggregationsLabelText { get; private set; }

		private Int32 _selectedAggregationIndex = -1;
		public Int32 SelectedAggregationIndex
		{
			get
			{
				return _selectedAggregationIndex;
			}
			set
			{
				Boolean fireEvent = (value != _selectedAggregationIndex);
				_selectedAggregationIndex = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("SelectedAggregationIndex");
				}
			}
		}

		private bool _isCandleStickGraphEnabled;
		public bool IsCandleStickGraphEnabled
		{
			get
			{
				return _isCandleStickGraphEnabled;
			}
			set
			{
				Boolean fireEvent = (_isCandleStickGraphEnabled != value);
				_isCandleStickGraphEnabled = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("IsCandleStickGraphEnabled");
				}
			}
		}

		private bool _isLinearGraphEnabled;
		public bool IsLinearGraphEnabled
		{
			get
			{
				return _isLinearGraphEnabled;
			}
			set
			{
				Boolean fireEvent = (_isLinearGraphEnabled != value);
				_isLinearGraphEnabled = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("IsLinearGraphEnabled");
				}
			}
		}
		private bool _isBarGraphEnabled;
		public bool IsBarGraphEnabled
		{
			get
			{
				return _isBarGraphEnabled;
			}
			set
			{
				Boolean fireEvent = (_isBarGraphEnabled != value);
				_isBarGraphEnabled = value;

				if (fireEvent)
				{
					NotifyPropertyChanged("IsBarGraphEnabled");
				}
			}
		}

		private DataWrapper<bool> _isVolumeChartVisibile;
		static PropertyChangedEventArgs isVolumeChartVisibleChangeArgs = ObservableHelper.CreateArgs<MainPageViewModel>(x => x.IsVolumeChartVisibile);

		public DataWrapper<bool> IsVolumeChartVisibile
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
					NotifyPropertyChanged(isVolumeChartVisibleChangeArgs);
				}
			}
		}

		public String AggregationLabelText { get; set; }
		public String AddAggregationButtonText { get; set; }
		public String RemoveAggregationButtonText { get; set; }
		public String AggregationLengthParameterLength { get; set; }

		public string UpdateButtonLabel { get; set; }
		public string DateFromLabel     { get; set; }
		public string DateToLabel       { get; set; }
		public string GraphLabel        { get; set; }
		public string TickerLabel       { get; set; }
		public string ShowVolumeLabel   { get; set; }
		public string StocksTitle       { get; set; }
		public string HelpTitle         { get; set; }
		public string HelpText          { get; set; }

		# endregion //UI Properties

		# region Constructor

		[ImportingConstructor]
		public MainPageViewModel()
		{
			InitializeService();

			PopulateUI();

			CreateCommands();

			/////////////////////////////////////////////////////
			/// prepare CandleStick graph
			/// 

			CandleStickGraphViewModel = new CandleStickGraphViewModel(this);

			CandleStickGraphViewModel.CandleStickChartTitle = ConfigurationSingleton.Instance.StockName;

			/////////////////////////////////////////////////////
			/// prepare StockBar graph
			/// 

			BarGraphViewModel = new BarGraphViewModel(this);

			BarGraphViewModel.BarChartTitle = ConfigurationSingleton.Instance.StockName;

			/////////////////////////////////////////////////////
			/// prepare Linear graph
			/// 

			LinearGraphViewModel = new LinearGraphViewModel(this);

			LinearGraphViewModel.LinearChartTitle = ConfigurationSingleton.Instance.StockName;
		}

		static MainPageViewModel()
		{
			AggregationParamRule = new SimpleRule("DataValue", Resources.Resources.AggregationParamMissing,
			  (object valObject) =>
			  {
				  DataWrapper<string> obj = (DataWrapper<string>)valObject;
				  return string.IsNullOrEmpty(obj.DataValue);
			  });
		}

		# endregion

		# region Model Setup

		private void InitializeService()
		{
			_financeServiceClient = new FinanceDataService.FinanceDataServiceClient();
			
			_financeServiceClient.SelectDailyDataCompleted -= new EventHandler<FinanceDataService.SelectDailyDataCompletedEventArgs>(client_SelectDailyDataCompleted);
			_financeServiceClient.SelectDailyDataCompleted += new EventHandler<FinanceDataService.SelectDailyDataCompletedEventArgs>(client_SelectDailyDataCompleted);

			_financeServiceClient.SelectDailyDataAsync(ConfigurationSingleton.Instance.StockName);
		}

		private void PopulateUI()
		{
			IsCandleStickGraphEnabled = false;
			IsLinearGraphEnabled = false;
			IsBarGraphEnabled = false;

			GraphTypeChosen = new DataWrapper<string>(this, graphTypeChoseChangeArgs, GraphTypeChosenChanged);

			Array graphTypesArray = Enum.GetValues(typeof(GraphType));
			GraphTypesList = new List<string>();
			foreach (GraphType gt in graphTypesArray)
			{
				string graphTypeAsString = string.Empty;

				switch (gt)
				{
					case GraphType.Bars:
						 graphTypeAsString = Resources.Resources.BarChartLabel;
						break;

					case GraphType.Candles:
						 graphTypeAsString = Resources.Resources.CandlestickTitle;
						break;

					case GraphType.Linear:
						graphTypeAsString = Resources.Resources.LinearChartTitle;
						break;

					default:
						graphTypeAsString = gt.ToString();
						break;
				}

				GraphTypesList.Add(graphTypeAsString);
			}

			switch (ConfigurationSingleton.Instance.GraphType)
			{
				case GraphType.Bars:
					GraphTypeChosen.DataValue = Resources.Resources.BarChartLabel;
					break;

				case GraphType.Candles:
					GraphTypeChosen.DataValue = Resources.Resources.CandlestickTitle;
					break;

				case GraphType.Linear:
					GraphTypeChosen.DataValue = Resources.Resources.LinearChartTitle;
					break;
			}

			DateTimeFrom = ConfigurationSingleton.Instance.DateTimeMin;
			DateTimeTo = ConfigurationSingleton.Instance.DateTimeMax;

			IsVolumeChartVisibile = new DataWrapper<bool>(this, isVolumeChartVisibleChangeArgs, VolumeChartVisiblityChanged);
			IsVolumeChartVisibile.DataValue = false;

			UpdateButtonLabel = Resources.Resources.UpdateButtonLabel;
			DateFromLabel     = Resources.Resources.DateFromLabel;
			DateToLabel       = Resources.Resources.DateToLabel;
			GraphLabel        = Resources.Resources.GraphLabel;
			TickerLabel       = Resources.Resources.TickerLabel;
			ShowVolumeLabel   = Resources.Resources.ShowVolumeLabel;

			AggregationLabelText             = Resources.Resources.AggregationLabelText;
			AddAggregationButtonText         = Resources.Resources.AddAggregationButtonText;
			RemoveAggregationButtonText      = Resources.Resources.RemoveAggregationButtonText;
			AggregationLengthParameterLength = Resources.Resources.AggregationLengthParameterLength;
			DefinedAggregationsLabelText     = Resources.Resources.DefinedAggregationsLabel;

			SelectedOpenValueLabel  = Resources.Resources.SelectedOpenValueLabel;
			SelectedMinValueLabel   = Resources.Resources.SelectedMinValueLabel;
			SelectedMaxValueLabel   = Resources.Resources.SelectedMaxValueLabel;
			SelectedCloseValueLabel = Resources.Resources.SelectedCloseValueLabel;
			SelectedDayValueLabel   = Resources.Resources.SelectedDayValueLabel;
			SelectedVolumeLabel     = Resources.Resources.SelectedVolumeLabel;

			StocksTitle = Resources.Resources.StocksTitle;
			HelpTitle   = Resources.Resources.HelpTitle;
			HelpText    = Resources.Resources.HelpText;

			/////////////////////////////////////////////////////
			/// prepare AggregationParam
			///
			AggregationParam = new DataWrapper<string>(this, aggregationParamChangeArgs);
			AggregationParam.DataValue = "10";
			AggregationParam.AddRule(AggregationParamRule);
			SelectedAggregationIndex = 0;

			CachedListOfDataWrappers = DataWrapperHelper.GetWrapperProperties<MainPageViewModel>(this);
		}

		private void AddAggregationCommandCallback(Object args)
		{
			if (_selectedAggregationIndex < 0 || _selectedAggregationIndex >= DefinedAggregations.Length)
				return;

			// check validity of input data
			if (!DataWrapperHelper.AllValid(this.CachedListOfDataWrappers))
				return;

			AggregationInfo selectedAggregation = DefinedAggregations[_selectedAggregationIndex];

			Int32 result;

			if (Int32.TryParse(AggregationParam.DataValue, out result))
			{
				AggregationParameters ap = new AggregationParameters(selectedAggregation, result);

				if (!_selectedAggregationsMap.ContainsKey(ap.ItemInfo))
				{
					_selectedAggregationsMap.Add(ap.ItemInfo, ap);

					_selectedAggregations.Add(ap);

					SelectedDefinedAggregation = ap;
				}
			}

		}

		private void DeleteAggregationCommandCallback(Object args)
		{
			if (SelectedDefinedAggregation == null)
			{
				return;
			}

			_selectedAggregationsMap.Remove(SelectedDefinedAggregation.ItemInfo);

			_selectedAggregations.Remove(SelectedDefinedAggregation);

			if (_selectedAggregations.Count > 0)
			{
				/////////////////////////////////////////////////////////
				/// select last item
				/// 

				SelectedDefinedAggregation = _selectedAggregations[_selectedAggregations.Count - 1];
			}
		}

		private void CreateCommands()
		{
			UpdateSettingsCommand = new SimpleCommand<Object, Object>(RequeryFinanceService);

			AddAggregationCommand = new SimpleCommand<Object,Object>(AddAggregationCommandCallback);

			DeleteAggregationCommand = new SimpleCommand<Object,Object>(DeleteAggregationCommandCallback);
		}

		# endregion //Model Setup

		# region Private Methods

		/// <summary>
		/// based on graph selection different control will be enabled
		/// </summary>
		private void GraphTypeChosenChanged()
		{
			IsCandleStickGraphEnabled = false;

			IsLinearGraphEnabled = false;
			IsBarGraphEnabled = false;

			if (String.Compare(GraphTypeChosen.DataValue, Resources.Resources.BarChartLabel) == 0)
			{
				IsBarGraphEnabled = true;
			}
			else if (String.Compare(GraphTypeChosen.DataValue, Resources.Resources.CandlestickTitle) == 0)
			{
				IsCandleStickGraphEnabled = true;
			}
			else if (String.Compare(GraphTypeChosen.DataValue, Resources.Resources.LinearChartTitle) == 0)
			{
				IsLinearGraphEnabled = true;
			}


			RefreshAllGraphs();
		}

		private void VolumeChartVisiblityChanged()
		{
			if (CandleStickGraphViewModel != null)
			{
				CandleStickGraphViewModel.IsVolumeChartVisibile = IsVolumeChartVisibile.DataValue;
			}

			if (BarGraphViewModel != null)
			{
				BarGraphViewModel.IsVolumeChartVisibile = IsVolumeChartVisibile.DataValue;
			}

			if (LinearGraphViewModel != null)
			{
				LinearGraphViewModel.IsVolumeChartVisibile = IsVolumeChartVisibile.DataValue;
			}
		}

		private void RequeryFinanceService(Object args)
		{
			if (_elementDailyDataRangeBase != null && 
				_elementDailyDataRangeBase.Ticker == ConfigurationSingleton.Instance.StockName &&
				_elementDailyDataRangeBase.DateFrom == DateTimeFrom &&
				_elementDailyDataRangeBase.DateTo == DateTimeTo)
			{
				//////////////////////////////////////////////////////////////////////////////
				/// use cached results 
				/// 

				try
				{
					ProcessResults(_elementDailyDataRangeBase, false);
				}
				catch (Exception ex)
				{
	#if DEBUG
					MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
	#else
					MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
	#endif
				}
			}
			else
			{
				_financeServiceClient.SelectDailyDataAsync(ConfigurationSingleton.Instance.StockName);
			}
		}

		/// <summary>
		/// updates a selected view model with information from the parent view model
		/// </summary>
		/// <param name="model"></param>
		private void RefreshAllGraphs()
		{
			if (CandleStickGraphViewModel != null)
			{
				CandleStickGraphViewModel.ElementDailyDataRangeWrapper = null;
			}

			if (BarGraphViewModel != null)
			{
				BarGraphViewModel.ElementDailyDataRangeWrapper = null;
			}

			if (LinearGraphViewModel != null)
			{
				LinearGraphViewModel.ElementDailyDataRangeWrapper = null;
			}

			if (null != ElementDailyDataRangeWrapper)
			{
				if (CandleStickGraphViewModel != null)
				{
					CandleStickGraphViewModel.ElementDailyDataRangeWrapper = ElementDailyDataRangeWrapper;
				}

				if (BarGraphViewModel != null)
				{
					BarGraphViewModel.ElementDailyDataRangeWrapper = ElementDailyDataRangeWrapper;
				}

				if (LinearGraphViewModel != null)
				{
					LinearGraphViewModel.ElementDailyDataRangeWrapper = ElementDailyDataRangeWrapper;
				}

				if (null != calculatedAggregationsContainer && calculatedAggregationsContainer.Ticker != ElementDailyDataRangeWrapper.ElementDailyDataRange.Ticker || null == calculatedAggregationsContainer)
				{
					calculatedAggregationsContainer = new CalculatedAggregationsContainer();
				}

				PrepareAggregationsContainer();

				if (CandleStickGraphViewModel != null)
				{
					CandleStickGraphViewModel.CalculatedAggregationsContainer = calculatedAggregationsContainer;
				}

				if (BarGraphViewModel != null)
				{
					BarGraphViewModel.CalculatedAggregationsContainer = calculatedAggregationsContainer;
				}

				if (LinearGraphViewModel != null)
				{
					LinearGraphViewModel.CalculatedAggregationsContainer = calculatedAggregationsContainer;
				}
			}
			else
			{
				if (CandleStickGraphViewModel != null)
				{
					CandleStickGraphViewModel.CalculatedAggregationsContainer = null;
				}

				if (BarGraphViewModel != null)
				{
					BarGraphViewModel.CalculatedAggregationsContainer = null;
				}

				if (LinearGraphViewModel != null)
				{
					LinearGraphViewModel.CalculatedAggregationsContainer = null;
				}
			}
		}

		private CalculatedAggregationsContainer calculatedAggregationsContainer = null;

		private static IAggregation GetAggregationFromParameters(AggregationParameters ap)
		{
			if (ap.AggregationInfo.TargetType == typeof(Sma))
			{
				return new Sma((UInt32)ap.Length);
			}

			if (ap.AggregationInfo.TargetType == typeof(MinValue))
			{
				return new MinValue((UInt32)ap.Length);
			}

			if (ap.AggregationInfo.TargetType == typeof(MaxValue))
			{
				return new MaxValue((UInt32)ap.Length);
			}

			if (ap.AggregationInfo.TargetType == typeof(Ema))
			{
				return new Ema((UInt32)ap.Length, 0.1M);
			}

			if (ap.AggregationInfo.TargetType == typeof(BollingerBand))
			{
				return new BollingerBand((UInt32)ap.Length);
			}

			if (ap.AggregationInfo.TargetType == typeof(RWilliams))
			{
				return new RWilliams((UInt32)ap.Length, -90M, -10M);
			}

			if (ap.AggregationInfo.TargetType == typeof(Rsi))
			{
				return new Rsi((UInt32)ap.Length, 20.0M, 80.0M);
			}

			if (ap.AggregationInfo.TargetType == typeof(MoneyFlow))
			{
				return new MoneyFlow((UInt32)ap.Length, 20.0M, 80.0M);
			}

			if (ap.AggregationInfo.TargetType == typeof(CommodityChannelIndex))
			{
				return new CommodityChannelIndex((UInt32)ap.Length);
			}

			if (ap.AggregationInfo.TargetType == typeof(StochasticOscillator)) 
			{
				return new StochasticOscillator((UInt32)ap.Length, 3, 20.0M, 80.0M);
			}

			throw new NotImplementedException(ap.AggregationInfo.TargetType.FullName);
		}

		/// <summary>
		/// prepares aggregations
		/// </summary>
		private void PrepareAggregationsContainer()
		{
			if (null != ElementDailyDataRangeWrapper && null != ElementDailyDataRangeWrapper.ElementDailyDataRange)
			{
				if (null != SelectedAggregations)
				{
					if (SelectedAggregations.Count > 0)
					{
						foreach (AggregationParameters ap in SelectedAggregations)
						{
							if (!calculatedAggregationsContainer.Aggregations.ContainsKey(ap.ItemInfo))
							{
								CalculatedAggregationInfo cai = new CalculatedAggregationInfo();

								IAggregation aggregation = GetAggregationFromParameters(ap);

								cai.Aggregation = aggregation;

								cai.Name = ap.ItemInfo;

								cai.AggregationColor = VersatileFactory.Instance.CreateColorProvider().GetColor((UInt32)ap.ItemInfo.GetHashCode());

								cai.Enabled = true;

								calculatedAggregationsContainer.Aggregations.Add(ap.ItemInfo, cai);
							}
						}

						PrepareAggregationData();

						return;
					}
				}
			}

			calculatedAggregationsContainer.Aggregations.Clear();
		}


		private void PrepareAggregationData()
		{
			DailyDataWrapper[] allRows = _elementDailyDataRangeBase.DailyData.ToArray();

			DailyDataWrapper[] dataForAggregation = null;

			//if (null == dataForAggregation)
			{
				////////////////////////////////////////////////////////////////////////
				/// prepare aggregation data
				/// 

				UInt32 maxAggregationLength = 0;

				foreach (CalculatedAggregationInfo ai in calculatedAggregationsContainer.Aggregations.Values)
				{
					if (maxAggregationLength < ai.Aggregation.Length)
					{
						maxAggregationLength = ai.Aggregation.Length;
					}
				}

				if (maxAggregationLength > 0)
				{
					List<DailyDataWrapper> selected = new List<DailyDataWrapper>();

					for (Int32 q = 0, allRowsCount = allRows.Length; q < allRowsCount; q++)
					{
						Int32 checkIndex = (Int32)maxAggregationLength + q;

						if (allRowsCount > checkIndex)
						{
							if (allRows[checkIndex].Day >= DateTimeFrom && allRows[q].Day <= DateTimeTo)
							{
								selected.Add(allRows[q]);
							}
						}
						else
						{
							if (allRows[q].Day >= DateTimeFrom && allRows[q].Day <= DateTimeTo)
							{
								selected.Add(allRows[q]);
							}
						}
					}

					dataForAggregation = selected.ToArray();
				}
			}

			if (null != ElementDailyDataRangeWrapper.ElementDailyDataRange.DailyData)
			{
				foreach (CalculatedAggregationInfo ai in calculatedAggregationsContainer.Aggregations.Values)
				{
					if ((ai.PreparedData == null || ai.PreparedData != null && ai.PreparedData.Count <= 0) && ai.Enabled)
					{
						PrepareAggregationData(ai, dataForAggregation);
					}
				}
			}
		}

		private void PrepareAggregationData(CalculatedAggregationInfo ai, DailyDataWrapper[] dataForAggregation)
		{
			List<Dictionary<DateTime, Decimal>> aggrData = new List<Dictionary<DateTime, Decimal>>();

			List<List<SingleValueDayPair>> aggrDataForGraph = new List<List<SingleValueDayPair>>();

			if (ai.Aggregation.AggregationInputType == AggregationInputType.Plain)
			{
				for (Int32 q = 0; q < dataForAggregation.Length; q++)
				{
					DailyDataWrapper current = dataForAggregation[q];

					ai.Aggregation.AddNext(current.CloseValue);

					if (q == 0)
					{
						for (Int32 w = 0; w < ai.Aggregation.ValuesCount; w++)
						{
							aggrData.Add(new Dictionary<DateTime, Decimal>());

							aggrDataForGraph.Add(new List<SingleValueDayPair>());
						}
					}

					if (ai.Aggregation.IsReady)
					{
						for (Int32 w = 0; w < ai.Aggregation.ValuesCount; w++)
						{
							aggrData[w].Add(current.Day, ai.Aggregation[w]);

							if (current.Day >= DateTimeFrom && current.Day <= DateTimeTo)
							{
								Int32 res;

								if (ElementDailyDataRangeWrapper.ReveresedDaysMap.TryGetValue(current.Day, out res))
								{
									aggrDataForGraph[w].Add(new SingleValueDayPair(
										current.Day,
										ai.Aggregation[w],
										res));
								}
							}
						}
					}
				}
			}
			else if (ai.Aggregation.AggregationInputType == AggregationInputType.Extended)
			{
				IExtendedAggregation extendedAggregation = (IExtendedAggregation)ai.Aggregation;

				for (Int32 q = 0; q < dataForAggregation.Length; q++)
				{
					DailyDataWrapper current = dataForAggregation[q];

					extendedAggregation.AddNext(current.OpenValue, current.MinValue, current.MaxValue, current.CloseValue, (Int64)current.Volume);

					if (q == 0)
					{
						for (Int32 w = 0; w < ai.Aggregation.ValuesCount; w++)
						{
							aggrData.Add(new Dictionary<DateTime, Decimal>());

							aggrDataForGraph.Add(new List<SingleValueDayPair>());
						}
					}

					if (ai.Aggregation.IsReady)
					{
						for (Int32 w = 0; w < ai.Aggregation.ValuesCount; w++)
						{
							aggrData[w].Add(current.Day, ai.Aggregation[w]);

							if (current.Day >= DateTimeFrom && current.Day <= DateTimeTo)
							{
								Int32 res;

								if (ElementDailyDataRangeWrapper.ReveresedDaysMap.TryGetValue(current.Day, out res))
								{
									aggrDataForGraph[w].Add(new SingleValueDayPair(current.Day, ai.Aggregation[w], res));
								}
							}
						}
					}
				}
			}

			ai.PreparedData = aggrData;

			ai.PreparedDataForGraph = aggrDataForGraph;
		}

		/// <summary>
		/// method which reacts towards data availability from the finance data service
		/// for the 1st time it uses data provided from ASP.NET webpage
		/// next times it uses data supplied by Siverlight
		/// </summary>
		/// <param name="result"></param>
		/// <param name="useParameters"></param>
		private void ProcessResults(FinanceDataService.ElementDailyDataRange result, Boolean useParameters)
		{
			FinanceDataService.ElementDailyDataRange tempElementDailyDataRange = new FinanceDataService.ElementDailyDataRange();

			tempElementDailyDataRange.Ticker = result.Ticker;

			DateTime dateFrom;
			DateTime dateTo;

			if (useParameters)
			{
				dateFrom = ConfigurationSingleton.Instance.DateTimeMin;
				dateTo = ConfigurationSingleton.Instance.DateTimeMax;
			}	
			else
			{
				dateFrom = _dateTimeFrom;
				dateTo = _dateTimeTo;
			}

			tempElementDailyDataRange.DailyData = new System.Collections.ObjectModel.ObservableCollection<FinanceDataService.DailyDataWrapper>
				(
					from dd in result.DailyData
					where
						dd.Day >= dateFrom
						&& dd.Day <= dateTo
					select dd
				);

			if (tempElementDailyDataRange.DailyData.Count > 0)
			{
				tempElementDailyDataRange.DateFrom = tempElementDailyDataRange.DailyData[0].Day;
				tempElementDailyDataRange.DateTo = tempElementDailyDataRange.DailyData[tempElementDailyDataRange.DailyData.Count - 1].Day;
			}
			else
			{
				tempElementDailyDataRange.DateTo = dateTo;
				tempElementDailyDataRange.DateFrom = dateFrom;
			}

			// prepare data for converter, so that dates can be displayed in linear axes
			DoubleToStringConverter.DatesArray = new List<DateTime>();

			_dataDictionary = new Dictionary<DateTime, DailyDataWrapper>();

			Int32 distance = 0;

			Dictionary<Int32, DateTime> daysMap = new Dictionary<Int32, DateTime>();

			Dictionary<DateTime, Int32> reversedDaysMap = new Dictionary<DateTime, Int32>();

			foreach (DailyDataWrapper ddw in tempElementDailyDataRange.DailyData)
			{
				DoubleToStringConverter.DatesArray.Add(ddw.Day);

				daysMap.Add(distance, ddw.Day);

				reversedDaysMap.Add(ddw.Day, distance);

				ddw.DayAsDouble = distance++;

				_dataDictionary.Add(ddw.Day, ddw);
			}

			ElementDailyDataRangeWrapper = new ElementDailyDataRangeWrapper(tempElementDailyDataRange, daysMap, reversedDaysMap);

			_elementDailyDataRangeBase = result;
		}

		# endregion //Private Methods

		# region Service Related Methods

		void client_SelectDailyDataCompleted(Object sender, FinanceDataService.SelectDailyDataCompletedEventArgs e)
		{
			try
			{
				if (null == e.Error)
				{
					ProcessResults(e.Result, _firstTimeSoUseParameters);
					_firstTimeSoUseParameters = false;
				}
				else
				{
#if DEBUG
					MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButton.OK);
#else
					MessageBox.Show(e.Error.Message, "Error", MessageBoxButton.OK);
#endif
				}
			}
			catch (Exception ex)
			{
#if DEBUG
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
#else
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
#endif
			}
		}

		# endregion 
	}
}
