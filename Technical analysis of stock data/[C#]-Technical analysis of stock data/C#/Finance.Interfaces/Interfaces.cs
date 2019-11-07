using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.Interfaces
{
	public interface IStockDataProvider
	{
	}

	public interface IModule
	{
		String Name
		{
			get;
		}

		void Start();

		void Stop();
	}

	public enum AggregationInputType : byte
	{
		Plain = 1,
		Extended = 2,
	}

	public enum AggregationOutputType : byte
	{
		Plain = 1,
		Oscillator = 2,
		NotClassified = 0
	}

	/// <summary>
	/// logger interface
	/// </summary>
	public interface ILogger
	{
		Boolean IsTraceEnabled
		{
			get;
		}

		Boolean IsDebugEnabled
		{
			get;
		}

		Boolean IsInfoEnabled
		{
			get;
		}

		Boolean IsWarnEnabled
		{
			get;
		}

		Boolean IsErrorEnabled
		{
			get;
		}

		Boolean IsExceptionEnabled
		{
			get;
		}

		void Trace(String message);

		void Debug(String message);

		void Info(String message);

		void Error(String message);

		void Warn(String message);

		void Exception(String message, Exception ex);
	}

	#region IAggregation interface definition

	public interface IAggregation
	{
		Decimal CurrentValue
		{
			get;
		}

		void AddNext(Decimal value);

		Boolean IsReady
		{
			get;
		}

		UInt32 Length
		{
			get;
		}

		AggregationInputType AggregationInputType
		{
			get;
		}

		AggregationOutputType AggregationOutputType
		{
			get;
		}

		Int32 ValuesCount
		{
			get;
		}

		Decimal this[Int32 index]
		{
			get;
		}
	}

	public interface IExtendedAggregation : IAggregation
	{
		void AddNext(Decimal openValue, Decimal minValue, Decimal maxValue, Decimal closeValue, Int64 volume);
	}

	#endregion IAggregation interface definition

	public interface IOscillator : IAggregation
	{
		Decimal LowValueBound
		{
			get;
		}

		Decimal LowMarker
		{
			get;
		}

		Decimal HighValueBound
		{
			get;
		}

		Decimal HighMarker
		{
			get;
		}
	}
}
