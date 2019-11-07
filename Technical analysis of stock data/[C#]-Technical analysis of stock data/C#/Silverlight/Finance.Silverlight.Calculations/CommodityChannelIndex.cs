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
	public class CommodityChannelIndex : IAggregation, IExtendedAggregation
	{
		private const Decimal paramA = 1 / 0.015M;

		private UInt32 length;

		private Sma sma;

		public CommodityChannelIndex(UInt32 length)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			this.length = length;

			this.sma = new Sma(length);
		}

		public Decimal CurrentValue
		{
			get 
			{
				if (sma.IsReady)
				{
					Decimal dev = sma.AbsDev;

					if (dev > 0.0M)
					{
						return paramA * (lastTypicalPrice - sma.CurrentValue) / dev;
					}

					return 0.0M;
				}
				else
				{
					throw new InvalidOperationException("CCI is not ready yet");
				}
			}
		}

		public void AddNext(Decimal value)
		{
			throw new NotSupportedException("method AddNext is not supported in CCI");
		}

		public Boolean IsReady
		{
			get 
			{
				return sma.IsReady;
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
				return AggregationInputType.Extended;
			}
		}

		public AggregationOutputType AggregationOutputType
		{
			get 
			{
				return AggregationOutputType.CCI;
			}
		}

		public Int32 ValuesCount
		{
			get 
			{
				return 1;
			}
		}

		public Decimal this[Int32 index]
		{
			get 
			{
				if (0 == index)
				{
					return CurrentValue;
				}

				throw new IndexOutOfRangeException("index " + index);
			}
		}

		private Decimal lastTypicalPrice = 0.0M;

		public void AddNext(Decimal openValue, Decimal minValue, Decimal maxValue, Decimal closeValue, Int64 volume)
		{
			Decimal typicalPrice = (minValue + maxValue + closeValue) / 3;

			lastTypicalPrice = typicalPrice;

			sma.AddNext(typicalPrice);
		}
	}
}
