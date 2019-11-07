using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Finance.Common
{
	public class ConfigurationParameter<T> where T : struct
	{
		protected T defaultValue;

		protected String key;

		public T DefaultValue
		{
			get
			{
				return defaultValue;
			}
		}

		public String ConfigurationKey
		{
			get
			{
				return key;
			}
		}

		public static T ReadFromConfig(String key, T defaultValue)
		{
			if (ConfigurationManager.AppSettings[key] != null)
			{
				T tempValue;

				try
				{
					tempValue = (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
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

		public ConfigurationParameter(String key, T defaultValue)
		{
			if (String.IsNullOrEmpty(key))
			{
				throw new ArgumentException("key");
			}

			this.defaultValue = defaultValue;

			this.key = key;
		}

		protected Nullable<T> wrapper;

		public T Value
		{
			get
			{
				if (!wrapper.HasValue)
				{
					wrapper = ReadFromConfig(key, defaultValue);
				}

				return wrapper.Value;
			}
		}

		public void Clear()
		{
			wrapper = null;
		}
	}

	public class LimitedConfigurationParameter<T> : ConfigurationParameter<T> where T : struct, IComparable
	{
		protected T minValue;

		protected T maxValue;

		public LimitedConfigurationParameter(String key, T defaultValue, T minValue, T maxValue)
			: base(key, defaultValue)
		{
			if (minValue.CompareTo(maxValue) > 0)
			{
				throw new ArgumentOutOfRangeException("minValue or maxValue");
			}

			this.minValue = minValue;

			this.maxValue = maxValue;
		}

		public new T Value
		{
			get
			{
				T tempValue = base.Value;

				if (tempValue.CompareTo(minValue) < 0)
				{
					return minValue;
				}
				else
				{
					if (tempValue.CompareTo(maxValue) > 0)
					{
						return maxValue;
					}
					else
					{
						return tempValue;
					}
				}
			}

		}
	}

	public class WritableConfigurationParameter<T> : ConfigurationParameter<T> where T : struct
	{
		public WritableConfigurationParameter(String key, T defaultValue)
			: base(key, defaultValue)
		{
		}

		public static void WriteValueToConfig(String key, T value)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			if (null != config.AppSettings.Settings[key])
			{
				config.AppSettings.Settings.Remove(key);
			}

			config.AppSettings.Settings.Add(key, value.ToString());

			config.Save();
		}

		public new T Value
		{
			get
			{
				return base.Value;
			}

			set
			{
				if (base.Value.ToString() != value.ToString())
				{
					WriteValueToConfig(ConfigurationKey, value);
				}

				wrapper = value;
			}
		}
	}

	public class WritableLimitedConfigurationParameter<T> : WritableConfigurationParameter<T> where T : struct, IComparable
	{
		protected T minValue;

		protected T maxValue;

		public WritableLimitedConfigurationParameter(String key, T defaultValue, T minValue, T maxValue)
			: base(key, defaultValue)
		{
			if (minValue.CompareTo(maxValue) > 0)
			{
				throw new ArgumentOutOfRangeException("minValue or maxValue");
			}

			this.minValue = minValue;

			this.maxValue = maxValue;
		}

		public new T Value
		{
			get
			{
				T tempValue = base.Value;

				if (tempValue.CompareTo(minValue) < 0)
				{
					return minValue;
				}
				else
				{
					if (tempValue.CompareTo(maxValue) > 0)
					{
						return maxValue;
					}
					else
					{
						return tempValue;
					}
				}
			}

			set
			{
				base.Value = value;
			}
		}
	}
}
