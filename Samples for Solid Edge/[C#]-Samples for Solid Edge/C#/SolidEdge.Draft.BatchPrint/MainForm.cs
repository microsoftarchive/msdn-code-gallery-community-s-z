using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SolidEdge.Draft.BatchPrint
{
    public partial class MainForm : Form
    {
        private FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();

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
            toolStripStatusLabel.Text = "Connecting to Solid Edge to get a copy of DraftPrintUtility settings.";

            SolidEdgeFramework.Application application = null;

            try
            {
                // Connect to or start Solid Edge.
                application = ConnectToSolidEdge(true);

                // Make sure user can see Solid Edge.
                application.Visible = true;

                // Minimize Solid Edge.
                //application.WindowState = (int)FormWindowState.Minimized;

                // Get a copy of the settings for use as a template.
                customListView.DraftPrintUtilityOptions = new DraftPrintUtilityOptions(application);

                // Enable UI.
                toolStrip.Enabled = true;
                customListView.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (application != null)
                {
                    Marshal.ReleaseComObject(application);
                }
            }

            toolStripStatusLabel.Text = "Tip: You can drag folders and files into the ListView.";
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            _folderBrowserDialog.ShowNewFolderButton = false;

            if (_folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                SearchOption searchOption = SearchOption.TopDirectoryOnly;
                DirectoryInfo directoryInfo = new DirectoryInfo(_folderBrowserDialog.SelectedPath);
                DirectoryInfo[] subDirectoryInfos = directoryInfo.GetDirectories();

                // If directory has subdirectories, ask user if we should process those as well.
                if (subDirectoryInfos.Length > 0)
                {
                    // Build the question to ask the user.
                    string message = String.Format("'{0}' contains subdirectories. Would you like to include those in the search?", directoryInfo.FullName);

                    // Ask the question.
                    switch (MessageBox.Show(message, "Process subdirectories?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            searchOption = SearchOption.AllDirectories;
                            break;
                        case DialogResult.Cancel:
                            // Bail out of entire OnDragDrop().
                            return;
                    }
                }

                customListView.AddFolder(directoryInfo, searchOption);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // Not necessary but we'll later highlight each one as we print them.
            foreach (ListViewItem listViewItem in customListView.Items)
            {
                listViewItem.Selected = false;
            }

            // Loop through all of the files and print them.
            foreach (ListViewItem listViewItem in customListView.Items)
            {
                // GUI sugar.  Highligh the item.
                listViewItem.Selected = true;

                string filename = listViewItem.Text;
                DraftPrintUtilityOptions options = (DraftPrintUtilityOptions)listViewItem.Tag;

                AppDomain interopDomain = null;

                try
                {
                    toolStripStatusLabel.Text = "Setting up an isolated application domation for COM Interop.";

                    var thread = new Thread(() =>
                    {
                        // Create a custom AppDomain to do COM Interop.
                        interopDomain = AppDomain.CreateDomain("Interop Domain");

                        Type proxyType = typeof(InteropProxy);

                        // Create a new instance of InteropProxy in the isolated application domain.
                        InteropProxy interopProxy = interopDomain.CreateInstanceAndUnwrap(
                            proxyType.Assembly.FullName,
                            proxyType.FullName) as InteropProxy;

                        toolStripStatusLabel.Text = String.Format("Printing '{0}' in isolated application.", filename);

                        // Start the printing process in the isolated application domain.
                        interopProxy.DoPrint(filename, options);
                    });

                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    listViewItem.Selected = false;

                    if (interopDomain != null)
                    {
                        // Unload the Interop AppDomain. This will automatically free up any COM references.
                        AppDomain.Unload(interopDomain);
                    }
                }
            }

            toolStripStatusLabel.Text = String.Empty;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> list = new List<object>();

            foreach (ListViewItem listViewItem in customListView.Items)
            {
                if (listViewItem.Selected)
                {
                    list.Add(listViewItem.Tag);
                }
            }

            propertyGrid.SelectedObjects = list.ToArray();
        }

        /// <summary>
        /// Connects to a running instance of Solid Edge.
        /// </summary>
        static SolidEdgeFramework.Application ConnectToSolidEdge()
        {
            return ConnectToSolidEdge(false);
        }

        /// <summary>
        /// Connects to a running instance of Solid Edge with an option to start if not running.
        /// </summary>
        static SolidEdgeFramework.Application ConnectToSolidEdge(bool startIfNotRunning)
        {
            try
            {
                // Attempt to connect to a running instance of Solid Edge.
                return (SolidEdgeFramework.Application)
                    Marshal.GetActiveObject("SolidEdge.Application");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                // Failed to connect.
                if (ex.ErrorCode == -2147221021 /* MK_E_UNAVAILABLE */)
                {
                    if (startIfNotRunning)
                    {
                        // Start Solid Edge.
                        return (SolidEdgeFramework.Application)
                            Activator.CreateInstance(Type.GetTypeFromProgID("SolidEdge.Application"));
                    }
                    else
                    {
                        throw;
                    }
                }
                else
                {
                    throw;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
