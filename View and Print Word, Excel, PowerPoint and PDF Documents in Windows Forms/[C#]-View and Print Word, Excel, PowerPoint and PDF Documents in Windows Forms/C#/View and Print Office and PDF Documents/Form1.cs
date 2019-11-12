using System.Windows.Forms;

namespace View_and_Print_Office_and_PDF_Documents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.officeViewer1.LoadFromFile(@"E:\Program Files\Test.pdf");
        }
    }
}
