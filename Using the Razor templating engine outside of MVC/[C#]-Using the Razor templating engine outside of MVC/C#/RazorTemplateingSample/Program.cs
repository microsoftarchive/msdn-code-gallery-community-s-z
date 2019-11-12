using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RazorTemplateingSample.ModelsAndTemplates;
using RazorTemplateingSample.RazorTemplating;

namespace RazorTemplateingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IRazorTemplateGenerator generator = new RazorTemplateGenerator();
            generator.RegisterTemplate<SampleModel>(SampleTemplateStrings.Sample1);
            generator.CompileTemplates();
            var output =
                generator.GenerateOutput(new SampleModel()
                                            {Prop1 = "p1", Prop2 = "p2", Prop3 = new List<string> {"pe1", "pe2", "pe3"}});
            System.Console.Out.WriteLine(output);
            System.Console.In.ReadLine();
        }
    }
}
