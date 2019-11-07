using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Finance.Web.Models.Infrastracture
{
	public class ModelClientValidationRangeDateRule : ModelClientValidationRule
	{
		public ModelClientValidationRangeDateRule(string errorMessage, DateTime minValue, DateTime maxValue)
		{
			ErrorMessage = errorMessage;
			ValidationType = "rangedate";

			ValidationParameters["min"] = minValue.ToString("yyyy/MM/dd");
			ValidationParameters["max"] = maxValue.ToString("yyyy/MM/dd");
		}
	}
}
