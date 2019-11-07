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
	public class BollingerBand : IAggregation
	{
		private UInt32 length;

		private UInt32 width;

		private Sma sma;

		public BollingerBand(UInt32 length) : this(length, 2)
		{
		}

		public BollingerBand(UInt32 length, UInt32 width)
		{
			if (width < 1 || width > 10)
			{
				throw new ArgumentOutOfRangeException("width " + width);
			}

			this.length = length;

			this.width = width;

			this.sma = new Sma(length);
		}

		public decimal CurrentValue
		{
			get 
			{
				return sma.CurrentValue;
			}
		}

		public void AddNext(Decimal value)
		{
			sma.AddNext(value);
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

		private const Int32 valuesCount = 2;

		public Int32 ValuesCount
		{
			get 
			{
				return valuesCount;
			}
		}

		public Decimal this[int index]
		{
			get 
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("aggregation is not ready yet");
				}

				switch (index)
				{
					case 0:
						return sma.CurrentValue - sma.Dev * width;

					case 1:
						return sma.CurrentValue + sma.Dev * width;

					default:
						throw new ArgumentOutOfRangeException("index " + index);
				}
			}
		}
	}
}
