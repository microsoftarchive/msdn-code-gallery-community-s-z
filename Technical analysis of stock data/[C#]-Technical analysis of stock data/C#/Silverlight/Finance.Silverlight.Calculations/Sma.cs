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
	#region Sma internal class

	public class Sma : IAggregation
	{
		private UInt32 length;

		private Decimal currentSum;

		private List<Decimal> elements = new List<Decimal>();

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

		public Decimal AbsDev
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("sm not ready yet");
				}

				Decimal avgValue = CurrentValue;

				Decimal tempSum = 0.0M;

				for (Int32 q = 0; q < elements.Count; q++)
				{
					Decimal tempValue = Math.Abs(elements[q] - avgValue);

					tempSum += tempValue;
				}

				return tempSum / elements.Count;
			}
		}

		public Decimal Dev
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("sm not ready yet");
				}

				Decimal avgValue = CurrentValue;

				Decimal tempSum = 0.0M;

				for (Int32 q = 0; q < elements.Count; q++)
				{
					Decimal tempValue = (elements[q] - avgValue);

					tempSum += tempValue * tempValue;
				}

				return (Decimal)Math.Sqrt((Double)(tempSum / elements.Count));
			}
		}

		public Sma(UInt32 length)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			this.length = length;
		}

		public UInt32 CurrentLength
		{
			get
			{
				return (UInt32)elements.Count;
			}
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
				return elements.Count == length;
			}
		}

		public void AddNext(Decimal value)
		{
			elements.Add(value);

			currentSum += value;

			while (elements.Count > length)
			{
				currentSum -= elements[0];
				elements.RemoveAt(0);
			}
		}

		public Decimal CurrentValue
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("sma not ready yet");
				}

				return currentSum / length;
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

	#endregion Sma internal class
}
