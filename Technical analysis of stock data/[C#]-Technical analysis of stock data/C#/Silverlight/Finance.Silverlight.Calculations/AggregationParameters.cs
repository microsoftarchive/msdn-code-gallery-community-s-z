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

namespace Finance.Silverlight.Calculations
{
	public class AggregationParameters
	{
		public AggregationParameters(AggregationInfo ai, Int32 length)
		{
			this.AggregationInfo = ai;

			this.Length = length;

			this.ItemInfo = ai.Name + " " + length;
		}

		public String ItemInfo
		{
			get;

			private set;
		}

		public AggregationInfo AggregationInfo
		{
			get;

			private set;
		}

		public Int32 Length
		{
			get;

			private set;
		}
	}
}
