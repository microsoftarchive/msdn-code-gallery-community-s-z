using System;
using RazorTemplateingSample.RazorTemplating;
using Xunit;

namespace RazorTemplateingSample.Facts
{
    public class RazorTemplateGeneratorFacts
    {
        public class TestModel1
        {
            public string Param1 { get; set; }
        }

        public class TestModel2
        {
            public string Param1 { get; set; }
        }

        [Fact]
        public void Will_Compile_single_Template_String_registered()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.CompileTemplates();
            var result = testable.GenerateOutput(new TestModel1() { Param1 = "p1" });

            Assert.Equal("this is a test for p1", result);
        }

        [Fact]
        public void Will_Compile_multiple_Template_String_registered()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.RegisterTemplate<TestModel2>("this is another test for @Model.Param1");
            testable.CompileTemplates();
            var result1 = testable.GenerateOutput(new TestModel1() { Param1 = "p1" });
            var result2 = testable.GenerateOutput(new TestModel2() { Param1 = "p2" });

            Assert.Equal("this is a test for p1", result1);
            Assert.Equal("this is another test for p2", result2);
        }

        [Fact]
        public void Will_Compile_multiple_Template_String_with_same_model()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.RegisterTemplate<TestModel1>("namedTemplate", "this is another test for @Model.Param1");
            testable.CompileTemplates();
            var result1 = testable.GenerateOutput(new TestModel1() { Param1 = "p1" });
            var result2 = testable.GenerateOutput(new TestModel1() { Param1 = "p2" }, "namedTemplate");

            Assert.Equal("this is a test for p1", result1);
            Assert.Equal("this is another test for p2", result2);
        }

        [Fact]
        public void Will_overwrite_existing_Template()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.RegisterTemplate<TestModel1>("this is another test for @Model.Param1");
            testable.CompileTemplates();
            var result1 = testable.GenerateOutput(new TestModel1() { Param1 = "p1" });

            Assert.Equal("this is another test for p1", result1);
        }

        [Fact]
        public void Will_throw_InvalidOperationException_if_attempt_to_generate_without_compiling()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            var ex = Record.Exception(() => testable.GenerateOutput(new TestModel1() { Param1 = "p1" }));

            Assert.True(ex is InvalidOperationException);
        }

        [Fact]
        public void Will_throw_InvalidOperationException_if_attempt_to_register_another_template_after_compiling()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.CompileTemplates();
            var ex = Record.Exception(() => testable.RegisterTemplate<TestModel2>("this is another test for @Model.Param1"));

            Assert.True(ex is InvalidOperationException);
        }

        [Fact]
        public void Will_throw_NullArgumentException_if_attempt_to_register_template_with_null_name()
        {
            var testable = new RazorTemplateGenerator();

            var ex = Record.Exception(() => testable.RegisterTemplate<TestModel1>(null, "this is a test for @Model.Param1"));

            Assert.True(ex is ArgumentNullException);
            Assert.Equal("templateName", (ex as ArgumentNullException).ParamName);
        }

        [Fact]
        public void Will_throw_NullArgumentException_if_attempt_to_register_template_with_null_templatestring()
        {
            var testable = new RazorTemplateGenerator();

            var ex = Record.Exception(() => testable.RegisterTemplate<TestModel1>(null));

            Assert.True(ex is ArgumentNullException);
            Assert.Equal("templateString", (ex as ArgumentNullException).ParamName);
        }

        [Fact]
        public void Will_throw_NullArgumentException_if_attempt_to_compile_template_with_null_name()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.CompileTemplates();
            var ex = Record.Exception(() => testable.GenerateOutput(new TestModel1(), null));

            Assert.True(ex is ArgumentNullException);
            Assert.Equal("templateName", (ex as ArgumentNullException).ParamName);
        }

        [Fact]
        public void Will_throw_argument_out_of_range_exception_if_trying_to_generate_unregistered_template()
        {
            var testable = new RazorTemplateGenerator();

            testable.RegisterTemplate<TestModel1>("this is a test for @Model.Param1");
            testable.CompileTemplates();
            testable.GenerateOutput(new TestModel1() { Param1 = "p1" });
            var ex = Record.Exception(() => testable.GenerateOutput(new TestModel2() { Param1 = "p2" }));

            Assert.True(ex is ArgumentOutOfRangeException);
        }

    }
}