using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.DataProvider;

namespace Finance.DataProvider
{
	public class ElementCorrelationResult
	{
		public ElementCorrelationResult(ElementCorrelation internalItem)
		{
			if (null == internalItem)
			{
				throw new ArgumentNullException("internalItem");
			}

			this.internalItem = internalItem;

			this.itemKey = new Key(internalItem.TickerA, internalItem.TickerB, (CorrelationPeriodType)internalItem.PeriodType);
		}

		private Key itemKey;

		public Key ItemKey
		{
			get
			{
				return itemKey;
			}
		}

		public class Key
		{
			public Key(String tickerA, String tickerB, CorrelationPeriodType periodType)
			{
				if (String.IsNullOrWhiteSpace(tickerA))
				{
					throw new ArgumentException("tickerA");
				}

				if (String.IsNullOrWhiteSpace(tickerB))
				{
					throw new ArgumentException("tickerB");
				}

				if (tickerA.Equals(tickerB, StringComparison.CurrentCultureIgnoreCase))
				{
					throw new ArgumentException("tickers are equal");
				}

				toString = "[" + periodType.ToString() + "] [" + tickerA + "] [" + tickerB + "]";

				hashCode = ("[" + periodType.ToString() + "]").GetHashCode() ^ ("[" + tickerA + "]").GetHashCode() ^ ("[" + tickerB + "]").GetHashCode();

				this.tickerB = tickerB;

				this.tickerA = tickerA;

				this.periodType = periodType;
			}

			private String toString;

			public override String ToString()
			{
				return toString;
			}

			private CorrelationPeriodType periodType;

			private Int32 hashCode;

			private String tickerA;

			public CorrelationPeriodType PeriodType
			{
				get
				{
					return periodType;
				}
			}

			public String TickerA
			{
				get
				{
					return tickerA;
				}
			}

			private String tickerB;

			public String TickerB
			{
				get
				{
					return tickerB;
				}
			}

			public override Int32 GetHashCode()
			{
				return hashCode;
			}

			public override Boolean Equals(Object obj)
			{
				Key other = obj as Key;

				if (null == other)
				{
					return false;
				}

				return this.periodType == other.periodType &&
					(this.tickerA == other.tickerA && this.tickerB == other.tickerB ||
					this.tickerB == other.tickerA && this.tickerA == other.tickerB);
			}
		}

		private ElementCorrelation internalItem;

		public ElementCorrelation InternalItem
		{
			get
			{
				return internalItem;
			}
		}
	}
}
