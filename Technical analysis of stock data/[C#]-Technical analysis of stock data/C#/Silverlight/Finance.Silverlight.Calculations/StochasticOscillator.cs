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
using Finance.Silverlight.Common;

namespace Finance.Silverlight.Calculations
{
	#region Stochastic oscillator

	#endregion Stochastic oscillator

	public class StochasticOscillator : IAggregation, IOscillator
	{
		private MinValue minValue;

		private MaxValue maxValue;

		private Sma sma;

		private UInt32 length;

		private Decimal lowMarker;

		public Decimal LowMarker
		{
			get
			{
				return lowMarker;
			}
		}

		private Decimal highMarker;

		public Decimal HighMarker
		{
			get
			{
				return highMarker;
			}
		}

		public StochasticOscillator(UInt32 kLength, UInt32 dLength, Decimal lowMarker, Decimal highMarker)
		{
			if (kLength < 1)
			{
				throw new ArgumentOutOfRangeException("kLength");
			}

			if (dLength < 1)
			{
				throw new ArgumentOutOfRangeException("dLength");
			}

			#region check markers ranges

			if (lowMarker < LowValueBound)
			{
				throw new ArgumentOutOfRangeException("lowMarker " + lowMarker + " < " + LowValueBound);
			}

			if (highMarker < LowValueBound)
			{
				throw new ArgumentOutOfRangeException("highMarker " + highMarker + " < " + LowValueBound);
			}

			if (lowMarker > HighValueBound)
			{
				throw new ArgumentOutOfRangeException("lowMarker " + lowMarker + " > " + HighValueBound);
			}

			if (highMarker > HighValueBound)
			{
				throw new ArgumentOutOfRangeException("highMarker " + highMarker + " > " + HighValueBound);
			}

			if (highMarker < lowMarker)
			{
				throw new ArgumentOutOfRangeException("highMarker or lowMarker " + highMarker + " < " + lowMarker);
			}

			this.highMarker = highMarker;

			this.lowMarker = lowMarker;

			#endregion check markers ranges

			this.length = kLength;

			this.minValue = new MinValue(length);

			this.maxValue = new MaxValue(length);

			this.sma = new Sma(dLength);
		}

		public Decimal LowValueBound
		{
			get
			{
				return 0.0M;
			}
		}

		public Decimal HighValueBound
		{
			get
			{
				return 100.0M;
			}
		}

		public Decimal CurrentValue
		{
			get
			{
				if (!(minValue.IsReady && maxValue.IsReady))
				{
					throw new InvalidOperationException("aggregation is not ready yet");
				}

				Decimal diff = maxValue.CurrentValue - minValue.CurrentValue;

				if (diff > 0.0M)
				{
					Decimal tempRes = 100 * (currentAddedValue - minValue.CurrentValue) / diff;

					if (tempRes < LowValueBound)
					{
						tempRes = LowValueBound;
					}

					if (tempRes > HighValueBound)
					{
						tempRes = HighValueBound;
					}

					return tempRes;
				}
				else
				{
					return 0.0M;
				}
			}
		}

		private Decimal currentAddedValue;

		public void AddNext(Decimal value)
		{
			currentAddedValue = value;

			minValue.AddNext(value);

			maxValue.AddNext(value);

			if (minValue.IsReady && maxValue.IsReady)
			{
				sma.AddNext(CurrentValue);
			}
		}

		public Boolean IsReady
		{
			get
			{
				return minValue.IsReady && maxValue.IsReady && sma.IsReady;
			}
		}

		public UInt32 Length
		{
			get
			{
				return length;
			}
		}

		public AggregationInputType AggregationInputType
		{
			get
			{
				return AggregationInputType.Plain;
			}
		}

		public AggregationOutputType AggregationOutputType
		{
			get
			{
				return AggregationOutputType.Oscillator;
			}
		}

		private const Int32 valuesCount = 2;

		public Int32 ValuesCount
		{
			get
			{
				return valuesCount;
			}
		}

		public Decimal this[Int32 index]
		{
			get
			{
				if (index < 0 || index >= valuesCount)
				{
					throw new ArgumentOutOfRangeException("index " + index);
				}

				if (!IsReady)
				{
					throw new InvalidOperationException("aggregation is not ready yet");
				}

				if (index == 0)
				{
					return CurrentValue;
				}
				else
				{
					return sma.CurrentValue;
				}
			}
		}
	}
}
