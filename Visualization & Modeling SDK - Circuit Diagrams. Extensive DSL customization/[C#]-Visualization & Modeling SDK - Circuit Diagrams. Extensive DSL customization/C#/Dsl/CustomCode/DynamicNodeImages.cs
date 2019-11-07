using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Microsoft.Example.Circuits
{

  #region image rotation



  partial class ComponentShape
  {
    /// <summary>
    /// Double-click => rotate by 90 degrees.
    /// 
    /// http://msdn.microsoft.com/library/bb126591.aspx
    /// </summary>
    /// <param name="e"></param>
    public override void OnDoubleClick(DiagramPointEventArgs e)
    {
      base.OnDoubleClick(e);
      this.Rotate90();
      e.Handled = true; // Don't pass to parent.
    }

    /// <summary>
    /// Called when the user double-clicks or selects Rotate.
    /// </summary>
    public virtual void Rotate90()
    {
      using (Transaction t = this.Store.TransactionManager.BeginTransaction("rotate"))
      {
        // Notice that rotate is a domain property of the shape, not the model element:
        rotate = (short)((rotate + 1) % 4);

        // Ensure that the image, if there is one, is repainted according to new rotate value:
        this.Invalidate(); 

        // Swap height and width, rotating about center.
        // The main idea is to accommodate the rotated image.
        // But also we move the sides so as to invoke the bounds rules of the 
        // terminal port shapes. For this reason, if the box is square, we 
        // rotate slightly off center to ensure the sides are always moved a bit:
        double scaledCenter = AbsoluteBounds.Height == AbsoluteBounds.Width ? 0.51 : 0.5;
        AbsoluteBounds = new RectangleD
          (AbsoluteBounds.Center.X - AbsoluteBounds.Height * scaledCenter,
          AbsoluteBounds.Center.Y - AbsoluteBounds.Width * scaledCenter,
          AbsoluteBounds.Height,
          AbsoluteBounds.Width);
      
        t.Commit();
      }
    }

    /// <summary>
    /// The appearance of the shape is set by an image decorator.
    /// Replace the ImageFields with RotatingImage fields.
    /// Each RotatingImage uses the same basic image as the ImageField that it replaces,
    /// but it can rotate the image.
    /// This method replaces all the image fields associated with this component.
    /// (The visibility of each image field is controlled by the decorator that contains it.
    /// For example for a Transistor, there are two basic images, only one of which is 
    /// visible at a time. The decorators are set up after this list of shape fields.)
    /// 
    /// http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.diagrams.imagefield.aspx
    /// </summary>
    /// <param name="shapeFields">List containing the fields.</param>
    protected void ReplaceImageFieldsWithRotatingImageFields(IList<ShapeField> shapeFields)
    {
      ImageField[] oldFields = shapeFields.OfType<ImageField>().ToArray();
      foreach (ImageField imageField in oldFields)
      {
        RotatingImageField rotatingImageField = new RotatingImageField(imageField.Name);
        rotatingImageField.DefaultImage = imageField.DefaultImage;
        shapeFields.Remove(imageField);
        shapeFields.Add(rotatingImageField);
      }
    }

    /// <summary>
    /// Encoding of the rotation and flip.
    /// 0..3 --> rotations 90 deg counterclockwise;
    /// + 4 = flip about Y axis before rotating
    /// </summary>
    public int RotateFlip
    {
      get
      {
        // understands rotate written by user as 90/180/270 or 1/2/3
        return (rotate / 90 + rotate % 90) % 4 + (flip ? 4 : 0);
      }
    }

    public void Flip()
    {
      flip = !flip;
      // Repaint image according to flip state:
      Invalidate();
      // Induce rerouting in connectors:
      RectangleD bounds = AbsoluteBounds; // Always gets a new Rectangle.
      bounds.Offset(flip ? 0.01 : -0.01, 0);
      AbsoluteBounds = bounds;
    }
    /// <summary>
    /// Multiply X and Y by width and height of shape.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    protected PointD ScalePoint(double x, double y)
    {
      return new PointD(x * AbsoluteBounds.Width, y * AbsoluteBounds.Height);
    }
  }

  /// <summary>
  /// A resistor is just a rectangle - it doesn't have an image.
  /// Rotation is done by swapping the height and width.
  /// </summary>
  public partial class ResistorShape
  {
    public override PointD GetTerminalLocation(ComponentTerminal terminal)
    {
      Resistor resistor = ModelElement as Resistor;
      if (resistor == null) return new PointD(0, 0);

      if (AbsoluteBounds.Height > AbsoluteBounds.Width)
      {
        if ((resistor.T1 == terminal) == ((rotate+1) % 4 < 2))
          return ScalePoint(0.5, 0);
        else
          return ScalePoint(0.5, 1);
      }
      else
      {
        if ((resistor.T1 == terminal) == ((rotate+1) % 4 < 2))
          return ScalePoint(0, 0.5);
        else
          return ScalePoint(1, 0.5);
      }
    }
  }

  public partial class CapacitorShape
  {
    /// <summary>
    /// Substitute rotatable image fields in place of the standard kind.
    /// To override this method, we had to set Generates Double Derived
    /// on this class in DSL Definition.
    /// 
    /// http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.diagrams.imagefield.aspx
    /// </summary>
    /// <param name="shapeFields">List to which to add fields.</param>
    protected override void InitializeShapeFields(IList<ShapeField> shapeFields)
    {
      base.InitializeShapeFields(shapeFields);
      this.ReplaceImageFieldsWithRotatingImageFields(shapeFields);
    }

    /// <summary>
    /// Called by the ComponentTerminalShape bounds rule.
    /// </summary>
    /// <param name="terminal"></param>
    /// <returns></returns>
    public override PointD GetTerminalLocation(ComponentTerminal terminal)
    {
      Capacitor capacitor = ModelElement as Capacitor;
      if (capacitor == null) return new PointD(0, 0);

      if (AbsoluteBounds.Height < AbsoluteBounds.Width)
      {
        if ((capacitor.T1 == terminal) == ((rotate+1) % 4 < 2))
          return ScalePoint(0.5, 0);
        else
          return ScalePoint(0.5, 1);
      }
      else
      {
        if ((capacitor.T1 == terminal) == ((rotate+1) % 4 < 2))
          return ScalePoint(0, 0.5);
        else
          return ScalePoint(1, 0.5);
      }
    }
  }

  public partial class JunctionShape
  {
    public override void Rotate90()
    {
      // No action.
    }
  }
  /// <summary>
  /// TransistorShape has 16 variants of its image:
  /// - Rotate it 90 degrees
  /// - Flip it about an axis.
  /// - Two types, PNP and NPN, in which the arrow goes in or out.
  /// PNP and NPN are done with separate basic images. 
  /// Rotational and reflective variants are done with image transforms.
  /// </summary>
  public partial class TransistorShape
  {
    /// <summary>
    /// Substitute rotatable image fields in place of the standard kind.
    /// To override this method, we had to set Generates Double Derived
    /// on this class in DSL Definition.
    /// 
    /// http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.diagrams.imagefield.aspx
    /// </summary>
    /// <param name="shapeFields">List to which to add fields.</param>
    protected override void InitializeShapeFields(IList<ShapeField> shapeFields)
    {
      base.InitializeShapeFields(shapeFields);
      this.ReplaceImageFieldsWithRotatingImageFields(shapeFields);
    }
    /// <summary>
    /// A transistor has three terminals: Base, Collector, Emitter.
    /// The location depends on the state of rotation and reflection in RotateFlip.
    /// </summary>
    /// <param name="terminal"></param>
    /// <returns></returns>
    public override PointD GetTerminalLocation(ComponentTerminal terminal)
    {
      Transistor transistor = this.ModelElement as Transistor;
      if (transistor == null) return new PointD(0, 0);
      if (terminal == transistor.Base)
      {
        // Base is half way up the side, in the 0 orientation.
        switch (RotateFlip)
        {
          case 0:
          case 6: return ScalePoint(0, 0.5);
          case 2:
          case 4: return ScalePoint(1, 0.5);
          case 1:
          case 7: return ScalePoint(0.5, 1);
          case 3:
          case 5: return ScalePoint(0.5, 0);
        }
      }
      const double ceOffset = 0.55;
      if (terminal == transistor.Collector)
      {
        // Collector is at top right, in 0 orientation.
        switch (RotateFlip)
        {
          case 0: return ScalePoint(ceOffset, 0);
          case 1: return ScalePoint(0, 1 - ceOffset);
          case 2: return ScalePoint(1 - ceOffset, 1);
          case 3: return ScalePoint(1, ceOffset);
          case 4: return ScalePoint(1 - ceOffset, 0);
          case 5: return ScalePoint(0, ceOffset);
          case 6: return ScalePoint(ceOffset, 1);
          case 7: return ScalePoint(1, 1 - ceOffset);
        }
      }
      if (terminal == transistor.Emitter)
      {
        // Emitter is at bottom right, in 0 orientation.
        switch (RotateFlip)
        {
          case 0: return ScalePoint(ceOffset, 1);
          case 1: return ScalePoint(1, 1 - ceOffset);
          case 2: return ScalePoint(1 - ceOffset, 0);
          case 3: return ScalePoint(0, ceOffset);
          case 4: return ScalePoint(1 - ceOffset, 1);
          case 5: return ScalePoint(1, ceOffset);
          case 6: return ScalePoint(ceOffset, 0);
          case 7: return ScalePoint(0, 1 - ceOffset);
        }
      }
      return new PointD(0, 0);
    }
  }

  /// <summary>
  /// Defines a field in the layout of a shape.
  /// Note: There is only one instance of each field per shape class.
  /// The fields are set up when InitializeShapeFields is called, once per class.
  /// 
  /// http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.diagrams.imagefield.aspx
  /// </summary>
  public class ClickableImageField : ImageField
  {
    public delegate void ClickReceiver(ComponentShape s);
    public event ClickReceiver ClickReceiverEvent;
    

    public override void OnDoubleClick(DiagramPointEventArgs e)
    {
      base.OnDoubleClick(e);
      ComponentShape shape = e.HitDiagramItem.Shape as ComponentShape;
      if (ClickReceiverEvent != null && shape != null)
      {
        ClickReceiverEvent(shape);
      e.Handled = true; // else it will be passed to parent shape too.
      }
    }
    public ClickableImageField(string fieldName)
      : base(fieldName)
    {
    }
  }

  /// <summary>
  /// Image field that can be rotated and reflected.
  /// There is an instance of this class for each definition of a decorator on a shape class.
  /// There is not an instance for every shape.
  /// 
  /// http://msdn.microsoft.com/library/microsoft.visualstudio.modeling.diagrams.imagefield.aspx
  /// </summary>
  public class RotatingImageField : ClickableImageField
  {
    public RotatingImageField(string tag) : base(tag) { }
    
    private static RotateFlipType[] rotateFlips = //typeof( RotateFlipType).GetEnumValues() as RotateFlipType[];
                new RotateFlipType[] {
                        RotateFlipType.RotateNoneFlipNone,
                        RotateFlipType.Rotate270FlipNone,
                        RotateFlipType.Rotate180FlipNone,
                        RotateFlipType.Rotate90FlipNone,
                        RotateFlipType.RotateNoneFlipX,
                        RotateFlipType.Rotate90FlipX,
                        RotateFlipType.RotateNoneFlipY,
                        RotateFlipType.Rotate90FlipY
                        };
    private Image[] cachedImage = new Image[8];
    /// <summary>
    /// Called when the decorator is to be displayed on a particular shape instance.
    /// Called whenever the diagram is refreshed.
    /// </summary>
    /// <param name="parentShape">The shape on which the image is to be displayed.</param>
    /// <returns></returns>
    public override Image GetDisplayImage(ShapeElement parentShape)
    {
      ComponentShape componentShape = parentShape as ComponentShape;
      RotateFlipType rotateFlip = rotateFlips[componentShape.RotateFlip];
      if (cachedImage[componentShape.RotateFlip] == null)
      {
        Image image = base.GetDisplayImage(parentShape).Clone() as Image;

        if (image != null)
        {
          image.RotateFlip(rotateFlip);
          cachedImage[componentShape.RotateFlip] = image;
        }
      }
      return cachedImage[componentShape.RotateFlip];
    }
  }
  #endregion
}
