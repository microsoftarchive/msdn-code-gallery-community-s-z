using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Drawing;
using System.Drawing.Imaging;


// See also Dsl\CustomCode\CutAndPaste.cs
// and http://msdn.microsoft.com/library/dd820672.aspx


namespace Microsoft.Example.Circuits.DslPackage
{
  internal partial class CircuitsClipboardCommandSet
  {
    /// <summary>
    /// Called to determine whether the Copy menu command should be enabled.
    /// </summary>
    /// <param name="cmd"></param>
    protected override void ProcessOnStatusCopyCommand(MenuCommand cmd)
    {
      this.ProcessOnStatusCutCommand(cmd);
    }
    /// <summary>
    /// Called to determine whether the Cut menu command should be enabled.
    /// </summary>
    /// <param name="cmd"></param>
    protected override void ProcessOnStatusCutCommand(MenuCommand cmd)
    {
      cmd.Visible = !this.IsDiagramSelected();
      cmd.Enabled = this.CurrentSelection.OfType<NodeShape>().Count() > 0;
    }
    /// <summary>
    /// Called to determine whether the Paste menu command should be enabled.
    /// </summary>
    /// <param name="cmd"></param>
    protected override void ProcessOnStatusPasteCommand(MenuCommand cmd)
    {
      CircuitsDocView docView = this.CurrentModelingDocView as CircuitsDocView;
      Diagram diagram = docView.CurrentDiagram;
      cmd.Visible = true;
      cmd.Enabled = diagram.ElementOperations.CanMerge(diagram, System.Windows.Forms.Clipboard.GetDataObject());
    }

    /// <summary>
    /// Called when the user presses CTRL+V or chooses Paste on the diagram.
    /// This method assumes we only want to paste things onto the diagram
    /// - not onto anything contained in the diagram.
    /// The base method pastes in a free space on the diagram.
    /// But if the menu was used to invoke paste, we want to paste in the cursor position.
    /// </summary>
    protected override void ProcessOnMenuPasteCommand()
    {
      // If true, this method assumes we're only pasting on the diagram.
      // Anything selected will be deselected, and paste will be onto diagram.
      const bool pasteOnlyOnDiagram = true;

      CircuitsDocView docView = this.CurrentModelingDocView as CircuitsDocView;

      // Retrieve data from clipboard:
      System.Windows.Forms.IDataObject data = System.Windows.Forms.Clipboard.GetDataObject();

      Diagram diagram = docView.CurrentDiagram;
      if (diagram == null) return;

      if (!docView.IsContextMenuShowing)
      {
        // User hit CTRL+V - just use base method.

        // Deselect anything that's selected, otherwise
        // pasted item will be incompatible:
        if (pasteOnlyOnDiagram && !this.IsDiagramSelected())
        {
          docView.SelectObjects(1, new object[] { diagram }, 0);
        }

        // Paste into a convenient spare space on diagram:
        base.ProcessOnMenuPasteCommand();
      }
      else
      {
        // User right-clicked - paste at mouse position.

        // Utility class:
        DesignSurfaceElementOperations op = diagram.ElementOperations;

        ShapeElement pasteTarget = pasteOnlyOnDiagram ? diagram : this.CurrentSelection.OfType<ShapeElement>().First();

        // Check whether what's in the paste buffer is acceptable on the target.
        if (op.CanMerge(pasteTarget, data))
        {

          // Although op.Merge would be a no-op if CanMerge failed, we check CanMerge first
          // so that we don't create an empty transaction (after which Undo would be no-op).
          using (Transaction t = diagram.Store.TransactionManager.BeginTransaction("paste"))
          {
            PointD place = docView.ContextMenuMousePosition;
            op.Merge(pasteTarget, data, PointD.ToPointF(place));
            t.Commit();

          }
        }
      }
    }


    /// <summary>
    /// Called when the user selects the Cut menu command, or presses CTRL+X.
    /// </summary>
    protected override void ProcessOnMenuCutCommand()
    {
      if (!this.IsDiagramSelected())
      {
        // There are shapes and/or connectors selected.
        using (Transaction t = this.CurrentDocData.Store.TransactionManager.BeginTransaction("cut"))
        {
          ProcessOnMenuCopyCommand();
          ModelElement[] toRemove = this.CurrentSelection.OfType<ShapeElement>()
            .Select(shape => shape.ModelElement as ModelElement)
            .Where(mel => mel is Component || mel is Junction || mel is Comment).ToArray();
          foreach (ModelElement mel in toRemove) mel.Delete();
          t.Commit();
        }
      }
    }
  }

}
