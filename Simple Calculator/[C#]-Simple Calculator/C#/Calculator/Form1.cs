using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        //Designed By: Yousif Garabet
        //Date: 18/11/2012
        private Double NewNumber = 0;
        private Double OldNumber = 0;
        private String Operation = "";
        private Boolean Clear = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private Double Calculate(Double Number1, Double Number2, String Operator)
        {
            Double Result = 0.0;
            switch (Operator)
            {
                case "+":
                    Result = Number1 + Number2;
                    break;
                case "-":
                    Result = Number1 - Number2;
                    break;
                case "*":
                    Result = Number1 * Number2;
                    break;
                case "/":
                    if (Number2 != 0)
                        Result = Number1 / Number2;
                    else
                        txtResult.Text = "Cannot divide by zero";
                    break;
            }
            return Result;
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtResult.Text!="0")
            {
                txtResult.Text += "0";
            }
       
              

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "1";
                Clear = false;
            }
            else
                txtResult.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "2";
                Clear = false;
            }
            else
                txtResult.Text += "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {

            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "3";
                Clear = false;
            }
            else
                txtResult.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "4";
                Clear = false;
            }
            else
                txtResult.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "5";
                Clear = false;
            }
            else
                txtResult.Text += "5";

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "6";
                Clear = false;
            }
            else
                txtResult.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "7";
                Clear = false;
            }
            else
                txtResult.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "8";
                Clear = false;
            }
            else
                txtResult.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {

            if (txtResult.Text == "0" || Clear)
            {
                txtResult.Text = "9";
                Clear = false;
            }
            else
                txtResult.Text += "9";
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {

            if (Operation == "")
            {
                Operation = "/";
                OldNumber = NewNumber = 1;
            }
            NewNumber = Convert.ToDouble(txtResult.Text);

            Clear = true;
            txtResult.Text = Calculate(NewNumber, OldNumber, Operation).ToString();
            OldNumber = Calculate(NewNumber, OldNumber, Operation);
            Operation = "/";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (Operation == "")
            {
                Operation = "*";
                OldNumber = NewNumber = 1;
            }
            NewNumber = Convert.ToDouble(txtResult.Text);

            Clear = true;
            txtResult.Text = Calculate(OldNumber, NewNumber, Operation).ToString();
            OldNumber = Calculate(OldNumber, NewNumber, Operation);
            Operation = "*";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (Operation == "")
                Operation = "+";

            NewNumber = Convert.ToDouble(txtResult.Text);

            Clear = true;
            txtResult.Text = Calculate(OldNumber, NewNumber, Operation).ToString();
            OldNumber = Calculate(OldNumber, NewNumber, Operation);
            Operation = "+";
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (Operation == "")
                Operation = "-";

            NewNumber = Convert.ToDouble(txtResult.Text);

            Clear = true;
            txtResult.Text = Calculate(NewNumber, OldNumber, Operation).ToString();
            OldNumber = Calculate(NewNumber, OldNumber, Operation);
            Operation = "-";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if ((txtResult.Text.Length == 0) && !(txtResult.Text.Contains(".")))
                txtResult.Text += "0.";
            if ((txtResult.Text.Length != 0) && !(txtResult.Text.Contains(".")))
                txtResult.Text += ".";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            NewNumber = Convert.ToDouble(txtResult.Text);
            txtResult.Text = Calculate(OldNumber, NewNumber, Operation).ToString();
            Clear = true;
            OldNumber = NewNumber = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            try
            {
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtResult.Text = "0";
        }


    }
}
