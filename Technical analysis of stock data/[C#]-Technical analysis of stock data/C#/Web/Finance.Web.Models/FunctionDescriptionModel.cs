using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.Common.Base;

namespace Finance.Web.Models
{
	public class FunctionDescriptionModel
	{
		public String Information { get; set; }
		public String ImageThumbnail { get; set; }
		public FunctionType FunctionType { get; set; }
		public String FunctionTypeAsString { get; set; }
	}
}
