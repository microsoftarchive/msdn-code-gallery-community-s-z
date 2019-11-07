using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_EntityFramework
{
    public class AnError
    {
        public string Text { get; set; }
        public ErrorSource Source { get; set; }

    }
    public enum ErrorSource
    {
        Conversion,
        Validation
    }
}
