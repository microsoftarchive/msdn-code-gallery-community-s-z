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
	#region Minvalue aggregation

	public class MinValue : IAggregation
	{
		private List<Decimal> elements = new List<Decimal>();

		private UInt32 length;

		private Int32 minIndex = -1;

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

		public MinValue(UInt32 length)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			this.length = length;
		}

		public UInt32 Length
		{
			get
			{
				return length;
			}
		}

		public void AddNext(Decimal value)
		{
			elements.Add(value);

			/////////////////////////////////////////////////
			// update index of minimum element

			if (minIndex >= 0)
			{
				if (elements[minIndex] >= value)
				{
					minIndex = elements.Count - 1;
				}
			}

			while (elements.Count > length)
			{
				elements.RemoveAt(0);
				if (minIndex >= 0)
				{
					minIndex--;
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
					throw new InvalidOperationException("min not ready yet");
				}

				if (minIndex >= 0)
				{
					return elements[minIndex];
				}
				else
				{
					Decimal tempMinValue = elements[0];
					Int32 tempMinIndex = 0;

					for (Int32 q = 1; q < elements.Count; q++)
					{
						if (elements[q] <= tempMinValue)
						{
							tempMinIndex = q;
							tempMinValue = elements[q];
						}
					}

					minIndex = tempMinIndex;

					return tempMinValue;
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

	#endregion Minvalue aggregation
}
