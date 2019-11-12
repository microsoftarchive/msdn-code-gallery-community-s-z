using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Example.Circuits.DslPackage
{
  public partial class WrappingForm : UserControl
  {
    public WrappingForm()
    {
      InitializeComponent();
    }

    #region Access form from model
    // Enable the form to access the model:
    private CircuitsDocView docView;
    private ComponentModel modelRoot;

    internal WrappingForm(CircuitsDocView docView, Control content)
      : this()
    {
      // Insert the DSL diagram into the Panel we've provided for it:
      DiagramPanel.Controls.Add(content);

      // Allows access to DSL from the form:
      this.docView = docView;
    }


    private void button1_Click_1(object sender, EventArgs e)
    {
      // Call the validation controller that is attached to the document, 
      // so that any errors appear in the errors window.
      // See http://msdn.microsoft.com/library/bb126413.aspx
      CircuitsDocData docData = docView.DocData as CircuitsDocData;
      docData.ValidationController.Validate(docData.Store, VisualStudio.Modeling.Validation.ValidationCategories.Menu);
    }
    #endregion


    /// <summary>
    /// Initialize the parts list when the model has loaded from file.
    /// </summary>
    internal void SetUpFormFromModel()
    {
      modelRoot = this.docView.CurrentDiagram.ModelElement as ComponentModel;
      UpdatePartsList();
    }

    /// <summary>
    /// Callback on Store Event when items are added to model.
    /// </summary>
    /// <param name="c"></param>
    internal void Add(Component c)
    {
      UpdatePartsList();
    }
    /// <summary>
    /// Callback on Store Event items are removed from model.
    /// </summary>
    /// <param name="c"></param>
    internal void Remove(Component c)
    {
      UpdatePartsList();
    }

    /// <summary>
    /// Better practice might be to decouple the Windows Form from the model a bit more.
    /// However, this is just an illustration to show that we can update the form from the model.
    /// </summary>
    private void UpdatePartsList()
    {
      SortedDictionary<string, int> inventory = new SortedDictionary<string, int>();
      foreach (Component c in modelRoot.Components)
      {
        string componentType = c.GetType().Name;
        int count = 0;
        if (!inventory.TryGetValue(componentType, out count))
        {
          inventory[componentType] = 1;
        }
        else
        {
          inventory[componentType]++;
        }
      }
      StringBuilder builder = new StringBuilder();
      listBox1.Items.Clear();
      foreach (string componentType in inventory.Keys)
      {
        listBox1.Items.Add(string.Format("{0,-20} {1,2}", componentType, inventory[componentType]));
      }
    }
  }



}