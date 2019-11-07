using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Microsoft.Example.Circuits
{
  partial class WireConnector
  {
    /// <summary>
    /// Called whenever a registered property changes in the associated model element.
    /// 
    /// http://msdn.microsoft.com/library/ff935836.aspx
    /// </summary>
    /// <param name="e"></param>
    protected override void OnAssociatedPropertyChanged(VisualStudio.Modeling.Diagrams.PropertyChangedEventArgs e)
    {
      base.OnAssociatedPropertyChanged(e);
      // Can be called for any property change. Therefore,
      // Verify that this is the property we're interested in:
      if ("IsDirected".Equals(e.PropertyName))
      {
        if (e.NewValue.Equals(true))
        {
          this.DecoratorTo = LinkDecorator.DecoratorEmptyArrow;
        }
        else
        {
          this.DecoratorTo = null; // No arrowhead.
        }
      }
    }

    /// <summary>
    /// Register the connection of the property in the MEL to this diagram element.
    /// AssociateValue means that OnAssociatedPropertyChanged will be called whenever
    /// the value of the property changes.
    /// 
    /// http://msdn.microsoft.com/library/ff935836.aspx
    /// </summary>
    /// <param name="classStyleSet"></param>
    protected override void InitializeResources(StyleSet classStyleSet)
    {
      base.InitializeResources(classStyleSet);
      AssociateValueWith(this.Store, Wire.IsDirectedDomainPropertyId);
    }
  }
}
