using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SolidEdge.Assembly.BOM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register with OLE to handle concurrency issues on the current thread.
            OleMessageFilter.Register();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            StringBuilder buffer = new StringBuilder();

            // Column Headers
            for (int i = 0; i < lvBOM.Columns.Count; i++)
            {
                buffer.Append(lvBOM.Columns[i].Text);
                buffer.Append("\t");
            }

            buffer.Append(Environment.NewLine);

            // Rows
            for (int i = 0; i < lvBOM.Items.Count; i++)
            {
                if (lvBOM.Items[i].Selected)
                {
                    for (int j = 0; j < lvBOM.Columns.Count; j++)
                    {
                        buffer.Append(lvBOM.Items[i].SubItems[j].Text);
                        buffer.Append("\t");
                    }
                    buffer.Append(Environment.NewLine);
                }
            }

            Clipboard.SetText(buffer.ToString());
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvBOM.BeginUpdate();

            foreach (ListViewItem item in lvBOM.Items)
            {
                item.Selected = true;
            }

            lvBOM.EndUpdate();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void RefreshListView()
        {
            AppDomain interopDomain = null;
            BomItem[] bomItems = null;

            try
            {
                var thread = new System.Threading.Thread(() =>
                    {
                        // Create a custom AppDomain to do COM Interop.
                        interopDomain = AppDomain.CreateDomain("Interop Domain");

                        Type proxyType = typeof(InteropProxy);

                        // Create a new instance of InteropProxy in the isolated application domain.
                        InteropProxy interopProxy = interopDomain.CreateInstanceAndUnwrap(
                            proxyType.Assembly.FullName,
                            proxyType.FullName) as InteropProxy;

                        bomItems = interopProxy.GetBomItems();
                    });

                thread.SetApartmentState(System.Threading.ApartmentState.STA);
                thread.Start();
                thread.Join();
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (BomItem bomItem in bomItems)
                {
                    ListViewItem listViewItem = new ListViewItem(String.Format("{0}", bomItem.Level));
                    listViewItem.SubItems.Add(bomItem.DocumentNumber);
                    listViewItem.SubItems.Add(bomItem.Revision);
                    listViewItem.SubItems.Add(bomItem.Title);
                    listViewItem.SubItems.Add(String.Format("{0}", bomItem.Quantity));
                    listViewItem.SubItems.Add(bomItem.FileName);
                    listViewItem.ImageIndex = bomItem.IsSubassembly ? 0 : 1;
                    listViewItems.Add(listViewItem);
                }

                lvBOM.Items.Clear();
                lvBOM.Items.AddRange(listViewItems.ToArray());
                lvBOM.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (interopDomain != null)
                {
                    // Unload the Interop AppDomain. This will automatically free up any COM references.
                    AppDomain.Unload(interopDomain);
                }
            }
        }
    }
}
