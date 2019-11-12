// -----------------------------------------------------------------------
// <copyright file="AuthenticationException.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Company.ExceptionManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AuthenticationException
        : Exception,IException
    {

        public string ExceptionMessage(string msj)
        {
            throw new NotImplementedException();
        }
    }
}
