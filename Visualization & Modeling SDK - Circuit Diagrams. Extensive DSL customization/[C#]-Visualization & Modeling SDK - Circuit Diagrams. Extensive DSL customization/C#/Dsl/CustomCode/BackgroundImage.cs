using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Microsoft.Example.Circuits
{
    // See http://msdn.microsoft.com/library/bb126272.aspx#background

    /*  Uncomment to see this feature.
    
    public partial class ComponentDiagram
    {
        // GeneratesDoubleDerived flag must be set in DSL Definition to override this.
        protected override void InitializeShapeFields(IList<ShapeField> shapeFields)
        {
            base.InitializeShapeFields(shapeFields);

            // Additional field. Image comes from DSL Project Resources.resx
            ImageField backgroundField = new ImageField("background",
              ImageHelper.GetImage(Properties.Resources.SampleBackgroundImage));

            // Make sure you can’t do anything with it.
            backgroundField.DefaultFocusable = false;
            backgroundField.DefaultSelectable = false;
            backgroundField.DefaultVisibility = true;

            shapeFields.Add(backgroundField);

            // Make it center in the diagram.      
            backgroundField.AnchoringBehavior.
               SetTopAnchor(AnchoringBehavior.Edge.Top, 0.01);
            backgroundField.AnchoringBehavior.
               SetLeftAnchor(AnchoringBehavior.Edge.Left, 0.01);
            backgroundField.AnchoringBehavior.
               SetRightAnchor(AnchoringBehavior.Edge.Right, 0.01);
            backgroundField.AnchoringBehavior.
               SetBottomAnchor(AnchoringBehavior.Edge.Bottom, 0.01);
        }
    }
    */
}