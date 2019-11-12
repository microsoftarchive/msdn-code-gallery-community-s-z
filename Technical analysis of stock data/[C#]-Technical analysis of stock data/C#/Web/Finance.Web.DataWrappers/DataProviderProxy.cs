using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.DataProvider;
using System.Runtime.Caching;
using System.Threading;
using Finance.Common;
using Finance.Common.Base;

namespace Finance.Web.DataWrappers
{
	public class DataProviderProxy
	{
		public DataProviderProxy()
		{
		}

		private static ReaderWriterLock selectElementsLock = new ReaderWriterLock();

		public ElementWrapper[] SelectElements(ElementTypeDefs itemsTypes)
		{
			String cacheItemKey = String.Format("[SelectElements][{0}]", itemsTypes.ToString());

			selectElementsLock.AcquireReaderLock(dataProviderLockTimeout);

			ElementWrapper[] result = null;

			try
			{
				result = (ElementWrapper[])DataCache.Instance.Get(cacheItemKey);

				if (null == result)
				{
					//////////////////////////////////////////////////////////////////
					/// no data in cache - need to load it, but first check it again
					/// 

					LockCookie lockCookie = selectElementsLock.UpgradeToWriterLock(dataProviderLockTimeout);

					try
					{
						result = (ElementWrapper[])DataCache.Instance.Get(cacheItemKey);

						if (null == result)
						{
							Element[] elements = (new ItemsDataProvider()).GetElementsByType(itemsTypes);

							if (LoggerFactory.AppLogger.IsTraceEnabled)
							{
								LoggerFactory.AppLogger.Trace("[DataProviderProxy.SelectElements] Loaded elements " + elements.Length);
							}

							result = WrapperUtilities.Convert(elements);

							DataCache.Instance.Add(cacheItemKey, result);
						}
					}
					finally
					{
						selectElementsLock.DowngradeFromWriterLock(ref lockCookie);
					}
				}
			}
			finally
			{
				selectElementsLock.ReleaseReaderLock();
			}

			return result;
		}

		public ElementDailyDataRange SelectDailyData(String ticker, DateTime dateFrom, DateTime dateTo)
		{
			ElementDailyDataRange tempRes = SelectDailyData(ticker);

			DailyDataWrapper[] tempArr = (from ddw in tempRes.DailyData where ddw.Day >= dateFrom && ddw.Day <= dateTo select ddw).ToArray<DailyDataWrapper>();

			ElementDailyDataRange result;

			if (tempArr.Length > 0)
			{
				result = new ElementDailyDataRange(ticker, tempArr, tempArr[0].Day, tempArr[tempArr.Length - 1].Day);

				if (LoggerFactory.AppLogger.IsTraceEnabled)
				{
					LoggerFactory.AppLogger.Trace("[DataProviderProxy.SelectDailyData] Loaded records for " + ticker + " " + tempArr.Length + " " + result.DateFrom + " " + result.DateTo);
				}

			}
			else
			{
				LoggerFactory.AppLogger.Warn("[DataProviderProxy.SelectDailyData] No data for period for " + ticker + " " + dateFrom + " " + dateTo);

				result = new ElementDailyDataRange(ticker, EmptyArrayTemplate<DailyDataWrapper>.Instance, DateTime.MaxValue, DateTime.MaxValue);
			}

			return result;	
		}

		private Int32 dataProviderLockTimeout = new ConfigurationParameter<Int32>("DataProviderLockTimeout", Timeout.Infinite).Value;

		private static ReaderWriterLock selectDailyDataLock = new ReaderWriterLock();

		public ElementDailyDataRange SelectDailyData(String ticker)
		{
			String cacheItemKey = String.Format("[SelectDailyData][{0}]", ticker);

			selectDailyDataLock.AcquireReaderLock(dataProviderLockTimeout);

			ElementDailyDataRange result = null;

			try
			{
				result = (ElementDailyDataRange)DataCache.Instance.Get(cacheItemKey);

				if (null == result)
				{
					//////////////////////////////////////////////////////////////////
					/// no data in cache - need to load it, but first check it again
					/// 

					LockCookie lockCookie = selectDailyDataLock.UpgradeToWriterLock(dataProviderLockTimeout);

					try
					{
						result = (ElementDailyDataRange)DataCache.Instance.Get(cacheItemKey);

						if (null == result)
						{
							DailyData[] tempRes = (new ItemsDataProvider()).LoadItemDailyData(ticker);

							if (tempRes.Length > 0)
							{
								result = new ElementDailyDataRange(ticker, WrapperUtilities.Convert(tempRes), tempRes[0].Day, tempRes[tempRes.Length - 1].Day);

								if (LoggerFactory.AppLogger.IsTraceEnabled)
								{
									LoggerFactory.AppLogger.Trace("[DataProviderProxy.SelectDailyData] Loaded records for " + ticker + " " + tempRes.Length + " " + result.DateFrom + " " + result.DateTo);
								}

								DataCache.Instance.Add(cacheItemKey, result);
							}
							else
							{
								LoggerFactory.AppLogger.Warn("[DataProviderProxy.SelectDailyData] No data for " + ticker);

								result = new ElementDailyDataRange(ticker, EmptyArrayTemplate<DailyDataWrapper>.Instance, DateTime.MaxValue, DateTime.MaxValue);

								//////////////////////////////////////////////////////
								/// do not add empty item to cache
								/// 
							}
						}
					}
					finally
					{
						selectDailyDataLock.DowngradeFromWriterLock(ref lockCookie);
					}
				}
			}
			finally
			{
				selectDailyDataLock.ReleaseReaderLock();
			}

			return result;
		}
	}
}
