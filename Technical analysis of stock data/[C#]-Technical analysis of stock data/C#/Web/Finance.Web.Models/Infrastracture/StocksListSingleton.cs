using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Finance.Web.Models.Infrastracture
{
	class StocksListSingleton
	{
		# region Data

		private const string STOCKS_FILE_NAME = "Finance.Web.Models.Infrastracture.StocksList.txt";

		private static volatile StocksListSingleton _instance;

		private static Object _synchro = new Object();

		private StocksListSingleton() { }

		private List<string> _stocksList;
		public List<string> StockList
		{
			get
			{
				return _stocksList;
			}
			private set
			{
				_stocksList = value;
			}
		}

		# endregion //Data

		# region Constructor

		public static StocksListSingleton Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_synchro) /// thread-safe singleton
					{
						if (null == _instance)
						{
							_instance = new StocksListSingleton();
							_instance.ReadStocksFromFile();
						}
					}
				}

				return _instance;
			}
		}

		# endregion //Constructor

		# region Private Methods

		public void ReadStocksFromFile()
		{
			try
			{
				StockList = new List<string>();

				Assembly assembly = Assembly.GetExecutingAssembly();
				Stream stream = assembly.GetManifestResourceStream(STOCKS_FILE_NAME);
				StreamReader textStreamReader = new StreamReader(stream);
				
				bool canRead = true;
				while (canRead)
				{
					string line = textStreamReader.ReadLine();
					if (String.IsNullOrWhiteSpace(line))
					{
						canRead = false;
					}
					else
					{
						StockList.Add(line);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception caught = " + ex.Message);
			}
		}

		# endregion //Private Methods


	}
}
