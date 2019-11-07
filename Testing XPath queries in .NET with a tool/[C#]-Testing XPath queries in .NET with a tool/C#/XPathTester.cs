using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using System.Xml.XPath;


namespace XPathHero.Forms
{
    public partial class XPathTester : Form
    {        

        public string SourceFileName { get; set; }


        XPathDocument document;

        public XPathTester()
        {
            InitializeComponent();
        }

        #region Event: XPathTester_Load
        private void XPathTester_Load(object sender, EventArgs e)
        {
            this.Width = 1083;
            this.splitContainer3.SplitterDistance = 883;
            this.splitContainer4.SplitterDistance = 883;
        }
        #endregion

        #region Event:  tsbOpenFile_Click
        //User clicked on OpenFile
        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            OpenXmlFile();
        }
        #endregion

        #region Event:  AboutMenuItem_Click
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutThisTool about = new AboutThisTool();

            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
        }
        #endregion

        #region Event:  btnCheck_Click
        private void btnCheck_Click(object sender, EventArgs e)
        {
            ResultBox.Text = "";
            string xpath = XPathQuery.Text;

            if (SourceBrowser.Document == null)
            {
                MessageBox.Show("Select a XML file to test the XPath", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(xpath))
            {
                MessageBox.Show("Enter a XPath Query.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                XPathNavigator navigator = document.CreateNavigator();

                XPathExpression expression = XPathExpression.Compile(xpath);

                string result = Evaluate(expression, navigator);

                ResultBox.Text = result;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event:  OpenFileMenuItem_Click
        //User clicked on menu item oOpenFile
        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenXmlFile();
        }
        #endregion


        #region Function:  OpenXmlFile
        //Open XML file
        private void OpenXmlFile()
        {
            ResultBox.BackColor = SystemColors.Info;      
            ResultBox.Text = "";
            tsslFile.Text = "";

            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SourceFileName = dialog.FileName;

                XPathNavigator nav;
                document = new XPathDocument(SourceFileName);
                nav = document.CreateNavigator();
                nav.MoveToRoot();

                ShowXmlFile();
            }

            
        }
        #endregion

        #region Function:  ShowXmlFile
        //Display XML file in TabControl 
        public void ShowXmlFile()
        {
            Uri uri = new Uri(SourceFileName);
            SourceBrowser.Url = uri;
            
            TabXml.SelectedTab = tabSource;            

            tsslFile.Text = string.Format("file: {0}", SourceFileName);
            ResultBox.Text = "";
        }
        #endregion

        #region  Function:  Evaluate
        public string Evaluate(XPathExpression expression, XPathNavigator navigator)
        {
            string result = null;

            try
            {
                switch (expression.ReturnType)
                {
                    case XPathResultType.Number:

                        result = String.Format("Result: {0}", navigator.Evaluate(expression));
                        break;

                    case XPathResultType.NodeSet:

                        StringBuilder resultBldr = new StringBuilder();

                        XPathNodeIterator nodes = navigator.Select(expression);

                        //Move to first selected node
                        nodes.MoveNext();                        

                        switch (nodes.Current.NodeType)
                        {
                            case XPathNodeType.Attribute:

                                resultBldr.AppendFormat("Result: {0} Attribute(s) selected", nodes.Count);
                                break;
                            case XPathNodeType.Element:

                                resultBldr.AppendFormat("Result: {0} Element(s) selected", nodes.Count);
                                break;
                        }
                        
                        resultBldr.AppendFormat("\n\n");                     

                        do
                        {
                            resultBldr.AppendFormat("{0}\n", nodes.Current.OuterXml);
                        } while (nodes.MoveNext());

                        result = resultBldr.ToString();

                        break;

                    case XPathResultType.Boolean:

                        bool blnResult = (bool)navigator.Evaluate(expression);
                        result = String.Format("Result: {0}", blnResult.ToString());

                        break;

                    case XPathResultType.String:

                        result = String.Format("Result: {0}", navigator.Evaluate(expression));
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
        #endregion
             
    }
}
