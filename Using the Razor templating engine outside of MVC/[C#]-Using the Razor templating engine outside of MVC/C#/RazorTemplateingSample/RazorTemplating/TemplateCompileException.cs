using System;
using System.CodeDom.Compiler;

namespace RazorTemplateingSample.RazorTemplating
{
    public class TemplateCompileException : Exception
    {
        public TemplateCompileException(CompilerErrorCollection errors, string sourceCode)
        {
            Errors = errors;
            SourceCode = sourceCode;
        }

        public CompilerErrorCollection Errors { get; private set; }
        public string SourceCode { get; private set; }
    }
}
