// -----------------------------------------------------------------------
// <copyright file="JsonAttribute.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class JsonAttribute
        : Attribute,IValidation
    {
        public bool Valid(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
