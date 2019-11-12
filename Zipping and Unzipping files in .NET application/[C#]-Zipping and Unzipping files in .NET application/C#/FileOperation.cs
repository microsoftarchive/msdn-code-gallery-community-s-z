using System.Collections.Generic;
using System.Windows.Forms;
using ComponentPro.IO;

namespace ArchiveManager
{
    /// <summary>
    /// A form that shows issues and let user decide what to do while uploading or download multiple files.
    /// </summary>
    public partial class FileOperation : Form
    {
        private Dictionary<System.Windows.Forms.Button, TransferConfirmNextActions> _btns; // A list of Button with transfer action pair.
        private readonly Dictionary<TransferConfirmReason, object> _skipTypes = new Dictionary<TransferConfirmReason, object>(); // Skipped transfer problem types.
        private TransferConfirmEventArgs _oldEvt; // Maintain the last event arguments.

        private bool _overwriteAll; // Overwrite all files?
        private bool _overwriteOlder; // Overwrite older files?
        private bool _overwriteDifferentSize; // Overwrite files that have different file size?

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FileOperation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the form.
        /// </summary>
        public void Init()
        {
            if (_btns == null)
            {
                _btns = new Dictionary<System.Windows.Forms.Button, TransferConfirmNextActions>();
                _btns.Add(btnOverwrite, TransferConfirmNextActions.Overwrite);
                _btns.Add(btnOverwriteAll, TransferConfirmNextActions.Overwrite);
                _btns.Add(btnOverwriteDiffSize, TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes);
                _btns.Add(btnOverwriteOlder, TransferConfirmNextActions.CheckAndOverwriteOlderFiles);
                _btns.Add(btnRename, TransferConfirmNextActions.Rename);
                _btns.Add(btnSkip, TransferConfirmNextActions.Skip);
                _btns.Add(btnSkipAll, TransferConfirmNextActions.Skip);
                _btns.Add(btnFollowLink, TransferConfirmNextActions.FollowLink);
                _btns.Add(btnRetry, TransferConfirmNextActions.Retry);
                _btns.Add(btnCancel, TransferConfirmNextActions.Cancel);
            }

            _skipTypes.Clear();
            _overwriteAll = false;
            _overwriteOlder = false;
            _overwriteDifferentSize = false;
        }

        /// <summary>
        /// Shows the form.
        /// </summary>
        /// <param name="parent">The parent form.</param>
        /// <param name="evt">The event arguments.</param>
        public void Show(Form parent, TransferConfirmEventArgs evt)
        {
            // If it's in the skipped type list, skip it.
            if (_skipTypes.ContainsKey(evt.ConfirmReason))
            {
                evt.NextAction = TransferConfirmNextActions.Skip;
                return;
            }

            // If the problem is file already exists?
            if (evt.ConfirmReason == TransferConfirmReason.FileAlreadyExists)
            {
                // Overwrite all?
                if (_overwriteAll)
                {
                    evt.NextAction = TransferConfirmNextActions.Overwrite;
                    return;
                }

                // Overwrite if files have different sizes?
                if (_overwriteDifferentSize)
                {
                    evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes;
                    return;
                }

                // Overwrite older files?
                if (_overwriteOlder)
                {
                    evt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles;
                    return;
                }

                // format the text according to TransferState (Downloading or Uploading)
                const string messageFormat = Messages.OverwriteFileConfirm;
                txtMessage.Text = string.Format(messageFormat,
                                                evt.DestinationFileInfo.FullName, evt.DestinationFileInfo.Length,
                                                evt.DestinationFileInfo.LastWriteTime,
                                                evt.SourceFileInfo.FullName, evt.SourceFileInfo.Length,
                                                evt.SourceFileInfo.LastWriteTime);
            }
            else
            {
                // Show the exception message.
                txtMessage.Text = evt.Exception.Message;

                if (evt.Exception.InnerException != null)
                {
                    txtMessage.Text += "\r\nReason: " + evt.Exception.InnerException.Message;
                }                    
            }

            _oldEvt = evt;

            // Only show available action buttons.
            ArrangeButtons(evt);

            ShowDialog(parent);
        }

        /// <summary>
        /// Arranges buttons.
        /// </summary>
        /// <param name="evt">The event arguments.</param>
        private void ArrangeButtons(TransferConfirmEventArgs evt)
        {
            int buttonHeight = 0;
            int y = txtMessage.Top;

            foreach (KeyValuePair<System.Windows.Forms.Button, TransferConfirmNextActions> en in _btns)
            {
                bool b = evt.CanPerform(en.Value);
                en.Key.Visible = b;
                if (buttonHeight == 0)
                    buttonHeight = en.Key.Height;
                if (!b) continue;
                en.Key.Top = y;
                y += buttonHeight + 3;
            }
        }

        /// <summary>
        /// Handles the Cancel button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Cancel;
            Close();
        }

        /// <summary>
        /// Handles the Skip button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnSkip_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Skip;
            Close();
        }

        /// <summary>
        /// Handles the Skip All button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnSkipAll_Click(object sender, System.EventArgs e)
        {
            _skipTypes.Add(_oldEvt.ConfirmReason, null);

            _oldEvt.NextAction = TransferConfirmNextActions.Skip;
            Close();
        }

        /// <summary>
        /// Handles the Retry button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRetry_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Retry;
            Close();
        }

        /// <summary>
        /// Handles the Rename button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRename_Click(object sender, System.EventArgs e)
        {
            string oldName = _oldEvt.DestinationFileSystem.GetFileName(_oldEvt.DestinationFileInfo.Name);
            NewNamePrompt formNewName = new NewNamePrompt(oldName);

            DialogResult result = formNewName.ShowDialog(this);

            string newName = formNewName.NewName;

            if (result != DialogResult.OK || newName.Length == 0 || newName == oldName)
                return;

            _oldEvt.NextAction = TransferConfirmNextActions.Rename;
            _oldEvt.NewName = newName;
            Close();
        }

        /// <summary>
        /// Handles the Overwrite button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOverwrite_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Overwrite;
            Close();
        }

        /// <summary>
        /// Handles the OverwriteAll button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOverwriteAll_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.Overwrite;
            _overwriteAll = true;
            Close();
        }

        /// <summary>
        /// Handles the OverwriteOlder button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOverwriteOlder_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteOlderFiles;
            _overwriteOlder = true;
            Close();
        }

        /// <summary>
        /// Handles the OverwriteDiffSize button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOverwriteDiffSize_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.CheckAndOverwriteFilesWithDifferentSizes;
            _overwriteDifferentSize = true;
            Close();
        }

        /// <summary>
        /// Handles the Follow Link button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnFollowLink_Click(object sender, System.EventArgs e)
        {
            _oldEvt.NextAction = TransferConfirmNextActions.FollowLink;
            Close();
        }
    }
}