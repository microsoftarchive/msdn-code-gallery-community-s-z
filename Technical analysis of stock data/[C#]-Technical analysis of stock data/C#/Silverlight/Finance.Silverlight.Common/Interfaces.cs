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

namespace Finance.Silverlight.Common
{
	public interface IColorProvider
	{
		Color GetColor(UInt32 id);
	}

	public interface IAggregationParametersProvider
	{
		Int32 PrimaryLength
		{
			get;
		}

		Int32 SecondaryLength
		{
			get;
		}

		Decimal LowMarker
		{
			get;
		}

		Decimal HighMarker
		{
			get;
		}
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
		NotClassified = 0,
		CCI = 3,
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
