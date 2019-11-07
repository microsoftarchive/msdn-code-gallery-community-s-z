using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Add new event attachment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // existing file to insert into table
            var FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CPR_Facts.xlsx");

            // find parent event by title
            var eventTitle = "CPR Training";

            // wil have new key for newly added row
            var NewIdentifier = 0;

            var ops = new EntityOperations();

            if (ops.AddNewAttachement(eventTitle,FilePath, ref NewIdentifier))
            {
                MessageBox.Show($"Id {NewIdentifier}");
            }
            else
            {
                MessageBox.Show(ops.ExceptionMessage);
            }

        }

        /// <summary>
        /// Get names of courses into a ListBox and setup so that on selection
        /// change file attachments are shown in the DataGridVIew
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            using (theContext context = new theContext())
            {
                var result = context.SampleEvents.Select(item => new EventItem
                    {
                        id = item.id,
                        Description = item.Description
                    }).ToList();

                listBox1.DataSource = result;
                listBox1.DisplayMember = "Description";
            }

            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

            GetRelatedFiles();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRelatedFiles();
        }
        /// <summary>
        /// Get known attachments for the course selected in the ListBox
        /// </summary>
        private void GetRelatedFiles()
        {
            using (theContext context = new theContext())
            {
                dataGridView1.DataSource = context
                    .EventAttachments
                    .Select(item => new EventFiles { id = item.EventId, FileName = item.FileBaseName + item.FileExtention })
                    .Where(item => item.id == ((EventItem)listBox1.SelectedItem).id)
                    .ToList();

                dataGridView1.ExpandColumns();
            }
        }
    }
}
