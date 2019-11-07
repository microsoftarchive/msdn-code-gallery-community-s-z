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
using System.Collections.Generic;

namespace Finance.Silverlight.Calculations
{
	public class AggregationInfo
	{
		static AggregationInfo()
		{
			List<AggregationInfo> temp = new List<AggregationInfo>();

			temp.Add(new AggregationInfo("Sma", typeof(Sma)));
			temp.Add(new AggregationInfo("Min", typeof(MinValue)));
			temp.Add(new AggregationInfo("Max", typeof(MaxValue)));
			temp.Add(new AggregationInfo("Ema", typeof(Ema)));
			temp.Add(new AggregationInfo("Bollinger band", typeof(BollingerBand)));
			temp.Add(new AggregationInfo("RWilliams",typeof(RWilliams)));
			temp.Add(new AggregationInfo("CCI", typeof(CommodityChannelIndex)));
			temp.Add(new AggregationInfo("Money flow", typeof(MoneyFlow)));
			temp.Add(new AggregationInfo("RSI", typeof(Rsi)));
			temp.Add(new AggregationInfo("Stochastic oscillator", typeof(StochasticOscillator)));

			DefinedAggregations = temp.ToArray();
		}

		public static AggregationInfo[] DefinedAggregations
		{
			get;
			private set;
		}

		public AggregationInfo(String name, Type targetType)
		{
			this.Name = name;
			this.TargetType = targetType;
		}

		public String Name
		{
			get;
			private set;
		}

		public Type TargetType
		{
			get;
			private set;
		}
	}
}
