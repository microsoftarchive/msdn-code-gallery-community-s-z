using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorTemplateingSample.ModelsAndTemplates
{
    public class SampleModel
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public IList<string> Prop3 { get; set; }

    }
}
