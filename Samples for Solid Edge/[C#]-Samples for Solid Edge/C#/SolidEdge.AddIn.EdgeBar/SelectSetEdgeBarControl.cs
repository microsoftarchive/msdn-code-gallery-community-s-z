using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace SolidEdge.AddIn.EdgeBar
{
    /// <summary>
    /// SelectSet EdgeBar control. 
    /// </summary>
    /// <remarks>
    /// Set BitmapID and Tooltip properties!
    /// Warning: The PropertyGrid frequently causes Solid Edge to terminate. Bad example control...
    /// </remarks>
    public partial class SelectSetEdgeBarControl : EdgeBarControl
    {
        public SelectSetEdgeBarControl()
        {
            InitializeComponent();
        }

        private void MyEdgeBarControl_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox
            SelectSetChanged(Application.ActiveSelectSet);
        }

        #region EdgeBarControl (SolidEdgeFramework.ISEDocumentEvents) overrides

        public override void AfterSave()
        {
            // Important to call base method!
            base.AfterSave();
        }

        public override void BeforeClose()
        {
            // Important to call base method!
            base.BeforeClose();

            comboBox.Items.Clear();
            propertyGrid.SelectedObject = null;
        }

        public override void BeforeSave()
        {
            // Important to call base method!
            base.BeforeSave();
        }

        public override void SelectSetChanged(object SelectSet)
        {
            base.SelectSetChanged(SelectSet);

            comboBox.Items.Clear();
            propertyGrid.SelectedObject = null;

            try
            {
                SolidEdgeFramework.SelectSet selectSet = (SolidEdgeFramework.SelectSet)SelectSet;
                List<object> list = new List<object>();

                if (selectSet.Count == 0)
                {
                    list.Add(Document);
                }
                else
                {
                    var items = selectSet.Cast<object>().ToArray();
                    foreach (var item in items)
                    {
                        list.Add(item);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];

                    string caption = GetComObjectFullyQualifiedName(item);
                    caption = String.Format("SelectSet[{0}] - {1}", i + 1, caption);
                    comboBox.Items.Add(new SelectSetComboBoxItem(caption, item));
                }

                comboBox.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region EdgeBarControl methods

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = null;

            SelectSetComboBoxItem item = comboBox.SelectedItem as SelectSetComboBoxItem;

            if (item != null)
            {
                // PropertyGrid may cause Solid Edge to terminate!
                // Training\Ziptie.par
                // Double click Protrusion2
                // Select 40 degree line
                propertyGrid.SelectedObject = item.SelectedObject;
            }
        }

        private string GetComObjectFullyQualifiedName(object o)
        {
            if (o == null) throw new ArgumentNullException();

            if (Marshal.IsComObject(o))
            {
                IDispatch dispatch = o as IDispatch;
                if (dispatch != null)
                {
                    ITypeLib typeLib = null;
                    ITypeInfo typeInfo = dispatch.GetTypeInfo(0, 0);
                    int index = 0;
                    typeInfo.GetContainingTypeLib(out typeLib, out index);
                    
                    string typeLibName = Marshal.GetTypeLibName(typeLib);
                    string typeInfoName = Marshal.GetTypeInfoName(typeInfo);

                    return String.Format("{0}.{1}", typeLibName, typeInfoName);
                }
            }

            return o.GetType().FullName;
        }

        #endregion
    }

    class SelectSetComboBoxItem
    {
        private string _caption;
        private object _selectedObject;

        public SelectSetComboBoxItem(string caption, object selectedObject)
        {
            _caption = caption;
            _selectedObject = selectedObject;
        }

        public string Caption { get { return _caption; } }
        public object SelectedObject { get { return _selectedObject; } }

        public override string ToString()
        {
            return _caption;
        }
    }
}
