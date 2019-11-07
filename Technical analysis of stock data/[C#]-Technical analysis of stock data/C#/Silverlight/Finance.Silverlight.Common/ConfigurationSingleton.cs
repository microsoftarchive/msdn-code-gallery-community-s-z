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
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Finance.Silverlight.Common
{
	/// <summary>
	/// class which holds information about status of all Silverlight controls in the Solution
	/// </summary>
	public class ConfigurationSingleton
	{
		# region Constructor

		private static volatile ConfigurationSingleton instance;

		private static Object synchro = new Object();

		private ConfigurationSingleton() { }

		public static ConfigurationSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					lock (synchro) /// thread-safe singleton
					{
						if (null == instance)
						{
							instance = new ConfigurationSingleton();
						}
					}
				}

				return instance;
			}
		}

		# endregion

		# region Constants

		private const string dateTimeMinAsString = "dateTimeMinAsString";
		private const string dateTimeMaxAsString = "dateTimeMaxAsString";
		private const string graphTypeAsString   = "graphTypeAsString";
		private const string stockNameAsString   = "stockNameAsString";
		private const string languageAsString    = "languageAsString";

		# endregion

		# region Configuration Params

		private CultureInfo _cultureInfo = new CultureInfo(DefaultCulture);

		public CultureInfo CultureInfo
		{
			get
			{
				return _cultureInfo;
			}
			set
			{
				_cultureInfo = value;
			}
		}

		private DateTime _dateTimeMin = DateTime.MinValue;

		public DateTime DateTimeMin
		{
			get
			{
				return _dateTimeMin;
			}
			set
			{
				_dateTimeMin = value;
			}
		}

		private DateTime _dateTimeMax = DateTime.Today;

		public DateTime DateTimeMax
		{
			get
			{
				return _dateTimeMax;
			}
			set
			{
				_dateTimeMax = value;
			}
		}

		private String _stockName = "WIG20"; /// default stock name

		public string StockName
		{
			get
			{
				return _stockName;
			}
			set
			{
				_stockName = value;
			}
		}

		private GraphType _graphType = GraphType.Candles;

		public GraphType GraphType
		{
			get
			{
				return _graphType;
			}
			set
			{
				_graphType = value;
			}
		}


		# endregion

		# region helper methods

		private const String DefaultCulture = "en-US";

		private Dictionary<String, String> Cultures = new Dictionary<String, String>()
		{
			{ "en-US", "en"},
			{ "pl", "pl"},
			{ "pl-PL", "pl"}
		};

		/// <summary>
		/// parses dictionary of strings and sets appropriate settings
		/// </summary>
		/// <param name="inputParams"></param>
		public void ParseInitParams(IDictionary<String, String> inputParams)
		{
			if (null == inputParams)
			{
				////////////////////////////////////
				/// all parameters are default
				/// 

				Thread.CurrentThread.CurrentCulture = CultureInfo;

				Thread.CurrentThread.CurrentUICulture = CultureInfo;

				return;
			}

			DateTimeStyles styles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal;

			if (inputParams.ContainsKey(dateTimeMinAsString))
			{
				if (!DateTime.TryParse(inputParams[dateTimeMinAsString], CultureInfo, styles, out _dateTimeMin))
				{
					DateTimeMin = DateTime.MinValue;
				}
			}

			if (inputParams.ContainsKey(dateTimeMaxAsString))
			{
				if (!DateTime.TryParse(inputParams[dateTimeMaxAsString], CultureInfo, styles, out _dateTimeMax))
				{
					DateTimeMax = DateTime.Today;
				}
			}

			if (inputParams.ContainsKey(languageAsString))
			{
				String value = inputParams[languageAsString];

				if (null != value && Cultures.ContainsKey(value))
				{
					CultureInfo = new CultureInfo(Cultures[value]);
				}
				else
				{
					CultureInfo = new CultureInfo(DefaultCulture);
				}

				Thread.CurrentThread.CurrentCulture = CultureInfo;

				Thread.CurrentThread.CurrentUICulture = CultureInfo;
			}
			else
			{
				CultureInfo = new CultureInfo(DefaultCulture);

				Thread.CurrentThread.CurrentCulture = CultureInfo;

				Thread.CurrentThread.CurrentUICulture = CultureInfo;
			}

			if (inputParams.ContainsKey(graphTypeAsString))
			{
				if (!Enum.TryParse<GraphType>(inputParams[graphTypeAsString], true, out _graphType))
				{
					GraphType = Common.GraphType.Candles;
				}
			}

			if (inputParams.ContainsKey(stockNameAsString))
			{
				StockName = inputParams[stockNameAsString];
			}
		}

		#endregion


	}
}
