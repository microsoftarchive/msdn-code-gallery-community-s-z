using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.DataProvider
{
	public class SmallElementMovementDistribution
	{
		public class Key
		{
			public Key(String ticker, Int32 range)
			{
				if (String.IsNullOrWhiteSpace(ticker))
				{
					throw new ArgumentException("ticker");
				}

				toString = "[" + range.ToString() + "] [" + ticker + "]";

				hashCode = ("[" + range.ToString() + "]").GetHashCode() ^ ("[" + ticker + "]").GetHashCode();

				this.ticker = ticker;

				this.range = range;
			}

			private String toString;

			public override String ToString()
			{
				return toString;
			}

			private Int32 range;

			private Int32 hashCode;

			private String ticker;

			public Int32 Range
			{
				get
				{
					return range;
				}
			}

			public String Ticker
			{
				get
				{
					return ticker;
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

				return this.range == other.range && (String.Compare(this.ticker, other.ticker, true) == 0);
			}
		}

		public SmallElementMovementDistribution()
		{
		}


		public SmallElementMovementDistribution(String ticker, Int32 rangeId, DateTime upd)
		{
			this.ticker = ticker;

			this.rangeId = rangeId;

			this.upd = upd;

			this.key = new Key(ticker, rangeId);
		}

		private Key key;

		public Key ItemKey
		{
			get
			{
				return key;
			}
		}

		private String ticker = String.Empty;

		public String Ticker
		{
			get
			{
				return ticker;
			}

			set
			{
				ticker = value;

				this.key = new Key(ticker, rangeId);
			}
		}

		private Int32 rangeId = 0;

		public Int32 RangeId
		{
			get
			{
				return rangeId;
			}

			set
			{
				rangeId = value;

				this.key = new Key(ticker, rangeId);
			}
		}

		private DateTime upd;

		public DateTime Upd
		{
			get
			{
				return upd;
			}

			set
			{
				upd = value;
			}
		}
	}
}
