using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace catalog
{
    public partial class Form1 : Form
    {
        int discount;
        int bill = 0;
        int orange = 100;
        int lemon = 200;
        int canberry = 300;
        
        


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox3.Text == "Mr.")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
                // Form1 Form2=new Form1();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && checkBox5.Checked != true)
            {
                textBox3.Text = "Choose all products to avail a 20% discount";
            }
        }
        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                textBox3.Text = "Choose all products to avail a 20% discount";
            }

        }

        public void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && checkBox5.Checked != true)
            {
                textBox3.Text = "Choose all products to avail a 20% discount";
            }
            if (radioButton2.Checked == true)
            {
                textBox3.Text = "Additional 20% discount!\nRip advantages of being a female!";
            }

        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("AUTHOR: ABHISHEK DE"));
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
            }
            if (checkBox5.Checked == false)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            if (checkBox2.Checked == false || checkBox3.Checked == false || checkBox4.Checked == false)
            {
                checkBox5.Checked = false;
            }
        }



        public void button2_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                discount = 20;
                bill = 600 - (discount * 6);

            }
            else if (checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false)
            {
                bill = orange;
            }
            else if (checkBox2.Checked == true && checkBox3.Checked == true)
            {
                bill = orange + lemon;
            }
            else if (checkBox2.Checked == true && checkBox4.Checked == true)
            {
                bill = orange + canberry;
            }
            else if (checkBox3.Checked == true && checkBox4.Checked == false)
            {
                bill = lemon;
            }
            else if (checkBox3.Checked == true && checkBox4.Checked == true)
            {
                bill = lemon + canberry;
            }
            else if (checkBox4.Checked == true)
            {
                bill = canberry;
            }
            textBox2.Text = "Total Bill is: Rs." + Convert.ToString(bill) + ".Thank You! Your Agent name is:" + comboBox2.Text;

            
            MessageBox.Show(string.Format("{0}", this.textBox2.Text));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "Succesfully added!!";
        }

    }
}