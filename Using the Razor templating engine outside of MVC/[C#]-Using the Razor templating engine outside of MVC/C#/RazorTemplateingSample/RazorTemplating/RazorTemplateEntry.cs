using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorTemplateingSample.RazorTemplating
{
    public class RazorTemplateEntry
    {
        public Type ModelType { get; set; }
        public string TemplateString { get; set; }
        public string TemplateName { get; set; }
    }
}
