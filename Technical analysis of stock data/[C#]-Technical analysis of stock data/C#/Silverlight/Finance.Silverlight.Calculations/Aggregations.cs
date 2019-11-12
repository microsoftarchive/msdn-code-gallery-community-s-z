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
	#region RsiEma internal class

	class RsiEma : IAggregation, IOscillator
	{
		private Boolean isReady;

		private UInt32 length;

		private Decimal currentSum;

		private Decimal currentLength;

		private Decimal currentValue;

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

		public RsiEma(UInt32 length, Decimal lowMarker, Decimal highMarker)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

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

			isReady = false;

			currentLength = 0;

			currentSum = 0.0M;

			this.length = length;
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
				currentValue = (currentValue * (length - 1) + value) / length;
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
				return 0.0M;
			}
		}

		public Decimal HighValueBound
		{
			get
			{
				return 100.0M;
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
				return AggregationOutputType.Oscillator;
			}
		}

	}

	#endregion RsiEma internal class
	 

	#region Rsi internal class

	public class Rsi : IAggregation, IOscillator
	{
		private UInt32 length;

		private RsiEma rsiEmaUps;

		private RsiEma rsiEmaDowns;

		private const Int32 valuesCount = 1;

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

		public Rsi(UInt32 length, Decimal lowMarker, Decimal highMarker)
		{
			if (length < 1)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			this.length = length;

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

			rsiEmaUps = new RsiEma(length, lowMarker, highMarker);

			rsiEmaDowns = new RsiEma(length, lowMarker, highMarker);
		}

		public Boolean IsReady
		{
			get
			{
				return rsiEmaUps.IsReady && rsiEmaDowns.IsReady;
			}
		}

		public Decimal CurrentValue
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("rsi not ready yet");
				}

				if (rsiEmaUps.CurrentValue + rsiEmaDowns.CurrentValue != 0.0M)
				{
					Decimal res = 100.0M * rsiEmaUps.CurrentValue / (rsiEmaUps.CurrentValue + rsiEmaDowns.CurrentValue);

					if (res < 0.0M)
					{
						res = 0.0M;
					}

					if (res > 100.0M)
					{
						res = 100.0M;
					}

					return res;
				}

				return 0.5M;
			}
		}

		private Boolean firstValue = true;

		private Decimal previousValue = 0.0M;

		public UInt32 Length
		{
			get
			{
				return length;
			}
		}

		public Decimal LowValueBound
		{
			get
			{
				return 0.0M;
			}
		}

		public Decimal HighValueBound
		{
			get
			{
				return 100.0M;
			}
		}

		public void AddNext(Decimal value)
		{
			if (!firstValue)
			{
				Decimal diff = value - previousValue;

				Decimal upValue = 0.0M;
				Decimal downValue = 0.0M;

				if (diff >= 0)
				{
					upValue = diff;
				}
				else if (diff < 0)
				{
					downValue = -diff;
				}

				rsiEmaUps.AddNext(upValue);
				rsiEmaDowns.AddNext(downValue);
			}
			else
			{
				firstValue = false;
			}

			previousValue = value;
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

	}

	#endregion Rsi internal class

	#region Linear regression class

	public class LinearRegression
	{
		public LinearRegression(List<Decimal> valuesX, List<Decimal> valuesY)
		{
			if (null == valuesX || null == valuesY)
			{
				throw new ArgumentNullException("values list");
			}

			if (valuesX.Count < 3 || valuesX.Count != valuesY.Count)
			{
				throw new ArgumentOutOfRangeException("elements count");
			}

			this.valuesX = valuesX.ToArray();

			this.valuesY = valuesY.ToArray();

			CalculateRegLin();
		}

		public Decimal A
		{
			get
			{
				return parameterA;
			}
		}

		public Decimal B
		{
			get
			{
				return parameterB;
			}
		}

		public Decimal RhoA
		{
			get
			{
				return rhoParameterA;
			}
		}

		public Decimal RhoB
		{
			get
			{
				return rhoParameterB;
			}
		}

		public Decimal Correlation
		{
			get
			{
				return correlation;
			}
		}

		private static Decimal Sqrt(Decimal value)
		{
			return (Decimal)Math.Sqrt((Double)value);
		}

		private void CalculateRegLin()
		{
			Decimal sumX = 0.0M;

			Decimal sumX2 = 0.0M;

			Decimal sumY = 0.0M;

			Decimal sumXY = 0.0M;

			///////////////////////////////////////////////////////////////////
			// step 1

			for (Int32 q = 0; q < valuesX.Length; q++)
			{
				Decimal x = valuesX[q];

				Decimal y = valuesY[q];

				sumX += x;

				sumX2 += x * x;

				sumY += y;

				sumXY += x * y;
			}

			Decimal gamma = valuesX.Length * sumX2 - sumX * sumX;
				
			parameterA = (valuesX.Length * sumXY - sumX * sumY) / gamma;

			parameterB = (sumX2 * sumY - sumX * sumXY) / gamma;

			/////////////////////////////////////////////////////////////////////
			// step 2

			Decimal avgX = sumX / valuesX.Length;

			Decimal avgY = sumY / valuesY.Length;
				
			Decimal tempSumA = 0.0M;

			Decimal tempSumB1 = 0.0M;

			Decimal tempSumB2 = 0.0M;

			Decimal sumDiffF2 = 0.0M;

			for (Int32 q = 0; q < valuesX.Length; q++)
			{
				Decimal diffX = (valuesX[q] - avgX);

				Decimal diffY = (valuesY[q] - avgY);

				tempSumA += diffX * diffY;

				tempSumB1 += diffX * diffX;

				tempSumB2 += diffY * diffY;

				Decimal diffF = valuesY[q] - parameterA * valuesX[q] - parameterB;

				sumDiffF2 += diffF * diffF;
			}

			Decimal rhoY = Sqrt(sumDiffF2 / (valuesX.Length - 2));

			if (tempSumB1 * tempSumB2 != 0.0M)
			{
				correlation = tempSumA / Sqrt(tempSumB1 * tempSumB2);
			}
			else if (tempSumA != 0.0M)
			{
				correlation = Decimal.MaxValue;
			}
			else
			{
				correlation = 0.0M;
			}

			rhoParameterA = rhoY * Sqrt(valuesX.Length / gamma);

			rhoParameterB = rhoY * Sqrt(sumX2 / gamma);
		}

		private Decimal[] valuesX;

		private Decimal[] valuesY;

		private Decimal parameterA = 0.0M;

		private Decimal rhoParameterA = 0.0M;

		private Decimal rhoParameterB = 0.0M;

		private Decimal parameterB = 0.0M;

		private Decimal correlation = 0.0M;

	}

	#endregion Linear regression class

	#region Linear regression

	public class LinRegBasic : IAggregation
	{
		public UInt32 Length
		{
			get
			{
				return length;
			}
		}

		private UInt32 length;

		private List<Decimal> elements = new List<Decimal>();

		private List<Decimal> xes = new List<Decimal>();

		private LinearRegression internalWorker;

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

		public LinRegBasic(UInt32 length)
		{
			if (length < 3)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			this.length = length;

			for (UInt32 q = 0; q < length; q++)
			{
				xes.Add(q);
			}
		}

		public Decimal CurrentValue
		{
			get
			{
				if (!IsReady)
				{
					throw new InvalidOperationException("lin reg not ready yet");
				}

				if (null == internalWorker)
				{
					internalWorker = new LinearRegression(xes, elements);
				}

				return internalWorker.A;
			}
		}

		public Decimal RegR
		{
			get
			{
				if (null == internalWorker)
				{
					internalWorker = new LinearRegression(xes, elements);
				}

				return internalWorker.Correlation;
			}
		}

		public void AddNext(Decimal value)
		{
			internalWorker = null;

			elements.Add(value);

			while (elements.Count > length)
			{
				elements.RemoveAt(0);
			}
		}

		public bool IsReady
		{
			get
			{
				return elements.Count == length;
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
				return AggregationOutputType.NotClassified;
			}
		}
	}

	#endregion
}
