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

namespace Finance.Silverlight.Graphs.Models
{
	public class ElementDailyDataRangeWrapper
	{
		public ElementDailyDataRangeWrapper(
			FinanceDataService.ElementDailyDataRange elementDailyDataRange,
			Dictionary<Int32, DateTime> daysMap,
			Dictionary<DateTime, Int32> reversedDaysMap)
		{
			ElementDailyDataRange = elementDailyDataRange;

			DaysMap = daysMap;

			ReveresedDaysMap = reversedDaysMap;
		}

		public FinanceDataService.ElementDailyDataRange ElementDailyDataRange
		{
			get;

			set;
		}

		public Dictionary<Int32, DateTime> DaysMap
		{
			get;

			set;
		}

		public Dictionary<DateTime, Int32> ReveresedDaysMap
		{
			get;

			set;
		}

	}
}
