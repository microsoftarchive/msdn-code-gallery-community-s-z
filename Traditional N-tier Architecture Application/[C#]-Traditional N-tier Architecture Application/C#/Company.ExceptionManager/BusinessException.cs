using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.ExceptionManager
{
    public class BusinessException
        : Exception, IException
    {
        public string ExceptionMessage(string msj)
        {
            throw new NotImplementedException();
        }
    }
}
