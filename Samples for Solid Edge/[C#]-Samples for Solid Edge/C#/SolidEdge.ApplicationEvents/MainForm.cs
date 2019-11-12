using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace SolidEdge.ApplicationEvents
{
    public partial class MainForm : Form, SolidEdgeFramework.ISEApplicationEvents
    {
        private SolidEdgeFramework.Application _application = null;
        private Dictionary<IConnectionPoint, int> _connectionPoints = new Dictionary<IConnectionPoint, int>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register with OLE to handle concurrency issues on the current thread.
            OleMessageFilter.Register();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unhook events.
            UnhookEvents();
            _application = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void eventButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (eventButton.Checked)
                {
                    if (_application == null)
                    {
                        _application = SolidEdgeUtils.Connect(true);
                        _application.Visible = true;
                    }

                    HookEvents(_application, typeof(SolidEdgeFramework.ISEApplicationEvents).GUID);
                }
                else
                {
                    UnhookEvents();
                    _application = null;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            eventLogTextBox.Clear();
        }

        #region SolidEdgeFramework.ISEApplicationEvents

        // Note: Events are fired in a background thread. You cannot update the UI
        // "directly" from a background thread. See ControlExtensions.Do().
        // Thread.CurrentThread.GetApartmentState() will always be ApartmentState.MTA.
        // OleMessageFilter is not in effect in this thread for two reasons. 1) It's a
        // different thread. 2) It can't be because the ApartmentState = MTA.

        public void AfterActiveDocumentChange(object theDocument)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterCommandRun(int theCommandID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theCommandID);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterDocumentOpen(object theDocument)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1}, {2}, {3}, {4})", MethodBase.GetCurrentMethod().Name, theDocument, hDC, ModelToDC, Rect);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterDocumentSave(object theDocument)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterEnvironmentActivate(object theEnvironment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theEnvironment);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterNewDocumentOpen(object theDocument)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterNewWindow(object theWindow)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theWindow);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void AfterWindowActivate(object theWindow)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theWindow);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void BeforeCommandRun(int theCommandID)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theCommandID);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void BeforeDocumentClose(object theDocument)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void BeforeDocumentPrint(object theDocument, int hDC, ref double ModelToDC, ref int Rect)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1}, {2}, {3}, {4})", MethodBase.GetCurrentMethod().Name, theDocument, hDC, ModelToDC, Rect);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void BeforeDocumentSave(object theDocument)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theDocument);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void BeforeEnvironmentDeactivate(object theEnvironment)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theEnvironment);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        public void BeforeQuit()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}()", MethodBase.GetCurrentMethod().Name);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });

            UnhookEvents();
            _application = null;
        }

        public void BeforeWindowDeactivate(object theWindow)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}({1})", MethodBase.GetCurrentMethod().Name, theWindow);
            sb.AppendLine();

            eventLogTextBox.Do(ctl =>
            {
                ctl.AppendText(sb.ToString());
            });
        }

        #endregion

        #region "Event hooking-unhooking"

        private void HookEvents(object source, Guid eventGuid)
        {
            IConnectionPointContainer connectionPointContainer = null;
            IConnectionPoint connectionPoint = null;
            int cookie = 0;

            connectionPointContainer = source as IConnectionPointContainer;
            if (connectionPointContainer != null)
            {
                connectionPointContainer.FindConnectionPoint(eventGuid, out connectionPoint);
                if (connectionPoint != null)
                {
                    connectionPoint.Advise(this, out cookie);
                    if (cookie != 0)
                    {
                        _connectionPoints.Add(connectionPoint, cookie);
                    }
                    else
                    {
                        throw new System.Exception("Advisory connection between the connection point and the caller's sink object failed.");
                    }
                }
                else
                {
                    throw new System.Exception(String.Format("Connection point '{0}' not found.", eventGuid));
                }
            }
            else
            {
                throw new System.Exception("Source does not implement IConnectionPointContainer.");
            }

        }

        private void UnhookEvents()
        {
            Dictionary<IConnectionPoint, int>.Enumerator enumerator = _connectionPoints.GetEnumerator();

            while (enumerator.MoveNext())
            {
                enumerator.Current.Key.Unadvise(enumerator.Current.Value);
            }

            _connectionPoints.Clear();
        }

        #endregion
    }
}
