using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wpf_EntityFramework
{
    class MustEqual : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }
        public ValidationContext TheObject { get; set; }
        public MustEqual(string propertyName)
            : base("Must match {0}")
        {
            OtherPropertyName = propertyName;
        }
        protected  override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            TheObject = validationContext;
            bool validate = IsValid(value);
            if (validate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
            }
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                Object obj = TheObject.ObjectInstance;
                Type objType = obj.GetType();
                PropertyInfo propInfo = objType.GetProperty(OtherPropertyName);
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
                return Object.Equals(value, propInfo.GetValue(obj, null));
            }
            return true;
        }
    }
}

