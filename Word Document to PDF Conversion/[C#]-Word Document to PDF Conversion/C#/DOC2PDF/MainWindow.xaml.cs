using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;


namespace DOC2PDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".doc";
            dlg.Filter = "Word documents (.doc)|*.docx;*.doc";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;
            }
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            wordDocument = appWord.Documents.Open(FileNameTextBox.Text);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Documents|*.pdf";
            try
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".pdf":
                            wordDocument.ExportAsFixedFormat(sfd.FileName, WdExportFormat.wdExportFormatPDF);
                            break;
                        case ".docx":
                            wordDocument.ExportAsFixedFormat(sfd.FileName, WdExportFormat.wdExportFormatPDF);
                            break;
                    }
                    pdfFileName.Text = sfd.FileName;
                }
                System.Windows.Forms.MessageBox.Show("File Converted Successfully..");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            System.Diagnostics.Process.Start(sfd.FileName);
        }

        public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
    }
}
