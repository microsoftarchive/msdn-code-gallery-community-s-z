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
    public partial class TestTransformsForm : Form
    {
        private double[] x;
        private int n;
        
        public TestTransformsForm(int n, double[] x)
        {
            InitializeComponent();
            this.n = n;
            this.x = new double[n];

            for (int i = 0; i < n; i++)
                this.x[i] = x[i];

            double[] u = new double[n];
            double[] v = new double[n];
            Complex complex = new Complex();
            Complex[] X = complex.DFT(this.x);
            Complex[] d = new Complex[n];
            Complex[] z = new Complex[n];

            for (int i = 0; i < n; i++)
            {
                Complex xc = new Complex(x[i], 0.0);

                d[i] = xc;
                z[i] = xc;
                u[i] = x[i];
                v[i] = 0.0;
            }

            Complex[] Z = complex.RecursiveFFT(z);
            int m = (int)Math.Log(n, 2.0);

            complex.FFT(1, m, u, v);
            complex.BitReversalFFT(n, d);

            textBox1.Text += "Forward Transforms Real Parts:\r\n\r\n";

            for (int i = 0; i < n; i++)
            {
                textBox1.Text += X[i].Re.ToString("E4") + "\t";
                textBox1.Text += z[i].Re.ToString("E4") + "\t";
                textBox1.Text += d[i].Re.ToString("E4") + "\t";
                textBox1.Text += u[i].ToString("E4") + "\r\n";
            }

            textBox1.Text += "\r\n";
            textBox1.Text += "Forward Transforms Imaginary Parts:\r\n\r\n";

            for (int i = 0; i < n; i++)
            {
                textBox1.Text += X[i].Im.ToString("E4") + "\t";
                textBox1.Text += z[i].Im.ToString("E4") + "\t";
                textBox1.Text += d[i].Im.ToString("E4") + "\t";
                textBox1.Text += v[i].ToString("E4") + "\r\n";
            }

            textBox1.Text += "\r\n";
            textBox1.Text += "Sample and Recovered Samples:\r\n\r\n";

            double[] s = complex.InverseDFT(X);

            complex.FFT(-1, m, u, v);

            for (int i = 0; i < n; i++)
            {
                textBox1.Text += x[i].ToString("E4") + "\t";
                textBox1.Text += s[i].ToString("E4") + "\t";
                textBox1.Text += u[i].ToString("E4") + "\r\n";
            }
        }
    }
}
