using System.Windows.Forms;

namespace ArchiveManager
{
    public partial class ArchiveComment : Form
    {
        public ArchiveComment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the archive's comment.
        /// </summary>
        public string Comment
        {
            get { return txtComment.Text; }
            set { txtComment.Text = value; }
        }
    }
}