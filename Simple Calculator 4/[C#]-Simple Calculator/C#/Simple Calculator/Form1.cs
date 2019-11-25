using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Madhava Krishnan B
//bmmaddy@gmail.com

namespace Simple_Calculator
{
    public partial class Frm_Calc : Form
    {
        bool firstchar;
        string function = "";
        bool _decimal;
        double num1;
        double num2;
        DateTime _start = DateTime.MinValue;
        TimeSpan _Elapse = TimeSpan.Zero;
        string Elapse;
        bool Reverse;

        public Frm_Calc()
        {
            InitializeComponent();
        }
                
        private void Btn_Click(object sender, EventArgs e)
        {
            Button Btn = (Button)sender;
            if (firstchar)
            {
                Txt_Out.Text += Btn.Text;
            }
            else
            {
                Txt_Out.Text = Btn.Text;
                firstchar = true;
            }
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            if (firstchar)
                if (Txt_Out.Text.Length > 0)
                    Txt_Out.Text += Btn0.Text;
        }

        private void Btn_Dec_Click(object sender, EventArgs e)
        {
            
             if (!_decimal)
                {
                    if (Txt_Out.Text == "")
                    {
                        Txt_Out.Text = "0.";
                    }
                    else
                    {
                        if (Txt_Out.Text != "0")
                        {
                            Txt_Out.Text += Btn_Dec.Text;
                        }
                        else
                        {
                            Txt_Out.Text = "0.";
                        }
                    }
                    _decimal = true;
                    firstchar = true;
                }
        }
        
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (Txt_Out.Text.Length != 0)
            {
                if (function == "")
                {
                    num1 = System.Double.Parse(Txt_Out.Text);
                    Txt_Out.Text = string.Empty;
                }
                else
                {
                    Calc();
                }
                function = "Add";
                _decimal = false;
            }
        }

        private void Btn_Sub_Click(object sender, EventArgs e)
        {
            if (Txt_Out.Text.Length != 0)
            {
                if (function == "")
                {
                    num1 = System.Double.Parse(Txt_Out.Text);
                    Txt_Out.Text = string.Empty;
                }
                else
                {
                    Calc();
                }
                function = "Sub";
                _decimal = false;
            }
        }

        private void Btn_Mul_Click(object sender, EventArgs e)
        {
            if (Txt_Out.Text.Length != 0)
            {
                if (function == "")
                {
                    num1 = System.Double.Parse(Txt_Out.Text);
                    Txt_Out.Text = string.Empty;
                }
                else
                {
                    Calc();
                }
                function = "Mul";
                _decimal = false;
            }
        }

        private void Btn_Div_Click(object sender, EventArgs e)
        {
            if (Txt_Out.Text.Length != 0)
            {
                if (function == "")
                {
                    num1 = System.Double.Parse(Txt_Out.Text);
                    Txt_Out.Text = string.Empty;
                }
                else
                {
                    Calc();
                }
                function = "Div";
                _decimal = false;
            }
        }

        private void Calc()
        {
            num2 = System.Double.Parse(Txt_Out.Text);
            switch (function)
            {
                case "Add":
                    Txt_Out.Text = (num1 + num2).ToString();
                    num1 = num1 + num2;
                    break;

                case "Sub":
                    Txt_Out.Text = (num1 - num2).ToString();
                    num1 = num1 - num2;
                    break;

                case "Mul":
                    Txt_Out.Text = (num1 * num2).ToString();
                    num1 = num2 * num2;
                    break;

                case "Div":
                    Txt_Out.Text = (num1 / num2).ToString();
                    num1 = num1 / num2;
                    break;
                case "SqRoot":
                    Txt_Out.Text = Math.Sqrt(num1).ToString();
                    break;
            }
            firstchar = false;
            function = "";
            int avail = Txt_Out.Text.IndexOf(".");
            if (avail != -1)
            {
                _decimal = true;
            }
            else
            {
                _decimal = false;
            }
        }

        private void Btn_CE_Click(object sender, EventArgs e)
        {
            Txt_Out.Text = "0";
            _decimal = false;
            function = "";
            num1 = 0;
            num2 = 0;
            //Screensaver_Reset();
            //Run();
        }

        private void Btn_Eq_Click(object sender, EventArgs e)
        {
            if (Txt_Out.Text.Length != 0)
            {
                if (function != "")
                {
                    Calc();
                }
            }
            else
            {
                Txt_Out.Text = Txt_Out.Text;
            }
        }

        private void Btn_Sqroot_Click(object sender, EventArgs e)
        {
            if (Txt_Out.Text.Length != 0)
            {
                function = "SqRoot";
                num1 = System.Double.Parse(Txt_Out.Text);
                Calc();
            }
        }

        public static bool CheckKey (Keys In)
        {
            return  (In >= Keys.D0 && In <= Keys.D9 || In >= Keys.NumPad0 && In <= Keys.NumPad9 || In == Keys.Decimal || In == Keys.OemPeriod || In == Keys.Add || In == Keys.Subtract 
                        || In == Keys.Multiply || In == Keys.Divide || In == Keys.Oemplus || In == Keys.OemMinus);
        }

        private void Frm_Calc_KeyDown(object sender, KeyEventArgs e)
        {
            if (CheckKey(e.KeyCode))
            {
                switch (e.KeyCode)
                {

                    case Keys.D1:
                    case Keys.NumPad1:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn1.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn1.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D2:
                    case Keys.NumPad2:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn2.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn2.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D3:
                    case Keys.NumPad3:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn3.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn3.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D4:
                    case Keys.NumPad4:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn4.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn4.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D5:
                    case Keys.NumPad5:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn5.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn5.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D6:
                    case Keys.NumPad6:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn6.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn6.Text;
                            firstchar = true;
                        }
                        break;
                    case Keys.D7:
                    case Keys.NumPad7:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn7.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn7.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D8:
                    case Keys.NumPad8:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn8.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn8.Text;
                            firstchar = true;
                        }
                        break;
                    case Keys.D9:
                    case Keys.NumPad9:
                        if (firstchar)
                        {
                            Txt_Out.Text += Btn9.Text;
                        }
                        else
                        {
                            Txt_Out.Text = Btn9.Text;
                            firstchar = true;
                        }
                        break;

                    case Keys.D0:
                    case Keys.NumPad0:
                        if (firstchar)
                        {
                            if (Txt_Out.Text.Length > 0)
                            {
                                Txt_Out.Text += Btn0.Text;
                            }
                        }
                        break;

                    case Keys.Decimal:
                    case Keys.OemPeriod:
                        if (!_decimal)
                        {
                            if (Txt_Out.Text == "")
                            {
                                Txt_Out.Text = "0.";
                            }
                            else
                            {
                                if (Txt_Out.Text != "0")
                                {
                                    Txt_Out.Text += Btn_Dec.Text;
                                }
                                else
                                {
                                    Txt_Out.Text = "0.";
                                }
                            }
                            _decimal = true;
                            firstchar = true;
                        }
                        break;

                    case Keys.Add:
                    case Keys.Oemplus:
                        if (Txt_Out.Text.Length != 0)
                        {
                            if (function == "")
                            {
                                num1 = System.Double.Parse(Txt_Out.Text);
                                Txt_Out.Text = string.Empty;
                            }
                            else
                            {
                                Calc();
                            }
                            function = "Add";
                            _decimal = false;
                        }
                        break;

                    case Keys.Subtract:
                    case Keys.OemMinus:
                        if (Txt_Out.Text.Length != 0)
                        {
                            if (function == "")
                            {
                                num1 = System.Double.Parse(Txt_Out.Text);
                                Txt_Out.Text = string.Empty;
                            }
                            else
                            {
                                Calc();
                            }
                            function = "Sub";
                            _decimal = false;
                        }
                        break;

                    case Keys.Multiply:
                        if (Txt_Out.Text.Length != 0)
                        {
                            if (function == "")
                            {
                                num1 = System.Double.Parse(Txt_Out.Text);
                                Txt_Out.Text = string.Empty;
                            }
                            else
                            {
                                Calc();
                            }
                            function = "Mul";
                            _decimal = false;
                        }
                        break;

                    case Keys.Divide:
                        if (Txt_Out.Text.Length != 0)
                        {
                            if (function == "")
                            {
                                num1 = System.Double.Parse(Txt_Out.Text);
                                Txt_Out.Text = string.Empty;
                            }
                            else
                            {
                                Calc();
                            }
                            function = "Div";
                            _decimal = false;
                        }
                        break;
                }
            }
            else
            {
                if (e.KeyCode.ToString() == "Escape")
                {
                    Txt_Out.Text = "0";
                    _decimal = false;
                    function = "";
                    num1 = 0;
                    num2 = 0;
                    Screensaver_Reset();
                    Run();
                }
                else
                {
                    MessageBox.Show(" Please Enter a Numerical Value or Operator");
                }
            }
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //return (keyData == Keys.Enter);
            if(msg.WParam.ToInt32() == (int)Keys.Enter)
            {
                if (Txt_Out.Text.Length != 0)
                {
                    if (function != "")
                    {
                        Calc();
                    }
                }
                else
                {
                   Txt_Out.Text = Txt_Out.Text;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Run()
        {
            if (Txt_Out.Text.Length == 0 | Txt_Out.Text == "0")
            {
                if (Elapse == "9")
                {
                    Txt_Madhava.Visible = true;
                }
                if (timer1.Enabled != true)
                {
                    timer1.Interval = 1000;
                    timer1.Start();
                    _start = DateTime.Now;
                }
            }
            else
            {
                Screensaver_Reset();
            }
            if (timer1.Enabled == true)
            {
                switch (Elapse)
                {
                    case "10":
                        Txt_Madhava.Text = "M";
                        break;
                    case "11":
                        Txt_Madhava.Text = "MA";
                        break;
                    case "12":
                        Txt_Madhava.Text = "MAD";
                        break;
                    case "13":
                        Txt_Madhava.Text = "MADH";
                        break;
                    case "14":
                        Txt_Madhava.Text = "MADHA";
                        break;
                    case "15":
                        Txt_Madhava.Text = "MADHAV";
                        break;
                    case "16":
                        Txt_Madhava.Text = "MADHAVA";
                        break;
                    case "17":
                        Txt_Madhava.Text = "MADHAVA ";
                        break;
                    case "18":
                        Txt_Madhava.Text = "MADHAVA K";
                        break;
                    case "19":
                        Txt_Madhava.Text = "MADHAVA KR";
                        break;
                    case "20":
                        Txt_Madhava.Text = "MADHAVA KRI";
                        break;
                    case "21":
                        Txt_Madhava.Text = "MADHAVA KRIS";
                        break;
                    case "22":
                        Txt_Madhava.Text = "MADHAVA KRISH";
                        break;
                    case "23":
                        Txt_Madhava.Text = "MADHAVA KRISHN";
                        break;
                    case "24":
                        Txt_Madhava.Text = "MADHAVA KRISHNA";
                        break;
                    case "25":
                        Txt_Madhava.Text = "MADHAVA KRISHNAN";
                        break;
                    case "26":
                        Txt_Madhava.Text = "MADHAVA KRISHNAN ";
                        break;
                    case "27":
                        Txt_Madhava.Text = "MADHAVA KRISHNAN B";
                        break;
                    case "28":
                        Txt_Madhava.Text = "";
                        break;
                    case "29":
                        Txt_Madhava.Text = "MADHAVA KRISHNAN B";
                        break;
                    case "30":
                        Txt_Madhava.Text = "";
                        break;
                    case "31":
                        Txt_Madhava.Text = "MADHAVA KRISHNAN B";
                        break;
                }
            }
            if (Elapse == "31")
            {
                _Elapse = new TimeSpan(0,0,8);
                Elapse = "8";
                timer1.Stop();
                timer1.Enabled = false;
                Run();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //_Elapse = DateTime.Now - _start;
            //_Elapse = new TimeSpan(_Elapse.Hours,_Elapse.Minutes, _Elapse.Seconds);
            //Elapse = _Elapse.Seconds.ToString();
            //Run();
        }

        private void Frm_Calc_Load(object sender, EventArgs e)
        {
            //Run();
            Marq_Tmr.Enabled = true;
            Marq_Tmr.Start();
            Marq_Tmr.Interval = 100;
        }

        private void Screensaver_Reset()
        {
            Txt_Madhava.Visible = false;
            timer1.Enabled = false;
            timer1.Stop();
            _start = DateTime.MinValue;
            _Elapse = TimeSpan.Zero;
            Elapse = "";
        }

        private void Marquee(int Width)
        {
            if (label1.Location.X > Width - 100)
            {
                Reverse = true;
            }
            if (label1.Location.X < 1)
            {
                Reverse = false;
            }

            if (Reverse)
            {
                label1.Location = new Point(label1.Location.X - 1, 275);
            }
            else
            {
                label1.Location = new Point(label1.Location.X + 1, 275);
            }

        }

        private void Marq_Tmr_Tick(object sender, EventArgs e)
        {
            Marquee(this.Width);
        }

    }
}

