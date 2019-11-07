using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorTemplateingSample.RazorTemplating
{
    public interface IRazorTemplateGenerator
    {
        void RegisterTemplate<TModel>(string templateString);
        void RegisterTemplate<TModel>(string templateName, string templateString);
        void CompileTemplates();
        string GenerateOutput<TModel>(TModel model);
        string GenerateOutput<TModel>(TModel model, string templateName);
    }
}
