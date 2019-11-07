using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InterfaceWebCam
{
    public partial class frmExibeWebCam : Form
    {
        public frmExibeWebCam()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            userControl11.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            userControl11.Stop();
        }
    }
}
