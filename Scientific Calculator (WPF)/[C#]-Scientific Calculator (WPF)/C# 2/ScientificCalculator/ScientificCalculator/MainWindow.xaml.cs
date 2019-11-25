using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScientificCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal num1 = 0;
        decimal num2 = 0;
        string Operator = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void input(string a)
        {
            if (txt_Main.Text == "0")
                txt_Main.Text = a;
            else
                txt_Main.Text += a;
        }

        private void btn_O_Click(object sender, RoutedEventArgs e)
        {
            Button btn_Operator = (Button)sender;
            Operator = btn_Operator.Content.ToString();
            num1 = decimal.Parse(txt_Main.Text);
            txt_Main.Text = "0";
        }

        private void btn_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn_Number = (Button)sender;
            input(btn_Number.Content.ToString());
        }

        private void btn_Dot_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Main.Text != "")
            {
                if (!txt_Main.Text.Contains("."))
                    input(".");
            }
        }

        private void txt_Main_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Main.Text != "0")
            {
                if (txt_Main.Text.Length == 1)
                {
                    txt_Main.Text = "0";
                }
                else if (txt_Main.Text.Length > 0)
                {
                    txt_Main.Text = txt_Main.Text.Substring(0, txt_Main.Text.Length - 1);
                }
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txt_Main.Text = "0";
            Operator = "";
            num1 = 0;
            num2 = 0;
        }

        private void btn_Equal_Click(object sender, RoutedEventArgs e)
        {
            num2 = decimal.Parse(txt_Main.Text);
            ////////////////////////////////
            switch (Operator)
            {
                case "+":
                    txt_Main.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    txt_Main.Text = (num1 - num2).ToString();
                    break;
                case "×":
                    txt_Main.Text = (num1 * num2).ToString();
                    break;
                case "÷":
                    txt_Main.Text = (num1 / num2).ToString();
                    break;
                case "^":
                    txt_Main.Text = (Math.Pow(double.Parse(num1.ToString()),double.Parse(num2.ToString()))).ToString();
                    break;
                case "Mod":
                    txt_Main.Text = (num1 % num2).ToString();
                    break;
            }
        }

        private void btn_Sin_Click(object sender, RoutedEventArgs e)
        {
            if (Operator == "")
                txt_Main.Text = (Math.Sin(double.Parse(txt_Main.Text))).ToString();
            else if (num1 != 0 && Operator != "" && num2 == 0)
                txt_Main.Text = (Math.Sin(double.Parse(num1.ToString()))).ToString();
            else
            {
                num2 = decimal.Parse(txt_Main.Text);
                ////////////////////////////////
                switch (Operator)
                {
                    case "+":
                        txt_Main.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        txt_Main.Text = (num1 - num2).ToString();
                        break;
                    case "×":
                        txt_Main.Text = (num1 * num2).ToString();
                        break;
                    case "÷":
                        txt_Main.Text = (num1 / num2).ToString();
                        break;
                    case "^":
                        txt_Main.Text = (Math.Pow(double.Parse(num1.ToString()), double.Parse(num2.ToString()))).ToString();
                        break;
                    case "Mod":
                        txt_Main.Text = (num1 % num2).ToString();
                        break;
                }

                txt_Main.Text = (Math.Sin(double.Parse(txt_Main.Text))).ToString();
            }
        }

        private void btn_Cos_Click(object sender, RoutedEventArgs e)
        {
            if (Operator == "")
                txt_Main.Text = (Math.Cos(double.Parse(txt_Main.Text))).ToString();
            else if (num1 != 0 && Operator != "" && num2 == 0)
                txt_Main.Text = (Math.Cos(double.Parse(num1.ToString()))).ToString();
            else
            {
                num2 = decimal.Parse(txt_Main.Text);
                ////////////////////////////////
                switch (Operator)
                {
                    case "+":
                        txt_Main.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        txt_Main.Text = (num1 - num2).ToString();
                        break;
                    case "×":
                        txt_Main.Text = (num1 * num2).ToString();
                        break;
                    case "÷":
                        txt_Main.Text = (num1 / num2).ToString();
                        break;
                    case "^":
                        txt_Main.Text = (Math.Pow(double.Parse(num1.ToString()), double.Parse(num2.ToString()))).ToString();
                        break;
                    case "Mod":
                        txt_Main.Text = (num1 % num2).ToString();
                        break;
                }

                txt_Main.Text = (Math.Cos(double.Parse(txt_Main.Text))).ToString();
            }
        }

        private void btn_Log_Click(object sender, RoutedEventArgs e)
        {
            if (Operator == "")
                txt_Main.Text = (Math.Log(double.Parse(txt_Main.Text))).ToString();
            else if (num1 != 0 && Operator != "" && num2 == 0)
                txt_Main.Text = (Math.Log(double.Parse(num1.ToString()))).ToString();
            else
            {
                num2 = decimal.Parse(txt_Main.Text);
                ////////////////////////////////
                switch (Operator)
                {
                    case "+":
                        txt_Main.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        txt_Main.Text = (num1 - num2).ToString();
                        break;
                    case "×":
                        txt_Main.Text = (num1 * num2).ToString();
                        break;
                    case "÷":
                        txt_Main.Text = (num1 / num2).ToString();
                        break;
                    case "^":
                        txt_Main.Text = (Math.Pow(double.Parse(num1.ToString()), double.Parse(num2.ToString()))).ToString();
                        break;
                    case "Mod":
                        txt_Main.Text = (num1 % num2).ToString();
                        break;
                }

                txt_Main.Text = (Math.Log(double.Parse(txt_Main.Text))).ToString();
            }
        }

        private void btn_Radical_Click(object sender, RoutedEventArgs e)
        {
            if (Operator == "")
                txt_Main.Text = (Math.Sqrt(double.Parse(txt_Main.Text))).ToString();
            else if (num1 != 0 && Operator != "" && num2 == 0)
                txt_Main.Text = (Math.Sqrt(double.Parse(num1.ToString()))).ToString();
            else
            {
                num2 = decimal.Parse(txt_Main.Text);
                ////////////////////////////////
                switch (Operator)
                {
                    case "+":
                        txt_Main.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        txt_Main.Text = (num1 - num2).ToString();
                        break;
                    case "×":
                        txt_Main.Text = (num1 * num2).ToString();
                        break;
                    case "÷":
                        txt_Main.Text = (num1 / num2).ToString();
                        break;
                    case "^":
                        txt_Main.Text = (Math.Pow(double.Parse(num1.ToString()), double.Parse(num2.ToString()))).ToString();
                        break;
                    case "Mod":
                        txt_Main.Text = (num1 % num2).ToString();
                        break;
                }

                txt_Main.Text = (Math.Sqrt(double.Parse(txt_Main.Text))).ToString();
            }
        }

        private void btn_Tan_Click(object sender, RoutedEventArgs e)
        {
            if (Operator == "")
                txt_Main.Text = (Math.Tan(double.Parse(txt_Main.Text))).ToString();
            else if (num1 != 0 && Operator != "" && num2 == 0)
                txt_Main.Text = (Math.Tan(double.Parse(num1.ToString()))).ToString();
            else
            {
                num2 = decimal.Parse(txt_Main.Text);
                ////////////////////////////////
                switch (Operator)
                {
                    case "+":
                        txt_Main.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        txt_Main.Text = (num1 - num2).ToString();
                        break;
                    case "×":
                        txt_Main.Text = (num1 * num2).ToString();
                        break;
                    case "÷":
                        txt_Main.Text = (num1 / num2).ToString();
                        break;
                    case "^":
                        txt_Main.Text = (Math.Pow(double.Parse(num1.ToString()), double.Parse(num2.ToString()))).ToString();
                        break;
                    case "Mod":
                        txt_Main.Text = (num1 % num2).ToString();
                        break;
                }

                txt_Main.Text = (Math.Tan(double.Parse(txt_Main.Text))).ToString();
            }
        }

        private void btn_Fact_Click(object sender, RoutedEventArgs e)
        {
            long f = 1;
            for (long i = 1; i <= long.Parse(txt_Main.Text); i++)
            {
                f = f * i;
            }
            txt_Main.Text = f.ToString();
        }
    }
}