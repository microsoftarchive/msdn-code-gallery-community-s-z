using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeKeySupport.Tests.PeopleService
{
    public partial class Container
    {
        public Container()
            : this(new Uri("http://localhost.fiddler:33051"))
        { 
        }
    }
}
