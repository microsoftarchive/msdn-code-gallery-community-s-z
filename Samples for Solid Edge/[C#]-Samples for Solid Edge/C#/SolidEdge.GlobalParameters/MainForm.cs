using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SolidEdge.GlobalParameters
{
    public partial class MainForm : Form
    {
        private SolidEdgeFramework.Application _application = null;
        private ToolStripSpringTextBox _textToolStripTextBox = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            booleanToolStripComboBox.Visible = false;
            

            _textToolStripTextBox = new ToolStripSpringTextBox();
            _textToolStripTextBox.Visible = false;

            int index = toolStrip1.Items.IndexOf(textToolStripTextBox);
            toolStrip1.Items.Remove(textToolStripTextBox);
            textToolStripTextBox = null;
            toolStrip1.Items.Insert(index, _textToolStripTextBox);

            booleanToolStripComboBox.Items.AddRange(new object[] { true, false });

            MethodInvoker methodInvoker = new MethodInvoker(RefreshGlobalParametersListView);
            BeginInvoke(methodInvoker);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                BeginInvoke(new MethodInvoker(RefreshGlobalParametersListView));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            ListViewItem listViewItem = lvGlobalParameters.SelectedItem;

            try
            {
                if (listViewItem != null)
                {
                    SolidEdgeFramework.ApplicationGlobalConstants globalConstant = (SolidEdgeFramework.ApplicationGlobalConstants)listViewItem.Tag;
                    Type valueType = listViewItem.SubItems[2].Tag as Type;
                    object globalValue = null;
                    Type globalValueType = null;

                    if (typeof(bool).Equals(valueType))
                    {
                        globalValue = booleanToolStripComboBox.SelectedItem;
                    }
                    else if (typeof(string).Equals(valueType))
                    {
                        globalValue = _textToolStripTextBox.Text;
                    }
                    else if (typeof(int).Equals(valueType))
                    {
                        globalValue = int.Parse(_textToolStripTextBox.Text);
                    }

                    if (globalValue != null)
                    {
                        _application.SetGlobalParameter(globalConstant, globalValue);

                        globalValueType = globalValue.GetType();

                        listViewItem.SubItems[1].Text = String.Format("{0}", globalValue);
                        listViewItem.SubItems[1].Tag = globalValue;
                        listViewItem.SubItems[2].Text = String.Format("{0}", globalValueType);
                        listViewItem.SubItems[2].Tag = globalValueType;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lvGlobalParameters.SelectedItem = listViewItem;
        }

        private SolidEdgeFramework.ApplicationGlobalConstants[] GetAllApplicationGlobalConstants()
        {
            List<SolidEdgeFramework.ApplicationGlobalConstants> list = new List<SolidEdgeFramework.ApplicationGlobalConstants>();
            FieldInfo[] fieldInfos = typeof(SolidEdgeFramework.ApplicationGlobalConstants).GetFields();

            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (fieldInfo.IsSpecialName) continue;
                list.Add((SolidEdgeFramework.ApplicationGlobalConstants)fieldInfo.GetRawConstantValue());
            }

            return list.OrderBy(x => x.ToString()).ToArray();
        }

        private void RefreshGlobalParametersListView()
        {
            if (lvGlobalParameters.Items.Count == 0)
            {
                List<ListViewItem> listViewItems = new List<ListViewItem>();
                SolidEdgeFramework.ApplicationGlobalConstants[] appGlobalConstants = GetAllApplicationGlobalConstants();

                foreach (SolidEdgeFramework.ApplicationGlobalConstants appGlobalConstant in appGlobalConstants)
                {
                    string[] itemValues = {
                                          appGlobalConstant.ToString(),
                                          String.Empty,
                                          String.Empty,
                                          String.Format("SolidEdgeFramework.ApplicationGlobalConstants.{0}", appGlobalConstant.ToString())
                                      };

                    itemValues[0] = itemValues[0].Replace("seApplicationGlobal", String.Empty).CamelCaseToWordString();

                    ListViewItem listViewItem = new ListViewItem(itemValues);
                    listViewItem.ImageIndex = 0;
                    listViewItem.Tag = appGlobalConstant;
                    listViewItems.Add(listViewItem);
                }

                lvGlobalParameters.Items.AddRange(listViewItems.ToArray());
                lvGlobalParameters.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                lvGlobalParameters.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                lvGlobalParameters.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            try
            {
                if (_application == null)
                {
                    // Register with OLE to handle concurrency issues on the current thread.
                    OleMessageFilter.Register();

                    // Connect to or start Solid Edge.
                    _application = SolidEdgeUtils.Connect(true);

                    // Ensure Solid Edge GUI is visible.
                    _application.Visible = true;
                }

                foreach (ListViewItem listViewItem in lvGlobalParameters.Items)
                {
                    SolidEdgeFramework.ApplicationGlobalConstants appGlobalConstant = (SolidEdgeFramework.ApplicationGlobalConstants)listViewItem.Tag;
                    
                    object globalValue = null;
                    object globalValueType = null;

                    try
                    {
                        _application.GetGlobalParameter(appGlobalConstant, ref globalValue);
                    }
                    catch (System.Exception ex)
                    {
                        globalValue = ex;
                        globalValueType = ex.GetType();
                    }

                    if (globalValue != null)
                    {
                        if (globalValueType == null)
                        {
                            globalValueType = globalValue.GetType();
                        }
                    }

                    listViewItem.SubItems[1].Text = String.Format("{0}", globalValue);
                    listViewItem.SubItems[1].Tag = globalValue;
                    listViewItem.SubItems[2].Text = String.Format("{0}", globalValueType);
                    listViewItem.SubItems[2].Tag = globalValueType;
                }

                lvGlobalParameters.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch
            {
#if DEBUG
                System.Diagnostics.Debugger.Break();
#endif
                throw;
            }
        }

        private void lvGlobalParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            booleanToolStripComboBox.Visible = false;
            _textToolStripTextBox.Visible = false;
            editButton.Enabled = false;

            ListViewItem item = lvGlobalParameters.SelectedItem;

            if (item != null)
            {
                object parameterValue = item.SubItems[1].Tag;
                Type valueType = item.SubItems[2].Tag as Type;

                if (typeof(bool).Equals(valueType))
                {
                    booleanToolStripComboBox.Visible = true;
                    booleanToolStripComboBox.SelectedItem = item.SubItems[1].Tag;
                    editButton.Enabled = true;
                }
                else if (typeof(string).Equals(valueType))
                {
                    _textToolStripTextBox.InputType = valueType;
                    _textToolStripTextBox.Visible = true;
                    _textToolStripTextBox.Text = parameterValue.ToString();
                    editButton.Enabled = true;
                }
                else if (typeof(int).Equals(valueType))
                {
                    _textToolStripTextBox.InputType = valueType;
                    _textToolStripTextBox.Visible = true;
                    _textToolStripTextBox.Text = parameterValue.ToString();
                    editButton.Enabled = true;
                }


                System.Exception exception = lvGlobalParameters.SelectedItem.SubItems[1].Tag as System.Exception;
            }
        }
    }
}
