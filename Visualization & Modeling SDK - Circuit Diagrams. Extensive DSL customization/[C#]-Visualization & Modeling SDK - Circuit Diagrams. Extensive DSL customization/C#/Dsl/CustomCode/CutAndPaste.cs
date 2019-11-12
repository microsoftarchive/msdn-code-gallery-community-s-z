using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

// See also DslPackage\Custom\CutAndPaste.cs

namespace Microsoft.Example.Circuits
{
  # region Copy-paste by custom ElementOperations. See http://msdn.microsoft.com/library/ff521398.aspx
  /// <summary>
  /// ElementOperations encapsulates several copy, paste, and similar operations.
  /// The standard version doesn't preserve the layout of the shapes on paste.
  /// This version does.
  /// </summary>
  public class MyElementOperations : DesignSurfaceElementOperations
  {
    
    /// <summary>
    /// Called on copy, cut or drag.
    /// For a copy or cut, the supplied elements are the model elements, and the call comes, via AddGroupFormat, from ClipboardCommands.ProcessOnMenuCopy().
    /// For a drag operation, the elements are the selected shapes and connectors, and the call comes from Diagram.DoDragDrop, if CanMove or CanCopy are true.
    /// In the drag case, we want to add the model elements so that we can do a copy
    /// if the user presses CTRL while dragging.
    /// 
    /// See http://msdn.microsoft.com/library/ff521398.aspx
    /// </summary>
    /// <param name="shapeOrModelElements">The shape or model elements being copied - usually the current selection.</param>
    /// <param name="closureType">Copy or Delete</param>
    /// <returns>Group to be stored in the clipboard.</returns>
    protected override ElementGroup CreateElementGroup(ICollection<ModelElement> shapeOrModelElements, ClosureType closureType)
    {
      // CreateElementGroup respects the settings of PropagateCopy.
      // Notice that we have set PropagateCopy on the roles from components to the terminals,
      // so that terminals will always be copied along with their parents.

      // Add the specified group of shapes or elements:
      ElementGroup group = base.CreateElementGroup(shapeOrModelElements, closureType);

      // If this a set of shapes, add their model elements:
      if (shapeOrModelElements.FirstOrDefault() is PresentationElement)
      {
        // Get the model elements of the shapes:
        ICollection<ModelElement> modelElements = 
          shapeOrModelElements.OfType<PresentationElement>()
          // Filter out shapes such as labels that don't have model elements:
                    .Where(pel=>pel.ModelElement != null)
                    .Select(pel => pel.ModelElement).ToList();

        ElementGroup melGroup = base.CreateElementGroup(modelElements, closureType);
        group.AddRange(melGroup.GetElements());
      }
      
      return group;

      // 2011-03-21 Thanks to Joeul in VMSDK Forum for a bug fix here.
      // http://social.msdn.microsoft.com/Forums/en-US/dslvsarchx/thread/0b0b16d4-6014-4b35-9e5a-e27ea02e0ee3
    }
     

    /// <summary>
    /// Create an EGP to add to the clipboard.
    /// Called when the elements to be copied or dragged have been
    /// collected into an ElementGroup and after the roots have been marked.
    /// This override ensures that the shapes and connectors of each element and relationship are included.
    /// </summary>
    /// <param name="elementGroup">Group of elements and maybe shapes</param>
    /// <param name="elements">The original set of elements to be added, not including children, relationships, etc. Typically, the current selection.</param>
    /// <param name="closureType">Copy or Delete - specifies which propagation scheme to follow</param>
    /// <returns>EGP </returns>
    protected override ElementGroupPrototype CreateElementGroupPrototype(ElementGroup elementGroup, ICollection<ModelElement> elements, ClosureType closureType)
    {
      // Get the elements already in the group:
      ModelElement[] mels = elementGroup.ModelElements
          .Concat(elementGroup.ElementLinks) // Omit if the paste target is not the diagram.
          .ToArray();

      // Get their shapes and connectors:
      IEnumerable<PresentationElement> shapes =
         mels.SelectMany(mel =>
              PresentationViewsSubject.GetPresentation(mel));
      elementGroup.AddRange(shapes, true);

      return base.CreateElementGroupPrototype (elementGroup, elements, closureType);
    }
    
    public MyElementOperations(IServiceProvider serviceProvider, ComponentDiagram diagram)
      : base(serviceProvider, diagram)
    { }

  }

  // Replace the standard ElementOperations
  // singleton with our own:
  partial class ComponentDiagram
  {
    
    /// <summary>
    /// Singleton ElementOperations attached to this diagram.
    /// </summary>
    public override DesignSurfaceElementOperations ElementOperations
    {
      get
      {
        if (elementOps == null)
        {
          elementOps = new MyElementOperations(this.Store as IServiceProvider, this);
        }
        return elementOps;
      }
    }
    private MyElementOperations elementOps = null;
        
  }
  #endregion

  # region copy by drag-drop http://msdn.microsoft.com/library/ff793459.aspx

  /// <summary>
  /// Implement copy by drag-drop.
  /// 
  /// See http://msdn.microsoft.com/library/ff793459.aspx
  /// </summary>
  partial class ComponentDiagram
  {
    /// <summary>
    /// Called when the user drags over parts of the diagram.
    /// </summary>
    /// <param name="e"></param>
    public override void OnDragOver(DiagramDragEventArgs e)
    {
      base.OnDragOver(e);
      if (e.Control // user is pressing CTRL key.
          && e.Effect == System.Windows.Forms.DragDropEffects.None
          && IsAcceptableDropItem(e))
      {
        // Set the cursor to show [+]:
        e.Effect = System.Windows.Forms.DragDropEffects.Copy;
      }
    }
    
    private bool IsAcceptableDropItem(DiagramDragEventArgs e)
    {
      if (e.Prototype == null) return false;
      IMergeElements mergeTarget = (IMergeElements)this.ModelElement;
      foreach (ProtoElement proto in e.Prototype.RootProtoElements)
      {
        if (mergeTarget.CanMerge(proto, e.Prototype))
        {
          return true;
        }
      }
      return false;
    }
 
    /// <summary>
    /// Called when the user lets go of the mouse button after dragging.
    /// </summary>
    /// <param name="e"></param>
    public override void OnDragDrop(DiagramDragEventArgs e)
    {
      if (e.Control // User pressing CTRL key.
        && IsAcceptableDropItem(e))
      {
        ProcessDragDropItem(e);
      }
      else
      {
        base.OnDragDrop(e);
      }
    }
    
    private void ProcessDragDropItem(DiagramDragEventArgs e)
    {
      // Utility class:
      DesignSurfaceElementOperations op = this.ElementOperations;

      ShapeElement pasteTarget = this;

      // Check whether what's in the paste buffer is acceptable on the target.
      if (op.CanMerge(pasteTarget.ModelElement, e.Data))
      {

        // Although op.Merge would be a no-op if CanMerge failed, we check CanMerge first
        // so that we don't create an empty transaction (after which Undo would be no-op).
        using (Transaction t = this.Store.TransactionManager.BeginTransaction("paste"))
        {
          PointD place = e.MousePosition;
          op.Merge(pasteTarget, e.Data, PointD.ToPointF(place));
          t.Commit();

        }
      }
    }

  }
  #endregion
}
