using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ArchiveManager
{
    public partial class Preview : Form
    {
        private readonly System.Media.SoundPlayer _soundPlayer = new System.Media.SoundPlayer();
        private bool _supportedFormat = true;

        public Preview()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the Preview class.
        /// </summary>
        /// <param name="fileName">The name of the file to view.</param>
        /// <param name="stream">The file stream object.</param>
        public Preview(string fileName, Stream stream)
            : this()
        {
            // Make sure the file it not empty and valid.
            if (stream.Length == 0)
            {
                MessageBox.Show("File is empty or invalid password", "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _supportedFormat = false;
                return;
            }

            // Reset the stream's possition.
            stream.Position = 0;
            // Get file name extension.
            string extension = Path.GetExtension(fileName).ToLower();
            switch (extension)
            {
                // Image?
                case ".jpeg":
                case ".jpg":
                case ".gif":
                case ".bmp":
                case ".png":
                case ".ico":
                    // Then show the picture control.
                    ShowImage(stream);
                    break;

                // Text file?
                case ".txt":
                    // Then show the textbox control.
                    ShowText(stream, false);
                    break;
                // Rich text file?
                case ".rtf":
                    // Then show the rich textbox control.
                    ShowText(stream, true);
                    break;

                // Sound file?
                case ".wav":
                    // Then play the sound file.
                    PlaySound(stream);
                    break;

                default: //if we don't know then tell the user and  show as text
                    if (MessageBox.Show("This file is an unknown format\nand may not preview properly\nWould you like to preview?", "Warning: Unknown file format", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ShowText(stream, false);
                    }
                    else
                        this._supportedFormat = false;
                    break;
            }  
        }

        /// <summary>
        /// Gets the boolean flag indicating whether the provided file is supported.
        /// </summary>
        public bool SupportedFormat
        {
            get { return _supportedFormat; }
        }

        /// <summary>
        /// Loads data from the specified stream and show the picture control.
        /// </summary>
        /// <param name="stream">The file stream object.</param>
        private void ShowImage(Stream stream)
        {
            try
            {
                // Load image from the stream.
                Image img = Image.FromStream(stream);
                pbPreview.Visible = true;
                // Adjust width and height.
                if (img.Width < 200)
                    this.Width = 200;
                else
                    this.Width = img.Width + 4;

                if (img.Height < 200)
                    this.Height = 200;
                else
                    this.Height = img.Height + 70;
                pbPreview.Image = Image.FromStream(stream);
                pbPreview.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            catch (Exception ex)
            {
                _supportedFormat = false;
                Util.ShowError(ex, "Error: Unable to Display the Image.");
                this.Close();
            }
        }

        /// <summary>
        /// Loads data from the specified stream and show the text box control.
        /// </summary>
        /// <param name="stream">The file stream object.</param>
        /// <param name="richContent">The boolean flag indicating whether to show the rich textbox.</param>
        private void ShowText(Stream stream, bool richContent)
        {
            if (richContent)
            {
                // Load text from the stream.
                txtPreview.LoadFile(stream, RichTextBoxStreamType.RichText);
                txtPreview.Visible = true;
            }
            else
            {
                // Load text from the stream.
                txtPreview.LoadFile(stream, RichTextBoxStreamType.PlainText);
                txtPreview.Visible = true;
            }
        }

        /// <summary>
        /// Loads data from the specified stream and play the sound data.
        /// </summary>
        /// <param name="stream">The file stream object.</param>
        private void PlaySound(Stream stream)
        {
            try
            {
                lblPlaying.Visible = true;
                this.Height = lblPlaying.Height + 74;
                btnClose.Text = "Stop";
                
                // Load sound data from the stream.
                _soundPlayer.LoadAsync();
                _soundPlayer.Stream = stream;
                // Play it.
                _soundPlayer.Play();
            }
            catch (Exception ex)
            {
                _supportedFormat = false;
                Util.ShowError(ex, "Error: Unable to play the Sound File.");
                this.Close();
            }
        }

        /// <summary>
        /// Handles the form's Closing event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            // Stop the sound before leaving.
            _soundPlayer.Stop();
        }
    }
}