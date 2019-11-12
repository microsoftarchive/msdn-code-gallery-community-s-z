using FluentValidation;
using SQLiteSample.Models;

namespace SQLiteSample.Validator
{
    public class ContactValidator : AbstractValidator<ContactInfo>  
    {  
        public ContactValidator()  
        {  
            RuleFor(c => c.Name).Must(n=>ValidateStringEmpty(n)).WithMessage("Contact name should not be empty.");
            RuleFor(c => c.MobileNumber).NotNull().Length(10);
            RuleFor(c => c.Age).Must(a => ValidateStringEmpty(a)).WithMessage("Contact Age should not be empty.");
            RuleFor(c => c.Gender).Must(g => ValidateStringEmpty(g)).WithMessage("Contact Gender should not be empty.");
            RuleFor(c => c.DOB).Must(d => ValidateStringEmpty(d.ToString())).WithMessage("Contact DOB should not be empty.");
            RuleFor(c => c.Address).Must(a => ValidateStringEmpty(a)).WithMessage("Contact Adress should not be empty.");
        }  

        bool ValidateStringEmpty(string stringValue){
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    } 
}
