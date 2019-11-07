using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.Common.Base;

namespace Finance.Web.Models.Graphs
{
	public class GraphDescription
	{
		public GraphType Type { get; set; }
		public string Name { get; set; }
	}

    public class StockDescription
    {
        public int Type { get; set; }
        public string Name { get; set; }
    }
}
