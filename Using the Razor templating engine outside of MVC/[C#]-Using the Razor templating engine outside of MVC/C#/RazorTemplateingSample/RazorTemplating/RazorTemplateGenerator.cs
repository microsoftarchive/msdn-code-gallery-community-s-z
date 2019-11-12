using System;
using System.Collections.Generic;
using System.Reflection;

namespace RazorTemplateingSample.RazorTemplating
{
    public class RazorTemplateGenerator : IRazorTemplateGenerator
    {
        private readonly Dictionary<string, RazorTemplateEntry> templateItems = new Dictionary<string, RazorTemplateEntry>();

        private Assembly compiledTemplateAssembly;

        public void RegisterTemplate<TModel>(string templateString)
        {
            RegisterTemplate<TModel>(GetTemplateNameFromModel(typeof(TModel)), templateString);
        }

        public void RegisterTemplate<TModel>(string templateName, string templateString)
        {
            if (compiledTemplateAssembly != null)
                throw new InvalidOperationException("May not register new templates after compiling.");
            if (templateName == null)
                throw new ArgumentNullException("templateName");
            if (templateString == null)
                throw new ArgumentNullException("templateString");

            templateItems[TranslateKey(typeof(TModel), templateName)] = new RazorTemplateEntry() { ModelType = typeof(TModel), TemplateString = templateString, TemplateName = "Rzr" + Guid.NewGuid().ToString("N") };
        }

        public void CompileTemplates()
        {
            compiledTemplateAssembly = Compiler.Compile(templateItems.Values);
        }

        public string GenerateOutput<TModel>(TModel model)
        {
            return GenerateOutput(model, GetTemplateNameFromModel(typeof(TModel)));
        }

        public string GenerateOutput<TModel>(TModel model, string templateName)
        {
            if (compiledTemplateAssembly == null)
                throw new InvalidOperationException("Templates have not been compiled.");
            if (templateName == null)
                throw new ArgumentNullException("templateName");

            RazorTemplateEntry entry = null;
            try
            {
                entry = templateItems[TranslateKey(typeof(TModel), templateName)];
            }
            catch (KeyNotFoundException)
            {

                throw new ArgumentOutOfRangeException("No template has been registered under this model or name.");
            }
            var template = (RazorTemplateBase<TModel>)compiledTemplateAssembly.CreateInstance("RazorTemplateingSample." + entry.TemplateName + "Template");
            template.Model = model;
            template.Execute();
            var output = template.Buffer.ToString();
            template.Buffer.Clear();
            return output;
        }

        private string GetTemplateNameFromModel(Type model)
        {
            return string.Format("RZR::{0}", model.Name);
        }

        private string TranslateKey(Type model, string templateName)
        {
            return string.Format("{0}::{1}", model.Name, templateName);
        }

    }
}