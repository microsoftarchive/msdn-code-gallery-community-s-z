using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Validation;

namespace Microsoft.Example.Circuits
{
  /// <summary>
  /// Validation methods for Component class.
  /// To make this work, Validation is globally enabled under Editor in DSL Explorer, in DSL Definition.
  /// ValidationState attribute is also required to enable validation in specific classes.
  /// 
  /// http://msdn.microsoft.com/library/bb126413.aspx
  /// </summary>
  [ValidationState(VisualStudio.Modeling.Validation.ValidationState.Enabled)]
  partial class Component
  {
    
    /// <summary>
    /// Each validation method is called on every instance of the type to which it applies.
    /// Validation methods are flagged by the ValidationMethod attribute.
    /// </summary>
    /// <param name="context"></param>
    [ValidationMethod(ValidationCategories.Menu | ValidationCategories.Save | ValidationCategories.Open)]
    private void NoMissingConnections(ValidationContext context)
    {
      foreach (ComponentTerminal terminal in this.ComponentTerminals)
      {
        if (terminal.SourceConnections.Count == 0 && terminal.TargetConnections.Count == 0)
        {
          context.LogError("Missing connections on " + this.Name, "MissingWires", this);
          break; // One error per component is enough.
        }
      }
    }
  }
}
