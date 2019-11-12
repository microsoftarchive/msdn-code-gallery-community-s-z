using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finance.DataProvider;
using System.Runtime.Serialization;
using Finance.Common.Base;

namespace Finance.Web.DataWrappers
{
	[DataContractAttribute]
	public class ElementWrapper
	{
		public ElementWrapper(
			String ticker, 
			ElementTypeDefs elementType,
			String name)
		{
			this.Ticker = ticker;

			this.ElementType = elementType;

			this.Name = name;
		}

		public ElementWrapper()
		{

		}

		[DataMemberAttribute()]
		public String Name
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

		[DataMemberAttribute()]
		public ElementTypeDefs ElementType
		{
			get;

			set;
		}
	}
}
