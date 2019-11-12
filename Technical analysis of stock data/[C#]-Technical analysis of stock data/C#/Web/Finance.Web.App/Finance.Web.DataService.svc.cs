using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Finance.DataProvider;
using Finance.Web.DataWrappers;
using Finance.Common.Base;

namespace Finance.Web.App
{
	[ServiceContract(Namespace = "")]
	[SilverlightFaultBehavior]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class FinanceDataService
	{
		[OperationContract]
		public ElementWrapper[] SelectItems(ElementTypeDefs itemsTypes)
		{
			return (new DataProviderProxy()).SelectElements(itemsTypes);
		}

		[OperationContract]
		public ElementDailyDataRange SelectDailyData(String ticker)
		{
			return (new DataProviderProxy()).SelectDailyData(ticker);
		}
	}
}
