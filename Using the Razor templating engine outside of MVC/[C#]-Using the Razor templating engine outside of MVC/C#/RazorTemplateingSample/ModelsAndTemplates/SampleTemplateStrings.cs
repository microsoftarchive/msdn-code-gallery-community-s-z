using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RazorTemplateingSample.RazorTemplating;

namespace RazorTemplateingSample.ModelsAndTemplates
{
    public static class SampleTemplateStrings
    {
        public static string Sample1 = @"
<html>
    I hope that you enjoy the rendering of @Model.Prop1 just as much as the rendering of @Model.Prop2
    For your pleasure I am including these extra parameter strings:
    @foreach(var p in @Model.Prop3) {
        <span>I present this param3 value: @p</span>
    }
</html>
"; 
    }
}
