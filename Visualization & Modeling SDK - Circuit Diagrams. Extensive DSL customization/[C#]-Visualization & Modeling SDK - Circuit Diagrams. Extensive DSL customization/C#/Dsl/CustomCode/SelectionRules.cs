using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Microsoft.Example.Circuits
{

  /// <summary>
  /// Makes sure that you select a component, even if you click one of its terminals.
  /// 
  /// http://msdn.microsoft.com/library/dd820621.aspx
  /// </summary>
  class MySelectionRules : DiagramSelectionRules
  {
    /// <summary>
    /// Called when the user selects an item on the diagram.
    /// Returns the shape that should actually be selected.
    /// </summary>
    /// <param name="currentSelection">The pre-existing selection.</param>
    /// <param name="proposedItemsToAdd">The items that will be selected. Modify this to select something else.</param>
    /// <param name="proposedItemsToRemove">Items that will be removed from the current selection.</param>
    /// <param name="primaryItem">The most recent item selected.</param>
    /// <returns>True if the selection was at least partially successful.</returns>
    public override bool GetCompliantSelection(SelectedShapesCollection currentSelection, DiagramItemCollection proposedItemsToAdd, DiagramItemCollection proposedItemsToRemove, DiagramItem primaryItem)
    {
      // We will modify proposedItemsToAdd, replacing component terminal shapes by component shapes.
      List<DiagramItem> toAdd = new List<DiagramItem>();
      List<DiagramItem> toDrop = new List<DiagramItem>();
      foreach (DiagramItem item in proposedItemsToAdd)
      {
        if (item.Shape is ComponentTerminalShape)
        {
          ComponentTerminal terminal = item.Shape.ModelElement as ComponentTerminal;
          if (terminal == null) continue;
          toAdd.Add(new DiagramItem(item.Diagram.FindShape(terminal.Component)));
          toDrop.Add(item);
        }
      }
      proposedItemsToAdd.Remove(toDrop); // Remove the terminals.
      proposedItemsToAdd.Add(toAdd); // Add the parent components.
      
      return base.GetCompliantSelection(currentSelection, proposedItemsToAdd, proposedItemsToRemove, primaryItem);
    }
  }

  partial class ComponentDiagram
  {
    public override DiagramSelectionRules SelectionRules
    {
      get
      {
        if (selectionRules == null)
        {
          selectionRules = new MySelectionRules();
        }
        return selectionRules;
      }
    }
    private MySelectionRules selectionRules = null;
  }
}