using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Finance.Web.DataWrappers
{
	[DataContractAttribute]
	public class DailyDataWrapper
	{
		public DailyDataWrapper(
			DateTime day,
			Decimal openValue,
			Decimal closeValue,
			Decimal minValue,
			Decimal maxValue,
			Decimal volume)
		{
			this.Day = day;

			this.MaxValue = maxValue;

			this.MinValue = minValue;

			this.OpenValue = openValue;

			this.CloseValue = closeValue;

			this.Volume = volume;
		}

		public DailyDataWrapper()
		{
		}

		[DataMemberAttribute()]
		public DateTime Day
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public double DayAsDouble
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public Decimal OpenValue
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public Decimal CloseValue
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public Decimal MinValue
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public Decimal MaxValue
		{
			get;

			set;
		}

		[DataMemberAttribute()]
		public Decimal Volume
		{
			get;

			set;
		}
	}
}
