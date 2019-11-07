using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1_cs
{
    public partial class SelectStatementForm : Form
    {
        public string Statement { get; set; }
        public SelectStatementForm()
        {
            InitializeComponent();
        }

        private void SelectStatementForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Statement;
            ActiveControl = button1;
        }
    }
}
