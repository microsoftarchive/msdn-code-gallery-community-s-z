using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.DataProvider;
using Finance.Common.Base;

namespace Finance.Web.DataWrappers
{
	public static class WrapperUtilities
	{
		public static ElementWrapper[] Convert(Element[] input)
		{
			return Array.ConvertAll<Element, ElementWrapper>(input, x => new ElementWrapper(x.Symbol, (ElementTypeDefs)x.Type, x.Name));
		}

		public static DailyDataWrapper[] Convert(DailyData[] input)
		{
			return Array.ConvertAll<DailyData, DailyDataWrapper>(input, x => new DailyDataWrapper(x.Day, x.OpenValue.Value, x.CloseValue.Value, x.MinValue.Value, x.MaxValue.Value, x.Volume));
		}
	}
}
