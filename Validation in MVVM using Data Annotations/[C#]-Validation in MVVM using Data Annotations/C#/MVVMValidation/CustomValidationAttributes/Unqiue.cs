using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMValidation.ViewModel;

namespace MVVMValidation.CustomValidationAttributes
{
    public class Unqiue : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var contains = CustomerViewModel.SharedViewModel().Customers.Select(x => x.Id).Contains(int.Parse(value.ToString()));
           
           if (contains)
               return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
           else
               return ValidationResult.Success;
        }
    }
}
