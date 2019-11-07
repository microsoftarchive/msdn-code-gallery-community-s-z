using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Microsoft.Example.Circuits
{
  // http://msdn.microsoft.com/library/cc512845.aspx
  partial class ComponentDiagram
  {
    /// <summary>
    /// True if the list of shapes can be aligned vertically or horizontally.
    /// </summary>
    /// <param name="currentSelection"></param>
    /// <returns></returns>
    public bool CanAlign(IEnumerable<ComponentShape> currentSelection)
    {
      // Simple alignment algorithm - works if there's a horizontal or vertical
      // line that intersects all the selected shapes.
      return HorizontalAlignCenter(currentSelection) > 0.0 || VerticalAlignCenter(currentSelection) > 0.0;
    }

    public void Align(System.Collections.ICollection currentSelection)
    {
      IEnumerable<ComponentShape> shapes = currentSelection.OfType<ComponentShape>();
      if (shapes.Count() > 1)
      {
        // The shapes must all overlap either horizontally or vertically.
        // Find a horizontal line that is covered by all the shapes:
        double Y = HorizontalAlignCenter(shapes);
        if (Y > 0.0) // Negative if they don't overlap.
        {
          // Adjust all the shape positions in one transaction:
          using (Transaction t = this.Store.TransactionManager.BeginTransaction("align"))
          {
            foreach (ComponentShape shape in shapes)
            {
              shape.AlignYCenter(Y);
            }
            t.Commit();
          }
        }
        else
        {
          // Find a vertical line that is covered by all the shapes:
          double X = VerticalAlignCenter(shapes);
          if (X > 0.0) // Negative if they don't overlap.
          {
            // Adjust all the shape positions in one transaction:
            using (Transaction t = this.Store.TransactionManager.BeginTransaction("align"))
            {
              foreach (ComponentShape shape in shapes)
              {
                shape.AlignXCenter(X);
              }
              t.Commit();
            }
          }
        }
      }
    }

    /// <summary>
    /// Find a horizontal line that goes through a list of shapes.
    /// </summary>
    /// <param name="shapes"></param>
    /// <returns></returns>
    private static double HorizontalAlignCenter(IEnumerable<ComponentShape> shapes)
    {
      double Y = -1.0;
      double top = 0.0, bottom = shapes.First().AbsoluteBounds.Bottom;
      foreach (ComponentShape shape in shapes)
      {
        top = Math.Max(top, shape.AbsoluteBounds.Top);
        bottom = Math.Min(bottom, shape.AbsoluteBounds.Bottom);
      }
      if (bottom > top) Y = (bottom + top) / 2.0;
      return Y;
    }

    /// <summary>
    /// Find a vertical line that goes through a list of shapes.
    /// </summary>
    /// <param name="shapes"></param>
    /// <returns></returns>
    private static double VerticalAlignCenter(IEnumerable<ComponentShape> shapes)
    {
      double X = -1.0;
      double left = 0.0, right = shapes.First().AbsoluteBounds.Right;
      foreach (ComponentShape shape in shapes)
      {
        left = Math.Max(left, shape.AbsoluteBounds.Left);
        right = Math.Min(right, shape.AbsoluteBounds.Right);
      }
      if (right > left) X = (right + left) / 2.0;
      return X;
    }
  }
  #region alignment

  partial class ComponentShape
  {
    /// <summary>
    /// Align to a horizontal line.
    /// </summary>
    /// <param name="Y"></param>
    public virtual void AlignYCenter(double Y)
    {
      PointD topLeft = new PointD(this.AbsoluteBounds.X, Y - YCenter);
      this.AbsoluteBounds = new RectangleD(topLeft, AbsoluteBounds.Size);
    }

    /// <summary>
    /// Align to a vertical line.
    /// </summary>
    /// <param name="X"></param>
    public virtual void AlignXCenter(double X)
    {
      PointD topLeft = new PointD(X - XCenter, AbsoluteBounds.Y);
      AbsoluteBounds = new RectangleD(topLeft, AbsoluteBounds.Size);
    }

    /// <summary>
    /// Center for alignment, relative to top left corner.
    /// </summary>
    protected virtual double YCenter
    {
      get
      {
        return this.AbsoluteBounds.Height / 2.0;
      }
    }
    /// <summary>
    /// Center for alignment, relative to top left corner.
    /// </summary>
    protected virtual double XCenter
    {
      get
      {
        return this.AbsoluteBounds.Width / 2.0;
      }
    }
  }

  partial class TransistorShape
  {
    /// <summary>
    /// "Center" for alignment is actually where the terminal center is, to keep wires straight.
    /// </summary>
    protected override double XCenter
    {
      get
      {
        double corner = this.AbsoluteBounds.Width * 0.1;
        ShapeElement midPort = this.RelativeChildShapes.Where(port => port is ComponentTerminalShape
          && port.AbsoluteBoundingBox.Left > this.AbsoluteBounds.Left + corner
          && port.AbsoluteBoundingBox.Right < this.AbsoluteBounds.Right - corner).FirstOrDefault();
        if (midPort != null) return midPort.AbsoluteCenter.X - this.AbsoluteBounds.X;
        else return base.XCenter;
      }
    }
    /// <summary>
    /// "Center" for alignment is actually where the terminal center is, to keep wires straight.
    /// </summary>
    protected override double YCenter
    {
      get
      {
        double corner = this.AbsoluteBounds.Height * 0.1;
        ShapeElement midPort = this.RelativeChildShapes.Where(port => port is ComponentTerminalShape
          && port.AbsoluteBoundingBox.Top > this.AbsoluteBounds.Top + corner
          && port.AbsoluteBoundingBox.Bottom < this.AbsoluteBounds.Bottom - corner).FirstOrDefault();
        if (midPort != null) return midPort.AbsoluteCenter.Y - this.AbsoluteBounds.Y;
        else return base.YCenter;
      }
    }
  }

  #endregion

}
