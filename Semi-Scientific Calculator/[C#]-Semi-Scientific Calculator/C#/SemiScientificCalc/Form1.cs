using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;

namespace SemiScientificCalc
{
    public partial class SemiScientificCalc : Form  //GlassForm
    {
        string sign;
        double num1, num2;
        
        public SemiScientificCalc()
        {
            InitializeComponent();
        //    AeroGlassCompositionChanged += (source, args) => ExcludeControlFromAeroGlass(BackPanel);
        }

        private void returnReadyStatus()
        {
            StatusLabel.Text = "Ready";
        }

        private void FileMenu_MouseHover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Select an action";
        }

        private void FileMenu_MouseLeave(object sender, EventArgs e)
        {
            returnReadyStatus();
        }

        private void FileExitMenu_MouseHover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Exit the program";
        }

        private void FileExitMenu_MouseLeave(object sender, EventArgs e)
        {
            returnReadyStatus();
        }

        private void AboutMenu_MouseHover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Select an action";
        }

        private void AboutMenu_MouseLeave(object sender, EventArgs e)
        {
            returnReadyStatus();
        }

        private void AboutCalcMenu_MouseHover(object sender, EventArgs e)
        {
            StatusLabel.Text = "About the program";
        }

        private void AboutCalcMenu_MouseLeave(object sender, EventArgs e)
        {
            returnReadyStatus();
        }

        private void ClearCalc_MouseHover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Clear all calculation";
        }

        private void ClearCalc_MouseLeave(object sender, EventArgs e)
        {
            returnReadyStatus();
        }

        private void EqualCalc_MouseHover(object sender, EventArgs e)
        {
            StatusLabel.Text = "Calculate";
        }

        private void EqualCalc_MouseLeave(object sender, EventArgs e)
        {
            returnReadyStatus();
        }

        private void AboutCalcMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Semi-Scientific Calculator v1.2\n(formerly known as Basic Calculator v1.1)\nby SQUILLACIUKM\n\n\t\t2014 AllWorldWeb");
        }

        private void FileExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            no0.Click += new EventHandler(button_Click);
            no1.Click += new EventHandler(button_Click);
            no2.Click += new EventHandler(button_Click);
            no3.Click += new EventHandler(button_Click);
            no4.Click += new EventHandler(button_Click);
            no5.Click += new EventHandler(button_Click);
            no6.Click += new EventHandler(button_Click);
            no7.Click += new EventHandler(button_Click);
            no8.Click += new EventHandler(button_Click);
            no9.Click += new EventHandler(button_Click);
            DotOperator.Click += new EventHandler(button_Click);
            NegativeSign.Click += new EventHandler(button_Click);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            try
            {
                switch (btn.Text)
                {
                    case "0": DispBox.Text += "0"; break;
                    case "1": DispBox.Text += "1"; break;
                    case "2": DispBox.Text += "2"; break;
                    case "3": DispBox.Text += "3"; break;
                    case "4": DispBox.Text += "4"; break;
                    case "5": DispBox.Text += "5"; break;
                    case "6": DispBox.Text += "6"; break;
                    case "7": DispBox.Text += "7"; break;
                    case "8": DispBox.Text += "8"; break;
                    case "9": DispBox.Text += "9"; break;
                    case ".":
                        if (!(DispBox.Text.Contains('.') || DispBox.Text.Contains(".")))
                        { DispBox.Text += "."; } break;
                    case "-":
                        if (!(DispBox.Text.Contains('-') || DispBox.Text.Contains("-")))
                        { DispBox.Text += "-"; } break;
                }
            }
            catch (Exception)
            { MessageBox.Show("Unexpected error occurs"); }
        }
        
        private void DispBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': break;
                case '-':
                        if (DispBox.Text.Contains('-') || DispBox.Text.Contains("-"))
                        {
                            e.Handled = true;
                            StatusLabel.Text = "a number cannot have more than one negative sign";
                        }
                        break;
                case '.':
                        if (DispBox.Text.Contains('.') || DispBox.Text.Contains("."))
                        { 
                            e.Handled = true;
                            StatusLabel.Text = "a number cannot have more than one dot operator";
                        }
                        break;
                default :
                        {
                            e.Handled = true;
                            StatusLabel.Text = string.Format("input {0} is invalid", e.KeyChar);
                        }
                        break;
            }
        }

        private void parseNum1andEmptyDispBox()
        {
            num1 = double.Parse(DispBox.Text);
            DispBox.Text = string.Empty;
        }

        private void Adds_Click(object sender, EventArgs e)
        {
            parseNum1andEmptyDispBox();
            sign = "+";
        }

        private void Subs_Click(object sender, EventArgs e)
        {
            parseNum1andEmptyDispBox();
            sign = "-";
        }

        private void Multiples_Click(object sender, EventArgs e)
        {
            parseNum1andEmptyDispBox();
            sign = "*";
        }

        private void Divs_Click(object sender, EventArgs e)
        {
            parseNum1andEmptyDispBox();
            sign = "/";
        }

        private void dispResult()
        {
            string num1Result = num1.ToString();
            if (num1Result.Contains('.') || num1Result.Contains("."))
            { DispBox.Text = string.Format("{0:N3}", num1); }
            else
            { DispBox.Text = string.Format("{0:N0}", num1); }
        }

        private void EqualCalc_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(DispBox.Text);

            switch (sign)
            {
                case "+": num1 += num2; dispResult(); break;
                case "-": num1 -= num2; dispResult(); break;
                case "*": num1 *= num2; dispResult(); break;
                case "/":
                            if (num2 != 0)
                            { num1 /= num2; dispResult(); }
                            else
                            { MessageBox.Show("Math error"); }
                            break;
            }
        }

        

        private void ClearCalc_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            sign = string.Empty;
            DispBox.Text = string.Empty;
            MessageBox.Show("Cleared");
        }

        private void Percentages_Click(object sender, EventArgs e)
        {
            if (DispBox.Text.Contains('.') || DispBox.Text.Contains("."))
            { DispBox.Text = string.Format("{0:N3}%", num1 * 100); }
            else
            { DispBox.Text = string.Format("{0:N0}%", num1 * 100); }
        }

        private void SquareValue_Click(object sender, EventArgs e)
        {
            num1 *= num1;
            dispResult();
        }

        private void CubeValue_Click(object sender, EventArgs e)
        {
            num1 = (num1 * num1 * num1);
            dispResult();
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            num1 = Math.Sqrt(num1);
            dispResult();
        }

        private void SinValue_Click(object sender, EventArgs e)
        {
            num1 = Math.Sin(num1);
            dispResult();
        }

        private void CosValue_Click(object sender, EventArgs e)
        {
            num1 = Math.Cos(num1);
            dispResult();
        }

        private void TanValue_Click(object sender, EventArgs e)
        {
            num1 = Math.Tan(num1);
            dispResult();
        }

        private void Exponentials_Click(object sender, EventArgs e)
        {
            num1 = Math.Exp(num1);
            dispResult();
        }

        private void RoundingValue_Click(object sender, EventArgs e)
        {
            num1 = Math.Round(num1);
            dispResult();
        }


    }
}
