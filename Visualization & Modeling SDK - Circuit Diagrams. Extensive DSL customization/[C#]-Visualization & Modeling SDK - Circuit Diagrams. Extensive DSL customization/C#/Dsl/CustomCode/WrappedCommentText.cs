using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Microsoft.Example.Circuits
{
  partial class CommentBoxShape
  {
    // The class is double-derived so that we can override this method.
    // Called once for each class.
    protected override void InitializeDecorators(IList<ShapeField> shapeFields, IList<Decorator> decorators)
    {
      // Set up the decorators defined in the DSL Definition:
      base.InitializeDecorators(shapeFields, decorators);

      // Look up the text decorator, which is called "Comment".
      TextField commentField = (TextField)ShapeElement.FindShapeField(shapeFields, "Comment");

      // This sets the wrapping behavior, but we need a couple of other things too:
      commentField.DefaultMultipleLine = true;

      // Autosize is incompatible with multiple line:
      commentField.DefaultAutoSize = false;

      // Need to anchor the field sides to the parent box to get sensible size:
      commentField.AnchoringBehavior.Clear();
      commentField.AnchoringBehavior.SetLeftAnchor(AnchoringBehavior.Edge.Left, 0.01);
      commentField.AnchoringBehavior.SetRightAnchor(AnchoringBehavior.Edge.Right, 0.01);
      commentField.AnchoringBehavior.SetTopAnchor(AnchoringBehavior.Edge.Top, 0.01);
      commentField.AnchoringBehavior.SetBottomAnchor(AnchoringBehavior.Edge.Bottom, 0.01);

      // Note that this method is called just once per class.
      // commentField is a field definition, attached to the class, not instances.
    }
    
  }
}
