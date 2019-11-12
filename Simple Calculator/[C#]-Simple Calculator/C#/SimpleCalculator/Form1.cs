using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Double val = 0;
        string operation = "";
        bool oper_pressed = false;

        int dotCount = 0;


        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            val = Double.Parse(inputBox.Text);
            oper_pressed = true;
            equation.Text = val + " " + operation;
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((inputBox.Text == "0") || (oper_pressed))
            {
                inputBox.Clear();
                dotCount = 0;
            }
                
            oper_pressed = false;
            Button b = (Button)sender;
            if(b.Text=="." && dotCount<1)
            {
                dotCount++;
                inputBox.Text = inputBox.Text + b.Text;
            }
            if(b.Text!=".")
            {
                inputBox.Text = inputBox.Text + b.Text;
            }
           
        }

        private void clear_click(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            dotCount = 0;
        }

        private void clear_all(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            val = 0;
            dotCount = 0;
        }

        private void equal_click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    inputBox.Text = (val + Double.Parse(inputBox.Text)).ToString();
                    break;
                case "-":
                    inputBox.Text = (val - Double.Parse(inputBox.Text)).ToString();
                    break;
                case "*":
                    inputBox.Text = (val * Double.Parse(inputBox.Text)).ToString();
                    break;
                case "/":
                    inputBox.Text = (val / Double.Parse(inputBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            double ans = double.Parse(inputBox.Text);
            if(ans==(double)ans)
            {
                dotCount = 1;
            }
            else
            dotCount = 0;
              
        }
    }
}
