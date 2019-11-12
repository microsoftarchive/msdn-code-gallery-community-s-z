#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using MSDN.Html.Editor;

#endregion

namespace MSDN.Html.Client
{
    public partial class EditorTestForm : Form
    {

        // working directory variable
        private string workingDirectory = string.Empty;

        // default constructor
        public EditorTestForm()
        {
            InitializeComponent();
        }

        #region Event Processing

        private void bToolbar_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.ToolbarVisible = !this.htmlEditorControl.ToolbarVisible;
            this.htmlEditorControl.Focus();
        }

        private void bBackground_Click(object sender, System.EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = dialog.Color;
                    this.htmlEditorControl.BodyBackColor = color;
                }
            }
            this.htmlEditorControl.Focus();
        }

        private void bForeground_Click(object sender, System.EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = dialog.Color;
                    this.htmlEditorControl.BodyForeColor =  color;
                }		
            }
            this.htmlEditorControl.Focus();
        }

        private void bEditHTML_Click(object sender, System.EventArgs e)
        {	
            this.htmlEditorControl.HtmlContentsEdit();
            this.htmlEditorControl.Focus();
        }

        private void bViewHtml_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.HtmlContentsView();
            this.htmlEditorControl.Focus();
        }

        private void bStyle_Click(object sender, System.EventArgs e)
        {
            string cssFile = Path.GetFullPath(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Resources\default.css");
            if (File.Exists(cssFile))
            {
                this.htmlEditorControl.StylesheetUrl = cssFile;
                MessageBox.Show(this, cssFile, "Style Sheet Linked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, cssFile, "Style Sheet Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.htmlEditorControl.Focus();
        }

        private void bScript_Click(object sender, System.EventArgs e)
        {
            string scriptFile = Path.GetFullPath(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Resources\default.js");
            if (File.Exists(scriptFile))
            {
                this.htmlEditorControl.ScriptSource = scriptFile;
                MessageBox.Show(this, scriptFile, "Script Source Linked", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, scriptFile, "Script Source Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.htmlEditorControl.Focus();
        }

        // obtains the text resource from an embedded file
        private string GetResourceText(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resource = string.Empty;

            // resources are named using a fully qualified name
            string streamName = this.GetType().Namespace + @"." + filename;
            using (Stream stream = assembly.GetManifestResourceStream(streamName))
            {
                // read the contents of the embedded file
                using (StreamReader reader = new StreamReader(stream))
                {
                    resource = reader.ReadToEnd();;
                }
            }
            return resource;
        }

        private void readonlyCheck_CheckedChanged(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.ReadOnly = this.readonlyCheck.Checked;
            this.htmlEditorControl.Focus();
        }

        private void bOverWrite_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.ToggleOverWrite();
            this.htmlEditorControl.Focus();
        }

        private void bSaveHtml_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.SaveFilePrompt();
            this.htmlEditorControl.Focus();
        }

        private void bOpenHtml_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.OpenFilePrompt();
            this.htmlEditorControl.Focus();
        }

        private void bHeading_Click(object sender, System.EventArgs e)
        {
            int headingRef = this.listHeadings.SelectedIndex + 1;
            if (headingRef > 0)
            {
                HtmlHeadingType headingType = (HtmlHeadingType)headingRef;
                this.htmlEditorControl.InsertHeading(headingType);
            }
            this.htmlEditorControl.Focus();
        }

        private void bFormatted_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.InsertFormattedBlock();
        }

        private void bNormal_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.InsertNormalBlock();
        }

        private void bInsertHtml_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.InsertHtmlPrompt();	
            this.htmlEditorControl.Focus();
        }

        private void bImage_Click(object sender, System.EventArgs e)
        {
            // set initial value states
            string fileName = string.Empty;
            string filePath = string.Empty;

            // define the file dialog
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Image";
                dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                dialog.CheckFileExists = true;
                if (workingDirectory != String.Empty) dialog.InitialDirectory = workingDirectory; 
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = Path.GetFileName(dialog.FileName);
                    filePath = Path.GetFullPath(dialog.FileName);
                    workingDirectory = Path.GetDirectoryName(dialog.FileName);

                    if (fileName != "")
                    {
                        // have a path for a image I can insert
                        this.htmlEditorControl.InsertImage(filePath);
                    }
                }
            }
            this.htmlEditorControl.Focus();
        }

        private void bBasrHref_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.AutoWordWrap = !this.htmlEditorControl.AutoWordWrap;
            this.htmlEditorControl.Focus();
        }

        private void bPaste_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.InsertTextPrompt();
            this.htmlEditorControl.Focus();
        }

        // set the flat style of the dialog based on the user setting
        private void SetFlatStyleSystem(Control parent) 
        {
            // iterate through all controls setting the flat style
            foreach(Control control in parent.Controls) 
            {
                // Only these controls have a FlatStyle property
                ButtonBase button = control as ButtonBase;
                GroupBox group = control as GroupBox;
                Label label = control as Label;
                TextBox textBox = control as TextBox;
                if( button != null ) button.FlatStyle = FlatStyle.System;
                else if( group != null ) group.FlatStyle = FlatStyle.System;
                else if( label != null ) label.FlatStyle = FlatStyle.System;

                // Set contained controls FlatStyle, too
                SetFlatStyleSystem(control);
            }
        }

        private void EditorTestForm_Load(object sender, System.EventArgs e)
        {
            SetFlatStyleSystem(this);
        }

        private void bMicrosoft_Click(object sender, System.EventArgs e)
        {
            this.htmlEditorControl.NavigateToUrl(@"http://msdn.microsoft.com");
        }

        private void bUrl_Click(object sender, System.EventArgs e)
        {
            string href = Microsoft.VisualBasic.Interaction.InputBox("Enter Href for Navigation:", "Href", string.Empty, -1, -1);
            if (href != string.Empty) this.htmlEditorControl.LoadFromUrl(href);
        }

        private void htmlEditorControl_HtmlException(object sender, MSDN.Html.Editor.HtmlExceptionEventArgs args)
        {
            // obtain the message and operation
            // concatenate the message with any inner message
            string operation = args.Operation;
            Exception ex = args.ExceptionObject;
            string message = ex.Message;
            if (ex.InnerException != null)
            {
                if (ex.InnerException.Message != null)
                {
                    message = string.Format("{0}\n{1}", message, ex.InnerException.Message);
                }
            }
            // define the title for the internal message box
            string title;
            if (operation == null || operation == string.Empty)
            {
                title = "Unknown Error";
            }
            else
            {
                title = operation + " Error";
            }
            // display the error message box
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bLoadFile_Click(object sender, System.EventArgs e)
        {
            // create an open file dialog
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                // define the dialog structure
                dialog.DefaultExt = "html";
                dialog.Title = "Open FIle";
                dialog.AddExtension = true;
                dialog.Filter = "Html files (*.html,*.htm)|*.html;*htm|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;
                if (workingDirectory != String.Empty) dialog.InitialDirectory = workingDirectory; 
                // show the dialog and see if the users enters OK
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    this.htmlEditorControl.LoadFromFile(dialog.FileName);
                }
            }
        }

        private void htmlEditorControl_HtmlNavigation(object sender, MSDN.Html.Editor.HtmlNavigationEventArgs e)
        {
            e.Cancel = false;
        }

        #endregion

    }
}
