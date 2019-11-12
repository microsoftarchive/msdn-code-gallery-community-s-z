using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Shell;
using Microsoft.VisualStudio.Shell.Interop;

// Embed the DSL diagram inside a Windows Form. See http://msdn.microsoft.com/library/bb126272.aspx#formEmbed


namespace Microsoft.Example.Circuits.DslPackage
{
  
  internal partial class CircuitsDocView
  {
    private WrappingForm container;

    /// <summary>
    /// Gets the window containing the DSL.
    /// Normally this is just the VS window, but we place our form inside it.
    /// </summary>
    public override System.Windows.Forms.IWin32Window Window
    {
      get
      {
        if (container == null)
        {
          // Put the our own form inside the DSL window:
          container = new WrappingForm(this, (System.Windows.Forms.Control)base.Window);
        }
        return container;
      }
    }

    /// <summary>
    /// Opens the window. 
    /// 
    /// This override registers listeners for the Add and Remove store events.
    /// Store events are called after the end of a store transaction (or an undo/redo) and are 
    /// used to keep things outside the store synchronized with changes inside the store.
    /// See http://msdn.microsoft.com/library/bb126250.aspx
    /// 
    /// This method is a convenient place to register listeners, because all the links
    /// in the model and diagram have been set up after loading from file.
    /// An alternative place is DocData.OnDocumentLoaded().
    /// </summary>
    /// <returns></returns>
    protected override bool LoadView()
    {
      bool result = base.LoadView();

      if (result)
      {
        ComponentModel root = this.DocData.ModelingDocStore.Store.ElementDirectory.FindElements<ComponentModel>().FirstOrDefault();
        IVsWindowFrame frame = this.ServiceProvider.GetService(typeof(IVsWindowFrame)) as IVsWindowFrame;
        if (frame != null)
        {
          frame.SetProperty((int)__VSFPROPID.VSFPROPID_EditorCaption, ": " + root.Name);
        } 
      }


      #region Store event handler registration

      Store store = this.DocData.Store;

      // Store events are added to the various properties of the EMD:
      EventManagerDirectory emd = store.EventManagerDirectory;

      // Store events are registered per domain class, not per instance. After a listener is 
      // registered with a class, it is called for every change to any instance of the class:

      DomainClassInfo componentClass = store.DomainDataDirectory.FindDomainClass(typeof(Component));
      emd.ElementAdded.Add(componentClass, new EventHandler<ElementAddedEventArgs>(AddComponent));
      emd.ElementDeleted.Add(componentClass, new EventHandler<ElementDeletedEventArgs>(RemoveComponent));

      DomainRelationshipInfo commentLinkInfo = store.DomainDataDirectory.FindDomainRelationship(typeof(CommentsReferenceComponents));
      emd.ElementDeleted.Add(commentLinkInfo, new EventHandler<ElementDeletedEventArgs>(RemoveCommentLink));
      

      // Do the initial parts list:
      container.SetUpFormFromModel();

      #endregion Store event handlers.

      return result;
    }

    /// <summary>
    /// Listener method called on creation of instances of 
    /// the Component class or its subclasses.
    /// Called once per instance that was added.
    /// This method was registered in LoadView().
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddComponent(object sender, ElementAddedEventArgs e)
    {
      Component component = e.ModelElement as Component;
      container.Add(component);
    }
    /// <summary>
    /// Listener method called after deletion of instances
    /// of the Component class or its subclasses.
    /// Called once per instance that was deleted.
    /// This method was registered in LoadView().
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RemoveComponent(object sender, ElementDeletedEventArgs e)
    {
      Component component = e.ModelElement as Component;
      container.Remove(component);
    }

    private void RemoveCommentLink(object sender, ElementDeletedEventArgs e)
    {
      CommentsReferenceComponents link = e.ModelElement as CommentsReferenceComponents;
      Comment comment = link.Comment;
      Component component = link.Subject;
      if (comment.IsDeleted)
      {
        // The link was deleted because the comment was deleted.
        System.Windows.Forms.MessageBox.Show("Removed comment on " + component.Name);
      }
      else
      {
        // It was just the link that was deleted - the comment itself remains.
        System.Windows.Forms.MessageBox.Show("Removed comment link to " + component.Name);
      }
    }

  }
}
