using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Interest_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        float interest, Amount;

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                interest = Convert.ToSingle(textBox1.Text) * Convert.ToSingle(textBox2.Text) * Convert.ToSingle(textBox3.Text);
                Amount = interest + Convert.ToSingle(textBox1.Text);
                MessageBox.Show(" simple interest =" + " " + interest + " " + "Amount =" + Amount);
            }
            else
            {
                MessageBox.Show("please enter the value");
            }
            

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
