using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace SplitMultiPageTiff
{
    /// <summary>
    /// This class creates multiple tiff files from single multipage tiff file and store it in the
    /// specified output directory. It also reads the tiff file properties
    /// </summary>
    public partial class SplitMultiPageTiff : Form
    {
        //Constructor
        public SplitMultiPageTiff()
        {
            InitializeComponent();
        }

        #region Split Tiff file

        /// <summary>
        /// This method is called when user clicks on the SplitTiff button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSplitTiff_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateSelectedFile())
                    return;

                // Split the multipage Tiff file
                Split(txtTiffFilePath.Text, txtOutPutDir.Text);
            }
            catch
            {
                MessageBox.Show("Error occured while splitting a Tiff file.");
            }

            MessageBox.Show(@"Splitted Files stored at " + txtOutPutDir.Text);
        }

        private void Split(string pstrInputFilePath, string pstrOutputPath)
        {
            //Get the frame dimension list from the image of the file and
            Image tiffImage = Image.FromFile(pstrInputFilePath);
            //get the globally unique identifier (GUID)
            Guid objGuid = tiffImage.FrameDimensionsList[0];
            //create the frame dimension
            FrameDimension dimension = new FrameDimension(objGuid);
            //Gets the total number of frames in the .tiff file
            int noOfPages = tiffImage.GetFrameCount(dimension);

            ImageCodecInfo encodeInfo = null;
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < imageEncoders.Length; j++)
            {
                if (imageEncoders[j].MimeType == "image/tiff")
                {
                    encodeInfo = imageEncoders[j];
                    break;
                }
            }

            // Save the tiff file in the output directory.
            if (!Directory.Exists(pstrOutputPath))
                Directory.CreateDirectory(pstrOutputPath);

            foreach (Guid guid in tiffImage.FrameDimensionsList)
            {
                for (int index = 0; index < noOfPages; index++)
                {
                    FrameDimension currentFrame = new FrameDimension(guid);
                    tiffImage.SelectActiveFrame(currentFrame, index);
                    tiffImage.Save(string.Concat(pstrOutputPath, @"\", index, ".TIF"), encodeInfo, null);
                }
            }
        }

        /// <summary>
        /// This method validates the inputs
        /// </summary>
        /// <returns>return true if the inputs are valid</returns>
        private bool ValidateSelectedFile()
        {

            // Validate the file path for the selected file.
            if (txtTiffFilePath.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select Input file.");
                return false;
            }
            // Validate the output folder path
            if (txtOutPutDir.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select Output folder.");
                return false;
            }

            // Validate whether the selected file is tiff file or not
            if (!txtTiffFilePath.Text.ToLower().EndsWith(".tif") && !txtTiffFilePath.Text.ToLower().EndsWith(".tiff"))
            {
                MessageBox.Show("Please select Valid tiff file");
                return false;
            }

            // Validate whether file exists or not
            if (!File.Exists(txtTiffFilePath.Text))
            {
                MessageBox.Show("File doesn't exist at the specified location");
                return false;
            }

            return true;
        }

        /// <summary>
        /// This method will open the file dialog to select the tif file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Show the open dialog.
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Tiff File";
            openDialog.Filter = "Image Files(*.TIF)|*.TIF|Image Files(*.TIFF)|*.TIFF";
            openDialog.FilterIndex = 0;
            openDialog.RestoreDirectory = true;
            DialogResult dlgResult = new DialogResult();
            //To show the dialog box everytime ok is clicked on error keep it in while.

            dlgResult = openDialog.ShowDialog();
            switch (dlgResult)
            {
                case DialogResult.OK:
                    // Get the path for the selected file
                    txtTiffFilePath.Text = openDialog.FileName;
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method will open the folder dialog to selected the output folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog lobjDialog = new FolderBrowserDialog();
            lobjDialog.ShowNewFolderButton = true;
            DialogResult dlgResult = lobjDialog.ShowDialog();

            switch (dlgResult)
            {
                case DialogResult.OK:
                    // Get the path for the selected folder
                    txtOutPutDir.Text = lobjDialog.SelectedPath;
                    break;
                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void btnReadProperties_Click(object sender, EventArgs e)
        {
            if (txtTiffFilePath.Text.Trim().Length == 0)
                return;

            // Read Tiff file tags
            ReadTiffProperties(txtTiffFilePath.Text);
        }

        /// <summary>
        /// This method reads the value of each metadata property of the tiff file
        /// </summary>
        /// <param name="pstrFilePath"></param>
        private void ReadTiffProperties(string pstrFilePath)
        {
            try
            {
                System.Drawing.Bitmap newImage = new System.Drawing.Bitmap(pstrFilePath);

                // Get the properties collection of the file
                System.Drawing.Imaging.PropertyItem[] tiffProperties = newImage.PropertyItems;
                PropertyItem currentItem = null;
                object objValue = null;

                for (int i = 0; i < tiffProperties.GetLength(0); i++)
                {
                    currentItem = tiffProperties[i];                    
                    objValue = ReadPropertyValue(currentItem.Type, currentItem.Value);
                }
                newImage = null;
                tiffProperties = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// This method reads the tiff property based on the property type
        /// </summary>
        /// <param name="pItemType"></param>
        /// <param name="pitemValue"></param>
        /// <returns></returns>
        private object ReadPropertyValue(short pItemType, byte[] pitemValue)
        {
            // Read all the properties of the file.
            object objValue = null;
            System.Text.Encoding asciiEnc = System.Text.Encoding.ASCII;
            // Read the values based on the type of the propery
            switch (pItemType)
            {
                case 2: // Value is a null-terminated ASCII string. 
                    objValue = asciiEnc.GetString(pitemValue);
                    break;
                case 3: // Value is an array of unsigned short (16-bit) integers.
                    objValue = System.BitConverter.ToUInt16(pitemValue, 0);
                    break;
                case 4: // Value is an array of unsigned long (32-bit) integers.
                    objValue = System.BitConverter.ToUInt32(pitemValue, 0);
                    break;                
                default:
                    break;
            }
            return objValue;
        }

    }
}