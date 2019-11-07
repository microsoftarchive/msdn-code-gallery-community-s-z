using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.Common;
using System.Transactions;

namespace Finance.DataProvider
{
	public class ConfigurationProvider
	{
		public String BossaLastDataUrl
		{
			get
			{
				return GetParameterFromDatabase("BossaLastDataUrl", @"http://bossa.pl/pub/ciagle/mstock/sesjacgl/few_last.zip");
			}
		}

		public String BossaAllDataUrl
		{
			get
			{
				return GetParameterFromDatabase("BossaAllDataUrl", @"http://bossa.pl/pub/metastock/mstock/mstall.zip");
			}
		}

		public String LastDataLastModifiedHeader
		{
			get
			{
				return GetParameterFromDatabase("LastDataLastModifiedHeader", String.Empty);
			}

			set
			{
				UpdateParameter("LastDataLastModifiedHeader", value);
			}
		}

		public String AllDataLastModifiedHeader
		{
			get
			{
				return GetParameterFromDatabase("AllDataLastModifiedHeader", String.Empty);
			}

			set
			{
				UpdateParameter("AllDataLastModifiedHeader", value);
			}
		}

		public DateTime LastLastDataRefresh
		{
			get
			{
				String temp = GetParameterFromDatabase("LastLastDataRefresh", "0");

				Int64 ticks = Int64.Parse(temp);

				DateTime result = DateTime.FromBinary(ticks);

				return result;
			}

			set
			{
				Int64 ticks = value.ToBinary();

				UpdateParameter("LastLastDataRefresh", ticks.ToString());
			}
		}

		public DateTime LastAllDataRefresh
		{
			get
			{
				String temp = GetParameterFromDatabase("LastAllDataRefresh", "0");

				Int64 ticks = Int64.Parse(temp);

				DateTime lastAllDataRefresh = DateTime.FromBinary(ticks);

				return lastAllDataRefresh;
			}

			set
			{
				Int64 ticks = value.ToBinary();

				UpdateParameter("LastAllDataRefresh", ticks.ToString());
			}
		}

		public Int32 DataCacheRefreshPeriod
		{
			get
			{
				String temp = GetParameterFromDatabase("DataCacheRefreshPeriod", "120" /* minutes */);

				return InternalUtilities.ApplyLimits(Int32.Parse(temp), 1, 1440);
			}
		}

		public Int32 FileImportPeriod
		{
			get
			{
				String temp = GetParameterFromDatabase("FileImportPeriod", "5" /* minutes */);

				return InternalUtilities.ApplyLimits(Int32.Parse(temp), 1, 1440);
			}
		}

		public Int32 AllDataRefreshPeriod
		{
			get
			{
				String temp = GetParameterFromDatabase("AllDataRefreshPeriod", "1440" /* minutes */);

				return InternalUtilities.ApplyLimits(Int32.Parse(temp), 1, 525600);
			}
		}

		public Int32 LastDataRefreshPeriod
		{
			get
			{
				String temp = GetParameterFromDatabase("LastDataRefreshPeriod", "1440" /* minutes */);

				return InternalUtilities.ApplyLimits(Int32.Parse(temp), 1, 525600);
			}
		}

		private void UpdateParameter(String name, String value)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required))
				{
					Parameters[] parameters = (from ps in context.Parameters
											   where ps.Name == name
											   select ps).Take<Parameters>(1).ToArray();

					if (null != parameters && parameters.Length > 0)
					{
						parameters[0].Value = value;
					}
					else
					{
						Parameters newItem = Parameters.CreateParameters(name, value);

						context.Parameters.AddObject(newItem);
					}

					context.SaveChanges();

					transaction.Complete();
				}
			}
		}

		private String GetParameterFromDatabase(String name, String defaultValue)
		{
			////////////////////////////////////////////////////////////
			/// read from database
			/// 

			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				Parameters[] parameters = (from ps in context.Parameters
										   where ps.Name == name
										   select ps).Take<Parameters>(1).ToArray();

				if (null != parameters && parameters.Length > 0)
				{
					return parameters[0].Value;
				}
			}

			////////////////////////////////////////////////////////////
			/// return default value
			/// 

			return defaultValue;
		}
	}
}
