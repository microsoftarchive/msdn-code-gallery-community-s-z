using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SolidEdge.UnitsOfMeasure
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(MainForm_Load_Async));
        }

        /// <summary>
        /// Asynchronous version of MainForm_Load.
        /// </summary>
        private void MainForm_Load_Async()
        {
            SolidEdgeFramework.Application application = null;
            SolidEdgeFramework.Documents documents = null;

            // Connect to or start Solid Edge.
            application = SolidEdgeUtils.Connect(true);

            // Ensure Solid Edge is visible.
            application.Visible = true;

            // Get a reference to the Documents collection.
            documents = application.Documents;

            if (documents.Count == 0)
            {
                documents.Add("SolidEdge.PartDocument");
            }

            externalPropertyGrid.SelectedObject = new ExternalExample();
            internalPropertyGrid.SelectedObject = new InternalExample();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void externalPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            externalPropertyGrid.Refresh();
        }

        private void internalPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            internalPropertyGrid.Refresh();
        }
    }
}
