using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

public enum Trait
{
    Unit,
    Integration,
    MailConversion
}

public class TestTraitsAttribute : TestCategoryBaseAttribute
{
    private Trait[] traits;

    public TestTraitsAttribute(params Trait[] traits)
    {
        this.traits = traits;
    }

    public override IList<string> TestCategories
    {
        get
        {
            var traitStrings = new List<string>();

            foreach (var trait in this.traits)
            {
                string value = Enum.GetName(typeof(Trait), trait);
                traitStrings.Add(value);
            }

            return traitStrings;
        }
    }
}

