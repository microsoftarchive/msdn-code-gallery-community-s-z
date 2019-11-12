using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Finance.Web.Models.Infrastracture;
using System.Security.AccessControl;
using Finance.Web.Models.Graphs;
using System.Web.Mvc;
using Finance.Web.DataWrappers;
using Finance.DataProvider;
using Finance.Common.Base;

namespace Finance.Web.Models
{
	public class GraphModel
	{
		[Required(ErrorMessageResourceName="BeginDateError", ErrorMessageResourceType=typeof(Resources.Resources))]
		[DataType(DataType.Date)]
		[DateRange(Min = "2001/01/01", Max = "2013/12/31")]
		[Display(Name = "BeginDateLabel", ResourceType = typeof(Resources.Resources))] 
		public DateTime BeginDate{ get; set; }

		[Required(ErrorMessageResourceName="EndDateError", ErrorMessageResourceType=typeof(Resources.Resources))]
		[DataType(DataType.Date)]
		[DateRange(Min = "2001/01/01", Max = "2013/12/31")]
		[Display(Name = "EndDateLabel", ResourceType = typeof(Resources.Resources))] 
		public DateTime EndDate { get; set; }

		[Required]
		[Display(Name = "StockNameLabel", ResourceType=typeof(Resources.Resources))] 
		public string StockNameSelected { get; set; }

		[Required]
		[Display(Name = "GraphTypeLabel", ResourceType = typeof(Resources.Resources))]
		public string GraphTypeSelected { get; set; }

		private SelectList _graphsList;
		public SelectList GraphsList
		{
			get
			{
				return _graphsList;
			}
			set
			{
				_graphsList = value;
			}
		}

		private SelectList _stocksList;
		public SelectList StocksList
		{
			get
			{
				return _stocksList;
			}
			set
			{
				_stocksList = value;
			}
		}

		public GraphModel()
		{
			List<GraphDescription> graphsList = new List<GraphDescription>()
			{
				new GraphDescription{ Type = GraphType.Bars, Name = Resources.Resources.GraphTypeBarsLabel},
				new GraphDescription{ Type = GraphType.Candles, Name = Resources.Resources.GraphTypeCandlestickLabel},
				new GraphDescription{ Type = GraphType.Linear, Name = Resources.Resources.GraphTypeLinearLabel},
			};

			GraphTypeSelected = GraphType.Bars.ToString();
			_graphsList = new SelectList(graphsList, "Type", "Name", GraphType.Candles);

			////////////////////////////////////////////////////////////////////////////////////
			/// prepare list with all loaded items
			/// 

			List<StockDescription> stocksList = new List<StockDescription>();
			foreach (String stockName in StocksListSingleton.Instance.StockList)
			{
				stocksList.Add(new StockDescription() { Type = 0, Name = stockName });
			}

			StockNameSelected = "WIG20";

			_stocksList = new SelectList(stocksList, "Name", "Name", 0);            
		}
	}
}
