using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Validation
{
    public class FieldAttribute
        :Attribute,IValidation
    {
        public bool Valid(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
