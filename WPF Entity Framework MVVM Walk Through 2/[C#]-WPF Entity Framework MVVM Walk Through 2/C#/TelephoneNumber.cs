using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace wpf_EntityFramework
{
    /// <summary>
    /// Although there is a standard Phone validation attribute, that isn't great for UK 
    /// orientated phone numbers
    /// </summary>
    public class TelephoneNumber : ValidationAttribute
    {
        public TelephoneNumber()
            : base("{0} is not a valid UK telephone number")
        {
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string input = value.ToString();
                if (input.StartsWith("+") || input.StartsWith("0"))
                {
                    string rest = input.Substring(1);
                    string restExSpaces = rest.Replace(" ", "");
                    if (restExSpaces.Length < 9 || restExSpaces.Length > 13)
                    {
                        return false;
                    }
                    return restExSpaces.All(Char.IsDigit);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
