using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_cs
{
    public partial class EditorForm : Form
    {

        private List<City> cities = new List<City>();
        private Customer customer;
        public EditorForm()
        {
            InitializeComponent();
        }
        public EditorForm(ref Customer cust)
        {
            InitializeComponent();
            customer = cust;
        }
        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCity.DataSource = null;           
            cboCity.DisplayMember = "";

            // fix bug with ComboBox reload
            cboCity.Items.Add("");
            cboCity.Items.Clear();

            var id = ((State)cboState.SelectedItem).StateIdentifier;
            var result = cities.Where(city => city.StateIdentifier == id).ToList();
            if (result.Count >0 && result.First().Name != "Select one")
            {
                result.Insert(0, new City { CityIdentifier = 0, Name = "Select one" });
                cboCity.DataSource = result;
                cboCity.DisplayMember = "Name";
            }
            //result.ForEach(item => Console.WriteLine($"{item.StateIdentifier} - {item.CityIdentifier} - {item.Name}"));
            //Console.WriteLine();
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            var ops = new Operations();
            if (ops.GetStates())
            {
                cboState.DisplayMember = "Name";
                cboState.DataSource = ops.States;
            }
            if (ops.GetCities())
            {
                cities = ops.Cities;
                Console.WriteLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((cboState.StateIdentifier() != 0) && (cboCity.CityIdentifier() != -1 && cboCity.CityIdentifier() != 0))
            {
                if (!string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    customer.CityIdentifier = cboCity.CityIdentifier();
                    customer.FirstName = txtFirstName.Text;
                    customer.LastName = txtLastName.Text;
                    customer.StateIdentifer = cboState.StateIdentifier();
                    customer.City = cboCity.Text;
                    customer.State = cboState.Text;

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("All fields are required");
                }
            }
            else
            {
                MessageBox.Show("Please select a state and city");
            }
        }
    }
}
