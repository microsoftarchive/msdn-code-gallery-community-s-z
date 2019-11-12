using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using System.Threading;
using Finance.Common;

namespace Finance.Web.DataWrappers
{
	class DataCache
	{
		private static DataCache instance = new DataCache();

		public static DataCache Instance
		{
			get
			{
				return instance;
			}
		}

		private DataCache()
		{
			
		}

		private Int32 dataWrapperCacheTimeToLive = new ConfigurationParameterLimited<Int32>("DataWrapperCacheTimeToLive", 300, 0, 86400).Value; /// in seconds

		private MemoryCache cache = new MemoryCache("DataWrappersCache", null);

		private ReaderWriterLockSlim synchro = new ReaderWriterLockSlim();

		public Object Get(String key)
		{
			synchro.EnterReadLock();

			try
			{
				return cache.Get(key);
			}
			finally
			{
				synchro.ExitReadLock();
			}
		}

		public void Add(String key, Object value)
		{
			LoggerFactory.AppLogger.Debug("[DataCache.Add] Adding item to cache " + key);

			synchro.EnterWriteLock();

			try
			{
				cache.Remove(key);

				DateTimeOffset offset = new DateTimeOffset(DateTime.Now.AddSeconds(dataWrapperCacheTimeToLive));

				cache.Add(key, value, offset);
			}
			finally
			{
				synchro.ExitWriteLock();
			}
		}
	}
}
