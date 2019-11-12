using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Shell;

namespace Microsoft.Example.Circuits.DslPackage
{
  // For more about setting up commands, see http://msdn.microsoft.com/library/dd820681.aspx

  internal partial class CircuitsCommandSet
  {
    // IDs of my commands, duplicated in Commands.vsct:
    private const int RotateCommand = 0x801;
    private const int FlipCommand = 0x802;
    private const int PolarityCommand = 0x803;
    private const int AlignCommand = 0x804;

    /// <summary>
    /// Initialize the list of menu commands.
    /// DynamicStatusMenuCommands are those that be made
    /// visible and enabled depending on state and selected object.
    /// 
    /// These commands are labelled and positioned on the menu in Commands.vsct.
    /// </summary>
    /// <returns></returns>
    protected override IList<MenuCommand> GetMenuCommands()
    {
      IList<MenuCommand> commands = base.GetMenuCommands();
      commands.Add(new DynamicStatusMenuCommand(
          new EventHandler(OnStatusFlipRotateComponent),
          new EventHandler(OnMenuFlipRotateComponent),
          new CommandID(
              new Guid(Constants.CircuitsCommandSetId),
              RotateCommand)));
      commands.Add(new DynamicStatusMenuCommand(
          new EventHandler(OnStatusFlipRotateComponent),
          new EventHandler(OnMenuFlipRotateComponent),
          new CommandID(
              new Guid(Constants.CircuitsCommandSetId),
              FlipCommand)));
      commands.Add(new DynamicStatusMenuCommand(
          new EventHandler(OnStatusFlipRotateComponent),
          new EventHandler(OnMenuFlipRotateComponent),
          new CommandID(
              new Guid(Constants.CircuitsCommandSetId),
              PolarityCommand)));
      commands.Add(new DynamicStatusMenuCommand(
          new EventHandler(OnStatusAlign),
          new EventHandler(OnMenuAlign),
          new CommandID(
              new Guid(Constants.CircuitsCommandSetId),
              AlignCommand)));

      return commands;
    }


    #region alignment
    /// <summary>
    /// Called when the user right-clicks anywhere in the diagram.
    /// This method determines whether a context menu command appears and is visible,
    /// based on the current selection.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    internal void OnStatusAlign(object sender, EventArgs e)
    {
      MenuCommand command = sender as MenuCommand;
      command.Visible = command.Enabled = false;
      IEnumerable<ComponentShape> shapes = this.CurrentSelection.OfType<ComponentShape>();
      if (shapes.Count() > 1)
      {
        command.Visible = true;
        // The shapes must all overlap a single horizontal line or a single vertical line:
        if ((this.CurrentCircuitsDocView.Diagram as ComponentDiagram).CanAlign(shapes))
        {
          command.Enabled = true;
        }
      }
    }


    /// <summary>
    /// Called when the user selects the Align menu command.
    /// Aligns a selection of shapes, provided all the items in the selection
    /// are roughly lined up either horizontally or vertically.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    internal void OnMenuAlign(object sender, EventArgs e)
    {
      (this.CurrentCircuitsDocView.Diagram as ComponentDiagram).Align(this.CurrentSelection);
    }
    #endregion

    #region flip and rotate commands
    /// <summary>
    /// Called when the user right-clicks the diagram,
    /// to determine whether to show the Flip and Rotate commands.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    internal void OnStatusFlipRotateComponent(object sender, EventArgs e)
    {
      MenuCommand command = sender as MenuCommand;
      command.Visible = command.Enabled = this.CurrentSelection.OfType<ComponentShape>()
        .Where(shape => shape.ModelElement is Component).Count() > 0;
      // JunctionShape is a ComponentShape, but Junction is not a Component.
      // In this case, we don't want JunctionShapes.
    }

    /// <summary>
    /// Called when the user selects the Flip, Rotate, or Polarity command.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    internal void OnMenuFlipRotateComponent(object sender, EventArgs e)
    {
      MenuCommand command = sender as MenuCommand;
      using (Transaction transaction = this.CurrentCircuitsDocData.Store.TransactionManager.BeginTransaction("component command"))
      {
        foreach (ComponentShape componentShape in this.CurrentSelection.OfType<ComponentShape>())
        {
          switch (command.CommandID.ID)
          {
            case RotateCommand:
              {
                componentShape.Rotate90();
                break;
              }
            case FlipCommand:
              {
                componentShape.Flip();
                break;
              }
            case PolarityCommand:
              {
                Component component = componentShape.ModelElement as Component;
                if (component != null)
                  component.Polarity = !component.Polarity;
                // For transistors, visibility of NPN and PNP images is coupled to this property in DSL Definition.
                // To see this, click the shape map from Transistor to TransistorShape, 
                // then open DSL Details window, and click the Decorators tab.
                break;
              }

          }
        }
        transaction.Commit();
      }


    }
    #endregion

  }

    
}