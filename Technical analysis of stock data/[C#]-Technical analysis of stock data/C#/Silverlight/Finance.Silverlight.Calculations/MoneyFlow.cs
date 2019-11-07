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
using System.Collections.Generic;

namespace Finance.Silverlight.Calculations
{
	public class MoneyFlow : IAggregation, IExtendedAggregation, IOscillator
	{
		private UInt32 length;

		private Decimal highMarker;

		private Decimal lowMarker;

		public MoneyFlow(UInt32 length, Decimal lowMarker, Decimal highMarker)
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
		}

		private Decimal positiveMoneyFlow = 0.0M;

		private Decimal negativeMoneyFlow = 0.0M;

		private List<Decimal> moneyFlowItems = new List<Decimal>();

		private Nullable<Decimal> previousTypicalPrice = null;

		public void AddNext(Decimal openValue, Decimal minValue, Decimal maxValue, Decimal closeValue, Int64 volume)
		{
			Decimal typicalPrice = (minValue + maxValue + closeValue) / 3;

			Decimal moneyFlow = Math.Abs(typicalPrice * volume);

			if (previousTypicalPrice.HasValue)
			{
				if (typicalPrice < previousTypicalPrice.Value)
				{
					moneyFlow = -moneyFlow;
				}

				previousTypicalPrice = typicalPrice;
			}
			else
			{
				previousTypicalPrice = typicalPrice;

				/////////////////////////////////////////////////////////////////////
				/// no previous typical price - can not calculate money flow
				/// 

				return;
			}

			moneyFlowItems.Add(moneyFlow);

			if (moneyFlow >= 0.0M)
			{
				positiveMoneyFlow += moneyFlow;
			}
			else
			{
				negativeMoneyFlow -= moneyFlow; //// moneyFlow is negative so subtract it to get positive value
			}

			while (moneyFlowItems.Count > length)
			{
				Decimal moneyFlowItem = moneyFlowItems[0];

				moneyFlowItems.RemoveAt(0);

				if (moneyFlowItem >= 0.0M)
				{
					positiveMoneyFlow -= moneyFlowItem;
				}
				else
				{
					negativeMoneyFlow += moneyFlowItem;
				}
			}
		}

		public Decimal CurrentValue
		{
			get 
			{
				if (IsReady)
				{
					Decimal sum = negativeMoneyFlow + positiveMoneyFlow;

					if (sum >= 0.0M)
					{
						Decimal res = 100.0M * positiveMoneyFlow / sum;

						if (res < LowValueBound)
						{
							res = LowValueBound;
						}

						if (res > HighValueBound)
						{
							res = HighValueBound;
						}

						return res;
					}
					else
					{
						return 0.0M;
					}
				}
				else
				{
					throw new InvalidOperationException("MF is not ready yet");
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
				return moneyFlowItems.Count >= length;
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

		public Decimal LowValueBound
		{
			get 
			{
				return 0.0M;
			}
		}

		public Decimal LowMarker
		{
			get 
			{
				return lowMarker;
			}
		}

		public Decimal HighValueBound
		{
			get 
			{
				return 100.0M;
			}
		}

		public Decimal HighMarker
		{
			get 
			{
				return highMarker;
			}
		}
	}
}


