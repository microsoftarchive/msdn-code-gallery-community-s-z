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
	public class RWilliams : IAggregation, IOscillator
	{
		private MinValue minValue;

		private MaxValue maxValue;

		public RWilliams(UInt32 length, Decimal lowMarker, Decimal highMarker)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
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

			this.length = length;

			this.minValue = new MinValue(length);

			this.maxValue = new MaxValue(length);
		}

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

		public Decimal LowValueBound
		{
			get 
			{
				return -100.0M;
			}
		}

		public decimal HighValueBound
		{
			get 
			{
				return 0.0M;
			}
		}

		private Decimal lastAddedValue;

		public Decimal CurrentValue
		{
			get 
			{
				if (IsReady)
				{
					Decimal diff = maxValue.CurrentValue - minValue.CurrentValue;

					if (diff > 0.0M)
					{
						Decimal tempRes = (lastAddedValue - maxValue.CurrentValue) / diff * 100.0M;

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

				throw new InvalidOperationException("aggregation is not ready yet");
			}
		}

		public void AddNext(Decimal value)
		{
			lastAddedValue = value;

			minValue.AddNext(value);

			maxValue.AddNext(value);
		}

		public Boolean IsReady
		{
			get 
			{
				return minValue.IsReady && maxValue.IsReady;
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

		public Int32 ValuesCount
		{
			get 
			{
				return 1;
			}
		}

		public Decimal this[int index]
		{
			get 
			{
				if (0 == index)
				{
					return CurrentValue;
				}

				throw new ArgumentOutOfRangeException("index " + index);
			}
		}
	}
}
