using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Finance.Common
{
	/// <summary>
	/// template of the configuration parameter
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ConfigurationParameterLimited<T> where T : struct, IComparable
	{
		protected T defaultValueVar;

		protected T minValueVar;

		protected T maxValueVar;

		public T MinValue
		{
			get
			{
				return minValueVar;
			}
		}

		public T MaxValue
		{
			get
			{
				return maxValueVar;
			}
		}

		protected String key;

		public T DefaultValue
		{
			get
			{
				return defaultValueVar;
			}
		}

		public String ConfigurationKey
		{
			get
			{
				return key;
			}
		}

		public void Clear()
		{
			//////////////////////////////////////////////
			/// clear the value
			/// 

			wrapper = null;
		}

		public static T ReadFromConfig(String key, T defaultValue, T minValue, T maxValue)
		{
			if (ConfigurationManager.AppSettings[key] != null)
			{
				T tempValue;

				try
				{
					tempValue = (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));

					if (tempValue.CompareTo(minValue) < 0)
					{
						tempValue = minValue;
					}

					if (tempValue.CompareTo(maxValue) > 0)
					{
						tempValue = maxValue;
					}
				}
				catch
				{
					tempValue = defaultValue;
				}

				return tempValue;
			}
			else
			{
				return defaultValue;
			}
		}

		public ConfigurationParameterLimited(String key, T defaultValue, T minValue, T maxValue)
		{
			if (String.IsNullOrEmpty(key))
			{
				throw new ArgumentException("key");
			}

			if (minValue.CompareTo(maxValue) > 0)
			{
				throw new ArgumentOutOfRangeException("maxValue");
			}

			if (defaultValue.CompareTo(minValue) < 0)
			{
				throw new ArgumentOutOfRangeException("defaultValue");
			}

			if (defaultValue.CompareTo(maxValue) > 0)
			{
				throw new ArgumentOutOfRangeException("defaultValue");
			}

			this.minValueVar = minValue;

			this.maxValueVar = maxValue;

			this.defaultValueVar = defaultValue;

			this.key = key;
		}

		protected Nullable<T> wrapper;

		public T Value
		{
			get
			{
				if (!wrapper.HasValue)
				{
					wrapper = ReadFromConfig(key, defaultValueVar, minValueVar, maxValueVar);
				}

				return wrapper.Value;
			}
		}
	}

}
