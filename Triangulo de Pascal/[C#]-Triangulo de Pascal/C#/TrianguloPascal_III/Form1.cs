using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrianguloPascal_III
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }

        private void button2_Click(object sender, EventArgs e)
            {
            Application.Exit();
            }
        //Variables
       int numero;

        private void button1_Click(object sender, EventArgs e)
            {
            for (int y = 0; y < numero; y++)
                {
                int c = 1;
                for (int q = 0; q < numero - y; q++)
                    {
                    textBox2.Text += "   ";
                    }
                    for (int x = 0; x <= y; x++)
                        {
                      //  textBox2.AppendText(c.ToString());
                        textBox2.Text += "    " + "\n";
                        c = c * (y - x) / (x + 1);
                        }
                    textBox2.Text += "   \r\n";
                    }
                }
            
        private void textBox1_TextChanged(object sender, EventArgs e)
            {
             numero = int.Parse(textBox1.Text);
            }
        }
    }
