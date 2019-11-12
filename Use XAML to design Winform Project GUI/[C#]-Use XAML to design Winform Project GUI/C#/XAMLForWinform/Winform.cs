using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XAMLForWinform
{
    public partial class Winform : Form
    {
        public Winform()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ctlTextBox.Text);
        }
    }
}
