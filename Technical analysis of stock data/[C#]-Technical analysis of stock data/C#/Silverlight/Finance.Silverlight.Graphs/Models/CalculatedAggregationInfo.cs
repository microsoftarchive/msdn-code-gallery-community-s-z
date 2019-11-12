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

namespace Finance.Silverlight.Graphs.Models
{
	public class CalculatedAggregationsContainer
	{
		public CalculatedAggregationsContainer()
		{
			Aggregations = new Dictionary<String, CalculatedAggregationInfo>();
		}

		public String Ticker
		{
			get;

			set;
		}

		public Dictionary<String, CalculatedAggregationInfo> Aggregations
		{
			get;

			private set;
		}
	}

	public class SingleValueDayPair
	{
		public SingleValueDayPair(DateTime dt, Decimal value, Double dayAsDouble)
		{
			this.Day = dt;

			this.Value = value;

			this.DayAsDouble = dayAsDouble;
		}

		public Double DayAsDouble
		{
			get;

			private set;
		}

		public DateTime Day
		{
			get;

			private set;
		}

		public Decimal Value
		{
			get;

			private set;
		}
	}

	public class CalculatedAggregationInfo
	{
		public CalculatedAggregationInfo()
		{
			PreparedData = new List<Dictionary<DateTime, Decimal>>();
		}

		public String Name
		{
			get;

			set;
		}

		public IAggregation Aggregation
		{
			get;

			set;
		}

		public Color AggregationColor
		{
			get;

			set;
		}

		public Boolean Enabled
		{
			get;

			set;
		}

		public List<Dictionary<DateTime, Decimal>> PreparedData
		{
			get;

			set;
		}

		public List<List<SingleValueDayPair>> PreparedDataForGraph
		{
			get;

			set;
		}

	}
}
