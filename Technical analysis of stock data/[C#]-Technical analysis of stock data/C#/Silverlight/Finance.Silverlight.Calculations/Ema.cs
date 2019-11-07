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
	#region Ema internal class

	public class Ema : IAggregation
	{
		private Boolean isReady;

		private UInt32 length;

		private Decimal currentSum;

		private Decimal currentLength;

		private Decimal currentValue;

		private Decimal alpha;

		private const Int32 valuesCount = 1;

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

				return CurrentValue;
			}
		}

		public Ema(UInt32 length, Decimal alpha)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			if (alpha <= 0 || alpha >= 1.0M)
			{
				throw new ArgumentOutOfRangeException("alpha");
			}

			isReady = false;

			currentLength = 0;

			currentSum = 0.0M;

			this.length = length;

			this.alpha = alpha;
		}

		public UInt32 Length
		{
			get
			{
				return length;
			}
		}

		public Boolean IsReady
		{
			get
			{
				return isReady;
			}
		}

		public void AddNext(Decimal value)
		{
			if (isReady)
			{
				currentValue = ((value - currentValue) * alpha) + currentValue;
			}
			else
			{
				currentSum += value;
				currentLength++;

				if (currentLength == length)
				{
					currentValue = currentSum / length;
					isReady = true;
				}
			}
		}

		public Decimal CurrentValue
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("ema not ready yet");
				}

				return currentValue;
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
				return AggregationOutputType.Plain;
			}
		}
	}

	#endregion Ema internal class
}
