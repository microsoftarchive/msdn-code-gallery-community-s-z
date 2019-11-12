using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UserManagement.Utilities.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("td", Attributes = "claim-type")]
    public class ClaimTypeTagHelper : TagHelper
    {
        public string ClaimType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            bool foundType = false;

            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.GetValue(null).ToString() == ClaimType)
                {
                    foundType = true;
                    output.Content.SetContent(field.Name);
                }
            }

            if (!foundType)
            {
                output.Content.SetContent(ClaimType.Split('/', '.').Last());
            }
        }
    }
}
