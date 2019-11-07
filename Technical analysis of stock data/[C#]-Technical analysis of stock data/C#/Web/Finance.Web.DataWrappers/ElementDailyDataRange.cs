using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Finance.Web.DataWrappers
{
	[DataContractAttribute]
	public class ElementDailyDataRange
	{
		public ElementDailyDataRange(
			String ticker,
			DailyDataWrapper[] dailyData,
			DateTime dateFrom,
			DateTime dateTo)
		{
			this.Ticker = ticker;

			this.DateFrom = dateFrom;

			this.DateTo = dateTo;

			this.DailyData = dailyData;
		}

		[DataMemberAttribute()]
		public DailyDataWrapper[] DailyData
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public DateTime DateTo
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public DateTime DateFrom
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public String Ticker
		{
			get;

			set;
		}
	}
}
