using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveManager
{
    public partial class CreateNewArchive : Form
    {
        public CreateNewArchive()
        {
            InitializeComponent();

            cbxFileFormat.SelectedIndex = 0;
        }

        public ArchiverType Type
        {
            get { return (ArchiverType) cbxFileFormat.SelectedIndex; }
        }
    }
}