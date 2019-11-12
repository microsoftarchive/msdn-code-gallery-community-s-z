using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;


namespace Microsoft.Example.Circuits
{

  public partial class CircuitsToolboxHelper
  {
    /* There are two versions of CreateElementToolPrototype here.
     * One deals with each Component subtype separately: if you add a new subtype, you need to add more here.
     * The other automatically deals with eacn Component subtype, using DSL reflection info.
     * 
     * See http://msdn.microsoft.com/library/bb126279.aspx#groups
     */

    /*
    /// <summary>
    /// Toolbox initialization, called for each element tool on the toolbox.
    /// This version deals with each Component subtype separately.
    /// </summary>
    /// <param name="store"></param>
    /// <param name="domainClassId">Identifies the domain class this tool should instantiate.</param>
    /// <returns>prototype of the object or group of objects to be created by tool</returns>
    protected override ElementGroupPrototype CreateElementToolPrototype(Store store, Guid domainClassId)
    {

        if (domainClassId == Resistor.DomainClassId)
        {
            Resistor resistor = new Resistor(store);

            // Must initialize these in order of initialization:
            // DSLT v1 bug affecting derived relationships.
            resistor.T1 = new ComponentTerminal(store);
            resistor.T2 = new ComponentTerminal(store);

            resistor.T1.Name = "t1";
            resistor.T2.Name = "t2";

            ElementGroup elementGroup = new ElementGroup(store.DefaultPartition);
            elementGroup.AddGraph(resistor, true);
            // AddGraph includes the embedded parts.

            return elementGroup.CreatePrototype();
        }
        else if (domainClassId == Capacitor.DomainClassId)
        {
            Capacitor capacitor = new Capacitor(store);

            // Must initialize these in order of initialization:
            // DSLT v1 bug affecting derived relationships.
            capacitor.T1 = new ComponentTerminal(store);
            capacitor.T2 = new ComponentTerminal(store);

            capacitor.T1.Name = "t1";
            capacitor.T2.Name = "t2";

            ElementGroup elementGroup = new ElementGroup(store.DefaultPartition);
            elementGroup.AddGraph(capacitor, true);
            // AddGraph includes the embedded parts.

            return elementGroup.CreatePrototype();
        }

        else if (domainClassId == Transistor.DomainClassId)
        {
            Transistor transistor = new Transistor(store);

            // Must initialize these in order of initialization:
            // DSLT v1 bug affecting derived relationships.
            transistor.Base = new ComponentTerminal(store);
            transistor.Collector = new ComponentTerminal(store);
            transistor.Emitter = new ComponentTerminal(store);

            transistor.Base.Name = "base";
            transistor.Collector.Name = "collector";
            transistor.Emitter.Name = "emitter";

            // Create an ElementGroup for the Toolbox.
            ElementGroup elementGroup = new ElementGroup(store.DefaultPartition);
            elementGroup.AddGraph(transistor, true);
            // AddGraph includes the embedded parts

            return elementGroup.CreatePrototype();
        }

        else
        {
            return base.CreateElementToolPrototype(store, domainClassId);
        }


    }
      
     */

    /// <summary>
    /// Toolbox initialization for components with fixed embedded parts.
    /// This deals with all the subclasses of Component, adding an instance for each relationship derived from ComponentHasTerminals.
    /// The benefit of this approach is that it does not need to be adjusted for each new Component subclass.
    /// Called for each element tool on the toolbox.
    /// </summary>
    /// <param name="store"></param>
    /// <param name="domainClassId">Identifies the domain class this tool should instantiate.</param>
    /// <returns>prototype of the object or group of objects to be created by tool</returns>
    protected override ElementGroupPrototype CreateElementToolPrototype(Store store, Guid domainClassId)
    {
      // Called for each element tool on the toolbox. 
      // Get the class meta info for this class.
      DomainClassInfo thisClassInfo = store.DomainDataDirectory.FindDomainClass(domainClassId);

      if (!thisClassInfo.IsDerivedFrom(Component.DomainClassId))
      {
        // Not one of those we're interested in: defer to base method.
        return base.CreateElementToolPrototype(store, domainClassId);
      }
      else
      {
        // Construct an instance of this type. Use the constructor that takes a store and a variable number of property bindings.
        Component component = (Component)thisClassInfo.ImplementationClass. // get the actual class from the meta info
            InvokeMember( // method in System.Reflection.Type
            "",
            System.Reflection.BindingFlags.CreateInstance  // invoke the constructor
            | System.Reflection.BindingFlags.OptionalParamBinding, // which has a params binding
            null,             // no special binder
            null,             //no target object since we want the constructor
            new object[] { store });  // Called like "new Resistor(store)"

        // Now add whatever ComponentTerminals it has. 
        // Each Component subtype sources several subrelationships of ComponentHasComponentTerminal.
        // Go through the metainfo about each role the class plays in relationships.
        foreach (DomainRoleInfo role in thisClassInfo.LocalDomainRolesPlayed)
        {
          // Pick out the roles that are one end of a relationship to a Terminal.
          if (role.DomainRelationship.IsDerivedFrom(ComponentHasComponentTerminal.DomainClassId)
              && !role.DomainRelationship.ImplementationClass.IsAbstract)
          {
            ComponentTerminal terminal = new ComponentTerminal(store);
            // Fill in the instance name with the name of the role - just a convenience.
            // The role at the Terminal end of the relationship is the one called "T1" or "collector" or some such.
            terminal.Name = role.OppositeDomainRole.Name.ToLowerInvariant();
            // Instantiate the relationship with the constructor that takes the component and terminal.
            role.DomainRelationship.ImplementationClass.InvokeMember("", System.Reflection.BindingFlags.CreateInstance,
                null, null,
                new object[] { component, terminal });
          }
        }
        // Create an Element Group Prototype containing this tree.
        ElementGroup elementGroup = new ElementGroup(store.DefaultPartition);
        elementGroup.AddGraph(component, true, true); // AddGraph includes the embedded elements.
        elementGroup.AddRange(component.ComponentTerminals, true);
        ElementGroupPrototype egp = elementGroup.CreatePrototype();
        return egp;
      }
    }
  }



  #region terminal placement

  public partial class ComponentTerminalShape
  {
    /// <summary>
    /// Register a BoundsRules that will determine the location and size of this shape.
    /// http://msdn.microsoft.com/library/bb126326.aspx
    /// </summary>
    public override Microsoft.VisualStudio.Modeling.Diagrams.BoundsRules BoundsRules
    {
      get
      {
        return new ComponentTerminalBoundsRule();
      }
    }
  }

  /// <summary>
  /// Determines the location and size of a ComponentTerminalShape.
  /// Has to be registered in the shape class.
  /// http://msdn.microsoft.com/library/bb126326.aspx
  /// </summary>
  public class ComponentTerminalBoundsRule : BoundsRules
  {
    /// <summary>
    /// Called when the user or program code tries to move or resize the shape, and when the shape is initially created.
    /// In this case, we restrict the ComponentTerminal to be at a fixed position on the shape, with a fixed size.
    /// </summary>
    /// <param name="shape">The shape that is being moved or created.</param>
    /// <param name="proposedBounds">What the user or code would like.</param>
    /// <returns>The permitted bounds that are closest to the proposedBounds.</returns>
    public override RectangleD GetCompliantBounds(ShapeElement shape, RectangleD proposedBounds)
    {
      ComponentTerminal terminal = shape.ModelElement as ComponentTerminal;
      if (terminal == null) return proposedBounds;
      ComponentTerminalShape terminalShape = shape as ComponentTerminalShape;
      ComponentShape componentShape = terminalShape.ParentShape as ComponentShape;
      if (componentShape == null) return proposedBounds;

      // Location depends on which terminal it is, of which type of shape.
      PointD relativeLocation = componentShape.GetTerminalLocation(terminal);

      if (relativeLocation.X > 0 || relativeLocation.Y > 0)
      {
        return new RectangleD(relativeLocation.X - 0.025, relativeLocation.Y - 0.025, proposedBounds.Width, proposedBounds.Height);
      }
      else return proposedBounds;
    }
  }

  #endregion


  #region resistor shape

  public partial class ResistorShape
  {
    public override Microsoft.VisualStudio.Modeling.Diagrams.BoundsRules BoundsRules
    {
      get
      {
        return new ResistorBoundsRule();
      }
    }
  }

  public class ResistorBoundsRule : BoundsRules
  {
    public override RectangleD GetCompliantBounds(ShapeElement shape, RectangleD proposedBounds)
    {
      if (proposedBounds.Width > proposedBounds.Height)
      {
        return new RectangleD(proposedBounds.X, proposedBounds.Y, 0.50, 0.15);
      }
      else
      {
        return new RectangleD(proposedBounds.X, proposedBounds.Y, 0.15, 0.40);
      }
    }
  }
  #endregion


  #region capacitor shape

  public partial class CapacitorShape
  {

    public override Microsoft.VisualStudio.Modeling.Diagrams.BoundsRules BoundsRules
    {
      get
      {
        return new CapacitorBoundsRule();
      }
    }

  }

  public class CapacitorBoundsRule : BoundsRules
  {
    public override RectangleD GetCompliantBounds(ShapeElement shape, RectangleD proposedBounds)
    {
      if (proposedBounds.Width > proposedBounds.Height)
      {
        return new RectangleD(proposedBounds.X, proposedBounds.Y, 0.60, 0.25);
      }
      else
      {
        return new RectangleD(proposedBounds.X, proposedBounds.Y, 0.20, 0.40);
      }
    }
  }
  #endregion


  #region transistor shape

  public partial class TransistorShape
  {
    public override Microsoft.VisualStudio.Modeling.Diagrams.BoundsRules BoundsRules
    {
      get
      {
        return new TransistorBoundsRule();
      }
    }

  }


  public class TransistorBoundsRule : BoundsRules
  {
    public override RectangleD GetCompliantBounds(ShapeElement shape, RectangleD proposedBounds)
    {
      return new RectangleD(proposedBounds.X, proposedBounds.Y, 0.40, 0.4);
    }
  }

  #endregion

  #region appearance
  public partial class ComponentDiagram
  {
    public override double GridSize
    {
      get
      {
        return 0.02;
      }
      set
      {
        //this.ShowGrid = true;
        base.GridSize = value;
      }
    }

  }

  public partial class ComponentShape
  {
    public virtual PointD GetTerminalLocation(ComponentTerminal terminal)
    {
      return new PointD(0, 0);
    }
    public override bool HasShadow
    {
      get
      {
        return false;
      }
    }
    public override bool ClipWhenDrawingFields
    {
      get
      {
        return false; // ensure the whole image appears
      }
    }


  }
  #endregion

}
