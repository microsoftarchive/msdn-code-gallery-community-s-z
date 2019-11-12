using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Razor;
using Microsoft.CSharp;

namespace RazorTemplateingSample.RazorTemplating
{
    public class Compiler
    {
        private static GeneratorResults GenerateCode(RazorTemplateEntry entry)
        {
            var host = new RazorEngineHost(new CSharpRazorCodeLanguage());
            host.DefaultBaseClass = string.Format("RazorTemplateingSample.RazorTemplating.RazorTemplateBase<{0}>", entry.ModelType.FullName);
            host.DefaultNamespace = "RazorTemplateingSample";
            host.DefaultClassName = entry.TemplateName + "Template";
            host.NamespaceImports.Add("System");
            GeneratorResults razorResult = null;
            using (TextReader reader = new StringReader(entry.TemplateString))
            {
                razorResult = new RazorTemplateEngine(host).GenerateCode(reader);
            }
            return razorResult;
        }

        private static CompilerParameters BuildCompilerParameters()
        {
            var @params = new CompilerParameters();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.ManifestModule.Name != "<In Memory Module>")
                    @params.ReferencedAssemblies.Add(assembly.Location);
            }
            @params.GenerateInMemory = true;
            @params.IncludeDebugInformation = false;
            @params.GenerateExecutable = false;
            @params.CompilerOptions = "/target:library /optimize";
            return @params;
        }

        public static Assembly Compile(IEnumerable<RazorTemplateEntry> entries)
        {
            var builder = new StringBuilder();
            var codeProvider = new CSharpCodeProvider();
            using (var writer = new StringWriter(builder))
            {
                foreach (var razorTemplateEntry in entries)
                {
                    var generatorResults = GenerateCode(razorTemplateEntry);
                    codeProvider.GenerateCodeFromCompileUnit(generatorResults.GeneratedCode, writer, new CodeGeneratorOptions());
                }
            }

            var result = codeProvider.CompileAssemblyFromSource(BuildCompilerParameters(), new[] { builder.ToString() });
            if (result.Errors != null && result.Errors.Count > 0)
                throw new TemplateCompileException(result.Errors, builder.ToString());

            return result.CompiledAssembly;
        }
    }
}