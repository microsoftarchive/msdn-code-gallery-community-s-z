using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.Web.Models.Graphs;
using Finance.Common.Base;

namespace Finance.Web.Models
{
	public class GraphDescriptionModel
	{
		public String Information { get; set; }
		public String ImageThumbnail { get; set; }
		public GraphType GraphType { get; set; }
		public String GraphTypeAsString { get; set; }
	}
}
