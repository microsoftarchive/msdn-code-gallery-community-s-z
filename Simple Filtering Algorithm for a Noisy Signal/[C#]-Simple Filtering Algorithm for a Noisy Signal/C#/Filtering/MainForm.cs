using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filtering
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse((string)comboBox1.SelectedItem);
            int seed = int.Parse((string)comboBox2.SelectedItem);
            double threshhold = double.Parse((string)comboBox3.SelectedItem);
            Signal signal = new Signal();
            double[] sample = signal.Sample(n);
            DrawGraphForm dgf0 = new DrawGraphForm(n, sample);
            dgf0.Show();
            double[] noisy = signal.AddWhiteNoise(n, seed, sample);
            DrawGraphForm dgf1 = new DrawGraphForm(n, noisy);
            dgf1.Show();
            double[] recovered = signal.Filter(n, threshhold, noisy);
            DrawGraphForm dgf2 = new DrawGraphForm(n, recovered);
            dgf2.Show();

            if (checkBox1.Checked)
            {
                TestTransformsForm ttf = new TestTransformsForm(n, sample);
                ttf.Show();
            }
        }
    }
}