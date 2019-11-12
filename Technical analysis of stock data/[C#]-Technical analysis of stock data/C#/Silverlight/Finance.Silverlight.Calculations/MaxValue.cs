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
	#region MaxValue aggregation

	public class MaxValue : IAggregation
	{
		private List<Decimal> elements = new List<Decimal>();

		private UInt32 length;

		private Int32 maxIndex = -1;

		public UInt32 Length
		{
			get
			{
				return length;
			}
		}

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

		public MaxValue(UInt32 length)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			this.length = length;
		}

		public void AddNext(Decimal value)
		{
			elements.Add(value);

			if (maxIndex >= 0)
			{
				if (elements[maxIndex] <= value)
				{
					maxIndex = elements.Count - 1;
				}
			}

			while (elements.Count > length)
			{
				elements.RemoveAt(0);
				if (maxIndex >= 0)
				{
					maxIndex--;
				}
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

		public Decimal CurrentValue
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("max not ready yet");
				}

				if (maxIndex >= 0)
				{
					return elements[maxIndex];
				}
				else
				{
					Decimal tempMaxValue = elements[0];
					Int32 tempMaxIndex = 0;

					for (Int32 q = 1; q < elements.Count; q++)
					{
						if (elements[q] >= tempMaxValue)
						{
							tempMaxIndex = q;
							tempMaxValue = elements[q];
						}
					}

					maxIndex = tempMaxIndex;

					return tempMaxValue;
				}
			}
		}

		public Boolean IsReady
		{
			get
			{
				return elements.Count == length;
			}
		}
	}

	#endregion MaxValue aggregation
}
